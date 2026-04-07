namespace HRM.Winform.Forms.DonTu
{
    partial class FrmDonNghiPhep
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblNhanVien;
        private Label lblLoaiNghi;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Label lblTongSoNgay;
        private Label lblLyDo;
        private Label lblTrangThai;
        private ComboBox cboNhanVien;
        private ComboBox cboLoaiNghi;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private NumericUpDown nudTongSoNgay;
        private TextBox txtLyDo;
        private ComboBox cboTrangThai;
        private Button btnTinhSoNgay;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvDonNghiPhep;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblNhanVien = new Label();
            lblLoaiNghi = new Label();
            lblTuNgay = new Label();
            lblDenNgay = new Label();
            lblTongSoNgay = new Label();
            lblLyDo = new Label();
            lblTrangThai = new Label();
            cboNhanVien = new ComboBox();
            cboLoaiNghi = new ComboBox();
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            nudTongSoNgay = new NumericUpDown();
            txtLyDo = new TextBox();
            cboTrangThai = new ComboBox();
            btnTinhSoNgay = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvDonNghiPhep = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudTongSoNgay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonNghiPhep).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(25, 16);
            lblTieuDe.Text = "ĐƠN NGHỈ PHÉP";

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 67);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(115, 64);
            cboNhanVien.Size = new Size(260, 28);

            lblLoaiNghi.AutoSize = true;
            lblLoaiNghi.Location = new Point(395, 67);
            lblLoaiNghi.Text = "Loại nghỉ";
            cboLoaiNghi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiNghi.Location = new Point(470, 64);
            cboLoaiNghi.Size = new Size(200, 28);

            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(28, 107);
            lblTuNgay.Text = "Từ ngày";
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(115, 104);
            dtpTuNgay.Size = new Size(120, 27);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(255, 107);
            lblDenNgay.Text = "Đến ngày";
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(325, 104);
            dtpDenNgay.Size = new Size(120, 27);

            lblTongSoNgay.AutoSize = true;
            lblTongSoNgay.Location = new Point(470, 107);
            lblTongSoNgay.Text = "Số ngày";
            nudTongSoNgay.Location = new Point(530, 104);
            nudTongSoNgay.DecimalPlaces = 2;
            nudTongSoNgay.Maximum = 365;
            nudTongSoNgay.Size = new Size(90, 27);

            btnTinhSoNgay.Location = new Point(640, 101);
            btnTinhSoNgay.Size = new Size(110, 32);
            btnTinhSoNgay.Text = "Tính số ngày";
            btnTinhSoNgay.Click += btnTinhSoNgay_Click;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(780, 67);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "ChoDuyet", "DaDuyet", "TuChoi" });
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboTrangThai.Location = new Point(855, 64);
            cboTrangThai.Size = new Size(140, 28);

            lblLyDo.AutoSize = true;
            lblLyDo.Location = new Point(28, 147);
            lblLyDo.Text = "Lý do";
            txtLyDo.Location = new Point(115, 144);
            txtLyDo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLyDo.Size = new Size(620, 27);

            btnThem.Location = new Point(1020, 61);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(90, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1116, 61);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1020, 104);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1116, 104);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(90, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvDonNghiPhep.Location = new Point(28, 195);
            dgvDonNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDonNghiPhep.Size = new Size(1178, 410);
            dgvDonNghiPhep.CellClick += dgvDonNghiPhep_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1235, 630);
            MinimumSize = new Size(1160, 680);
            Controls.Add(dgvDonNghiPhep);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtLyDo);
            Controls.Add(cboTrangThai);
            Controls.Add(btnTinhSoNgay);
            Controls.Add(nudTongSoNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(cboLoaiNghi);
            Controls.Add(cboNhanVien);
            Controls.Add(lblTrangThai);
            Controls.Add(lblLyDo);
            Controls.Add(lblTongSoNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(lblTuNgay);
            Controls.Add(lblLoaiNghi);
            Controls.Add(lblNhanVien);
            Controls.Add(lblTieuDe);
            Name = "FrmDonNghiPhep";
            Text = "Đơn nghỉ phép";
            Load += FrmDonNghiPhep_Load;
            ((System.ComponentModel.ISupportInitialize)nudTongSoNgay).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonNghiPhep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
