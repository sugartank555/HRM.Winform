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
        private Label lblMoTa;
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
        private Panel pnlThongTin;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
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
            pnlThongTin = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudTongSoNgay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonNghiPhep).BeginInit();
            pnlThongTin.SuspendLayout();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Đơn nghỉ phép";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Tạo và quản lý các đơn nghỉ phép của nhân sự trong hệ thống.";

            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Location = new Point(24, 102);
            pnlThongTin.Size = new Size(1187, 168);

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 26);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(115, 23);
            cboNhanVien.Size = new Size(260, 28);

            lblLoaiNghi.AutoSize = true;
            lblLoaiNghi.Location = new Point(395, 26);
            lblLoaiNghi.Text = "Loại nghỉ";
            cboLoaiNghi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiNghi.Location = new Point(470, 23);
            cboLoaiNghi.Size = new Size(200, 28);

            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(28, 66);
            lblTuNgay.Text = "Từ ngày";
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(115, 63);
            dtpTuNgay.Size = new Size(120, 27);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(255, 66);
            lblDenNgay.Text = "Đến ngày";
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(325, 63);
            dtpDenNgay.Size = new Size(120, 27);

            lblTongSoNgay.AutoSize = true;
            lblTongSoNgay.Location = new Point(470, 66);
            lblTongSoNgay.Text = "Số ngày";
            nudTongSoNgay.Location = new Point(530, 63);
            nudTongSoNgay.DecimalPlaces = 2;
            nudTongSoNgay.Maximum = 365;
            nudTongSoNgay.Size = new Size(90, 27);

            btnTinhSoNgay.Location = new Point(640, 60);
            btnTinhSoNgay.Size = new Size(110, 32);
            btnTinhSoNgay.Text = "Tính số ngày";
            btnTinhSoNgay.Click += btnTinhSoNgay_Click;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(780, 26);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "ChoDuyet", "DaDuyet", "TuChoi" });
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboTrangThai.Location = new Point(855, 23);
            cboTrangThai.Size = new Size(140, 28);

            lblLyDo.AutoSize = true;
            lblLyDo.Location = new Point(28, 107);
            lblLyDo.Text = "Lý do";
            txtLyDo.Location = new Point(115, 104);
            txtLyDo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLyDo.Size = new Size(620, 27);

            btnThem.Location = new Point(1020, 20);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(90, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1116, 20);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1020, 63);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1116, 63);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(90, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvDonNghiPhep.Location = new Point(24, 290);
            dgvDonNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDonNghiPhep.Size = new Size(1187, 390);
            dgvDonNghiPhep.CellClick += dgvDonNghiPhep_CellClick;

            pnlThongTin.Controls.Add(lblNhanVien);
            pnlThongTin.Controls.Add(cboNhanVien);
            pnlThongTin.Controls.Add(lblLoaiNghi);
            pnlThongTin.Controls.Add(cboLoaiNghi);
            pnlThongTin.Controls.Add(lblTuNgay);
            pnlThongTin.Controls.Add(dtpTuNgay);
            pnlThongTin.Controls.Add(lblDenNgay);
            pnlThongTin.Controls.Add(dtpDenNgay);
            pnlThongTin.Controls.Add(lblTongSoNgay);
            pnlThongTin.Controls.Add(nudTongSoNgay);
            pnlThongTin.Controls.Add(btnTinhSoNgay);
            pnlThongTin.Controls.Add(lblTrangThai);
            pnlThongTin.Controls.Add(cboTrangThai);
            pnlThongTin.Controls.Add(lblLyDo);
            pnlThongTin.Controls.Add(txtLyDo);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnLamMoi);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1235, 720);
            MinimumSize = new Size(1160, 700);
            Controls.Add(dgvDonNghiPhep);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmDonNghiPhep";
            Text = "Đơn nghỉ phép";
            Load += FrmDonNghiPhep_Load;
            ((System.ComponentModel.ISupportInitialize)nudTongSoNgay).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonNghiPhep).EndInit();
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
