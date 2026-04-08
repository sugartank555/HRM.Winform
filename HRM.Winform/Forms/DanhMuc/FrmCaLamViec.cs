using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DanhMuc
{
    public partial class FrmCaLamViec : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmCaLamViec()
        {
            InitializeComponent();
        }

        private void FrmCaLamViec_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvCaLamViec);
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
            ThemeHelper.ApplyInput(txtMaCa);
            ThemeHelper.ApplyInput(txtTenCa);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplySecondaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvCaLamViec);
        }

        private void CaiDatGrid()
        {
            dgvCaLamViec.AutoGenerateColumns = false;
            dgvCaLamViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCaLamViec.Columns.Clear();
            dgvCaLamViec.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvCaLamViec.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaCa", HeaderText = "Mã ca", DataPropertyName = "MaCa", FillWeight = 90, MinimumWidth = 110 });
            dgvCaLamViec.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenCa", HeaderText = "Tên ca", DataPropertyName = "TenCa", FillWeight = 120, MinimumWidth = 130 });
            dgvCaLamViec.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioBatDau", HeaderText = "Giờ bắt đầu", DataPropertyName = "GioBatDau", FillWeight = 90, MinimumWidth = 110 });
            dgvCaLamViec.Columns.Add(new DataGridViewTextBoxColumn { Name = "GioKetThuc", HeaderText = "Giờ kết thúc", DataPropertyName = "GioKetThuc", FillWeight = 90, MinimumWidth = 110 });
            dgvCaLamViec.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoPhutNghi", HeaderText = "Phút nghỉ", DataPropertyName = "SoPhutNghi", FillWeight = 70, MinimumWidth = 90 });
            dgvCaLamViec.Columns.Add(new DataGridViewCheckBoxColumn { Name = "QuaDem", HeaderText = "Qua đêm", DataPropertyName = "QuaDem", FillWeight = 65, MinimumWidth = 80 });
            dgvCaLamViec.Columns.Add(new DataGridViewCheckBoxColumn { Name = "HoatDong", HeaderText = "Hoạt động", DataPropertyName = "HoatDong", FillWeight = 70, MinimumWidth = 90 });
            dgvCaLamViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCaLamViec.MultiSelect = false;
            dgvCaLamViec.ReadOnly = true;
            dgvCaLamViec.AllowUserToAddRows = false;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();
            _gridHelper?.ApplyData(db.CaLamViecs.AsNoTracking().OrderBy(x => x.Id).ToList());
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            txtMaCa.Clear();
            txtTenCa.Clear();
            dtpGioBatDau.Value = DateTime.Today.AddHours(8);
            dtpGioKetThuc.Value = DateTime.Today.AddHours(17);
            nudSoPhutNghi.Value = 60;
            nudDiMuon.Value = 5;
            nudVeSom.Value = 5;
            chkQuaDem.Checked = false;
            chkHoatDong.Checked = true;
            txtMaCa.Focus();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaCa.Text)) { MessageBox.Show("Vui lòng nhập mã ca!"); txtMaCa.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtTenCa.Text)) { MessageBox.Show("Vui lòng nhập tên ca!"); txtTenCa.Focus(); return false; }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;
            using var db = new AppDbContext();
            if (db.CaLamViecs.Any(x => x.MaCa == txtMaCa.Text.Trim())) { MessageBox.Show("Mã ca đã tồn tại!"); return; }
            db.CaLamViecs.Add(new CaLamViec
            {
                MaCa = txtMaCa.Text.Trim(),
                TenCa = txtTenCa.Text.Trim(),
                GioBatDau = dtpGioBatDau.Value.TimeOfDay,
                GioKetThuc = dtpGioKetThuc.Value.TimeOfDay,
                SoPhutNghi = (int)nudSoPhutNghi.Value,
                SoPhutChoPhepDiMuon = (int)nudDiMuon.Value,
                SoPhutChoPhepVeSom = (int)nudVeSom.Value,
                QuaDem = chkQuaDem.Checked,
                HoatDong = chkHoatDong.Checked,
                NgayTao = DateTime.Now
            });
            db.SaveChanges();
            MessageBox.Show("Thêm ca làm việc thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0) { MessageBox.Show("Vui lòng chọn ca làm việc cần sửa!"); return; }
            if (!KiemTraDuLieu()) return;
            using var db = new AppDbContext();
            var ca = db.CaLamViecs.FirstOrDefault(x => x.Id == _idDangChon);
            if (ca == null) { MessageBox.Show("Không tìm thấy ca làm việc!"); return; }
            if (db.CaLamViecs.Any(x => x.MaCa == txtMaCa.Text.Trim() && x.Id != _idDangChon)) { MessageBox.Show("Mã ca đã tồn tại!"); return; }
            ca.MaCa = txtMaCa.Text.Trim();
            ca.TenCa = txtTenCa.Text.Trim();
            ca.GioBatDau = dtpGioBatDau.Value.TimeOfDay;
            ca.GioKetThuc = dtpGioKetThuc.Value.TimeOfDay;
            ca.SoPhutNghi = (int)nudSoPhutNghi.Value;
            ca.SoPhutChoPhepDiMuon = (int)nudDiMuon.Value;
            ca.SoPhutChoPhepVeSom = (int)nudVeSom.Value;
            ca.QuaDem = chkQuaDem.Checked;
            ca.HoatDong = chkHoatDong.Checked;
            ca.NgayCapNhat = DateTime.Now;
            db.SaveChanges();
            MessageBox.Show("Cập nhật ca làm việc thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0) { MessageBox.Show("Vui lòng chọn ca làm việc cần xóa!"); return; }
            if (MessageBox.Show("Bạn có chắc muốn xóa ca làm việc này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            using var db = new AppDbContext();
            var ca = db.CaLamViecs.Include(x => x.DanhSachPhanCa).Include(x => x.DanhSachChamCong).FirstOrDefault(x => x.Id == _idDangChon);
            if (ca == null) { MessageBox.Show("Không tìm thấy ca làm việc!"); return; }
            if (ca.DanhSachPhanCa.Any() || ca.DanhSachChamCong.Any()) { MessageBox.Show("Ca làm việc đã phát sinh dữ liệu, không thể xóa!"); return; }
            db.CaLamViecs.Remove(ca);
            db.SaveChanges();
            MessageBox.Show("Xóa ca làm việc thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        private void dgvCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvCaLamViec.Rows[e.RowIndex];
            _idDangChon = Convert.ToInt32(row.Cells["Id"].Value);
            txtMaCa.Text = row.Cells["MaCa"].Value?.ToString() ?? "";
            txtTenCa.Text = row.Cells["TenCa"].Value?.ToString() ?? "";
            if (TimeSpan.TryParse(row.Cells["GioBatDau"].Value?.ToString(), out TimeSpan gioBD)) dtpGioBatDau.Value = DateTime.Today.Add(gioBD);
            if (TimeSpan.TryParse(row.Cells["GioKetThuc"].Value?.ToString(), out TimeSpan gioKT)) dtpGioKetThuc.Value = DateTime.Today.Add(gioKT);
            nudSoPhutNghi.Value = Convert.ToDecimal(row.Cells["SoPhutNghi"].Value ?? 0);
            chkQuaDem.Checked = Convert.ToBoolean(row.Cells["QuaDem"].Value ?? false);
            chkHoatDong.Checked = Convert.ToBoolean(row.Cells["HoatDong"].Value ?? true);
        }
    }
}
