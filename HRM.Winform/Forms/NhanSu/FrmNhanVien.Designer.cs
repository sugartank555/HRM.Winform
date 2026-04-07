namespace HRM.Winform.Forms.NhanSu
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblMaNhanVien;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblGioiTinh;
        private Label lblSoDienThoai;
        private Label lblEmail;
        private Label lblDiaChi;
        private Label lblCCCD;
        private Label lblPhongBan;
        private Label lblChucVu;
        private Label lblNgayVaoLam;
        private Label lblLuongCoBan;
        private Label lblCaHomNay;
        private Label lblMaQrHienTai;
        private Label lblNgayPhatQr;

        private TextBox txtMaNhanVien;
        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtDiaChi;
        private TextBox txtCCCD;
        private TextBox txtCaHomNay;
        private TextBox txtMaQrHienTai;
        private TextBox txtNgayPhatQr;

        private DateTimePicker dtpNgaySinh;
        private DateTimePicker dtpNgayVaoLam;

        private RadioButton rdoNam;
        private RadioButton rdoNu;

        private ComboBox cboPhongBan;
        private ComboBox cboChucVu;

        private NumericUpDown nudLuongCoBan;
        private CheckBox chkDangLamViec;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvNhanVien;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMaNhanVien = new Label();
            lblHoTen = new Label();
            lblNgaySinh = new Label();
            lblGioiTinh = new Label();
            lblSoDienThoai = new Label();
            lblEmail = new Label();
            lblDiaChi = new Label();
            lblCCCD = new Label();
            lblPhongBan = new Label();
            lblChucVu = new Label();
            lblNgayVaoLam = new Label();
            lblLuongCoBan = new Label();
            lblCaHomNay = new Label();
            lblMaQrHienTai = new Label();
            lblNgayPhatQr = new Label();
            txtMaNhanVien = new TextBox();
            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            txtCCCD = new TextBox();
            txtCaHomNay = new TextBox();
            txtMaQrHienTai = new TextBox();
            txtNgayPhatQr = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            dtpNgayVaoLam = new DateTimePicker();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            cboPhongBan = new ComboBox();
            cboChucVu = new ComboBox();
            nudLuongCoBan = new NumericUpDown();
            chkDangLamViec = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvNhanVien = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudLuongCoBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 14);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(291, 37);
            lblTieuDe.TabIndex = 37;
            lblTieuDe.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // lblMaNhanVien
            // 
            lblMaNhanVien.AutoSize = true;
            lblMaNhanVien.Location = new Point(28, 66);
            lblMaNhanVien.Name = "lblMaNhanVien";
            lblMaNhanVien.Size = new Size(97, 20);
            lblMaNhanVien.TabIndex = 33;
            lblMaNhanVien.Text = "Mã nhân viên";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(28, 101);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 32;
            lblHoTen.Text = "Họ tên";
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(28, 136);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(74, 20);
            lblNgaySinh.TabIndex = 31;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(28, 171);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(65, 20);
            lblGioiTinh.TabIndex = 30;
            lblGioiTinh.Text = "Giới tính";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(430, 66);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(97, 20);
            lblSoDienThoai.TabIndex = 29;
            lblSoDienThoai.Text = "Số điện thoại";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(430, 101);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 28;
            lblEmail.Text = "Email";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(430, 136);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(55, 20);
            lblDiaChi.TabIndex = 27;
            lblDiaChi.Text = "Địa chỉ";
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Location = new Point(430, 171);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(47, 20);
            lblCCCD.TabIndex = 26;
            lblCCCD.Text = "CCCD";
            // 
            // lblPhongBan
            // 
            lblPhongBan.AutoSize = true;
            lblPhongBan.Location = new Point(28, 209);
            lblPhongBan.Name = "lblPhongBan";
            lblPhongBan.Size = new Size(80, 20);
            lblPhongBan.TabIndex = 25;
            lblPhongBan.Text = "Phòng ban";
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Location = new Point(430, 209);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(61, 20);
            lblChucVu.TabIndex = 24;
            lblChucVu.Text = "Chức vụ";
            // 
            // lblNgayVaoLam
            // 
            lblNgayVaoLam.AutoSize = true;
            lblNgayVaoLam.Location = new Point(28, 246);
            lblNgayVaoLam.Name = "lblNgayVaoLam";
            lblNgayVaoLam.Size = new Size(101, 20);
            lblNgayVaoLam.TabIndex = 23;
            lblNgayVaoLam.Text = "Ngày vào làm";
            // 
            // lblLuongCoBan
            // 
            lblLuongCoBan.AutoSize = true;
            lblLuongCoBan.Location = new Point(430, 246);
            lblLuongCoBan.Name = "lblLuongCoBan";
            lblLuongCoBan.Size = new Size(100, 20);
            lblLuongCoBan.TabIndex = 22;
            lblLuongCoBan.Text = "Lương cơ bản";
            // 
            // lblCaHomNay
            // 
            lblCaHomNay.AutoSize = true;
            lblCaHomNay.Location = new Point(28, 283);
            lblCaHomNay.Name = "lblCaHomNay";
            lblCaHomNay.Size = new Size(87, 20);
            lblCaHomNay.TabIndex = 34;
            lblCaHomNay.Text = "Ca hôm nay";
            // 
            // lblMaQrHienTai
            // 
            lblMaQrHienTai.AutoSize = true;
            lblMaQrHienTai.Location = new Point(430, 283);
            lblMaQrHienTai.Name = "lblMaQrHienTai";
            lblMaQrHienTai.Size = new Size(107, 20);
            lblMaQrHienTai.TabIndex = 35;
            lblMaQrHienTai.Text = "Mã QR hiện tại";
            // 
            // lblNgayPhatQr
            // 
            lblNgayPhatQr.AutoSize = true;
            lblNgayPhatQr.Location = new Point(890, 283);
            lblNgayPhatQr.Name = "lblNgayPhatQr";
            lblNgayPhatQr.Size = new Size(61, 20);
            lblNgayPhatQr.TabIndex = 36;
            lblNgayPhatQr.Text = "Phát lúc";
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(140, 63);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(180, 27);
            txtMaNhanVien.TabIndex = 18;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(140, 98);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(260, 27);
            txtHoTen.TabIndex = 17;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(540, 63);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(180, 27);
            txtSoDienThoai.TabIndex = 16;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(540, 98);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 15;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(540, 133);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(330, 27);
            txtDiaChi.TabIndex = 14;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(540, 168);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(180, 27);
            txtCCCD.TabIndex = 13;
            // 
            // txtCaHomNay
            // 
            txtCaHomNay.Location = new Point(140, 280);
            txtCaHomNay.Name = "txtCaHomNay";
            txtCaHomNay.ReadOnly = true;
            txtCaHomNay.Size = new Size(220, 27);
            txtCaHomNay.TabIndex = 19;
            // 
            // txtMaQrHienTai
            // 
            txtMaQrHienTai.Location = new Point(540, 280);
            txtMaQrHienTai.Name = "txtMaQrHienTai";
            txtMaQrHienTai.ReadOnly = true;
            txtMaQrHienTai.Size = new Size(330, 27);
            txtMaQrHienTai.TabIndex = 20;
            // 
            // txtNgayPhatQr
            // 
            txtNgayPhatQr.Location = new Point(960, 280);
            txtNgayPhatQr.Name = "txtNgayPhatQr";
            txtNgayPhatQr.ReadOnly = true;
            txtNgayPhatQr.Size = new Size(247, 27);
            txtNgayPhatQr.TabIndex = 21;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(140, 133);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(180, 27);
            dtpNgaySinh.TabIndex = 12;
            // 
            // dtpNgayVaoLam
            // 
            dtpNgayVaoLam.Format = DateTimePickerFormat.Short;
            dtpNgayVaoLam.Location = new Point(140, 243);
            dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            dtpNgayVaoLam.Size = new Size(180, 27);
            dtpNgayVaoLam.TabIndex = 11;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(140, 169);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.TabIndex = 10;
            rdoNam.Text = "Nam";
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(210, 169);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(50, 24);
            rdoNu.TabIndex = 9;
            rdoNu.Text = "Nữ";
            // 
            // cboPhongBan
            // 
            cboPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhongBan.Location = new Point(140, 206);
            cboPhongBan.Name = "cboPhongBan";
            cboPhongBan.Size = new Size(220, 28);
            cboPhongBan.TabIndex = 8;
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Location = new Point(540, 206);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(220, 28);
            cboChucVu.TabIndex = 7;
            // 
            // nudLuongCoBan
            // 
            nudLuongCoBan.Location = new Point(540, 243);
            nudLuongCoBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudLuongCoBan.Name = "nudLuongCoBan";
            nudLuongCoBan.Size = new Size(180, 27);
            nudLuongCoBan.TabIndex = 6;
            nudLuongCoBan.ThousandsSeparator = true;
            // 
            // chkDangLamViec
            // 
            chkDangLamViec.AutoSize = true;
            chkDangLamViec.Location = new Point(760, 245);
            chkDangLamViec.Name = "chkDangLamViec";
            chkDangLamViec.Size = new Size(126, 24);
            chkDangLamViec.TabIndex = 5;
            chkDangLamViec.Text = "Đang làm việc";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(910, 60);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 35);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Location = new Point(1011, 60);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 35);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Location = new Point(1112, 60);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 35);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(910, 106);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(297, 35);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.ColumnHeadersHeight = 29;
            dgvNhanVien.Location = new Point(28, 329);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(1179, 328);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            dgvNhanVien.CellContentClick += dgvNhanVien_CellContentClick;
            // 
            // FrmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1238, 680);
            Controls.Add(dgvNhanVien);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(chkDangLamViec);
            Controls.Add(nudLuongCoBan);
            Controls.Add(cboChucVu);
            Controls.Add(cboPhongBan);
            Controls.Add(rdoNu);
            Controls.Add(rdoNam);
            Controls.Add(dtpNgayVaoLam);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtCCCD);
            Controls.Add(txtDiaChi);
            Controls.Add(txtEmail);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaNhanVien);
            Controls.Add(txtCaHomNay);
            Controls.Add(txtMaQrHienTai);
            Controls.Add(txtNgayPhatQr);
            Controls.Add(lblLuongCoBan);
            Controls.Add(lblNgayVaoLam);
            Controls.Add(lblChucVu);
            Controls.Add(lblPhongBan);
            Controls.Add(lblCCCD);
            Controls.Add(lblDiaChi);
            Controls.Add(lblEmail);
            Controls.Add(lblSoDienThoai);
            Controls.Add(lblGioiTinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(lblHoTen);
            Controls.Add(lblMaNhanVien);
            Controls.Add(lblCaHomNay);
            Controls.Add(lblMaQrHienTai);
            Controls.Add(lblNgayPhatQr);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(1180, 700);
            Name = "FrmNhanVien";
            Text = "Nhân viên";
            Load += FrmNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)nudLuongCoBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
