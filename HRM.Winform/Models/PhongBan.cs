namespace HRM.Winform.Models
{
    public class PhongBan : BaseEntity
    {
        public string MaPhongBan { get; set; } = string.Empty;
        public string TenPhongBan { get; set; } = string.Empty;
        public string? MoTa { get; set; }

        public ICollection<NhanVien> DanhSachNhanVien { get; set; } = new List<NhanVien>();
    }
}