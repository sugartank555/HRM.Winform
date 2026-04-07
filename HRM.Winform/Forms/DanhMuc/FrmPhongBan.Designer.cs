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
            ((System.ComponentModel.ISupportInitialize)dgvPhongBan).BeginInit();
            SuspendLayout();
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(28, 18);
            lblTieuDe.Text = "DANH MỤC PHÒNG BAN";
            // 
            lblMaPhongBan.AutoSize = true;
            lblMaPhongBan.Location = new Point(31, 78);
            lblMaPhongBan.Text = "Mã phòng ban";
            // 
            lblTenPhongBan.AutoSize = true;
            lblTenPhongBan.Location = new Point(31, 118);
            lblTenPhongBan.Text = "Tên phòng ban";
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(31, 158);
            lblMoTa.Text = "Mô tả";
            // 
            txtMaPhongBan.Location = new Point(154, 75);
            txtMaPhongBan.Size = new Size(220, 27);
            // 
            txtTenPhongBan.Location = new Point(154, 115);
            txtTenPhongBan.Size = new Size(320, 27);
            // 
            txtMoTa.Location = new Point(154, 155);
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.Size = new Size(420, 27);
            // 
            btnThem.Location = new Point(610, 72);
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Size = new Size(95, 35);
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            btnSua.Location = new Point(711, 72);
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Size = new Size(95, 35);
            btnSua.Text = "Sửa";
            btnSua.Click += btnSua_Click;
            // 
            btnXoa.Location = new Point(812, 72);
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.Size = new Size(95, 35);
            btnXoa.Text = "Xóa";
            btnXoa.Click += btnXoa_Click;
            // 
            btnLamMoi.Location = new Point(913, 72);
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.Size = new Size(95, 35);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            dgvPhongBan.Location = new Point(31, 210);
            dgvPhongBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhongBan.Size = new Size(977, 360);
            dgvPhongBan.CellClick += dgvPhongBan_CellClick;
           
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1045, 600);
            MinimumSize = new Size(980, 620);
            Controls.Add(dgvPhongBan);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtMoTa);
            Controls.Add(txtTenPhongBan);
            Controls.Add(txtMaPhongBan);
            Controls.Add(lblMoTa);
            Controls.Add(lblTenPhongBan);
            Controls.Add(lblMaPhongBan);
            Controls.Add(lblTieuDe);
            Name = "FrmPhongBan";
            Text = "Phòng ban";
            Load += FrmPhongBan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhongBan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
