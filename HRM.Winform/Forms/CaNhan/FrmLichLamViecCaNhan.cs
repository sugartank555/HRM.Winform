using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.CaNhan
{
    public partial class FrmLichLamViecCaNhan : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmLichLamViecCaNhan()
        {
            InitializeComponent();
        }

        private void FrmLichLamViecCaNhan_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            ApplyResponsiveLayout();
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today.AddDays(14);
            TaiDuLieu();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            pnlTop.BackColor = Color.White;
            pnlGrid.BackColor = Color.White;

            btnXem.BackColor = Color.FromArgb(37, 99, 235);
            btnXem.ForeColor = Color.White;
            btnXem.FlatStyle = FlatStyle.Flat;
            btnXem.FlatAppearance.BorderSize = 0;

            btnYeuCauDoiCa.BackColor = Color.White;
            btnYeuCauDoiCa.ForeColor = Color.FromArgb(37, 99, 235);
            btnYeuCauDoiCa.FlatStyle = FlatStyle.Flat;
            btnYeuCauDoiCa.FlatAppearance.BorderSize = 1;
            btnYeuCauDoiCa.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);

            dgvLich.BackgroundColor = Color.White;
            dgvLich.BorderStyle = BorderStyle.None;
            dgvLich.RowHeadersVisible = false;
            dgvLich.AutoGenerateColumns = false;
            dgvLich.AllowUserToAddRows = false;
            dgvLich.ReadOnly = true;
            dgvLich.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLich.Columns.Clear();
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngay", DataPropertyName = "NgayLamViec", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thu", DataPropertyName = "Thu", Width = 110 });
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ca lam viec", DataPropertyName = "TenCa", Width = 190 });
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bat dau", DataPropertyName = "GioBatDau", Width = 100 });
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ket thuc", DataPropertyName = "GioKetThuc", Width = 100 });
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loai ca", DataPropertyName = "LoaiCa", Width = 150 });
            dgvLich.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chu", DataPropertyName = "GhiChu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            _gridHelper ??= new DataGridSearchPaginationHelper(dgvLich);
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            var tuNgay = dtpTuNgay.Value.Date;
            var denNgay = dtpDenNgay.Value.Date;

            var ds = db.PhanCaNhanViens
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec >= tuNgay && x.NgayLamViec <= denNgay)
                .OrderBy(x => x.NgayLamViec)
                .Select(x => new
                {
                    x.NgayLamViec,
                    Thu = x.NgayLamViec.ToString("dddd"),
                    TenCa = x.CaLamViec != null ? x.CaLamViec.TenCa : "",
                    GioBatDau = x.CaLamViec != null ? x.CaLamViec.GioBatDau.ToString(@"hh\:mm") : "",
                    GioKetThuc = x.CaLamViec != null ? x.CaLamViec.GioKetThuc.ToString(@"hh\:mm") : "",
                    LoaiCa = XacDinhLoaiCa(x.CaLamViec != null ? x.CaLamViec.TenCa : ""),
                    GhiChu = TaoGhiChu(x.NgayLamViec)
                })
                .ToList();

            _gridHelper?.ApplyData(ds);

            lblCaHomNay.Text = ds.Count(x => x.NgayLamViec == DateTime.Today).ToString();
            lblCaTuanNay.Text = ds.Count(x => x.NgayLamViec >= DateTime.Today && x.NgayLamViec < DateTime.Today.AddDays(7)).ToString();
            lblCaDacBiet.Text = ds.Count(x => x.LoaiCa != "Ca thuong").ToString();
        }

        private static string XacDinhLoaiCa(string tenCa)
        {
            var lower = tenCa.ToLowerInvariant();
            if (lower.Contains("dem")) return "Ca dem";
            if (lower.Contains("le")) return "Ca le";
            if (lower.Contains("tang cuong")) return "Ca tang cuong";
            return "Ca thuong";
        }

        private static string TaoGhiChu(DateTime ngayLamViec)
        {
            if (ngayLamViec.Date == DateTime.Today) return "Ca hom nay";
            if (ngayLamViec.Date == DateTime.Today.AddDays(1)) return "Sap den ca";
            return string.Empty;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                MessageBox.Show("Den ngay phai lon hon hoac bang tu ngay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiDuLieu();
        }

        private void btnYeuCauDoiCa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Da san sang luong yeu cau doi ca.\n\nBuoc tiep theo nen them bang YeuCauDoiCa de luu nguoi doi, ngay can doi va trang thai phe duyet.",
                "Yeu cau doi ca",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ApplyResponsiveLayout()
        {
            int right = pnlTop.ClientSize.Width - 24;
            btnYeuCauDoiCa.Left = right - btnYeuCauDoiCa.Width;
            btnXem.Left = btnYeuCauDoiCa.Left - 12 - btnXem.Width;
            dtpDenNgay.Left = btnXem.Left - 16 - dtpDenNgay.Width;
            lblDenNgay.Left = dtpDenNgay.Left;
            dtpTuNgay.Left = dtpDenNgay.Left - 16 - dtpTuNgay.Width;
            lblTuNgay.Left = dtpTuNgay.Left;

            int metricWidth = 120;
            int gap = 42;
            int x3 = right - metricWidth;
            int x2 = x3 - gap - metricWidth;
            int x1 = x2 - gap - metricWidth;

            PositionMetric(lblCaHomNayTitle, lblCaHomNay, x1, metricWidth);
            PositionMetric(lblCaTuanNayTitle, lblCaTuanNay, x2, metricWidth);
            PositionMetric(lblCaDacBietTitle, lblCaDacBiet, x3, metricWidth);
        }

        private static void PositionMetric(Control title, Control value, int x, int width)
        {
            title.Left = x;
            title.Width = width;
            value.Left = x;
        }
    }
}
