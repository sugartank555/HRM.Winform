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
        private Label lblMoTa;
        private Label lblThang;
        private Label lblNam;
        private Label lblNhanVien;
        private Label lblTong;
        private Panel pnlLoc;
        private NumericUpDown nudThang;
        private NumericUpDown nudNam;
        private ComboBox cboNhanVien;
        private Button btnXem;
        private Button btnXuatExcel;
        private DataGridView dgvBaoCaoChamCong;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblThang = new Label();
            lblNam = new Label();
            lblNhanVien = new Label();
            lblTong = new Label();
            pnlLoc = new Panel();
            nudThang = new NumericUpDown();
            nudNam = new NumericUpDown();
            cboNhanVien = new ComboBox();
            btnXem = new Button();
            btnXuatExcel = new Button();
            dgvBaoCaoChamCong = new DataGridView();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoChamCong).BeginInit();
            SuspendLayout();
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Báo cáo chấm công";
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Tổng hợp chấm công theo tháng để theo dõi ngày công, tăng ca, đi muộn và vắng mặt.";
            pnlLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLoc.Controls.Add(lblTong);
            pnlLoc.Controls.Add(btnXuatExcel);
            pnlLoc.Controls.Add(btnXem);
            pnlLoc.Controls.Add(cboNhanVien);
            pnlLoc.Controls.Add(nudNam);
            pnlLoc.Controls.Add(nudThang);
            pnlLoc.Controls.Add(lblNhanVien);
            pnlLoc.Controls.Add(lblNam);
            pnlLoc.Controls.Add(lblThang);
            pnlLoc.Location = new Point(24, 100);
            pnlLoc.Size = new Size(1148, 84);
            lblThang.AutoSize = true;
            lblThang.Location = new Point(24, 31);
            lblThang.Text = "Tháng";
            nudThang.Location = new Point(78, 27);
            nudThang.Minimum = 1;
            nudThang.Maximum = 12;
            nudThang.Size = new Size(70, 27);
            lblNam.AutoSize = true;
            lblNam.Location = new Point(172, 31);
            lblNam.Text = "Năm";
            nudNam.Location = new Point(217, 27);
            nudNam.Minimum = 2000;
            nudNam.Maximum = 3000;
            nudNam.Size = new Size(90, 27);
            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(334, 31);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(406, 27);
            cboNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboNhanVien.Size = new Size(320, 28);
            btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXem.Location = new Point(754, 24);
            btnXem.Size = new Size(90, 34);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.Location = new Point(850, 24);
            btnXuatExcel.Size = new Size(110, 34);
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.Click += btnXuatExcel_Click;
            lblTong.AutoSize = true;
            lblTong.Location = new Point(982, 31);
            lblTong.Text = "Tổng số nhân viên: 0";
            dgvBaoCaoChamCong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCaoChamCong.Location = new Point(24, 208);
            dgvBaoCaoChamCong.Size = new Size(1148, 486);
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1200, 730);
            MinimumSize = new Size(1120, 700);
            Controls.Add(dgvBaoCaoChamCong);
            Controls.Add(pnlLoc);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoChamCong";
            Text = "Báo cáo chấm công";
            Load += FrmBaoCaoChamCong_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoChamCong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
