namespace HRM.Winform.Models
{
    public class DonNghiPhep : BaseEntity
    {
        public int NhanVienId { get; set; }
        public NhanVien? NhanVien { get; set; }

        public int LoaiNghiPhepId { get; set; }
        public LoaiNghiPhep? LoaiNghiPhep { get; set; }

        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }

        public decimal TongSoNgay { get; set; }

        public string LyDo { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "ChoDuyet";
        // ChoDuyet, DaDuyet, TuChoi

        public DateTime? NgayDuyet { get; set; }
        public string? NguoiDuyet { get; set; }
    }
}