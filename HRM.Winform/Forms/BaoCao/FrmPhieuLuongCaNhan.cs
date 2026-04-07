using HRM.Winform.Helpers;

namespace HRM.Winform.Forms.BaoCao
{
    public class FrmPhieuLuongCaNhan : Form
    {
        private readonly int _thang;
        private readonly int _nam;
        private readonly int _nhanVienId;

        private readonly Panel _pnlPaper = new();
        private readonly Label _lblCompany = new();
        private readonly Label _lblTitle = new();
        private readonly Label _lblPeriod = new();
        private readonly Label _lblHoTen = new();
        private readonly Label _lblMaNhanVien = new();
        private readonly Label _lblPhongBan = new();
        private readonly Label _lblChucVu = new();
        private readonly Label _lblLuongCoBan = new();
        private readonly Label _lblNgayCong = new();
        private readonly Label _lblNghiLuong = new();
        private readonly Label _lblNghiKhongLuong = new();
        private readonly Label _lblOt = new();
        private readonly Label _lblTienOt = new();
        private readonly Label _lblKhauTru = new();
        private readonly Label _lblThucNhan = new();
        private readonly Label _lblFooter = new();
        private readonly Button _btnIn = new();
        private readonly Button _btnXuatPdf = new();
        private readonly Button _btnDong = new();
        private SalaryRowDto? _salary;

        public FrmPhieuLuongCaNhan(int thang, int nam, int nhanVienId)
        {
            _thang = thang;
            _nam = nam;
            _nhanVienId = nhanVienId;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            BackColor = ThemeHelper.AppBackColor;
            ClientSize = new Size(900, 760);
            MinimumSize = new Size(820, 700);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Phieu luong ca nhan";

            _pnlPaper.Location = new Point(28, 24);
            _pnlPaper.Size = new Size(828, 660);
            _pnlPaper.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pnlPaper.Padding = new Padding(34, 28, 34, 28);
            ThemeHelper.ApplyCard(_pnlPaper);

            _lblCompany.AutoSize = true;
            _lblCompany.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            _lblCompany.ForeColor = ThemeHelper.PrimaryColor;
            _lblCompany.Location = new Point(34, 28);
            _lblCompany.Text = "HRM HUMAN RESOURCE MANAGER";

            _lblTitle.AutoSize = true;
            _lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            _lblTitle.ForeColor = ThemeHelper.TextPrimary;
            _lblTitle.Location = new Point(34, 64);
            _lblTitle.Text = "PHIEU LUONG CA NHAN";

            _lblPeriod.AutoSize = true;
            _lblPeriod.Font = new Font("Segoe UI", 11F);
            _lblPeriod.ForeColor = ThemeHelper.TextSecondary;
            _lblPeriod.Location = new Point(36, 116);

            _lblHoTen.Location = new Point(36, 168);
            _lblHoTen.Size = new Size(360, 28);
            _lblHoTen.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            _lblMaNhanVien.Location = new Point(430, 168);
            _lblMaNhanVien.Size = new Size(300, 28);
            _lblMaNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            _lblPhongBan.Location = new Point(36, 206);
            _lblPhongBan.Size = new Size(360, 26);
            _lblPhongBan.Font = new Font("Segoe UI", 10F);

            _lblChucVu.Location = new Point(430, 206);
            _lblChucVu.Size = new Size(300, 26);
            _lblChucVu.Font = new Font("Segoe UI", 10F);

            _lblLuongCoBan.Location = new Point(36, 272);
            _lblLuongCoBan.Size = new Size(340, 32);
            _lblLuongCoBan.Font = new Font("Segoe UI", 11F);

            _lblNgayCong.Location = new Point(36, 314);
            _lblNgayCong.Size = new Size(340, 32);
            _lblNgayCong.Font = new Font("Segoe UI", 11F);

            _lblNghiLuong.Location = new Point(36, 356);
            _lblNghiLuong.Size = new Size(340, 32);
            _lblNghiLuong.Font = new Font("Segoe UI", 11F);

            _lblNghiKhongLuong.Location = new Point(36, 398);
            _lblNghiKhongLuong.Size = new Size(340, 32);
            _lblNghiKhongLuong.Font = new Font("Segoe UI", 11F);

            _lblOt.Location = new Point(430, 272);
            _lblOt.Size = new Size(320, 32);
            _lblOt.Font = new Font("Segoe UI", 11F);

            _lblTienOt.Location = new Point(430, 314);
            _lblTienOt.Size = new Size(320, 32);
            _lblTienOt.Font = new Font("Segoe UI", 11F);

            _lblKhauTru.Location = new Point(430, 356);
            _lblKhauTru.Size = new Size(320, 32);
            _lblKhauTru.Font = new Font("Segoe UI", 11F);

            _lblThucNhan.Location = new Point(36, 478);
            _lblThucNhan.Size = new Size(714, 76);
            _lblThucNhan.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            _lblThucNhan.ForeColor = Color.FromArgb(22, 101, 52);
            _lblThucNhan.BackColor = Color.FromArgb(236, 253, 245);
            _lblThucNhan.Padding = new Padding(18, 14, 18, 14);

            _lblFooter.Location = new Point(36, 586);
            _lblFooter.Size = new Size(714, 44);
            _lblFooter.Font = new Font("Segoe UI", 9.5F);
            _lblFooter.ForeColor = ThemeHelper.TextSecondary;
            _lblFooter.Text = "Phieu luong tam tinh duoc tong hop tu bang cong, nghi phep va tang ca da duyet trong ky.";

            _pnlPaper.Controls.AddRange(
            [
                _lblCompany, _lblTitle, _lblPeriod, _lblHoTen, _lblMaNhanVien, _lblPhongBan, _lblChucVu,
                _lblLuongCoBan, _lblNgayCong, _lblNghiLuong, _lblNghiKhongLuong,
                _lblOt, _lblTienOt, _lblKhauTru, _lblThucNhan, _lblFooter
            ]);

            _btnDong.Text = "Dong";
            _btnDong.Size = new Size(120, 38);
            _btnDong.Location = new Point(736, 696);
            _btnDong.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeHelper.ApplyPrimaryButton(_btnDong);
            _btnDong.Click += (_, _) => Close();

            _btnIn.Text = "In";
            _btnIn.Size = new Size(120, 38);
            _btnIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeHelper.ApplySecondaryButton(_btnIn);
            _btnIn.Click += async (_, _) => await InPhieuLuongAsync();

            _btnXuatPdf.Text = "Xuat PDF";
            _btnXuatPdf.Size = new Size(140, 38);
            _btnXuatPdf.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ThemeHelper.ApplySecondaryButton(_btnXuatPdf);
            _btnXuatPdf.Click += async (_, _) => await XuatPdfAsync();

            Controls.Add(_pnlPaper);
            Controls.Add(_btnIn);
            Controls.Add(_btnXuatPdf);
            Controls.Add(_btnDong);

            Load += FrmPhieuLuongCaNhan_Load;
            Resize += (_, _) => ApplyResponsiveLayout();
            ResumeLayout(false);
        }

        private void FrmPhieuLuongCaNhan_Load(object? sender, EventArgs e)
        {
            _lblPeriod.Text = $"Ky luong thang {_thang:00}/{_nam}";
            TaiDuLieu();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            _pnlPaper.Size = new Size(ClientSize.Width - 56, ClientSize.Height - 104);
            _btnDong.Location = new Point(ClientSize.Width - _btnDong.Width - 24, ClientSize.Height - _btnDong.Height - 18);
            _btnXuatPdf.Location = new Point(_btnDong.Left - _btnXuatPdf.Width - 12, _btnDong.Top);
            _btnIn.Location = new Point(_btnXuatPdf.Left - _btnIn.Width - 12, _btnDong.Top);
        }

        private void TaiDuLieu()
        {
            _salary = SalaryCalculationService.GetMonthlySalaries(_thang, _nam, _nhanVienId).FirstOrDefault();
            if (_salary == null)
            {
                MessageBox.Show("Khong tim thay du lieu luong cho nhan vien nay.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            _lblHoTen.Text = $"Ho ten: {_salary.HoTen}";
            _lblMaNhanVien.Text = $"Ma nhan vien: {_salary.MaNhanVien}";
            _lblPhongBan.Text = $"Phong ban: {_salary.PhongBan}";
            _lblChucVu.Text = $"Chuc vu: {_salary.ChucVu}";
            _lblLuongCoBan.Text = $"Luong co ban: {_salary.LuongCoBan:N0} VND";
            _lblNgayCong.Text = $"Ngay cong huong luong: {_salary.NgayCongHuongLuong:N1} ngay";
            _lblNghiLuong.Text = $"Nghi co luong: {_salary.NghiHuongLuong:N1} ngay";
            _lblNghiKhongLuong.Text = $"Nghi khong luong/vang: {_salary.NghiKhongLuong:N1} ngay";
            _lblOt.Text = $"Tong gio tang ca: {_salary.TongGioTangCa:N1} gio";
            _lblTienOt.Text = $"Tien tang ca: {_salary.TienTangCa:N0} VND";
            _lblKhauTru.Text = $"Tong khau tru: {_salary.TongKhauTru:N0} VND";
            _lblThucNhan.Text = $"Luong thuc nhan: {_salary.LuongThucNhan:N0} VND";
        }

        private Task InPhieuLuongAsync()
        {
            if (_salary == null)
            {
                return Task.CompletedTask;
            }

            PayslipDocumentHelper.Print(this, _salary, _thang, _nam);
            return Task.CompletedTask;
        }

        private Task XuatPdfAsync()
        {
            if (_salary == null)
            {
                return Task.CompletedTask;
            }

            PayslipDocumentHelper.ExportPdf(this, _salary, _thang, _nam);
            return Task.CompletedTask;
        }
    }
}
