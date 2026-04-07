namespace HRM.Winform.Forms.HeThong
{
    partial class FrmDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblTenDangNhap;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblXacNhan;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtXacNhanMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnLuu;
        private Button btnDong;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblTenDangNhap = new Label();
            lblMatKhauCu = new Label();
            lblMatKhauMoi = new Label();
            lblXacNhan = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtXacNhanMatKhau = new TextBox();
            chkHienMatKhau = new CheckBox();
            btnLuu = new Button();
            btnDong = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.Navy;
            lblTieuDe.Location = new Point(113, 23);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(201, 35);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐỔI MẬT KHẨU";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Location = new Point(48, 79);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(112, 20);
            lblTenDangNhap.TabIndex = 1;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // lblMatKhauCu
            // 
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Location = new Point(48, 126);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(90, 20);
            lblMatKhauCu.TabIndex = 2;
            lblMatKhauCu.Text = "Mật khẩu cũ";
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Location = new Point(48, 173);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(96, 20);
            lblMatKhauMoi.TabIndex = 3;
            lblMatKhauMoi.Text = "Mật khẩu mới";
            // 
            // lblXacNhan
            // 
            lblXacNhan.AutoSize = true;
            lblXacNhan.Location = new Point(48, 220);
            lblXacNhan.Name = "lblXacNhan";
            lblXacNhan.Size = new Size(124, 20);
            lblXacNhan.TabIndex = 4;
            lblXacNhan.Text = "Xác nhận mật khẩu";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(188, 123);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(190, 27);
            txtMatKhauCu.TabIndex = 0;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(188, 170);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(190, 27);
            txtMatKhauMoi.TabIndex = 1;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Location = new Point(188, 217);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.Size = new Size(190, 27);
            txtXacNhanMatKhau.TabIndex = 2;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(188, 257);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(122, 24);
            chkHienMatKhau.TabIndex = 3;
            chkHienMatKhau.Text = "Hiện mật khẩu";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(100, 304);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 38);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(228, 304);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(100, 38);
            btnDong.TabIndex = 5;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // FrmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 371);
            Controls.Add(btnDong);
            Controls.Add(btnLuu);
            Controls.Add(chkHienMatKhau);
            Controls.Add(txtXacNhanMatKhau);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lblXacNhan);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(lblMatKhauCu);
            Controls.Add(lblTenDangNhap);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            Load += FrmDoiMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}