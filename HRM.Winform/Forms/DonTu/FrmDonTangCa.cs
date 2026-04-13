using HRM.Winform.Data;
using HRM.Winform.Helpers;
using HRM.Winform.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DonTu
{
    public partial class FrmDonTangCa : Form
    {
        private int _idDangChon;
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmDonTangCa()
        {
            InitializeComponent();
        }

        private void FrmDonTangCa_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvDonTangCa);
            TaiNhanVien();
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
            ThemeHelper.ApplyInput(dtpNgayLam);
            ThemeHelper.ApplyInput(dtpTuGio);
            ThemeHelper.ApplyInput(dtpDenGio);
            ThemeHelper.ApplyInput(nudTongSoGio);
            ThemeHelper.ApplyInput(txtLyDo);
            ThemeHelper.ApplyInput(cboTrangThai);

            ThemeHelper.ApplySecondaryButton(btnTinhGio);
            ThemeHelper.ApplyPrimaryButton(btnThem);
            ThemeHelper.ApplyPrimaryButton(btnSua);
            ThemeHelper.ApplyDangerButton(btnXoa);
            ThemeHelper.ApplySecondaryButton(btnLamMoi);
            ThemeHelper.ApplyDataGrid(dgvDonTangCa);
        }

        private void CaiDatGrid()
        {
            dgvDonTangCa.AutoGenerateColumns = false;
            dgvDonTangCa.Columns.Clear();

            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNhanVien", HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 90 });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoTen", HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 170 });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayLam", HeaderText = "Ngày làm", DataPropertyName = "NgayLam", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "TuGio", HeaderText = "Từ giờ", DataPropertyName = "TuGio", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "DenGio", HeaderText = "Đến giờ", DataPropertyName = "DenGio", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "TongSoGio", HeaderText = "Tổng giờ", DataPropertyName = "TongSoGio", Width = 90 });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "LyDo", HeaderText = "Lý do", DataPropertyName = "LyDo", Width = 180 });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "TrangThai", HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });
            dgvDonTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "NhanVienId", DataPropertyName = "NhanVienId", Visible = false });

            dgvDonTangCa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonTangCa.MultiSelect = false;
            dgvDonTangCa.ReadOnly = true;
            dgvDonTangCa.AllowUserToAddRows = false;
            dgvDonTangCa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            var ds = db.DonTangCas
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .OrderByDescending(x => x.NgayLam)
                .Select(x => new
                {
                    x.Id,
                    x.NhanVienId,
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    x.NgayLam,
                    x.TuGio,
                    x.DenGio,
                    x.TongSoGio,
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
            dtpNgayLam.Value = DateTime.Today;
            dtpTuGio.Value = DateTime.Now;
            dtpDenGio.Value = DateTime.Now;
            nudTongSoGio.Value = 0;
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

            if (dtpNgayLam.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Không được tạo đơn tăng ca cho ngày trong quá khứ.");
                dtpNgayLam.Focus();
                return false;
            }

            if (dtpDenGio.Value <= dtpTuGio.Value)
            {
                MessageBox.Show("Đến giờ phải lớn hơn từ giờ!");
                return false;
            }

            if (dtpNgayLam.Value.Date != dtpTuGio.Value.Date || dtpNgayLam.Value.Date != dtpDenGio.Value.Date)
            {
                MessageBox.Show("Ngày làm phải trùng với ngày của thời gian tăng ca.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng nhập lý do tăng ca.");
                txtLyDo.Focus();
                return false;
            }

            var tongSoGioThucTe = (decimal)(dtpDenGio.Value - dtpTuGio.Value).TotalHours;
            if (tongSoGioThucTe <= 0)
            {
                MessageBox.Show("Tổng số giờ tăng ca không hợp lệ.");
                return false;
            }

            if (Math.Abs(nudTongSoGio.Value - tongSoGioThucTe) > 0.01m)
            {
                MessageBox.Show("Tổng số giờ tăng ca không khớp với khoảng thời gian đã chọn.");
                nudTongSoGio.Focus();
                return false;
            }

            using var db = new AppDbContext();
            int nhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            var nhanVien = db.NhanViens.AsNoTracking().FirstOrDefault(x => x.Id == nhanVienId);
            if (nhanVien == null || !nhanVien.DangLamViec)
            {
                MessageBox.Show("Chỉ được tạo đơn tăng ca cho nhân viên đang làm việc.");
                return false;
            }

            bool trungLich = db.DonTangCas.Any(x =>
                x.NhanVienId == nhanVienId
                && x.Id != _idDangChon
                && x.TrangThai != "TuChoi"
                && x.TuGio < dtpDenGio.Value
                && dtpTuGio.Value < x.DenGio);

            if (trungLich)
            {
                MessageBox.Show("Nhân viên đã có đơn tăng ca khác bị trùng thời gian.");
                return false;
            }

            return true;
        }

        private void btnTinhGio_Click(object sender, EventArgs e)
        {
            TimeSpan diff = dtpDenGio.Value - dtpTuGio.Value;
            nudTongSoGio.Value = diff.TotalHours > 0 ? (decimal)diff.TotalHours : 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            using var db = new AppDbContext();

            db.DonTangCas.Add(new DonTangCa
            {
                NhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue),
                NgayLam = dtpNgayLam.Value.Date,
                TuGio = dtpTuGio.Value,
                DenGio = dtpDenGio.Value,
                TongSoGio = (double)nudTongSoGio.Value,
                LyDo = ValidationHelper.NormalizeText(txtLyDo.Text),
                TrangThai = cboTrangThai.Text,
                NgayTao = DateTime.Now
            });

            db.SaveChanges();
            MessageBox.Show("Thêm đơn tăng ca thành công!");
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

            var don = db.DonTangCas.FirstOrDefault(x => x.Id == _idDangChon);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn tăng ca!");
                return;
            }

            don.NhanVienId = Convert.ToInt32(cboNhanVien.SelectedValue);
            don.NgayLam = dtpNgayLam.Value.Date;
            don.TuGio = dtpTuGio.Value;
            don.DenGio = dtpDenGio.Value;
            don.TongSoGio = (double)nudTongSoGio.Value;
            don.LyDo = ValidationHelper.NormalizeText(txtLyDo.Text);
            don.TrangThai = cboTrangThai.Text;
            don.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cập nhật đơn tăng ca thành công!");
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

            var don = db.DonTangCas.FirstOrDefault(x => x.Id == _idDangChon);
            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn tăng ca!");
                return;
            }

            db.DonTangCas.Remove(don);
            db.SaveChanges();

            MessageBox.Show("Xóa đơn tăng ca thành công!");
            TaiDuLieu();
            LamMoi();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvDonTangCa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvDonTangCa.Rows[e.RowIndex].Cells["Id"].Value);

            using var db = new AppDbContext();
            var don = db.DonTangCas.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (don == null) return;

            _idDangChon = don.Id;
            cboNhanVien.SelectedValue = don.NhanVienId;
            dtpNgayLam.Value = don.NgayLam;
            dtpTuGio.Value = don.TuGio;
            dtpDenGio.Value = don.DenGio;
            nudTongSoGio.Value = (decimal)don.TongSoGio;
            txtLyDo.Text = don.LyDo;
            cboTrangThai.Text = don.TrangThai;
        }
    }
}
