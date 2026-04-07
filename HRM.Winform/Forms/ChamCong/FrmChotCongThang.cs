using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.ChamCong
{
    public class FrmChotCongThang : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;
        private readonly Label _lblTitle = new();
        private readonly Label _lblSubtitle = new();
        private readonly Label _lblThang = new();
        private readonly NumericUpDown _nudThang = new();
        private readonly Label _lblNam = new();
        private readonly NumericUpDown _nudNam = new();
        private readonly Button _btnXem = new();
        private readonly Button _btnChot = new();
        private readonly Button _btnMoChot = new();
        private readonly Panel _pnlStatus = new();
        private readonly Label _lblStatusTitle = new();
        private readonly Label _lblStatusValue = new();
        private readonly Label _lblStatusDetail = new();
        private readonly Label _lblTong = new();
        private readonly DataGridView _dgvPreview = new();

        public FrmChotCongThang()
        {
            InitializeComponent();
            _gridHelper ??= new DataGridSearchPaginationHelper(_dgvPreview);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            BackColor = ThemeHelper.AppBackColor;
            Text = "Chot cong theo thang";
            ClientSize = new Size(1180, 760);
            MinimumSize = new Size(1080, 700);

            _lblTitle.AutoSize = true;
            _lblTitle.Location = new Point(24, 18);
            _lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            _lblTitle.ForeColor = ThemeHelper.TextPrimary;
            _lblTitle.Text = "Chot cong theo thang";

            _lblSubtitle.AutoSize = true;
            _lblSubtitle.Location = new Point(24, 58);
            _lblSubtitle.ForeColor = ThemeHelper.TextSecondary;
            _lblSubtitle.Text = "Sau khi chot, cac thao tac them/sua/xoa cham cong va check-in thong minh trong thang se bi khoa.";

            _lblThang.AutoSize = true;
            _lblThang.Location = new Point(28, 104);
            _lblThang.Text = "Thang";

            _nudThang.Location = new Point(82, 100);
            _nudThang.Minimum = 1;
            _nudThang.Maximum = 12;
            _nudThang.Value = DateTime.Today.Month;
            _nudThang.Size = new Size(74, 27);

            _lblNam.AutoSize = true;
            _lblNam.Location = new Point(182, 104);
            _lblNam.Text = "Nam";

            _nudNam.Location = new Point(226, 100);
            _nudNam.Minimum = 2000;
            _nudNam.Maximum = 3000;
            _nudNam.Value = DateTime.Today.Year;
            _nudNam.Size = new Size(90, 27);

            _btnXem.Location = new Point(346, 96);
            _btnXem.Size = new Size(94, 34);
            _btnXem.Text = "Xem";
            _btnXem.Click += (_, _) => TaiDuLieu();
            ThemeHelper.ApplySecondaryButton(_btnXem);

            _btnChot.Location = new Point(456, 96);
            _btnChot.Size = new Size(120, 34);
            _btnChot.Text = "Chot cong";
            _btnChot.Click += (_, _) => CapNhatTrangThai(true);
            ThemeHelper.ApplyPrimaryButton(_btnChot);

            _btnMoChot.Location = new Point(588, 96);
            _btnMoChot.Size = new Size(120, 34);
            _btnMoChot.Text = "Mo chot";
            _btnMoChot.Click += (_, _) => CapNhatTrangThai(false);
            ThemeHelper.ApplyDangerButton(_btnMoChot);

            _pnlStatus.Location = new Point(24, 152);
            _pnlStatus.Size = new Size(1132, 108);
            _pnlStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _pnlStatus.Padding = new Padding(20, 18, 20, 18);
            ThemeHelper.ApplyCard(_pnlStatus);

            _lblStatusTitle.AutoSize = false;
            _lblStatusTitle.Dock = DockStyle.Top;
            _lblStatusTitle.Height = 24;
            _lblStatusTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblStatusTitle.ForeColor = ThemeHelper.TextPrimary;
            _lblStatusTitle.Text = "Trang thai khoa bang cong";

            _lblStatusValue.AutoSize = false;
            _lblStatusValue.Dock = DockStyle.Top;
            _lblStatusValue.Height = 32;
            _lblStatusValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            _lblStatusValue.Text = "--";

            _lblStatusDetail.AutoSize = false;
            _lblStatusDetail.Dock = DockStyle.Fill;
            _lblStatusDetail.Font = new Font("Segoe UI", 9.5F);
            _lblStatusDetail.ForeColor = ThemeHelper.TextSecondary;
            _lblStatusDetail.Text = "--";

            _pnlStatus.Controls.Add(_lblStatusDetail);
            _pnlStatus.Controls.Add(_lblStatusValue);
            _pnlStatus.Controls.Add(_lblStatusTitle);

            _lblTong.AutoSize = true;
            _lblTong.Location = new Point(28, 282);
            _lblTong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _lblTong.ForeColor = ThemeHelper.TextPrimary;
            _lblTong.Text = "Tong ban ghi: 0";

            _dgvPreview.Location = new Point(24, 314);
            _dgvPreview.Size = new Size(1132, 410);
            _dgvPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(_lblTitle);
            Controls.Add(_lblSubtitle);
            Controls.Add(_lblThang);
            Controls.Add(_nudThang);
            Controls.Add(_lblNam);
            Controls.Add(_nudNam);
            Controls.Add(_btnXem);
            Controls.Add(_btnChot);
            Controls.Add(_btnMoChot);
            Controls.Add(_pnlStatus);
            Controls.Add(_lblTong);
            Controls.Add(_dgvPreview);

            Load += FrmChotCongThang_Load;
            ResumeLayout(false);
        }

        private void FrmChotCongThang_Load(object? sender, EventArgs e)
        {
            ThemeHelper.ApplyDataGrid(_dgvPreview);
            CaiDatGrid();
            TaiDuLieu();
        }

        private void CaiDatGrid()
        {
            _dgvPreview.AutoGenerateColumns = false;
            _dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dgvPreview.Columns.Clear();
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ma NV", DataPropertyName = "MaNhanVien", FillWeight = 70, MinimumWidth = 80 });
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ho ten", DataPropertyName = "HoTen", FillWeight = 130, MinimumWidth = 130 });
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "So ngay cong", DataPropertyName = "SoNgayCong", FillWeight = 80, MinimumWidth = 90 });
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tong gio lam", DataPropertyName = "TongSoGioLam", FillWeight = 85, MinimumWidth = 90 });
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tang ca", DataPropertyName = "TongTangCa", FillWeight = 80, MinimumWidth = 80 });
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Di muon", DataPropertyName = "TongDiMuon", FillWeight = 80, MinimumWidth = 80 });
            _dgvPreview.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ve som", DataPropertyName = "TongVeSom", FillWeight = 80, MinimumWidth = 80 });
        }

        private void TaiDuLieu()
        {
            int month = (int)_nudThang.Value;
            int year = (int)_nudNam.Value;

            using var db = new AppDbContext();
            var ds = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Where(x => x.NgayLamViec.Month == month && x.NgayLamViec.Year == year)
                .GroupBy(x => new
                {
                    x.NhanVienId,
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : ""
                })
                .Select(g => new
                {
                    g.Key.MaNhanVien,
                    g.Key.HoTen,
                    SoNgayCong = g.Count(x => x.TrangThai != "Vang"),
                    TongSoGioLam = g.Sum(x => x.SoGioLam),
                    TongTangCa = g.Sum(x => x.SoGioTangCa),
                    TongDiMuon = g.Sum(x => x.SoPhutDiMuon),
                    TongVeSom = g.Sum(x => x.SoPhutVeSom)
                })
                .OrderBy(x => x.HoTen)
                .ToList();

            _gridHelper?.ApplyData(ds);
            _lblTong.Text = $"Tong ban ghi: {ds.Count}";
            CapNhatTrangThai();
        }

        private void CapNhatTrangThai()
        {
            int month = (int)_nudThang.Value;
            int year = (int)_nudNam.Value;
            var lockInfo = MonthlyAttendanceLockStore.Get(month, year);

            if (lockInfo?.IsLocked == true)
            {
                _lblStatusValue.Text = "Da chot";
                _lblStatusValue.ForeColor = Color.FromArgb(153, 27, 27);
                _lblStatusDetail.Text = $"Bang cong thang {month:00}/{year} da khoa luc {lockInfo.UpdatedAt:HH:mm dd/MM/yyyy} boi {lockInfo.UpdatedBy}. {lockInfo.Note}".Trim();
            }
            else
            {
                _lblStatusValue.Text = "Chua chot";
                _lblStatusValue.ForeColor = Color.FromArgb(5, 150, 105);
                _lblStatusDetail.Text = $"Bang cong thang {month:00}/{year} dang mo, co the tiep tuc doi soat va cap nhat.";
            }
        }

        private void CapNhatTrangThai(bool isLocked)
        {
            int month = (int)_nudThang.Value;
            int year = (int)_nudNam.Value;

            MonthlyAttendanceLockStore.Save(new MonthlyAttendanceLockRecord
            {
                Month = month,
                Year = year,
                IsLocked = isLocked,
                UpdatedAt = DateTime.Now,
                UpdatedBy = string.IsNullOrWhiteSpace(CurrentUser.TenDangNhap) ? CurrentUser.HoTen : CurrentUser.TenDangNhap,
                Note = isLocked ? "Khong cho sua bang cong sau khi da doi soat." : "Mo lai de dieu chinh bang cong."
            });

            MessageBox.Show(
                isLocked
                    ? $"Da chot bang cong thang {month:00}/{year}."
                    : $"Da mo chot bang cong thang {month:00}/{year}.",
                "Thong bao",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            CapNhatTrangThai();
        }
    }
}
