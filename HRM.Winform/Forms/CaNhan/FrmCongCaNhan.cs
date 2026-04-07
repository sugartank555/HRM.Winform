using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.CaNhan
{
    public partial class FrmCongCaNhan : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmCongCaNhan()
        {
            InitializeComponent();
        }

        private void FrmCongCaNhan_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            ApplyResponsiveLayout();
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;
            TaiDuLieu();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            pnlFilter.BackColor = Color.White;
            pnlSummary.BackColor = Color.White;
            pnlGrid.BackColor = Color.White;

            dgvCong.BackgroundColor = Color.White;
            dgvCong.BorderStyle = BorderStyle.None;
            dgvCong.RowHeadersVisible = false;
            dgvCong.AllowUserToAddRows = false;
            dgvCong.ReadOnly = true;
            dgvCong.AutoGenerateColumns = false;
            dgvCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCong.Columns.Clear();
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngay", DataPropertyName = "NgayLamViec", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ca", DataPropertyName = "TenCa", Width = 150 });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check in", DataPropertyName = "GioCheckIn", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Check out", DataPropertyName = "GioCheckOut", Width = 140, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Gio lam", DataPropertyName = "SoGioLam", Width = 90 });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Di muon", DataPropertyName = "SoPhutDiMuon", Width = 90 });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ve som", DataPropertyName = "SoPhutVeSom", Width = 90 });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tang ca", DataPropertyName = "SoGioTangCa", Width = 90 });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trang thai", DataPropertyName = "TrangThai", Width = 110 });
            dgvCong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chu", DataPropertyName = "GhiChu", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            btnLoc.BackColor = Color.FromArgb(37, 99, 235);
            btnLoc.ForeColor = Color.White;
            btnLoc.FlatStyle = FlatStyle.Flat;
            btnLoc.FlatAppearance.BorderSize = 0;
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvCong);
        }

        private void TaiDuLieu()
        {
            using var db = new AppDbContext();

            var tuNgay = dtpTuNgay.Value.Date;
            var denNgay = dtpDenNgay.Value.Date;

            var ds = db.ChamCongs
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId && x.NgayLamViec >= tuNgay && x.NgayLamViec <= denNgay)
                .OrderByDescending(x => x.NgayLamViec)
                .Select(x => new
                {
                    x.NgayLamViec,
                    TenCa = x.CaLamViec != null ? x.CaLamViec.TenCa : "",
                    x.GioCheckIn,
                    x.GioCheckOut,
                    x.SoGioLam,
                    x.SoPhutDiMuon,
                    x.SoPhutVeSom,
                    x.SoGioTangCa,
                    x.TrangThai,
                    x.GhiChu
                })
                .ToList();

            _gridHelper?.ApplyData(ds);

            var tongTangCaDaDuyet = db.DonTangCas
                .AsNoTracking()
                .Where(x => x.NhanVienId == CurrentUser.NhanVienId && x.TrangThai == "DaDuyet" && x.NgayLam >= tuNgay && x.NgayLam <= denNgay)
                .Sum(x => (double?)x.TongSoGio) ?? 0;

            lblTongNgayCong.Text = ds.Count.ToString();
            lblTongGioLam.Text = $"{ds.Sum(x => x.SoGioLam):N1} gio";
            lblDiMuon.Text = $"{ds.Sum(x => x.SoPhutDiMuon)} phut";
            lblTangCa.Text = $"{tongTangCaDaDuyet:N1} gio";
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
            {
                MessageBox.Show("Den ngay phai lon hon hoac bang tu ngay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiDuLieu();
        }

        private void ApplyResponsiveLayout()
        {
            int right = pnlFilter.ClientSize.Width - 24;
            btnLoc.Left = right - btnLoc.Width;
            dtpDenNgay.Left = btnLoc.Left - 16 - dtpDenNgay.Width;
            lblDenNgay.Left = dtpDenNgay.Left;
            dtpTuNgay.Left = dtpDenNgay.Left - 16 - dtpTuNgay.Width;
            lblTuNgay.Left = dtpTuNgay.Left;

            int gap = 24;
            int sectionWidth = Math.Max(140, (pnlSummary.ClientSize.Width - 48 - gap * 3) / 4);
            int startX = 24;

            PositionSummaryBlock(lblTongNgayCongTitle, lblTongNgayCong, startX, sectionWidth);
            PositionSummaryBlock(lblTongGioLamTitle, lblTongGioLam, startX + sectionWidth + gap, sectionWidth);
            PositionSummaryBlock(lblDiMuonTitle, lblDiMuon, startX + (sectionWidth + gap) * 2, sectionWidth);
            PositionSummaryBlock(lblTangCaTitle, lblTangCa, startX + (sectionWidth + gap) * 3, sectionWidth);
        }

        private static void PositionSummaryBlock(Control title, Control value, int x, int width)
        {
            title.Left = x;
            title.Width = width;
            value.Left = x;
        }
    }
}
