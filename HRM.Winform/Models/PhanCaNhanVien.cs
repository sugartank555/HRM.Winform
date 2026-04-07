namespace HRM.Winform.Models
{
    public class PhanCaNhanVien : BaseEntity
    {
        public int NhanVienId { get; set; }
        public NhanVien? NhanVien { get; set; }

        public int CaLamViecId { get; set; }
        public CaLamViec? CaLamViec { get; set; }

        public DateTime NgayLamViec { get; set; }
    }
}