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
        private Label lblMoTa;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblLoaiNghi;
        private Label lblTrangThai;
        private Label lblTong;
        private Panel pnlLoc;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private ComboBox cboLoaiNghi;
        private ComboBox cboTrangThai;
        private Button btnXem;
        private DataGridView dgvBaoCaoNghiPhep;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblTuNgay = new Label();
            lblDenNgay = new Label();
            lblLoaiNghi = new Label();
            lblTrangThai = new Label();
            lblTong = new Label();
            pnlLoc = new Panel();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            cboLoaiNghi = new ComboBox();
            cboTrangThai = new ComboBox();
            btnXem = new Button();
            dgvBaoCaoNghiPhep = new DataGridView();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoNghiPhep).BeginInit();
            SuspendLayout();
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Báo cáo nghỉ phép";
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Theo dõi đơn nghỉ phép theo khoảng thời gian, loại nghỉ và trạng thái duyệt.";
            pnlLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLoc.Controls.Add(lblTong);
            pnlLoc.Controls.Add(btnXem);
            pnlLoc.Controls.Add(cboTrangThai);
            pnlLoc.Controls.Add(cboLoaiNghi);
            pnlLoc.Controls.Add(dtpDenNgay);
            pnlLoc.Controls.Add(dtpTuNgay);
            pnlLoc.Controls.Add(lblTrangThai);
            pnlLoc.Controls.Add(lblLoaiNghi);
            pnlLoc.Controls.Add(lblDenNgay);
            pnlLoc.Controls.Add(lblTuNgay);
            pnlLoc.Location = new Point(24, 100);
            pnlLoc.Size = new Size(1148, 84);
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(24, 31);
            lblTuNgay.Text = "Từ ngày";
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(86, 27);
            dtpTuNgay.Size = new Size(120, 27);
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(224, 31);
            lblDenNgay.Text = "Đến ngày";
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(298, 27);
            dtpDenNgay.Size = new Size(120, 27);
            lblLoaiNghi.AutoSize = true;
            lblLoaiNghi.Location = new Point(438, 31);
            lblLoaiNghi.Text = "Loại nghỉ";
            cboLoaiNghi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiNghi.Location = new Point(503, 27);
            cboLoaiNghi.Size = new Size(180, 28);
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(706, 31);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "-- Tất cả --", "ChoDuyet", "DaDuyet", "TuChoi" });
            cboTrangThai.Location = new Point(777, 27);
            cboTrangThai.Size = new Size(140, 28);
            cboTrangThai.SelectedIndex = 0;
            btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXem.Location = new Point(939, 24);
            btnXem.Size = new Size(90, 34);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;
            lblTong.AutoSize = true;
            lblTong.Location = new Point(1044, 31);
            lblTong.Text = "Tổng số đơn: 0";
            dgvBaoCaoNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBaoCaoNghiPhep.Location = new Point(24, 208);
            dgvBaoCaoNghiPhep.Size = new Size(1148, 486);
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1200, 730);
            MinimumSize = new Size(1120, 700);
            Controls.Add(dgvBaoCaoNghiPhep);
            Controls.Add(pnlLoc);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmBaoCaoNghiPhep";
            Text = "Báo cáo nghỉ phép";
            Load += FrmBaoCaoNghiPhep_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCaoNghiPhep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
