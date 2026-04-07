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
        private Label lblNhanVien;
        private Label lblCaLamViec;
        private Label lblNgayLamViec;
        private ComboBox cboNhanVien;
        private ComboBox cboCaLamViec;
        private DateTimePicker dtpNgayLamViec;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvPhanCa;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblNhanVien = new Label();
            lblCaLamViec = new Label();
            lblNgayLamViec = new Label();
            cboNhanVien = new ComboBox();
            cboCaLamViec = new ComboBox();
            dtpNgayLamViec = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvPhanCa = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPhanCa).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(26, 17);
            lblTieuDe.Text = "PHÂN CA NHÂN VIÊN";

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(30, 75);
            lblNhanVien.Text = "Nhân viên";

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(120, 72);
            cboNhanVien.Size = new Size(280, 28);

            lblCaLamViec.AutoSize = true;
            lblCaLamViec.Location = new Point(430, 75);
            lblCaLamViec.Text = "Ca làm việc";

            cboCaLamViec.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaLamViec.Location = new Point(520, 72);
            cboCaLamViec.Size = new Size(220, 28);

            lblNgayLamViec.AutoSize = true;
            lblNgayLamViec.Location = new Point(770, 75);
            lblNgayLamViec.Text = "Ngày làm việc";

            dtpNgayLamViec.Format = DateTimePickerFormat.Short;
            dtpNgayLamViec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpNgayLamViec.Location = new Point(870, 72);
            dtpNgayLamViec.Size = new Size(130, 27);

            btnThem.Location = new Point(1020, 68);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(85, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(1111, 68);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(85, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(1020, 108);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(85, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(1111, 108);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(85, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvPhanCa.Location = new Point(30, 170);
            dgvPhanCa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhanCa.Size = new Size(1166, 420);
            dgvPhanCa.CellClick += dgvPhanCa_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1230, 620);
            MinimumSize = new Size(1160, 660);
            Controls.Add(dgvPhanCa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dtpNgayLamViec);
            Controls.Add(cboCaLamViec);
            Controls.Add(cboNhanVien);
            Controls.Add(lblNgayLamViec);
            Controls.Add(lblCaLamViec);
            Controls.Add(lblNhanVien);
            Controls.Add(lblTieuDe);
            Name = "FrmPhanCaNhanVien";
            Text = "Phân ca nhân viên";
            Load += FrmPhanCaNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhanCa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
