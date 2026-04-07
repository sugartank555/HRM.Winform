using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HRM.Winform.Forms.BaoCao
{
    public partial class FrmBaoCaoNhanSu : Form
    {
        private List<ReportRow> _duLieuHienTai = [];
        private DataGridSearchPaginationHelper? _gridHelper;

        private sealed class ReportRow
        {
            public string MaNhanVien { get; set; } = string.Empty;
            public string HoTen { get; set; } = string.Empty;
            public DateTime NgaySinh { get; set; }
            public string GioiTinhText { get; set; } = string.Empty;
            public string SoDienThoai { get; set; } = string.Empty;
            public string? Email { get; set; }
            public string TenPhongBan { get; set; } = string.Empty;
            public string TenChucVu { get; set; } = string.Empty;
            public DateTime NgayVaoLam { get; set; }
            public decimal LuongCoBan { get; set; }
            public bool DangLamViec { get; set; }
        }

        public FrmBaoCaoNhanSu()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoNhanSu_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvBaoCaoNhanSu);
            TaiPhongBan();
            TaiDuLieu();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            ThemeHelper.ApplyInput(cboPhongBan);
            ThemeHelper.ApplyInput(cboTrangThaiLamViec);
            ThemeHelper.ApplyInput(txtTuKhoa);
            ThemeHelper.ApplyPrimaryButton(btnXem);
            ThemeHelper.ApplySecondaryButton(btnTomTatAI);
            ThemeHelper.ApplySecondaryButton(btnXuatExcel);
            ThemeHelper.ApplyCard(pnlTomTat);
            ThemeHelper.ApplyDataGrid(dgvBaoCaoNhanSu);

            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblTong.ForeColor = ThemeHelper.TextPrimary;
            lblTomTatTitle.ForeColor = ThemeHelper.TextPrimary;
            lblTomTatTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTomTatBody.ForeColor = ThemeHelper.TextSecondary;
            lblTomTatBody.Font = new Font("Segoe UI", 10F);

            pnlTomTat.Padding = new Padding(20, 18, 20, 18);
        }

        private void CaiDatGrid()
        {
            dgvBaoCaoNhanSu.AutoGenerateColumns = false;
            dgvBaoCaoNhanSu.Columns.Clear();
            dgvBaoCaoNhanSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", FillWeight = 70, MinimumWidth = 80 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", FillWeight = 135, MinimumWidth = 120 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày sinh", DataPropertyName = "NgaySinh", FillWeight = 85, MinimumWidth = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giới tính", DataPropertyName = "GioiTinhText", FillWeight = 60, MinimumWidth = 70 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SĐT", DataPropertyName = "SoDienThoai", FillWeight = 95, MinimumWidth = 95 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Email", DataPropertyName = "Email", FillWeight = 145, MinimumWidth = 130 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phòng ban", DataPropertyName = "TenPhongBan", FillWeight = 110, MinimumWidth = 110 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chức vụ", DataPropertyName = "TenChucVu", FillWeight = 100, MinimumWidth = 100 });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày vào làm", DataPropertyName = "NgayVaoLam", FillWeight = 90, MinimumWidth = 95, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lương cơ bản", DataPropertyName = "LuongCoBan", FillWeight = 95, MinimumWidth = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvBaoCaoNhanSu.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Đang làm việc", DataPropertyName = "DangLamViec", FillWeight = 75, MinimumWidth = 85 });

            dgvBaoCaoNhanSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCaoNhanSu.ReadOnly = true;
            dgvBaoCaoNhanSu.AllowUserToAddRows = false;
        }

        private void TaiPhongBan()
        {
            using var db = new AppDbContext();

            var ds = db.PhongBans
                .AsNoTracking()
                .OrderBy(x => x.TenPhongBan)
                .Select(x => new
                {
                    x.Id,
                    x.TenPhongBan
                })
                .ToList();

            ds.Insert(0, new { Id = 0, TenPhongBan = "-- Tất cả --" });

            cboPhongBan.DataSource = ds;
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";
            cboPhongBan.SelectedIndex = 0;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            int phongBanId = Convert.ToInt32(cboPhongBan.SelectedValue ?? 0);
            bool? dangLamViec = null;

            if (cboTrangThaiLamViec.Text == "Đang làm việc")
            {
                dangLamViec = true;
            }
            else if (cboTrangThaiLamViec.Text == "Đã nghỉ")
            {
                dangLamViec = false;
            }

            var query = db.NhanViens
                .AsNoTracking()
                .Include(x => x.PhongBan)
                .Include(x => x.ChucVu)
                .AsQueryable();

            if (phongBanId > 0)
            {
                query = query.Where(x => x.PhongBanId == phongBanId);
            }

            if (dangLamViec.HasValue)
            {
                query = query.Where(x => x.DangLamViec == dangLamViec.Value);
            }

            string tuKhoa = txtTuKhoa.Text.Trim();
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(x =>
                    x.MaNhanVien.Contains(tuKhoa) ||
                    x.HoTen.Contains(tuKhoa) ||
                    x.SoDienThoai.Contains(tuKhoa) ||
                    (x.Email != null && x.Email.Contains(tuKhoa)));
            }

            var ds = query
                .OrderBy(x => x.HoTen)
                .Select(x => new ReportRow
                {
                    MaNhanVien = x.MaNhanVien,
                    HoTen = x.HoTen,
                    NgaySinh = x.NgaySinh,
                    GioiTinhText = x.GioiTinh ? "Nam" : "Nữ",
                    SoDienThoai = x.SoDienThoai,
                    Email = x.Email,
                    TenPhongBan = x.PhongBan != null ? x.PhongBan.TenPhongBan : string.Empty,
                    TenChucVu = x.ChucVu != null ? x.ChucVu.TenChucVu : string.Empty,
                    NgayVaoLam = x.NgayVaoLam,
                    LuongCoBan = x.LuongCoBan,
                    DangLamViec = x.DangLamViec
                })
                .ToList();

            _duLieuHienTai = ds;
            _gridHelper?.ApplyData(ds);
            lblTong.Text = $"Tổng số nhân viên: {ds.Count}";
            CapNhatTomTatTuDong();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnTomTatAI_Click(object sender, EventArgs e)
        {
            CapNhatTomTatTuDong();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            CsvExportHelper.Export(
                _duLieuHienTai,
                $"bao_cao_nhan_su_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                new Dictionary<string, string>
                {
                    ["MaNhanVien"] = "Ma NV",
                    ["HoTen"] = "Ho ten",
                    ["NgaySinh"] = "Ngay sinh",
                    ["GioiTinhText"] = "Gioi tinh",
                    ["SoDienThoai"] = "So dien thoai",
                    ["Email"] = "Email",
                    ["TenPhongBan"] = "Phong ban",
                    ["TenChucVu"] = "Chuc vu",
                    ["NgayVaoLam"] = "Ngay vao lam",
                    ["LuongCoBan"] = "Luong co ban",
                    ["DangLamViec"] = "Dang lam viec"
                });
        }

        private void CapNhatTomTatTuDong()
        {
            if (_duLieuHienTai.Count == 0)
            {
                lblTomTatBody.Text = "Khong co du lieu nhan su phu hop voi bo loc hien tai de sinh tom tat tu dong.";
                return;
            }

            int tongNhanVien = _duLieuHienTai.Count;
            int dangLam = _duLieuHienTai.Count(x => x.DangLamViec);
            int daNghi = tongNhanVien - dangLam;
            decimal luongTrungBinh = _duLieuHienTai.Average(x => x.LuongCoBan);

            var phongBanDongNhat = _duLieuHienTai
                .GroupBy(x => x.TenPhongBan)
                .Select(x => new { TenPhongBan = x.Key, SoLuong = x.Count() })
                .OrderByDescending(x => x.SoLuong)
                .FirstOrDefault();

            var chucVuPhoBien = _duLieuHienTai
                .GroupBy(x => x.TenChucVu)
                .Select(x => new { TenChucVu = x.Key, SoLuong = x.Count() })
                .OrderByDescending(x => x.SoLuong)
                .FirstOrDefault();

            var nhanSuMoi = _duLieuHienTai
                .OrderByDescending(x => x.NgayVaoLam)
                .Take(3)
                .Select(x => $"{x.HoTen} ({x.MaNhanVien})")
                .ToList();

            var sb = new StringBuilder();
            sb.Append($"Tom tat tu dong: Hien co {tongNhanVien} nhan vien trong bao cao, trong do {dangLam} dang lam viec va {daNghi} da nghi. ");

            if (phongBanDongNhat != null)
            {
                sb.Append($"Phong ban dong nhat la {phongBanDongNhat.TenPhongBan} voi {phongBanDongNhat.SoLuong} nhan su. ");
            }

            if (chucVuPhoBien != null)
            {
                sb.Append($"Chuc vu pho bien nhat la {chucVuPhoBien.TenChucVu}. ");
            }

            sb.Append($"Luong co ban trung binh dat {luongTrungBinh:N0} VND. ");

            if (nhanSuMoi.Count > 0)
            {
                sb.Append($"Nhan su vao lam gan day nhat: {string.Join(", ", nhanSuMoi)}.");
            }

            lblTomTatBody.Text = sb.ToString();
        }
    }
}
