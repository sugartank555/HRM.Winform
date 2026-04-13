using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;

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
            DoubleBuffered = true;

            BackColor = ThemeHelper.AppBackColor;
            pnlBrand.BackColor = ThemeHelper.SidebarBackColor;
            ThemeHelper.ApplyCard(pnlLoginCard);

            Paint += FrmDangNhap_Paint;
            pnlBrand.Paint += PnlBrand_Paint;
            pnlLoginCard.Paint += PnlLoginCard_Paint;

            lblBrandTitle.ForeColor = Color.White;
            lblBrandSubtitle.ForeColor = Color.FromArgb(222, 244, 255);
            lblBrandFeature1.ForeColor = Color.FromArgb(233, 249, 255);
            lblBrandFeature2.ForeColor = Color.FromArgb(233, 249, 255);
            lblBrandFeature3.ForeColor = Color.FromArgb(233, 249, 255);
            lblBrandTitle.BackColor = Color.Transparent;
            lblBrandSubtitle.BackColor = Color.Transparent;
            lblBrandFeature1.BackColor = Color.Transparent;
            lblBrandFeature2.BackColor = Color.Transparent;
            lblBrandFeature3.BackColor = Color.Transparent;
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblMoTa.ForeColor = ThemeHelper.TextSecondary;
            chkHienMatKhau.ForeColor = ThemeHelper.TextSecondary;
            lblBrandTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBrandSubtitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);

            ThemeHelper.ApplyInput(txtTenDangNhap);
            ThemeHelper.ApplyInput(txtMatKhau);
            ThemeHelper.ApplyPrimaryButton(btnDangNhap);
            ThemeHelper.ApplySecondaryButton(btnThoat);

            btnDangNhap.Text = "Dang nhap";
            btnThoat.Text = "Thoat";
            lblBrandTitle.Text = "HRM Bloom";
            lblBrandSubtitle.Text = "He thong quan tri nhan su phuc vu cong tac dieu hanh, cham cong va bao cao noi bo.";
            lblBrandFeature1.Text = "Quan ly ho so nhan vien, phong ban, chuc vu va tai khoan truy cap.";
            lblBrandFeature2.Text = "Ho tro cham cong, phan ca, xu ly don tu va theo doi tinh trang phe duyet.";
            lblBrandFeature3.Text = "Tong hop bao cao nhan su, cong, nghi phep va cac chi so van hanh quan trong.";
            lblTieuDe.Text = "Dang nhap he thong";
            lblMoTa.Text = "Vui long dang nhap bang tai khoan duoc cap de truy cap he thong quan tri nhan su.";
            chkHienMatKhau.Text = "Hien mat khau";
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

            Hide();

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

        private void FrmDangNhap_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var backgroundBrush = new LinearGradientBrush(
                ClientRectangle,
                Color.FromArgb(243, 251, 255),
                Color.FromArgb(230, 255, 250),
                32F);
            e.Graphics.FillRectangle(backgroundBrush, ClientRectangle);

            DrawGlow(e.Graphics, new Rectangle(360, 32, 240, 240), Color.FromArgb(85, ThemeHelper.AccentSky));
            DrawGlow(e.Graphics, new Rectangle(784, 404, 184, 184), Color.FromArgb(95, ThemeHelper.PrimaryColor));
        }

        private void PnlBrand_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new LinearGradientBrush(
                pnlBrand.ClientRectangle,
                ThemeHelper.SidebarHeaderColor,
                ThemeHelper.AccentPurple,
                118F);
            e.Graphics.FillRectangle(brush, pnlBrand.ClientRectangle);

            DrawGlow(e.Graphics, new Rectangle(24, 340, 150, 150), Color.FromArgb(76, ThemeHelper.WarmAccent));
            DrawGlow(e.Graphics, new Rectangle(252, 90, 124, 124), Color.FromArgb(85, ThemeHelper.AccentSky));
            DrawOutlineOrb(e.Graphics, new Rectangle(292, 360, 92, 92), Color.FromArgb(115, 255, 255, 255));

            var titleBadgeBounds = new Rectangle(32, 40, 238, 58);
            using var badgePath = ThemeHelper.CreateRoundedPath(titleBadgeBounds, 16);
            using var badgeBrush = new SolidBrush(Color.FromArgb(32, 24, 82, 166));
            using var badgePen = new Pen(Color.FromArgb(76, 255, 255, 255));
            e.Graphics.FillPath(badgeBrush, badgePath);
            e.Graphics.DrawPath(badgePen, badgePath);

            using var accentBrush = new SolidBrush(Color.FromArgb(180, 255, 255, 255));
            e.Graphics.FillEllipse(accentBrush, new Rectangle(296, 28, 20, 20));
        }

        private void PnlLoginCard_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var outline = new Pen(Color.FromArgb(198, 227, 247), 1.5F);
            using var path = ThemeHelper.CreateRoundedPath(new Rectangle(0, 0, pnlLoginCard.Width - 1, pnlLoginCard.Height - 1), 22);
            e.Graphics.DrawPath(outline, path);

            using var badgeBrush = new SolidBrush(Color.FromArgb(234, 247, 255));
            e.Graphics.FillEllipse(badgeBrush, new Rectangle(pnlLoginCard.Width - 94, 18, 48, 48));

            using var dotBrush = new SolidBrush(ThemeHelper.PrimaryColor);
            e.Graphics.FillEllipse(dotBrush, new Rectangle(pnlLoginCard.Width - 76, 34, 12, 12));
            e.Graphics.FillEllipse(dotBrush, new Rectangle(pnlLoginCard.Width - 58, 34, 12, 12));
        }

        private static void DrawGlow(Graphics graphics, Rectangle bounds, Color color)
        {
            using var path = new GraphicsPath();
            path.AddEllipse(bounds);
            using var brush = new PathGradientBrush(path)
            {
                CenterColor = color,
                SurroundColors = [Color.Transparent]
            };
            graphics.FillEllipse(brush, bounds);
        }

        private static void DrawOutlineOrb(Graphics graphics, Rectangle bounds, Color color)
        {
            using var pen = new Pen(color, 2F);
            graphics.DrawEllipse(pen, bounds);
        }
    }
}
