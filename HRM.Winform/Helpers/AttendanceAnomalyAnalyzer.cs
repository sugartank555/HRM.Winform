using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

namespace HRM.Winform.Helpers
{
    public sealed class AttendanceAnomalyAlert
    {
        public string MucDo { get; set; } = string.Empty;
        public string LoaiCanhBao { get; set; } = string.Empty;
        public DateTime NgayLamViec { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string PhongBan { get; set; } = string.Empty;
        public string ChiTiet { get; set; } = string.Empty;
        public string GoiYXuLy { get; set; } = string.Empty;
    }

    public sealed class AttendanceAnomalySummary
    {
        public int TongCanhBao { get; set; }
        public int MucDoCao { get; set; }
        public int DiMuonLapLai { get; set; }
        public int OtBatThuong { get; set; }
        public int XacThucCanKiemTra { get; set; }
        public string NhanXetTuDong { get; set; } = string.Empty;
    }

    public sealed class AttendanceAnomalyResult
    {
        public List<AttendanceAnomalyAlert> Alerts { get; set; } = [];
        public AttendanceAnomalySummary Summary { get; set; } = new();
    }

    public static class AttendanceAnomalyAnalyzer
    {
        private static readonly Regex DistanceRegex = new(@"CachVanPhong\s+(?<distance>\d+)m", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex AccuracyRegex = new(@"SaiSo\s+(?<accuracy>\d+)m", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static AttendanceAnomalyResult Analyze(int month, int year, int? nhanVienId = null)
        {
            using var db = new AppDbContext();

            var fromDate = new DateTime(year, month, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);

            var chamCongs = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.NhanVien)
                    .ThenInclude(x => x!.PhongBan)
                .Include(x => x.CaLamViec)
                .Where(x => x.NgayLamViec >= fromDate && x.NgayLamViec <= toDate);

            if (nhanVienId.HasValue && nhanVienId.Value > 0)
            {
                chamCongs = chamCongs.Where(x => x.NhanVienId == nhanVienId.Value);
            }

            var data = chamCongs.ToList();
            var alerts = new List<AttendanceAnomalyAlert>();

            foreach (var group in data.GroupBy(x => x.NhanVienId))
            {
                var ordered = group.OrderBy(x => x.NgayLamViec).ToList();
                var first = ordered.FirstOrDefault();
                if (first?.NhanVien == null)
                {
                    continue;
                }

                string maNhanVien = first.NhanVien.MaNhanVien;
                string hoTen = first.NhanVien.HoTen;
                string phongBan = first.NhanVien.PhongBan?.TenPhongBan ?? "Chua ro";

                int soLanDiMuon = ordered.Count(x => x.SoPhutDiMuon >= 10 || string.Equals(x.TrangThai, "DiMuon", StringComparison.OrdinalIgnoreCase));
                int tongPhutDiMuon = ordered.Sum(x => x.SoPhutDiMuon);
                if (soLanDiMuon >= 3)
                {
                    alerts.Add(new AttendanceAnomalyAlert
                    {
                        MucDo = soLanDiMuon >= 5 || tongPhutDiMuon >= 120 ? "Cao" : "TrungBinh",
                        LoaiCanhBao = "Di muon lap lai",
                        NgayLamViec = ordered.Last().NgayLamViec,
                        MaNhanVien = maNhanVien,
                        HoTen = hoTen,
                        PhongBan = phongBan,
                        ChiTiet = $"Di muon {soLanDiMuon} lan trong thang, tong {tongPhutDiMuon} phut.",
                        GoiYXuLy = "Trao doi voi nhan vien, doi chieu lich lam va xem xet nhac nho."
                    });
                }

                double avgHours = ordered.Average(x => x.SoGioLam);
                foreach (var chamCong in ordered)
                {
                    var tenCa = chamCong.CaLamViec?.TenCa ?? "Chua phan ca";

                    if (!chamCong.GioCheckIn.HasValue || !chamCong.GioCheckOut.HasValue)
                    {
                        alerts.Add(new AttendanceAnomalyAlert
                        {
                            MucDo = "Cao",
                            LoaiCanhBao = "Thieu du lieu check in/out",
                            NgayLamViec = chamCong.NgayLamViec,
                            MaNhanVien = maNhanVien,
                            HoTen = hoTen,
                            PhongBan = phongBan,
                            ChiTiet = $"Ban ghi ngay {chamCong.NgayLamViec:dd/MM/yyyy} cua ca {tenCa} thieu check in hoac check out.",
                            GoiYXuLy = "Yeu cau nhan vien gui don dieu chinh cong va HR doi chieu log."
                        });
                        continue;
                    }

                    if (chamCong.GioCheckOut < chamCong.GioCheckIn)
                    {
                        alerts.Add(new AttendanceAnomalyAlert
                        {
                            MucDo = "Cao",
                            LoaiCanhBao = "Thoi gian check out khong hop le",
                            NgayLamViec = chamCong.NgayLamViec,
                            MaNhanVien = maNhanVien,
                            HoTen = hoTen,
                            PhongBan = phongBan,
                            ChiTiet = $"Check out som hon check in trong ca {tenCa}.",
                            GoiYXuLy = "Kiem tra lai ban ghi cham cong va log xac thuc."
                        });
                    }

                    if (chamCong.SoGioLam is < 2 or > 16)
                    {
                        alerts.Add(new AttendanceAnomalyAlert
                        {
                            MucDo = chamCong.SoGioLam > 16 ? "Cao" : "TrungBinh",
                            LoaiCanhBao = "So gio lam bat thuong",
                            NgayLamViec = chamCong.NgayLamViec,
                            MaNhanVien = maNhanVien,
                            HoTen = hoTen,
                            PhongBan = phongBan,
                            ChiTiet = $"Tong gio lam {chamCong.SoGioLam:N1} gio trong ngay, lech so voi muc thong thuong.",
                            GoiYXuLy = "Doi chieu ca lam, lich su check in/out va don tang ca neu co."
                        });
                    }

                    if (avgHours > 0 && Math.Abs(chamCong.SoGioLam - avgHours) >= 3.5)
                    {
                        alerts.Add(new AttendanceAnomalyAlert
                        {
                            MucDo = "TrungBinh",
                            LoaiCanhBao = "Hanh vi cham cong lech lich su",
                            NgayLamViec = chamCong.NgayLamViec,
                            MaNhanVien = maNhanVien,
                            HoTen = hoTen,
                            PhongBan = phongBan,
                            ChiTiet = $"So gio lam {chamCong.SoGioLam:N1} gio, lech ro so voi trung binh ca nhan {avgHours:N1} gio.",
                            GoiYXuLy = "Xem lai tinh chat cong viec hom do va xac nhan voi quan ly."
                        });
                    }

                    if (chamCong.SoGioTangCa >= 4)
                    {
                        alerts.Add(new AttendanceAnomalyAlert
                        {
                            MucDo = chamCong.SoGioTangCa >= 6 ? "Cao" : "TrungBinh",
                            LoaiCanhBao = "Tang ca bat thuong",
                            NgayLamViec = chamCong.NgayLamViec,
                            MaNhanVien = maNhanVien,
                            HoTen = hoTen,
                            PhongBan = phongBan,
                            ChiTiet = $"Tang ca {chamCong.SoGioTangCa:N1} gio trong ngay.",
                            GoiYXuLy = "Doi chieu don tang ca da duyet va quy dinh OT noi bo."
                        });
                    }

                    if (TryExtractGpsAudit(chamCong.GhiChu, out int distance, out int accuracy))
                    {
                        if (distance >= 120 || accuracy >= 80)
                        {
                            alerts.Add(new AttendanceAnomalyAlert
                            {
                                MucDo = distance >= 150 ? "Cao" : "TrungBinh",
                                LoaiCanhBao = "Xac thuc GPS can kiem tra",
                                NgayLamViec = chamCong.NgayLamViec,
                                MaNhanVien = maNhanVien,
                                HoTen = hoTen,
                                PhongBan = phongBan,
                                ChiTiet = $"GPS check in cach van phong {distance}m, sai so {accuracy}m.",
                                GoiYXuLy = "Kiem tra vi tri thuc te, chat luong GPS va doi chieu anh/xac thuc khac."
                            });
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(chamCong.GhiChu) &&
                        chamCong.GhiChu.Contains("KhuonMat", StringComparison.OrdinalIgnoreCase) &&
                        chamCong.GhiChu.Contains("QR", StringComparison.OrdinalIgnoreCase))
                    {
                        alerts.Add(new AttendanceAnomalyAlert
                        {
                            MucDo = "Thap",
                            LoaiCanhBao = "Da dung nhieu phuong thuc xac thuc",
                            NgayLamViec = chamCong.NgayLamViec,
                            MaNhanVien = maNhanVien,
                            HoTen = hoTen,
                            PhongBan = phongBan,
                            ChiTiet = "Ban ghi co dau vet nhieu phuong thuc xac thuc trong cung ngay.",
                            GoiYXuLy = "Kiem tra nhu cau xac thuc lai va tranh cap nhat cong lap."
                        });
                    }
                }
            }

            alerts = alerts
                .OrderByDescending(x => SeverityRank(x.MucDo))
                .ThenByDescending(x => x.NgayLamViec)
                .ThenBy(x => x.HoTen)
                .ToList();

            return new AttendanceAnomalyResult
            {
                Alerts = alerts,
                Summary = BuildSummary(data, alerts, month, year)
            };
        }

        private static AttendanceAnomalySummary BuildSummary(List<Models.ChamCong> data, List<AttendanceAnomalyAlert> alerts, int month, int year)
        {
            var summary = new AttendanceAnomalySummary
            {
                TongCanhBao = alerts.Count,
                MucDoCao = alerts.Count(x => x.MucDo == "Cao"),
                DiMuonLapLai = alerts.Count(x => x.LoaiCanhBao == "Di muon lap lai"),
                OtBatThuong = alerts.Count(x => x.LoaiCanhBao == "Tang ca bat thuong"),
                XacThucCanKiemTra = alerts.Count(x => x.LoaiCanhBao == "Xac thuc GPS can kiem tra")
            };

            var topPhongBan = alerts
                .GroupBy(x => x.PhongBan)
                .OrderByDescending(x => x.Count())
                .Select(x => new { x.Key, Count = x.Count() })
                .FirstOrDefault();

            var topDiMuon = data
                .GroupBy(x => new { x.NhanVienId, MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "", HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "" })
                .Select(x => new
                {
                    x.Key.MaNhanVien,
                    x.Key.HoTen,
                    TongPhutDiMuon = x.Sum(v => v.SoPhutDiMuon)
                })
                .OrderByDescending(x => x.TongPhutDiMuon)
                .FirstOrDefault();

            var topOt = data
                .GroupBy(x => new { x.NhanVienId, MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "", HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "" })
                .Select(x => new
                {
                    x.Key.MaNhanVien,
                    x.Key.HoTen,
                    TongOt = x.Sum(v => v.SoGioTangCa)
                })
                .OrderByDescending(x => x.TongOt)
                .FirstOrDefault();

            var sb = new StringBuilder();
            sb.Append($"Tom tat tu dong thang {month:00}/{year}: ");

            if (alerts.Count == 0)
            {
                sb.Append("Khong phat hien bat thuong dang chu y trong du lieu cham cong.");
            }
            else
            {
                sb.Append($"He thong ghi nhan {alerts.Count} canh bao, trong do {summary.MucDoCao} muc do cao. ");

                if (topPhongBan != null)
                {
                    sb.Append($"Phong ban co nhieu canh bao nhat la {topPhongBan.Key} ({topPhongBan.Count} canh bao). ");
                }

                if (topDiMuon != null && topDiMuon.TongPhutDiMuon > 0)
                {
                    sb.Append($"Nhan vien di muon nhieu nhat la {topDiMuon.HoTen} ({topDiMuon.MaNhanVien}) voi {topDiMuon.TongPhutDiMuon} phut. ");
                }

                if (topOt != null && topOt.TongOt > 0)
                {
                    sb.Append($"OT cao nhat thuoc ve {topOt.HoTen} ({topOt.MaNhanVien}) voi {topOt.TongOt:N1} gio. ");
                }

                if (summary.XacThucCanKiemTra > 0)
                {
                    sb.Append("Can uu tien doi chieu cac ban ghi GPS co sai so lon hoac gan nguong cho phep.");
                }
            }

            summary.NhanXetTuDong = sb.ToString().Trim();
            return summary;
        }

        private static int SeverityRank(string severity)
        {
            return severity switch
            {
                "Cao" => 3,
                "TrungBinh" => 2,
                "Thap" => 1,
                _ => 0
            };
        }

        private static bool TryExtractGpsAudit(string? note, out int distance, out int accuracy)
        {
            distance = 0;
            accuracy = 0;

            if (string.IsNullOrWhiteSpace(note))
            {
                return false;
            }

            var distanceMatch = DistanceRegex.Match(note);
            var accuracyMatch = AccuracyRegex.Match(note);

            if (!distanceMatch.Success && !accuracyMatch.Success)
            {
                return false;
            }

            if (distanceMatch.Success)
            {
                int.TryParse(distanceMatch.Groups["distance"].Value, out distance);
            }

            if (accuracyMatch.Success)
            {
                int.TryParse(accuracyMatch.Groups["accuracy"].Value, out accuracy);
            }

            return true;
        }
    }
}
