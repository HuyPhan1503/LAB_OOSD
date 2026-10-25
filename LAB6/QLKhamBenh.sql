/* ============================================================
   CSDL: QL_KhamBenh  (SQL Server / T-SQL)
   Chay toan bo script trong SSMS de tao database + bang + du lieu mau
   ============================================================ */
USE master;
GO
IF DB_ID(N'QL_KhamBenh') IS NOT NULL
BEGIN
    ALTER DATABASE QL_KhamBenh SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QL_KhamBenh;
END
GO
CREATE DATABASE QL_KhamBenh COLLATE Vietnamese_CI_AS;
GO
USE QL_KhamBenh;
GO

/* ---------- 1. Danh muc ---------- */
CREATE TABLE KHOA (
    MaKhoa   INT IDENTITY(1,1) PRIMARY KEY,
    TenKhoa  NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE BACSI (
    MaBS       INT IDENTITY(1,1) PRIMARY KEY,
    HoTen      NVARCHAR(100) NOT NULL,
    MaKhoa     INT NOT NULL REFERENCES KHOA(MaKhoa),
    ChuyenMon  NVARCHAR(100) NULL,
    DienThoai  VARCHAR(15)   NULL
);

CREATE TABLE NHANVIEN (
    MaNV         INT IDENTITY(1,1) PRIMARY KEY,
    HoTen        NVARCHAR(100) NOT NULL,
    ChucVu       VARCHAR(20) NOT NULL
        CHECK (ChucVu IN ('TiepNhan','ThuNgan','ChamSocKH','QuanLy')),
    TenDangNhap  VARCHAR(50)  NOT NULL UNIQUE,
    MatKhau      VARCHAR(255) NOT NULL          -- luu dang hash
);

CREATE TABLE THUOC (
    MaThuoc   INT IDENTITY(1,1) PRIMARY KEY,
    TenThuoc  NVARCHAR(150) NOT NULL,
    DonVi     NVARCHAR(30)  NOT NULL,
    DonGia    DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0)
);

CREATE TABLE XETNGHIEM (
    MaXN    INT IDENTITY(1,1) PRIMARY KEY,
    TenXN   NVARCHAR(150) NOT NULL,
    DonGia  DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0)
);

/* ---------- 2. Dang ky & ho so benh an ---------- */
CREATE TABLE PHIEUDANGKY (
    MaPhieu      INT IDENTITY(1,1) PRIMARY KEY,
    HoTen        NVARCHAR(100) NOT NULL,
    DiaChi       NVARCHAR(255) NOT NULL,
    NgaySinh     DATE NOT NULL,
    DienThoai    VARCHAR(15) NOT NULL,
    AnhThe3x4    NVARCHAR(260) NULL,            -- duong dan file anh
    CCCD         CHAR(12) NOT NULL UNIQUE
        CHECK (CCCD NOT LIKE '%[^0-9]%'),
    SoBHYT       VARCHAR(15) NULL,
    NgayDangKy   DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE)
);

CREATE TABLE HOSOBENHAN (
    MaHS        INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu     INT NOT NULL UNIQUE REFERENCES PHIEUDANGKY(MaPhieu),
    NgayCap     DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    NgayHetHan  DATE NOT NULL                   -- hieu luc den (cap nhat khi gia han)
);

CREATE TABLE LEPHI (
    MaLP     INT IDENTITY(1,1) PRIMARY KEY,
    MaHS     INT NOT NULL REFERENCES HOSOBENHAN(MaHS),
    MaNV     INT NOT NULL REFERENCES NHANVIEN(MaNV),
    NgayDong DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    TuNgay   DATE NOT NULL,
    DenNgay  DATE NOT NULL,
    SoTien   DECIMAL(18,0) NOT NULL CHECK (SoTien >= 0),
    CHECK (DenNgay > TuNgay)
);

/* ---------- 3. Lich hen & kham benh ---------- */
CREATE TABLE LICHHEN (
    MaLH        INT IDENTITY(1,1) PRIMARY KEY,
    MaHS        INT NOT NULL REFERENCES HOSOBENHAN(MaHS),
    MaBS        INT NOT NULL REFERENCES BACSI(MaBS),
    MaNV        INT NULL REFERENCES NHANVIEN(MaNV),   -- nhan vien CSKH nhan cuoc goi
    NgayGioHen  DATETIME NOT NULL,
    TrangThai   NVARCHAR(20) NOT NULL DEFAULT N'Đã hẹn'
        CHECK (TrangThai IN (N'Đã hẹn', N'Đã khám', N'Hủy')),
    CONSTRAINT UQ_LichHen_BS UNIQUE (MaBS, NgayGioHen)   -- BR10: bac si khong trung lich
);

CREATE TABLE PHIEUKHAM (
    MaPK         INT IDENTITY(1,1) PRIMARY KEY,
    MaHS         INT NOT NULL REFERENCES HOSOBENHAN(MaHS),
    MaBS         INT NOT NULL REFERENCES BACSI(MaBS),
    MaKhoa       INT NOT NULL REFERENCES KHOA(MaKhoa),
    MaLH         INT NULL REFERENCES LICHHEN(MaLH),
    NgayGioKham  DATETIME NOT NULL DEFAULT GETDATE(),
    LoaiKham     VARCHAR(10) NOT NULL DEFAULT 'Benh'
        CHECK (LoaiKham IN ('Benh','DinhKy')),
    Quy          TINYINT NULL CHECK (Quy BETWEEN 1 AND 4),
    Nam          SMALLINT NULL,
    TrieuChung   NVARCHAR(500) NULL,            -- nhuc dau, than nhiet,...
    KetLuan      NVARCHAR(500) NULL,            -- khong benh / mam benh phat hien som
    CONSTRAINT UQ_PhieuKham_BS UNIQUE (MaBS, NgayGioKham),
    CONSTRAINT CK_KhamDinhKy CHECK (
        (LoaiKham = 'DinhKy' AND Quy IS NOT NULL AND Nam IS NOT NULL)
        OR LoaiKham = 'Benh')
);
-- Moi ho so chi duoc kham dinh ky 1 lan / quy / nam
CREATE UNIQUE INDEX UX_PhieuKham_DinhKy
    ON PHIEUKHAM (MaHS, Nam, Quy) WHERE LoaiKham = 'DinhKy';

CREATE TABLE TOATHUOC (
    MaToa    INT IDENTITY(1,1) PRIMARY KEY,
    MaPK     INT NOT NULL UNIQUE REFERENCES PHIEUKHAM(MaPK),
    NgayKe   DATETIME NOT NULL DEFAULT GETDATE(),
    GhiChu   NVARCHAR(255) NULL
);

CREATE TABLE CHITIETTOA (
    MaToa     INT NOT NULL REFERENCES TOATHUOC(MaToa),
    MaThuoc   INT NOT NULL REFERENCES THUOC(MaThuoc),
    SoLuong   INT NOT NULL CHECK (SoLuong > 0),
    LieuDung  NVARCHAR(100) NOT NULL,           -- vd: 2 vien/lan, 3 lan/ngay
    CachDung  NVARCHAR(150) NULL,
    PRIMARY KEY (MaToa, MaThuoc)
);

CREATE TABLE CHITIETXETNGHIEM (
    MaPK         INT NOT NULL REFERENCES PHIEUKHAM(MaPK),
    MaXN         INT NOT NULL REFERENCES XETNGHIEM(MaXN),
    NgayChiDinh  DATETIME NOT NULL DEFAULT GETDATE(),
    KetQua       NVARCHAR(500) NULL,
    NgayCoKQ     DATETIME NULL,
    PRIMARY KEY (MaPK, MaXN)
);

/* ---------- 4. Xuat vien, vien phi, theo doi ---------- */
CREATE TABLE HOADON (
    MaHD         INT IDENTITY(1,1) PRIMARY KEY,
    MaPK         INT NOT NULL UNIQUE REFERENCES PHIEUKHAM(MaPK),
    MaNV         INT NOT NULL REFERENCES NHANVIEN(MaNV),   -- thu ngan
    NgayLap      DATETIME NOT NULL DEFAULT GETDATE(),
    TongTien     DECIMAL(18,0) NOT NULL CHECK (TongTien >= 0),
    HinhThucTT   NVARCHAR(30) NOT NULL DEFAULT N'Tiền mặt',
    TrangThai    NVARCHAR(20) NOT NULL DEFAULT N'Đã thanh toán'
        CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán')),
    NgayXuatVien DATETIME NULL
);

CREATE TABLE THEODOI (
    MaTD              INT IDENTITY(1,1) PRIMARY KEY,
    MaHD              INT NOT NULL REFERENCES HOADON(MaHD),  -- chi ghi sau khi xuat vien + thanh toan
    MaNV              INT NOT NULL REFERENCES NHANVIEN(MaNV),-- nhan vien CSKH
    NgayGhiNhan       DATETIME NOT NULL DEFAULT GETDATE(),
    DienBienBenh      NVARCHAR(500) NULL,
    PhanUngPhu        NVARCHAR(500) NULL,
    HieuQuaDieuTri    NVARCHAR(500) NULL,
    TrachNhiemBacSi   NVARCHAR(500) NULL
);
GO

/* ---------- 5. Index phuc vu tra cuu ---------- */
CREATE INDEX IX_Phieu_HoTen   ON PHIEUDANGKY(HoTen);
CREATE INDEX IX_Phieu_BHYT    ON PHIEUDANGKY(SoBHYT);
CREATE INDEX IX_PK_HoSo       ON PHIEUKHAM(MaHS, NgayGioKham DESC);
GO

/* ---------- 6. Du lieu mau ---------- */
INSERT INTO KHOA(TenKhoa) VALUES (N'Nội tổng quát'), (N'Nhi'), (N'Tai mũi họng'), (N'Da liễu');

INSERT INTO BACSI(HoTen, MaKhoa, ChuyenMon, DienThoai) VALUES
 (N'Nguyễn Văn An', 1, N'Nội tổng quát', '0901000001'),
 (N'Trần Thị Bình', 2, N'Nhi khoa',      '0901000002');

INSERT INTO NHANVIEN(HoTen, ChucVu, TenDangNhap, MatKhau) VALUES
 (N'Lê Thu Hà',    'TiepNhan',  'tiepnhan1', 'CHANGE_ME'),
 (N'Phạm Minh Tú', 'ThuNgan',   'thungan1',  'CHANGE_ME'),
 (N'Võ Ngọc Lan',  'ChamSocKH', 'cskh1',     'CHANGE_ME'),
 (N'Đỗ Quang Huy', 'QuanLy',    'quanly1',   'CHANGE_ME');

INSERT INTO THUOC(TenThuoc, DonVi, DonGia) VALUES
 (N'Paracetamol 500mg', N'Viên', 1000),
 (N'Amoxicillin 500mg', N'Viên', 3000);

INSERT INTO XETNGHIEM(TenXN, DonGia) VALUES
 (N'Công thức máu', 80000),
 (N'Xét nghiệm nước tiểu', 60000);
GO