using HRM.Winform.Data;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DanhMuc
{
    public partial class FrmLoaiNghiPhep : Form
    {
        private int _idDangChon = 0;
        private HRM.Winform.Helpers.DataGridSearchPaginationHelper? _gridHelper;

        public FrmLoaiNghiPhep()
        {
            InitializeComponent();
        }

        private void FrmLoaiNghiPhep_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            _gridHelper ??= new HRM.Winform.Helpers.DataGridSearchPaginationHelper(dgvLoaiNghiPhep);
            TaiDuLieu();
            LamMoi();
        }

        private void CaiDatGrid()
        {
            dgvLoaiNghiPhep.AutoGenerateColumns = false;
            dgvLoaiNghiPhep.Columns.Clear();

            dgvLoaiNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvLoaiNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaLoaiNghi", HeaderText = "Mã loại nghỉ", DataPropertyName = "MaLoaiNghi", Width = 150 });
            dgvLoaiNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenLoaiNghi", HeaderText = "Tên loại nghỉ", DataPropertyName = "TenLoaiNghi", Width = 250 });
            dgvLoaiNghiPhep.Columns.Add(new DataGridViewCheckBoxColumn { Name = "HuongLuong", HeaderText = "Hưởng lương", DataPropertyName = "HuongLuong", Width = 100 });
            dgvLoaiNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô tả", DataPropertyName = "MoTa", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvLoaiNghiPhep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiNghiPhep.MultiSelect = false;
            dgvLoaiNghiPhep.ReadOnly = true;
            dgvLoaiNghiPhep.AllowUserToAddRows = false;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();
            _gridHelper?.ApplyData(db.LoaiNghiPheps.AsNoTracking().OrderBy(x => x.Id).ToList());
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            txtMaLoaiNghi.Clear();
            txtTenLoaiNghi.Clear();
            txtMoTa.Clear();
            chkHuongLuong.Checked = true;
            txtMaLoaiNghi.Focus();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiNghi.Text))
            {
                MessageBox.Show("Vui lòng nhập mã loại nghỉ!");
                txtMaLoaiNghi.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLoaiNghi.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại nghỉ!");
                txtTenLoaiNghi.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            if (db.LoaiNghiPheps.Any(x => x.MaLoaiNghi == txtMaLoaiNghi.Text.Trim()))
            {
                MessageBox.Show("Mã loại nghỉ đã tồn tại!");
                return;
            }

            db.LoaiNghiPheps.Add(new LoaiNghiPhep
            {
                MaLoaiNghi = txtMaLoaiNghi.Text.Trim(),
                TenLoaiNghi = txtTenLoaiNghi.Text.Trim(),
                HuongLuong = chkHuongLuong.Checked,
                MoTa = txtMoTa.Text.Trim(),
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Thêm loại nghỉ phép thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn loại nghỉ cần sửa!");
                return;
            }

            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            var loai = db.LoaiNghiPheps.FirstOrDefault(x => x.Id == _idDangChon);
            if (loai == null)
            {
                MessageBox.Show("Không tìm thấy loại nghỉ!");
                return;
            }

            if (db.LoaiNghiPheps.Any(x => x.MaLoaiNghi == txtMaLoaiNghi.Text.Trim() && x.Id != _idDangChon))
            {
                MessageBox.Show("Mã loại nghỉ đã tồn tại!");
                return;
            }

            loai.MaLoaiNghi = txtMaLoaiNghi.Text.Trim();
            loai.TenLoaiNghi = txtTenLoaiNghi.Text.Trim();
            loai.HuongLuong = chkHuongLuong.Checked;
            loai.MoTa = txtMoTa.Text.Trim();
            loai.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cập nhật loại nghỉ phép thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn loại nghỉ cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa loại nghỉ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes) return;

            using var db = new AppDbContext();

            var loai = db.LoaiNghiPheps
                .Include(x => x.DanhSachDonNghiPhep)
                .FirstOrDefault(x => x.Id == _idDangChon);

            if (loai == null)
            {
                MessageBox.Show("Không tìm thấy loại nghỉ!");
                return;
            }

            if (loai.DanhSachDonNghiPhep.Any())
            {
                MessageBox.Show("Loại nghỉ đã phát sinh dữ liệu, không thể xóa!");
                return;
            }

            db.LoaiNghiPheps.Remove(loai);
            db.SaveChanges();

            MessageBox.Show("Xóa loại nghỉ phép thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvLoaiNghiPhep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvLoaiNghiPhep.Rows[e.RowIndex];
            _idDangChon = Convert.ToInt32(row.Cells["Id"].Value);
            txtMaLoaiNghi.Text = row.Cells["MaLoaiNghi"].Value?.ToString() ?? "";
            txtTenLoaiNghi.Text = row.Cells["TenLoaiNghi"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
            chkHuongLuong.Checked = Convert.ToBoolean(row.Cells["HuongLuong"].Value ?? true);
        }
    }
}
