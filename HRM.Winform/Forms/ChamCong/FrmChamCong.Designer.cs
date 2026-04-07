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
            ((System.ComponentModel.ISupportInitialize)nudDiMuon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudVeSom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoGioLam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTangCa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChamCong).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 15);
            lblTieuDe.Text = "CHẤM CÔNG";

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 65);
            lblNhanVien.Text = "Nhân viên";
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(120, 62);
            cboNhanVien.Size = new Size(260, 28);

            lblCaLamViec.AutoSize = true;
            lblCaLamViec.Location = new Point(405, 65);
            lblCaLamViec.Text = "Ca làm việc";
            cboCaLamViec.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaLamViec.Location = new Point(490, 62);
            cboCaLamViec.Size = new Size(180, 28);

            lblNgayLamViec.AutoSize = true;
            lblNgayLamViec.Location = new Point(695, 65);
            lblNgayLamViec.Text = "Ngày làm việc";
            dtpNgayLamViec.Format = DateTimePickerFormat.Short;
            dtpNgayLamViec.Location = new Point(800, 62);
            dtpNgayLamViec.Size = new Size(120, 27);

            lblCheckIn.AutoSize = true;
            lblCheckIn.Location = new Point(28, 105);
            lblCheckIn.Text = "Check In";
            dtpCheckIn.Format = DateTimePickerFormat.Custom;
            dtpCheckIn.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpCheckIn.Location = new Point(120, 102);
            dtpCheckIn.Size = new Size(180, 27);

            lblCheckOut.AutoSize = true;
            lblCheckOut.Location = new Point(325, 105);
            lblCheckOut.Text = "Check Out";
            dtpCheckOut.Format = DateTimePickerFormat.Custom;
            dtpCheckOut.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpCheckOut.Location = new Point(410, 102);
            dtpCheckOut.Size = new Size(180, 27);

            lblDiMuon.AutoSize = true;
            lblDiMuon.Location = new Point(615, 105);
            lblDiMuon.Text = "Đi muộn";
            nudDiMuon.Location = new Point(680, 102);
            nudDiMuon.Maximum = 600;
            nudDiMuon.Size = new Size(80, 27);

            lblVeSom.AutoSize = true;
            lblVeSom.Location = new Point(780, 105);
            lblVeSom.Text = "Về sớm";
            nudVeSom.Location = new Point(840, 102);
            nudVeSom.Maximum = 600;
            nudVeSom.Size = new Size(80, 27);

            lblSoGioLam.AutoSize = true;
            lblSoGioLam.Location = new Point(28, 145);
            lblSoGioLam.Text = "Số giờ làm";
            nudSoGioLam.DecimalPlaces = 2;
            nudSoGioLam.Location = new Point(120, 142);
            nudSoGioLam.Maximum = 1000;
            nudSoGioLam.Size = new Size(100, 27);

            lblTangCa.AutoSize = true;
            lblTangCa.Location = new Point(245, 145);
            lblTangCa.Text = "Tăng ca";
            nudTangCa.DecimalPlaces = 2;
            nudTangCa.Location = new Point(305, 142);
            nudTangCa.Maximum = 1000;
            nudTangCa.Size = new Size(100, 27);

            btnTuTinhGio.Location = new Point(425, 140);
            btnTuTinhGio.Size = new Size(120, 32);
            btnTuTinhGio.Text = "Tự tính giờ";
            btnTuTinhGio.Click += btnTuTinhGio_Click;

            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(570, 145);
            lblTrangThai.Text = "Trạng thái";
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Location = new Point(645, 142);
            cboTrangThai.Size = new Size(160, 28);

            lblGhiChu.AutoSize = true;
            lblGhiChu.Location = new Point(28, 185);
            lblGhiChu.Text = "Ghi chú";
            txtGhiChu.Location = new Point(120, 182);
            txtGhiChu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtGhiChu.Size = new Size(685, 27);

            btnThem.Location = new Point(970, 60);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(95, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1071, 60);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(95, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(970, 105);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(95, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1071, 105);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(95, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvChamCong.Location = new Point(28, 235);
            dgvChamCong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChamCong.Size = new Size(1138, 390);
            dgvChamCong.CellClick += dgvChamCong_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1195, 650);
            MinimumSize = new Size(1120, 680);
            Controls.Add(dgvChamCong);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtGhiChu);
            Controls.Add(cboTrangThai);
            Controls.Add(btnTuTinhGio);
            Controls.Add(nudTangCa);
            Controls.Add(nudSoGioLam);
            Controls.Add(nudVeSom);
            Controls.Add(nudDiMuon);
            Controls.Add(dtpCheckOut);
            Controls.Add(dtpCheckIn);
            Controls.Add(dtpNgayLamViec);
            Controls.Add(cboCaLamViec);
            Controls.Add(cboNhanVien);
            Controls.Add(lblGhiChu);
            Controls.Add(lblTrangThai);
            Controls.Add(lblTangCa);
            Controls.Add(lblSoGioLam);
            Controls.Add(lblVeSom);
            Controls.Add(lblDiMuon);
            Controls.Add(lblCheckOut);
            Controls.Add(lblCheckIn);
            Controls.Add(lblNgayLamViec);
            Controls.Add(lblCaLamViec);
            Controls.Add(lblNhanVien);
            Controls.Add(lblTieuDe);
            Name = "FrmChamCong";
            Text = "Chấm công";
            Load += FrmChamCong_Load;
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
