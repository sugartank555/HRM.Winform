namespace HRM.Winform.Forms.CaNhan
{
    partial class FrmCongCaNhan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Panel pnlFilter;
        private Label lblTitle;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnLoc;
        private Panel pnlSummary;
        private Label lblTongNgayCongTitle;
        private Label lblTongNgayCong;
        private Label lblTongGioLamTitle;
        private Label lblTongGioLam;
        private Label lblDiMuonTitle;
        private Label lblDiMuon;
        private Label lblTangCaTitle;
        private Label lblTangCa;
        private Panel pnlGrid;
        private DataGridView dgvCong;

        private void InitializeComponent()
        {
            pnlFilter = new Panel();
            btnLoc = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            lblTuNgay = new Label();
            lblTitle = new Label();
            pnlSummary = new Panel();
            lblTangCa = new Label();
            lblTangCaTitle = new Label();
            lblDiMuon = new Label();
            lblDiMuonTitle = new Label();
            lblTongGioLam = new Label();
            lblTongGioLamTitle = new Label();
            lblTongNgayCong = new Label();
            lblTongNgayCongTitle = new Label();
            pnlGrid = new Panel();
            dgvCong = new DataGridView();
            pnlFilter.SuspendLayout();
            pnlSummary.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCong).BeginInit();
            SuspendLayout();
            pnlFilter.Controls.Add(btnLoc);
            pnlFilter.Controls.Add(dtpDenNgay);
            pnlFilter.Controls.Add(dtpTuNgay);
            pnlFilter.Controls.Add(lblDenNgay);
            pnlFilter.Controls.Add(lblTuNgay);
            pnlFilter.Controls.Add(lblTitle);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Padding = new Padding(24, 20, 24, 16);
            pnlFilter.Size = new Size(1184, 106);
            btnLoc.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoc.Location = new Point(745, 49);
            btnLoc.Size = new Size(124, 36);
            btnLoc.Text = "Loc du lieu";
            btnLoc.Click += btnLoc_Click;
            dtpDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(514, 54);
            dtpDenNgay.Size = new Size(188, 27);
            dtpTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(272, 54);
            dtpTuNgay.Size = new Size(188, 27);
            lblDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(514, 28);
            lblDenNgay.Text = "Den ngay";
            lblTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(272, 28);
            lblTuNgay.Text = "Tu ngay";
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 28);
            lblTitle.Text = "Cong cua toi";
            pnlSummary.Controls.Add(lblTangCa);
            pnlSummary.Controls.Add(lblTangCaTitle);
            pnlSummary.Controls.Add(lblDiMuon);
            pnlSummary.Controls.Add(lblDiMuonTitle);
            pnlSummary.Controls.Add(lblTongGioLam);
            pnlSummary.Controls.Add(lblTongGioLamTitle);
            pnlSummary.Controls.Add(lblTongNgayCong);
            pnlSummary.Controls.Add(lblTongNgayCongTitle);
            pnlSummary.Dock = DockStyle.Top;
            pnlSummary.Padding = new Padding(24, 18, 24, 18);
            pnlSummary.Location = new Point(0, 106);
            pnlSummary.Size = new Size(1184, 92);
            lblTangCa.AutoSize = true;
            lblTangCa.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTangCa.Location = new Point(903, 33);
            lblTangCa.Text = "0 h";
            lblTangCaTitle.AutoSize = true;
            lblTangCaTitle.Location = new Point(903, 13);
            lblTangCaTitle.Text = "Tang ca da duyet";
            lblDiMuon.AutoSize = true;
            lblDiMuon.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDiMuon.Location = new Point(645, 33);
            lblDiMuon.Text = "0 p";
            lblDiMuonTitle.AutoSize = true;
            lblDiMuonTitle.Location = new Point(645, 13);
            lblDiMuonTitle.Text = "Di muon";
            lblTongGioLam.AutoSize = true;
            lblTongGioLam.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongGioLam.Location = new Point(386, 33);
            lblTongGioLam.Text = "0 h";
            lblTongGioLamTitle.AutoSize = true;
            lblTongGioLamTitle.Location = new Point(386, 13);
            lblTongGioLamTitle.Text = "Tong gio lam";
            lblTongNgayCong.AutoSize = true;
            lblTongNgayCong.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTongNgayCong.Location = new Point(131, 33);
            lblTongNgayCong.Text = "0";
            lblTongNgayCongTitle.AutoSize = true;
            lblTongNgayCongTitle.Location = new Point(131, 13);
            lblTongNgayCongTitle.Text = "Tong ngay cong";
            pnlGrid.Controls.Add(dgvCong);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Padding = new Padding(24, 18, 24, 24);
            pnlGrid.Location = new Point(0, 198);
            pnlGrid.Size = new Size(1184, 563);
            dgvCong.Dock = DockStyle.Fill;
            dgvCong.Location = new Point(24, 18);
            dgvCong.Size = new Size(1136, 521);
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(pnlGrid);
            Controls.Add(pnlSummary);
            Controls.Add(pnlFilter);
            MinimumSize = new Size(960, 640);
            Name = "FrmCongCaNhan";
            Text = "Cong cua toi";
            Load += FrmCongCaNhan_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCong).EndInit();
            ResumeLayout(false);
        }
    }
}
