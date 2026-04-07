namespace HRM.Winform.Forms.CaNhan
{
    partial class FrmLichLamViecCaNhan
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

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXem;
        private Button btnYeuCauDoiCa;
        private Label lblCaHomNayTitle;
        private Label lblCaHomNay;
        private Label lblCaTuanNayTitle;
        private Label lblCaTuanNay;
        private Label lblCaDacBietTitle;
        private Label lblCaDacBiet;
        private Panel pnlGrid;
        private DataGridView dgvLich;

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblCaDacBiet = new Label();
            lblCaDacBietTitle = new Label();
            lblCaTuanNay = new Label();
            lblCaTuanNayTitle = new Label();
            lblCaHomNay = new Label();
            lblCaHomNayTitle = new Label();
            btnYeuCauDoiCa = new Button();
            btnXem = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            lblTuNgay = new Label();
            lblTitle = new Label();
            pnlGrid = new Panel();
            dgvLich = new DataGridView();
            pnlTop.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLich).BeginInit();
            SuspendLayout();
            pnlTop.Controls.Add(lblCaDacBiet);
            pnlTop.Controls.Add(lblCaDacBietTitle);
            pnlTop.Controls.Add(lblCaTuanNay);
            pnlTop.Controls.Add(lblCaTuanNayTitle);
            pnlTop.Controls.Add(lblCaHomNay);
            pnlTop.Controls.Add(lblCaHomNayTitle);
            pnlTop.Controls.Add(btnYeuCauDoiCa);
            pnlTop.Controls.Add(btnXem);
            pnlTop.Controls.Add(dtpDenNgay);
            pnlTop.Controls.Add(dtpTuNgay);
            pnlTop.Controls.Add(lblDenNgay);
            pnlTop.Controls.Add(lblTuNgay);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Padding = new Padding(24, 20, 24, 16);
            pnlTop.Size = new Size(1184, 170);
            lblCaDacBiet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaDacBiet.AutoSize = true;
            lblCaDacBiet.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCaDacBiet.Location = new Point(842, 97);
            lblCaDacBiet.Text = "0";
            lblCaDacBietTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaDacBietTitle.AutoSize = true;
            lblCaDacBietTitle.Location = new Point(842, 72);
            lblCaDacBietTitle.Text = "Ca dac biet";
            lblCaTuanNay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaTuanNay.AutoSize = true;
            lblCaTuanNay.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCaTuanNay.Location = new Point(679, 97);
            lblCaTuanNay.Text = "0";
            lblCaTuanNayTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaTuanNayTitle.AutoSize = true;
            lblCaTuanNayTitle.Location = new Point(679, 72);
            lblCaTuanNayTitle.Text = "Ca 7 ngay";
            lblCaHomNay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaHomNay.AutoSize = true;
            lblCaHomNay.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCaHomNay.Location = new Point(518, 97);
            lblCaHomNay.Text = "0";
            lblCaHomNayTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCaHomNayTitle.AutoSize = true;
            lblCaHomNayTitle.Location = new Point(518, 72);
            lblCaHomNayTitle.Text = "Ca hom nay";
            btnYeuCauDoiCa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYeuCauDoiCa.Location = new Point(1028, 31);
            btnYeuCauDoiCa.Size = new Size(129, 37);
            btnYeuCauDoiCa.Text = "Yeu cau doi ca";
            btnYeuCauDoiCa.Click += btnYeuCauDoiCa_Click;
            btnXem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXem.Location = new Point(879, 31);
            btnXem.Size = new Size(120, 37);
            btnXem.Text = "Xem lich";
            btnXem.Click += btnXem_Click;
            dtpDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(648, 37);
            dtpDenNgay.Size = new Size(184, 27);
            dtpTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(431, 37);
            dtpTuNgay.Size = new Size(184, 27);
            lblDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(648, 14);
            lblDenNgay.Text = "Den ngay";
            lblTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(431, 14);
            lblTuNgay.Text = "Tu ngay";
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 23);
            lblTitle.Text = "Lich lam viec toi";
            pnlGrid.Controls.Add(dgvLich);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Padding = new Padding(24, 18, 24, 24);
            pnlGrid.Location = new Point(0, 170);
            pnlGrid.Size = new Size(1184, 591);
            dgvLich.Dock = DockStyle.Fill;
            dgvLich.Location = new Point(24, 18);
            dgvLich.Size = new Size(1136, 549);
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(pnlGrid);
            Controls.Add(pnlTop);
            MinimumSize = new Size(980, 660);
            Name = "FrmLichLamViecCaNhan";
            Text = "Lich lam viec cua toi";
            Load += FrmLichLamViecCaNhan_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLich).EndInit();
            ResumeLayout(false);
        }
    }
}
