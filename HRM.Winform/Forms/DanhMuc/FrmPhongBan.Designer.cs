namespace HRM.Winform.Forms.DanhMuc
{
    partial class FrmPhongBan
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
        private Label lblMaPhongBan;
        private Label lblTenPhongBan;
        private Label lblMoTa;
        private TextBox txtMaPhongBan;
        private TextBox txtTenPhongBan;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvPhongBan;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTaForm = new Label();
            pnlThongTin = new Panel();
            lblMaPhongBan = new Label();
            lblTenPhongBan = new Label();
            lblMoTa = new Label();
            txtMaPhongBan = new TextBox();
            txtTenPhongBan = new TextBox();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvPhongBan = new DataGridView();
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhongBan).BeginInit();
            SuspendLayout();
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Phòng ban";
            lblMoTaForm.AutoSize = true;
            lblMoTaForm.Location = new Point(28, 62);
            lblMoTaForm.Text = "Thiết lập danh mục phòng ban để tổ chức và quản lý nhân sự theo đơn vị.";
            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(txtMoTa);
            pnlThongTin.Controls.Add(txtTenPhongBan);
            pnlThongTin.Controls.Add(txtMaPhongBan);
            pnlThongTin.Controls.Add(lblMoTa);
            pnlThongTin.Controls.Add(lblTenPhongBan);
            pnlThongTin.Controls.Add(lblMaPhongBan);
            pnlThongTin.Location = new Point(24, 100);
            pnlThongTin.Size = new Size(1000, 132);
            lblMaPhongBan.AutoSize = true;
            lblMaPhongBan.Location = new Point(24, 28);
            lblMaPhongBan.Text = "Mã phòng ban";
            lblTenPhongBan.AutoSize = true;
            lblTenPhongBan.Location = new Point(24, 68);
            lblTenPhongBan.Text = "Tên phòng ban";
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(420, 28);
            lblMoTa.Text = "Mô tả";
            txtMaPhongBan.Location = new Point(146, 24);
            txtMaPhongBan.Size = new Size(200, 27);
            txtTenPhongBan.Location = new Point(146, 64);
            txtTenPhongBan.Size = new Size(200, 27);
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
            dgvPhongBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhongBan.Location = new Point(24, 256);
            dgvPhongBan.Size = new Size(1000, 414);
            dgvPhongBan.CellClick += dgvPhongBan_CellClick;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1050, 700);
            MinimumSize = new Size(980, 680);
            Controls.Add(dgvPhongBan);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTaForm);
            Controls.Add(lblTieuDe);
            Name = "FrmPhongBan";
            Text = "Phòng ban";
            Load += FrmPhongBan_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhongBan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
