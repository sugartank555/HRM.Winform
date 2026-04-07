namespace HRM.Winform.Models
{
    public class DonTangCa : BaseEntity
    {
        public int NhanVienId { get; set; }
        public NhanVien? NhanVien { get; set; }

        public DateTime NgayLam { get; set; }
        public DateTime TuGio { get; set; }
        public DateTime DenGio { get; set; }

        public double TongSoGio { get; set; }

        public string LyDo { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "ChoDuyet";
        // ChoDuyet, DaDuyet, TuChoi

        public DateTime? NgayDuyet { get; set; }
        public string? NguoiDuyet { get; set; }
    }
}