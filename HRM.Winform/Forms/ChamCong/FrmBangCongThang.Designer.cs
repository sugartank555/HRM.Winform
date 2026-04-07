namespace HRM.Winform.Forms.ChamCong
{
    partial class FrmBangCongThang
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
        private Label lblTong;
        private NumericUpDown nudThang;
        private NumericUpDown nudNam;
        private Button btnXem;
        private DataGridView dgvBangCongThang;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblThang = new Label();
            lblNam = new Label();
            lblTong = new Label();
            nudThang = new NumericUpDown();
            nudNam = new NumericUpDown();
            btnXem = new Button();
            dgvBangCongThang = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongThang).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Text = "BẢNG CÔNG THÁNG";

            lblThang.AutoSize = true;
            lblThang.Location = new Point(28, 68);
            lblThang.Text = "Tháng";

            nudThang.Location = new Point(85, 65);
            nudThang.Minimum = 1;
            nudThang.Maximum = 12;
            nudThang.Size = new Size(70, 27);
            nudThang.Value = 1;

            lblNam.AutoSize = true;
            lblNam.Location = new Point(180, 68);
            lblNam.Text = "Năm";

            nudNam.Location = new Point(225, 65);
            nudNam.Minimum = 2000;
            nudNam.Maximum = 3000;
            nudNam.Size = new Size(90, 27);
            nudNam.Value = 2026;

            btnXem.Location = new Point(340, 62);
            btnXem.Size = new Size(90, 32);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            lblTong.AutoSize = true;
            lblTong.Location = new Point(460, 69);
            lblTong.Text = "Tổng số nhân viên: 0";

            dgvBangCongThang.Location = new Point(28, 115);
            dgvBangCongThang.Size = new Size(1120, 470);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 620);
            Controls.Add(dgvBangCongThang);
            Controls.Add(lblTong);
            Controls.Add(btnXem);
            Controls.Add(nudNam);
            Controls.Add(nudThang);
            Controls.Add(lblNam);
            Controls.Add(lblThang);
            Controls.Add(lblTieuDe);
            Name = "FrmBangCongThang";
            Text = "Bảng công tháng";
            Load += FrmBangCongThang_Load;
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongThang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}