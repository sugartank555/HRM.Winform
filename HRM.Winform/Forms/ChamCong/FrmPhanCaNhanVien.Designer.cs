namespace HRM.Winform.Forms.ChamCong
{
    partial class FrmPhanCaNhanVien
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
        private Label lblCheDo;
        private Panel pnlThongTin;
        private ComboBox cboNhanVien;
        private ComboBox cboCaLamViec;
        private ComboBox cboCheDo;
        private DateTimePicker dtpNgayLamViec;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvPhanCa;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblNhanVien = new Label();
            lblCaLamViec = new Label();
            lblNgayLamViec = new Label();
            lblCheDo = new Label();
            pnlThongTin = new Panel();
            cboNhanVien = new ComboBox();
            cboCaLamViec = new ComboBox();
            cboCheDo = new ComboBox();
            dtpNgayLamViec = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvPhanCa = new DataGridView();
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCa).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Phân ca nhân viên";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Thiết lập ca làm việc theo ngày cho từng nhân viên đang hoạt động.";

            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(cboCheDo);
            pnlThongTin.Controls.Add(dtpNgayLamViec);
            pnlThongTin.Controls.Add(cboCaLamViec);
            pnlThongTin.Controls.Add(cboNhanVien);
            pnlThongTin.Controls.Add(lblCheDo);
            pnlThongTin.Controls.Add(lblNgayLamViec);
            pnlThongTin.Controls.Add(lblCaLamViec);
            pnlThongTin.Controls.Add(lblNhanVien);
            pnlThongTin.Location = new Point(24, 100);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(1180, 160);

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(24, 29);
            lblNhanVien.Text = "Nhân viên";

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(108, 25);
            cboNhanVien.Size = new Size(360, 28);

            lblCaLamViec.AutoSize = true;
            lblCaLamViec.Location = new Point(498, 29);
            lblCaLamViec.Text = "Ca làm việc";

            cboCaLamViec.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaLamViec.Location = new Point(590, 25);
            cboCaLamViec.Size = new Size(210, 28);

            lblNgayLamViec.AutoSize = true;
            lblNgayLamViec.Location = new Point(826, 29);
            lblNgayLamViec.Text = "Ngày làm việc";

            lblCheDo.AutoSize = true;
            lblCheDo.Location = new Point(24, 76);
            lblCheDo.Text = "Chế độ";

            dtpNgayLamViec.Format = DateTimePickerFormat.Short;
            dtpNgayLamViec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpNgayLamViec.Location = new Point(928, 25);
            dtpNgayLamViec.Size = new Size(130, 27);

            cboCheDo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCheDo.Location = new Point(108, 72);
            cboCheDo.Size = new Size(220, 28);

            btnThem.Location = new Point(873, 108);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(120, 34);
            btnThem.Text = "Lưu phân ca";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(999, 108);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1095, 108);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(952, 64);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(196, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvPhanCa.Location = new Point(24, 284);
            dgvPhanCa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhanCa.Size = new Size(1180, 406);
            dgvPhanCa.CellClick += dgvPhanCa_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1230, 724);
            MinimumSize = new Size(1160, 720);
            Controls.Add(dgvPhanCa);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmPhanCaNhanVien";
            Text = "Phân ca nhân viên";
            Load += FrmPhanCaNhanVien_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
