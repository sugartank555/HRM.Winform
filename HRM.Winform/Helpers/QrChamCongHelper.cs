namespace HRM.Winform.Helpers
{
    public static class QrChamCongHelper
    {
        public static string TaoMa(int nhanVienId, DateTime ngay, string maCa)
        {
            return $"HRM-{ngay:yyyyMMdd}-{nhanVienId}-{maCa}".ToUpperInvariant();
        }
    }
}
