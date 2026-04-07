using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.BaoCao
{
    public class FrmCanhBaoChamCongAI : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;
        private readonly Label lblTieuDe = new();
        private readonly Label lblMoTa = new();
        private readonly Label lblThang = new();
        private readonly Label lblNam = new();
        private readonly Label lblNhanVien = new();
        private readonly NumericUpDown nudThang = new();
        private readonly NumericUpDown nudNam = new();
        private readonly ComboBox cboNhanVien = new();
        private readonly Button btnPhanTich = new();
        private readonly Panel pnlSummaryHost = new();
        private readonly FlowLayoutPanel flpCards = new();
        private readonly Panel pnlSummaryText = new();
        private readonly Label lblSummaryTitle = new();
        private readonly Label lblSummaryBody = new();
        private readonly DataGridView dgvAlerts = new();
        private readonly Label lblTongCanhBao = new();

        public FrmCanhBaoChamCongAI()
        {
            InitializeComponent();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvAlerts);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Text = "Canh bao cham cong AI";
            BackColor = ThemeHelper.AppBackColor;
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1320, 860);
            MinimumSize = new Size(1180, 760);
            Padding = new Padding(24);

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblTieuDe.Location = new Point(24, 20);
            lblTieuDe.Text = "Canh bao cham cong AI";

            lblMoTa.AutoSize = false;
            lblMoTa.Font = new Font("Segoe UI", 10F);
            lblMoTa.ForeColor = ThemeHelper.TextSecondary;
            lblMoTa.Location = new Point(26, 60);
            lblMoTa.Size = new Size(760, 24);
            lblMoTa.Text = "Phat hien bat thuong theo GPS, di muon lap lai, OT bat thuong va hanh vi cong lech lich su.";

            lblThang.AutoSize = true;
            lblThang.Location = new Point(28, 108);
            lblThang.Text = "Thang";

            nudThang.Location = new Point(84, 104);
            nudThang.Minimum = 1;
            nudThang.Maximum = 12;
            nudThang.Size = new Size(74, 27);

            lblNam.AutoSize = true;
            lblNam.Location = new Point(182, 108);
            lblNam.Text = "Nam";

            nudNam.Location = new Point(226, 104);
            nudNam.Minimum = 2000;
            nudNam.Maximum = 3000;
            nudNam.Size = new Size(92, 27);

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(346, 108);
            lblNhanVien.Text = "Nhan vien";

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(420, 104);
            cboNhanVien.Size = new Size(320, 28);

            btnPhanTich.Location = new Point(760, 100);
            btnPhanTich.Size = new Size(148, 36);
            btnPhanTich.Text = "Phan tich AI";
            btnPhanTich.Click += btnPhanTich_Click;
            ThemeHelper.ApplyPrimaryButton(btnPhanTich);

            pnlSummaryHost.Location = new Point(24, 156);
            pnlSummaryHost.Size = new Size(1272, 230);
            pnlSummaryHost.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummaryHost.BackColor = Color.Transparent;

            flpCards.Location = new Point(0, 0);
            flpCards.Size = new Size(1272, 96);
            flpCards.WrapContents = false;
            flpCards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpCards.BackColor = Color.Transparent;

            pnlSummaryText.Location = new Point(0, 114);
            pnlSummaryText.Size = new Size(1272, 108);
            pnlSummaryText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummaryText.Padding = new Padding(20, 18, 20, 18);
            ThemeHelper.ApplyCard(pnlSummaryText);

            lblSummaryTitle.AutoSize = false;
            lblSummaryTitle.Dock = DockStyle.Top;
            lblSummaryTitle.Height = 28;
            lblSummaryTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = ThemeHelper.TextPrimary;
            lblSummaryTitle.Text = "Nhan xet tu dong";

            lblSummaryBody.AutoSize = false;
            lblSummaryBody.Dock = DockStyle.Fill;
            lblSummaryBody.Font = new Font("Segoe UI", 10F);
            lblSummaryBody.ForeColor = ThemeHelper.TextSecondary;
            lblSummaryBody.Text = "Bam 'Phan tich AI' de sinh canh bao va nhan xet tu dong.";

            pnlSummaryText.Controls.Add(lblSummaryBody);
            pnlSummaryText.Controls.Add(lblSummaryTitle);
            pnlSummaryHost.Controls.Add(pnlSummaryText);
            pnlSummaryHost.Controls.Add(flpCards);

            lblTongCanhBao.AutoSize = true;
            lblTongCanhBao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongCanhBao.ForeColor = ThemeHelper.TextPrimary;
            lblTongCanhBao.Location = new Point(28, 408);
            lblTongCanhBao.Text = "Tong canh bao: 0";

            dgvAlerts.Location = new Point(24, 440);
            dgvAlerts.Size = new Size(1272, 390);
            dgvAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(lblTieuDe);
            Controls.Add(lblMoTa);
            Controls.Add(lblThang);
            Controls.Add(nudThang);
            Controls.Add(lblNam);
            Controls.Add(nudNam);
            Controls.Add(lblNhanVien);
            Controls.Add(cboNhanVien);
            Controls.Add(btnPhanTich);
            Controls.Add(pnlSummaryHost);
            Controls.Add(lblTongCanhBao);
            Controls.Add(dgvAlerts);

            Load += FrmCanhBaoChamCongAI_Load;
            ResumeLayout(false);
        }

        private void FrmCanhBaoChamCongAI_Load(object? sender, EventArgs e)
        {
            ThemeHelper.ApplyInput(cboNhanVien);
            ThemeHelper.ApplyDataGrid(dgvAlerts);
            ConfigureGrid();
            dgvAlerts.CellFormatting += dgvAlerts_CellFormatting;
            TaiNhanVien();
            nudThang.Value = DateTime.Today.Month;
            nudNam.Value = DateTime.Today.Year;
            TaoCardsMacDinh();
            TaiPhanTich();
        }

        private void ConfigureGrid()
        {
            dgvAlerts.AutoGenerateColumns = false;
            dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlerts.Columns.Clear();
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Muc do", DataPropertyName = "MucDo", FillWeight = 70, MinimumWidth = 80 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loai canh bao", DataPropertyName = "LoaiCanhBao", FillWeight = 120, MinimumWidth = 120 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngay", DataPropertyName = "NgayLamViec", FillWeight = 75, MinimumWidth = 85, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ma NV", DataPropertyName = "MaNhanVien", FillWeight = 65, MinimumWidth = 75 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ho ten", DataPropertyName = "HoTen", FillWeight = 120, MinimumWidth = 130 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phong ban", DataPropertyName = "PhongBan", FillWeight = 100, MinimumWidth = 100 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chi tiet", DataPropertyName = "ChiTiet", FillWeight = 180, MinimumWidth = 180 });
            dgvAlerts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Goi y xu ly", DataPropertyName = "GoiYXuLy", FillWeight = 160, MinimumWidth = 160 });
        }

        private void TaiNhanVien()
        {
            using var db = new AppDbContext();

            var ds = db.NhanViens
                .AsNoTracking()
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.Id,
                    HienThi = x.MaNhanVien + " - " + x.HoTen
                })
                .ToList();

            ds.Insert(0, new { Id = 0, HienThi = "-- Tat ca nhan vien --" });

            cboNhanVien.DataSource = ds;
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "Id";
            cboNhanVien.SelectedIndex = 0;
        }

        private void btnPhanTich_Click(object? sender, EventArgs e)
        {
            TaiPhanTich();
        }

        private void TaiPhanTich()
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;
            int nhanVienId = 0;

            if (cboNhanVien.SelectedValue != null)
            {
                _ = int.TryParse(cboNhanVien.SelectedValue.ToString(), out nhanVienId);
            }

            var result = AttendanceAnomalyAnalyzer.Analyze(thang, nam, nhanVienId > 0 ? nhanVienId : null);

            _gridHelper?.ApplyData(result.Alerts);
            lblTongCanhBao.Text = $"Tong canh bao: {result.Summary.TongCanhBao}";
            lblSummaryBody.Text = result.Summary.NhanXetTuDong;

            RenderSummaryCards(result.Summary);
        }

        private void TaoCardsMacDinh()
        {
            RenderSummaryCards(new AttendanceAnomalySummary());
        }

        private void RenderSummaryCards(AttendanceAnomalySummary summary)
        {
            flpCards.SuspendLayout();
            flpCards.Controls.Clear();
            flpCards.Controls.Add(CreateInfoCard("Tong canh bao", summary.TongCanhBao.ToString(), "Tat ca bat thuong duoc phat hien trong ky.", ThemeHelper.PrimaryColor));
            flpCards.Controls.Add(CreateInfoCard("Muc do cao", summary.MucDoCao.ToString(), "Can uu tien xu ly som.", ThemeHelper.DangerColor));
            flpCards.Controls.Add(CreateInfoCard("Di muon lap lai", summary.DiMuonLapLai.ToString(), "Nhan vien co xu huong di muon nhieu lan.", ThemeHelper.WarmAccent));
            flpCards.Controls.Add(CreateInfoCard("OT/GPS can kiem tra", (summary.OtBatThuong + summary.XacThucCanKiemTra).ToString(), "OT cao hoac GPS gan nguong can doi chieu.", ThemeHelper.SecondaryAccent));
            flpCards.ResumeLayout();
        }

        private Control CreateInfoCard(string title, string value, string description, Color accent)
        {
            var panel = new Panel
            {
                Width = 300,
                Height = 96,
                Margin = new Padding(0, 0, 18, 0),
                Padding = new Padding(18, 16, 18, 14)
            };
            ThemeHelper.ApplyCard(panel);

            panel.Paint += (_, e) =>
            {
                using var brush = new SolidBrush(accent);
                e.Graphics.FillRectangle(brush, 0, 0, 6, panel.Height);
            };

            var lblTitle = new Label
            {
                AutoSize = false,
                Location = new Point(20, 16),
                Size = new Size(250, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextSecondary,
                Text = title
            };

            var lblValue = new Label
            {
                AutoSize = false,
                Location = new Point(20, 40),
                Size = new Size(120, 28),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextPrimary,
                Text = value
            };

            var lblDesc = new Label
            {
                AutoSize = false,
                Location = new Point(140, 38),
                Size = new Size(136, 36),
                Font = new Font("Segoe UI", 8.8F),
                ForeColor = ThemeHelper.TextSecondary,
                Text = description
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblDesc);
            return panel;
        }

        private void dgvAlerts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = dgvAlerts.Rows[e.RowIndex];
            string severity = row.Cells[0].Value?.ToString() ?? string.Empty;

            Color backColor;
            Color foreColor;
            Color selectionColor;

            switch (severity)
            {
                case "Cao":
                    backColor = Color.FromArgb(254, 226, 226);
                    foreColor = Color.FromArgb(153, 27, 27);
                    selectionColor = Color.FromArgb(252, 165, 165);
                    break;
                case "TrungBinh":
                    backColor = Color.FromArgb(255, 237, 213);
                    foreColor = Color.FromArgb(154, 52, 18);
                    selectionColor = Color.FromArgb(253, 186, 116);
                    break;
                case "Thap":
                    backColor = Color.FromArgb(254, 249, 195);
                    foreColor = Color.FromArgb(133, 77, 14);
                    selectionColor = Color.FromArgb(253, 224, 71);
                    break;
                default:
                    backColor = Color.White;
                    foreColor = ThemeHelper.TextPrimary;
                    selectionColor = Color.FromArgb(224, 236, 255);
                    break;
            }

            row.DefaultCellStyle.BackColor = backColor;
            row.DefaultCellStyle.ForeColor = foreColor;
            row.DefaultCellStyle.SelectionBackColor = selectionColor;
            row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 31, 32);
        }
    }
}
