using HRM.Winform.Data;
using HRM.Winform.Forms.BaoCao;
using HRM.Winform.Forms.CaNhan;
using HRM.Winform.Forms.ChamCong;
using HRM.Winform.Forms.DanhMuc;
using HRM.Winform.Forms.DonTu;
using HRM.Winform.Forms.NhanSu;
using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.HeThong
{
    public partial class FrmMain : Form
    {
        private sealed record ModuleDefinition(
            string Key,
            string Title,
            string Description,
            string Section,
            string[] Roles,
            Func<Form> Factory,
            Color AccentColor);

        private readonly List<ModuleDefinition> _modules;
        private readonly Dictionary<string, Button> _navigationButtons = new(StringComparer.OrdinalIgnoreCase);
        private Form? _activeForm;

        public string TenDangNhap { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string VaiTro { get; set; } = string.Empty;
        public bool IsLogoutRequested { get; private set; }

        public FrmMain()
        {
            InitializeComponent();
            _modules = BuildModules();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ApplyWindowStyle();
            DongBoThongTinNguoiDung();
            BuildNavigation();
            ShowDashboard();
            Resize += (_, _) => ApplyResponsiveDashboardLayout();
        }

        private void ApplyWindowStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            pnlSidebar.BackColor = ThemeHelper.SidebarBackColor;
            pnlSidebarHeader.BackColor = ThemeHelper.SidebarHeaderColor;
            pnlSidebarFooter.BackColor = ThemeHelper.SidebarBackColor;
            pnlHeader.BackColor = ThemeHelper.CardBackColor;
            pnlMainContent.BackColor = ThemeHelper.AppBackColor;
            pnlDashboard.BackColor = ThemeHelper.AppBackColor;
            pnlFormHost.BackColor = ThemeHelper.CardBackColor;
            flpNavigation.BackColor = ThemeHelper.SidebarBackColor;
            flpAiHighlights.BackColor = Color.Transparent;

            lblAppName.ForeColor = Color.White;
            lblAppSubtitle.ForeColor = Color.FromArgb(208, 226, 255);
            lblHeaderTitle.ForeColor = ThemeHelper.TextPrimary;
            lblHeaderSubtitle.ForeColor = ThemeHelper.TextSecondary;
            lblCurrentUser.ForeColor = Color.White;
            lblCurrentRole.ForeColor = Color.FromArgb(147, 211, 255);
            lblDashboardTitle.ForeColor = ThemeHelper.TextPrimary;
            lblDashboardSubtitle.ForeColor = ThemeHelper.TextSecondary;
            lblAiHighlights.ForeColor = ThemeHelper.TextPrimary;

            ConfigureActionButton(btnDashboard, ThemeHelper.PrimaryColor, Color.White);
            ConfigureActionButton(btnDoiMatKhau, Color.White, ThemeHelper.PrimaryColor, FlatStyle.Flat);
            ConfigureActionButton(btnDangXuat, ThemeHelper.DangerColor, Color.White);

            btnDoiMatKhau.FlatAppearance.BorderSize = 1;
            btnDoiMatKhau.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);

            pnlSidebarHeader.Padding = new Padding(24, 24, 24, 18);
            flpNavigation.Padding = new Padding(16, 14, 16, 16);
            pnlSidebarFooter.Padding = new Padding(24, 18, 24, 22);
            pnlHeader.Padding = new Padding(28, 18, 28, 18);
            pnlMainContent.Padding = new Padding(22, 20, 22, 22);
            pnlDashboard.Padding = new Padding(0, 4, 0, 18);
            pnlFormHost.Padding = new Padding(1);

            flpAiHighlights.Padding = new Padding(0);
            flpAiHighlights.Margin = new Padding(0);
            flpAiHighlights.AutoSize = false;
            flpAiHighlights.FlowDirection = FlowDirection.LeftToRight;
            flpAiHighlights.WrapContents = true;

            flpQuickActions.Padding = new Padding(0);
            flpQuickActions.Margin = new Padding(0);
            flpQuickActions.AutoSize = false;
            flpQuickActions.FlowDirection = FlowDirection.LeftToRight;
            flpQuickActions.WrapContents = true;
        }

        private void ConfigureActionButton(Button button, Color backColor, Color foreColor, FlatStyle flatStyle = FlatStyle.Flat)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = flatStyle;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        private void DongBoThongTinNguoiDung()
        {
            TenDangNhap = string.IsNullOrWhiteSpace(TenDangNhap) ? CurrentUser.TenDangNhap : TenDangNhap;
            HoTen = string.IsNullOrWhiteSpace(HoTen) ? CurrentUser.HoTen : HoTen;
            VaiTro = NormalizeRole(string.IsNullOrWhiteSpace(VaiTro) ? CurrentUser.VaiTro : VaiTro);

            lblCurrentUser.Text = string.IsNullOrWhiteSpace(HoTen) ? "Chưa xác định người dùng" : HoTen;
            lblCurrentRole.Text = $"{VaiTro}  |  @{TenDangNhap}";
            lblHeaderTitle.Text = $"Xin chào, {HoTen}";
            lblHeaderSubtitle.Text = GetRoleSummary(VaiTro);
        }

        private static string NormalizeRole(string role)
        {
            return role.Trim().ToLowerInvariant() switch
            {
                "admin" => "Admin",
                "hr" => "HR",
                "quanly" => "QuanLy",
                "nhanvien" => "NhanVien",
                _ => "NhanVien"
            };
        }

        private string GetRoleSummary(string role)
        {
            return role switch
            {
                "Admin" => "Toan quyen cau hinh, nhan su, cham cong, don tu va bao cao.",
                "HR" => "Tap trung quan tri nhan su, danh muc, tai khoan va bao cao van hanh.",
                "QuanLy" => "Theo doi cham cong, xu ly phe duyet va xem bao cao quan ly.",
                _ => "Su dung cham cong thong minh, cong cua toi, lich lam viec, don tu va ho so ca nhan."
            };
        }

        private List<ModuleDefinition> BuildModules()
        {
            return
            [
                new("PhongBan", "Phong ban", "Quan ly co cau phong ban trong doanh nghiep.", "Danh muc", ["Admin", "HR"], () => new FrmPhongBan(), Color.FromArgb(37, 99, 235)),
                new("ChucVu", "Chuc vu", "Cap nhat danh muc chuc vu va vai tro cong viec.", "Danh muc", ["Admin", "HR"], () => new FrmChucVu(), Color.FromArgb(14, 165, 233)),
                new("CaLamViec", "Ca lam viec", "Thiet lap khung gio lam viec va quy dinh ca.", "Danh muc", ["Admin", "HR"], () => new FrmCaLamViec(), Color.FromArgb(6, 182, 212)),
                new("LoaiNghiPhep", "Loai nghi phep", "Cau hinh cac loai nghi phep ap dung noi bo.", "Danh muc", ["Admin", "HR"], () => new FrmLoaiNghiPhep(), Color.FromArgb(16, 185, 129)),
                new("NhanVien", "Nhan vien", "Ho so nhan vien va thong tin cong tac.", "Nhan su", ["Admin", "HR"], () => new FrmNhanVien(), Color.FromArgb(249, 115, 22)),
                new("TaiKhoan", "Tai khoan", "Cap quyen dang nhap va phan vai tro cho nhan su.", "Nhan su", ["Admin", "HR"], () => new FrmTaiKhoan(), Color.FromArgb(234, 88, 12)),
                new("PhanCaNhanVien", "Phan ca nhan vien", "Gan lich lam viec cho tung nhan vien.", "Cham cong", ["Admin", "HR", "QuanLy"], () => new FrmPhanCaNhanVien(), Color.FromArgb(99, 102, 241)),
                new("CauHinhGpsCongTy", "Cau hinh GPS", "Thiet lap vi tri cong ty va ban kinh hop le cho check in GPS.", "Cham cong", ["Admin", "HR"], () => new FrmCauHinhGpsCongTy(), Color.FromArgb(5, 150, 105)),
                new("PhatMaQrChamCong", "Phat ma QR", "Sinh ma QR noi bo cho nhan vien check in theo ngay va ca.", "Cham cong", ["Admin", "HR", "QuanLy"], () => new FrmPhatMaQrChamCong(), Color.FromArgb(37, 99, 235)),
                new("ChamCong", "Cham cong", "Ghi nhan vao ca, ra ca va theo doi hien dien.", "Cham cong", ["Admin", "HR", "QuanLy"], () => new FrmChamCong(), Color.FromArgb(79, 70, 229)),
                new("ChotCongThang", "Chot cong thang", "Khoa bang cong thang sau khi doi soat, mo chot khi can dieu chinh.", "Cham cong", ["Admin", "HR"], () => new FrmChotCongThang(), Color.FromArgb(180, 83, 9)),
                new("NhatKyChamCongThongMinh", "Nhat ky thong minh", "Theo doi lich su check in/check out bang QR, GPS va Khuon mat.", "Cham cong", ["Admin", "HR", "QuanLy"], () => new FrmNhatKyChamCongThongMinh(), Color.FromArgb(15, 118, 110)),
                new("BangCongNgay", "Bang cong ngay", "Tong hop cong viec va thoi gian trong ngay.", "Cham cong", ["Admin", "HR", "QuanLy"], () => new FrmBangCongNgay(), Color.FromArgb(139, 92, 246)),
                new("BangCongThang", "Bang cong thang", "Tong ket cong thang de doi soat luong.", "Cham cong", ["Admin", "HR", "QuanLy"], () => new FrmBangCongThang(), Color.FromArgb(168, 85, 247)),
                new("DonNghiPhep", "Don nghi phep", "Tao va theo doi cac yeu cau nghi phep.", "Don tu", ["Admin", "HR", "QuanLy"], () => new FrmDonNghiPhep(), Color.FromArgb(236, 72, 153)),
                new("DonTangCa", "Don tang ca", "Dang ky tang ca va quan ly gio lam them.", "Don tu", ["Admin", "HR", "QuanLy"], () => new FrmDonTangCa(), Color.FromArgb(244, 63, 94)),
                new("DuyetDon", "Duyet don", "Phe duyet nghi phep va tang ca cho nhan vien.", "Don tu", ["Admin", "HR", "QuanLy"], () => new FrmDuyetDon(), Color.FromArgb(239, 68, 68)),
                new("BaoCaoNhanSu", "Bao cao nhan su", "Thong ke bien dong nhan su va ho so lao dong.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmBaoCaoNhanSu(), Color.FromArgb(2, 132, 199)),
                new("BaoCaoChamCong", "Bao cao cham cong", "Tong hop so lieu cong va ti le di lam.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmBaoCaoChamCong(), Color.FromArgb(14, 116, 144)),
                new("CanhBaoChamCongAI", "Canh bao AI", "Phat hien bat thuong cham cong theo GPS, OT va lich su cong.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmCanhBaoChamCongAI(), Color.FromArgb(127, 29, 29)),
                new("BaoCaoNghiPhep", "Bao cao nghi phep", "Theo doi lich su nghi phep va so ngay nghi.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmBaoCaoNghiPhep(), Color.FromArgb(5, 150, 105)),
                new("TinhLuong", "Tinh luong", "Tam tinh luong theo luong co ban, cong, nghi phep va tang ca.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmTinhLuong(), Color.FromArgb(249, 115, 22)),
                new("PhieuLuongBaoCao", "Phieu luong", "Xem phieu luong ca nhan theo thang voi tong hop chi tiet thu nhap va khau tru.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmPhieuLuongCaNhan(DateTime.Today.Month, DateTime.Today.Year, CurrentUser.NhanVienId), Color.FromArgb(21, 128, 61)),
                new("TroLyHRQuanTri", "Tro ly HR", "Hoi dap nhanh ve cong, phep, ca lam va don tu tu du lieu he thong.", "Bao cao", ["Admin", "HR", "QuanLy"], () => new FrmChatbotHR(), Color.FromArgb(22, 163, 74)),
                new("ChamCongThongMinh", "Cham cong thong minh", "Check in bang khuon mat, QR, GPS va theo doi nhac viec.", "Ca nhan", ["NhanVien"], () => new FrmChamCongThongMinh(), Color.FromArgb(37, 99, 235)),
                new("CongCaNhan", "Cong cua toi", "Xem bang cong, di muon, ve som va tong tang ca da duyet.", "Ca nhan", ["NhanVien"], () => new FrmCongCaNhan(), Color.FromArgb(79, 70, 229)),
                new("LichLamViecCaNhan", "Lich lam viec", "Theo doi ca hom nay, tuan nay va cac ca dac biet.", "Ca nhan", ["NhanVien"], () => new FrmLichLamViecCaNhan(), Color.FromArgb(14, 165, 233)),
                new("DonTuCaNhan", "Don tu cua toi", "Gui nghi phep, tang ca va theo doi trang thai duyet.", "Ca nhan", ["NhanVien"], () => new FrmDonTuCaNhan(), Color.FromArgb(236, 72, 153)),
                new("HoSoCaNhan", "Ho so ca nhan", "Cap nhat thong tin lien he, xem phong ban, chuc vu va doi mat khau.", "Ca nhan", ["NhanVien"], () => new FrmHoSoCaNhan(), Color.FromArgb(249, 115, 22)),
                new("PhieuLuongCaNhan", "Phieu luong", "Xem phieu luong tam tinh cua ban theo thang.", "Ca nhan", ["NhanVien"], () => new FrmPhieuLuongCaNhan(DateTime.Today.Month, DateTime.Today.Year, CurrentUser.NhanVienId), Color.FromArgb(21, 128, 61)),
                new("NhatKyThongMinhCaNhan", "Nhat ky check in", "Xem lich su check in/check out thong minh cua ban.", "Ca nhan", ["NhanVien"], () => new FrmNhatKyChamCongThongMinh(), Color.FromArgb(15, 118, 110)),
                new("TroLyHRNhanVien", "Tro ly HR", "Hoi dap nhanh ve cong, phep, ca lam va don tu cua ban.", "Ca nhan", ["NhanVien"], () => new FrmChatbotHR(), Color.FromArgb(22, 163, 74))
            ];
        }

        private IEnumerable<ModuleDefinition> GetAccessibleModules()
        {
            return _modules.Where(x => x.Roles.Contains(VaiTro, StringComparer.OrdinalIgnoreCase));
        }

        private void BuildNavigation()
        {
            flpNavigation.SuspendLayout();
            flpNavigation.Controls.Clear();
            _navigationButtons.Clear();

            foreach (var sectionGroup in GetAccessibleModules().GroupBy(x => x.Section))
            {
                flpNavigation.Controls.Add(CreateSectionLabel(sectionGroup.Key));

                foreach (var module in sectionGroup)
                {
                    var button = CreateNavigationButton(module);
                    _navigationButtons[module.Key] = button;
                    flpNavigation.Controls.Add(button);
                }
            }

            flpNavigation.ResumeLayout();
        }

        private Control CreateSectionLabel(string text)
        {
            return new Label
            {
                AutoSize = false,
                Width = 228,
                Height = 32,
                Margin = new Padding(4, 12, 4, 4),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(148, 163, 184),
                Text = text.ToUpperInvariant()
            };
        }

        private Button CreateNavigationButton(ModuleDefinition module)
        {
            var button = new Button
            {
                AutoSize = false,
                Width = 228,
                Height = 54,
                Margin = new Padding(4, 4, 4, 4),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(31, 49, 79),
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(18, 0, 18, 0),
                Cursor = Cursors.Hand,
                Text = module.Title,
                Tag = module.Key
            };

            button.FlatAppearance.BorderSize = 0;
            button.Click += (_, _) => OpenModule(module.Key);
            return button;
        }

        private void OpenModule(string key)
        {
            var module = GetAccessibleModules().FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
            if (module == null)
            {
                MessageBox.Show("Ban khong co quyen truy cap man hinh nay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetActiveNavigation(module.Key);

            if (_activeForm?.Tag?.ToString() == module.Key)
            {
                _activeForm.Focus();
                return;
            }

            _activeForm?.Close();
            pnlFormHost.Controls.Clear();

            var form = module.Factory();
            form.Tag = module.Key;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlDashboard.Visible = false;
            pnlFormHost.Visible = true;
            pnlFormHost.Controls.Add(form);
            _activeForm = form;

            lblHeaderTitle.Text = module.Title;
            lblHeaderSubtitle.Text = module.Description;

            form.Show();
        }

        private void SetActiveNavigation(string? activeKey)
        {
            foreach (var pair in _navigationButtons)
            {
                bool isActive = string.Equals(pair.Key, activeKey, StringComparison.OrdinalIgnoreCase);
                pair.Value.BackColor = isActive ? ThemeHelper.PrimaryColor : Color.FromArgb(31, 49, 79);
            }
        }

        private void ShowDashboard()
        {
            _activeForm?.Close();
            _activeForm = null;
            pnlFormHost.Controls.Clear();
            pnlFormHost.Visible = false;
            pnlDashboard.Visible = true;
            SetActiveNavigation(null);

            lblHeaderTitle.Text = $"Xin chao, {HoTen}";
            lblHeaderSubtitle.Text = GetRoleSummary(VaiTro);

            RenderDashboard();
        }

        private void RenderDashboard()
        {
            tlpStats.Controls.Clear();
            flpAiHighlights.Controls.Clear();
            flpQuickActions.Controls.Clear();

            foreach (var statCard in BuildStatCards())
            {
                tlpStats.Controls.Add(statCard);
            }

            foreach (var aiCard in BuildAiHighlightCards())
            {
                flpAiHighlights.Controls.Add(aiCard);
            }

            foreach (var module in GetAccessibleModules().Take(6))
            {
                flpQuickActions.Controls.Add(CreateQuickActionCard(module));
            }

            ApplyResponsiveDashboardLayout();
        }

        private IEnumerable<Control> BuildStatCards()
        {
            int tongNhanVien = 0;
            int tongPhongBan = 0;
            int choDuyet = 0;
            int tongTaiKhoan = 0;

            try
            {
                using var db = new AppDbContext();
                tongNhanVien = db.NhanViens.Count(x => x.DangLamViec);
                tongPhongBan = db.PhongBans.Count();
                tongTaiKhoan = db.TaiKhoans.Count(x => x.HoatDong);
                choDuyet = db.DonNghiPheps.Count(x => x.TrangThai == "ChoDuyet") + db.DonTangCas.Count(x => x.TrangThai == "ChoDuyet");
            }
            catch
            {
                // Giu dashboard van hoat dong ngay ca khi CSDL tam thoi co van de.
            }

            yield return CreateStatCard("Nhan su dang lam", tongNhanVien.ToString(), "Nhan vien dang hoat dong trong he thong.", Color.FromArgb(37, 99, 235));
            yield return CreateStatCard("Phong ban", tongPhongBan.ToString(), "So don vi dang duoc cau hinh.", Color.FromArgb(14, 165, 233));
            yield return CreateStatCard("Tai khoan hoat dong", tongTaiKhoan.ToString(), "Tai khoan dang co the dang nhap.", Color.FromArgb(249, 115, 22));
            yield return CreateStatCard("Don cho duyet", choDuyet.ToString(), "Tong hop don nghi phep va tang ca cho xu ly.", Color.FromArgb(239, 68, 68));
        }

        private IEnumerable<Control> BuildAiHighlightCards()
        {
            var now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            string canhBaoValue = "0 muc do cao";
            string canhBaoDesc = "Chua co canh bao bat thuong dang chu y.";

            string xacThucValue = "0 thanh cong";
            string xacThucDesc = "Theo doi QR, GPS va KhuonMat trong ngay.";

            string insightValue = "On dinh";
            string insightDesc = "He thong se dua ra nhan xet nhanh tu du lieu hien tai.";

            try
            {
                var anomaly = AttendanceAnomalyAnalyzer.Analyze(month, year);
                canhBaoValue = $"{anomaly.Summary.MucDoCao} muc do cao";
                canhBaoDesc = string.IsNullOrWhiteSpace(anomaly.Summary.NhanXetTuDong)
                    ? "Khong co canh bao bat thuong dang chu y."
                    : anomaly.Summary.NhanXetTuDong;

                var todayLogs = AttendanceAuditStore.LoadAll()
                    .Where(x => x.ThoiGian.Date == DateTime.Today)
                    .ToList();

                int successCount = todayLogs.Count(x => x.KetQua == "ThanhCong");
                int failedCount = todayLogs.Count(x => x.KetQua == "ThatBai");
                xacThucValue = $"{successCount} thanh cong";
                xacThucDesc = failedCount > 0
                    ? $"{failedCount} lan that bai can xem lai, uu tien doi chieu GPS/KhuonMat."
                    : "Chua ghi nhan that bai dang chu y trong ngay.";

                using var db = new AppDbContext();
                int pendingLeaves = db.DonNghiPheps.Count(x => x.TrangThai == "ChoDuyet");
                int pendingOt = db.DonTangCas.Count(x => x.TrangThai == "ChoDuyet");
                insightValue = $"{pendingLeaves + pendingOt} muc cho duyet";

                var topMethod = todayLogs
                    .Where(x => x.KetQua == "ThanhCong")
                    .GroupBy(x => x.PhuongThuc)
                    .OrderByDescending(x => x.Count())
                    .Select(x => new { Method = x.Key, Count = x.Count() })
                    .FirstOrDefault();

                insightDesc = topMethod != null
                    ? $"Phuong thuc xac thuc noi bat hom nay la {topMethod.Method} ({topMethod.Count} lan). Don cho duyet hien tai: {pendingLeaves} nghi phep, {pendingOt} tang ca."
                    : $"Don cho duyet hien tai: {pendingLeaves} nghi phep, {pendingOt} tang ca.";
            }
            catch
            {
                // Dashboard should still render even if data is temporarily unavailable.
            }

            yield return CreateHighlightCard("Canh bao AI", canhBaoValue, canhBaoDesc, Color.FromArgb(254, 242, 242), Color.FromArgb(153, 27, 27));
            yield return CreateHighlightCard("Xac thuc thong minh", xacThucValue, xacThucDesc, Color.FromArgb(236, 253, 245), Color.FromArgb(6, 95, 70));
            yield return CreateHighlightCard("Insight van hanh", insightValue, insightDesc, Color.FromArgb(239, 246, 255), Color.FromArgb(30, 64, 175));
        }

        private Control CreateStatCard(string title, string value, string description, Color accentColor)
        {
            var panel = new Panel
            {
                Width = 240,
                Height = 156,
                Margin = new Padding(0, 0, 20, 20),
                BackColor = ThemeHelper.CardBackColor,
                Padding = new Padding(18, 18, 18, 16)
            };

            var line = new Panel
            {
                Width = panel.Width - 36,
                Height = 6,
                BackColor = accentColor,
                Location = new Point(18, 16)
            };

            var lblTitle = new Label
            {
                AutoSize = false,
                Location = new Point(18, 34),
                Size = new Size(panel.Width - 36, 26),
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextSecondary,
                Text = title
            };

            var lblValue = new Label
            {
                AutoSize = false,
                Location = new Point(18, 64),
                Size = new Size(panel.Width - 36, 52),
                Font = new Font("Segoe UI", 27F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextPrimary,
                Text = value
            };

            var lblDescription = new Label
            {
                AutoSize = false,
                Location = new Point(18, 116),
                Size = new Size(panel.Width - 36, 28),
                Font = new Font("Segoe UI", 9.25F),
                ForeColor = ThemeHelper.TextSecondary,
                Text = description,
                AutoEllipsis = true
            };

            panel.Controls.Add(line);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblDescription);
            panel.Paint += DashboardCard_Paint;
            panel.Tag = accentColor;

            return panel;
        }

        private Control CreateQuickActionCard(ModuleDefinition module)
        {
            var card = new Panel
            {
                Width = 262,
                Height = 138,
                Margin = new Padding(0, 0, 20, 20),
                BackColor = ThemeHelper.CardBackColor,
                Padding = new Padding(18),
                Cursor = Cursors.Hand,
                Tag = module.Key
            };

            var badge = new Panel
            {
                Width = 48,
                Height = 48,
                BackColor = module.AccentColor,
                Location = new Point(18, 18)
            };

            var lblShortcut = new Label
            {
                AutoSize = false,
                Width = badge.Width,
                Height = badge.Height,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = module.Title[..1].ToUpperInvariant(),
                BackColor = Color.Transparent
            };
            badge.Controls.Add(lblShortcut);

            var lblTitle = new Label
            {
                Location = new Point(78, 16),
                Width = 170,
                Height = 30,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextPrimary,
                Text = module.Title
            };

            var lblDesc = new Label
            {
                Location = new Point(78, 46),
                Width = 172,
                Height = 68,
                Font = new Font("Segoe UI", 9.25F),
                ForeColor = ThemeHelper.TextSecondary,
                Text = module.Description,
                AutoEllipsis = true
            };

            card.Controls.Add(badge);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblDesc);
            card.Paint += DashboardNeutralCard_Paint;

            card.Click += (_, _) => OpenModule(module.Key);
            foreach (Control child in card.Controls)
            {
                child.Click += (_, _) => OpenModule(module.Key);
            }

            return card;
        }

        private Control CreateHighlightCard(string title, string value, string description, Color backColor, Color foreColor)
        {
            var card = new Panel
            {
                Width = 320,
                Height = 164,
                Margin = new Padding(0, 0, 20, 20),
                BackColor = backColor,
                Padding = new Padding(20, 18, 20, 18)
            };

            var toneBar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(card.Width, 6),
                BackColor = foreColor
            };

            var lblTitle = new Label
            {
                AutoSize = false,
                Location = new Point(20, 24),
                Size = new Size(card.Width - 40, 24),
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = foreColor,
                Text = title
            };

            var lblValue = new Label
            {
                AutoSize = false,
                Location = new Point(20, 56),
                Size = new Size(card.Width - 40, 40),
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = foreColor,
                Text = value
            };

            var lblDescription = new Label
            {
                AutoSize = false,
                Location = new Point(20, 102),
                Size = new Size(card.Width - 40, 48),
                Font = new Font("Segoe UI", 9.25F),
                ForeColor = foreColor,
                Text = description,
                AutoEllipsis = true
            };

            card.Controls.Add(toneBar);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblValue);
            card.Controls.Add(lblDescription);
            card.Paint += DashboardSoftCard_Paint;
            return card;
        }

        private void ApplyResponsiveDashboardLayout()
        {
            const int sectionGap = 20;
            int contentWidth = Math.Max(760, pnlDashboard.ClientSize.Width - 56);

            lblDashboardTitle.Left = 28;
            lblDashboardSubtitle.Left = 28;
            tlpStats.Width = contentWidth;
            flpAiHighlights.Width = contentWidth;
            flpQuickActions.Width = contentWidth;
            tlpStats.Height = 164;
            tlpStats.Left = 28;
            flpAiHighlights.Left = 28;
            flpQuickActions.Left = 28;

            tlpStats.Top = lblDashboardSubtitle.Bottom + 18;

            int statWidth = Math.Max(210, (contentWidth - (sectionGap * 4)) / 4);
            foreach (Control control in tlpStats.Controls)
            {
                control.Width = statWidth;
                control.Height = 156;
                control.Margin = new Padding(0, 0, sectionGap, sectionGap);
            }

            int aiColumns = contentWidth >= 1100 ? 3 : contentWidth >= 760 ? 2 : 1;
            int aiWidth = Math.Max(260, (contentWidth - (aiColumns * sectionGap)) / aiColumns);
            foreach (Control control in flpAiHighlights.Controls)
            {
                control.Width = aiWidth;
                control.Height = 164;
                control.Margin = new Padding(0, 0, sectionGap, sectionGap);
            }
            int aiRows = Math.Max(1, (int)Math.Ceiling(flpAiHighlights.Controls.Count / (double)aiColumns));
            flpAiHighlights.Height = (aiRows * 164) + ((aiRows - 1) * 20) + 4;
            lblAiHighlights.Left = 28;
            lblAiHighlights.Top = tlpStats.Bottom + 10;
            flpAiHighlights.Top = lblAiHighlights.Bottom + 12;

            int quickColumns = contentWidth >= 1200 ? 3 : contentWidth >= 760 ? 2 : 1;
            int quickWidth = Math.Max(240, (contentWidth - (quickColumns * sectionGap)) / quickColumns);
            foreach (Control control in flpQuickActions.Controls)
            {
                control.Width = quickWidth;
                control.Height = 138;
                control.Margin = new Padding(0, 0, sectionGap, sectionGap);
            }
            int quickRows = Math.Max(1, (int)Math.Ceiling(flpQuickActions.Controls.Count / (double)quickColumns));
            flpQuickActions.Height = (quickRows * 138) + ((quickRows - 1) * 20) + 4;
            lblQuickActions.Left = 28;
            lblQuickActions.Top = flpAiHighlights.Bottom + 14;
            flpQuickActions.Top = lblQuickActions.Bottom + 12;
        }

        private static void DashboardCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            using var pen = new Pen(Color.FromArgb(226, 232, 240));
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
        }

        private static void DashboardNeutralCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            using var pen = new Pen(Color.FromArgb(226, 232, 240));
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
        }

        private static void DashboardSoftCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            using var pen = new Pen(Color.FromArgb(219, 234, 254));
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            using var frm = new FrmDoiMatKhau();
            frm.ShowDialog(this);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show("Ban co muon dang xuat khoi he thong khong?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes)
            {
                return;
            }

            IsLogoutRequested = true;
            CurrentUser.Clear();
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsLogoutRequested)
            {
                return;
            }

            if (Application.OpenForms.OfType<FrmDangNhap>().Any())
            {
                CurrentUser.Clear();
            }
        }
    }
}
