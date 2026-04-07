namespace HRM.Winform.Models
{
    public class TaiKhoan : BaseEntity
    {
        public string TenDangNhap { get; set; } = string.Empty;
        public string MatKhauHash { get; set; } = string.Empty;
        public string VaiTro { get; set; } = "NhanVien";
        // Admin, HR, QuanLy, NhanVien

        public bool HoatDong { get; set; } = true;

        public int NhanVienId { get; set; }
        public NhanVien? NhanVien { get; set; }
    }
}