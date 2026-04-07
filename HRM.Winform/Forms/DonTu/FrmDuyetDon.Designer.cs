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
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Text = "DUYỆT ĐƠN";

            tabControl1.Controls.Add(tabNghiPhep);
            tabControl1.Controls.Add(tabTangCa);
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Location = new Point(24, 60);
            tabControl1.Size = new Size(1180, 570);

            tabNghiPhep.Text = "Đơn nghỉ phép";
            tabNghiPhep.Controls.Add(dgvNghiPhep);
            tabNghiPhep.Controls.Add(btnDuyetNghiPhep);
            tabNghiPhep.Controls.Add(btnTuChoiNghiPhep);

            dgvNghiPhep.Location = new Point(15, 15);
            dgvNghiPhep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNghiPhep.Size = new Size(1135, 455);

            btnDuyetNghiPhep.Location = new Point(835, 490);
            btnDuyetNghiPhep.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDuyetNghiPhep.Size = new Size(140, 36);
            btnDuyetNghiPhep.Text = "Duyệt";
            btnDuyetNghiPhep.Click += btnDuyetNghiPhep_Click;

            btnTuChoiNghiPhep.Location = new Point(995, 490);
            btnTuChoiNghiPhep.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTuChoiNghiPhep.Size = new Size(155, 36);
            btnTuChoiNghiPhep.Text = "Từ chối";
            btnTuChoiNghiPhep.Click += btnTuChoiNghiPhep_Click;

            tabTangCa.Text = "Đơn tăng ca";
            tabTangCa.Controls.Add(dgvTangCa);
            tabTangCa.Controls.Add(btnDuyetTangCa);
            tabTangCa.Controls.Add(btnTuChoiTangCa);

            dgvTangCa.Location = new Point(15, 15);
            dgvTangCa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTangCa.Size = new Size(1135, 455);

            btnDuyetTangCa.Location = new Point(835, 490);
            btnDuyetTangCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDuyetTangCa.Size = new Size(140, 36);
            btnDuyetTangCa.Text = "Duyệt";
            btnDuyetTangCa.Click += btnDuyetTangCa_Click;

            btnTuChoiTangCa.Location = new Point(995, 490);
            btnTuChoiTangCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTuChoiTangCa.Size = new Size(155, 36);
            btnTuChoiTangCa.Text = "Từ chối";
            btnTuChoiTangCa.Click += btnTuChoiTangCa_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1235, 650);
            MinimumSize = new Size(1160, 700);
            Controls.Add(tabControl1);
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
