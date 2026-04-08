namespace HRM.Winform.Forms.DanhMuc
{
    partial class FrmChucVu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblMoTaForm;
        private Panel pnlThongTin;
        private Label lblMaChucVu;
        private Label lblTenChucVu;
        private Label lblMoTa;
        private TextBox txtMaChucVu;
        private TextBox txtTenChucVu;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvChucVu;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTaForm = new Label();
            pnlThongTin = new Panel();
            lblMaChucVu = new Label();
            lblTenChucVu = new Label();
            lblMoTa = new Label();
            txtMaChucVu = new TextBox();
            txtTenChucVu = new TextBox();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvChucVu = new DataGridView();
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChucVu).BeginInit();
            SuspendLayout();
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Chức vụ";
            lblMoTaForm.AutoSize = true;
            lblMoTaForm.Location = new Point(28, 62);
            lblMoTaForm.Text = "Thiết lập danh mục chức vụ và mô tả vai trò áp dụng cho nhân sự.";
            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(txtMoTa);
            pnlThongTin.Controls.Add(txtTenChucVu);
            pnlThongTin.Controls.Add(txtMaChucVu);
            pnlThongTin.Controls.Add(lblMoTa);
            pnlThongTin.Controls.Add(lblTenChucVu);
            pnlThongTin.Controls.Add(lblMaChucVu);
            pnlThongTin.Location = new Point(24, 100);
            pnlThongTin.Size = new Size(1000, 132);
            lblMaChucVu.AutoSize = true;
            lblMaChucVu.Location = new Point(24, 28);
            lblMaChucVu.Text = "Mã chức vụ";
            lblTenChucVu.AutoSize = true;
            lblTenChucVu.Location = new Point(24, 68);
            lblTenChucVu.Text = "Tên chức vụ";
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(420, 28);
            lblMoTa.Text = "Mô tả";
            txtMaChucVu.Location = new Point(126, 24);
            txtMaChucVu.Size = new Size(220, 27);
            txtTenChucVu.Location = new Point(126, 64);
            txtTenChucVu.Size = new Size(220, 27);
            txtMoTa.Location = new Point(474, 24);
            txtMoTa.Size = new Size(270, 27);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(784, 22);
            btnThem.Size = new Size(90, 34);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Location = new Point(880, 22);
            btnSua.Size = new Size(90, 34);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Location = new Point(784, 64);
            btnXoa.Size = new Size(90, 34);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Location = new Point(880, 64);
            btnLamMoi.Size = new Size(90, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            dgvChucVu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChucVu.Location = new Point(24, 256);
            dgvChucVu.Size = new Size(1000, 414);
            dgvChucVu.CellClick += dgvChucVu_CellClick;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1050, 700);
            MinimumSize = new Size(980, 680);
            Controls.Add(dgvChucVu);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTaForm);
            Controls.Add(lblTieuDe);
            Name = "FrmChucVu";
            Text = "Chức vụ";
            Load += FrmChucVu_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChucVu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
