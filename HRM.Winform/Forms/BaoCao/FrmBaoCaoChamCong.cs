using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;

using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.BaoCao
{
    public partial class FrmBaoCaoChamCong : Form
    {
        private List<AttendanceReportRow> _duLieuHienTai = [];
        private DataGridSearchPaginationHelper? _gridHelper;

        private sealed class AttendanceReportRow
        {
            public string MaNhanVien { get; set; } = string.Empty;
            public string HoTen { get; set; } = string.Empty;
            public int SoNgayCong { get; set; }
            public double TongSoGioLam { get; set; }
            public double TongTangCa { get; set; }
            public int TongDiMuon { get; set; }
            public int TongVeSom { get; set; }
            public int SoNgayVang { get; set; }
            public int SoNgayNghiPhep { get; set; }
        }

        public FrmBaoCaoChamCong()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoChamCong_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvBaoCaoChamCong);
            TaiNhanVien();
            nudThang.Value = DateTime.Today.Month;
            nudNam.Value = DateTime.Today.Year;
            TaiDuLieu();
            _gridHelper?.RefreshLayout();
            Resize += (_, _) => _gridHelper?.RefreshLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblMoTa.ForeColor = ThemeHelper.TextSecondary;
            lblTong.ForeColor = ThemeHelper.TextPrimary;
            ThemeHelper.ApplyCard(pnlLoc);
            ThemeHelper.ApplySecondaryButton(btnXem);
            ThemeHelper.ApplyPrimaryButton(btnXuatExcel);
            ThemeHelper.ApplyInput(cboNhanVien);
            ThemeHelper.ApplyDataGrid(dgvBaoCaoChamCong);
        }

        private void CaiDatGrid()
        {
            dgvBaoCaoChamCong.AutoGenerateColumns = false;
            dgvBaoCaoChamCong.Columns.Clear();

            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 90 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 170 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số ngày công", DataPropertyName = "SoNgayCong", Width = 100 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng giờ làm", DataPropertyName = "TongSoGioLam", Width = 100 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tăng ca", DataPropertyName = "TongTangCa", Width = 90 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đi muộn", DataPropertyName = "TongDiMuon", Width = 90 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Về sớm", DataPropertyName = "TongVeSom", Width = 90 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số ngày vắng", DataPropertyName = "SoNgayVang", Width = 100 });
            dgvBaoCaoChamCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số ngày nghỉ phép", DataPropertyName = "SoNgayNghiPhep", Width = 120 });

            dgvBaoCaoChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCaoChamCong.ReadOnly = true;
            dgvBaoCaoChamCong.AllowUserToAddRows = false;
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

            ds.Insert(0, new { Id = 0, HienThi = "-- Tất cả --" });

            cboNhanVien.DataSource = ds;
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "Id";
            cboNhanVien.SelectedIndex = 0;
        }

        private void TaiDuLieu()
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;
            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue ?? 0);

            using var db = new AppDbContext();

            var query = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Where(x => x.NgayLamViec.Month == thang && x.NgayLamViec.Year == nam);

            if (nhanVienId > 0)
                query = query.Where(x => x.NhanVienId == nhanVienId);

            var ds = query
                .GroupBy(x => new
                {
                    x.NhanVienId,
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : ""
                })
                .Select(g => new AttendanceReportRow
                {
                    MaNhanVien = g.Key.MaNhanVien,
                    HoTen = g.Key.HoTen,
                    SoNgayCong = g.Count(x => x.TrangThai != "Vang"),
                    TongSoGioLam = g.Sum(x => x.SoGioLam),
                    TongTangCa = g.Sum(x => x.SoGioTangCa),
                    TongDiMuon = g.Sum(x => x.SoPhutDiMuon),
                    TongVeSom = g.Sum(x => x.SoPhutVeSom),
                    SoNgayVang = g.Count(x => x.TrangThai == "Vang"),
                    SoNgayNghiPhep = g.Count(x => x.TrangThai == "NghiPhep")
                })
                .OrderBy(x => x.HoTen)
                .ToList();

            _duLieuHienTai = ds;
            _gridHelper?.ApplyData(ds);
            lblTong.Text = $"Tổng số nhân viên: {ds.Count}";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            CsvExportHelper.Export(
                _duLieuHienTai,
                $"bao_cao_cham_cong_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                new Dictionary<string, string>
                {
                    ["MaNhanVien"] = "Ma NV",
                    ["HoTen"] = "Ho ten",
                    ["SoNgayCong"] = "So ngay cong",
                    ["TongSoGioLam"] = "Tong gio lam",
                    ["TongTangCa"] = "Tong tang ca",
                    ["TongDiMuon"] = "Tong di muon",
                    ["TongVeSom"] = "Tong ve som",
                    ["SoNgayVang"] = "So ngay vang",
                    ["SoNgayNghiPhep"] = "So ngay nghi phep"
                });
        }
    }
}
