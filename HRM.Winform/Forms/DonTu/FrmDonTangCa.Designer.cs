namespace HRM.Winform.Forms.DonTu
{
    partial class FrmDonTangCa
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblNhanVien;
        private Label lblNgayLam;
        private Label lblTuGio;
        private Label lblDenGio;
        private Label lblTongSoGio;
        private Label lblLyDo;
        private Label lblTrangThai;
        private ComboBox cboNhanVien;
        private DateTimePicker dtpNgayLam;
        private DateTimePicker dtpTuGio;
        private DateTimePicker dtpDenGio;
        private NumericUpDown nudTongSoGio;
        private TextBox txtLyDo;
        private ComboBox cboTrangThai;
        private Button btnTinhGio;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvDonTangCa;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblNhanVien = new Label();
            lblNgayLam = new Label();
            lblTuGio = new Label();
            lblDenGio = new Label();
            lblTongSoGio = new Label();
            lblLyDo = new Label();
            lblTrangThai = new Label();
            cboNhanVien = new ComboBox();
            dtpNgayLam = new DateTimePicker();
            dtpTuGio = new DateTimePicker();
            dtpDenGio = new DateTimePicker();
            nudTongSoGio = new NumericUpDown();
            txtLyDo = new TextBox();
            cboTrangThai = new ComboBox();
            btnTinhGio = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvDonTangCa = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudTongSoGio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonTangCa).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(25, 16);
            lblTieuDe.Text = "ĐƠN TĂNG CA";

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 67);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(110, 64);
            cboNhanVien.Size = new Size(260, 28);

            lblNgayLam.AutoSize = true;
            lblNgayLam.Location = new Point(390, 67);
            lblNgayLam.Text = "Ngày làm";
            dtpNgayLam.Format = DateTimePickerFormat.Short;
            dtpNgayLam.Location = new Point(460, 64);
            dtpNgayLam.Size = new Size(120, 27);

            lblTuGio.AutoSize = true;
            lblTuGio.Location = new Point(28, 107);
            lblTuGio.Text = "Từ giờ";
            dtpTuGio.Format = DateTimePickerFormat.Custom;
            dtpTuGio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpTuGio.Location = new Point(110, 104);
            dtpTuGio.Size = new Size(180, 27);

            lblDenGio.AutoSize = true;
            lblDenGio.Location = new Point(315, 107);
            lblDenGio.Text = "Đến giờ";
            dtpDenGio.Format = DateTimePickerFormat.Custom;
            dtpDenGio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDenGio.Location = new Point(390, 104);
            dtpDenGio.Size = new Size(180, 27);

            lblTongSoGio.AutoSize = true;
            lblTongSoGio.Location = new Point(595, 107);
            lblTongSoGio.Text = "Tổng số giờ";
            nudTongSoGio.DecimalPlaces = 2;
            nudTongSoGio.Location = new Point(680, 104);
            nudTongSoGio.Maximum = 1000;
            nudTongSoGio.Size = new Size(90, 27);

            btnTinhGio.Location = new Point(790, 101);
            btnTinhGio.Size = new Size(100, 32);
            btnTinhGio.Text = "Tính giờ";
            btnTinhGio.Click += btnTinhGio_Click;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(610, 67);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "ChoDuyet", "DaDuyet", "TuChoi" });
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboTrangThai.Location = new Point(680, 64);
            cboTrangThai.Size = new Size(140, 28);

            lblLyDo.AutoSize = true;
            lblLyDo.Location = new Point(28, 147);
            lblLyDo.Text = "Lý do";
            txtLyDo.Location = new Point(110, 144);
            txtLyDo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLyDo.Size = new Size(710, 27);

            btnThem.Location = new Point(1015, 61);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(90, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1111, 61);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1015, 104);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1111, 104);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(90, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvDonTangCa.Location = new Point(28, 195);
            dgvDonTangCa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDonTangCa.Size = new Size(1173, 410);
            dgvDonTangCa.CellClick += dgvDonTangCa_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1230, 630);
            MinimumSize = new Size(1160, 680);
            Controls.Add(dgvDonTangCa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtLyDo);
            Controls.Add(cboTrangThai);
            Controls.Add(btnTinhGio);
            Controls.Add(nudTongSoGio);
            Controls.Add(dtpDenGio);
            Controls.Add(dtpTuGio);
            Controls.Add(dtpNgayLam);
            Controls.Add(cboNhanVien);
            Controls.Add(lblTrangThai);
            Controls.Add(lblLyDo);
            Controls.Add(lblTongSoGio);
            Controls.Add(lblDenGio);
            Controls.Add(lblTuGio);
            Controls.Add(lblNgayLam);
            Controls.Add(lblNhanVien);
            Controls.Add(lblTieuDe);
            Name = "FrmDonTangCa";
            Text = "Đơn tăng ca";
            Load += FrmDonTangCa_Load;
            ((System.ComponentModel.ISupportInitialize)nudTongSoGio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonTangCa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
