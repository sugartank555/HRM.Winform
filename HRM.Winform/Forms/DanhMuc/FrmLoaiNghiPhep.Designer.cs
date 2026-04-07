namespace HRM.Winform.Forms.DanhMuc
{
    partial class FrmLoaiNghiPhep
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblMaLoaiNghi;
        private Label lblTenLoaiNghi;
        private Label lblMoTa;
        private TextBox txtMaLoaiNghi;
        private TextBox txtTenLoaiNghi;
        private TextBox txtMoTa;
        private CheckBox chkHuongLuong;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvLoaiNghiPhep;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMaLoaiNghi = new Label();
            lblTenLoaiNghi = new Label();
            lblMoTa = new Label();
            txtMaLoaiNghi = new TextBox();
            txtTenLoaiNghi = new TextBox();
            txtMoTa = new TextBox();
            chkHuongLuong = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLoaiNghiPhep = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiNghiPhep).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(28, 18);
            lblTieuDe.Text = "DANH MỤC LOẠI NGHỈ PHÉP";

            lblMaLoaiNghi.AutoSize = true;
            lblMaLoaiNghi.Location = new Point(31, 78);
            lblMaLoaiNghi.Text = "Mã loại nghỉ";

            lblTenLoaiNghi.AutoSize = true;
            lblTenLoaiNghi.Location = new Point(31, 118);
            lblTenLoaiNghi.Text = "Tên loại nghỉ";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(31, 158);
            lblMoTa.Text = "Mô tả";

            txtMaLoaiNghi.Location = new Point(154, 75);
            txtMaLoaiNghi.Size = new Size(220, 27);

            txtTenLoaiNghi.Location = new Point(154, 115);
            txtTenLoaiNghi.Size = new Size(320, 27);

            txtMoTa.Location = new Point(154, 155);
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.Size = new Size(420, 27);

            chkHuongLuong.AutoSize = true;
            chkHuongLuong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkHuongLuong.Location = new Point(610, 118);
            chkHuongLuong.Text = "Hưởng lương";

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

            dgvLoaiNghiPhep.Location = new Point(31, 210);
            dgvLoaiNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoaiNghiPhep.Size = new Size(977, 360);
            dgvLoaiNghiPhep.CellClick += dgvLoaiNghiPhep_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1045, 600);
            MinimumSize = new Size(980, 620);
            Controls.Add(dgvLoaiNghiPhep);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(chkHuongLuong);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenLoaiNghi);
            Controls.Add(txtMaLoaiNghi);
            Controls.Add(lblMoTa);
            Controls.Add(lblTenLoaiNghi);
            Controls.Add(lblMaLoaiNghi);
            Controls.Add(lblTieuDe);
            Name = "FrmLoaiNghiPhep";
            Text = "Loại nghỉ phép";
            Load += FrmLoaiNghiPhep_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLoaiNghiPhep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
