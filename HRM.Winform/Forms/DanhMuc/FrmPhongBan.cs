using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DanhMuc
{
    public partial class FrmPhongBan : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmPhongBan()
        {
            InitializeComponent();
        }

        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvPhongBan);
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
            ThemeHelper.ApplyInput(txtMaPhongBan);
            ThemeHelper.ApplyInput(txtTenPhongBan);
            ThemeHelper.ApplyInput(txtMoTa);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplySecondaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvPhongBan);
        }

        private void CaiDatGrid()
        {
            dgvPhongBan.AutoGenerateColumns = false;
            dgvPhongBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhongBan.Columns.Clear();
            dgvPhongBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", DataPropertyName = "Id", Visible = false });
            dgvPhongBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaPhongBan", HeaderText = "Mã phòng ban", DataPropertyName = "MaPhongBan", FillWeight = 100, MinimumWidth = 120 });
            dgvPhongBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenPhongBan", HeaderText = "Tên phòng ban", DataPropertyName = "TenPhongBan", FillWeight = 140, MinimumWidth = 160 });
            dgvPhongBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "MoTa", HeaderText = "Mô tả", DataPropertyName = "MoTa", FillWeight = 180, MinimumWidth = 180 });
            dgvPhongBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhongBan.MultiSelect = false;
            dgvPhongBan.ReadOnly = true;
            dgvPhongBan.AllowUserToAddRows = false;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();
            var ds = db.PhongBans.AsNoTracking().OrderBy(x => x.Id).ToList();
            _gridHelper?.ApplyData(ds);
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            txtMaPhongBan.Clear();
            txtTenPhongBan.Clear();
            txtMoTa.Clear();
            txtMaPhongBan.Focus();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhongBan.Text)) { MessageBox.Show("Vui lòng nhập mã phòng ban!"); txtMaPhongBan.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtTenPhongBan.Text)) { MessageBox.Show("Vui lòng nhập tên phòng ban!"); txtTenPhongBan.Focus(); return false; }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;
            using var db = new AppDbContext();
            string ma = txtMaPhongBan.Text.Trim();
            if (db.PhongBans.Any(x => x.MaPhongBan == ma)) { MessageBox.Show("Mã phòng ban đã tồn tại!"); txtMaPhongBan.Focus(); return; }
            var phongBan = new PhongBan
            {
                MaPhongBan = txtMaPhongBan.Text.Trim(),
                TenPhongBan = txtTenPhongBan.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                NgayTao = DateTime.Now
            };
            db.PhongBans.Add(phongBan);
            db.SaveChanges();
            MessageBox.Show("Thêm phòng ban thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0) { MessageBox.Show("Vui lòng chọn phòng ban cần sửa!"); return; }
            if (!KiemTraDuLieu()) return;
            using var db = new AppDbContext();
            var phongBan = db.PhongBans.FirstOrDefault(x => x.Id == _idDangChon);
            if (phongBan == null) { MessageBox.Show("Không tìm thấy phòng ban!"); return; }
            string ma = txtMaPhongBan.Text.Trim();
            if (db.PhongBans.Any(x => x.MaPhongBan == ma && x.Id != _idDangChon)) { MessageBox.Show("Mã phòng ban đã tồn tại!"); txtMaPhongBan.Focus(); return; }
            phongBan.MaPhongBan = txtMaPhongBan.Text.Trim();
            phongBan.TenPhongBan = txtTenPhongBan.Text.Trim();
            phongBan.MoTa = txtMoTa.Text.Trim();
            phongBan.NgayCapNhat = DateTime.Now;
            db.SaveChanges();
            MessageBox.Show("Cập nhật phòng ban thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0) { MessageBox.Show("Vui lòng chọn phòng ban cần xóa!"); return; }
            if (MessageBox.Show("Bạn có chắc muốn xóa phòng ban này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            using var db = new AppDbContext();
            var phongBan = db.PhongBans.Include(x => x.DanhSachNhanVien).FirstOrDefault(x => x.Id == _idDangChon);
            if (phongBan == null) { MessageBox.Show("Không tìm thấy phòng ban!"); return; }
            if (phongBan.DanhSachNhanVien.Any()) { MessageBox.Show("Phòng ban đang có nhân viên, không thể xóa!"); return; }
            db.PhongBans.Remove(phongBan);
            db.SaveChanges();
            MessageBox.Show("Xóa phòng ban thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void dgvPhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvPhongBan.Rows[e.RowIndex];
            _idDangChon = Convert.ToInt32(row.Cells["Id"].Value);
            txtMaPhongBan.Text = row.Cells["MaPhongBan"].Value?.ToString() ?? "";
            txtTenPhongBan.Text = row.Cells["TenPhongBan"].Value?.ToString() ?? "";
            txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";
        }
    }
}
