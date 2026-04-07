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
            ((System.ComponentModel.ISupportInitialize)dgvChucVu).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(28, 18);
            lblTieuDe.Text = "DANH MỤC CHỨC VỤ";

            lblMaChucVu.AutoSize = true;
            lblMaChucVu.Location = new Point(31, 78);
            lblMaChucVu.Text = "Mã chức vụ";

            lblTenChucVu.AutoSize = true;
            lblTenChucVu.Location = new Point(31, 118);
            lblTenChucVu.Text = "Tên chức vụ";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(31, 158);
            lblMoTa.Text = "Mô tả";

            txtMaChucVu.Location = new Point(154, 75);
            txtMaChucVu.Size = new Size(220, 27);

            txtTenChucVu.Location = new Point(154, 115);
            txtTenChucVu.Size = new Size(320, 27);

            txtMoTa.Location = new Point(154, 155);
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.Size = new Size(420, 27);

            btnThem.Location = new Point(610, 72);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(95, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;

            btnSua.Location = new Point(711, 72);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(95, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;

            btnXoa.Location = new Point(812, 72);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(95, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;

            btnLamMoi.Location = new Point(913, 72);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(95, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;

            dgvChucVu.Location = new Point(31, 210);
            dgvChucVu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChucVu.Size = new Size(977, 360);
            dgvChucVu.CellClick += dgvChucVu_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1045, 600);
            MinimumSize = new Size(980, 620);
            Controls.Add(dgvChucVu);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenChucVu);
            Controls.Add(txtMaChucVu);
            Controls.Add(lblMoTa);
            Controls.Add(lblTenChucVu);
            Controls.Add(lblMaChucVu);
            Controls.Add(lblTieuDe);
            Name = "FrmChucVu";
            Text = "Chức vụ";
            Load += FrmChucVu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChucVu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
