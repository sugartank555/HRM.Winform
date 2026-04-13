using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.NhanSu
{
    public class FrmDuyetDangKyLaiKhuonMat : Form
    {
        private readonly Label lblTitle = new();
        private readonly Label lblSubtitle = new();
        private readonly Label lblTong = new();
        private readonly DataGridView dgvRequests = new();
        private readonly Button btnLamMoi = new();
        private readonly Button btnDuyet = new();
        private readonly Button btnTuChoi = new();
        private DataGridSearchPaginationHelper? _gridHelper;

        public FrmDuyetDangKyLaiKhuonMat()
        {
            InitializeComponent();
            _gridHelper = new DataGridSearchPaginationHelper(dgvRequests);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            Text = "Duyet dang ky lai khuon mat";
            BackColor = ThemeHelper.AppBackColor;
            ClientSize = new Size(1260, 760);
            MinimumSize = new Size(1120, 700);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = ThemeHelper.TextPrimary;
            lblTitle.Location = new Point(24, 18);
            lblTitle.Text = "Duyệt đăng ký lại khuôn mặt";

            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = ThemeHelper.TextSecondary;
            lblSubtitle.Location = new Point(28, 62);
            lblSubtitle.Text = "Admin/HR duyệt yêu cầu mở khóa đăng ký lại khuôn mặt của nhân viên.";

            btnLamMoi.Location = new Point(24, 100);
            btnLamMoi.Size = new Size(110, 36);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Click += (_, _) => TaiDuLieu();
            ThemeHelper.ApplySecondaryButton(btnLamMoi);

            btnDuyet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDuyet.Location = new Point(1018, 100);
            btnDuyet.Size = new Size(110, 36);
            btnDuyet.Text = "Duyệt";
            btnDuyet.Click += btnDuyet_Click;
            ThemeHelper.ApplyPrimaryButton(btnDuyet);

            btnTuChoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTuChoi.Location = new Point(1142, 100);
            btnTuChoi.Size = new Size(110, 36);
            btnTuChoi.Text = "Từ chối";
            btnTuChoi.Click += btnTuChoi_Click;
            ThemeHelper.ApplyDangerButton(btnTuChoi);

            lblTong.AutoSize = true;
            lblTong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTong.ForeColor = ThemeHelper.TextPrimary;
            lblTong.Location = new Point(28, 152);
            lblTong.Text = "Tổng yêu cầu: 0";

            dgvRequests.Location = new Point(24, 184);
            dgvRequests.Size = new Size(1228, 544);
            dgvRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDuyet);
            Controls.Add(btnTuChoi);
            Controls.Add(lblTong);
            Controls.Add(dgvRequests);

            Load += FrmDuyetDangKyLaiKhuonMat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void FrmDuyetDangKyLaiKhuonMat_Load(object? sender, EventArgs e)
        {
            ThemeHelper.ApplyDataGrid(dgvRequests);
            ConfigureGrid();
            TaiDuLieu();
            Resize += (_, _) => _gridHelper?.RefreshLayout();
        }

        private void ConfigureGrid()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = false;
            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.Columns.Clear();
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { Name = "RequestId", DataPropertyName = "RequestId", Visible = false });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "MaNhanVien", FillWeight = 70, MinimumWidth = 80 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ tên", DataPropertyName = "HoTen", FillWeight = 120, MinimumWidth = 130 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Yêu cầu lúc", DataPropertyName = "RequestedAt", FillWeight = 95, MinimumWidth = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Người gửi", DataPropertyName = "RequestedBy", FillWeight = 90, MinimumWidth = 100 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = "Status", FillWeight = 80, MinimumWidth = 90 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ghi chú", DataPropertyName = "Note", FillWeight = 150, MinimumWidth = 140 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Duyệt bởi", DataPropertyName = "ReviewedBy", FillWeight = 90, MinimumWidth = 100 });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Duyệt lúc", DataPropertyName = "ReviewedAt", FillWeight = 95, MinimumWidth = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "KQ mở khóa", DataPropertyName = "UnlockInfo", FillWeight = 110, MinimumWidth = 120 });
            dgvRequests.CellFormatting += dgvRequests_CellFormatting;
        }

        private void TaiDuLieu()
        {
            var data = FaceRegistrationResetRequestStore.LoadAll()
                .Select(x => new
                {
                    x.RequestId,
                    x.MaNhanVien,
                    x.HoTen,
                    x.RequestedAt,
                    x.RequestedBy,
                    x.Status,
                    x.Note,
                    x.ReviewedBy,
                    x.ReviewedAt,
                    UnlockInfo = x.Status == "DaDuyet"
                        ? (x.UnlockUsed ? $"Da dung luc {x.UnlockUsedAt:dd/MM HH:mm}" : "Da mo khoa 1 lan")
                        : x.Status == "TuChoi" ? "Khong duoc mo khoa" : "Dang cho duyet"
                })
                .ToList();

            _gridHelper?.ApplyData(data);
            lblTong.Text = $"Tổng yêu cầu: {data.Count}";
        }

        private string? GetSelectedRequestId()
        {
            return dgvRequests.CurrentRow?.Cells["RequestId"].Value?.ToString();
        }

        private void btnDuyet_Click(object? sender, EventArgs e)
        {
            var requestId = GetSelectedRequestId();
            if (string.IsNullOrWhiteSpace(requestId))
            {
                MessageBox.Show("Chọn yêu cầu cần duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FaceRegistrationResetRequestStore.Approve(requestId, CurrentUser.TenDangNhap, "Admin/HR da mo khoa dang ky lai khuon mat.");
            AttendanceAuditStore.Save(new AttendanceAuditEntry
            {
                NhanVienId = 0,
                MaNhanVien = "ADMIN",
                HoTen = CurrentUser.HoTen,
                ThoiGian = DateTime.Now,
                HanhDong = "DuyetDangKyLaiKhuonMat",
                PhuongThuc = "KhuonMat",
                KetQua = "ThanhCong",
                ChiTiet = $"Da duyet yeu cau {requestId}."
            });
            TaiDuLieu();
        }

        private void btnTuChoi_Click(object? sender, EventArgs e)
        {
            var requestId = GetSelectedRequestId();
            if (string.IsNullOrWhiteSpace(requestId))
            {
                MessageBox.Show("Chọn yêu cầu cần từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FaceRegistrationResetRequestStore.Reject(requestId, CurrentUser.TenDangNhap, "Admin/HR tu choi mo khoa dang ky lai khuon mat.");
            TaiDuLieu();
        }

        private void dgvRequests_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string status = dgvRequests.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? string.Empty;
            var row = dgvRequests.Rows[e.RowIndex];

            if (status == "ChoDuyet")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 247, 237);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 215, 170);
            }
            else if (status == "DaDuyet")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(236, 253, 245);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(167, 243, 208);
            }
            else if (status == "TuChoi")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(252, 165, 165);
            }
        }
    }
}
