using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.HeThong
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = "admin";
            txtMatKhau.Text = "123456";
            txtMatKhau.UseSystemPasswordChar = true;
            AcceptButton = btnDangNhap;

            BackColor = ThemeHelper.AppBackColor;
            pnlBrand.BackColor = ThemeHelper.SidebarBackColor;
            pnlLoginCard.BackColor = ThemeHelper.CardBackColor;
            pnlBrand.Paint += (_, pe) =>
            {
                using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    pnlBrand.ClientRectangle,
                    ThemeHelper.SidebarHeaderColor,
                    ThemeHelper.SidebarBackColor,
                    90F);
                pe.Graphics.FillRectangle(brush, pnlBrand.ClientRectangle);
            };

            lblBrandTitle.ForeColor = Color.White;
            lblBrandSubtitle.ForeColor = Color.FromArgb(208, 226, 255);
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblMoTa.ForeColor = ThemeHelper.TextSecondary;

            ThemeHelper.ApplyInput(txtTenDangNhap);
            ThemeHelper.ApplyInput(txtMatKhau);
            ThemeHelper.ApplyPrimaryButton(btnDangNhap);
            ThemeHelper.ApplySecondaryButton(btnThoat);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            string matKhauHash = HashHelper.ToSha256(matKhau);

            using var db = new AppDbContext();

            var taiKhoan = db.TaiKhoans
                .Include(x => x.NhanVien)
                .FirstOrDefault(x =>
                    x.TenDangNhap == tenDangNhap &&
                    x.MatKhauHash == matKhauHash &&
                    x.HoatDong);

            if (taiKhoan == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CurrentUser.TaiKhoanId = taiKhoan.Id;
            CurrentUser.NhanVienId = taiKhoan.NhanVienId;
            CurrentUser.TenDangNhap = taiKhoan.TenDangNhap;
            CurrentUser.HoTen = taiKhoan.NhanVien?.HoTen ?? string.Empty;
            CurrentUser.VaiTro = taiKhoan.VaiTro;

            this.Hide();

            using FrmMain frmMain = new FrmMain();
            frmMain.TenDangNhap = taiKhoan.TenDangNhap;
            frmMain.HoTen = taiKhoan.NhanVien?.HoTen ?? "";
            frmMain.VaiTro = taiKhoan.VaiTro;

            frmMain.ShowDialog();

            if (frmMain.IsLogoutRequested)
            {
                CurrentUser.Clear();
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                Show();
                return;
            }

            Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }
    }
}
