namespace HRM.Winform.Models
{
    public class NhanVien : BaseEntity
    {
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; } // true: Nam, false: Nữ
        public string SoDienThoai { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? CCCD { get; set; }

        public DateTime NgayVaoLam { get; set; }
        public DateTime? NgayNghiViec { get; set; }

        public decimal LuongCoBan { get; set; }
        public bool DangLamViec { get; set; } = true;

        public int PhongBanId { get; set; }
        public PhongBan? PhongBan { get; set; }

        public int ChucVuId { get; set; }
        public ChucVu? ChucVu { get; set; }

        public ICollection<ChamCong> DanhSachChamCong { get; set; } = new List<ChamCong>();
        public ICollection<DonNghiPhep> DanhSachDonNghiPhep { get; set; } = new List<DonNghiPhep>();
        public ICollection<DonTangCa> DanhSachDonTangCa { get; set; } = new List<DonTangCa>();
        public ICollection<PhanCaNhanVien> DanhSachPhanCa { get; set; } = new List<PhanCaNhanVien>();
        public ICollection<TaiKhoan> DanhSachTaiKhoan { get; set; } = new List<TaiKhoan>();
    }
}