using HRM.Winform.Data;
using HRM.Winform.Forms.HeThong;

namespace HRM.Winform
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            SeedData.KhoiTaoDuLieuBanDau();

            Application.Run(new FrmDangNhap());
        }
    }
}