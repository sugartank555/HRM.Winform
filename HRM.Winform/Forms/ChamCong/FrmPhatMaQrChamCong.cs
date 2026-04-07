using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace HRM.Winform.Forms.ChamCong
{
    public partial class FrmPhatMaQrChamCong : Form
    {
        private bool _dangTaiDuLieu;
        private int? _phanCaIdHienTai;

        public FrmPhatMaQrChamCong()
        {
            InitializeComponent();
        }

        private void FrmPhatMaQrChamCong_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            ApplyResponsiveLayout();
            TaiNhanVien();
            TaiDanhSachCaLamViec();
            dtpNgay.Value = DateTime.Today;
            TaiPhanCa();
            TaoMa();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = ThemeHelper.AppBackColor;
            pnlTop.BackColor = ThemeHelper.CardBackColor;
            pnlQrCard.BackColor = ThemeHelper.CardBackColor;
            pnlInfo.BackColor = ThemeHelper.CardBackColor;
            pnlQrPreview.BackColor = ThemeHelper.CardMutedBackColor;

            ThemeHelper.ApplyPrimaryButton(btnTaoMa);
            ThemeHelper.ApplySecondaryButton(btnSaoChep);
            ThemeHelper.ApplySuccessButton(btnLuuPhanCa);
            ThemeHelper.ApplyInput(txtCaLam);
            ThemeHelper.ApplyInput(txtMaCa);
            ThemeHelper.ApplyInput(txtMaQr);
        }

        private void TaiNhanVien()
        {
            _dangTaiDuLieu = true;
            using var db = new AppDbContext();
            var ds = db.NhanViens
                .AsNoTracking()
                .Where(x => x.DangLamViec)
                .OrderBy(x => x.HoTen)
                .Select(x => new
                {
                    x.Id,
                    HienThi = $"{x.MaNhanVien} - {x.HoTen}"
                })
                .ToList();

            cboNhanVien.DataSource = ds;
            cboNhanVien.DisplayMember = "HienThi";
            cboNhanVien.ValueMember = "Id";
            if (ds.Count > 0)
            {
                cboNhanVien.SelectedIndex = 0;
            }
            _dangTaiDuLieu = false;
        }

        private void TaiDanhSachCaLamViec()
        {
            using var db = new AppDbContext();
            var ds = db.CaLamViecs
                .AsNoTracking()
                .Where(x => x.HoatDong)
                .OrderBy(x => x.TenCa)
                .Select(x => new
                {
                    x.Id,
                    HienThi = $"{x.MaCa} - {x.TenCa}",
                    x.MaCa,
                    x.TenCa
                })
                .ToList();

            cboCaLamViec.DataSource = ds;
            cboCaLamViec.DisplayMember = "HienThi";
            cboCaLamViec.ValueMember = "Id";
            cboCaLamViec.SelectedIndex = ds.Count > 0 ? 0 : -1;
        }

        private void TaiPhanCa()
        {
            int? nhanVienId = LayNhanVienIdDangChon();
            if (!nhanVienId.HasValue)
            {
                _phanCaIdHienTai = null;
                txtCaLam.Text = "Chua co du lieu";
                txtMaCa.Text = "FREE";
                return;
            }

            using var db = new AppDbContext();

            var phanCa = db.PhanCaNhanViens
                .AsNoTracking()
                .Include(x => x.CaLamViec)
                .FirstOrDefault(x => x.NhanVienId == nhanVienId.Value && x.NgayLamViec == dtpNgay.Value.Date);

            _phanCaIdHienTai = phanCa?.Id;
            txtCaLam.Text = phanCa?.CaLamViec?.TenCa ?? "Chua phan ca";
            txtMaCa.Text = phanCa?.CaLamViec?.MaCa ?? "FREE";

            if (phanCa?.CaLamViecId != null)
            {
                cboCaLamViec.SelectedValue = phanCa.CaLamViecId;
            }
        }

        private void TaoMa()
        {
            int? nhanVienId = LayNhanVienIdDangChon();
            if (!nhanVienId.HasValue)
            {
                txtMaQr.Text = string.Empty;
                lblQrPreview.Visible = true;
                lblQrPreview.Text = "Chua co du lieu";
                picQr.ImageLocation = null;
                picQr.Image = null;
                lblHuongDan.Text = "Hay chon nhan vien hop le de phat ma QR.";
                return;
            }

            string maCa = string.IsNullOrWhiteSpace(txtMaCa.Text) ? "FREE" : txtMaCa.Text.Trim();
            string maQr = QrChamCongHelper.TaoMa(nhanVienId.Value, dtpNgay.Value.Date, maCa);

            txtMaQr.Text = maQr;
            lblQrPreview.Text = maQr;
            lblQrPreview.Visible = false;
            HienThiAnhQr(maQr);
            lblHuongDan.Text = "Nhan vien co the quet QR bang camera hoac nhap dung ma dang phat de hoan tat check in.";
        }

        private void HienThiAnhQr(string maQr)
        {
            try
            {
                picQr.Image?.Dispose();

                var generator = new QRCodeGenerator();
                using QRCodeData qrData = generator.CreateQrCode(maQr, QRCodeGenerator.ECCLevel.Q);
                using var qrCode = new QRCode(qrData);
                picQr.Image = qrCode.GetGraphic(12, Color.Black, Color.White, true);
            }
            catch
            {
                picQr.ImageLocation = null;
                picQr.Image = null;
                lblQrPreview.Visible = true;
            }
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated || _dangTaiDuLieu) return;
            TaiPhanCa();
            TaoMa();
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            TaiPhanCa();
            TaoMa();
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            TaiPhanCa();
            TaoMa();
            LuuMaQrDangPhat();
        }

        private void btnLuuPhanCa_Click(object sender, EventArgs e)
        {
            int? nhanVienId = LayNhanVienIdDangChon();
            int? caLamViecId = LayCaLamViecDangChon();

            if (!nhanVienId.HasValue)
            {
                MessageBox.Show("Vui long chon nhan vien hop le.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!caLamViecId.HasValue)
            {
                MessageBox.Show("Vui long chon ca lam viec.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new AppDbContext();
            var ngay = dtpNgay.Value.Date;
            var phanCa = db.PhanCaNhanViens.FirstOrDefault(x => x.NhanVienId == nhanVienId.Value && x.NgayLamViec == ngay);

            if (phanCa == null)
            {
                db.PhanCaNhanViens.Add(new Models.PhanCaNhanVien
                {
                    NhanVienId = nhanVienId.Value,
                    CaLamViecId = caLamViecId.Value,
                    NgayLamViec = ngay,
                    NgayTao = DateTime.Now
                });
            }
            else
            {
                phanCa.CaLamViecId = caLamViecId.Value;
                phanCa.NgayCapNhat = DateTime.Now;
            }

            db.SaveChanges();
            MessageBox.Show("Da luu phan ca cho nhan vien.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiPhanCa();
            TaoMa();
        }

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaQr.Text))
            {
                MessageBox.Show("Chua co ma QR de sao chep.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Clipboard.SetText(txtMaQr.Text);
            MessageBox.Show("Da sao chep ma QR.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int? LayNhanVienIdDangChon()
        {
            if (cboNhanVien.SelectedValue is int id)
            {
                return id;
            }

            if (cboNhanVien.SelectedValue is long longId)
            {
                return (int)longId;
            }

            if (cboNhanVien.SelectedValue is short shortId)
            {
                return shortId;
            }

            if (cboNhanVien.SelectedValue is string valueText && int.TryParse(valueText, out int parsedId))
            {
                return parsedId;
            }

            return null;
        }

        private int? LayCaLamViecDangChon()
        {
            if (cboCaLamViec.SelectedValue is int id)
            {
                return id;
            }

            if (cboCaLamViec.SelectedValue is long longId)
            {
                return (int)longId;
            }

            if (cboCaLamViec.SelectedValue is short shortId)
            {
                return shortId;
            }

            if (cboCaLamViec.SelectedValue is string valueText && int.TryParse(valueText, out int parsedId))
            {
                return parsedId;
            }

            return null;
        }

        private void LuuMaQrDangPhat()
        {
            int? nhanVienId = LayNhanVienIdDangChon();
            if (!nhanVienId.HasValue || string.IsNullOrWhiteSpace(txtMaQr.Text))
            {
                MessageBox.Show("Chua co du lieu hop le de luu ma QR.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hienThiNhanVien = cboNhanVien.Text.Trim();
            string maNhanVien = hienThiNhanVien;
            string hoTen = hienThiNhanVien;

            if (hienThiNhanVien.Contains(" - ", StringComparison.Ordinal))
            {
                var parts = hienThiNhanVien.Split(" - ", 2, StringSplitOptions.None);
                maNhanVien = parts[0];
                hoTen = parts.Length > 1 ? parts[1] : parts[0];
            }

            var record = new QrPhatRecord
            {
                NhanVienId = nhanVienId.Value,
                MaNhanVien = maNhanVien,
                HoTen = hoTen,
                NgayLamViec = dtpNgay.Value.Date,
                TenCa = txtCaLam.Text.Trim(),
                MaCa = string.IsNullOrWhiteSpace(txtMaCa.Text) ? "FREE" : txtMaCa.Text.Trim(),
                MaQr = txtMaQr.Text.Trim(),
                PhatLuc = DateTime.Now,
                NguoiPhat = string.IsNullOrWhiteSpace(CurrentUser.HoTen) ? CurrentUser.TenDangNhap : CurrentUser.HoTen
            };

            QrPhatStore.Save(record);

            MessageBox.Show(
                "Da luu ma QR dang phat. Man hinh Nhan vien se hien ma QR moi nhat cua nhan vien nay.",
                "Luu ma QR thanh cong",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ApplyResponsiveLayout()
        {
            int margin = 24;
            int top = pnlTop.Bottom + 26;
            int availableWidth = ClientSize.Width - margin * 2;
            bool stack = availableWidth < 1040;

            if (stack)
            {
                pnlInfo.Location = new Point(margin, top);
                pnlInfo.Size = new Size(availableWidth, 294);

                pnlQrCard.Location = new Point(margin, pnlInfo.Bottom + 20);
                pnlQrCard.Size = new Size(availableWidth, ClientSize.Height - pnlQrCard.Top - 24);
            }
            else
            {
                int gap = 26;
                int infoWidth = 560;
                pnlInfo.Location = new Point(margin, top);
                pnlInfo.Size = new Size(infoWidth, ClientSize.Height - top - 24);

                pnlQrCard.Location = new Point(pnlInfo.Right + gap, top);
                pnlQrCard.Size = new Size(availableWidth - infoWidth - gap, ClientSize.Height - top - 24);
            }
        }
    }
}
