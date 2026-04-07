USE [HRMDb];
GO

SET NOCOUNT ON;

DECLARE @Now DATETIME = GETDATE();
DECLARE @PasswordHash NVARCHAR(64) = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92';

IF NOT EXISTS (SELECT 1 FROM PhongBans WHERE MaPhongBan = 'PB001')
    INSERT INTO PhongBans (MaPhongBan, TenPhongBan, MoTa, NgayTao, NgayCapNhat)
    VALUES ('PB001', N'Ban Giam Doc', N'Khoi dieu hanh', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM PhongBans WHERE MaPhongBan = 'PB002')
    INSERT INTO PhongBans (MaPhongBan, TenPhongBan, MoTa, NgayTao, NgayCapNhat)
    VALUES ('PB002', N'Nhan su', N'Quan ly nhan su va hanh chinh', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM PhongBans WHERE MaPhongBan = 'PB003')
    INSERT INTO PhongBans (MaPhongBan, TenPhongBan, MoTa, NgayTao, NgayCapNhat)
    VALUES ('PB003', N'Ke toan', N'Quan ly tai chinh va luong', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM PhongBans WHERE MaPhongBan = 'PB004')
    INSERT INTO PhongBans (MaPhongBan, TenPhongBan, MoTa, NgayTao, NgayCapNhat)
    VALUES ('PB004', N'Cong nghe thong tin', N'Quan ly he thong va phan mem', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM PhongBans WHERE MaPhongBan = 'PB005')
    INSERT INTO PhongBans (MaPhongBan, TenPhongBan, MoTa, NgayTao, NgayCapNhat)
    VALUES ('PB005', N'Kinh doanh', N'Phat trien khach hang va doanh thu', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM ChucVus WHERE MaChucVu = 'CV001')
    INSERT INTO ChucVus (MaChucVu, TenChucVu, MoTa, NgayTao, NgayCapNhat)
    VALUES ('CV001', N'Giam doc', N'Dieu hanh doanh nghiep', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM ChucVus WHERE MaChucVu = 'CV002')
    INSERT INTO ChucVus (MaChucVu, TenChucVu, MoTa, NgayTao, NgayCapNhat)
    VALUES ('CV002', N'Truong phong Nhan su', N'Quan ly nhan su', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM ChucVus WHERE MaChucVu = 'CV003')
    INSERT INTO ChucVus (MaChucVu, TenChucVu, MoTa, NgayTao, NgayCapNhat)
    VALUES ('CV003', N'Ke toan vien', N'Xu ly ke toan', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM ChucVus WHERE MaChucVu = 'CV004')
    INSERT INTO ChucVus (MaChucVu, TenChucVu, MoTa, NgayTao, NgayCapNhat)
    VALUES ('CV004', N'Lap trinh vien', N'Phat trien phan mem', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM ChucVus WHERE MaChucVu = 'CV005')
    INSERT INTO ChucVus (MaChucVu, TenChucVu, MoTa, NgayTao, NgayCapNhat)
    VALUES ('CV005', N'Nhan vien Kinh doanh', N'Ban hang va cham soc khach hang', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM ChucVus WHERE MaChucVu = 'CV006')
    INSERT INTO ChucVus (MaChucVu, TenChucVu, MoTa, NgayTao, NgayCapNhat)
    VALUES ('CV006', N'Nhan vien', N'Nhan vien thong thuong', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM CaLamViecs WHERE MaCa = 'CA01')
    INSERT INTO CaLamViecs
    (MaCa, TenCa, GioBatDau, GioKetThuc, SoPhutNghi, SoPhutChoPhepDiMuon, SoPhutChoPhepVeSom, QuaDem, HoatDong, NgayTao, NgayCapNhat)
    VALUES ('CA01', N'Sang', '08:00:00', '17:00:00', 60, 10, 10, 0, 1, @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM CaLamViecs WHERE MaCa = 'CA02')
    INSERT INTO CaLamViecs
    (MaCa, TenCa, GioBatDau, GioKetThuc, SoPhutNghi, SoPhutChoPhepDiMuon, SoPhutChoPhepVeSom, QuaDem, HoatDong, NgayTao, NgayCapNhat)
    VALUES ('CA02', N'Chieu', '13:00:00', '22:00:00', 60, 10, 10, 0, 1, @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM CaLamViecs WHERE MaCa = 'CA03')
    INSERT INTO CaLamViecs
    (MaCa, TenCa, GioBatDau, GioKetThuc, SoPhutNghi, SoPhutChoPhepDiMuon, SoPhutChoPhepVeSom, QuaDem, HoatDong, NgayTao, NgayCapNhat)
    VALUES ('CA03', N'Hanh chinh', '08:30:00', '17:30:00', 60, 10, 10, 0, 1, @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP001')
    INSERT INTO LoaiNghiPheps (MaLoaiNghi, TenLoaiNghi, HuongLuong, MoTa, NgayTao, NgayCapNhat)
    VALUES ('LP001', N'Nghi phep nam', 1, N'Nghi phep huong luong', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP002')
    INSERT INTO LoaiNghiPheps (MaLoaiNghi, TenLoaiNghi, HuongLuong, MoTa, NgayTao, NgayCapNhat)
    VALUES ('LP002', N'Nghi benh', 1, N'Nghi benh co giay xac nhan', @Now, NULL);

IF NOT EXISTS (SELECT 1 FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP003')
    INSERT INTO LoaiNghiPheps (MaLoaiNghi, TenLoaiNghi, HuongLuong, MoTa, NgayTao, NgayCapNhat)
    VALUES ('LP003', N'Nghi khong luong', 0, N'Nghi rieng khong huong luong', @Now, NULL);

DECLARE @PB_GD INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB001');
DECLARE @PB_NS INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB002');
DECLARE @PB_KT INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB003');
DECLARE @PB_IT INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB004');
DECLARE @PB_KD INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB005');

DECLARE @CV_GD INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV001');
DECLARE @CV_NS INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV002');
DECLARE @CV_KT INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV003');
DECLARE @CV_DEV INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV004');
DECLARE @CV_KD INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV005');
DECLARE @CV_NV INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV006');

DECLARE @CA01 INT = (SELECT TOP 1 Id FROM CaLamViecs WHERE MaCa = 'CA01');
DECLARE @CA02 INT = (SELECT TOP 1 Id FROM CaLamViecs WHERE MaCa = 'CA02');
DECLARE @CA03 INT = (SELECT TOP 1 Id FROM CaLamViecs WHERE MaCa = 'CA03');
DECLARE @LP_PHEP INT = (SELECT TOP 1 Id FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP001');
DECLARE @LP_KL  INT = (SELECT TOP 1 Id FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP003');

INSERT INTO NhanViens
(MaNhanVien, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, CCCD, NgayVaoLam, NgayNghiViec, LuongCoBan, DangLamViec, PhongBanId, ChucVuId, NgayTao, NgayCapNhat)
SELECT *
FROM
(
    VALUES
    ('N01', N'Tran Le Anh Dai', '2000-08-15', 1, '0901000001', 'dai.n01@hrm.local', N'TP.HCM', '079200000001', '2024-01-05', NULL, 18000000, 1, @PB_GD, @CV_GD, @Now, NULL),
    ('N02', N'Le Khai',          '2001-04-11', 1, '0901000002', 'khai.n02@hrm.local', N'Binh Duong', '079200000002', '2024-02-10', NULL, 12000000, 1, @PB_IT, @CV_DEV, @Now, NULL),
    ('N03', N'Nguyen Minh Thu',  '1998-09-20', 0, '0901000003', 'thu.n03@hrm.local', N'TP.HCM', '079200000003', '2023-07-18', NULL, 13500000, 1, @PB_NS, @CV_NS, @Now, NULL),
    ('N04', N'Pham Gia Bao',     '1999-12-01', 1, '0901000004', 'bao.n04@hrm.local', N'Dong Nai', '079200000004', '2023-09-01', NULL, 11000000, 1, @PB_KT, @CV_KT, @Now, NULL),
    ('N05', N'Tran Ngoc Han',    '2000-03-03', 0, '0901000005', 'han.n05@hrm.local', N'TP.HCM', '079200000005', '2024-03-12', NULL, 10000000, 1, @PB_KD, @CV_KD, @Now, NULL),
    ('N06', N'Vo Quoc Tuan',     '1997-10-09', 1, '0901000006', 'tuan.n06@hrm.local', N'Long An', '079200000006', '2022-11-11', NULL, 12500000, 1, @PB_IT, @CV_DEV, @Now, NULL),
    ('N07', N'Dang My Linh',     '2001-01-25', 0, '0901000007', 'linh.n07@hrm.local', N'TP.HCM', '079200000007', '2024-04-02', NULL, 9500000,  1, @PB_NS, @CV_NV, @Now, NULL),
    ('N08', N'Hoang Duc Manh',   '1996-06-17', 1, '0901000008', 'manh.n08@hrm.local', N'Tay Ninh', '079200000008', '2021-05-07', NULL, 11500000, 1, @PB_KD, @CV_KD, @Now, NULL),
    ('N09', N'Bui Thanh Truc',   '2002-02-14', 0, '0901000009', 'truc.n09@hrm.local', N'TP.HCM', '079200000009', '2024-05-20', NULL, 9800000,  1, @PB_KT, @CV_NV, @Now, NULL),
    ('N10', N'Nguyen Van Phuc',  '1998-07-07', 1, '0901000010', 'phuc.n10@hrm.local', N'Binh Phuoc', '079200000010', '2023-12-15', NULL, 10500000, 1, @PB_IT, @CV_DEV, @Now, NULL)
) AS src (MaNhanVien, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, CCCD, NgayVaoLam, NgayNghiViec, LuongCoBan, DangLamViec, PhongBanId, ChucVuId, NgayTao, NgayCapNhat)
WHERE NOT EXISTS (SELECT 1 FROM NhanViens nv WHERE nv.MaNhanVien = src.MaNhanVien);

INSERT INTO TaiKhoans (TenDangNhap, MatKhauHash, VaiTro, HoatDong, NhanVienId, NgayTao, NgayCapNhat)
SELECT src.TenDangNhap, @PasswordHash, src.VaiTro, 1, nv.Id, @Now, NULL
FROM
(
    VALUES
    ('admin',  'Admin',    'N01'),
    ('hr001',  'HR',       'N03'),
    ('kt001',  'QuanLy',   'N04'),
    ('it001',  'NhanVien', 'N02'),
    ('kd001',  'NhanVien', 'N05'),
    ('it002',  'NhanVien', 'N06'),
    ('ns002',  'NhanVien', 'N07'),
    ('kd002',  'NhanVien', 'N08'),
    ('kt002',  'NhanVien', 'N09'),
    ('it003',  'NhanVien', 'N10')
) AS src (TenDangNhap, VaiTro, MaNhanVien)
JOIN NhanViens nv ON nv.MaNhanVien = src.MaNhanVien
WHERE NOT EXISTS (SELECT 1 FROM TaiKhoans tk WHERE tk.TenDangNhap = src.TenDangNhap);

INSERT INTO PhanCaNhanViens (NhanVienId, CaLamViecId, NgayLamViec, NgayTao, NgayCapNhat)
SELECT nv.Id,
       CASE WHEN nv.MaNhanVien IN ('N02','N06','N10') THEN @CA01
            WHEN nv.MaNhanVien IN ('N05','N08') THEN @CA02
            ELSE @CA03 END,
       '2026-04-07',
       @Now,
       NULL
FROM NhanViens nv
WHERE nv.MaNhanVien IN ('N01','N02','N03','N04','N05','N06','N07','N08','N09','N10')
  AND NOT EXISTS
  (
      SELECT 1 FROM PhanCaNhanViens pc
      WHERE pc.NhanVienId = nv.Id AND pc.NgayLamViec = '2026-04-07'
  );

INSERT INTO DonTangCas (NhanVienId, NgayLam, TuGio, DenGio, TongSoGio, LyDo, TrangThai, NgayDuyet, NguoiDuyet, NgayTao, NgayCapNhat)
SELECT nv.Id, '2026-04-05', '2026-04-05T18:00:00', '2026-04-05T20:00:00', 2.0, N'Hoan thanh deadline', 'DaDuyet', @Now, 'hr001', @Now, NULL
FROM NhanViens nv
WHERE nv.MaNhanVien IN ('N02','N06','N10')
  AND NOT EXISTS
  (
      SELECT 1 FROM DonTangCas dt
      WHERE dt.NhanVienId = nv.Id AND dt.NgayLam = '2026-04-05'
  );

INSERT INTO DonNghiPheps (NhanVienId, LoaiNghiPhepId, TuNgay, DenNgay, TongSoNgay, LyDo, TrangThai, NgayDuyet, NguoiDuyet, NgayTao, NgayCapNhat)
SELECT nv.Id,
       CASE WHEN nv.MaNhanVien = 'N09' THEN @LP_KL ELSE @LP_PHEP END,
       '2026-04-03',
       '2026-04-03',
       1.0,
       CASE WHEN nv.MaNhanVien = 'N09' THEN N'Ve que giai quyet viec rieng' ELSE N'Nghi phep ca nhan' END,
       'DaDuyet',
       @Now,
       'hr001',
       @Now,
       NULL
FROM NhanViens nv
WHERE nv.MaNhanVien IN ('N07','N09')
  AND NOT EXISTS
  (
      SELECT 1 FROM DonNghiPheps dnp
      WHERE dnp.NhanVienId = nv.Id AND dnp.TuNgay = '2026-04-03'
  );

INSERT INTO ChamCongs
(NhanVienId, CaLamViecId, NgayLamViec, GioCheckIn, GioCheckOut, SoPhutDiMuon, SoPhutVeSom, SoGioLam, SoGioTangCa, TrangThai, GhiChu, NgayTao, NgayCapNhat)
SELECT nv.Id,
       CASE WHEN nv.MaNhanVien IN ('N02','N06','N10') THEN @CA01
            WHEN nv.MaNhanVien IN ('N05','N08') THEN @CA02
            ELSE @CA03 END,
       '2026-04-07',
       CASE nv.MaNhanVien
            WHEN 'N01' THEN '2026-04-07T08:31:00'
            WHEN 'N02' THEN '2026-04-07T08:05:00'
            WHEN 'N03' THEN '2026-04-07T08:28:00'
            WHEN 'N04' THEN '2026-04-07T08:35:00'
            WHEN 'N05' THEN '2026-04-07T13:02:00'
            WHEN 'N06' THEN '2026-04-07T08:12:00'
            WHEN 'N07' THEN '2026-04-07T08:30:00'
            WHEN 'N08' THEN '2026-04-07T13:10:00'
            WHEN 'N09' THEN '2026-04-07T08:29:00'
            WHEN 'N10' THEN '2026-04-07T08:01:00'
       END,
       CASE nv.MaNhanVien
            WHEN 'N01' THEN '2026-04-07T17:32:00'
            WHEN 'N02' THEN '2026-04-07T17:08:00'
            WHEN 'N03' THEN '2026-04-07T17:29:00'
            WHEN 'N04' THEN '2026-04-07T17:20:00'
            WHEN 'N05' THEN '2026-04-07T22:05:00'
            WHEN 'N06' THEN '2026-04-07T17:40:00'
            WHEN 'N07' THEN '2026-04-07T17:31:00'
            WHEN 'N08' THEN '2026-04-07T22:01:00'
            WHEN 'N09' THEN '2026-04-07T17:26:00'
            WHEN 'N10' THEN '2026-04-07T17:45:00'
       END,
       CASE nv.MaNhanVien
            WHEN 'N01' THEN 1 WHEN 'N04' THEN 5 WHEN 'N06' THEN 12 WHEN 'N08' THEN 10
            ELSE 0 END,
       CASE nv.MaNhanVien
            WHEN 'N04' THEN 10 WHEN 'N09' THEN 4
            ELSE 0 END,
       CASE nv.MaNhanVien
            WHEN 'N06' THEN 8.5 WHEN 'N10' THEN 8.7 ELSE 8.0 END,
       CASE nv.MaNhanVien
            WHEN 'N02' THEN 1.5 WHEN 'N06' THEN 2.0 WHEN 'N10' THEN 2.0
            ELSE 0 END,
       CASE nv.MaNhanVien
            WHEN 'N01' THEN 'DiMuon'
            WHEN 'N04' THEN 'DiMuon'
            WHEN 'N06' THEN 'DiMuon'
            WHEN 'N08' THEN 'DiMuon'
            ELSE 'CoMat' END,
       N'Du lieu mau',
       @Now,
       NULL
FROM NhanViens nv
WHERE nv.MaNhanVien IN ('N01','N02','N03','N04','N05','N06','N07','N08','N09','N10')
  AND NOT EXISTS
  (
      SELECT 1 FROM ChamCongs cc
      WHERE cc.NhanVienId = nv.Id AND cc.NgayLamViec = '2026-04-07'
  );

PRINT N'Da tao du lieu mau 10 nhan vien cho de tai HRM.';
PRINT N'Tai khoan mau: admin / hr001 / kt001 / it001 ...';
PRINT N'Mat khau chung: 123456';
GO
