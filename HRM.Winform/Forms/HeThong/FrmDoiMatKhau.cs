using HRM.Winform.Data;
using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.HeThong
{
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            lblTenDangNhap.Text = $"Tên đăng nhập: {CurrentUser.TenDangNhap}";
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hien = chkHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = !hien;
            txtMatKhauMoi.UseSystemPasswordChar = !hien;
            txtXacNhanMatKhau.UseSystemPasswordChar = !hien;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhan = txtXacNhanMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(matKhauCu))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ!");
                txtMatKhauCu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải từ 6 ký tự trở lên!");
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!");
                txtXacNhanMatKhau.Focus();
                return;
            }

            using var db = new AppDbContext();

            var taiKhoan = db.TaiKhoans.FirstOrDefault(x => x.Id == CurrentUser.TaiKhoanId && x.HoatDong);
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản đang đăng nhập!");
                return;
            }

            string matKhauCuHash = HashHelper.ToSha256(matKhauCu);
            if (taiKhoan.MatKhauHash != matKhauCuHash)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
                txtMatKhauCu.Focus();
                return;
            }

            taiKhoan.MatKhauHash = HashHelper.ToSha256(matKhauMoi);
            taiKhoan.NgayCapNhat = DateTime.Now;

            db.SaveChanges();

            MessageBox.Show("Đổi mật khẩu thành công!");
            Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}