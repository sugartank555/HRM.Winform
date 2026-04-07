using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.NhanSu
{
    public partial class FrmTaiKhoan : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmTaiKhoan()
        {
            InitializeComponent();
        }

        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvTaiKhoan);
            TaiNhanVien();
            TaiVaiTro();
            TaiDuLieu();
            LamMoi();
            _gridHelper?.RefreshLayout();
            Resize += (_, _) => _gridHelper?.RefreshLayout();
        }

        private void CaiDatGrid()
        {
            dgvTaiKhoan.AutoGenerateColumns = false;
            dgvTaiKhoan.Columns.Clear();

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                DataPropertyName = "TenDangNhap",
                Width = 150
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Nhân viên",
                DataPropertyName = "HoTen",
                Width = 220
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "VaiTro",
                HeaderText = "Vai trò",
                DataPropertyName = "VaiTro",
                Width = 120
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "HoatDong",
                HeaderText = "Hoạt động",
                DataPropertyName = "HoatDong",
                Width = 90
            });

            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NhanVienId",
                DataPropertyName = "NhanVienId",
                Visible = false
            });

            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.AllowUserToAddRows = false;
        }

        private void TaiNhanVien()
        {
            using var db = new AppDbContext();
            var ds = db.NhanViens
                .AsNoTracking()
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

        private void TaiVaiTro()
        {
            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("HR");
            cboVaiTro.Items.Add("QuanLy");
            cboVaiTro.Items.Add("NhanVien");
            cboVaiTro.SelectedIndex = -1;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            var ds = db.TaiKhoans
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    x.Id,
                    x.TenDangNhap,
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    x.VaiTro,
                    x.HoatDong,
                    x.NhanVienId
                })
                .ToList();

            _gridHelper?.ApplyData(ds);
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboNhanVien.SelectedIndex = -1;
            cboVaiTro.SelectedIndex = -1;
            chkHoatDong.Checked = true;
            chkHienMatKhau.Checked = false;
            txtMatKhau.UseSystemPasswordChar = true;
            txtTenDangNhap.Focus();
        }

        private bool KiemTraDuLieu(bool batBuocNhapMatKhau)
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                txtTenDangNhap.Focus();
                return false;
            }

            if (batBuocNhapMatKhau && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }

            if (cboNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                cboNhanVien.Focus();
                return false;
            }

            if (cboVaiTro.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn vai trò!");
                cboVaiTro.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu(true)) return;

            using var db = new AppDbContext();

            string tenDangNhap = txtTenDangNhap.Text.Trim();
            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);

            if (db.TaiKhoans.Any(x => x.TenDangNhap == tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                return;
            }

            if (db.TaiKhoans.Any(x => x.NhanVienId == nhanVienId))
            {
                MessageBox.Show("Nhân viên này đã có tài khoản!");
                return;
            }

            db.TaiKhoans.Add(new TaiKhoan
            {
                TenDangNhap = txtTenDangNhap.Text.Trim(),
                MatKhauHash = HashHelper.ToSha256(txtMatKhau.Text.Trim()),
                VaiTro = cboVaiTro.Text,
                HoatDong = chkHoatDong.Checked,
                NhanVienId = nhanVienId,
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Thêm tài khoản thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                return;
            }

            if (!KiemTraDuLieu(false)) return;

            using var db = new AppDbContext();

            var taiKhoan = db.TaiKhoans.FirstOrDefault(x => x.Id == _idDangChon);
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản!");
                return;
            }

            string tenDangNhap = txtTenDangNhap.Text.Trim();
            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);

            if (db.TaiKhoans.Any(x => x.TenDangNhap == tenDangNhap && x.Id != _idDangChon))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!");
                return;
            }

            if (db.TaiKhoans.Any(x => x.NhanVienId == nhanVienId && x.Id != _idDangChon))
            {
                MessageBox.Show("Nhân viên này đã có tài khoản khác!");
                return;
            }

            taiKhoan.TenDangNhap = txtTenDangNhap.Text.Trim();
            taiKhoan.VaiTro = cboVaiTro.Text;
            taiKhoan.HoatDong = chkHoatDong.Checked;
            taiKhoan.NhanVienId = nhanVienId;
            taiKhoan.NgayCapNhat = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                taiKhoan.MatKhauHash = HashHelper.ToSha256(txtMatKhau.Text.Trim());
            }

            db.SaveChanges();
            MessageBox.Show("Cập nhật tài khoản thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes) return;

            using var db = new AppDbContext();

            var taiKhoan = db.TaiKhoans.FirstOrDefault(x => x.Id == _idDangChon);
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản!");
                return;
            }

            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();

            MessageBox.Show("Xóa tài khoản thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !chkHienMatKhau.Checked;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvTaiKhoan.Rows[e.RowIndex];
            _idDangChon = Convert.ToInt32(row.Cells["Id"].Value);

            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
            txtMatKhau.Clear();
            cboVaiTro.Text = row.Cells["VaiTro"].Value?.ToString() ?? "";
            chkHoatDong.Checked = Convert.ToBoolean(row.Cells["HoatDong"].Value ?? true);
            cboNhanVien.SelectedValue = Convert.ToInt32(row.Cells["NhanVienId"].Value);
        }
    }
}
