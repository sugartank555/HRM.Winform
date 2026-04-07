USE [HRMDb];
GO

SET NOCOUNT ON;

DECLARE @Now DATETIME = GETDATE();
DECLARE @PasswordHash NVARCHAR(64) = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92';

DECLARE @PB_NS INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB002');
DECLARE @PB_KT INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB003');
DECLARE @PB_IT INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB004');
DECLARE @PB_KD INT = (SELECT TOP 1 Id FROM PhongBans WHERE MaPhongBan = 'PB005');

DECLARE @CV_NS INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV002');
DECLARE @CV_KT INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV003');
DECLARE @CV_DEV INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV004');
DECLARE @CV_KD INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV005');
DECLARE @CV_NV INT = (SELECT TOP 1 Id FROM ChucVus WHERE MaChucVu = 'CV006');

DECLARE @CA01 INT = (SELECT TOP 1 Id FROM CaLamViecs WHERE MaCa = 'CA01');
DECLARE @CA02 INT = (SELECT TOP 1 Id FROM CaLamViecs WHERE MaCa = 'CA02');
DECLARE @CA03 INT = (SELECT TOP 1 Id FROM CaLamViecs WHERE MaCa = 'CA03');
DECLARE @LP_PHEP INT = (SELECT TOP 1 Id FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP001');
DECLARE @LP_KL INT = (SELECT TOP 1 Id FROM LoaiNghiPheps WHERE MaLoaiNghi = 'LP003');

DECLARE @Seed TABLE
(
    MaNhanVien NVARCHAR(20) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    CCCD NVARCHAR(20) NOT NULL,
    NgayVaoLam DATE NOT NULL,
    LuongCoBan DECIMAL(18,2) NOT NULL,
    PhongBanId INT NOT NULL,
    ChucVuId INT NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL,
    TenDangNhap NVARCHAR(50) NOT NULL,
    CaLamViecId INT NOT NULL,
    TrangThaiCong NVARCHAR(30) NOT NULL,
    SoPhutDiMuon INT NOT NULL,
    SoPhutVeSom INT NOT NULL,
    SoGioLam FLOAT NOT NULL,
    SoGioTangCa FLOAT NOT NULL
);

INSERT INTO @Seed
(MaNhanVien, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, CCCD, NgayVaoLam, LuongCoBan, PhongBanId, ChucVuId, VaiTro, TenDangNhap, CaLamViecId, TrangThaiCong, SoPhutDiMuon, SoPhutVeSom, SoGioLam, SoGioTangCa)
VALUES
('N11', N'Nguyen Hai Dang',   '1999-01-12', 1, '0901000011', 'dang.n11@hrm.local', N'TP.HCM',     '079200000011', '2024-01-08', 11500000, @PB_IT, @CV_DEV, 'NhanVien', 'user011', @CA01, 'CoMat', 0, 0, 8.0, 1.0),
('N12', N'Le Bao Chau',       '2000-03-24', 0, '0901000012', 'chau.n12@hrm.local', N'Binh Duong', '079200000012', '2024-01-15', 10200000, @PB_NS, @CV_NV,  'NhanVien', 'user012', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N13', N'Tran Minh Khoa',    '1998-07-19', 1, '0901000013', 'khoa.n13@hrm.local', N'Dong Nai',   '079200000013', '2024-01-20', 10800000, @PB_KT, @CV_KT,  'NhanVien', 'user013', @CA03, 'DiMuon', 7, 0, 8.0, 0.0),
('N14', N'Pham Nhu Quynh',    '2001-05-02', 0, '0901000014', 'quynh.n14@hrm.local', N'TP.HCM',    '079200000014', '2024-02-01', 9800000,  @PB_KD, @CV_KD,  'NhanVien', 'user014', @CA02, 'CoMat', 0, 0, 8.0, 1.5),
('N15', N'Vo Tuan Anh',       '1997-11-11', 1, '0901000015', 'anh.n15@hrm.local',  N'Long An',    '079200000015', '2024-02-03', 12300000, @PB_IT, @CV_DEV, 'NhanVien', 'user015', @CA01, 'CoMat', 0, 0, 8.6, 2.0),
('N16', N'Dang Thu Ha',       '1999-09-09', 0, '0901000016', 'ha.n16@hrm.local',   N'TP.HCM',     '079200000016', '2024-02-08', 9900000,  @PB_NS, @CV_NV,  'NhanVien', 'user016', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N17', N'Nguyen Duc Huy',    '1996-06-30', 1, '0901000017', 'huy.n17@hrm.local',  N'Tay Ninh',   '079200000017', '2024-02-12', 11800000, @PB_KD, @CV_KD,  'NhanVien', 'user017', @CA02, 'DiMuon', 10, 0, 8.0, 0.0),
('N18', N'Bui Khanh Linh',    '2002-02-20', 0, '0901000018', 'linh.n18@hrm.local', N'TP.HCM',     '079200000018', '2024-02-18', 9700000,  @PB_KT, @CV_NV,  'NhanVien', 'user018', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N19', N'Hoang Gia Huy',     '1998-04-17', 1, '0901000019', 'giahuy.n19@hrm.local', N'Binh Phuoc','079200000019', '2024-02-20', 12100000, @PB_IT, @CV_DEV, 'NhanVien', 'user019', @CA01, 'CoMat', 0, 0, 8.4, 1.0),
('N20', N'Le Ngoc Mai',       '2001-12-05', 0, '0901000020', 'mai.n20@hrm.local',  N'TP.HCM',     '079200000020', '2024-03-01', 9600000,  @PB_NS, @CV_NV,  'NhanVien', 'user020', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N21', N'Pham Quoc Viet',    '1997-08-08', 1, '0901000021', 'viet.n21@hrm.local', N'Dong Nai',   '079200000021', '2024-03-03', 11000000, @PB_KD, @CV_KD,  'NhanVien', 'user021', @CA02, 'VeSom', 0, 8, 7.6, 0.0),
('N22', N'Tran Thi Tam',      '2000-10-10', 0, '0901000022', 'tam.n22@hrm.local',  N'TP.HCM',     '079200000022', '2024-03-05', 10100000, @PB_KT, @CV_KT,  'NhanVien', 'user022', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N23', N'Nguyen Phuc Loc',   '1999-06-16', 1, '0901000023', 'loc.n23@hrm.local',  N'Long An',    '079200000023', '2024-03-06', 12400000, @PB_IT, @CV_DEV, 'NhanVien', 'user023', @CA01, 'CoMat', 0, 0, 8.8, 2.0),
('N24', N'Bui Ngoc Ngan',     '2001-03-27', 0, '0901000024', 'ngan.n24@hrm.local', N'TP.HCM',     '079200000024', '2024-03-09', 9900000,  @PB_NS, @CV_NV,  'NhanVien', 'user024', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N25', N'Hoang Thanh Son',   '1998-12-14', 1, '0901000025', 'son.n25@hrm.local',  N'Tay Ninh',   '079200000025', '2024-03-11', 10900000, @PB_KD, @CV_KD,  'NhanVien', 'user025', @CA02, 'DiMuon', 6, 0, 8.0, 1.0),
('N26', N'Le My Duyen',       '2002-01-09', 0, '0901000026', 'duyen.n26@hrm.local',N'TP.HCM',     '079200000026', '2024-03-15', 9500000,  @PB_KT, @CV_NV,  'NhanVien', 'user026', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N27', N'Pham Tien Dat',     '1997-09-29', 1, '0901000027', 'dat.n27@hrm.local',  N'Binh Duong', '079200000027', '2024-03-18', 12200000, @PB_IT, @CV_DEV, 'NhanVien', 'user027', @CA01, 'CoMat', 0, 0, 8.5, 1.5),
('N28', N'Dang Thu Trang',    '2000-11-18', 0, '0901000028', 'trang.n28@hrm.local',N'TP.HCM',     '079200000028', '2024-03-21', 10000000, @PB_NS, @CV_NV,  'NhanVien', 'user028', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N29', N'Nguyen Tan Phat',   '1998-02-02', 1, '0901000029', 'phat.n29@hrm.local', N'Dong Nai',   '079200000029', '2024-03-24', 11100000, @PB_KD, @CV_KD,  'NhanVien', 'user029', @CA02, 'CoMat', 0, 0, 8.1, 0.5),
('N30', N'Bui Phuong Thao',   '2001-06-22', 0, '0901000030', 'thao.n30@hrm.local', N'TP.HCM',     '079200000030', '2024-03-28', 10300000, @PB_KT, @CV_KT,  'NhanVien', 'user030', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N31', N'Le Quang Minh',     '1996-05-12', 1, '0901000031', 'minh.n31@hrm.local', N'Long An',    '079200000031', '2024-04-01', 12600000, @PB_IT, @CV_DEV, 'NhanVien', 'user031', @CA01, 'DiMuon', 9, 0, 8.2, 1.0),
('N32', N'Tran Kim Ngan',     '2002-04-04', 0, '0901000032', 'ngan.n32@hrm.local', N'TP.HCM',     '079200000032', '2024-04-02', 9700000,  @PB_NS, @CV_NV,  'NhanVien', 'user032', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N33', N'Nguyen Trung Kien', '1999-07-25', 1, '0901000033', 'kien.n33@hrm.local', N'Binh Phuoc', '079200000033', '2024-04-04', 11200000, @PB_KD, @CV_KD,  'NhanVien', 'user033', @CA02, 'CoMat', 0, 0, 8.0, 0.5),
('N34', N'Pham Thanh Huyen',  '2001-08-13', 0, '0901000034', 'huyen.n34@hrm.local',N'TP.HCM',     '079200000034', '2024-04-05', 10400000, @PB_KT, @CV_NV,  'NhanVien', 'user034', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N35', N'Vo Hoai Nam',       '1997-03-03', 1, '0901000035', 'nam.n35@hrm.local',  N'Dong Nai',   '079200000035', '2024-04-06', 12500000, @PB_IT, @CV_DEV, 'NhanVien', 'user035', @CA01, 'CoMat', 0, 0, 8.7, 2.0),
('N36', N'Bui Lan Anh',       '2000-09-21', 0, '0901000036', 'lananh.n36@hrm.local',N'TP.HCM',    '079200000036', '2024-04-07', 9900000,  @PB_NS, @CV_NV,  'NhanVien', 'user036', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N37', N'Nguyen Huu Tin',    '1998-10-10', 1, '0901000037', 'tin.n37@hrm.local',  N'Long An',    '079200000037', '2024-04-08', 11000000, @PB_KD, @CV_KD,  'NhanVien', 'user037', @CA02, 'DiMuon', 8, 0, 8.0, 1.0),
('N38', N'Tran Bao Ngoc',     '2002-05-19', 0, '0901000038', 'ngoc.n38@hrm.local', N'TP.HCM',     '079200000038', '2024-04-09', 10200000, @PB_KT, @CV_KT,  'NhanVien', 'user038', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N39', N'Le Tuan Kiet',      '1997-12-12', 1, '0901000039', 'kiet.n39@hrm.local', N'Binh Duong', '079200000039', '2024-04-10', 12300000, @PB_IT, @CV_DEV, 'NhanVien', 'user039', @CA01, 'CoMat', 0, 0, 8.4, 1.0),
('N40', N'Dang Nhat Vy',      '2001-01-15', 0, '0901000040', 'vy.n40@hrm.local',   N'TP.HCM',     '079200000040', '2024-04-11', 9800000,  @PB_NS, @CV_NV,  'NhanVien', 'user040', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N41', N'Pham Gia Loc',      '1998-06-06', 1, '0901000041', 'loc.n41@hrm.local',  N'Dong Nai',   '079200000041', '2024-04-12', 11100000, @PB_KD, @CV_KD,  'NhanVien', 'user041', @CA02, 'CoMat', 0, 0, 8.1, 0.5),
('N42', N'Nguyen Thu Uyen',   '2000-02-02', 0, '0901000042', 'uyen.n42@hrm.local', N'TP.HCM',     '079200000042', '2024-04-13', 10300000, @PB_KT, @CV_NV,  'NhanVien', 'user042', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N43', N'Hoang Minh Quan',   '1997-07-07', 1, '0901000043', 'quan.n43@hrm.local', N'Long An',    '079200000043', '2024-04-14', 12400000, @PB_IT, @CV_DEV, 'NhanVien', 'user043', @CA01, 'CoMat', 0, 0, 8.6, 1.5),
('N44', N'Bui Ngoc Thao',     '2001-03-30', 0, '0901000044', 'thao.n44@hrm.local', N'TP.HCM',     '079200000044', '2024-04-15', 9900000,  @PB_NS, @CV_NV,  'NhanVien', 'user044', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N45', N'Tran Quoc Bao',     '1998-08-08', 1, '0901000045', 'bao.n45@hrm.local',  N'Binh Phuoc', '079200000045', '2024-04-16', 11200000, @PB_KD, @CV_KD,  'NhanVien', 'user045', @CA02, 'VeSom', 0, 12, 7.5, 0.0),
('N46', N'Le My Hanh',        '2000-10-17', 0, '0901000046', 'hanh.n46@hrm.local', N'TP.HCM',     '079200000046', '2024-04-17', 10400000, @PB_KT, @CV_KT,  'NhanVien', 'user046', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N47', N'Nguyen Van Duc',    '1997-04-18', 1, '0901000047', 'duc.n47@hrm.local',  N'Dong Nai',   '079200000047', '2024-04-18', 12500000, @PB_IT, @CV_DEV, 'NhanVien', 'user047', @CA01, 'DiMuon', 11, 0, 8.1, 1.0),
('N48', N'Pham Thanh Truc',   '2002-06-26', 0, '0901000048', 'truc.n48@hrm.local', N'TP.HCM',     '079200000048', '2024-04-19', 9800000,  @PB_NS, @CV_NV,  'NhanVien', 'user048', @CA03, 'CoMat', 0, 0, 8.0, 0.0),
('N49', N'Vo Quoc Khanh',     '1998-09-14', 1, '0901000049', 'khanh.n49@hrm.local',N'Long An',    '079200000049', '2024-04-20', 11100000, @PB_KD, @CV_KD,  'NhanVien', 'user049', @CA02, 'CoMat', 0, 0, 8.0, 0.5),
('N50', N'Dang Minh Anh',     '2001-11-01', 0, '0901000050', 'minhanh.n50@hrm.local',N'TP.HCM',   '079200000050', '2024-04-21', 10500000, @PB_KT, @CV_NV,  'NhanVien', 'user050', @CA03, 'CoMat', 0, 0, 8.0, 0.0);

INSERT INTO NhanViens
(MaNhanVien, HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, CCCD, NgayVaoLam, NgayNghiViec, LuongCoBan, DangLamViec, PhongBanId, ChucVuId, NgayTao, NgayCapNhat)
SELECT
    s.MaNhanVien, s.HoTen, s.NgaySinh, s.GioiTinh, s.SoDienThoai, s.Email, s.DiaChi, s.CCCD,
    s.NgayVaoLam, NULL, s.LuongCoBan, 1, s.PhongBanId, s.ChucVuId, @Now, NULL
FROM @Seed s
WHERE NOT EXISTS (SELECT 1 FROM NhanViens nv WHERE nv.MaNhanVien = s.MaNhanVien);

INSERT INTO TaiKhoans (TenDangNhap, MatKhauHash, VaiTro, HoatDong, NhanVienId, NgayTao, NgayCapNhat)
SELECT s.TenDangNhap, @PasswordHash, s.VaiTro, 1, nv.Id, @Now, NULL
FROM @Seed s
JOIN NhanViens nv ON nv.MaNhanVien = s.MaNhanVien
WHERE NOT EXISTS (SELECT 1 FROM TaiKhoans tk WHERE tk.TenDangNhap = s.TenDangNhap);

INSERT INTO PhanCaNhanViens (NhanVienId, CaLamViecId, NgayLamViec, NgayTao, NgayCapNhat)
SELECT nv.Id, s.CaLamViecId, '2026-04-07', @Now, NULL
FROM @Seed s
JOIN NhanViens nv ON nv.MaNhanVien = s.MaNhanVien
WHERE NOT EXISTS
(
    SELECT 1
    FROM PhanCaNhanViens pc
    WHERE pc.NhanVienId = nv.Id AND pc.NgayLamViec = '2026-04-07'
);

INSERT INTO ChamCongs
(NhanVienId, CaLamViecId, NgayLamViec, GioCheckIn, GioCheckOut, SoPhutDiMuon, SoPhutVeSom, SoGioLam, SoGioTangCa, TrangThai, GhiChu, NgayTao, NgayCapNhat)
SELECT
    nv.Id,
    s.CaLamViecId,
    '2026-04-07',
    CASE
        WHEN s.CaLamViecId = @CA02 THEN DATEADD(MINUTE, 2 + s.SoPhutDiMuon, CAST('2026-04-07T13:00:00' AS DATETIME))
        WHEN s.CaLamViecId = @CA03 THEN DATEADD(MINUTE, 30 + s.SoPhutDiMuon, CAST('2026-04-07T08:00:00' AS DATETIME))
        ELSE DATEADD(MINUTE, s.SoPhutDiMuon, CAST('2026-04-07T08:00:00' AS DATETIME))
    END,
    CASE
        WHEN s.CaLamViecId = @CA02 THEN DATEADD(MINUTE, -s.SoPhutVeSom, CAST('2026-04-07T22:00:00' AS DATETIME))
        WHEN s.CaLamViecId = @CA03 THEN DATEADD(MINUTE, -s.SoPhutVeSom, CAST('2026-04-07T17:30:00' AS DATETIME))
        ELSE DATEADD(MINUTE, -s.SoPhutVeSom, CAST('2026-04-07T17:00:00' AS DATETIME))
    END,
    s.SoPhutDiMuon,
    s.SoPhutVeSom,
    s.SoGioLam,
    s.SoGioTangCa,
    s.TrangThaiCong,
    N'Du lieu demo mo rong',
    @Now,
    NULL
FROM @Seed s
JOIN NhanViens nv ON nv.MaNhanVien = s.MaNhanVien
WHERE NOT EXISTS
(
    SELECT 1
    FROM ChamCongs cc
    WHERE cc.NhanVienId = nv.Id AND cc.NgayLamViec = '2026-04-07'
);

INSERT INTO DonTangCas (NhanVienId, NgayLam, TuGio, DenGio, TongSoGio, LyDo, TrangThai, NgayDuyet, NguoiDuyet, NgayTao, NgayCapNhat)
SELECT nv.Id, '2026-04-06', '2026-04-06T18:00:00', '2026-04-06T20:00:00', 2.0, N'Tang ca du an', 'DaDuyet', @Now, 'hr001', @Now, NULL
FROM @Seed s
JOIN NhanViens nv ON nv.MaNhanVien = s.MaNhanVien
WHERE s.MaNhanVien IN ('N11','N15','N19','N23','N27','N31','N35','N39','N43','N47')
  AND NOT EXISTS
  (
      SELECT 1 FROM DonTangCas dt
      WHERE dt.NhanVienId = nv.Id AND dt.NgayLam = '2026-04-06'
  );

INSERT INTO DonNghiPheps (NhanVienId, LoaiNghiPhepId, TuNgay, DenNgay, TongSoNgay, LyDo, TrangThai, NgayDuyet, NguoiDuyet, NgayTao, NgayCapNhat)
SELECT nv.Id,
       CASE WHEN s.MaNhanVien IN ('N21','N45') THEN @LP_KL ELSE @LP_PHEP END,
       '2026-04-04',
       '2026-04-04',
       1.0,
       CASE WHEN s.MaNhanVien IN ('N21','N45') THEN N'Nghi viec rieng' ELSE N'Nghi phep 1 ngay' END,
       'DaDuyet',
       @Now,
       'hr001',
       @Now,
       NULL
FROM @Seed s
JOIN NhanViens nv ON nv.MaNhanVien = s.MaNhanVien
WHERE s.MaNhanVien IN ('N12','N16','N20','N24','N28','N32','N36','N40','N44','N48','N21','N45')
  AND NOT EXISTS
  (
      SELECT 1 FROM DonNghiPheps dnp
      WHERE dnp.NhanVienId = nv.Id AND dnp.TuNgay = '2026-04-04'
  );

PRINT N'Da them tiep 40 du lieu demo tu N11 den N50.';
PRINT N'Ten dang nhap: user011 -> user050';
PRINT N'Mat khau chung: 123456';
GO
