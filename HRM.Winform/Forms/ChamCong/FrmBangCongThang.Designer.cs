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
        private Label lblMoTa;
        private Label lblThang;
        private Label lblNam;
        private Label lblTong;
        private Panel pnlLoc;
        private NumericUpDown nudThang;
        private NumericUpDown nudNam;
        private Button btnXem;
        private DataGridView dgvBangCongThang;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblThang = new Label();
            lblNam = new Label();
            lblTong = new Label();
            pnlLoc = new Panel();
            nudThang = new NumericUpDown();
            nudNam = new NumericUpDown();
            btnXem = new Button();
            dgvBangCongThang = new DataGridView();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongThang).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Bảng công tháng";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Tổng hợp công theo tháng để theo dõi số ngày công, giờ làm, tăng ca và vắng mặt.";

            pnlLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLoc.Controls.Add(lblTong);
            pnlLoc.Controls.Add(btnXem);
            pnlLoc.Controls.Add(nudNam);
            pnlLoc.Controls.Add(nudThang);
            pnlLoc.Controls.Add(lblNam);
            pnlLoc.Controls.Add(lblThang);
            pnlLoc.Location = new Point(24, 100);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1132, 76);

            lblThang.AutoSize = true;
            lblThang.Location = new Point(24, 28);
            lblThang.Text = "Tháng";

            nudThang.Location = new Point(84, 24);
            nudThang.Minimum = 1;
            nudThang.Maximum = 12;
            nudThang.Size = new Size(70, 27);
            nudThang.Value = 1;

            lblNam.AutoSize = true;
            lblNam.Location = new Point(179, 28);
            lblNam.Text = "Năm";

            nudNam.Location = new Point(226, 24);
            nudNam.Minimum = 2000;
            nudNam.Maximum = 3000;
            nudNam.Size = new Size(90, 27);
            nudNam.Value = 2026;

            btnXem.Location = new Point(336, 20);
            btnXem.Size = new Size(90, 34);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            lblTong.AutoSize = true;
            lblTong.Location = new Point(452, 27);
            lblTong.Text = "Tổng số nhân viên: 0";

            dgvBangCongThang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBangCongThang.Location = new Point(24, 200);
            dgvBangCongThang.Size = new Size(1132, 478);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1180, 710);
            Controls.Add(dgvBangCongThang);
            Controls.Add(pnlLoc);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(1080, 700);
            Name = "FrmBangCongThang";
            Text = "Bảng công tháng";
            Load += FrmBangCongThang_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongThang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
