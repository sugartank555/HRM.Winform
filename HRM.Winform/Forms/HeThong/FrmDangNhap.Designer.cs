namespace HRM.Winform.Forms.HeThong
{
    partial class FrmDangNhap
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

        private Panel pnlBrand;
        private Label lblBrandTitle;
        private Label lblBrandSubtitle;
        private Label lblBrandFeature1;
        private Label lblBrandFeature2;
        private Label lblBrandFeature3;
        private Panel pnlLoginCard;
        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;

        private void InitializeComponent()
        {
            pnlBrand = new Panel();
            lblBrandFeature3 = new Label();
            lblBrandFeature2 = new Label();
            lblBrandFeature1 = new Label();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            pnlLoginCard = new Panel();
            btnThoat = new Button();
            btnDangNhap = new Button();
            chkHienMatKhau = new CheckBox();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            lblTenDangNhap = new Label();
            lblMoTa = new Label();
            lblTieuDe = new Label();
            pnlBrand.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBrand
            // 
            pnlBrand.Controls.Add(lblBrandFeature3);
            pnlBrand.Controls.Add(lblBrandFeature2);
            pnlBrand.Controls.Add(lblBrandFeature1);
            pnlBrand.Controls.Add(lblBrandSubtitle);
            pnlBrand.Controls.Add(lblBrandTitle);
            pnlBrand.Dock = DockStyle.Left;
            pnlBrand.Location = new Point(0, 0);
            pnlBrand.Name = "pnlBrand";
            pnlBrand.Size = new Size(360, 420);
            pnlBrand.TabIndex = 0;
            // 
            // lblBrandFeature3
            // 
            lblBrandFeature3.AutoSize = true;
            lblBrandFeature3.Font = new Font("Segoe UI", 10F);
            lblBrandFeature3.Location = new Point(34, 236);
            lblBrandFeature3.Name = "lblBrandFeature3";
            lblBrandFeature3.Size = new Size(246, 23);
            lblBrandFeature3.TabIndex = 4;
            lblBrandFeature3.Text = "Bao cao nhan su, nghi phep, luong";
            // 
            // lblBrandFeature2
            // 
            lblBrandFeature2.AutoSize = true;
            lblBrandFeature2.Font = new Font("Segoe UI", 10F);
            lblBrandFeature2.Location = new Point(34, 198);
            lblBrandFeature2.Name = "lblBrandFeature2";
            lblBrandFeature2.Size = new Size(231, 23);
            lblBrandFeature2.TabIndex = 3;
            lblBrandFeature2.Text = "Cham cong, phan ca, xu ly don tu";
            // 
            // lblBrandFeature1
            // 
            lblBrandFeature1.AutoSize = true;
            lblBrandFeature1.Font = new Font("Segoe UI", 10F);
            lblBrandFeature1.Location = new Point(34, 160);
            lblBrandFeature1.Name = "lblBrandFeature1";
            lblBrandFeature1.Size = new Size(235, 23);
            lblBrandFeature1.TabIndex = 2;
            lblBrandFeature1.Text = "Quan ly nhan vien, phong ban, role";
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.AutoSize = true;
            lblBrandSubtitle.Font = new Font("Segoe UI", 11F);
            lblBrandSubtitle.Location = new Point(34, 92);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(251, 25);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Nen tang quan ly nhan su noi bo";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBrandTitle.Location = new Point(28, 34);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(111, 54);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "HRM";
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.Controls.Add(btnThoat);
            pnlLoginCard.Controls.Add(btnDangNhap);
            pnlLoginCard.Controls.Add(chkHienMatKhau);
            pnlLoginCard.Controls.Add(txtMatKhau);
            pnlLoginCard.Controls.Add(txtTenDangNhap);
            pnlLoginCard.Controls.Add(lblMatKhau);
            pnlLoginCard.Controls.Add(lblTenDangNhap);
            pnlLoginCard.Controls.Add(lblMoTa);
            pnlLoginCard.Controls.Add(lblTieuDe);
            pnlLoginCard.Location = new Point(398, 36);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(404, 344);
            pnlLoginCard.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(219, 266);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(120, 42);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(66, 266);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(135, 42);
            btnDangNhap.TabIndex = 7;
            btnDangNhap.Text = "Dang nhap";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(66, 214);
            chkHienMatKhau.Name = "chkHienMatKhau";
            chkHienMatKhau.Size = new Size(130, 24);
            chkHienMatKhau.TabIndex = 6;
            chkHienMatKhau.Text = "Hien mat khau";
            chkHienMatKhau.UseVisualStyleBackColor = true;
            chkHienMatKhau.CheckedChanged += chkHienMatKhau_CheckedChanged;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10.5F);
            txtMatKhau.Location = new Point(66, 174);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(273, 31);
            txtMatKhau.TabIndex = 5;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10.5F);
            txtTenDangNhap.Location = new Point(66, 114);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(273, 31);
            txtTenDangNhap.TabIndex = 4;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatKhau.Location = new Point(66, 148);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(86, 23);
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mat khau";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenDangNhap.Location = new Point(66, 88);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(126, 23);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Ten dang nhap";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(66, 48);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(246, 20);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Dang nhap de vao khu vuc quan tri HRM.";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(60, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(198, 37);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Dang nhap he thong";
            // 
            // FrmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 420);
            Controls.Add(pnlLoginCard);
            Controls.Add(pnlBrand);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dang nhap";
            Load += FrmDangNhap_Load;
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
