namespace HRM.Winform.Forms.DanhMuc
{
    partial class FrmCaLamViec
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblMaCa;
        private Label lblTenCa;
        private Label lblGioBatDau;
        private Label lblGioKetThuc;
        private Label lblSoPhutNghi;
        private Label lblDiMuon;
        private Label lblVeSom;
        private TextBox txtMaCa;
        private TextBox txtTenCa;
        private DateTimePicker dtpGioBatDau;
        private DateTimePicker dtpGioKetThuc;
        private NumericUpDown nudSoPhutNghi;
        private NumericUpDown nudDiMuon;
        private NumericUpDown nudVeSom;
        private CheckBox chkQuaDem;
        private CheckBox chkHoatDong;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvCaLamViec;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMaCa = new Label();
            lblTenCa = new Label();
            lblGioBatDau = new Label();
            lblGioKetThuc = new Label();
            lblSoPhutNghi = new Label();
            lblDiMuon = new Label();
            lblVeSom = new Label();
            txtMaCa = new TextBox();
            txtTenCa = new TextBox();
            dtpGioBatDau = new DateTimePicker();
            dtpGioKetThuc = new DateTimePicker();
            nudSoPhutNghi = new NumericUpDown();
            nudDiMuon = new NumericUpDown();
            nudVeSom = new NumericUpDown();
            chkQuaDem = new CheckBox();
            chkHoatDong = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvCaLamViec = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nudSoPhutNghi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDiMuon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudVeSom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCaLamViec).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(28, 18);
            lblTieuDe.Text = "DANH MỤC CA LÀM VIỆC";

            lblMaCa.AutoSize = true;
            lblMaCa.Location = new Point(31, 78);
            lblMaCa.Text = "Mã ca";
            lblTenCa.AutoSize = true;
            lblTenCa.Location = new Point(31, 118);
            lblTenCa.Text = "Tên ca";
            lblGioBatDau.AutoSize = true;
            lblGioBatDau.Location = new Point(31, 158);
            lblGioBatDau.Text = "Giờ bắt đầu";
            lblGioKetThuc.AutoSize = true;
            lblGioKetThuc.Location = new Point(31, 198);
            lblGioKetThuc.Text = "Giờ kết thúc";
            lblSoPhutNghi.AutoSize = true;
            lblSoPhutNghi.Location = new Point(430, 78);
            lblSoPhutNghi.Text = "Số phút nghỉ";
            lblDiMuon.AutoSize = true;
            lblDiMuon.Location = new Point(430, 118);
            lblDiMuon.Text = "Cho phép đi muộn";
            lblVeSom.AutoSize = true;
            lblVeSom.Location = new Point(430, 158);
            lblVeSom.Text = "Cho phép về sớm";

            txtMaCa.Location = new Point(145, 75);
            txtMaCa.Size = new Size(220, 27);
            txtTenCa.Location = new Point(145, 115);
            txtTenCa.Size = new Size(220, 27);

            dtpGioBatDau.Format = DateTimePickerFormat.Time;
            dtpGioBatDau.ShowUpDown = true;
            dtpGioBatDau.Location = new Point(145, 155);
            dtpGioBatDau.Size = new Size(220, 27);

            dtpGioKetThuc.Format = DateTimePickerFormat.Time;
            dtpGioKetThuc.ShowUpDown = true;
            dtpGioKetThuc.Location = new Point(145, 195);
            dtpGioKetThuc.Size = new Size(220, 27);

            nudSoPhutNghi.Location = new Point(590, 75);
            nudSoPhutNghi.Maximum = 600;
            nudSoPhutNghi.Size = new Size(120, 27);

            nudDiMuon.Location = new Point(590, 115);
            nudDiMuon.Maximum = 120;
            nudDiMuon.Size = new Size(120, 27);

            nudVeSom.Location = new Point(590, 155);
            nudVeSom.Maximum = 120;
            nudVeSom.Size = new Size(120, 27);

            chkQuaDem.AutoSize = true;
            chkQuaDem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkQuaDem.Location = new Point(430, 198);
            chkQuaDem.Text = "Ca qua đêm";

            chkHoatDong.AutoSize = true;
            chkHoatDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkHoatDong.Location = new Point(590, 198);
            chkHoatDong.Text = "Hoạt động";

            btnThem.Location = new Point(770, 72);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(95, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(871, 72);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(95, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(972, 72);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(95, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(770, 118);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(297, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvCaLamViec.Location = new Point(31, 255);
            dgvCaLamViec.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCaLamViec.Size = new Size(1036, 330);
            dgvCaLamViec.CellClick += dgvCaLamViec_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1100, 620);
            MinimumSize = new Size(1040, 650);
            Controls.Add(dgvCaLamViec);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(chkHoatDong);
            Controls.Add(chkQuaDem);
            Controls.Add(nudVeSom);
            Controls.Add(nudDiMuon);
            Controls.Add(nudSoPhutNghi);
            Controls.Add(dtpGioKetThuc);
            Controls.Add(dtpGioBatDau);
            Controls.Add(txtTenCa);
            Controls.Add(txtMaCa);
            Controls.Add(lblVeSom);
            Controls.Add(lblDiMuon);
            Controls.Add(lblSoPhutNghi);
            Controls.Add(lblGioKetThuc);
            Controls.Add(lblGioBatDau);
            Controls.Add(lblTenCa);
            Controls.Add(lblMaCa);
            Controls.Add(lblTieuDe);
            Name = "FrmCaLamViec";
            Text = "Ca làm việc";
            Load += FrmCaLamViec_Load;
            ((System.ComponentModel.ISupportInitialize)nudSoPhutNghi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDiMuon).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudVeSom).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCaLamViec).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
