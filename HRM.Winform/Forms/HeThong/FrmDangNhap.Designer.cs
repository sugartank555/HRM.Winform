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
            pnlBrand.Size = new Size(390, 540);
            pnlBrand.TabIndex = 0;
            // 
            // lblBrandFeature3
            // 
            lblBrandFeature3.AutoSize = false;
            lblBrandFeature3.Font = new Font("Segoe UI", 10F);
            lblBrandFeature3.Location = new Point(36, 296);
            lblBrandFeature3.Name = "lblBrandFeature3";
            lblBrandFeature3.Size = new Size(318, 48);
            lblBrandFeature3.TabIndex = 4;
            lblBrandFeature3.Text = "Bang dashboard dep, ro, nhieu sac thai";
            lblBrandFeature3.TextAlign = ContentAlignment.TopLeft;
            // 
            // lblBrandFeature2
            // 
            lblBrandFeature2.AutoSize = false;
            lblBrandFeature2.Font = new Font("Segoe UI", 10F);
            lblBrandFeature2.Location = new Point(36, 240);
            lblBrandFeature2.Name = "lblBrandFeature2";
            lblBrandFeature2.Size = new Size(318, 48);
            lblBrandFeature2.TabIndex = 3;
            lblBrandFeature2.Text = "Cham cong thong minh, duyet don, AI";
            lblBrandFeature2.TextAlign = ContentAlignment.TopLeft;
            // 
            // lblBrandFeature1
            // 
            lblBrandFeature1.AutoSize = false;
            lblBrandFeature1.Font = new Font("Segoe UI", 10F);
            lblBrandFeature1.Location = new Point(36, 184);
            lblBrandFeature1.Name = "lblBrandFeature1";
            lblBrandFeature1.Size = new Size(318, 48);
            lblBrandFeature1.TabIndex = 2;
            lblBrandFeature1.Text = "Nhan su, phong ban, role trong mot luong UI";
            lblBrandFeature1.TextAlign = ContentAlignment.TopLeft;
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.AutoSize = false;
            lblBrandSubtitle.Font = new Font("Segoe UI", 11F);
            lblBrandSubtitle.Location = new Point(40, 116);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(300, 52);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Phong cach tre trung cho he thong HRM";
            lblBrandSubtitle.TextAlign = ContentAlignment.TopLeft;
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBrandTitle.Location = new Point(40, 44);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(250, 54);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "HRM Bloom";
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
            pnlLoginCard.Location = new Point(456, 58);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Size = new Size(430, 410);
            pnlLoginCard.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(220, 316);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(134, 46);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoat";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(60, 316);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(146, 46);
            btnDangNhap.TabIndex = 7;
            btnDangNhap.Text = "Dang nhap";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // chkHienMatKhau
            // 
            chkHienMatKhau.AutoSize = true;
            chkHienMatKhau.Location = new Point(60, 263);
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
            txtMatKhau.Location = new Point(60, 218);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(294, 31);
            txtMatKhau.TabIndex = 5;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10.5F);
            txtTenDangNhap.Location = new Point(60, 144);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(294, 31);
            txtTenDangNhap.TabIndex = 4;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatKhau.Location = new Point(60, 192);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(86, 23);
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mat khau";
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTenDangNhap.Location = new Point(60, 118);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(126, 23);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Ten dang nhap";
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(60, 66);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(320, 44);
            lblMoTa.TabIndex = 1;
            lblMoTa.Text = "Dang nhap de vao workspace quan tri HRM day sac mau.";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(56, 24);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(235, 37);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Welcome back";
            // 
            // FrmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 540);
            Controls.Add(pnlLoginCard);
            Controls.Add(pnlBrand);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HRM Bloom";
            Load += FrmDangNhap_Load;
            pnlBrand.ResumeLayout(false);
            pnlBrand.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            ResumeLayout(false);
        }
    }
}
