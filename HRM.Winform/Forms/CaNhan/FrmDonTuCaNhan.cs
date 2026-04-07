using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.CaNhan
{
    public partial class FrmDonTuCaNhan : Form
    {
        private DataGridSearchPaginationHelper? _nghiPhepGridHelper;
        private DataGridSearchPaginationHelper? _tangCaGridHelper;

        public FrmDonTuCaNhan()
        {
            InitializeComponent();
        }

        private void FrmDonTuCaNhan_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            TaiLoaiNghi();
            TaiTrangThaiMacDinh();
            nudTongSoNgay.Value = 1;
            TaiDanhSach();
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            pnlTop.BackColor = Color.White;

            btnGuiNghiPhep.BackColor = Color.FromArgb(37, 99, 235);
            btnGuiNghiPhep.ForeColor = Color.White;
            btnGuiNghiPhep.FlatStyle = FlatStyle.Flat;
            btnGuiNghiPhep.FlatAppearance.BorderSize = 0;

            btnGuiTangCa.BackColor = Color.FromArgb(5, 150, 105);
            btnGuiTangCa.ForeColor = Color.White;
            btnGuiTangCa.FlatStyle = FlatStyle.Flat;
            btnGuiTangCa.FlatAppearance.BorderSize = 0;

            btnGuiDieuChinh.BackColor = Color.White;
            btnGuiDieuChinh.ForeColor = Color.FromArgb(37, 99, 235);
            btnGuiDieuChinh.FlatStyle = FlatStyle.Flat;
            btnGuiDieuChinh.FlatAppearance.BorderSize = 1;
            btnGuiDieuChinh.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);

            ConfigureGrid(dgvNghiPhep);
            dgvNghiPhep.Columns.Clear();
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tu ngay", DataPropertyName = "TuNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Den ngay", DataPropertyName = "DenNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loai nghi", DataPropertyName = "TenLoaiNghi", Width = 150 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "So ngay", DataPropertyName = "TongSoNgay", Width = 90 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trang thai", DataPropertyName = "TrangThai", Width = 110 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ly do", DataPropertyName = "LyDo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            ConfigureGrid(dgvTangCa);
            dgvTangCa.Columns.Clear();
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngay lam", DataPropertyName = "NgayLam", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tu gio", DataPropertyName = "TuGio", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Den gio", DataPropertyName = "DenGio", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tong gio", DataPropertyName = "TongSoGio", Width = 90 });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trang thai", DataPropertyName = "TrangThai", Width = 110 });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ly do", DataPropertyName = "LyDo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            _nghiPhepGridHelper ??= new DataGridSearchPaginationHelper(dgvNghiPhep);
            _tangCaGridHelper ??= new DataGridSearchPaginationHelper(dgvTangCa);
        }

        private static void ConfigureGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void TaiLoaiNghi()
        {
            using var db = new AppDbContext();
            cboLoaiNghi.DataSource = db.LoaiNghiPheps.AsNoTracking().OrderBy(x => x.TenLoaiNghi).ToList();
            cboLoaiNghi.DisplayMember = "TenLoaiNghi";
            cboLoaiNghi.ValueMember = "Id";
            cboLoaiNghi.SelectedIndex = -1;
        }

        private void TaiTrangThaiMacDinh()
        {
            cboTrangThaiNghi.Items.Clear();
            cboTrangThaiNghi.Items.Add("ChoDuyet");
            cboTrangThaiNghi.SelectedIndex = 0;
            cboTrangThaiNghi.Enabled = false;

            cboTrangThaiTangCa.Items.Clear();
            cboTrangThaiTangCa.Items.Add("ChoDuyet");
            cboTrangThaiTangCa.SelectedIndex = 0;
            cboTrangThaiTangCa.Enabled = false;
        }

        private void TaiDanhSach()
        {
            using var db = new AppDbContext();

            var dsNghiPhep = db.DonNghiPheps
                .AsNoTracking()
                .Include(x => x.LoaiNghiPhep)
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId)
                .OrderByDescending(x => x.TuNgay)
                .Select(x => new
                {
                    x.TuNgay,
                    x.DenNgay,
                    TenLoaiNghi = x.LoaiNghiPhep != null ? x.LoaiNghiPhep.TenLoaiNghi : "",
                    x.TongSoNgay,
                    x.TrangThai,
                    x.LyDo
                })
                .ToList();

            var dsTangCa = db.DonTangCas
                .AsNoTracking()
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId)
                .OrderByDescending(x => x.NgayLam)
                .Select(x => new
                {
                    x.NgayLam,
                    x.TuGio,
                    x.DenGio,
                    x.TongSoGio,
                    x.TrangThai,
                    x.LyDo
                })
                .ToList();

            _nghiPhepGridHelper?.ApplyData(dsNghiPhep);
            _tangCaGridHelper?.ApplyData(dsTangCa);

            lblTongDonNghi.Text = dsNghiPhep.Count.ToString();
            lblTongDonTangCa.Text = dsTangCa.Count.ToString();
        }

        private void btnGuiNghiPhep_Click(object sender, EventArgs e)
        {
            if (cboLoaiNghi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui long chon loai nghi.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDenNgayNghi.Value.Date < dtpTuNgayNghi.Value.Date)
            {
                MessageBox.Show("Den ngay phai lon hon hoac bang tu ngay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            db.DonNghiPheps.Add(new DonNghiPhep
            {
                NhanVienId = CurrentUser.NhanVienId,
                LoaiNghiPhepId = Convert.ToInt32(cboLoaiNghi.SelectedValue),
                TuNgay = dtpTuNgayNghi.Value.Date,
                DenNgay = dtpDenNgayNghi.Value.Date,
                TongSoNgay = nudTongSoNgay.Value,
                LyDo = txtLyDoNghi.Text.Trim(),
                TrangThai = "ChoDuyet",
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Da gui don nghi phep.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLyDoNghi.Clear();
            nudTongSoNgay.Value = 1;
            TaiDanhSach();
        }

        private void btnGuiTangCa_Click(object sender, EventArgs e)
        {
            if (dtpDenGioTangCa.Value <= dtpTuGioTangCa.Value)
            {
                MessageBox.Show("Den gio phai lon hon tu gio.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            db.DonTangCas.Add(new DonTangCa
            {
                NhanVienId = CurrentUser.NhanVienId,
                NgayLam = dtpNgayTangCa.Value.Date,
                TuGio = dtpTuGioTangCa.Value,
                DenGio = dtpDenGioTangCa.Value,
                TongSoGio = Math.Round((dtpDenGioTangCa.Value - dtpTuGioTangCa.Value).TotalHours, 2),
                LyDo = txtLyDoTangCa.Text.Trim(),
                TrangThai = "ChoDuyet",
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Da gui don tang ca.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLyDoTangCa.Clear();
            TaiDanhSach();
        }

        private void btnGuiDieuChinh_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Luong giao dien dieu chinh cong da duoc dat san.\n\nDe luu xuong CSDL, buoc tiep theo can them bang DonDieuChinhCong va man duyet tuong ung.",
                "Dieu chinh cong",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnTinhSoNgay_Click(object sender, EventArgs e)
        {
            var soNgay = (dtpDenNgayNghi.Value.Date - dtpTuNgayNghi.Value.Date).Days + 1;
            nudTongSoNgay.Value = soNgay > 0 ? soNgay : 1;
        }
    }
}
