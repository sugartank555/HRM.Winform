namespace HRM.Winform.Forms.DonTu
{
    partial class FrmDuyetDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblMoTa;
        private TabControl tabControl1;
        private TabPage tabNghiPhep;
        private TabPage tabTangCa;
        private DataGridView dgvNghiPhep;
        private DataGridView dgvTangCa;
        private Button btnDuyetNghiPhep;
        private Button btnTuChoiNghiPhep;
        private Button btnDuyetTangCa;
        private Button btnTuChoiTangCa;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            tabControl1 = new TabControl();
            tabNghiPhep = new TabPage();
            tabTangCa = new TabPage();
            dgvNghiPhep = new DataGridView();
            dgvTangCa = new DataGridView();
            btnDuyetNghiPhep = new Button();
            btnTuChoiNghiPhep = new Button();
            btnDuyetTangCa = new Button();
            btnTuChoiTangCa = new Button();
            tabControl1.SuspendLayout();
            tabNghiPhep.SuspendLayout();
            tabTangCa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNghiPhep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTangCa).BeginInit();
            SuspendLayout();
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Duyệt đơn";
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Kiểm tra và duyệt đơn nghỉ phép hoặc tăng ca theo từng nhóm nghiệp vụ.";
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabNghiPhep);
            tabControl1.Controls.Add(tabTangCa);
            tabControl1.Location = new Point(24, 102);
            tabControl1.Size = new Size(1180, 588);
            tabNghiPhep.Text = "Đơn nghỉ phép";
            tabNghiPhep.Controls.Add(dgvNghiPhep);
            tabNghiPhep.Controls.Add(btnDuyetNghiPhep);
            tabNghiPhep.Controls.Add(btnTuChoiNghiPhep);
            dgvNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNghiPhep.Location = new Point(16, 16);
            dgvNghiPhep.Size = new Size(1128, 468);
            btnDuyetNghiPhep.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDuyetNghiPhep.Location = new Point(836, 504);
            btnDuyetNghiPhep.Size = new Size(144, 36);
            btnDuyetNghiPhep.Text = "Duyệt";
            btnDuyetNghiPhep.Click += btnDuyetNghiPhep_Click;
            btnTuChoiNghiPhep.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTuChoiNghiPhep.Location = new Point(994, 504);
            btnTuChoiNghiPhep.Size = new Size(150, 36);
            btnTuChoiNghiPhep.Text = "Từ chối";
            btnTuChoiNghiPhep.Click += btnTuChoiNghiPhep_Click;
            tabTangCa.Text = "Đơn tăng ca";
            tabTangCa.Controls.Add(dgvTangCa);
            tabTangCa.Controls.Add(btnDuyetTangCa);
            tabTangCa.Controls.Add(btnTuChoiTangCa);
            dgvTangCa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTangCa.Location = new Point(16, 16);
            dgvTangCa.Size = new Size(1128, 468);
            btnDuyetTangCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDuyetTangCa.Location = new Point(836, 504);
            btnDuyetTangCa.Size = new Size(144, 36);
            btnDuyetTangCa.Text = "Duyệt";
            btnDuyetTangCa.Click += btnDuyetTangCa_Click;
            btnTuChoiTangCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTuChoiTangCa.Location = new Point(994, 504);
            btnTuChoiTangCa.Size = new Size(150, 36);
            btnTuChoiTangCa.Text = "Từ chối";
            btnTuChoiTangCa.Click += btnTuChoiTangCa_Click;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1235, 720);
            MinimumSize = new Size(1160, 700);
            Controls.Add(tabControl1);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            Name = "FrmDuyetDon";
            Text = "Duyệt đơn";
            Load += FrmDuyetDon_Load;
            tabControl1.ResumeLayout(false);
            tabNghiPhep.ResumeLayout(false);
            tabTangCa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNghiPhep).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTangCa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
