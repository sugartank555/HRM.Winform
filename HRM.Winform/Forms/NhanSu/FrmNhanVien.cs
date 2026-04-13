using HRM.Winform.Data;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.NhanSu
{
    public partial class FrmNhanVien : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvNhanVien);
            TaiPhongBan();
            TaiChucVu();
            TaiDuLieu();
            LamMoi();
            ApplyResponsiveLayout();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplySecondaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);

            foreach (Control control in Controls)
            {
                if (control is TextBox or ComboBox or NumericUpDown or DateTimePicker)
                {
                    ThemeHelper.ApplyInput(control);
                }
            }

            ThemeHelper.ApplyDataGrid(dgvNhanVien);
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
        }

        private void CaiDatGrid()
        {
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Columns.Clear();

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNhanVien",
                HeaderText = "Mã NV",
                DataPropertyName = "MaNhanVien",
                Width = 100
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen",
                Width = 180
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgaySinh",
                HeaderText = "Ngày sinh",
                DataPropertyName = "NgaySinh",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GioiTinhText",
                HeaderText = "Giới tính",
                DataPropertyName = "GioiTinhText",
                Width = 90
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoDienThoai",
                HeaderText = "SĐT",
                DataPropertyName = "SoDienThoai",
                Width = 110
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenPhongBan",
                HeaderText = "Phòng ban",
                DataPropertyName = "TenPhongBan",
                Width = 140
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenChucVu",
                HeaderText = "Chức vụ",
                DataPropertyName = "TenChucVu",
                Width = 120
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CaHomNay",
                HeaderText = "Ca hôm nay",
                DataPropertyName = "CaHomNay",
                Width = 120
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaQrHienTai",
                HeaderText = "Mã QR hiện tại",
                DataPropertyName = "MaQrHienTai",
                Width = 190
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayPhatQr",
                HeaderText = "Phát QR lúc",
                DataPropertyName = "NgayPhatQr",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM HH:mm" }
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayVaoLam",
                HeaderText = "Ngày vào làm",
                DataPropertyName = "NgayVaoLam",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LuongCoBan",
                HeaderText = "Lương cơ bản",
                DataPropertyName = "LuongCoBan",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvNhanVien.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "DangLamViec",
                HeaderText = "Đang làm việc",
                DataPropertyName = "DangLamViec",
                Width = 90
            });

            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
        }

        private void TaiPhongBan()
        {
            using var db = new AppDbContext();
            var ds = db.PhongBans
                .AsNoTracking()
                .OrderBy(x => x.TenPhongBan)
                .ToList();

            cboPhongBan.DataSource = ds;
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";
            cboPhongBan.SelectedIndex = -1;
        }

        private void TaiChucVu()
        {
            using var db = new AppDbContext();
            var ds = db.ChucVus
                .AsNoTracking()
                .OrderBy(x => x.TenChucVu)
                .ToList();

            cboChucVu.DataSource = ds;
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "Id";
            cboChucVu.SelectedIndex = -1;
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();
            var qrByNhanVien = HRM.Winform.Helpers.QrPhatStore.GetLatestByNhanVien();

            var ds = db.NhanViens
                .AsNoTracking()
                .Include(x => x.PhongBan)
                .Include(x => x.ChucVu)
                .OrderBy(x => x.Id)
                .Select(x => new
                {
                    x.Id,
                    x.MaNhanVien,
                    x.HoTen,
                    x.NgaySinh,
                    GioiTinhText = x.GioiTinh ? "Nam" : "Nữ",
                    x.SoDienThoai,
                    x.Email,
                    TenPhongBan = x.PhongBan != null ? x.PhongBan.TenPhongBan : "",
                    TenChucVu = x.ChucVu != null ? x.ChucVu.TenChucVu : "",
                    CaHomNay = qrByNhanVien.ContainsKey(x.Id) ? qrByNhanVien[x.Id].TenCa : "",
                    MaQrHienTai = qrByNhanVien.ContainsKey(x.Id) ? qrByNhanVien[x.Id].MaQr : "",
                    NgayPhatQr = qrByNhanVien.ContainsKey(x.Id) ? qrByNhanVien[x.Id].PhatLuc : (DateTime?)null,
                    x.NgayVaoLam,
                    x.LuongCoBan,
                    x.DangLamViec
                })
                .ToList();

            _gridHelper?.ApplyData(ds);
        }

        private void LamMoi()
        {
            _idDangChon = 0;
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            rdoNam.Checked = true;
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtCCCD.Clear();
            dtpNgayVaoLam.Value = DateTime.Today;
            nudLuongCoBan.Value = 0;
            chkDangLamViec.Checked = true;
            cboPhongBan.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;
            txtCaHomNay.Clear();
            txtMaQrHienTai.Clear();
            txtNgayPhatQr.Clear();
            txtMaNhanVien.Focus();
        }

        private bool KiemTraDuLieu()
        {
            var maNhanVien = ValidationHelper.NormalizeCode(txtMaNhanVien.Text);
            var hoTen = ValidationHelper.NormalizeText(txtHoTen.Text);
            var soDienThoai = ValidationHelper.NormalizeText(txtSoDienThoai.Text);
            var email = ValidationHelper.NormalizeOptional(txtEmail.Text);
            var cccd = ValidationHelper.NormalizeOptional(txtCCCD.Text);
            var tuoi = ValidationHelper.CalculateFullAge(dtpNgaySinh.Value.Date, DateTime.Today);

            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
                txtMaNhanVien.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtHoTen.Focus();
                return false;
            }

            if (tuoi < 18 || tuoi > 70)
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Nhân viên phải trong độ tuổi lao động từ 18 đến 70.");
                dtpNgaySinh.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidVietnamesePhone(soDienThoai))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập đúng định dạng số điện thoại Việt Nam.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (email != null && !ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng.");
                txtEmail.Focus();
                return false;
            }

            if (cccd != null && !ValidationHelper.IsValidCitizenId(cccd))
            {
                MessageBox.Show("CCCD phải gồm đúng 12 chữ số.");
                txtCCCD.Focus();
                return false;
            }

            if (dtpNgayVaoLam.Value.Date < dtpNgaySinh.Value.Date.AddYears(18))
            {
                MessageBox.Show("Ngày vào làm không hợp lệ so với ngày sinh.");
                dtpNgayVaoLam.Focus();
                return false;
            }

            if (nudLuongCoBan.Value <= 0)
            {
                MessageBox.Show("Lương cơ bản phải lớn hơn 0.");
                nudLuongCoBan.Focus();
                return false;
            }

            if (cboPhongBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ban!");
                cboPhongBan.Focus();
                return false;
            }

            if (cboChucVu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ!");
                cboChucVu.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            string ma = ValidationHelper.NormalizeCode(txtMaNhanVien.Text);
            string soDienThoai = ValidationHelper.NormalizeText(txtSoDienThoai.Text);
            string? email = ValidationHelper.NormalizeOptional(txtEmail.Text);
            string? cccd = ValidationHelper.NormalizeOptional(txtCCCD.Text);
            if (db.NhanViens.Any(x => x.MaNhanVien == ma))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }

            if (db.NhanViens.Any(x => x.SoDienThoai == soDienThoai))
            {
                MessageBox.Show("Số điện thoại đã tồn tại!");
                return;
            }

            if (email != null && db.NhanViens.Any(x => x.Email == email))
            {
                MessageBox.Show("Email đã tồn tại!");
                return;
            }

            if (cccd != null && db.NhanViens.Any(x => x.CCCD == cccd))
            {
                MessageBox.Show("CCCD đã tồn tại!");
                return;
            }

            db.NhanViens.Add(new NhanVien
            {
                MaNhanVien = ma,
                HoTen = ValidationHelper.NormalizeText(txtHoTen.Text),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = rdoNam.Checked,
                SoDienThoai = soDienThoai,
                Email = email,
                DiaChi = ValidationHelper.NormalizeOptional(txtDiaChi.Text),
                CCCD = cccd,
                NgayVaoLam = dtpNgayVaoLam.Value.Date,
                LuongCoBan = nudLuongCoBan.Value,
                DangLamViec = chkDangLamViec.Checked,
                PhongBanId = Convert.ToInt32(cboPhongBan.SelectedValue),
                ChucVuId = Convert.ToInt32(cboChucVu.SelectedValue),
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Thêm nhân viên thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            var nhanVien = db.NhanViens.FirstOrDefault(x => x.Id == _idDangChon);
            if (nhanVien == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
                return;
            }

            string ma = ValidationHelper.NormalizeCode(txtMaNhanVien.Text);
            string soDienThoai = ValidationHelper.NormalizeText(txtSoDienThoai.Text);
            string? email = ValidationHelper.NormalizeOptional(txtEmail.Text);
            string? cccd = ValidationHelper.NormalizeOptional(txtCCCD.Text);
            if (db.NhanViens.Any(x => x.MaNhanVien == ma && x.Id != _idDangChon))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }

            if (db.NhanViens.Any(x => x.SoDienThoai == soDienThoai && x.Id != _idDangChon))
            {
                MessageBox.Show("Số điện thoại đã tồn tại!");
                return;
            }

            if (email != null && db.NhanViens.Any(x => x.Email == email && x.Id != _idDangChon))
            {
                MessageBox.Show("Email đã tồn tại!");
                return;
            }

            if (cccd != null && db.NhanViens.Any(x => x.CCCD == cccd && x.Id != _idDangChon))
            {
                MessageBox.Show("CCCD đã tồn tại!");
                return;
            }

            nhanVien.MaNhanVien = ma;
            nhanVien.HoTen = ValidationHelper.NormalizeText(txtHoTen.Text);
            nhanVien.NgaySinh = dtpNgaySinh.Value.Date;
            nhanVien.GioiTinh = rdoNam.Checked;
            nhanVien.SoDienThoai = soDienThoai;
            nhanVien.Email = email;
            nhanVien.DiaChi = ValidationHelper.NormalizeOptional(txtDiaChi.Text);
            nhanVien.CCCD = cccd;
            nhanVien.NgayVaoLam = dtpNgayVaoLam.Value.Date;
            nhanVien.LuongCoBan = nudLuongCoBan.Value;
            nhanVien.DangLamViec = chkDangLamViec.Checked;
            nhanVien.PhongBanId = Convert.ToInt32(cboPhongBan.SelectedValue);
            nhanVien.ChucVuId = Convert.ToInt32(cboChucVu.SelectedValue);
            nhanVien.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cập nhật nhân viên thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs != DialogResult.Yes) return;

            using var db = new AppDbContext();

            var nhanVien = db.NhanViens
                .Include(x => x.DanhSachTaiKhoan)
                .Include(x => x.DanhSachChamCong)
                .Include(x => x.DanhSachDonNghiPhep)
                .Include(x => x.DanhSachDonTangCa)
                .Include(x => x.DanhSachPhanCa)
                .FirstOrDefault(x => x.Id == _idDangChon);

            if (nhanVien == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
                return;
            }

            if (nhanVien.DanhSachTaiKhoan.Any() ||
                nhanVien.DanhSachChamCong.Any() ||
                nhanVien.DanhSachDonNghiPhep.Any() ||
                nhanVien.DanhSachDonTangCa.Any() ||
                nhanVien.DanhSachPhanCa.Any())
            {
                MessageBox.Show("Nhân viên đã phát sinh dữ liệu, không thể xóa!");
                return;
            }

            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();

            MessageBox.Show("Xóa nhân viên thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells["Id"].Value);

            using var db = new AppDbContext();
            var nhanVien = db.NhanViens.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (nhanVien == null) return;

            _idDangChon = nhanVien.Id;
            txtMaNhanVien.Text = nhanVien.MaNhanVien;
            txtHoTen.Text = nhanVien.HoTen;
            dtpNgaySinh.Value = nhanVien.NgaySinh;
            rdoNam.Checked = nhanVien.GioiTinh;
            rdoNu.Checked = !nhanVien.GioiTinh;
            txtSoDienThoai.Text = nhanVien.SoDienThoai;
            txtEmail.Text = nhanVien.Email ?? "";
            txtDiaChi.Text = nhanVien.DiaChi ?? "";
            txtCCCD.Text = nhanVien.CCCD ?? "";
            dtpNgayVaoLam.Value = nhanVien.NgayVaoLam;
            nudLuongCoBan.Value = nhanVien.LuongCoBan;
            chkDangLamViec.Checked = nhanVien.DangLamViec;
            cboPhongBan.SelectedValue = nhanVien.PhongBanId;
            cboChucVu.SelectedValue = nhanVien.ChucVuId;

            var qrByNhanVien = HRM.Winform.Helpers.QrPhatStore.GetLatestByNhanVien();
            if (qrByNhanVien.TryGetValue(nhanVien.Id, out var qrInfo))
            {
                txtCaHomNay.Text = qrInfo.TenCa;
                txtMaQrHienTai.Text = qrInfo.MaQr;
                txtNgayPhatQr.Text = qrInfo.PhatLuc.ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                txtCaHomNay.Text = string.Empty;
                txtMaQrHienTai.Text = string.Empty;
                txtNgayPhatQr.Text = string.Empty;
            }
        }

        private void ApplyResponsiveLayout()
        {
            int right = ClientSize.Width - 31;
            btnXoa.Left = right - btnXoa.Width;
            btnSua.Left = btnXoa.Left - 8 - btnSua.Width;
            btnThem.Left = btnSua.Left - 8 - btnThem.Width;
            btnLamMoi.Left = btnThem.Left;
            btnLamMoi.Width = btnXoa.Right - btnLamMoi.Left;

            txtNgayPhatQr.Left = right - txtNgayPhatQr.Width;
            lblNgayPhatQr.Left = txtNgayPhatQr.Left;

            txtMaQrHienTai.Width = Math.Max(220, txtNgayPhatQr.Left - 90 - txtMaQrHienTai.Left);
            lblMaQrHienTai.Left = txtMaQrHienTai.Left;
            _gridHelper?.RefreshLayout();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
