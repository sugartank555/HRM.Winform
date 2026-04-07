namespace HRM.Winform.Models
{
    public class CaLamViec : BaseEntity
    {
        public string MaCa { get; set; } = string.Empty;
        public string TenCa { get; set; } = string.Empty;

        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }

        public int SoPhutNghi { get; set; } = 60;
        public int SoPhutChoPhepDiMuon { get; set; } = 5;
        public int SoPhutChoPhepVeSom { get; set; } = 5;

        public bool QuaDem { get; set; } = false;
        public bool HoatDong { get; set; } = true;

        public ICollection<PhanCaNhanVien> DanhSachPhanCa { get; set; } = new List<PhanCaNhanVien>();
        public ICollection<ChamCong> DanhSachChamCong { get; set; } = new List<ChamCong>();
    }
}