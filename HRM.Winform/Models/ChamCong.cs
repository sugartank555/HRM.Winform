namespace HRM.Winform.Models
{
    public class ChamCong : BaseEntity
    {
        public int NhanVienId { get; set; }
        public NhanVien? NhanVien { get; set; }

        public int? CaLamViecId { get; set; }
        public CaLamViec? CaLamViec { get; set; }

        public DateTime NgayLamViec { get; set; }

        public DateTime? GioCheckIn { get; set; }
        public DateTime? GioCheckOut { get; set; }

        public int SoPhutDiMuon { get; set; } = 0;
        public int SoPhutVeSom { get; set; } = 0;
        public double SoGioLam { get; set; } = 0;
        public double SoGioTangCa { get; set; } = 0;

        public string TrangThai { get; set; } = "CoMat";
        // CoMat, DiMuon, VeSom, Vang, NghiPhep, CongTac, ThieuCheckIn, ThieuCheckOut

        public string? GhiChu { get; set; }
    }
}