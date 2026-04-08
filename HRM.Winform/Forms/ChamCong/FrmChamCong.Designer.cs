namespace HRM.Winform.Forms.ChamCong
{
    partial class FrmChamCong
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
        private Label lblCaLamViec;
        private Label lblNgayLamViec;
        private Label lblCheckIn;
        private Label lblCheckOut;
        private Label lblDiMuon;
        private Label lblVeSom;
        private Label lblSoGioLam;
        private Label lblTangCa;
        private Label lblTrangThai;
        private Label lblGhiChu;
        private Panel pnlThongTin;

        private ComboBox cboNhanVien;
        private ComboBox cboCaLamViec;
        private ComboBox cboTrangThai;

        private DateTimePicker dtpNgayLamViec;
        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;

        private NumericUpDown nudDiMuon;
        private NumericUpDown nudVeSom;
        private NumericUpDown nudSoGioLam;
        private NumericUpDown nudTangCa;

        private TextBox txtGhiChu;

        private Button btnTuTinhGio;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private DataGridView dgvChamCong;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblNhanVien = new Label();
            lblCaLamViec = new Label();
            lblNgayLamViec = new Label();
            lblCheckIn = new Label();
            lblCheckOut = new Label();
            lblDiMuon = new Label();
            lblVeSom = new Label();
            lblSoGioLam = new Label();
            lblTangCa = new Label();
            lblTrangThai = new Label();
            lblGhiChu = new Label();
            pnlThongTin = new Panel();
            cboNhanVien = new ComboBox();
            cboCaLamViec = new ComboBox();
            cboTrangThai = new ComboBox();
            dtpNgayLamViec = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            dtpCheckOut = new DateTimePicker();
            nudDiMuon = new NumericUpDown();
            nudVeSom = new NumericUpDown();
            nudSoGioLam = new NumericUpDown();
            nudTangCa = new NumericUpDown();
            txtGhiChu = new TextBox();
            btnTuTinhGio = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvChamCong = new DataGridView();
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiMuon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudVeSom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoGioLam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTangCa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Chấm công";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Quản lý check-in, check-out, số giờ làm, tăng ca và trạng thái công theo ngày.";

            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(txtGhiChu);
            pnlThongTin.Controls.Add(cboTrangThai);
            pnlThongTin.Controls.Add(btnTuTinhGio);
            pnlThongTin.Controls.Add(nudTangCa);
            pnlThongTin.Controls.Add(nudSoGioLam);
            pnlThongTin.Controls.Add(nudVeSom);
            pnlThongTin.Controls.Add(nudDiMuon);
            pnlThongTin.Controls.Add(dtpCheckOut);
            pnlThongTin.Controls.Add(dtpCheckIn);
            pnlThongTin.Controls.Add(dtpNgayLamViec);
            pnlThongTin.Controls.Add(cboCaLamViec);
            pnlThongTin.Controls.Add(cboNhanVien);
            pnlThongTin.Controls.Add(lblGhiChu);
            pnlThongTin.Controls.Add(lblTrangThai);
            pnlThongTin.Controls.Add(lblTangCa);
            pnlThongTin.Controls.Add(lblSoGioLam);
            pnlThongTin.Controls.Add(lblVeSom);
            pnlThongTin.Controls.Add(lblDiMuon);
            pnlThongTin.Controls.Add(lblCheckOut);
            pnlThongTin.Controls.Add(lblCheckIn);
            pnlThongTin.Controls.Add(lblNgayLamViec);
            pnlThongTin.Controls.Add(lblCaLamViec);
            pnlThongTin.Controls.Add(lblNhanVien);
            pnlThongTin.Location = new Point(24, 100);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(1147, 186);

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(24, 28);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(108, 24);
            cboNhanVien.Size = new Size(300, 28);

            lblCaLamViec.AutoSize = true;
            lblCaLamViec.Location = new Point(432, 28);
            lblCaLamViec.Text = "Ca làm việc";
            cboCaLamViec.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaLamViec.Location = new Point(515, 24);
            cboCaLamViec.Size = new Size(180, 28);

            lblNgayLamViec.AutoSize = true;
            lblNgayLamViec.Location = new Point(720, 28);
            lblNgayLamViec.Text = "Ngày làm việc";
            dtpNgayLamViec.Format = DateTimePickerFormat.Short;
            dtpNgayLamViec.Location = new Point(824, 24);
            dtpNgayLamViec.Size = new Size(120, 27);

            lblCheckIn.AutoSize = true;
            lblCheckIn.Location = new Point(24, 69);
            lblCheckIn.Text = "Check In";
            dtpCheckIn.Format = DateTimePickerFormat.Custom;
            dtpCheckIn.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpCheckIn.Location = new Point(108, 65);
            dtpCheckIn.Size = new Size(180, 27);

            lblCheckOut.AutoSize = true;
            lblCheckOut.Location = new Point(316, 69);
            lblCheckOut.Text = "Check Out";
            dtpCheckOut.Format = DateTimePickerFormat.Custom;
            dtpCheckOut.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpCheckOut.Location = new Point(404, 65);
            dtpCheckOut.Size = new Size(180, 27);

            lblDiMuon.AutoSize = true;
            lblDiMuon.Location = new Point(611, 69);
            lblDiMuon.Text = "Đi muộn";
            nudDiMuon.Location = new Point(674, 65);
            nudDiMuon.Maximum = 600;
            nudDiMuon.Size = new Size(80, 27);

            lblVeSom.AutoSize = true;
            lblVeSom.Location = new Point(778, 69);
            lblVeSom.Text = "Về sớm";
            nudVeSom.Location = new Point(838, 65);
            nudVeSom.Maximum = 600;
            nudVeSom.Size = new Size(80, 27);

            lblSoGioLam.AutoSize = true;
            lblSoGioLam.Location = new Point(24, 110);
            lblSoGioLam.Text = "Số giờ làm";
            nudSoGioLam.DecimalPlaces = 2;
            nudSoGioLam.Location = new Point(108, 106);
            nudSoGioLam.Maximum = 1000;
            nudSoGioLam.Size = new Size(100, 27);

            lblTangCa.AutoSize = true;
            lblTangCa.Location = new Point(231, 110);
            lblTangCa.Text = "Tăng ca";
            nudTangCa.DecimalPlaces = 2;
            nudTangCa.Location = new Point(288, 106);
            nudTangCa.Maximum = 1000;
            nudTangCa.Size = new Size(100, 27);

            btnTuTinhGio.Location = new Point(412, 104);
            btnTuTinhGio.Size = new Size(120, 32);
            btnTuTinhGio.Text = "Tự tính giờ";
            btnTuTinhGio.Click += btnTuTinhGio_Click;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(555, 110);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(628, 106);
            cboTrangThai.Size = new Size(160, 28);

            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(24, 150);
            lblGhiChu.Text = "Ghi chú";
            txtGhiChu.Location = new Point(108, 146);
            txtGhiChu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGhiChu.Size = new Size(680, 27);

            btnThem.Location = new Point(956, 23);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(95, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1057, 23);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(95, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(956, 66);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(95, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1057, 66);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(95, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvChamCong.Location = new Point(24, 310);
            dgvChamCong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChamCong.Size = new Size(1147, 388);
            dgvChamCong.CellClick += dgvChamCong_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1195, 730);
            MinimumSize = new Size(1120, 720);
            Controls.Add(dgvChamCong);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmChamCong";
            Text = "Chấm công";
            Load += FrmChamCong_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiMuon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudVeSom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoGioLam).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTangCa).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
