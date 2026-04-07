using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace HRM.Winform.Helpers
{
    public static class InternalHrChatbotService
    {
        public static string Ask(string question, int nhanVienId)
        {
            string normalized = Normalize(question);

            if (string.IsNullOrWhiteSpace(normalized))
            {
                return BuildHelpMessage();
            }

            if (ContainsAll(normalized, "ca", "hom nay") || ContainsAll(normalized, "lich", "hom nay"))
            {
                return GetShiftToday(nhanVienId);
            }

            if (ContainsAny(normalized, "check in", "checkin", "cong hom nay", "cong") && ContainsAny(normalized, "hom nay", "today", "check out", "checkout"))
            {
                return GetAttendanceToday(nhanVienId);
            }

            if (ContainsAny(normalized, "phep", "nghi phep") && ContainsAny(normalized, "con", "bao nhieu", "so ngay"))
            {
                return GetLeaveBalance(nhanVienId);
            }

            if (ContainsAny(normalized, "don", "duyet don", "trang thai don"))
            {
                return GetRequestStatus(nhanVienId);
            }

            if (ContainsAny(normalized, "di muon", "muon") && ContainsAny(normalized, "thang", "bao nhieu", "lan"))
            {
                return GetLateStats(nhanVienId);
            }

            if (ContainsAny(normalized, "ot", "tang ca"))
            {
                return GetOvertimeStats(nhanVienId);
            }

            if (ContainsAny(normalized, "gan nhat", "cuoi cung", "moi nhat") &&
                ContainsAny(normalized, "check-in", "check in", "xac thuc", "qr", "gps", "khuon mat"))
            {
                return GetLatestVerification(nhanVienId);
            }

            if (ContainsAny(normalized, "that bai", "thanh cong", "xac thuc") &&
                ContainsAny(normalized, "hom nay", "gan day", "cuoi"))
            {
                return GetVerificationStatus(nhanVienId);
            }

            return BuildHelpMessage();
        }

        public static string BuildGreeting(string userName)
        {
            return $"Xin chao {userName}. Toi co the tra loi nhanh ve ca hom nay, cong hom nay, phep con lai, don tu, di muon va tang ca.";
        }

        private static string GetShiftToday(int nhanVienId)
        {
            using var db = new AppDbContext();
            var today = DateTime.Today;

            var shift = db.PhanCaNhanViens
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == nhanVienId && x.NgayLamViec == today);

            if (shift?.CaLamViec == null)
            {
                return "Hom nay ban chua duoc phan ca. Nen lien he quan ly hoac HR de xac nhan lich lam.";
            }

            return $"Ca hom nay cua ban la {shift.CaLamViec.TenCa} ({shift.CaLamViec.MaCa}), khung gio {shift.CaLamViec.GioBatDau:hh\\:mm} - {shift.CaLamViec.GioKetThuc:hh\\:mm}.";
        }

        private static string GetAttendanceToday(int nhanVienId)
        {
            using var db = new AppDbContext();
            var today = DateTime.Today;

            var attendance = db.ChamCongs
                .AsNoTracking()
                .FirstOrDefault(x => x.NhanVienId == nhanVienId && x.NgayLamViec == today);

            if (attendance == null)
            {
                return "Hom nay ban chua co ban ghi cham cong. Neu dang vao ca, ban co the check in bang QR, GPS hoac khuon mat.";
            }

            var checkIn = attendance.GioCheckIn?.ToString("HH:mm dd/MM") ?? "--";
            var checkOut = attendance.GioCheckOut?.ToString("HH:mm dd/MM") ?? "--";

            return $"Cong hom nay: trang thai {attendance.TrangThai}, check in {checkIn}, check out {checkOut}, di muon {attendance.SoPhutDiMuon} phut, ve som {attendance.SoPhutVeSom} phut.";
        }

        private static string GetLeaveBalance(int nhanVienId)
        {
            using var db = new AppDbContext();
            int currentYear = DateTime.Today.Year;
            const decimal quota = 12m;

            decimal used = db.DonNghiPheps
                .AsNoTracking()
                .Include(x => x.LoaiNghiPhep)
                .Where(x =>
                    x.NhanVienId == nhanVienId &&
                    x.TrangThai == "DaDuyet" &&
                    x.TuNgay.Year == currentYear &&
                    x.LoaiNghiPhep != null &&
                    x.LoaiNghiPhep.HuongLuong)
                .Sum(x => (decimal?)x.TongSoNgay) ?? 0m;

            decimal pending = db.DonNghiPheps
                .AsNoTracking()
                .Where(x => x.NhanVienId == nhanVienId && x.TrangThai == "ChoDuyet" && x.TuNgay.Year == currentYear)
                .Sum(x => (decimal?)x.TongSoNgay) ?? 0m;

            decimal remain = quota - used;
            if (remain < 0)
            {
                remain = 0;
            }

            return $"Phep nam tam tinh cua ban con {remain:N1} ngay. Da duyet {used:N1} ngay, dang cho duyet {pending:N1} ngay. He thong dang tinh theo muc mac dinh {quota:N0} ngay/nam.";
        }

        private static string GetRequestStatus(int nhanVienId)
        {
            using var db = new AppDbContext();

            int leavePending = db.DonNghiPheps.Count(x => x.NhanVienId == nhanVienId && x.TrangThai == "ChoDuyet");
            int leaveApproved = db.DonNghiPheps.Count(x => x.NhanVienId == nhanVienId && x.TrangThai == "DaDuyet");
            int overtimePending = db.DonTangCas.Count(x => x.NhanVienId == nhanVienId && x.TrangThai == "ChoDuyet");
            int overtimeApproved = db.DonTangCas.Count(x => x.NhanVienId == nhanVienId && x.TrangThai == "DaDuyet");

            return $"Tinh trang don tu cua ban: nghi phep cho duyet {leavePending}, nghi phep da duyet {leaveApproved}, tang ca cho duyet {overtimePending}, tang ca da duyet {overtimeApproved}.";
        }

        private static string GetLateStats(int nhanVienId)
        {
            using var db = new AppDbContext();
            var fromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);

            var records = db.ChamCongs
                .AsNoTracking()
                .Where(x => x.NhanVienId == nhanVienId && x.NgayLamViec >= fromDate && x.NgayLamViec <= toDate)
                .ToList();

            int soLan = records.Count(x => x.SoPhutDiMuon > 0 || x.TrangThai == "DiMuon");
            int tongPhut = records.Sum(x => x.SoPhutDiMuon);

            return $"Thang nay ban di muon {soLan} lan, tong cong {tongPhut} phut.";
        }

        private static string GetOvertimeStats(int nhanVienId)
        {
            using var db = new AppDbContext();
            var fromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);

            double approved = db.DonTangCas
                .AsNoTracking()
                .Where(x => x.NhanVienId == nhanVienId && x.TrangThai == "DaDuyet" && x.NgayLam >= fromDate && x.NgayLam <= toDate)
                .Sum(x => (double?)x.TongSoGio) ?? 0d;

            double pending = db.DonTangCas
                .AsNoTracking()
                .Where(x => x.NhanVienId == nhanVienId && x.TrangThai == "ChoDuyet" && x.NgayLam >= fromDate && x.NgayLam <= toDate)
                .Sum(x => (double?)x.TongSoGio) ?? 0d;

            return $"Thang nay ban co {approved:N1} gio OT da duyet va {pending:N1} gio OT dang cho duyet.";
        }

        private static string GetLatestVerification(int nhanVienId)
        {
            var latest = AttendanceAuditStore.LoadAll()
                .Where(x => x.NhanVienId == nhanVienId)
                .OrderByDescending(x => x.ThoiGian)
                .FirstOrDefault();

            if (latest == null)
            {
                return "Chua co nhat ky xac thuc thong minh nao duoc ghi nhan cho ban.";
            }

            return $"Lan xac thuc gan nhat cua ban la {latest.HanhDong} bang {latest.PhuongThuc} luc {latest.ThoiGian:HH:mm dd/MM/yyyy}, ket qua {latest.KetQua.ToLowerInvariant()}. Chi tiet: {latest.ChiTiet}";
        }

        private static string GetVerificationStatus(int nhanVienId)
        {
            var today = DateTime.Today;
            var logs = AttendanceAuditStore.LoadAll()
                .Where(x => x.NhanVienId == nhanVienId && x.ThoiGian.Date == today)
                .OrderByDescending(x => x.ThoiGian)
                .ToList();

            if (logs.Count == 0)
            {
                return "Hom nay chua co nhat ky xac thuc thong minh nao cua ban.";
            }

            var latestSuccess = logs.FirstOrDefault(x => x.KetQua == "ThanhCong");
            var latestFailure = logs.FirstOrDefault(x => x.KetQua == "ThatBai");

            if (latestSuccess != null && latestFailure != null)
            {
                return $"Hom nay ban da co xac thuc thanh cong gan nhat luc {latestSuccess.ThoiGian:HH:mm} bang {latestSuccess.PhuongThuc}. Lan that bai gan nhat la {latestFailure.ThoiGian:HH:mm} bang {latestFailure.PhuongThuc}.";
            }

            if (latestSuccess != null)
            {
                return $"Hom nay ban da xac thuc thanh cong luc {latestSuccess.ThoiGian:HH:mm} bang {latestSuccess.PhuongThuc}.";
            }

            return $"Hom nay moi chi co xac thuc that bai. Lan gan nhat la {latestFailure!.ThoiGian:HH:mm} bang {latestFailure.PhuongThuc}. Chi tiet: {latestFailure.ChiTiet}";
        }

        private static string BuildHelpMessage()
        {
            var sb = new StringBuilder();
            sb.Append("Toi co the tra loi cac cau hoi nhu: ");
            sb.Append("\"Ca hom nay cua toi la gi?\", ");
            sb.Append("\"Cong hom nay cua toi the nao?\", ");
            sb.Append("\"Toi con bao nhieu ngay phep?\", ");
            sb.Append("\"Don cua toi da duyet chua?\", ");
            sb.Append("\"Thang nay toi di muon may lan?\", ");
            sb.Append("\"OT thang nay cua toi bao nhieu gio?\", ");
            sb.Append("\"Lan check-in gan nhat cua toi bang gi?\", ");
            sb.Append("\"Hom nay xac thuc cua toi co thanh cong khong?\".");
            return sb.ToString();
        }

        private static string Normalize(string text)
        {
            var normalized = text.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString()
                .Normalize(NormalizationForm.FormC)
                .Replace('đ', 'd');
        }

        private static bool ContainsAny(string source, params string[] keywords)
        {
            return keywords.Any(keyword => source.Contains(keyword));
        }

        private static bool ContainsAll(string source, params string[] keywords)
        {
            return keywords.All(keyword => source.Contains(keyword));
        }
    }
}
