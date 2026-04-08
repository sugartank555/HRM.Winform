using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.BaoCao
{
    public partial class FrmBaoCaoNghiPhep : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmBaoCaoNghiPhep()
        {
            InitializeComponent();
        }

        private void FrmBaoCaoNghiPhep_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvBaoCaoNghiPhep);
            TaiLoaiNghi();
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
            ThemeHelper.ApplyInput(cboLoaiNghi);
            ThemeHelper.ApplyInput(cboTrangThai);
            ThemeHelper.ApplyDataGrid(dgvBaoCaoNghiPhep);
        }

        private void CaiDatGrid()
        {
            dgvBaoCaoNghiPhep.AutoGenerateColumns = false;
            dgvBaoCaoNghiPhep.Columns.Clear();

            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 90 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 170 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại nghỉ", DataPropertyName = "TenLoaiNghi", Width = 140 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Từ ngày", DataPropertyName = "TuNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đến ngày", DataPropertyName = "DenNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số ngày", DataPropertyName = "TongSoNgay", Width = 90 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lý do", DataPropertyName = "LyDo", Width = 180 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người duyệt", DataPropertyName = "NguoiDuyet", Width = 120 });
            dgvBaoCaoNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày duyệt", DataPropertyName = "NgayDuyet", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });

            dgvBaoCaoNghiPhep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCaoNghiPhep.ReadOnly = true;
            dgvBaoCaoNghiPhep.AllowUserToAddRows = false;
        }

        private void TaiLoaiNghi()
        {
            using var db = new AppDbContext();

            var ds = db.LoaiNghiPheps
                .AsNoTracking()
                .OrderBy(x => x.TenLoaiNghi)
                .Select(x => new
                {
                    x.Id,
                    x.TenLoaiNghi
                })
                .ToList();

            ds.Insert(0, new { Id = 0, TenLoaiNghi = "-- Tất cả --" });

            cboLoaiNghi.DataSource = ds;
            cboLoaiNghi.DisplayMember = "TenLoaiNghi";
            cboLoaiNghi.ValueMember = "Id";
            cboLoaiNghi.SelectedIndex = 0;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            int loaiNghiId = Convert.ToInt32(cboLoaiNghi.SelectedValue ?? 0);

            var query = db.DonNghiPheps
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Include(x => x.LoaiNghiPhep)
                .Where(x => x.TuNgay >= tuNgay && x.DenNgay <= denNgay);

            if (loaiNghiId > 0)
                query = query.Where(x => x.LoaiNghiPhepId == loaiNghiId);

            if (cboTrangThai.Text != "-- Tất cả --")
                query = query.Where(x => x.TrangThai == cboTrangThai.Text);

            var ds = query
                .OrderByDescending(x => x.TuNgay)
                .Select(x => new
                {
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    TenLoaiNghi = x.LoaiNghiPhep != null ? x.LoaiNghiPhep.TenLoaiNghi : "",
                    x.TuNgay,
                    x.DenNgay,
                    x.TongSoNgay,
                    x.LyDo,
                    x.TrangThai,
                    x.NguoiDuyet,
                    x.NgayDuyet
                })
                .ToList();

            _gridHelper?.ApplyData(ds);
            lblTong.Text = $"Tổng số đơn: {ds.Count}";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            TaiDuLieu();
        }
    }
}
