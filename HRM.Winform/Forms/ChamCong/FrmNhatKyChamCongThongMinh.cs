using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.ChamCong
{
    public class FrmNhatKyChamCongThongMinh : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;
        private readonly Label lblTitle = new();
        private readonly Label lblSubtitle = new();
        private readonly Label lblNhanVien = new();
        private readonly ComboBox cboNhanVien = new();
        private readonly Label lblTuNgay = new();
        private readonly DateTimePicker dtpTuNgay = new();
        private readonly Label lblDenNgay = new();
        private readonly DateTimePicker dtpDenNgay = new();
        private readonly Button btnXem = new();
        private readonly Label lblTong = new();
        private readonly DataGridView dgvLogs = new();

        public FrmNhatKyChamCongThongMinh()
        {
            InitializeComponent();
            _gridHelper ??= new DataGridSearchPaginationHelper(dgvLogs);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Text = "Nhat ky cham cong thong minh";
            BackColor = ThemeHelper.AppBackColor;
            ClientSize = new Size(1280, 780);
            MinimumSize = new Size(1120, 700);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = ThemeHelper.TextPrimary;
            lblTitle.Location = new Point(24, 22);
            lblTitle.Text = "Nhat ky cham cong thong minh";

            lblSubtitle.AutoSize = false;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = ThemeHelper.TextSecondary;
            lblSubtitle.Location = new Point(26, 62);
            lblSubtitle.Size = new Size(800, 24);
            lblSubtitle.Text = "Theo doi lich su check in/check out bang QR, GPS, Khuon mat va ket qua xac thuc.";

            lblNhanVien.AutoSize = true;
            lblNhanVien.Location = new Point(28, 108);
            lblNhanVien.Text = "Nhan vien";

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Location = new Point(106, 104);
            cboNhanVien.Size = new Size(280, 28);

            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(414, 108);
            lblTuNgay.Text = "Tu ngay";

            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(474, 104);
            dtpTuNgay.Size = new Size(120, 27);

            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(620, 108);
            lblDenNgay.Text = "Den ngay";

            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(690, 104);
            dtpDenNgay.Size = new Size(120, 27);

            btnXem.Location = new Point(836, 100);
            btnXem.Size = new Size(110, 34);
            btnXem.Text = "Xem nhat ky";
            btnXem.Click += btnXem_Click;
            ThemeHelper.ApplyPrimaryButton(btnXem);

            lblTong.AutoSize = true;
            lblTong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTong.ForeColor = ThemeHelper.TextPrimary;
            lblTong.Location = new Point(28, 150);
            lblTong.Text = "Tong ban ghi: 0";

            dgvLogs.Location = new Point(24, 182);
            dgvLogs.Size = new Size(1232, 560);
            dgvLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(lblNhanVien);
            Controls.Add(cboNhanVien);
            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(btnXem);
            Controls.Add(lblTong);
            Controls.Add(dgvLogs);

            Load += FrmNhatKyChamCongThongMinh_Load;
            ResumeLayout(false);
        }

        private void FrmNhatKyChamCongThongMinh_Load(object? sender, EventArgs e)
        {
            ThemeHelper.ApplyInput(cboNhanVien);
            ThemeHelper.ApplyDataGrid(dgvLogs);
            ConfigureGrid();
            TaiNhanVien();
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;
            TaiDuLieu();
        }

        private void ConfigureGrid()
        {
            dgvLogs.AutoGenerateColumns = false;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogs.Columns.Clear();
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thoi gian", DataPropertyName = "ThoiGian", FillWeight = 105, MinimumWidth = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" } });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ma NV", DataPropertyName = "MaNhanVien", FillWeight = 70, MinimumWidth = 80 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ho ten", DataPropertyName = "HoTen", FillWeight = 110, MinimumWidth = 120 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hanh dong", DataPropertyName = "HanhDong", FillWeight = 80, MinimumWidth = 90 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Phuong thuc", DataPropertyName = "PhuongThuc", FillWeight = 80, MinimumWidth = 90 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ket qua", DataPropertyName = "KetQua", FillWeight = 80, MinimumWidth = 80 });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chi tiet", DataPropertyName = "ChiTiet", FillWeight = 240, MinimumWidth = 220 });
            dgvLogs.CellFormatting += dgvLogs_CellFormatting;
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

            ds.Insert(0, new { Id = 0, HienThi = "-- Tat ca --" });

            cboNhanVien.DataSource = ds;
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "Id";
            cboNhanVien.SelectedIndex = 0;

            bool laNhanVien = string.Equals(CurrentUser.VaiTro, "NhanVien", StringComparison.OrdinalIgnoreCase);
            cboNhanVien.Enabled = !laNhanVien;
            lblNhanVien.Visible = !laNhanVien;
            cboNhanVien.Visible = !laNhanVien;

            if (laNhanVien)
            {
                var index = ds.FindIndex(x => x.Id == CurrentUser.NhanVienId);
                if (index >= 0)
                {
                    cboNhanVien.SelectedIndex = index;
                }
            }
        }

        private void btnXem_Click(object? sender, EventArgs e)
        {
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            var fromDate = dtpTuNgay.Value.Date;
            var toDate = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
            int nhanVienId = GetNhanVienId();

            var data = AttendanceAuditStore.LoadAll()
                .Where(x => x.ThoiGian >= fromDate && x.ThoiGian <= toDate)
                .Where(x => nhanVienId == 0 || x.NhanVienId == nhanVienId)
                .OrderByDescending(x => x.ThoiGian)
                .ToList();

            _gridHelper?.ApplyData(data);
            lblTong.Text = $"Tong ban ghi: {data.Count}";
        }

        private int GetNhanVienId()
        {
            bool laNhanVien = string.Equals(CurrentUser.VaiTro, "NhanVien", StringComparison.OrdinalIgnoreCase);
            if (laNhanVien)
            {
                return CurrentUser.NhanVienId;
            }

            return int.TryParse(cboNhanVien.SelectedValue?.ToString(), out int id) ? id : 0;
        }

        private void dgvLogs_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var row = dgvLogs.Rows[e.RowIndex];
            string result = row.Cells[5].Value?.ToString() ?? string.Empty;

            if (result == "ThanhCong")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(220, 252, 231);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(134, 239, 172);
                row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 83, 45);
            }
            else if (result == "ThatBai")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 165, 165);
                row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(127, 29, 29);
            }
        }
    }
}
