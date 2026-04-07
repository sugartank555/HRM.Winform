namespace HRM.Winform.Forms.BaoCao
{
    partial class FrmBaoCaoNhanSu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblPhongBan;
        private Label lblTrangThai;
        private Label lblTuKhoa;
        private Label lblTong;
        private Label lblTomTatTitle;
        private Label lblTomTatBody;
        private ComboBox cboPhongBan;
        private ComboBox cboTrangThaiLamViec;
        private TextBox txtTuKhoa;
        private Button btnXem;
        private Button btnTomTatAI;
        private Button btnXuatExcel;
        private DataGridView dgvBaoCaoNhanSu;
        private Panel pnlTomTat;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblPhongBan = new Label();
            lblTrangThai = new Label();
            lblTuKhoa = new Label();
            lblTong = new Label();
            lblTomTatTitle = new Label();
            lblTomTatBody = new Label();
            cboPhongBan = new ComboBox();
            cboTrangThaiLamViec = new ComboBox();
            txtTuKhoa = new TextBox();
            btnXem = new Button();
            btnTomTatAI = new Button();
            btnXuatExcel = new Button();
            dgvBaoCaoNhanSu = new DataGridView();
            pnlTomTat = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoNhanSu).BeginInit();
            pnlTomTat.SuspendLayout();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Text = "BÁO CÁO NHÂN SỰ";

            lblPhongBan.AutoSize = true;
            lblPhongBan.Location = new Point(28, 70);
            lblPhongBan.Text = "Phòng ban";
            cboPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhongBan.Location = new Point(110, 67);
            cboPhongBan.Size = new Size(220, 28);

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(355, 70);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThaiLamViec.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThaiLamViec.Items.AddRange(new object[] { "-- Tất cả --", "Đang làm việc", "Đã nghỉ" });
            cboTrangThaiLamViec.Location = new Point(425, 67);
            cboTrangThaiLamViec.Size = new Size(160, 28);
            cboTrangThaiLamViec.SelectedIndex = 0;

            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Location = new Point(610, 70);
            lblTuKhoa.Text = "Từ khóa";
            txtTuKhoa.Location = new Point(670, 67);
            txtTuKhoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTuKhoa.Size = new Size(220, 27);

            btnXem.Location = new Point(910, 64);
            btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXem.Size = new Size(90, 32);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            btnTomTatAI.Location = new Point(1010, 64);
            btnTomTatAI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTomTatAI.Size = new Size(138, 32);
            btnTomTatAI.Text = "Tom tat tu dong";
            btnTomTatAI.Click += btnTomTatAI_Click;

            btnXuatExcel.Location = new Point(860, 64);
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.Size = new Size(138, 32);
            btnXuatExcel.Text = "Xuat Excel";
            btnXuatExcel.Click += btnXuatExcel_Click;

            lblTong.AutoSize = true;
            lblTong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTong.Location = new Point(28, 127);
            lblTong.Text = "Tổng số nhân viên: 0";

            pnlTomTat.Location = new Point(28, 160);
            pnlTomTat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTomTat.Size = new Size(1140, 110);

            lblTomTatTitle.AutoSize = false;
            lblTomTatTitle.Dock = DockStyle.Top;
            lblTomTatTitle.Height = 28;
            lblTomTatTitle.Text = "Tom tat bao cao nhan su";

            lblTomTatBody.AutoSize = false;
            lblTomTatBody.Dock = DockStyle.Fill;
            lblTomTatBody.Text = "Bam 'Tom tat tu dong' de he thong sinh nhan xet nhanh tu du lieu nhan su hien tai.";

            pnlTomTat.Controls.Add(lblTomTatBody);
            pnlTomTat.Controls.Add(lblTomTatTitle);

            dgvBaoCaoNhanSu.Location = new Point(28, 286);
            dgvBaoCaoNhanSu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCaoNhanSu.Size = new Size(1140, 314);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1200, 630);
            MinimumSize = new Size(1120, 680);
            Controls.Add(dgvBaoCaoNhanSu);
            Controls.Add(pnlTomTat);
            Controls.Add(lblTong);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnTomTatAI);
            Controls.Add(btnXem);
            Controls.Add(txtTuKhoa);
            Controls.Add(cboTrangThaiLamViec);
            Controls.Add(cboPhongBan);
            Controls.Add(lblTuKhoa);
            Controls.Add(lblTrangThai);
            Controls.Add(lblPhongBan);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoNhanSu";
            Text = "Báo cáo nhân sự";
            Load += FrmBaoCaoNhanSu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoNhanSu).EndInit();
            pnlTomTat.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
