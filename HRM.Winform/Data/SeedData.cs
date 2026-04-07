using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Data
{
    public static class SeedData
    {
        public static void KhoiTaoDuLieuBanDau()
        {
            using var db = new AppDbContext();

            db.Database.Migrate();

            if (!db.PhongBans.Any())
            {
                db.PhongBans.Add(new PhongBan
                {
                    MaPhongBan = "PB001",
                    TenPhongBan = "Ban Giam Doc",
                    MoTa = "Phong ban mac dinh",
                    NgayTao = DateTime.Now
                });
                db.SaveChanges();
            }

            if (!db.ChucVus.Any())
            {
                db.ChucVus.Add(new ChucVu
                {
                    MaChucVu = "CV001",
                    TenChucVu = "Admin",
                    MoTa = "Quan tri he thong",
                    NgayTao = DateTime.Now
                });
                db.SaveChanges();
            }

            if (!db.NhanViens.Any(x => x.MaNhanVien == "NV001"))
            {
                var phongBan = db.PhongBans.First();
                var chucVu = db.ChucVus.First();

                db.NhanViens.Add(new NhanVien
                {
                    MaNhanVien = "NV001",
                    HoTen = "Quan Tri He Thong",
                    NgaySinh = new DateTime(2000, 1, 1),
                    GioiTinh = true,
                    SoDienThoai = "0900000000",
                    Email = "admin@local.com",
                    DiaChi = "Viet Nam",
                    CCCD = "000000000001",
                    NgayVaoLam = DateTime.Now,
                    LuongCoBan = 10000000,
                    DangLamViec = true,
                    PhongBanId = phongBan.Id,
                    ChucVuId = chucVu.Id,
                    NgayTao = DateTime.Now
                });

                db.SaveChanges();
            }

            if (!db.TaiKhoans.Any(x => x.TenDangNhap == "admin"))
            {
                var nhanVienAdmin = db.NhanViens.First(x => x.MaNhanVien == "NV001");

                db.TaiKhoans.Add(new TaiKhoan
                {
                    TenDangNhap = "admin",
                    MatKhauHash = HashHelper.ToSha256("123456"),
                    VaiTro = "Admin",
                    HoatDong = true,
                    NhanVienId = nhanVienAdmin.Id,
                    NgayTao = DateTime.Now
                });

                db.SaveChanges();
            }
        }
    }
}