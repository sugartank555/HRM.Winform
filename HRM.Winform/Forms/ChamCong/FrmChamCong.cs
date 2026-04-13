using HRM.Winform.Data;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.ChamCong
{
    public partial class FrmChamCong : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmChamCong()
        {
            InitializeComponent();
        }

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvChamCong);
            TaiNhanVien();
            TaiCaLamViec();
            TaiDuLieu();
            LamMoi();
            TaiTrangThai();
            ApplyResponsiveLayout();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            lblTieuDe.ForeColor = ThemeHelper.TextPrimary;
            lblMoTa.ForeColor = ThemeHelper.TextSecondary;
            ThemeHelper.ApplyCard(pnlThongTin);
            ThemeHelper.ApplyInput(cboNhanVien);
            ThemeHelper.ApplyInput(cboCaLamViec);
            ThemeHelper.ApplyInput(cboTrangThai);
            ThemeHelper.ApplyInput(txtGhiChu);
            ThemeHelper.ApplySecondaryButton(btnTuTinhGio);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplySecondaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvChamCong);
        }

        private void TaiTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("CoMat");
            cboTrangThai.Items.Add("DiMuon");
            cboTrangThai.Items.Add("VeSom");
            cboTrangThai.Items.Add("Vang");
            cboTrangThai.Items.Add("NghiPhep");
            cboTrangThai.Items.Add("CongTac");
            cboTrangThai.Items.Add("ThieuCheckIn");
            cboTrangThai.Items.Add("ThieuCheckOut");
            cboTrangThai.SelectedIndex = 0;
        }

        private void CaiDatGrid()
        {
            dgvChamCong.AutoGenerateColumns = false;
            dgvChamCong.Columns.Clear();
            dgvChamCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaNhanVien",
                HeaderText = "Mã NV",
                DataPropertyName = "MaNhanVien",
                FillWeight = 70,
                MinimumWidth = 70
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen",
                FillWeight = 120,
                MinimumWidth = 110
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenCa",
                HeaderText = "Ca",
                DataPropertyName = "TenCa",
                FillWeight = 85,
                MinimumWidth = 80
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayLamViec",
                HeaderText = "Ngày",
                DataPropertyName = "NgayLamViec",
                FillWeight = 80,
                MinimumWidth = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GioCheckIn",
                HeaderText = "CheckIn",
                DataPropertyName = "GioCheckIn",
                FillWeight = 110,
                MinimumWidth = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "GioCheckOut",
                HeaderText = "CheckOut",
                DataPropertyName = "GioCheckOut",
                FillWeight = 110,
                MinimumWidth = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoGioLam",
                HeaderText = "Số giờ làm",
                DataPropertyName = "SoGioLam",
                FillWeight = 75,
                MinimumWidth = 70
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoGioTangCa",
                HeaderText = "Tăng ca",
                DataPropertyName = "SoGioTangCa",
                FillWeight = 70,
                MinimumWidth = 70
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TrangThai",
                HeaderText = "Trạng thái",
                DataPropertyName = "TrangThai",
                FillWeight = 80,
                MinimumWidth = 80
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NhanVienId",
                DataPropertyName = "NhanVienId",
                Visible = false
            });

            dgvChamCong.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CaLamViecId",
                DataPropertyName = "CaLamViecId",
                Visible = false
            });

            dgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChamCong.MultiSelect = false;
            dgvChamCong.ReadOnly = true;
            dgvChamCong.AllowUserToAddRows = false;
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

            var ds = db.ChamCongs
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
                    x.NgayLamViec,
                    GioCheckIn = x.GioCheckIn,
                    GioCheckOut = x.GioCheckOut,
                    x.SoGioLam,
                    x.SoGioTangCa,
                    x.TrangThai
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
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now;
            nudDiMuon.Value = 0;
            nudVeSom.Value = 0;
            nudSoGioLam.Value = 0;
            nudTangCa.Value = 0;
            txtGhiChu.Clear();
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        private bool KiemTraDuLieu()
        {
            if (cboNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!");
                return false;
            }

            if (cboCaLamViec.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn ca làm việc!");
                return false;
            }

            if (cboTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return false;
            }

            using var db = new AppDbContext();
            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            var nhanVien = db.NhanViens.AsNoTracking().FirstOrDefault(x => x.Id == nhanVienId);
            if (nhanVien == null || !nhanVien.DangLamViec)
            {
                MessageBox.Show("Chỉ được chấm công cho nhân viên đang làm việc!");
                return false;
            }

            if (dtpNgayLamViec.Value.Date < nhanVien.NgayVaoLam.Date)
            {
                MessageBox.Show("Ngày chấm công không được trước ngày vào làm của nhân viên.");
                return false;
            }

            string trangThai = cboTrangThai.Text;
            bool canCoCheckInOut = trangThai is "CoMat" or "DiMuon" or "VeSom";
            bool choPhepThieuMotDau = trangThai is "ThieuCheckIn" or "ThieuCheckOut";
            bool khongCanGio = trangThai is "Vang" or "NghiPhep" or "CongTac";

            if (canCoCheckInOut && dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Giờ check-out phải lớn hơn giờ check-in.");
                return false;
            }

            if (khongCanGio)
            {
                if (nudSoGioLam.Value != 0 || nudTangCa.Value != 0 || nudDiMuon.Value != 0 || nudVeSom.Value != 0)
                {
                    MessageBox.Show("Trạng thái vắng/nghỉ phép/công tác không được có số giờ làm, tăng ca, đi muộn hoặc về sớm.");
                    return false;
                }
            }

            if (choPhepThieuMotDau && dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Dữ liệu check-in/check-out không hợp lệ cho trạng thái thiếu check.");
                return false;
            }

            if (nudSoGioLam.Value < 0 || nudTangCa.Value < 0)
            {
                MessageBox.Show("Số giờ làm và tăng ca không được âm.");
                return false;
            }

            return true;
        }

        private bool KiemTraThangDaChot(DateTime ngay)
        {
            if (!MonthlyAttendanceLockStore.IsLocked(ngay))
            {
                return false;
            }

            MessageBox.Show(
                $"Bang cong thang {ngay.Month:00}/{ngay.Year} da duoc chot. Ban khong the them, sua hoac xoa du lieu trong thang nay.",
                "Thang da chot",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return true;
        }

        private void btnTuTinhGio_Click(object sender, EventArgs e)
        {
            TimeSpan diff = dtpCheckOut.Value - dtpCheckIn.Value;
            nudSoGioLam.Value = diff.TotalHours > 0 ? (decimal)diff.TotalHours : 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            DateTime ngay = dtpNgayLamViec.Value.Date;

            if (ngay < DateTime.Today)
            {
                MessageBox.Show("Không được tạo mới chấm công cho ngày trong quá khứ.");
                dtpNgayLamViec.Focus();
                return;
            }

            if (KiemTraThangDaChot(ngay)) return;

            using var db = new AppDbContext();

            bool daTonTai = db.ChamCongs.Any(x => x.NhanVienId == nhanVienId && x.NgayLamViec == ngay);
            if (daTonTai)
            {
                MessageBox.Show("Nhân viên đã có chấm công trong ngày này!");
                return;
            }

            db.ChamCongs.Add(new Models.ChamCong
            {
                NhanVienId = nhanVienId,
                CaLamViecId = Convert.ToInt32(cboCaLamViec.SelectedValue),
                NgayLamViec = ngay,
                GioCheckIn = dtpCheckIn.Value,
                GioCheckOut = dtpCheckOut.Value,
                SoPhutDiMuon = (int)nudDiMuon.Value,
                SoPhutVeSom = (int)nudVeSom.Value,
                SoGioLam = (double)nudSoGioLam.Value,
                SoGioTangCa = (double)nudTangCa.Value,
                TrangThai = cboTrangThai.Text,
                GhiChu = ValidationHelper.NormalizeOptional(txtGhiChu.Text),
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Thêm chấm công thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần sửa!");
                return;
            }

            if (!KiemTraDuLieu()) return;

            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            DateTime ngay = dtpNgayLamViec.Value.Date;

            if (KiemTraThangDaChot(ngay)) return;

            using var db = new AppDbContext();

            var cc = db.ChamCongs.FirstOrDefault(x => x.Id == _idDangChon);
            if (cc == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu chấm công!");
                return;
            }

            bool daTonTai = db.ChamCongs.Any(x =>
                x.NhanVienId == nhanVienId &&
                x.NgayLamViec == ngay &&
                x.Id != _idDangChon);

            if (daTonTai)
            {
                MessageBox.Show("Nhân viên đã có chấm công trong ngày này!");
                return;
            }

            cc.NhanVienId = nhanVienId;
            cc.CaLamViecId = Convert.ToInt32(cboCaLamViec.SelectedValue);
            cc.NgayLamViec = ngay;
            cc.GioCheckIn = dtpCheckIn.Value;
            cc.GioCheckOut = dtpCheckOut.Value;
            cc.SoPhutDiMuon = (int)nudDiMuon.Value;
            cc.SoPhutVeSom = (int)nudVeSom.Value;
            cc.SoGioLam = (double)nudSoGioLam.Value;
            cc.SoGioTangCa = (double)nudTangCa.Value;
            cc.TrangThai = cboTrangThai.Text;
            cc.GhiChu = ValidationHelper.NormalizeOptional(txtGhiChu.Text);
            cc.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cập nhật chấm công thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDangChon == 0)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu chấm công này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            using var db = new AppDbContext();

            var cc = db.ChamCongs.FirstOrDefault(x => x.Id == _idDangChon);
            if (cc == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu!");
                return;
            }

            if (KiemTraThangDaChot(cc.NgayLamViec)) return;

            db.ChamCongs.Remove(cc);
            db.SaveChanges();

            MessageBox.Show("Xóa chấm công thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvChamCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvChamCong.Rows[e.RowIndex].Cells["Id"].Value);

            using var db = new AppDbContext();
            var cc = db.ChamCongs.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (cc == null) return;

            _idDangChon = cc.Id;
            cboNhanVien.SelectedValue = cc.NhanVienId;
            cboCaLamViec.SelectedValue = cc.CaLamViecId ?? 0;
            dtpNgayLamViec.Value = cc.NgayLamViec;
            dtpCheckIn.Value = cc.GioCheckIn ?? DateTime.Now;
            dtpCheckOut.Value = cc.GioCheckOut ?? DateTime.Now;
            nudDiMuon.Value = cc.SoPhutDiMuon;
            nudVeSom.Value = cc.SoPhutVeSom;
            nudSoGioLam.Value = (decimal)cc.SoGioLam;
            nudTangCa.Value = (decimal)cc.SoGioTangCa;
            cboTrangThai.Text = cc.TrangThai;
            txtGhiChu.Text = cc.GhiChu ?? "";
        }

        private void ApplyResponsiveLayout()
        {
            int panelRight = pnlThongTin.ClientSize.Width - 24;
            int buttonWidth = 95;
            int gap = 6;

            btnSua.SetBounds(panelRight - buttonWidth, 23, buttonWidth, 35);
            btnThem.SetBounds(btnSua.Left - gap - buttonWidth, 23, buttonWidth, 35);
            btnLamMoi.SetBounds(panelRight - buttonWidth, 66, buttonWidth, 35);
            btnXoa.SetBounds(btnLamMoi.Left - gap - buttonWidth, 66, buttonWidth, 35);

            int dateWidth = 120;
            dtpNgayLamViec.Left = btnThem.Left - 20 - dateWidth;
            lblNgayLamViec.Left = dtpNgayLamViec.Left - lblNgayLamViec.Width - 10;

            cboCaLamViec.Left = lblNgayLamViec.Left - 18 - cboCaLamViec.Width;
            lblCaLamViec.Left = cboCaLamViec.Left - lblCaLamViec.Width - 10;

            cboNhanVien.Width = Math.Max(220, lblCaLamViec.Left - 24 - cboNhanVien.Left);

            int secondRowRight = btnXoa.Left - 20;
            nudVeSom.Left = secondRowRight - nudVeSom.Width;
            lblVeSom.Left = nudVeSom.Left - lblVeSom.Width - 10;

            nudDiMuon.Left = lblVeSom.Left - 18 - nudDiMuon.Width;
            lblDiMuon.Left = nudDiMuon.Left - lblDiMuon.Width - 10;

            dtpCheckOut.Width = 180;
            dtpCheckOut.Left = lblDiMuon.Left - 18 - dtpCheckOut.Width;
            lblCheckOut.Left = dtpCheckOut.Left - lblCheckOut.Width - 10;

            dtpCheckIn.Width = 180;
            dtpCheckIn.Left = lblCheckOut.Left - 18 - dtpCheckIn.Width;
            lblCheckIn.Left = dtpCheckIn.Left - lblCheckIn.Width - 10;

            cboTrangThai.Left = Math.Min(628, panelRight - 24 - cboTrangThai.Width);
            lblTrangThai.Left = cboTrangThai.Left - lblTrangThai.Width - 10;

            btnTuTinhGio.Left = lblTrangThai.Left - 18 - btnTuTinhGio.Width;
            nudTangCa.Left = btnTuTinhGio.Left - 18 - nudTangCa.Width;
            lblTangCa.Left = nudTangCa.Left - lblTangCa.Width - 10;

            nudSoGioLam.Left = lblTangCa.Left - 18 - nudSoGioLam.Width;
            lblSoGioLam.Left = nudSoGioLam.Left - lblSoGioLam.Width - 10;

            txtGhiChu.Width = Math.Max(420, panelRight - 24 - txtGhiChu.Left);

            _gridHelper?.RefreshLayout();
        }
    }
}
