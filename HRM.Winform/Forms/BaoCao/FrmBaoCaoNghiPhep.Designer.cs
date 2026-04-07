namespace HRM.Winform.Forms.BaoCao
{
    partial class FrmBaoCaoNghiPhep
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblLoaiNghi;
        private Label lblTrangThai;
        private Label lblTong;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private ComboBox cboLoaiNghi;
        private ComboBox cboTrangThai;
        private Button btnXem;
        private DataGridView dgvBaoCaoNghiPhep;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblTuNgay = new Label();
            lblDenNgay = new Label();
            lblLoaiNghi = new Label();
            lblTrangThai = new Label();
            lblTong = new Label();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            cboLoaiNghi = new ComboBox();
            cboTrangThai = new ComboBox();
            btnXem = new Button();
            dgvBaoCaoNghiPhep = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoNghiPhep).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Text = "BÁO CÁO NGHỈ PHÉP";

            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(28, 70);
            lblTuNgay.Text = "Từ ngày";
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(90, 67);
            dtpTuNgay.Size = new Size(120, 27);
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(230, 70);
            lblDenNgay.Text = "Đến ngày";
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(305, 67);
            dtpDenNgay.Size = new Size(120, 27);

            lblLoaiNghi.AutoSize = true;
            lblLoaiNghi.Location = new Point(450, 70);
            lblLoaiNghi.Text = "Loại nghỉ";
            cboLoaiNghi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiNghi.Location = new Point(515, 67);
            cboLoaiNghi.Size = new Size(180, 28);

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(720, 70);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "-- Tất cả --", "ChoDuyet", "DaDuyet", "TuChoi" });
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboTrangThai.Location = new Point(790, 67);
            cboTrangThai.Size = new Size(140, 28);
            cboTrangThai.SelectedIndex = 0;

            btnXem.Location = new Point(955, 64);
            btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXem.Size = new Size(90, 32);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            lblTong.AutoSize = true;
            lblTong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTong.Location = new Point(1065, 70);
            lblTong.Text = "Tổng số đơn: 0";

            dgvBaoCaoNghiPhep.Location = new Point(28, 120);
            dgvBaoCaoNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCaoNghiPhep.Size = new Size(1140, 480);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1200, 630);
            MinimumSize = new Size(1120, 680);
            Controls.Add(dgvBaoCaoNghiPhep);
            Controls.Add(lblTong);
            Controls.Add(btnXem);
            Controls.Add(cboTrangThai);
            Controls.Add(cboLoaiNghi);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblTrangThai);
            Controls.Add(lblLoaiNghi);
            Controls.Add(lblDenNgay);
            Controls.Add(lblTuNgay);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoNghiPhep";
            Text = "Báo cáo nghỉ phép";
            Load += FrmBaoCaoNghiPhep_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoNghiPhep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
