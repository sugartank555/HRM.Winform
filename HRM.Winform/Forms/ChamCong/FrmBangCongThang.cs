using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.ChamCong
{
    public partial class FrmBangCongThang : Form
    {
        private HRM.Winform.Helpers.DataGridSearchPaginationHelper? _gridHelper;

        public FrmBangCongThang()
        {
            InitializeComponent();
        }

        private void FrmBangCongThang_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            _gridHelper ??= new HRM.Winform.Helpers.DataGridSearchPaginationHelper(dgvBangCongThang);
            nudThang.Value = DateTime.Today.Month;
            nudNam.Value = DateTime.Today.Year;
            TaiDuLieu();
        }

        private void CaiDatGrid()
        {
            dgvBangCongThang.AutoGenerateColumns = false;
            dgvBangCongThang.Columns.Clear();
            dgvBangCongThang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBangCongThang.Columns.Add(TaoCot("Mã NV", "MaNhanVien", 70));
            dgvBangCongThang.Columns.Add(TaoCot("Họ tên", "HoTen", 130));
            dgvBangCongThang.Columns.Add(TaoCot("Số ngày công", "SoNgayCong", 80));
            dgvBangCongThang.Columns.Add(TaoCot("Tổng giờ làm", "TongSoGioLam", 85));
            dgvBangCongThang.Columns.Add(TaoCot("Tổng tăng ca", "TongTangCa", 80));
            dgvBangCongThang.Columns.Add(TaoCot("Tổng phút đi muộn", "TongDiMuon", 95));
            dgvBangCongThang.Columns.Add(TaoCot("Tổng phút về sớm", "TongVeSom", 95));
            dgvBangCongThang.Columns.Add(TaoCot("Số ngày vắng", "SoNgayVang", 80));
            dgvBangCongThang.Columns.Add(TaoCot("Số ngày nghỉ phép", "SoNgayNghiPhep", 90));

            dgvBangCongThang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangCongThang.ReadOnly = true;
            dgvBangCongThang.AllowUserToAddRows = false;
        }

        private static DataGridViewTextBoxColumn TaoCot(string header, string property, int weight)
        {
            return new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                FillWeight = weight,
                MinimumWidth = 75
            };
        }

        private void TaiDuLieu()
        {
            int thang = (int)nudThang.Value;
            int nam = (int)nudNam.Value;

            using var db = new AppDbContext();

            var ds = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Where(x => x.NgayLamViec.Month == thang && x.NgayLamViec.Year == nam)
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
                    TongVeSom = g.Sum(x => x.SoPhutVeSom),
                    SoNgayVang = g.Count(x => x.TrangThai == "Vang"),
                    SoNgayNghiPhep = g.Count(x => x.TrangThai == "NghiPhep")
                })
                .OrderBy(x => x.HoTen)
                .ToList();

            _gridHelper?.ApplyData(ds);
            lblTong.Text = $"Tổng số nhân viên: {ds.Count}";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }
    }
}
