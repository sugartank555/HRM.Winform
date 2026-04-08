using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.ChamCong
{
    public partial class FrmPhanCaNhanVien : Form
    {
        private int _idDangChon = 0;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmPhanCaNhanVien()
        {
            InitializeComponent();
        }

        private void FrmPhanCaNhanVien_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvPhanCa);
            TaiNhanVien();
            TaiCaLamViec();
            TaiCheDoPhanCa();
            TaiDuLieu();
            LamMoi();
            ApplyResponsiveLayout();
            _gridHelper?.RefreshLayout();
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
            ThemeHelper.ApplyInput(cboCheDo);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplySecondaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvPhanCa);
        }

        private void CaiDatGrid()
        {
            dgvPhanCa.AutoGenerateColumns = false;
            dgvPhanCa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                FillWeight = 75,
                MinimumWidth = 90
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ tên",
                DataPropertyName = "HoTen",
                FillWeight = 130,
                MinimumWidth = 150
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenCa",
                HeaderText = "Ca làm việc",
                DataPropertyName = "TenCa",
                FillWeight = 120,
                MinimumWidth = 140
            });

            dgvPhanCa.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NgayLamViec",
                HeaderText = "Ngày làm việc",
                DataPropertyName = "NgayLamViec",
                FillWeight = 90,
                MinimumWidth = 120,
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

        private void TaiCheDoPhanCa()
        {
            cboCheDo.Items.Clear();
            cboCheDo.Items.Add("Nhập tay theo ngày");
            cboCheDo.Items.Add("Tự động theo tuần");
            cboCheDo.Items.Add("Tự động theo tháng");
            cboCheDo.SelectedIndex = 0;
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
            cboCheDo.SelectedIndex = cboCheDo.Items.Count > 0 ? 0 : -1;
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
            List<DateTime> danhSachNgay = TaoDanhSachNgayPhanCa(dtpNgayLamViec.Value.Date);

            using var db = new AppDbContext();
            var ngaySet = danhSachNgay.Select(x => x.Date).ToHashSet();
            var daTonTai = db.PhanCaNhanViens
                .Where(x => x.NhanVienId == nhanVienId && ngaySet.Contains(x.NgayLamViec.Date))
                .Select(x => x.NgayLamViec.Date)
                .ToList()
                .ToHashSet();

            int daThem = 0;
            foreach (var ngay in danhSachNgay)
            {
                if (daTonTai.Contains(ngay.Date))
                {
                    continue;
                }

                db.PhanCaNhanViens.Add(new PhanCaNhanVien
                {
                    NhanVienId = nhanVienId,
                    CaLamViecId = caLamViecId,
                    NgayLamViec = ngay,
                    NgayTao = DateTime.Now
                });
                daThem++;
            }

            if (daThem == 0)
            {
                MessageBox.Show("Các ngày trong phạm vi chọn đã được phân ca rồi.");
                return;
            }

            db.SaveChanges();
            int boQua = danhSachNgay.Count - daThem;
            string phamVi = cboCheDo.Text;
            MessageBox.Show(
                boQua > 0
                    ? $"Đã phân ca {daThem} ngày theo chế độ '{phamVi}'. Bỏ qua {boQua} ngày đã có sẵn."
                    : $"Đã phân ca {daThem} ngày theo chế độ '{phamVi}'.");
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

        private void ApplyResponsiveLayout()
        {
            int rightPadding = 24;
            int actionWidth = 90;
            int gap = 6;
            int panelRight = pnlThongTin.ClientSize.Width - rightPadding;

            btnXoa.SetBounds(panelRight - actionWidth, 108, actionWidth, 34);
            btnSua.SetBounds(btnXoa.Left - gap - actionWidth, 108, actionWidth, 34);
            btnThem.SetBounds(btnSua.Left - gap - 120, 108, 120, 34);
            btnLamMoi.SetBounds(panelRight - 196, 64, 196, 34);

            dtpNgayLamViec.Left = panelRight - dtpNgayLamViec.Width;
            lblNgayLamViec.Left = dtpNgayLamViec.Left - lblNgayLamViec.Width - 10;

            cboCaLamViec.Left = lblNgayLamViec.Left - 18 - cboCaLamViec.Width;
            lblCaLamViec.Left = cboCaLamViec.Left - lblCaLamViec.Width - 10;

            cboNhanVien.Width = Math.Max(260, lblCaLamViec.Left - 24 - cboNhanVien.Left);
            cboCheDo.Width = Math.Max(220, btnThem.Left - 30 - cboCheDo.Left);

            _gridHelper?.RefreshLayout();
        }

        private List<DateTime> TaoDanhSachNgayPhanCa(DateTime ngayBatDau)
        {
            string cheDo = cboCheDo.Text;
            if (cheDo.Contains("tuần", StringComparison.OrdinalIgnoreCase))
            {
                int diff = ((int)ngayBatDau.DayOfWeek + 6) % 7;
                DateTime dauTuan = ngayBatDau.AddDays(-diff);
                return Enumerable.Range(0, 7).Select(i => dauTuan.AddDays(i).Date).ToList();
            }

            if (cheDo.Contains("tháng", StringComparison.OrdinalIgnoreCase))
            {
                DateTime dauThang = new DateTime(ngayBatDau.Year, ngayBatDau.Month, 1);
                int soNgay = DateTime.DaysInMonth(ngayBatDau.Year, ngayBatDau.Month);
                return Enumerable.Range(0, soNgay).Select(i => dauThang.AddDays(i).Date).ToList();
            }

            return [ngayBatDau.Date];
        }
    }
}
