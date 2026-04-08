using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DanhMuc
{
    public partial class FrmChucVu : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmChucVu()
        {
            InitializeComponent();
        }

        private void FrmChucVu_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvChucVu);
            TaiDuLieu();
            LamMoi();
            _gridHelper?.RefreshLayout();
            Resize += (_, _) => _gridHelper?.RefreshLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblMoTaForm.ForeColor = ThemeHelper.TextSecondary;
            ThemeHelper.ApplyCard(pnlThongTin);
            ThemeHelper.ApplyInput(txtMaChucVu);
            ThemeHelper.ApplyInput(txtTenChucVu);
            ThemeHelper.ApplyInput(txtMoTa);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplySecondaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvChucVu);
        }

        private void CaiDatGrid()
        {
            dgvChucVu.AutoGenerateColumns = false;
            dgvChucVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChucVu.Columns.Clear();
            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaChucVu", HeaderText = "Mã chức vụ", DataPropertyName = "MaChucVu", FillWeight = 100, MinimumWidth = 120 });
            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenChucVu", HeaderText = "Tên chức vụ", DataPropertyName = "TenChucVu", FillWeight = 140, MinimumWidth = 160 });
            dgvChucVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô tả", DataPropertyName = "MoTa", FillWeight = 180, MinimumWidth = 180 });
            dgvChucVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChucVu.MultiSelect = false;
            dgvChucVu.ReadOnly = true;
            dgvChucVu.AllowUserToAddRows = false;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();
            _gridHelper?.ApplyData(db.ChucVus.AsNoTracking().OrderBy(x => x.Id).ToList());
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            txtMaChucVu.Clear();
            txtTenChucVu.Clear();
            txtMoTa.Clear();
            txtMaChucVu.Focus();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaChucVu.Text)) { MessageBox.Show("Vui lòng nhập mã chức vụ!"); txtMaChucVu.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtTenChucVu.Text)) { MessageBox.Show("Vui lòng nhập tên chức vụ!"); txtTenChucVu.Focus(); return false; }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;
            using var db = new AppDbContext();
            string ma = txtMaChucVu.Text.Trim();
            if (db.ChucVus.Any(x => x.MaChucVu == ma)) { MessageBox.Show("Mã chức vụ đã tồn tại!"); return; }
            db.ChucVus.Add(new ChucVu
            {
                MaChucVu = txtMaChucVu.Text.Trim(),
                TenChucVu = txtTenChucVu.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                NgayTao = DateTime.Now
            });
            db.SaveChanges();
            MessageBox.Show("Thêm chức vụ thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0) { MessageBox.Show("Vui lòng chọn chức vụ cần sửa!"); return; }
            if (!KiemTraDuLieu()) return;
            using var db = new AppDbContext();
            var chucVu = db.ChucVus.FirstOrDefault(x => x.Id == _idDangChon);
            if (chucVu == null) { MessageBox.Show("Không tìm thấy chức vụ!"); return; }
            string ma = txtMaChucVu.Text.Trim();
            if (db.ChucVus.Any(x => x.MaChucVu == ma && x.Id != _idDangChon)) { MessageBox.Show("Mã chức vụ đã tồn tại!"); return; }
            chucVu.MaChucVu = txtMaChucVu.Text.Trim();
            chucVu.TenChucVu = txtTenChucVu.Text.Trim();
            chucVu.MoTa = txtMoTa.Text.Trim();
            chucVu.NgayCapNhat = DateTime.Now;
            db.SaveChanges();
            MessageBox.Show("Cập nhật chức vụ thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0) { MessageBox.Show("Vui lòng chọn chức vụ cần xóa!"); return; }
            if (MessageBox.Show("Bạn có chắc muốn xóa chức vụ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            using var db = new AppDbContext();
            var chucVu = db.ChucVus.Include(x => x.DanhSachNhanVien).FirstOrDefault(x => x.Id == _idDangChon);
            if (chucVu == null) { MessageBox.Show("Không tìm thấy chức vụ!"); return; }
            if (chucVu.DanhSachNhanVien.Any()) { MessageBox.Show("Chức vụ đang có nhân viên, không thể xóa!"); return; }
            db.ChucVus.Remove(chucVu);
            db.SaveChanges();
            MessageBox.Show("Xóa chức vụ thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvChucVu.Rows[e.RowIndex];
            _idDangChon = Convert.ToInt32(row.Cells["Id"].Value);
            txtMaChucVu.Text = row.Cells["MaChucVu"].Value?.ToString() ?? "";
            txtTenChucVu.Text = row.Cells["TenChucVu"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
        }
    }
}
