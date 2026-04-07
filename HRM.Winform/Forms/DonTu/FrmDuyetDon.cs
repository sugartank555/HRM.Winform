using HRM.Winform.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.DonTu
{
    public partial class FrmDuyetDon : Form
    {
        private HRM.Winform.Helpers.DataGridSearchPaginationHelper? _nghiPhepGridHelper;
        private HRM.Winform.Helpers.DataGridSearchPaginationHelper? _tangCaGridHelper;

        public FrmDuyetDon()
        {
            InitializeComponent();
        }

        private void FrmDuyetDon_Load(object sender, EventArgs e)
        {
            CaiDatGridNghiPhep();
            CaiDatGridTangCa();
            _nghiPhepGridHelper ??= new HRM.Winform.Helpers.DataGridSearchPaginationHelper(dgvNghiPhep);
            _tangCaGridHelper ??= new HRM.Winform.Helpers.DataGridSearchPaginationHelper(dgvTangCa);
            TaiDonNghiPhep();
            TaiDonTangCa();
            _nghiPhepGridHelper?.RefreshLayout();
            _tangCaGridHelper?.RefreshLayout();
            Resize += (_, _) =>
            {
                _nghiPhepGridHelper?.RefreshLayout();
                _tangCaGridHelper?.RefreshLayout();
            };
            tabControl1.SelectedIndexChanged += (_, _) =>
            {
                _nghiPhepGridHelper?.RefreshLayout();
                _tangCaGridHelper?.RefreshLayout();
            };
        }

        private void CaiDatGridNghiPhep()
        {
            dgvNghiPhep.AutoGenerateColumns = false;
            dgvNghiPhep.Columns.Clear();

            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 90 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 160 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại nghỉ", DataPropertyName = "TenLoaiNghi", Width = 130 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Từ ngày", DataPropertyName = "TuNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đến ngày", DataPropertyName = "DenNgay", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số ngày", DataPropertyName = "TongSoNgay", Width = 80 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lý do", DataPropertyName = "LyDo", Width = 180 });
            dgvNghiPhep.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });

            dgvNghiPhep.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNghiPhep.MultiSelect = false;
            dgvNghiPhep.ReadOnly = true;
            dgvNghiPhep.AllowUserToAddRows = false;
        }

        private void CaiDatGridTangCa()
        {
            dgvTangCa.AutoGenerateColumns = false;
            dgvTangCa.Columns.Clear();

            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", Width = 90 });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", Width = 160 });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày làm", DataPropertyName = "NgayLam", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Từ giờ", DataPropertyName = "TuGio", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đến giờ", DataPropertyName = "DenGio", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng giờ", DataPropertyName = "TongSoGio", Width = 80 });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lý do", DataPropertyName = "LyDo", Width = 180 });
            dgvTangCa.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = "TrangThai", Width = 100 });

            dgvTangCa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTangCa.MultiSelect = false;
            dgvTangCa.ReadOnly = true;
            dgvTangCa.AllowUserToAddRows = false;
        }

        private void TaiDonNghiPhep()
        {
            using var db = new AppDbContext();

            var ds = db.DonNghiPheps
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .Include(x => x.LoaiNghiPhep)
                .OrderByDescending(x => x.TuNgay)
                .Select(x => new
                {
                    x.Id,
                    MaNhanVien = x.NhanVien != null ? x.NhanVien.MaNhanVien : "",
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "",
                    TenLoaiNghi = x.LoaiNghiPhep != null ? x.LoaiNghiPhep.TenLoaiNghi : "",
                    x.TuNgay,
                    x.DenNgay,
                    x.TongSoNgay,
                    x.LyDo,
                    x.TrangThai
                })
                .ToList();

            _nghiPhepGridHelper?.ApplyData(ds);
        }

        private void TaiDonTangCa()
        {
            using var db = new AppDbContext();

            var ds = db.DonTangCas
                .AsNoTracking()
                .Include(x => x.NhanVien)
                .OrderByDescending(x => x.NgayLam)
                .Select(x => new
                {
                    x.Id,
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

            _tangCaGridHelper?.ApplyData(ds);
        }

        private void btnDuyetNghiPhep_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhep.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn nghỉ phép!");
                return;
            }

            int id = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["Id"].Value);

            using var db = new AppDbContext();
            var don = db.DonNghiPheps.FirstOrDefault(x => x.Id == id);
            if (don == null) return;

            don.TrangThai = "DaDuyet";
            don.NgayDuyet = DateTime.Now;
            don.NguoiDuyet = "Admin";
            don.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Đã duyệt đơn nghỉ phép!");
            TaiDonNghiPhep();
        }

        private void btnTuChoiNghiPhep_Click(object sender, EventArgs e)
        {
            if (dgvNghiPhep.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn nghỉ phép!");
                return;
            }

            int id = Convert.ToInt32(dgvNghiPhep.CurrentRow.Cells["Id"].Value);

            using var db = new AppDbContext();
            var don = db.DonNghiPheps.FirstOrDefault(x => x.Id == id);
            if (don == null) return;

            don.TrangThai = "TuChoi";
            don.NgayDuyet = DateTime.Now;
            don.NguoiDuyet = "Admin";
            don.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Đã từ chối đơn nghỉ phép!");
            TaiDonNghiPhep();
        }

        private void btnDuyetTangCa_Click(object sender, EventArgs e)
        {
            if (dgvTangCa.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn tăng ca!");
                return;
            }

            int id = Convert.ToInt32(dgvTangCa.CurrentRow.Cells["Id"].Value);

            using var db = new AppDbContext();
            var don = db.DonTangCas.FirstOrDefault(x => x.Id == id);
            if (don == null) return;

            don.TrangThai = "DaDuyet";
            don.NgayDuyet = DateTime.Now;
            don.NguoiDuyet = "Admin";
            don.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Đã duyệt đơn tăng ca!");
            TaiDonTangCa();
        }

        private void btnTuChoiTangCa_Click(object sender, EventArgs e)
        {
            if (dgvTangCa.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn tăng ca!");
                return;
            }

            int id = Convert.ToInt32(dgvTangCa.CurrentRow.Cells["Id"].Value);

            using var db = new AppDbContext();
            var don = db.DonTangCas.FirstOrDefault(x => x.Id == id);
            if (don == null) return;

            don.TrangThai = "TuChoi";
            don.NgayDuyet = DateTime.Now;
            don.NguoiDuyet = "Admin";
            don.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Đã từ chối đơn tăng ca!");
            TaiDonTangCa();
        }
    }
}
