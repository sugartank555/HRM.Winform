using HRM.Winform.Forms.CaNhan;
using HRM.Winform.Helpers;
using System.Globalization;

namespace HRM.Winform.Forms.ChamCong
{
    public class FrmCauHinhGpsCongTy : Form
    {
        private readonly Label _lblTitle;
        private readonly Label _lblSubtitle;
        private readonly Label _lblLatitude;
        private readonly Label _lblLongitude;
        private readonly Label _lblRadius;
        private readonly Label _lblCurrent;
        private readonly TextBox _txtLatitude;
        private readonly TextBox _txtLongitude;
        private readonly NumericUpDown _nudRadius;
        private readonly Button _btnLayViTriHienTai;
        private readonly Button _btnLuu;
        private readonly Panel _pnlCard;

        public FrmCauHinhGpsCongTy()
        {
            BackColor = Color.FromArgb(241, 245, 249);

            _lblTitle = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(24, 20),
                Text = "Cau hinh GPS cong ty"
            };

            _lblSubtitle = new Label
            {
                AutoSize = true,
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(24, 63),
                Text = "Thiet lap toa do van phong va ban kinh hop le de nhan vien check in GPS."
            };

            _pnlCard = new Panel
            {
                BackColor = Color.White,
                Location = new Point(24, 104),
                Size = new Size(760, 320),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            _lblLatitude = new Label
            {
                AutoSize = true,
                Location = new Point(28, 32),
                Text = "Latitude"
            };

            _txtLatitude = new TextBox
            {
                Location = new Point(28, 56),
                Size = new Size(320, 27)
            };

            _lblLongitude = new Label
            {
                AutoSize = true,
                Location = new Point(388, 32),
                Text = "Longitude"
            };

            _txtLongitude = new TextBox
            {
                Location = new Point(388, 56),
                Size = new Size(320, 27),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            _lblRadius = new Label
            {
                AutoSize = true,
                Location = new Point(28, 104),
                Text = "Ban kinh hop le (m)"
            };

            _nudRadius = new NumericUpDown
            {
                Location = new Point(28, 128),
                Size = new Size(180, 27),
                Minimum = 20,
                Maximum = 5000,
                Increment = 10,
                Value = 150
            };

            _btnLayViTriHienTai = new Button
            {
                Location = new Point(28, 184),
                Size = new Size(180, 40),
                Text = "Lay vi tri hien tai",
                BackColor = Color.White,
                ForeColor = Color.FromArgb(37, 99, 235),
                FlatStyle = FlatStyle.Flat
            };
            _btnLayViTriHienTai.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);
            _btnLayViTriHienTai.FlatAppearance.BorderSize = 1;
            _btnLayViTriHienTai.Click += BtnLayViTriHienTai_Click;

            _btnLuu = new Button
            {
                Location = new Point(228, 184),
                Size = new Size(140, 40),
                Text = "Luu cau hinh",
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            _btnLuu.FlatAppearance.BorderSize = 0;
            _btnLuu.Click += BtnLuu_Click;

            _lblCurrent = new Label
            {
                AutoSize = false,
                Location = new Point(28, 246),
                Size = new Size(680, 48),
                ForeColor = Color.FromArgb(71, 85, 105),
                Text = "Chua co cau hinh GPS cong ty."
            };

            _pnlCard.Controls.AddRange(
            [
                _lblLatitude, _txtLatitude,
                _lblLongitude, _txtLongitude,
                _lblRadius, _nudRadius,
                _btnLayViTriHienTai, _btnLuu,
                _lblCurrent
            ]);

            Controls.AddRange([_lblTitle, _lblSubtitle, _pnlCard]);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 470);
            MinimumSize = new Size(760, 430);
            Text = "Cau hinh GPS cong ty";
            Load += FrmCauHinhGpsCongTy_Load;
        }

        private void FrmCauHinhGpsCongTy_Load(object? sender, EventArgs e)
        {
            TaiCauHinh();
        }

        private void TaiCauHinh()
        {
            var config = GpsCheckInStore.LoadOfficeConfig();
            if (config == null)
            {
                _txtLatitude.Text = string.Empty;
                _txtLongitude.Text = string.Empty;
                _nudRadius.Value = 150;
                _lblCurrent.Text = "Chua co cau hinh GPS cong ty. Hay nhap toa do tay hoac bam 'Lay vi tri hien tai'.";
                return;
            }

            _txtLatitude.Text = config.Latitude.ToString("F6", CultureInfo.InvariantCulture);
            _txtLongitude.Text = config.Longitude.ToString("F6", CultureInfo.InvariantCulture);
            _nudRadius.Value = (decimal)Math.Max((double)_nudRadius.Minimum, Math.Min((double)_nudRadius.Maximum, config.AllowedRadiusMeters));
            _lblCurrent.Text = $"Cau hinh hien tai: {config.Latitude:F6}, {config.Longitude:F6} | Ban kinh {config.AllowedRadiusMeters:N0} m | Cap nhat {config.UpdatedAt:dd/MM/yyyy HH:mm}";
        }

        private void BtnLayViTriHienTai_Click(object? sender, EventArgs e)
        {
            using var frm = new FrmXacThucGps();
            if (frm.ShowDialog(this) != DialogResult.OK || frm.GpsResult == null)
            {
                return;
            }

            _txtLatitude.Text = frm.GpsResult.Latitude.ToString("F6", CultureInfo.InvariantCulture);
            _txtLongitude.Text = frm.GpsResult.Longitude.ToString("F6", CultureInfo.InvariantCulture);
            _lblCurrent.Text = $"Da lay vi tri hien tai: {frm.GpsResult.Latitude:F6}, {frm.GpsResult.Longitude:F6} | Sai so ~ {frm.GpsResult.AccuracyMeters:N0} m";
        }

        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (!double.TryParse(_txtLatitude.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double latitude))
            {
                MessageBox.Show("Latitude khong hop le.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtLatitude.Focus();
                return;
            }

            if (!double.TryParse(_txtLongitude.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double longitude))
            {
                MessageBox.Show("Longitude khong hop le.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _txtLongitude.Focus();
                return;
            }

            var config = new OfficeGpsConfig
            {
                Latitude = latitude,
                Longitude = longitude,
                AllowedRadiusMeters = (double)_nudRadius.Value
            };

            GpsCheckInStore.SaveOfficeConfig(config);
            TaiCauHinh();

            MessageBox.Show("Da luu cau hinh GPS cong ty.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
