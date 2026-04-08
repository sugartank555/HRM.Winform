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
        private Label lblMoTa;
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
        private Panel pnlThongTin;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
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
            pnlThongTin = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudTongSoGio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonTangCa).BeginInit();
            pnlThongTin.SuspendLayout();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Đơn tăng ca";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Tạo và quản lý các đơn đăng ký tăng ca cho nhân sự.";

            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Location = new Point(24, 102);
            pnlThongTin.Size = new Size(1182, 168);

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 26);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(110, 23);
            cboNhanVien.Size = new Size(260, 28);

            lblNgayLam.AutoSize = true;
            lblNgayLam.Location = new Point(390, 26);
            lblNgayLam.Text = "Ngày làm";
            dtpNgayLam.Format = DateTimePickerFormat.Short;
            dtpNgayLam.Location = new Point(460, 23);
            dtpNgayLam.Size = new Size(120, 27);

            lblTuGio.AutoSize = true;
            lblTuGio.Location = new Point(28, 66);
            lblTuGio.Text = "Từ giờ";
            dtpTuGio.Format = DateTimePickerFormat.Custom;
            dtpTuGio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpTuGio.Location = new Point(110, 63);
            dtpTuGio.Size = new Size(180, 27);

            lblDenGio.AutoSize = true;
            lblDenGio.Location = new Point(315, 66);
            lblDenGio.Text = "Đến giờ";
            dtpDenGio.Format = DateTimePickerFormat.Custom;
            dtpDenGio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDenGio.Location = new Point(390, 63);
            dtpDenGio.Size = new Size(180, 27);

            lblTongSoGio.AutoSize = true;
            lblTongSoGio.Location = new Point(595, 66);
            lblTongSoGio.Text = "Tổng số giờ";
            nudTongSoGio.DecimalPlaces = 2;
            nudTongSoGio.Location = new Point(680, 63);
            nudTongSoGio.Maximum = 1000;
            nudTongSoGio.Size = new Size(90, 27);

            btnTinhGio.Location = new Point(790, 60);
            btnTinhGio.Size = new Size(100, 32);
            btnTinhGio.Text = "Tính giờ";
            btnTinhGio.Click += btnTinhGio_Click;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(610, 26);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "ChoDuyet", "DaDuyet", "TuChoi" });
            cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboTrangThai.Location = new Point(680, 23);
            cboTrangThai.Size = new Size(140, 28);

            lblLyDo.AutoSize = true;
            lblLyDo.Location = new Point(28, 107);
            lblLyDo.Text = "Lý do";
            txtLyDo.Location = new Point(110, 104);
            txtLyDo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLyDo.Size = new Size(710, 27);

            btnThem.Location = new Point(1015, 20);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(90, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1111, 20);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1015, 63);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1111, 63);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(90, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvDonTangCa.Location = new Point(24, 290);
            dgvDonTangCa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDonTangCa.Size = new Size(1182, 390);
            dgvDonTangCa.CellClick += dgvDonTangCa_CellClick;

            pnlThongTin.Controls.Add(lblNhanVien);
            pnlThongTin.Controls.Add(cboNhanVien);
            pnlThongTin.Controls.Add(lblNgayLam);
            pnlThongTin.Controls.Add(dtpNgayLam);
            pnlThongTin.Controls.Add(lblTrangThai);
            pnlThongTin.Controls.Add(cboTrangThai);
            pnlThongTin.Controls.Add(lblTuGio);
            pnlThongTin.Controls.Add(dtpTuGio);
            pnlThongTin.Controls.Add(lblDenGio);
            pnlThongTin.Controls.Add(dtpDenGio);
            pnlThongTin.Controls.Add(lblTongSoGio);
            pnlThongTin.Controls.Add(nudTongSoGio);
            pnlThongTin.Controls.Add(btnTinhGio);
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
            ClientSize = new Size(1230, 720);
            MinimumSize = new Size(1160, 700);
            Controls.Add(dgvDonTangCa);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmDonTangCa";
            Text = "Đơn tăng ca";
            Load += FrmDonTangCa_Load;
            ((System.ComponentModel.ISupportInitialize)nudTongSoGio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonTangCa).EndInit();
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
