using HRM.Winform.Data;
using HRM.Winform.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRM.Winform.Forms.CaNhan
{
    public partial class FrmHoSoCaNhan : Form
    {
        private int _nhanVienId;

        public FrmHoSoCaNhan()
        {
            InitializeComponent();
        }

        private void FrmHoSoCaNhan_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            ApplyResponsiveLayout();
            TaiThongTin();
            Resize += (_, _) => ApplyResponsiveLayout();
        }

        private void ApplyStyle()
        {
            BackColor = Color.FromArgb(241, 245, 249);
            pnlHeader.BackColor = Color.White;
            pnlInfo.BackColor = Color.White;
            pnlContact.BackColor = Color.White;

            btnLuu.BackColor = Color.FromArgb(37, 99, 235);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;

            btnDoiMatKhau.BackColor = Color.White;
            btnDoiMatKhau.ForeColor = Color.FromArgb(37, 99, 235);
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.FlatAppearance.BorderSize = 1;
            btnDoiMatKhau.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);

            btnDangKyKhuonMat.BackColor = Color.White;
            btnDangKyKhuonMat.ForeColor = Color.FromArgb(5, 150, 105);
            btnDangKyKhuonMat.FlatStyle = FlatStyle.Flat;
            btnDangKyKhuonMat.FlatAppearance.BorderSize = 1;
            btnDangKyKhuonMat.FlatAppearance.BorderColor = Color.FromArgb(167, 243, 208);

            lblFaceStatusTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblFaceCapturedTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblFaceAssetTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblFaceRequestTitle.ForeColor = Color.FromArgb(71, 85, 105);
        }

        private void TaiThongTin()
        {
            using var db = new AppDbContext();
            var nhanVien = db.NhanViens
                .AsNoTracking()
                .Include(x => x.PhongBan)
                .Include(x => x.ChucVu)
                .FirstOrDefault(x => x.Id == CurrentUser.NhanVienId);

            if (nhanVien == null)
            {
                MessageBox.Show("Khong tim thay ho so nhan vien.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _nhanVienId = nhanVien.Id;

            lblHoTenValue.Text = nhanVien.HoTen;
            lblMaNhanVienValue.Text = nhanVien.MaNhanVien;
            lblPhongBanValue.Text = nhanVien.PhongBan?.TenPhongBan ?? "--";
            lblChucVuValue.Text = nhanVien.ChucVu?.TenChucVu ?? "--";
            lblNgayVaoLamValue.Text = nhanVien.NgayVaoLam.ToString("dd/MM/yyyy");
            lblTrangThaiValue.Text = nhanVien.DangLamViec ? "Dang lam viec" : "Da nghi";

            txtSoDienThoai.Text = nhanVien.SoDienThoai;
            txtEmail.Text = nhanVien.Email ?? string.Empty;
            txtDiaChi.Text = nhanVien.DiaChi ?? string.Empty;
            txtCCCD.Text = nhanVien.CCCD ?? string.Empty;

            CapNhatTrangThaiKhuonMat();
        }

        private void CapNhatTrangThaiKhuonMat()
        {
            var profile = FaceProfileStore.Load(CurrentUser.NhanVienId);
            bool daDangKy = profile != null && profile.Descriptor.Length > 0 && !string.IsNullOrWhiteSpace(profile.ImageDataUrl);
            var pendingRequest = FaceRegistrationResetRequestStore.GetPending(CurrentUser.NhanVienId);
            var approvedUnlock = FaceRegistrationResetRequestStore.GetApprovedUnlock(CurrentUser.NhanVienId);

            if (!daDangKy)
            {
                btnDangKyKhuonMat.Text = "Dang ky khuon mat";
                btnDangKyKhuonMat.Enabled = true;
            }
            else if (approvedUnlock != null)
            {
                btnDangKyKhuonMat.Text = "Dang ky lai khuon mat";
                btnDangKyKhuonMat.Enabled = true;
            }
            else if (pendingRequest != null)
            {
                btnDangKyKhuonMat.Text = "Cho admin duyet";
                btnDangKyKhuonMat.Enabled = true;
            }
            else
            {
                btnDangKyKhuonMat.Text = "Gui yeu cau dang ky lai";
                btnDangKyKhuonMat.Enabled = true;
            }

            lblFaceStatusValue.Text = daDangKy ? "Da dang ky mau" : "Chua co mau";
            lblFaceStatusValue.ForeColor = daDangKy
                ? Color.FromArgb(5, 150, 105)
                : Color.FromArgb(220, 38, 38);

            lblFaceCapturedValue.Text = daDangKy && profile != null
                ? profile.CapturedAt.ToString("HH:mm dd/MM/yyyy")
                : "--";

            var assetConfig = FaceRecognitionAssetHelper.ResolveForWebView();
            lblFaceAssetValue.Text = assetConfig.IsOfflineReady ? "San sang offline" : "Dang fallback online";
            lblFaceAssetValue.ForeColor = assetConfig.IsOfflineReady
                ? Color.FromArgb(5, 150, 105)
                : Color.FromArgb(234, 88, 12);

            if (!daDangKy)
            {
                lblFaceRequestValue.Text = "Chua can duyet";
                lblFaceRequestValue.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else if (approvedUnlock != null)
            {
                lblFaceRequestValue.Text = $"Da duyet, cho dang ky lai tu {approvedUnlock.UnlockGrantedAt:HH:mm dd/MM}";
                lblFaceRequestValue.ForeColor = Color.FromArgb(5, 150, 105);
            }
            else if (pendingRequest != null)
            {
                lblFaceRequestValue.Text = $"Dang cho duyet tu {pendingRequest.RequestedAt:HH:mm dd/MM}";
                lblFaceRequestValue.ForeColor = Color.FromArgb(234, 88, 12);
            }
            else
            {
                lblFaceRequestValue.Text = "Da khoa, can gui yeu cau dang ky lai";
                lblFaceRequestValue.ForeColor = Color.FromArgb(220, 38, 38);
            }

            if (picKhuonMatMau.Image != null)
            {
                var old = picKhuonMatMau.Image;
                picKhuonMatMau.Image = null;
                old.Dispose();
            }

            picKhuonMatMau.Image = daDangKy && profile != null
                ? FaceProfileStore.CreatePreviewImage(profile.ImageDataUrl)
                : null;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();
            var nhanVien = db.NhanViens.FirstOrDefault(x => x.Id == _nhanVienId);
            if (nhanVien == null)
            {
                MessageBox.Show("Khong tim thay ho so nhan vien.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var soDienThoai = ValidationHelper.NormalizeText(txtSoDienThoai.Text);
            var email = ValidationHelper.NormalizeOptional(txtEmail.Text);
            var diaChi = ValidationHelper.NormalizeOptional(txtDiaChi.Text);
            var cccd = ValidationHelper.NormalizeOptional(txtCCCD.Text);

            if (!ValidationHelper.IsValidVietnamesePhone(soDienThoai))
            {
                MessageBox.Show("So dien thoai khong hop le.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (email != null && !ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Email khong dung dinh dang.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (cccd != null && !ValidationHelper.IsValidCitizenId(cccd))
            {
                MessageBox.Show("CCCD phai gom dung 12 chu so.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            if (db.NhanViens.Any(x => x.Id != _nhanVienId && x.SoDienThoai == soDienThoai))
            {
                MessageBox.Show("So dien thoai da ton tai.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (email != null && db.NhanViens.Any(x => x.Id != _nhanVienId && x.Email == email))
            {
                MessageBox.Show("Email da ton tai.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (cccd != null && db.NhanViens.Any(x => x.Id != _nhanVienId && x.CCCD == cccd))
            {
                MessageBox.Show("CCCD da ton tai.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            nhanVien.SoDienThoai = soDienThoai;
            nhanVien.Email = email;
            nhanVien.DiaChi = diaChi;
            nhanVien.CCCD = cccd;
            nhanVien.NgayCapNhat = DateTime.Now;

            db.SaveChanges();
            MessageBox.Show("Cap nhat ho so thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiThongTin();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            using var frm = new Forms.HeThong.FrmDoiMatKhau();
            frm.ShowDialog(this);
        }

        private void btnDangKyKhuonMat_Click(object sender, EventArgs e)
        {
            bool daDangKy = FaceProfileStore.HasValidProfile(CurrentUser.NhanVienId);
            var pendingRequest = FaceRegistrationResetRequestStore.GetPending(CurrentUser.NhanVienId);
            var approvedUnlock = FaceRegistrationResetRequestStore.GetApprovedUnlock(CurrentUser.NhanVienId);

            if (daDangKy && approvedUnlock == null)
            {
                if (pendingRequest != null)
                {
                    MessageBox.Show(
                        $"Ban da gui yeu cau dang ky lai khuon mat luc {pendingRequest.RequestedAt:HH:mm dd/MM/yyyy}. Cho admin/HR duyet de mo khoa.",
                        "Dang cho duyet",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                var request = FaceRegistrationResetRequestStore.CreateRequest(
                    CurrentUser.NhanVienId,
                    lblMaNhanVienValue.Text,
                    CurrentUser.HoTen,
                    CurrentUser.TenDangNhap,
                    "Nhan vien yeu cau dang ky lai khuon mat.");

                AttendanceAuditStore.Save(new AttendanceAuditEntry
                {
                    NhanVienId = CurrentUser.NhanVienId,
                    MaNhanVien = lblMaNhanVienValue.Text,
                    HoTen = CurrentUser.HoTen,
                    ThoiGian = DateTime.Now,
                    HanhDong = "GuiYeuCauDangKyLaiKhuonMat",
                    PhuongThuc = "KhuonMat",
                    KetQua = "ThanhCong",
                    ChiTiet = $"Da gui yeu cau {request.RequestId} luc {request.RequestedAt:HH:mm dd/MM/yyyy}."
                });

                CapNhatTrangThaiKhuonMat();
                MessageBox.Show(
                    "Da gui yeu cau dang ky lai khuon mat. Admin/HR can duyet truoc khi ban co the dang ky lai.",
                    "Da gui yeu cau",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using var frm = new FrmCameraKhuonMat("Dang ky khuon mat", "Chup anh khuon mat mau cho tai khoan cua ban");
            if (frm.ShowDialog(this) != DialogResult.OK || frm.CaptureResult == null)
            {
                return;
            }

            if (frm.CaptureResult.Descriptor.Length == 0 || string.IsNullOrWhiteSpace(frm.CaptureResult.ImageDataUrl))
            {
                MessageBox.Show("Khong lay duoc du lieu khuon mat hop le. Thu dang ky lai trong dieu kien anh sang tot hon.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var profile = new FaceProfile
            {
                NhanVienId = CurrentUser.NhanVienId,
                HoTen = CurrentUser.HoTen,
                CapturedAt = DateTime.Now,
                Descriptor = frm.CaptureResult.Descriptor,
                ImageDataUrl = frm.CaptureResult.ImageDataUrl
            };

            FaceProfileStore.Save(profile);
            if (daDangKy && approvedUnlock != null)
            {
                FaceRegistrationResetRequestStore.ConsumeUnlock(CurrentUser.NhanVienId);
            }

            AttendanceAuditStore.Save(new AttendanceAuditEntry
            {
                NhanVienId = CurrentUser.NhanVienId,
                MaNhanVien = lblMaNhanVienValue.Text,
                HoTen = CurrentUser.HoTen,
                ThoiGian = DateTime.Now,
                HanhDong = "DangKyMauKhuonMat",
                PhuongThuc = "KhuonMat",
                KetQua = "ThanhCong",
                ChiTiet = $"Da luu mau khuon mat luc {DateTime.Now:HH:mm dd/MM/yyyy}."
            });
            CapNhatTrangThaiKhuonMat();
            MessageBox.Show("Da dang ky khuon mat mau thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyResponsiveLayout()
        {
            int margin = 24;
            int top = pnlHeader.Bottom + 24;
            int availableWidth = ClientSize.Width - (margin * 2);
            bool stack = availableWidth < 1020;

            if (stack)
            {
                pnlInfo.Location = new Point(margin, top);
                pnlInfo.Size = new Size(availableWidth, 392);

                pnlContact.Location = new Point(margin, pnlInfo.Bottom + 20);
                pnlContact.Size = new Size(availableWidth, ClientSize.Height - pnlContact.Top - 24);
            }
            else
            {
                int gap = 30;
                int infoWidth = 551;
                int contactWidth = availableWidth - infoWidth - gap;

                pnlInfo.Location = new Point(margin, top);
                pnlInfo.Size = new Size(infoWidth, ClientSize.Height - top - 24);

                pnlContact.Location = new Point(pnlInfo.Right + gap, top);
                pnlContact.Size = new Size(contactWidth, ClientSize.Height - top - 24);
            }

            btnLuu.Top = pnlContact.ClientSize.Height - btnLuu.Height - 24;
            btnLuu.Left = pnlContact.ClientSize.Width - btnLuu.Width - 27;
        }
    }
}
