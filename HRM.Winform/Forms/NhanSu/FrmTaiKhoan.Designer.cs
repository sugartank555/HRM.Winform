namespace HRM.Winform.Forms.NhanSu
{
    partial class FrmTaiKhoan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblTenDangNhap;
        private Label lblMatKhau;
        private Label lblNhanVien;
        private Label lblVaiTro;

        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private ComboBox cboNhanVien;
        private ComboBox cboVaiTro;
        private CheckBox chkHoatDong;
        private CheckBox chkHienMatKhau;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvTaiKhoan;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblTenDangNhap = new Label();
            lblMatKhau = new Label();
            lblNhanVien = new Label();
            lblVaiTro = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            cboNhanVien = new ComboBox();
            cboVaiTro = new ComboBox();
            chkHoatDong = new CheckBox();
            chkHienMatKhau = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvTaiKhoan = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(26, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(288, 37);
            lblTieuDe.TabIndex = 15;
            lblTieuDe.Text = "QUẢN LÝ TÀI KHOẢN";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(29, 72);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(107, 20);
            lblTenDangNhap.TabIndex = 14;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(29, 109);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(70, 20);
            lblMatKhau.TabIndex = 13;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(410, 72);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(75, 20);
            lblNhanVien.TabIndex = 12;
            lblNhanVien.Text = "Nhân viên";
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(410, 109);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(52, 20);
            lblVaiTro.TabIndex = 11;
            lblVaiTro.Text = "Vai trò";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(147, 69);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(220, 27);
            txtTenDangNhap.TabIndex = 10;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(147, 106);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(220, 27);
            txtMatKhau.TabIndex = 9;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // cboNhanVien
            // 
            cboNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(490, 69);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(280, 28);
            cboNhanVien.TabIndex = 8;
            // 
            // cboVaiTro
            // 
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.Location = new Point(490, 106);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(180, 28);
            cboVaiTro.TabIndex = 7;
            // 
            // chkHoatDong
            // 
            chkHoatDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkHoatDong.AutoSize = true;
            chkHoatDong.Location = new Point(700, 108);
            chkHoatDong.Name = "chkHoatDong";
            chkHoatDong.Size = new Size(103, 24);
            chkHoatDong.TabIndex = 6;
            chkHoatDong.Text = "Hoạt động";
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(147, 140);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(127, 24);
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(860, 66);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 35);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Location = new Point(961, 66);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 35);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Location = new Point(1062, 66);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 35);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(860, 112);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(297, 35);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTaiKhoan.ColumnHeadersHeight = 29;
            dgvTaiKhoan.Location = new Point(29, 191);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.Size = new Size(1128, 390);
            dgvTaiKhoan.TabIndex = 0;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            // 
            // FrmTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1188, 610);
            Controls.Add(dgvTaiKhoan);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(chkHienMatKhau);
            Controls.Add(chkHoatDong);
            Controls.Add(cboVaiTro);
            Controls.Add(cboNhanVien);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(lblVaiTro);
            Controls.Add(lblNhanVien);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTenDangNhap);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(1100, 640);
            Name = "FrmTaiKhoan";
            Text = "Tài khoản";
            Load += FrmTaiKhoan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
