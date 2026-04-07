using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Helpers
{
    public sealed class SalaryRowDto
    {
        public int NhanVienId { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string PhongBan { get; set; } = string.Empty;
        public string ChucVu { get; set; } = string.Empty;
        public decimal LuongCoBan { get; set; }
        public decimal NgayCongHuongLuong { get; set; }
        public decimal NghiHuongLuong { get; set; }
        public decimal NghiKhongLuong { get; set; }
        public decimal TongGioTangCa { get; set; }
        public decimal TienTangCa { get; set; }
        public decimal TongKhauTru { get; set; }
        public decimal LuongThucNhan { get; set; }
    }

    public static class SalaryCalculationService
    {
        public static List<SalaryRowDto> GetMonthlySalaries(int month, int year, int nhanVienId = 0)
        {
            using var db = new AppDbContext();
            var nhanVienQuery = db.NhanViens
                .AsNoTracking()
                .Include(x => x.PhongBan)
                .Include(x => x.ChucVu)
                .Where(x => x.DangLamViec || x.NgayNghiViec == null || (x.NgayNghiViec.Value.Month == month && x.NgayNghiViec.Value.Year == year));

            if (nhanVienId > 0)
            {
                nhanVienQuery = nhanVienQuery.Where(x => x.Id == nhanVienId);
            }

            var nhanViens = nhanVienQuery
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.Id,
                    x.MaNhanVien,
                    x.HoTen,
                    PhongBan = x.PhongBan != null ? x.PhongBan.TenPhongBan : string.Empty,
                    ChucVu = x.ChucVu != null ? x.ChucVu.TenChucVu : string.Empty,
                    x.LuongCoBan
                })
                .ToList();

            var chamCongThang = db.ChamCongs
                .AsNoTracking()
                .Where(x => x.NgayLamViec.Month == month && x.NgayLamViec.Year == year && (nhanVienId == 0 || x.NhanVienId == nhanVienId))
                .ToList()
                .GroupBy(x => x.NhanVienId)
                .ToDictionary(x => x.Key, x => x.ToList());

            var donTangCa = db.DonTangCas
                .AsNoTracking()
                .Where(x => x.TrangThai == "DaDuyet" && x.NgayLam.Month == month && x.NgayLam.Year == year && (nhanVienId == 0 || x.NhanVienId == nhanVienId))
                .ToList()
                .GroupBy(x => x.NhanVienId)
                .ToDictionary(x => x.Key, x => x.ToList());

            var donNghiPhep = db.DonNghiPheps
                .AsNoTracking()
                .Include(x => x.LoaiNghiPhep)
                .Where(x => x.TrangThai == "DaDuyet" && x.TuNgay.Month <= month && x.DenNgay.Month >= month && x.TuNgay.Year <= year && x.DenNgay.Year >= year && (nhanVienId == 0 || x.NhanVienId == nhanVienId))
                .ToList()
                .GroupBy(x => x.NhanVienId)
                .ToDictionary(x => x.Key, x => x.ToList());

            return nhanViens.Select(x =>
            {
                var chamCongs = chamCongThang.TryGetValue(x.Id, out var dsCong) ? dsCong : [];
                var ots = donTangCa.TryGetValue(x.Id, out var dsOt) ? dsOt : [];
                var nghis = donNghiPhep.TryGetValue(x.Id, out var dsNghi) ? dsNghi : [];

                decimal luongNgay = x.LuongCoBan / 26m;
                decimal luongGio = luongNgay / 8m;

                decimal ngayCongHuongLuong = chamCongs.Count(y => y.TrangThai is "CoMat" or "DiMuon" or "VeSom" or "CongTac");
                decimal ngayNghiHuongLuong = nghis.Where(y => y.LoaiNghiPhep != null && y.LoaiNghiPhep.HuongLuong).Sum(y => y.TongSoNgay);
                decimal ngayNghiKhongLuong = nghis.Where(y => y.LoaiNghiPhep == null || !y.LoaiNghiPhep.HuongLuong).Sum(y => y.TongSoNgay);
                decimal ngayVang = chamCongs.Count(y => y.TrangThai == "Vang");

                double tongOtGioDouble = ots.Sum(y => y.TongSoGio);
                decimal tongOtGio = Convert.ToDecimal(tongOtGioDouble);
                decimal tienTangCa = tongOtGio * luongGio * 1.5m;

                int tongPhutKhauTru = chamCongs.Sum(y => y.SoPhutDiMuon + y.SoPhutVeSom);
                decimal khauTruDiMuon = (decimal)tongPhutKhauTru / 60m * luongGio;
                decimal khauTruNghiKhongLuong = (ngayNghiKhongLuong + ngayVang) * luongNgay;

                decimal luongTheoCong = (ngayCongHuongLuong + ngayNghiHuongLuong) * luongNgay;
                decimal tongKhauTru = khauTruDiMuon + khauTruNghiKhongLuong;
                decimal luongThucNhan = Math.Max(0, luongTheoCong + tienTangCa - tongKhauTru);

                return new SalaryRowDto
                {
                    NhanVienId = x.Id,
                    MaNhanVien = x.MaNhanVien,
                    HoTen = x.HoTen,
                    PhongBan = x.PhongBan,
                    ChucVu = x.ChucVu,
                    LuongCoBan = x.LuongCoBan,
                    NgayCongHuongLuong = ngayCongHuongLuong,
                    NghiHuongLuong = ngayNghiHuongLuong,
                    NghiKhongLuong = ngayNghiKhongLuong + ngayVang,
                    TongGioTangCa = tongOtGio,
                    TienTangCa = tienTangCa,
                    TongKhauTru = tongKhauTru,
                    LuongThucNhan = luongThucNhan
                };
            }).ToList();
        }
    }
}
