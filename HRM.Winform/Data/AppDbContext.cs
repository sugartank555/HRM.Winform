using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<CaLamViec> CaLamViecs { get; set; }
        public DbSet<PhanCaNhanVien> PhanCaNhanViens { get; set; }
        public DbSet<ChamCong> ChamCongs { get; set; }
        public DbSet<LoaiNghiPhep> LoaiNghiPheps { get; set; }
        public DbSet<DonNghiPhep> DonNghiPheps { get; set; }
        public DbSet<DonTangCa> DonTangCas { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=LAPTOP-1OLPGQ5K\SUGAR;Database=HRMDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhongBan>()
                .HasIndex(x => x.MaPhongBan)
                .IsUnique();

            modelBuilder.Entity<ChucVu>()
                .HasIndex(x => x.MaChucVu)
                .IsUnique();

            modelBuilder.Entity<NhanVien>()
                .HasIndex(x => x.MaNhanVien)
                .IsUnique();

            modelBuilder.Entity<CaLamViec>()
                .HasIndex(x => x.MaCa)
                .IsUnique();

            modelBuilder.Entity<LoaiNghiPhep>()
                .HasIndex(x => x.MaLoaiNghi)
                .IsUnique();

            modelBuilder.Entity<TaiKhoan>()
                .HasIndex(x => x.TenDangNhap)
                .IsUnique();

            modelBuilder.Entity<NhanVien>()
                .Property(x => x.LuongCoBan)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DonNghiPhep>()
                .Property(x => x.TongSoNgay)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<PhanCaNhanVien>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.DanhSachPhanCa)
                .HasForeignKey(x => x.NhanVienId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhanCaNhanVien>()
                .HasOne(x => x.CaLamViec)
                .WithMany(x => x.DanhSachPhanCa)
                .HasForeignKey(x => x.CaLamViecId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChamCong>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.DanhSachChamCong)
                .HasForeignKey(x => x.NhanVienId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChamCong>()
                .HasOne(x => x.CaLamViec)
                .WithMany(x => x.DanhSachChamCong)
                .HasForeignKey(x => x.CaLamViecId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonNghiPhep>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.DanhSachDonNghiPhep)
                .HasForeignKey(x => x.NhanVienId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonNghiPhep>()
                .HasOne(x => x.LoaiNghiPhep)
                .WithMany(x => x.DanhSachDonNghiPhep)
                .HasForeignKey(x => x.LoaiNghiPhepId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonTangCa>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.DanhSachDonTangCa)
                .HasForeignKey(x => x.NhanVienId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaiKhoan>()
                .HasOne(x => x.NhanVien)
                .WithMany(x => x.DanhSachTaiKhoan)
                .HasForeignKey(x => x.NhanVienId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}