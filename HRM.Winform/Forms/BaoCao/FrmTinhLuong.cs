using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.BaoCao
{
    public class FrmTinhLuong : Form
    {
        private DataGridSearchPaginationHelper? _gridHelper;
        private readonly Label _lblTitle;
        private readonly Label _lblSubtitle;
        private readonly Label _lblThang;
        private readonly Label _lblNam;
        private readonly Label _lblNhanVien;
        private readonly NumericUpDown _nudThang;
        private readonly NumericUpDown _nudNam;
        private readonly ComboBox _cboNhanVien;
        private readonly Button _btnXem;
        private readonly Button _btnXuatExcel;
        private readonly Button _btnPhieuLuong;
        private readonly Panel _pnlSummary;
        private readonly Label _lblTongNhanVien;
        private readonly Label _lblTongLuong;
        private readonly Label _lblTongOT;
        private readonly Label _lblTongKhauTru;
        private readonly DataGridView _dgvLuong;
        private List<SalaryRowDto> _duLieuHienTai = [];

        public FrmTinhLuong()
        {
            BackColor = ThemeHelper.AppBackColor;

            _lblTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextPrimary,
                Location = new Point(24, 18),
                Text = "Tinh luong"
            };

            _lblSubtitle = new Label
            {
                AutoSize = true,
                ForeColor = ThemeHelper.TextSecondary,
                Location = new Point(24, 60),
                Text = "Tam tinh luong theo luong co ban, ngay cong, nghi phep, tang ca va khau tru di muon."
            };

            _lblThang = new Label { AutoSize = true, Location = new Point(28, 104), Text = "Thang" };
            _lblNam = new Label { AutoSize = true, Location = new Point(175, 104), Text = "Nam" };
            _lblNhanVien = new Label { AutoSize = true, Location = new Point(320, 104), Text = "Nhan vien" };

            _nudThang = new NumericUpDown
            {
                Location = new Point(82, 101),
                Size = new Size(70, 27),
                Minimum = 1,
                Maximum = 12,
                Value = DateTime.Today.Month
            };

            _nudNam = new NumericUpDown
            {
                Location = new Point(220, 101),
                Size = new Size(80, 27),
                Minimum = 2000,
                Maximum = 3000,
                Value = DateTime.Today.Year
            };

            _cboNhanVien = new ComboBox
            {
                Location = new Point(395, 101),
                Size = new Size(280, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            _btnXem = new Button
            {
                Location = new Point(700, 98),
                Size = new Size(110, 34),
                Text = "Tinh luong",
                BackColor = ThemeHelper.PrimaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            _btnXem.FlatAppearance.BorderSize = 0;
            _btnXem.Click += (_, _) => TaiDuLieu();

            _btnXuatExcel = new Button
            {
                Location = new Point(822, 98),
                Size = new Size(118, 34),
                Text = "Xuat Excel",
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            ThemeHelper.ApplySecondaryButton(_btnXuatExcel);
            _btnXuatExcel.Click += (_, _) => XuatExcel();

            _btnPhieuLuong = new Button
            {
                Location = new Point(952, 98),
                Size = new Size(150, 34),
                Text = "Phieu luong",
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            ThemeHelper.ApplySecondaryButton(_btnPhieuLuong);
            _btnPhieuLuong.Click += (_, _) => MoPhieuLuong();

            _pnlSummary = new Panel
            {
                Location = new Point(24, 152),
                Size = new Size(1140, 88),
                BackColor = ThemeHelper.CardBackColor,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            _lblTongNhanVien = TaoSummaryLabel(new Point(24, 18), "Tong nhan vien: 0");
            _lblTongLuong = TaoSummaryLabel(new Point(300, 18), "Tong luong tam tinh: 0");
            _lblTongOT = TaoSummaryLabel(new Point(620, 18), "Tong tien OT: 0");
            _lblTongKhauTru = TaoSummaryLabel(new Point(870, 18), "Tong khau tru: 0");
            _pnlSummary.Controls.AddRange([_lblTongNhanVien, _lblTongLuong, _lblTongOT, _lblTongKhauTru]);

            _dgvLuong = new DataGridView
            {
                Location = new Point(24, 258),
                Size = new Size(1140, 420),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackgroundColor = ThemeHelper.CardBackColor,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                GridColor = ThemeHelper.BorderColor,
                EnableHeadersVisualStyles = false
            };
            _dgvLuong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 251);
            _dgvLuong.ColumnHeadersDefaultCellStyle.ForeColor = ThemeHelper.TextPrimary;
            _dgvLuong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            _dgvLuong.ColumnHeadersHeight = 40;
            _dgvLuong.RowTemplate.Height = 36;

            Controls.AddRange(
            [
                _lblTitle, _lblSubtitle,
                _lblThang, _lblNam, _lblNhanVien,
                _nudThang, _nudNam, _cboNhanVien, _btnXem, _btnXuatExcel, _btnPhieuLuong,
                _pnlSummary, _dgvLuong
            ]);

            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1188, 710);
            MinimumSize = new Size(1120, 700);
            Text = "Tinh luong";
            Load += FrmTinhLuong_Load;
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private static Label TaoSummaryLabel(Point location, string text)
        {
            return new Label
            {
                AutoSize = true,
                Location = location,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = ThemeHelper.TextPrimary,
                Text = text
            };
        }

        private void FrmTinhLuong_Load(object? sender, EventArgs e)
        {
            CaiDatGrid();
            _gridHelper ??= new DataGridSearchPaginationHelper(_dgvLuong);
            TaiNhanVien();
            TaiDuLieu();
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            int right = ClientSize.Width - 24;
            _btnPhieuLuong.Left = right - _btnPhieuLuong.Width;
            _btnXuatExcel.Left = _btnPhieuLuong.Left - 12 - _btnXuatExcel.Width;
            _btnXem.Left = _btnXuatExcel.Left - 12 - _btnXem.Width;
            _cboNhanVien.Width = Math.Max(220, _btnXem.Left - 20 - _cboNhanVien.Left);
            _pnlSummary.Width = ClientSize.Width - 48;
            _dgvLuong.Width = ClientSize.Width - 48;
            _dgvLuong.Height = ClientSize.Height - _dgvLuong.Top - 24;
        }

        private void CaiDatGrid()
        {
            _dgvLuong.Columns.Clear();
            _dgvLuong.Columns.Add(TaoCot("Ma NV", "MaNhanVien", 70));
            _dgvLuong.Columns.Add(TaoCot("Ho ten", "HoTen", 120));
            _dgvLuong.Columns.Add(TaoCot("Luong co ban", "LuongCoBan", 90, "N0"));
            _dgvLuong.Columns.Add(TaoCot("Ngay cong", "NgayCongHuongLuong", 75, "N1"));
            _dgvLuong.Columns.Add(TaoCot("Nghi co luong", "NghiHuongLuong", 80, "N1"));
            _dgvLuong.Columns.Add(TaoCot("Nghi khong luong", "NghiKhongLuong", 90, "N1"));
            _dgvLuong.Columns.Add(TaoCot("OT gio", "TongGioTangCa", 65, "N1"));
            _dgvLuong.Columns.Add(TaoCot("Tien OT", "TienTangCa", 85, "N0"));
            _dgvLuong.Columns.Add(TaoCot("Khau tru", "TongKhauTru", 85, "N0"));
            _dgvLuong.Columns.Add(TaoCot("Luong thuc nhan", "LuongThucNhan", 100, "N0"));
        }

        private static DataGridViewTextBoxColumn TaoCot(string header, string property, int weight, string? format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                FillWeight = weight,
                MinimumWidth = 75
            };

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle = new DataGridViewCellStyle { Format = format };
            }

            return column;
        }

        private void TaiNhanVien()
        {
            using var db = new AppDbContext();
            var ds = db.NhanViens
                .AsNoTracking()
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.Id,
                    HienThi = $"{x.MaNhanVien} - {x.HoTen}"
                })
                .ToList();

            ds.Insert(0, new { Id = 0, HienThi = "-- Tat ca --" });
            _cboNhanVien.DataSource = ds;
            _cboNhanVien.DisplayMember = "HienThi";
            _cboNhanVien.ValueMember = "Id";
            _cboNhanVien.SelectedIndex = 0;
        }

        private void TaiDuLieu()
        {
            int thang = (int)_nudThang.Value;
            int nam = (int)_nudNam.Value;
            int nhanVienId = Convert.ToInt32(_cboNhanVien.SelectedValue ?? 0);

            var ds = SalaryCalculationService.GetMonthlySalaries(thang, nam, nhanVienId);

            _duLieuHienTai = ds;
            _gridHelper?.ApplyData(ds);
            _lblTongNhanVien.Text = $"Tong nhan vien: {ds.Count}";
            _lblTongLuong.Text = $"Tong luong tam tinh: {ds.Sum(x => x.LuongThucNhan):N0}";
            _lblTongOT.Text = $"Tong tien OT: {ds.Sum(x => x.TienTangCa):N0}";
            _lblTongKhauTru.Text = $"Tong khau tru: {ds.Sum(x => x.TongKhauTru):N0}";
        }

        private void XuatExcel()
        {
            CsvExportHelper.Export(
                _duLieuHienTai,
                $"bang_luong_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                new Dictionary<string, string>
                {
                    ["NhanVienId"] = "NhanVienId",
                    ["MaNhanVien"] = "Ma NV",
                    ["HoTen"] = "Ho ten",
                    ["PhongBan"] = "Phong ban",
                    ["ChucVu"] = "Chuc vu",
                    ["LuongCoBan"] = "Luong co ban",
                    ["NgayCongHuongLuong"] = "Ngay cong",
                    ["NghiHuongLuong"] = "Nghi co luong",
                    ["NghiKhongLuong"] = "Nghi khong luong",
                    ["TongGioTangCa"] = "Tong gio OT",
                    ["TienTangCa"] = "Tien OT",
                    ["TongKhauTru"] = "Tong khau tru",
                    ["LuongThucNhan"] = "Luong thuc nhan"
                });
        }

        private void MoPhieuLuong()
        {
            int nhanVienId = Convert.ToInt32(_cboNhanVien.SelectedValue ?? 0);
            if (nhanVienId <= 0)
            {
                MessageBox.Show("Vui long chon mot nhan vien de xem phieu luong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new FrmPhieuLuongCaNhan((int)_nudThang.Value, (int)_nudNam.Value, nhanVienId);
            frm.ShowDialog(this);
        }
    }
}
