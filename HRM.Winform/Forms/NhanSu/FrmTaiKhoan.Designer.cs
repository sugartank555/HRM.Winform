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
        private Label lblMoTa;
        private Label lblTenDangNhap;
        private Label lblMatKhau;
        private Label lblNhanVien;
        private Label lblVaiTro;
        private Panel pnlThongTin;

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
            lblMoTa = new Label();
            lblTenDangNhap = new Label();
            lblMatKhau = new Label();
            lblNhanVien = new Label();
            lblVaiTro = new Label();
            pnlThongTin = new Panel();
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
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(203, 41);
            lblTieuDe.TabIndex = 15;
            lblTieuDe.Text = "Tài khoản";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(290, 20);
            lblMoTa.TabIndex = 16;
            lblMoTa.Text = "Cấp quyền đăng nhập và phân vai trò cho nhân sự.";
            // 
            // pnlThongTin
            // 
            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(chkHienMatKhau);
            pnlThongTin.Controls.Add(chkHoatDong);
            pnlThongTin.Controls.Add(cboVaiTro);
            pnlThongTin.Controls.Add(cboNhanVien);
            pnlThongTin.Controls.Add(txtMatKhau);
            pnlThongTin.Controls.Add(txtTenDangNhap);
            pnlThongTin.Controls.Add(lblVaiTro);
            pnlThongTin.Controls.Add(lblNhanVien);
            pnlThongTin.Controls.Add(lblMatKhau);
            pnlThongTin.Controls.Add(lblTenDangNhap);
            pnlThongTin.Location = new Point(24, 100);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(1140, 154);
            pnlThongTin.TabIndex = 17;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(24, 28);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(107, 20);
            lblTenDangNhap.TabIndex = 14;
            lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(24, 69);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(70, 20);
            lblMatKhau.TabIndex = 13;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(355, 28);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(75, 20);
            lblNhanVien.TabIndex = 12;
            lblNhanVien.Text = "Nhân viên";
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(355, 69);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(52, 20);
            lblVaiTro.TabIndex = 11;
            lblVaiTro.Text = "Vai trò";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(120, 24);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(190, 27);
            txtTenDangNhap.TabIndex = 10;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(120, 65);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(190, 27);
            txtMatKhau.TabIndex = 9;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // cboNhanVien
            // 
            cboNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(420, 24);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(500, 28);
            cboNhanVien.TabIndex = 8;
            // 
            // cboVaiTro
            // 
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.Location = new Point(420, 65);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(180, 28);
            cboVaiTro.TabIndex = 7;
            // 
            // chkHoatDong
            // 
            chkHoatDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkHoatDong.AutoSize = true;
            chkHoatDong.Location = new Point(920, 67);
            chkHoatDong.Name = "chkHoatDong";
            chkHoatDong.Size = new Size(103, 24);
            chkHoatDong.TabIndex = 6;
            chkHoatDong.Text = "Hoạt động";
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(120, 104);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(127, 24);
            chkHienMatKhau.TabIndex = 5;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(954, 20);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 35);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Location = new Point(1055, 20);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 35);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Location = new Point(954, 61);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 35);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(1055, 61);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(95, 35);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTaiKhoan.ColumnHeadersHeight = 29;
            dgvTaiKhoan.Location = new Point(24, 278);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.Size = new Size(1140, 408);
            dgvTaiKhoan.TabIndex = 0;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            // 
            // FrmTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1188, 720);
            Controls.Add(dgvTaiKhoan);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(1100, 720);
            Name = "FrmTaiKhoan";
            Text = "Tài khoản";
            Load += FrmTaiKhoan_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
