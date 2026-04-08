using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DonTu
{
    public partial class FrmDonNghiPhep : Form
    {
        private int _idDangChon;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmDonNghiPhep()
        {
            InitializeComponent();
        }

        private void FrmDonNghiPhep_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvDonNghiPhep);
            TaiNhanVien();
            TaiLoaiNghi();
            TaiDuLieu();
            LamMoi();
            _gridHelper?.RefreshLayout();
            Resize += (_, _) => _gridHelper?.RefreshLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            pnlThongTin.BackColor = ThemeHelper.CardBackColor;
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblMoTa.ForeColor = ThemeHelper.TextSecondary;

            ThemeHelper.ApplyInput(cboNhanVien);
            ThemeHelper.ApplyInput(cboLoaiNghi);
            ThemeHelper.ApplyInput(dtpTuNgay);
            ThemeHelper.ApplyInput(dtpDenNgay);
            ThemeHelper.ApplyInput(nudTongSoNgay);
            ThemeHelper.ApplyInput(txtLyDo);
            ThemeHelper.ApplyInput(cboTrangThai);

            ThemeHelper.ApplySecondaryButton(btnTinhSoNgay);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplyPrimaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvDonNghiPhep);
        }

        private void CaiDatGrid()
        {
            dgvDonNghiPhep.AutoGenerateColumns = false;
            dgvDonNghiPhep.Columns.Clear();

            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNhanVien", HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 90 });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 170 });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLoaiNghi", HeaderText = "Loại nghỉ", DataPropertyName = "TenLoaiNghi", Width = 140 });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "TuNgay", HeaderText = "Từ ngày", DataPropertyName = "TuNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "DenNgay", HeaderText = "Đến ngày", DataPropertyName = "DenNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongSoNgay", HeaderText = "Số ngày", DataPropertyName = "TongSoNgay", Width = 80 });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "LyDo", HeaderText = "Lý do", DataPropertyName = "LyDo", Width = 200 });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "NhanVienId", DataPropertyName = "NhanVienId", Visible = false });
            dgvDonNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "LoaiNghiPhepId", DataPropertyName = "LoaiNghiPhepId", Visible = false });

            dgvDonNghiPhep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonNghiPhep.MultiSelect = false;
            dgvDonNghiPhep.ReadOnly = true;
            dgvDonNghiPhep.AllowUserToAddRows = false;
            dgvDonNghiPhep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void TaiNhanVien()
        {
            using var db = new AppDbContext();
            var ds = db.NhanViens
                .AsNoTracking()
                .Where(x => x.DangLamViec)
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.Id,
                    HienThi = x.MaNhanVien + " - " + x.HoTen
                })
                .ToList();

            cboNhanVien.DataSource = ds;
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "Id";
            cboNhanVien.SelectedIndex = -1;
        }

        private void TaiLoaiNghi()
        {
            using var db = new AppDbContext();
            var ds = db.LoaiNghiPheps
                .AsNoTracking()
                .OrderBy(x => x.TenLoaiNghi)
                .ToList();

            cboLoaiNghi.DataSource = ds;
            cboLoaiNghi.DisplayMember = "TenLoaiNghi";
            cboLoaiNghi.ValueMember = "Id";
            cboLoaiNghi.SelectedIndex = -1;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            var ds = db.DonNghiPheps
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Include(x => x.LoaiNghiPhep)
                .OrderByDescending(x => x.TuNgay)
                .Select(x => new
                {
                    x.Id,
                    x.NhanVienId,
                    x.LoaiNghiPhepId,
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    TenLoaiNghi = x.LoaiNghiPhep != null ? x.LoaiNghiPhep.TenLoaiNghi : "",
                    x.TuNgay,
                    x.DenNgay,
                    x.TongSoNgay,
                    x.LyDo,
                    x.TrangThai
                })
                .ToList();

            _gridHelper?.ApplyData(ds);
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            cboNhanVien.SelectedIndex = -1;
            cboLoaiNghi.SelectedIndex = -1;
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            nudTongSoNgay.Value = 1;
            txtLyDo.Clear();
            cboTrangThai.SelectedIndex = 0;
        }

        private bool KiemTraDuLieu()
        {
            if (cboNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return false;
            }

            if (cboLoaiNghi.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại nghỉ!");
                return false;
            }

            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                MessageBox.Show("Đến ngày phải lớn hơn hoặc bằng từ ngày!");
                return false;
            }

            if (nudTongSoNgay.Value <= 0)
            {
                MessageBox.Show("Tổng số ngày phải lớn hơn 0!");
                return false;
            }

            return true;
        }

        private void btnTinhSoNgay_Click(object sender, EventArgs e)
        {
            int soNgay = (dtpDenNgay.Value.Date - dtpTuNgay.Value.Date).Days + 1;
            nudTongSoNgay.Value = soNgay > 0 ? soNgay : 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            db.DonNghiPheps.Add(new DonNghiPhep
            {
                NhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue),
                LoaiNghiPhepId = Convert.ToInt32(cboLoaiNghi.SelectedValue),
                TuNgay = dtpTuNgay.Value.Date,
                DenNgay = dtpDenNgay.Value.Date,
                TongSoNgay = nudTongSoNgay.Value,
                LyDo = txtLyDo.Text.Trim(),
                TrangThai = cboTrangThai.Text,
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Thêm đơn nghỉ phép thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn cần sửa!");
                return;
            }

            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            var don = db.DonNghiPheps.FirstOrDefault(x => x.Id == _idDangChon);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn nghỉ phép!");
                return;
            }

            don.NhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            don.LoaiNghiPhepId = Convert.ToInt32(cboLoaiNghi.SelectedValue);
            don.TuNgay = dtpTuNgay.Value.Date;
            don.DenNgay = dtpDenNgay.Value.Date;
            don.TongSoNgay = nudTongSoNgay.Value;
            don.LyDo = txtLyDo.Text.Trim();
            don.TrangThai = cboTrangThai.Text;
            don.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cập nhật đơn nghỉ phép thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            using var db = new AppDbContext();

            var don = db.DonNghiPheps.FirstOrDefault(x => x.Id == _idDangChon);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn nghỉ phép!");
                return;
            }

            db.DonNghiPheps.Remove(don);
            db.SaveChanges();

            MessageBox.Show("Xóa đơn nghỉ phép thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvDonNghiPhep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvDonNghiPhep.Rows[e.RowIndex].Cells["Id"].Value);

            using var db = new AppDbContext();
            var don = db.DonNghiPheps.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (don == null) return;

            _idDangChon = don.Id;
            cboNhanVien.SelectedValue = don.NhanVienId;
            cboLoaiNghi.SelectedValue = don.LoaiNghiPhepId;
            dtpTuNgay.Value = don.TuNgay;
            dtpDenNgay.Value = don.DenNgay;
            nudTongSoNgay.Value = don.TongSoNgay;
            txtLyDo.Text = don.LyDo;
            cboTrangThai.Text = don.TrangThai;
        }
    }
}
