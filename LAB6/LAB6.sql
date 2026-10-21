/* ============================================================
   CSDL: QL_KhamBenh (MySQL / MariaDB)
   Chạy toàn bộ script này trong MySQL Workbench hoặc phpMyAdmin
   ============================================================ */

DROP DATABASE IF EXISTS QL_KhamBenh;
CREATE DATABASE QL_KhamBenh 
    CHARACTER SET utf8mb4 
    COLLATE utf8mb4_unicode_ci;

USE QL_KhamBenh;

/* ---------- 1. Danh mục ---------- */
CREATE TABLE KHOA (
    MaKhoa  INT AUTO_INCREMENT PRIMARY KEY,
    TenKhoa VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE BACSI (
    MaBS      INT AUTO_INCREMENT PRIMARY KEY,
    HoTen     VARCHAR(100) NOT NULL,
    MaKhoa    INT NOT NULL,
    ChuyenMon VARCHAR(100) NULL,
    DienThoai VARCHAR(15)  NULL,
    CONSTRAINT FK_BacSi_Khoa FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
) ENGINE=InnoDB;

CREATE TABLE NHANVIEN (
    MaNV        INT AUTO_INCREMENT PRIMARY KEY,
    HoTen       VARCHAR(100) NOT NULL,
    ChucVu      VARCHAR(20) NOT NULL 
        CHECK (ChucVu IN ('TiepNhan','ThuNgan','ChamSocKH','QuanLy')),
    TenDangNhap VARCHAR(50)  NOT NULL UNIQUE,
    MatKhau     VARCHAR(255) NOT NULL          -- lưu dạng hash
) ENGINE=InnoDB;

CREATE TABLE THUOC (
    MaThuoc  INT AUTO_INCREMENT PRIMARY KEY,
    TenThuoc VARCHAR(150) NOT NULL,
    DonVi    VARCHAR(30)  NOT NULL,
    DonGia   DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0)
) ENGINE=InnoDB;

CREATE TABLE XETNGHIEM (
    MaXN   INT AUTO_INCREMENT PRIMARY KEY,
    TenXN  VARCHAR(150) NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0)
) ENGINE=InnoDB;

/* ---------- 2. Đăng ký & hồ sơ bệnh án ---------- */
CREATE TABLE PHIEUDANGKY (
    MaPhieu    INT AUTO_INCREMENT PRIMARY KEY,
    HoTen      VARCHAR(100) NOT NULL,
    DiaChi     VARCHAR(255) NOT NULL,
    NgaySinh   DATE NOT NULL,
    DienThoai  VARCHAR(15) NOT NULL,
    AnhThe3x4  VARCHAR(260) NULL,             -- đường dẫn file ảnh
    CCCD       CHAR(12) NOT NULL UNIQUE,
    SoBHYT     VARCHAR(15) NULL,
    NgayDangKy DATE NOT NULL DEFAULT (CURRENT_DATE),
    CONSTRAINT CK_CCCD_Digits CHECK (CCCD REGEXP '^[0-9]{12}$')
) ENGINE=InnoDB;

CREATE TABLE HOSOBENHAN (
    MaHS       INT AUTO_INCREMENT PRIMARY KEY,
    MaPhieu    INT NOT NULL UNIQUE,
    NgayCap    DATE NOT NULL DEFAULT (CURRENT_DATE),
    NgayHetHan DATE NOT NULL,                  -- hiệu lực đến (cập nhật khi gia hạn)
    CONSTRAINT FK_HSBA_Phieu FOREIGN KEY (MaPhieu) REFERENCES PHIEUDANGKY(MaPhieu)
) ENGINE=InnoDB;

CREATE TABLE LEPHI (
    MaLP     INT AUTO_INCREMENT PRIMARY KEY,
    MaHS     INT NOT NULL,
    MaNV     INT NOT NULL,
    NgayDong DATE NOT NULL DEFAULT (CURRENT_DATE),
    TuNgay   DATE NOT NULL,
    DenNgay  DATE NOT NULL,
    SoTien   DECIMAL(18,0) NOT NULL CHECK (SoTien >= 0),
    CONSTRAINT FK_LePhi_HSBA FOREIGN KEY (MaHS) REFERENCES HOSOBENHAN(MaHS),
    CONSTRAINT FK_LePhi_NhanVien FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT CK_LePhi_Han CHECK (DenNgay > TuNgay)
) ENGINE=InnoDB;

/* ---------- 3. Lịch hẹn & khám bệnh ---------- */
CREATE TABLE LICHHEN (
    MaLH       INT AUTO_INCREMENT PRIMARY KEY,
    MaHS       INT NOT NULL,
    MaBS       INT NOT NULL,
    MaNV       INT NULL,                       -- nhân viên CSKH nhận cuộc gọi
    NgayGioHen DATETIME NOT NULL,
    TrangThai  VARCHAR(20) NOT NULL DEFAULT 'Đã hẹn'
        CHECK (TrangThai IN ('Đã hẹn', 'Đã khám', 'Hủy')),
    CONSTRAINT FK_LichHen_HSBA FOREIGN KEY (MaHS) REFERENCES HOSOBENHAN(MaHS),
    CONSTRAINT FK_LichHen_BacSi FOREIGN KEY (MaBS) REFERENCES BACSI(MaBS),
    CONSTRAINT FK_LichHen_NhanVien FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT UQ_LichHen_BS UNIQUE (MaBS, NgayGioHen)   -- BR10: bác sĩ không trùng lịch
) ENGINE=InnoDB;

CREATE TABLE PHIEUKHAM (
    MaPK        INT AUTO_INCREMENT PRIMARY KEY,
    MaHS        INT NOT NULL,
    MaBS        INT NOT NULL,
    MaKhoa      INT NOT NULL,
    MaLH        INT NULL,
    NgayGioKham DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    LoaiKham    VARCHAR(10) NOT NULL DEFAULT 'Benh'
        CHECK (LoaiKham IN ('Benh','DinhKy')),
    Quy         TINYINT NULL CHECK (Quy BETWEEN 1 AND 4),
    Nam         SMALLINT NULL,
    TrieuChung  VARCHAR(500) NULL,             -- nhức đầu, thân nhiệt,...
    KetLuan     VARCHAR(500) NULL,             -- không bệnh / mầm bệnh phát hiện sớm
    CONSTRAINT FK_PhieuKham_HSBA FOREIGN KEY (MaHS) REFERENCES HOSOBENHAN(MaHS),
    CONSTRAINT FK_PhieuKham_BacSi FOREIGN KEY (MaBS) REFERENCES BACSI(MaBS),
    CONSTRAINT FK_PhieuKham_Khoa FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa),
    CONSTRAINT FK_PhieuKham_LichHen FOREIGN KEY (MaLH) REFERENCES LICHHEN(MaLH),
    CONSTRAINT UQ_PhieuKham_BS UNIQUE (MaBS, NgayGioKham),
    CONSTRAINT CK_KhamDinhKy CHECK (
        (LoaiKham = 'DinhKy' AND Quy IS NOT NULL AND Nam IS NOT NULL)
        OR LoaiKham = 'Benh')
) ENGINE=InnoDB;

-- Mỗi hồ sơ chỉ được khám định kỳ 1 lần / quý / năm (MySQL 8.0+ hỗ trợ Functional Unique Index)
CREATE UNIQUE INDEX UX_PhieuKham_DinhKy
    ON PHIEUKHAM (MaHS, Nam, Quy, (CASE WHEN LoaiKham = 'DinhKy' THEN 1 ELSE NULL END));

CREATE TABLE TOATHUOC (
    MaToa   INT AUTO_INCREMENT PRIMARY KEY,
    MaPK    INT NOT NULL UNIQUE,
    NgayKe  DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    GhiChu  VARCHAR(255) NULL,
    CONSTRAINT FK_ToaThuoc_PhieuKham FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK)
) ENGINE=InnoDB;

CREATE TABLE CHITIETTOA (
    MaToa    INT NOT NULL,
    MaThuoc  INT NOT NULL,
    SoLuong  INT NOT NULL CHECK (SoLuong > 0),
    LieuDung VARCHAR(100) NOT NULL,            -- ví dụ: 2 viên/lần, 3 lần/ngày
    CachDung VARCHAR(150) NULL,
    PRIMARY KEY (MaToa, MaThuoc),
    CONSTRAINT FK_ChiTietToa_Toa FOREIGN KEY (MaToa) REFERENCES TOATHUOC(MaToa),
    CONSTRAINT FK_ChiTietToa_Thuoc FOREIGN KEY (MaThuoc) REFERENCES THUOC(MaThuoc)
) ENGINE=InnoDB;

CREATE TABLE CHITIETXETNGHIEM (
    MaPK        INT NOT NULL,
    MaXN        INT NOT NULL,
    NgayChiDinh DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    KetQua      VARCHAR(500) NULL,
    NgayCoKQ    DATETIME NULL,
    PRIMARY KEY (MaPK, MaXN),
    CONSTRAINT FK_ChiTietXN_PhieuKham FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK),
    CONSTRAINT FK_ChiTietXN_XetNghiem FOREIGN KEY (MaXN) REFERENCES XETNGHIEM(MaXN)
) ENGINE=InnoDB;

/* ---------- 4. Xuất viện, viện phí, theo dõi ---------- */
CREATE TABLE HOADON (
    MaHD         INT AUTO_INCREMENT PRIMARY KEY,
    MaPK         INT NOT NULL UNIQUE,
    MaNV         INT NOT NULL,                 -- thu ngân
    NgayLap      DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TongTien     DECIMAL(18,0) NOT NULL CHECK (TongTien >= 0),
    HinhThucTT   VARCHAR(30) NOT NULL DEFAULT 'Tiền mặt',
    TrangThai    VARCHAR(20) NOT NULL DEFAULT 'Đã thanh toán'
        CHECK (TrangThai IN ('Chưa thanh toán', 'Đã thanh toán')),
    NgayXuatVien DATETIME NULL,
    CONSTRAINT FK_HoaDon_PhieuKham FOREIGN KEY (MaPK) REFERENCES PHIEUKHAM(MaPK),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
) ENGINE=InnoDB;

CREATE TABLE THEODOI (
    MaTD            INT AUTO_INCREMENT PRIMARY KEY,
    MaHD            INT NOT NULL,              -- chỉ ghi sau khi xuất viện + thanh toán
    MaNV            INT NOT NULL,              -- nhân viên CSKH
    NgayGhiNhan     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DienBienBenh    VARCHAR(500) NULL,
    PhanUngPhu      VARCHAR(500) NULL,
    HieuQuaDieuTri  VARCHAR(500) NULL,
    TrachNhiemBacSi VARCHAR(500) NULL,
    CONSTRAINT FK_TheoDoi_HoaDon FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
    CONSTRAINT FK_TheoDoi_NhanVien FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
) ENGINE=InnoDB;

/* ---------- 5. Index phục vụ tra cứu ---------- */
CREATE INDEX IX_Phieu_HoTen ON PHIEUDANGKY(HoTen);
CREATE INDEX IX_Phieu_BHYT  ON PHIEUDANGKY(SoBHYT);
CREATE INDEX IX_PK_HoSo     ON PHIEUKHAM(MaHS, NgayGioKham DESC);

/* ---------- 6. Dữ liệu mẫu ---------- */
INSERT INTO KHOA(TenKhoa) VALUES 
('Nội tổng quát'), 
('Nhi'), 
('Tai mũi họng'), 
('Da liễu');

INSERT INTO BACSI(HoTen, MaKhoa, ChuyenMon, DienThoai) VALUES
('Nguyễn Văn An', 1, 'Nội tổng quát', '0901000001'),
('Trần Thị Bình', 2, 'Nhi khoa',      '0901000002');

INSERT INTO NHANVIEN(HoTen, ChucVu, TenDangNhap, MatKhau) VALUES
('Lê Thu Hà',    'TiepNhan',  'tiepnhan1', 'CHANGE_ME'),
('Phạm Minh Tú', 'ThuNgan',   'thungan1',  'CHANGE_ME'),
('Võ Ngọc Lan',  'ChamSocKH', 'cskh1',     'CHANGE_ME'),
('Đỗ Quang Huy', 'QuanLy',    'quanly1',   'CHANGE_ME');

INSERT INTO THUOC(TenThuoc, DonVi, DonGia) VALUES
('Paracetamol 500mg', 'Viên', 1000),
('Amoxicillin 500mg', 'Viên', 3000);

INSERT INTO XETNGHIEM(TenXN, DonGia) VALUES
('Công thức máu', 80000),
('Xét nghiệm nước tiểu', 60000);