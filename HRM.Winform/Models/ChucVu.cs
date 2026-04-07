namespace HRM.Winform.Models
{
    public class ChucVu : BaseEntity
    {
        public string MaChucVu { get; set; } = string.Empty;
        public string TenChucVu { get; set; } = string.Empty;
        public string? MoTa { get; set; }

        public ICollection<NhanVien> DanhSachNhanVien { get; set; } = new List<NhanVien>();
    }
}