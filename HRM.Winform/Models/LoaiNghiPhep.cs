namespace HRM.Winform.Models
{
    public class LoaiNghiPhep : BaseEntity
    {
        public string MaLoaiNghi { get; set; } = string.Empty;
        public string TenLoaiNghi { get; set; } = string.Empty;
        public bool HuongLuong { get; set; } = true;
        public string? MoTa { get; set; }

        public ICollection<DonNghiPhep> DanhSachDonNghiPhep { get; set; } = new List<DonNghiPhep>();
    }
}