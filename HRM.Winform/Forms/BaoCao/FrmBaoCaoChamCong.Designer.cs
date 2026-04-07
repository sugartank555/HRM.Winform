namespace HRM.Winform.Forms.BaoCao
{
    partial class FrmBaoCaoChamCong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblThang;
        private Label lblNam;
        private Label lblNhanVien;
        private Label lblTong;
        private NumericUpDown nudThang;
        private NumericUpDown nudNam;
        private ComboBox cboNhanVien;
        private Button btnXem;
        private Button btnXuatExcel;
        private DataGridView dgvBaoCaoChamCong;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblThang = new Label();
            lblNam = new Label();
            lblNhanVien = new Label();
            lblTong = new Label();
            nudThang = new NumericUpDown();
            nudNam = new NumericUpDown();
            cboNhanVien = new ComboBox();
            btnXem = new Button();
            btnXuatExcel = new Button();
            dgvBaoCaoChamCong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoChamCong).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Text = "BÁO CÁO CHẤM CÔNG";

            lblThang.AutoSize = true;
            lblThang.Location = new Point(28, 70);
            lblThang.Text = "Tháng";
            nudThang.Location = new Point(82, 67);
            nudThang.Minimum = 1;
            nudThang.Maximum = 12;
            nudThang.Size = new Size(70, 27);

            lblNam.AutoSize = true;
            lblNam.Location = new Point(175, 70);
            lblNam.Text = "Năm";
            nudNam.Location = new Point(220, 67);
            nudNam.Minimum = 2000;
            nudNam.Maximum = 3000;
            nudNam.Size = new Size(90, 27);

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(340, 70);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(410, 67);
            cboNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNhanVien.Size = new Size(260, 28);

            btnXem.Location = new Point(695, 64);
            btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXem.Size = new Size(90, 32);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            btnXuatExcel.Location = new Point(792, 64);
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.Size = new Size(110, 32);
            btnXuatExcel.Text = "Xuat Excel";
            btnXuatExcel.Click += btnXuatExcel_Click;

            lblTong.AutoSize = true;
            lblTong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTong.Location = new Point(918, 70);
            lblTong.Text = "Tổng số nhân viên: 0";

            dgvBaoCaoChamCong.Location = new Point(28, 120);
            dgvBaoCaoChamCong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCaoChamCong.Size = new Size(1140, 480);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1200, 630);
            MinimumSize = new Size(1120, 680);
            Controls.Add(dgvBaoCaoChamCong);
            Controls.Add(lblTong);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnXem);
            Controls.Add(cboNhanVien);
            Controls.Add(nudNam);
            Controls.Add(nudThang);
            Controls.Add(lblNhanVien);
            Controls.Add(lblNam);
            Controls.Add(lblThang);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoChamCong";
            Text = "Báo cáo chấm công";
            Load += FrmBaoCaoChamCong_Load;
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoChamCong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
