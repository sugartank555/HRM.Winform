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
        private Label lblNgay;
        private Label lblTong;
        private DateTimePicker dtpNgay;
        private Button btnXem;
        private DataGridView dgvBangCongNgay;

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblNgay = new Label();
            lblTong = new Label();
            dtpNgay = new DateTimePicker();
            btnXem = new Button();
            dgvBangCongNgay = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBangCongNgay).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 16);
            lblTieuDe.Text = "BẢNG CÔNG NGÀY";

            lblNgay.AutoSize = true;
            lblNgay.Location = new Point(28, 67);
            lblNgay.Text = "Ngày";

            dtpNgay.Format = DateTimePickerFormat.Short;
            dtpNgay.Location = new Point(80, 64);
            dtpNgay.Size = new Size(130, 27);

            btnXem.Location = new Point(230, 61);
            btnXem.Size = new Size(90, 32);
            btnXem.Text = "Xem";
            btnXem.Click += btnXem_Click;

            lblTong.AutoSize = true;
            lblTong.Location = new Point(350, 68);
            lblTong.Text = "Tổng số dòng: 0";

            dgvBangCongNgay.Location = new Point(28, 115);
            dgvBangCongNgay.Size = new Size(1120, 470);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 620);
            Controls.Add(dgvBangCongNgay);
            Controls.Add(lblTong);
            Controls.Add(btnXem);
            Controls.Add(dtpNgay);
            Controls.Add(lblNgay);
            Controls.Add(lblTieuDe);
            Name = "FrmBangCongNgay";
            Text = "Bảng công ngày";
            Load += FrmBangCongNgay_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBangCongNgay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}