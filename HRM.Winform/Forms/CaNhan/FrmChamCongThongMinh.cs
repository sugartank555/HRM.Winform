using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.CaNhan
{
    public partial class FrmChamCongThongMinh : Form
    {
        private readonly Panel[] _summaryPanels;
        private DataGridSearchPaginationHelper? _historyGridHelper;

        public FrmChamCongThongMinh()
        {
            InitializeComponent();
            _summaryPanels = [pnlStatus, pnlShift, pnlReminder, pnlStats];
            _historyGridHelper ??= new DataGridSearchPaginationHelper(dgvHistory);
        }

        private void FrmChamCongThongMinh_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            ApplyResponsiveLayout();
            TaiTongQuan();
            TaiLichSuGanDay();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            pnlTop.BackColor = ThemeHelper.CardBackColor;
            pnlHistory.BackColor = ThemeHelper.CardBackColor;
            pnlTop.Padding = new Padding(28, 22, 28, 18);
            pnlHistory.Padding = new Padding(28, 22, 28, 28);
            pnlMethods.Padding = new Padding(0);
            pnlMethods.BackColor = Color.Transparent;
            tlpSummary.BackColor = Color.Transparent;
            tlpSummary.Padding = new Padding(28, 20, 28, 0);

            ConfigureActionButton(btnKhuonMat, ThemeHelper.PrimaryColor);
            ConfigureActionButton(btnQr, ThemeHelper.SecondaryAccent);
            ConfigureActionButton(btnGps, ThemeHelper.WarmAccent);
            ConfigureActionButton(btnCheckOut, ThemeHelper.DangerColor);
            ConfigureActionButton(btnLamMoi, Color.White, ThemeHelper.PrimaryColor, true);

            foreach (Panel panel in _summaryPanels)
            {
                panel.BackColor = ThemeHelper.CardBackColor;
                panel.Margin = new Padding(0, 0, 18, 18);
                panel.Padding = new Padding(22, 20, 22, 18);
                panel.Paint -= SummaryCard_Paint;
                panel.Paint += SummaryCard_Paint;
            }

            ConfigureSummaryCard(pnlStatus, lblStatusTitle, lblStatusValue, lblStatusDetail, ThemeHelper.PrimaryColor);
            ConfigureSummaryCard(pnlShift, lblShiftTitle, lblShiftValue, lblShiftDetail, Color.FromArgb(14, 165, 233));
            ConfigureSummaryCard(pnlReminder, lblReminderTitle, lblReminderValue, lblReminderDetail, ThemeHelper.SecondaryAccent);
            ConfigureSummaryCard(pnlStats, lblStatsTitle, lblStatsValue, lblStatsDetail, ThemeHelper.WarmAccent);

            ThemeHelper.ApplyDataGrid(dgvHistory);
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngay", DataPropertyName = "NgayLamViec", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ca", DataPropertyName = "TenCa", Width = 160 });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check in", DataPropertyName = "GioCheckIn", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check out", DataPropertyName = "GioCheckOut", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Gio lam", DataPropertyName = "SoGioLam", Width = 90 });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trang thai", DataPropertyName = "TrangThai", Width = 120 });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chu", DataPropertyName = "GhiChu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void ConfigureActionButton(Button button, Color backColor, Color? foreColor = null, bool bordered = false)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor ?? Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = bordered ? 1 : 0;
            button.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void ConfigureSummaryCard(Panel panel, Label title, Label value, Label detail, Color accentColor)
        {
            panel.Tag = accentColor;

            title.Dock = DockStyle.None;
            title.AutoSize = false;
            title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            title.ForeColor = ThemeHelper.TextSecondary;

            value.Dock = DockStyle.None;
            value.AutoSize = false;
            value.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
            value.ForeColor = ThemeHelper.TextPrimary;

            detail.Dock = DockStyle.None;
            detail.AutoSize = false;
            detail.Font = new Font("Segoe UI", 9.5F);
            detail.ForeColor = ThemeHelper.TextSecondary;

            panel.Resize -= SummaryCard_Resize;
            panel.Resize += SummaryCard_Resize;
            LayoutSummaryCard(panel, title, value, detail);
        }

        private void SummaryCard_Resize(object? sender, EventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            Label? title = null;
            Label? value = null;
            Label? detail = null;

            foreach (Control control in panel.Controls)
            {
                if (control == lblStatusTitle || control == lblShiftTitle || control == lblReminderTitle || control == lblStatsTitle)
                {
                    title = (Label)control;
                }
                else if (control == lblStatusValue || control == lblShiftValue || control == lblReminderValue || control == lblStatsValue)
                {
                    value = (Label)control;
                }
                else if (control == lblStatusDetail || control == lblShiftDetail || control == lblReminderDetail || control == lblStatsDetail)
                {
                    detail = (Label)control;
                }
            }

            if (title != null && value != null && detail != null)
            {
                LayoutSummaryCard(panel, title, value, detail);
            }
        }

        private static void LayoutSummaryCard(Panel panel, Label title, Label value, Label detail)
        {
            const int left = 22;
            int width = Math.Max(120, panel.ClientSize.Width - (left * 2));

            title.SetBounds(left, 18, width, 22);
            value.SetBounds(left, 48, width, 42);
            detail.SetBounds(left, 96, width, Math.Max(24, panel.ClientSize.Height - 118));
        }

        private static void SummaryCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var bounds = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            using var borderPen = new Pen(Color.FromArgb(226, 232, 240));
            using var accentBrush = new SolidBrush(panel.Tag is Color accent ? accent : Color.FromArgb(37, 99, 235));

            e.Graphics.FillRectangle(accentBrush, 0, 0, 6, panel.Height);
            e.Graphics.DrawRectangle(borderPen, bounds);
        }

        private void ApplyResponsiveLayout()
        {
            pnlMethods.Width = Math.Max(420, pnlTop.ClientSize.Width - 220);
            pnlMethods.Height = pnlMethods.PreferredSize.Height;

            lblLastSync.Left = pnlTop.ClientSize.Width - lblLastSync.PreferredWidth - 28;
            lblLastSync.Top = pnlMethods.Bottom + 10;

            pnlTop.Height = Math.Max(178, lblLastSync.Bottom + 18);

            bool singleColumn = ClientSize.Width < 1180;
            RebuildSummaryGrid(singleColumn);
        }

        private void RebuildSummaryGrid(bool singleColumn)
        {
            tlpSummary.SuspendLayout();
            tlpSummary.Controls.Clear();
            tlpSummary.ColumnStyles.Clear();
            tlpSummary.RowStyles.Clear();

            if (singleColumn)
            {
                tlpSummary.ColumnCount = 1;
                tlpSummary.RowCount = 4;
                tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                for (int i = 0; i < 4; i++)
                {
                    tlpSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
                }

                tlpSummary.Controls.Add(pnlStatus, 0, 0);
                tlpSummary.Controls.Add(pnlShift, 0, 1);
                tlpSummary.Controls.Add(pnlReminder, 0, 2);
                tlpSummary.Controls.Add(pnlStats, 0, 3);
                tlpSummary.Height = 628;
            }
            else
            {
                tlpSummary.ColumnCount = 2;
                tlpSummary.RowCount = 2;
                tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlpSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
                tlpSummary.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));

                tlpSummary.Controls.Add(pnlStatus, 0, 0);
                tlpSummary.Controls.Add(pnlShift, 1, 0);
                tlpSummary.Controls.Add(pnlReminder, 0, 1);
                tlpSummary.Controls.Add(pnlStats, 1, 1);
                tlpSummary.Height = 332;
            }

            tlpSummary.ResumeLayout();
        }

        private void TaiTongQuan()
        {
            using var db = new AppDbContext();

            var homNay = DateTime.Today;
            var dauThang = new DateTime(homNay.Year, homNay.Month, 1);
            var cuoiThang = dauThang.AddMonths(1).AddDays(-1);

            var chamCongHomNay = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec == homNay);

            var caHomNay = db.PhanCaNhanViens
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec == homNay);

            var dsThang = db.ChamCongs
                .AsNoTracking()
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec >= dauThang && x.NgayLamViec <= cuoiThang)
                .ToList();

            var tongTangCa = db.DonTangCas
                .AsNoTracking()
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId && x.TrangThai == "DaDuyet" && x.NgayLam >= dauThang && x.NgayLam <= cuoiThang)
                .Sum(x => (double?)x.TongSoGio) ?? 0;

            lblStatusValue.Text = chamCongHomNay == null ? "Chua check in" : chamCongHomNay.TrangThai;
            lblStatusDetail.Text = chamCongHomNay == null
                ? "Hom nay ban chua co ban ghi cham cong."
                : $"Check in: {FormatDateTime(chamCongHomNay.GioCheckIn)}  |  Check out: {FormatDateTime(chamCongHomNay.GioCheckOut)}";

            lblShiftValue.Text = caHomNay?.CaLamViec?.TenCa ?? "Chua phan ca";
            lblShiftDetail.Text = caHomNay?.CaLamViec == null
                ? "Lien he quan ly neu hom nay ban chua co lich lam."
                : $"Khung gio: {caHomNay.CaLamViec.GioBatDau:hh\\:mm} - {caHomNay.CaLamViec.GioKetThuc:hh\\:mm}";

            lblReminderValue.Text = GetReminder(chamCongHomNay, caHomNay?.CaLamViec?.GioBatDau);
            lblReminderDetail.Text = "Nhac check-in/check-out, canh bao quen cham cong va goi y xu ly.";

            lblStatsValue.Text = $"{dsThang.Sum(x => x.SoGioLam):N1} gio";
            lblStatsDetail.Text = $"Di muon: {dsThang.Sum(x => x.SoPhutDiMuon)} phut  |  Tang ca da duyet: {tongTangCa:N1} gio";

            lblLastSync.Text = $"Cap nhat luc {DateTime.Now:HH:mm:ss dd/MM/yyyy}";
        }

        private static string FormatDateTime(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("HH:mm dd/MM") : "--";
        }

        private string GetReminder(Models.ChamCong? chamCong, TimeSpan? gioBatDau)
        {
            if (chamCong == null)
            {
                return gioBatDau.HasValue && DateTime.Now.TimeOfDay > gioBatDau.Value
                    ? "Ban co the da quen check in hom nay."
                    : "Ban san sang check in cho ca lam.";
            }

            if (chamCong.GioCheckIn.HasValue && !chamCong.GioCheckOut.HasValue)
            {
                return "Ban da check in. Nho check out khi ket thuc ca.";
            }

            if (chamCong.GioCheckIn.HasValue && chamCong.GioCheckOut.HasValue)
            {
                return "Ban da hoan tat cham cong trong ngay.";
            }

            return "Kiem tra lai ban ghi hom nay de tranh thieu cong.";
        }

        private void TaiLichSuGanDay()
        {
            using var db = new AppDbContext();

            var ds = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId)
                .OrderByDescending(x => x.NgayLamViec)
                .Take(10)
                .Select(x => new
                {
                    x.NgayLamViec,
                    TenCa = x.CaLamViec != null ? x.CaLamViec.TenCa : "",
                    x.GioCheckIn,
                    x.GioCheckOut,
                    x.SoGioLam,
                    x.TrangThai,
                    x.GhiChu
                })
                .ToList();

            _historyGridHelper?.ApplyData(ds);
        }

        private void btnKhuonMat_Click(object sender, EventArgs e)
        {
            if (!XacThucKhuonMat()) return;
            ThucHienCheckIn("KhuonMat");
        }

        private void btnQr_Click(object sender, EventArgs e)
        {
            if (!XacThucQr()) return;
            ThucHienCheckIn("QR");
        }

        private void btnGps_Click(object sender, EventArgs e)
        {
            if (!XacThucGpsThucTe(out string? gpsAudit)) return;
            ThucHienCheckIn("GPS", gpsAudit);
        }

        private bool XacThucThongMinh(string phuongThuc)
        {
            string noiDung = phuongThuc switch
            {
                "KhuonMat" => "Chuc nang cham cong khuon mat chua duoc noi camera va bo nhan dien thuc te, nen he thong se khong cho check in bang mot nut bam.",
                "QR" => "Chuc nang check in QR chua duoc noi bo quet/ma QR dong, nen he thong se khong ghi cong neu chua quet ma thuc te.",
                "GPS" => "Chuc nang check in GPS chua duoc lay toa do thiet bi va kiem tra vi tri hop le, nen he thong se khong ghi cong neu chi bam nut.",
                _ => "Phuong thuc xac thuc nay chua san sang."
            };

            MessageBox.Show(
                $"{noiDung}\n\nCan tich hop thiet bi hoac dich vu xac thuc that truoc khi cho phep check in.",
                "Chua xac thuc du dieu kien",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private bool XacThucGpsThucTe(out string? gpsAudit)
        {
            gpsAudit = null;

            using var frm = new FrmXacThucGps();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.GpsResult == null)
            {
                return false;
            }

            var gps = frm.GpsResult;
            var config = GpsCheckInStore.LoadOfficeConfig();

            if (config == null)
            {
                var rs = MessageBox.Show(
                    $"Chua co vi tri cong ty de doi chieu.\n\nToa do hien tai:\n{gps.Latitude:F6}, {gps.Longitude:F6}\nSai so uoc tinh: {gps.AccuracyMeters:N0} m\n\nBan co muon dung vi tri nay lam vi tri cong ty mau khong?",
                    "Thiet lap GPS cong ty",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (rs != DialogResult.Yes)
                {
                    GhiNhatKyChamCong("CheckIn", "GPS", "ThatBai", "Chua co cau hinh GPS cong ty.");
                    MessageBox.Show("Chua co cau hinh GPS cong ty, nen he thong chua the check in bang GPS.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                config = new OfficeGpsConfig
                {
                    Latitude = gps.Latitude,
                    Longitude = gps.Longitude,
                    AllowedRadiusMeters = 150
                };
                GpsCheckInStore.SaveOfficeConfig(config);
            }

            double distance = GpsCheckInStore.ComputeDistanceMeters(
                gps.Latitude,
                gps.Longitude,
                config.Latitude,
                config.Longitude);

            if (distance > config.AllowedRadiusMeters)
            {
                GhiNhatKyChamCong("CheckIn", "GPS", "ThatBai", $"Khoang cach {distance:N0}m vuot ban kinh {config.AllowedRadiusMeters:N0}m.");
                MessageBox.Show(
                    $"Ban dang ngoai pham vi check in GPS.\n\nKhoang cach den vi tri cong ty: {distance:N0} m\nBan kinh cho phep: {config.AllowedRadiusMeters:N0} m",
                    "GPS khong hop le",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            gpsAudit = $"GPS {gps.Latitude:F6},{gps.Longitude:F6} | SaiSo {gps.AccuracyMeters:N0}m | CachVanPhong {distance:N0}m";
            GhiNhatKyChamCong("CheckIn", "GPS", "ThanhCong", gpsAudit);
            MessageBox.Show(
                $"Xac thuc GPS thanh cong.\n\nKhoang cach den vi tri cong ty: {distance:N0} m\nSai so vi tri: {gps.AccuracyMeters:N0} m",
                "GPS hop le",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return true;
        }

        private bool XacThucKhuonMat()
        {
            var profile = FaceProfileStore.Load(CurrentUser.NhanVienId);
            if (profile == null || profile.Descriptor.Length == 0)
            {
                GhiNhatKyChamCong("CheckIn", "KhuonMat", "ThatBai", "Chua co khuon mat mau hop le.");
                MessageBox.Show(
                    "Ban chua co khuon mat mau hop le. Vao Ho so ca nhan va bam 'Dang ky khuon mat' de dang ky lai truoc khi check in.",
                    "Chua co khuon mat mau",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            using var frm = new FrmCameraKhuonMat("Check in khuon mat", "Chup anh hien tai de doi chieu voi khuon mat da dang ky");
            if (frm.ShowDialog(this) != DialogResult.OK || frm.CaptureResult == null)
            {
                return false;
            }

            double distance = FaceProfileStore.ComputeDistance(profile.Descriptor, frm.CaptureResult.Descriptor);
            const double threshold = 0.48;

            if (distance > threshold)
            {
                GhiNhatKyChamCong("CheckIn", "KhuonMat", "ThatBai", $"Do lech khuon mat {distance:N3} vuot nguong {threshold:N2}.");
                MessageBox.Show(
                    $"Khuon mat hien tai khong khop voi mau da luu.\n\nDo lech: {distance:N3}  |  Nguong cho phep: {threshold:N2}",
                    "Xac thuc khuon mat that bai",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            GhiNhatKyChamCong("CheckIn", "KhuonMat", "ThanhCong", $"Do lech khuon mat {distance:N3}.");
            MessageBox.Show(
                $"Xac thuc khuon mat thanh cong.\n\nDo lech: {distance:N3}",
                "Xac thuc thanh cong",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return true;
        }

        private bool XacThucQr()
        {
            using var db = new AppDbContext();

            var homNay = DateTime.Today;
            var phanCa = db.PhanCaNhanViens
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec == homNay);

            string maCa = phanCa?.CaLamViec?.MaCa ?? "FREE";
            string maQrHopLe = QrChamCongHelper.TaoMa(CurrentUser.NhanVienId, homNay, maCa);
            string? maNguoiDungNhap = HienThiHopNhapQr(maQrHopLe, maCa);

            if (string.IsNullOrWhiteSpace(maNguoiDungNhap))
            {
                return false;
            }

            if (!string.Equals(maNguoiDungNhap.Trim(), maQrHopLe, StringComparison.OrdinalIgnoreCase))
            {
                GhiNhatKyChamCong("CheckIn", "QR", "ThatBai", $"Ma QR khong hop le: {maNguoiDungNhap.Trim()}.");
                MessageBox.Show(
                    "Ma QR khong hop le. He thong khong ghi nhan check in.",
                    "Sai ma QR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            LuuQrDaQuetThanhCong(homNay, phanCa?.CaLamViec?.TenCa ?? "Chua phan ca", maCa, maQrHopLe);
            GhiNhatKyChamCong("CheckIn", "QR", "ThanhCong", $"Quet dung ma {maQrHopLe}.");
            return true;
        }

        private void LuuQrDaQuetThanhCong(DateTime ngayLamViec, string tenCa, string maCa, string maQr)
        {
            var record = new QrPhatRecord
            {
                NhanVienId = CurrentUser.NhanVienId,
                MaNhanVien = string.IsNullOrWhiteSpace(CurrentUser.TenDangNhap) ? CurrentUser.NhanVienId.ToString() : CurrentUser.TenDangNhap,
                HoTen = CurrentUser.HoTen,
                NgayLamViec = ngayLamViec,
                TenCa = tenCa,
                MaCa = maCa,
                MaQr = maQr,
                PhatLuc = DateTime.Now,
                NguoiPhat = "NhanVien quet QR"
            };

            QrPhatStore.Save(record);
        }

        private string? HienThiHopNhapQr(string maQrHopLe, string maCa)
        {
            using var dialog = new Form();
            var lblHuongDan = new Label();
            var lblMaMau = new Label();
            var txtQr = new TextBox();
            var btnXacNhan = new Button();
            var btnHuy = new Button();
            var btnMoManPhatQr = new Button();
            var btnQuetCamera = new Button();

            dialog.Text = "Xac thuc QR check in";
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MinimizeBox = false;
            dialog.MaximizeBox = false;
            dialog.ClientSize = new Size(520, 230);
            dialog.BackColor = Color.White;

            lblHuongDan.AutoSize = false;
            lblHuongDan.Location = new Point(24, 20);
            lblHuongDan.Size = new Size(470, 46);
            lblHuongDan.Font = new Font("Segoe UI", 10F);
            lblHuongDan.Text = $"Nhap ma QR cua ca lam hien tai de check in.\nCa ap dung: {maCa}";

            lblMaMau.AutoSize = false;
            lblMaMau.Location = new Point(24, 72);
            lblMaMau.Size = new Size(470, 42);
            lblMaMau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMaMau.ForeColor = Color.FromArgb(37, 99, 235);
            lblMaMau.Text = $"Ma QR demo hom nay: {maQrHopLe}";

            txtQr.Location = new Point(24, 124);
            txtQr.Size = new Size(470, 27);
            txtQr.PlaceholderText = "Nhap hoac dan ma QR vao day";

            btnXacNhan.Text = "Xac nhan";
            btnXacNhan.Location = new Point(284, 170);
            btnXacNhan.Size = new Size(100, 34);
            btnXacNhan.DialogResult = DialogResult.OK;
            btnXacNhan.BackColor = Color.FromArgb(37, 99, 235);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.FlatAppearance.BorderSize = 0;

            btnHuy.Text = "Huy";
            btnHuy.Location = new Point(394, 180);
            btnHuy.Size = new Size(100, 34);
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FlatStyle = FlatStyle.Flat;

            btnMoManPhatQr.Text = "Xem ma QR";
            btnMoManPhatQr.Location = new Point(24, 180);
            btnMoManPhatQr.Size = new Size(120, 34);
            btnMoManPhatQr.FlatStyle = FlatStyle.Flat;
            btnMoManPhatQr.Click += (_, _) =>
            {
                MessageBox.Show(
                    $"Nho HR/Quan ly mo man 'Phat ma QR' va chon dung nhan vien/ngay/ca.\n\nMa hop le hien tai cua ban la:\n{maQrHopLe}",
                    "Huong dan quet QR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            btnQuetCamera.Text = "Quet camera";
            btnQuetCamera.Location = new Point(154, 180);
            btnQuetCamera.Size = new Size(120, 34);
            btnQuetCamera.FlatStyle = FlatStyle.Flat;
            btnQuetCamera.Click += (_, _) =>
            {
                using var frmQuet = new FrmQuetQrCamera();
                if (frmQuet.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(frmQuet.MaQrDaQuet))
                {
                    txtQr.Text = frmQuet.MaQrDaQuet;
                }
            };

            dialog.Controls.Add(lblHuongDan);
            dialog.Controls.Add(lblMaMau);
            dialog.Controls.Add(txtQr);
            dialog.Controls.Add(btnXacNhan);
            dialog.Controls.Add(btnHuy);
            dialog.Controls.Add(btnMoManPhatQr);
            dialog.Controls.Add(btnQuetCamera);
            dialog.AcceptButton = btnXacNhan;
            dialog.CancelButton = btnHuy;

            return dialog.ShowDialog(this) == DialogResult.OK
                ? txtQr.Text
                : null;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();

            var homNay = DateTime.Today;
            if (MonthlyAttendanceLockStore.IsLocked(homNay))
            {
                MessageBox.Show(
                    $"Bang cong thang {homNay.Month:00}/{homNay.Year} da duoc chot. Khong the check out them.",
                    "Thang da chot",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var chamCong = db.ChamCongs
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec == homNay);

            if (chamCong == null || !chamCong.GioCheckIn.HasValue)
            {
                GhiNhatKyChamCong("CheckOut", "ThuCong", "ThatBai", "Chua co ban ghi check in hom nay.");
                MessageBox.Show("Ban chua check in hom nay, chua the check out.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chamCong.GioCheckOut.HasValue)
            {
                GhiNhatKyChamCong("CheckOut", "ThuCong", "ThatBai", "Ban ghi hom nay da check out truoc do.");
                MessageBox.Show("Ban da check out hom nay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            chamCong.GioCheckOut = DateTime.Now;
            var gioLam = chamCong.GioCheckOut.Value - chamCong.GioCheckIn.Value;
            chamCong.SoGioLam = Math.Round(Math.Max(gioLam.TotalHours, 0), 2);

            if (chamCong.CaLamViec != null && chamCong.GioCheckOut.Value.TimeOfDay < chamCong.CaLamViec.GioKetThuc)
            {
                chamCong.SoPhutVeSom = (int)(chamCong.CaLamViec.GioKetThuc - chamCong.GioCheckOut.Value.TimeOfDay).TotalMinutes;
            }

            chamCong.GhiChu = AppendAudit(chamCong.GhiChu, "CheckOut");
            chamCong.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            GhiNhatKyChamCong("CheckOut", "ThuCong", "ThanhCong", $"Check out luc {chamCong.GioCheckOut:HH:mm dd/MM}.");
            MessageBox.Show("Check out thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiTongQuan();
            TaiLichSuGanDay();
        }

        private void ThucHienCheckIn(string phuongThuc, string? extraAudit = null)
        {
            using var db = new AppDbContext();

            var homNay = DateTime.Today;
            if (MonthlyAttendanceLockStore.IsLocked(homNay))
            {
                GhiNhatKyChamCong("CheckIn", phuongThuc, "ThatBai", $"Thang {homNay.Month:00}/{homNay.Year} da chot.");
                MessageBox.Show(
                    $"Bang cong thang {homNay.Month:00}/{homNay.Year} da duoc chot. Khong the check in them.",
                    "Thang da chot",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var chamCong = db.ChamCongs
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec == homNay);

            if (chamCong != null && chamCong.GioCheckIn.HasValue)
            {
                GhiNhatKyChamCong("CheckIn", phuongThuc, "ThatBai", "Ban da check in hom nay.");
                MessageBox.Show("Ban da check in hom nay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var phanCa = db.PhanCaNhanViens
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec == homNay);

            var gioHienTai = DateTime.Now;
            var trangThai = "CoMat";
            var soPhutDiMuon = 0;

            if (phanCa?.CaLamViec != null && gioHienTai.TimeOfDay > phanCa.CaLamViec.GioBatDau)
            {
                soPhutDiMuon = (int)(gioHienTai.TimeOfDay - phanCa.CaLamViec.GioBatDau).TotalMinutes;
                trangThai = soPhutDiMuon > 0 ? "DiMuon" : "CoMat";
            }

            if (chamCong == null)
            {
                chamCong = new Models.ChamCong
                {
                    NhanVienId = CurrentUser.NhanVienId,
                    CaLamViecId = phanCa?.CaLamViecId,
                    NgayLamViec = homNay,
                    NgayTao = DateTime.Now
                };
                db.ChamCongs.Add(chamCong);
            }

            chamCong.GioCheckIn = gioHienTai;
            chamCong.SoPhutDiMuon = Math.Max(0, soPhutDiMuon);
            chamCong.TrangThai = trangThai;
            chamCong.GhiChu = AppendAudit(chamCong.GhiChu, $"CheckIn:{phuongThuc}");
            if (!string.IsNullOrWhiteSpace(extraAudit))
            {
                chamCong.GhiChu = AppendAudit(chamCong.GhiChu, extraAudit);
            }
            chamCong.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            GhiNhatKyChamCong("CheckIn", phuongThuc, "ThanhCong", string.IsNullOrWhiteSpace(extraAudit) ? $"Check in thanh cong, trang thai {trangThai}." : $"Check in thanh cong, trang thai {trangThai}. {extraAudit}");

            MessageBox.Show($"Check in thanh cong bang {phuongThuc}.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiTongQuan();
            TaiLichSuGanDay();
        }

        private static string AppendAudit(string? current, string value)
        {
            var prefix = string.IsNullOrWhiteSpace(current) ? string.Empty : $"{current} | ";
            return $"{prefix}{value} {DateTime.Now:HH:mm}";
        }

        private void GhiNhatKyChamCong(string hanhDong, string phuongThuc, string ketQua, string chiTiet)
        {
            AttendanceAuditStore.Save(new AttendanceAuditEntry
            {
                NhanVienId = CurrentUser.NhanVienId,
                MaNhanVien = string.IsNullOrWhiteSpace(CurrentUser.TenDangNhap) ? CurrentUser.NhanVienId.ToString() : CurrentUser.TenDangNhap,
                HoTen = CurrentUser.HoTen,
                ThoiGian = DateTime.Now,
                HanhDong = hanhDong,
                PhuongThuc = phuongThuc,
                KetQua = ketQua,
                ChiTiet = chiTiet
            });
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiTongQuan();
            TaiLichSuGanDay();
        }
    }
}
