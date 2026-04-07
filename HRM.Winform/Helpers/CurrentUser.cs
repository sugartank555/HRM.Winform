namespace HRM.Winform.Helpers
{
    public static class CurrentUser
    {
        public static int TaiKhoanId { get; set; }
        public static int NhanVienId { get; set; }
        public static string TenDangNhap { get; set; } = string.Empty;
        public static string HoTen { get; set; } = string.Empty;
        public static string VaiTro { get; set; } = string.Empty;

        public static void Clear()
        {
            TaiKhoanId = 0;
            NhanVienId = 0;
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            VaiTro = string.Empty;
        }
    }
}