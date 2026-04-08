namespace HRM.Winform.Forms.ChamCong
{
    partial class FrmBangCongNgay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTieuDe;
        private Label lblMoTa;
        private Label lblNgay;
        private Label lblTong;
        private Panel pnlLoc;
        private DateTimePicker dtpNgay;
        private Button btnXem;
        private DataGridView dgvBangCongNgay;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMoTa = new Label();
            lblNgay = new Label();
            lblTong = new Label();
            pnlLoc = new Panel();
            dtpNgay = new DateTimePicker();
            btnXem = new Button();
            dgvBangCongNgay = new DataGridView();
            pnlLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongNgay).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 18);
            lblTieuDe.Text = "Bảng công ngày";

            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(28, 62);
            lblMoTa.Text = "Theo dõi chấm công theo từng ngày với tổng hợp số dòng và trạng thái hiện tại.";

            pnlLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLoc.Controls.Add(lblTong);
            pnlLoc.Controls.Add(btnXem);
            pnlLoc.Controls.Add(dtpNgay);
            pnlLoc.Controls.Add(lblNgay);
            pnlLoc.Location = new Point(24, 100);
            pnlLoc.Name = "pnlLoc";
            pnlLoc.Size = new Size(1132, 76);

            lblNgay.AutoSize = true;
            lblNgay.Location = new Point(24, 28);
            lblNgay.Text = "Ngày";

            dtpNgay.Format = DateTimePickerFormat.Short;
            dtpNgay.Location = new Point(74, 24);
            dtpNgay.Size = new Size(130, 27);

            btnXem.Location = new Point(220, 20);
            btnXem.Size = new Size(90, 34);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            lblTong.AutoSize = true;
            lblTong.Location = new Point(336, 27);
            lblTong.Text = "Tổng số dòng: 0";

            dgvBangCongNgay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBangCongNgay.Location = new Point(24, 200);
            dgvBangCongNgay.Size = new Size(1132, 478);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(236, 243, 250);
            ClientSize = new Size(1180, 710);
            Controls.Add(dgvBangCongNgay);
            Controls.Add(pnlLoc);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            MinimumSize = new Size(1080, 700);
            Name = "FrmBangCongNgay";
            Text = "Bảng công ngày";
            Load += FrmBangCongNgay_Load;
            pnlLoc.ResumeLayout(false);
            pnlLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongNgay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
