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
        private Label lblMoTaForm;
        private Panel pnlThongTin;
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
            lblMoTaForm = new Label();
            pnlThongTin = new Panel();
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
            pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiNghiPhep).BeginInit();
            SuspendLayout();
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Loại nghỉ phép";
            lblMoTaForm.AutoSize = true;
            lblMoTaForm.Location = new Point(28, 62);
            lblMoTaForm.Text = "Thiết lập các loại nghỉ áp dụng trong doanh nghiệp và quy định hưởng lương.";
            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(chkHuongLuong);
            pnlThongTin.Controls.Add(txtMoTa);
            pnlThongTin.Controls.Add(txtTenLoaiNghi);
            pnlThongTin.Controls.Add(txtMaLoaiNghi);
            pnlThongTin.Controls.Add(lblMoTa);
            pnlThongTin.Controls.Add(lblTenLoaiNghi);
            pnlThongTin.Controls.Add(lblMaLoaiNghi);
            pnlThongTin.Location = new Point(24, 100);
            pnlThongTin.Size = new Size(1000, 132);
            lblMaLoaiNghi.AutoSize = true;
            lblMaLoaiNghi.Location = new Point(24, 28);
            lblMaLoaiNghi.Text = "Mã loại nghỉ";
            lblTenLoaiNghi.AutoSize = true;
            lblTenLoaiNghi.Location = new Point(24, 68);
            lblTenLoaiNghi.Text = "Tên loại nghỉ";
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(420, 28);
            lblMoTa.Text = "Mô tả";
            txtMaLoaiNghi.Location = new Point(126, 24);
            txtMaLoaiNghi.Size = new Size(220, 27);
            txtTenLoaiNghi.Location = new Point(126, 64);
            txtTenLoaiNghi.Size = new Size(220, 27);
            txtMoTa.Location = new Point(474, 24);
            txtMoTa.Size = new Size(270, 27);
            chkHuongLuong.AutoSize = true;
            chkHuongLuong.Location = new Point(474, 66);
            chkHuongLuong.Text = "Hưởng lương";
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
            dgvLoaiNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoaiNghiPhep.Location = new Point(24, 256);
            dgvLoaiNghiPhep.Size = new Size(1000, 414);
            dgvLoaiNghiPhep.CellClick += dgvLoaiNghiPhep_CellClick;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1050, 700);
            MinimumSize = new Size(980, 680);
            Controls.Add(dgvLoaiNghiPhep);
            Controls.Add(pnlThongTin);
            Controls.Add(lblMoTaForm);
            Controls.Add(lblTieuDe);
            Name = "FrmLoaiNghiPhep";
            Text = "Loại nghỉ phép";
            Load += FrmLoaiNghiPhep_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiNghiPhep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
