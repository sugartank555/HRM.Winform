using HRM.Winform.Data;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.ChamCong
{
    public partial class FrmPhanCaNhanVien : Form
    {
        private int _idDangChon = 0;
        private HRM.Winform.Helpers.DataGridSearchPaginationHelper? _gridHelper;

        public FrmPhanCaNhanVien()
        {
            InitializeComponent();
        }

        private void FrmPhanCaNhanVien_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            _gridHelper ??= new HRM.Winform.Helpers.DataGridSearchPaginationHelper(dgvPhanCa);
            TaiNhanVien();
            TaiCaLamViec();
            TaiDuLieu();
            LamMoi();
            _gridHelper?.RefreshLayout();
            Resize += (_, _) => _gridHelper?.RefreshLayout();
        }

        private void CaiDatGrid()
        {
            dgvPhanCa.AutoGenerateColumns = false;
            dgvPhanCa.Columns.Clear();

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNhanVien",
                HeaderText = "Mã NV",
                DataPropertyName = "MaNhanVien",
                Width = 100
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen",
                Width = 180
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenCa",
                HeaderText = "Ca làm việc",
                DataPropertyName = "TenCa",
                Width = 180
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayLamViec",
                HeaderText = "Ngày làm việc",
                DataPropertyName = "NgayLamViec",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NhanVienId",
                DataPropertyName = "NhanVienId",
                Visible = false
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CaLamViecId",
                DataPropertyName = "CaLamViecId",
                Visible = false
            });

            dgvPhanCa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanCa.MultiSelect = false;
            dgvPhanCa.ReadOnly = true;
            dgvPhanCa.AllowUserToAddRows = false;
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

        private void TaiCaLamViec()
        {
            using var db = new AppDbContext();
            var ds = db.CaLamViecs
                .AsNoTracking()
                .Where(x => x.HoatDong)
                .OrderBy(x => x.TenCa)
                .ToList();

            cboCaLamViec.DataSource = ds;
            cboCaLamViec.DisplayMember = "TenCa";
            cboCaLamViec.ValueMember = "Id";
            cboCaLamViec.SelectedIndex = -1;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            var ds = db.PhanCaNhanViens
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Include(x => x.CaLamViec)
                .OrderByDescending(x => x.NgayLamViec)
                .ThenBy(x => x.NhanVien!.HoTen)
                .Select(x => new
                {
                    x.Id,
                    x.NhanVienId,
                    x.CaLamViecId,
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    TenCa = x.CaLamViec != null ? x.CaLamViec.TenCa : "",
                    x.NgayLamViec
                })
                .ToList();

            _gridHelper?.ApplyData(ds);
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            cboNhanVien.SelectedIndex = -1;
            cboCaLamViec.SelectedIndex = -1;
            dtpNgayLamViec.Value = DateTime.Today;
        }

        private bool KiemTraDuLieu()
        {
            if (cboNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                cboNhanVien.Focus();
                return false;
            }

            if (cboCaLamViec.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn ca làm việc!");
                cboCaLamViec.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            int caLamViecId = Convert.ToInt32(cboCaLamViec.SelectedValue);
            DateTime ngay = dtpNgayLamViec.Value.Date;

            using var db = new AppDbContext();

            bool daTonTai = db.PhanCaNhanViens.Any(x =>
                x.NhanVienId == nhanVienId &&
                x.NgayLamViec == ngay);

            if (daTonTai)
            {
                MessageBox.Show("Nhân viên đã được phân ca trong ngày này!");
                return;
            }

            db.PhanCaNhanViens.Add(new PhanCaNhanVien
            {
                NhanVienId = nhanVienId,
                CaLamViecId = caLamViecId,
                NgayLamViec = ngay,
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Phân ca thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                return;
            }

            if (!KiemTraDuLieu()) return;

            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            int caLamViecId = Convert.ToInt32(cboCaLamViec.SelectedValue);
            DateTime ngay = dtpNgayLamViec.Value.Date;

            using var db = new AppDbContext();

            var phanCa = db.PhanCaNhanViens.FirstOrDefault(x => x.Id == _idDangChon);
            if (phanCa == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phân ca!");
                return;
            }

            bool daTonTai = db.PhanCaNhanViens.Any(x =>
                x.NhanVienId == nhanVienId &&
                x.NgayLamViec == ngay &&
                x.Id != _idDangChon);

            if (daTonTai)
            {
                MessageBox.Show("Nhân viên đã được phân ca trong ngày này!");
                return;
            }

            phanCa.NhanVienId = nhanVienId;
            phanCa.CaLamViecId = caLamViecId;
            phanCa.NgayLamViec = ngay;
            phanCa.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cập nhật phân ca thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phân ca này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using var db = new AppDbContext();

            var phanCa = db.PhanCaNhanViens.FirstOrDefault(x => x.Id == _idDangChon);
            if (phanCa == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu!");
                return;
            }

            db.PhanCaNhanViens.Remove(phanCa);
            db.SaveChanges();

            MessageBox.Show("Xóa phân ca thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvPhanCa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPhanCa.Rows[e.RowIndex];
            _idDangChon = Convert.ToInt32(row.Cells["Id"].Value);
            cboNhanVien.SelectedValue = Convert.ToInt32(row.Cells["NhanVienId"].Value);
            cboCaLamViec.SelectedValue = Convert.ToInt32(row.Cells["CaLamViecId"].Value);
            dtpNgayLamViec.Value = Convert.ToDateTime(row.Cells["NgayLamViec"].Value);
        }
    }
}
