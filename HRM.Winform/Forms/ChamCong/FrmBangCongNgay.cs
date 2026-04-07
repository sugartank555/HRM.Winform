using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.ChamCong
{
    public partial class FrmBangCongNgay : Form
    {
        private HRM.Winform.Helpers.DataGridSearchPaginationHelper? _gridHelper;

        public FrmBangCongNgay()
        {
            InitializeComponent();
        }

        private void FrmBangCongNgay_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            _gridHelper ??= new HRM.Winform.Helpers.DataGridSearchPaginationHelper(dgvBangCongNgay);
            TaiDuLieu();
        }

        private void CaiDatGrid()
        {
            dgvBangCongNgay.AutoGenerateColumns = false;
            dgvBangCongNgay.Columns.Clear();
            dgvBangCongNgay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBangCongNgay.Columns.Add(TaoCot("Mã NV", "MaNhanVien", 70));
            dgvBangCongNgay.Columns.Add(TaoCot("Họ tên", "HoTen", 120));
            dgvBangCongNgay.Columns.Add(TaoCot("Ca", "TenCa", 90));
            dgvBangCongNgay.Columns.Add(TaoCot("Ngày", "NgayLamViec", 80, "dd/MM/yyyy"));
            dgvBangCongNgay.Columns.Add(TaoCot("CheckIn", "GioCheckIn", 110, "dd/MM/yyyy HH:mm"));
            dgvBangCongNgay.Columns.Add(TaoCot("CheckOut", "GioCheckOut", 110, "dd/MM/yyyy HH:mm"));
            dgvBangCongNgay.Columns.Add(TaoCot("Đi muộn", "SoPhutDiMuon", 70));
            dgvBangCongNgay.Columns.Add(TaoCot("Về sớm", "SoPhutVeSom", 70));
            dgvBangCongNgay.Columns.Add(TaoCot("Giờ làm", "SoGioLam", 70));
            dgvBangCongNgay.Columns.Add(TaoCot("Tăng ca", "SoGioTangCa", 70));
            dgvBangCongNgay.Columns.Add(TaoCot("Trạng thái", "TrangThai", 75));

            dgvBangCongNgay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBangCongNgay.ReadOnly = true;
            dgvBangCongNgay.AllowUserToAddRows = false;
        }

        private static DataGridViewTextBoxColumn TaoCot(string header, string property, int weight, string? format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                FillWeight = weight,
                MinimumWidth = 70
            };

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle = new DataGridViewCellStyle { Format = format };
            }

            return column;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();
            DateTime ngay = dtpNgay.Value.Date;

            var ds = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Include(x => x.CaLamViec)
                .Where(x => x.NgayLamViec == ngay)
                .OrderBy(x => x.NhanVien!.HoTen)
                .Select(x => new
                {
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    TenCa = x.CaLamViec != null ? x.CaLamViec.TenCa : "",
                    x.NgayLamViec,
                    GioCheckIn = x.GioCheckIn,
                    GioCheckOut = x.GioCheckOut,
                    x.SoPhutDiMuon,
                    x.SoPhutVeSom,
                    x.SoGioLam,
                    x.SoGioTangCa,
                    x.TrangThai
                })
                .ToList();

            _gridHelper?.ApplyData(ds);
            lblTong.Text = $"Tổng số dòng: {ds.Count}";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }
    }
}
