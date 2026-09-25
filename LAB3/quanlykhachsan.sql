CREATE DATABASE IF NOT EXISTS QuanLyKhachSan
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE QuanLyKhachSan;
SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS ThanhToan;
DROP TABLE IF EXISTS HoaDon;
DROP TABLE IF EXISTS ChiTietPhieuDenBu;
DROP TABLE IF EXISTS PhieuDenBu;
DROP TABLE IF EXISTS QuyDinhDenBu;
DROP TABLE IF EXISTS ChiTietPhieuSuDungDV;
DROP TABLE IF EXISTS PhieuSuDungDV;
DROP TABLE IF EXISTS DichVu;
DROP TABLE IF EXISTS NguoiLuuTru;
DROP TABLE IF EXISTS ChiTietDatPhong;
DROP TABLE IF EXISTS PhieuDatPhong;
DROP TABLE IF EXISTS KhachHang;
DROP TABLE IF EXISTS PhieuLapDat;
DROP TABLE IF EXISTS TienNghi;
DROP TABLE IF EXISTS LoaiTienNghi;
DROP TABLE IF EXISTS Phong;
DROP TABLE IF EXISTS KhuVuc;
DROP TABLE IF EXISTS NhanVien;

SET FOREIGN_KEY_CHECKS = 1;


-- =====================================================
-- 1. NHÂN VIÊN
-- =====================================================

CREATE TABLE NhanVien (
    MaNV VARCHAR(20) NOT NULL,
    HoTen VARCHAR(120) NOT NULL,
    VaiTro VARCHAR(50) NOT NULL,
    SoDienThoai VARCHAR(20) NULL,

    PRIMARY KEY (MaNV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 2. KHU VỰC
-- =====================================================

CREATE TABLE KhuVuc (
    MaKhuVuc VARCHAR(20) NOT NULL,
    TenKhuVuc VARCHAR(100) NOT NULL,

    PRIMARY KEY (MaKhuVuc),
    UNIQUE KEY UQ_KhuVuc_Ten (TenKhuVuc)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 3. PHÒNG
-- =====================================================

CREATE TABLE Phong (
    SoPhong VARCHAR(20) NOT NULL,
    MaKhuVuc VARCHAR(20) NOT NULL,
    SoNguoiToiDa INT NOT NULL,
    DonGiaNgay DECIMAL(18,2) NOT NULL,
    TrangThai VARCHAR(30) NOT NULL DEFAULT 'Trống',

    PRIMARY KEY (SoPhong),

    CONSTRAINT CK_Phong_SoNguoi
        CHECK (SoNguoiToiDa > 0),

    CONSTRAINT CK_Phong_DonGia
        CHECK (DonGiaNgay >= 0),

    CONSTRAINT CK_Phong_TrangThai
        CHECK (TrangThai IN ('Trống', 'Đã đặt', 'Đang ở', 'Bảo trì')),

    CONSTRAINT FK_Phong_KhuVuc
        FOREIGN KEY (MaKhuVuc)
        REFERENCES KhuVuc(MaKhuVuc)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 4. LOẠI TIỆN NGHI
-- =====================================================

CREATE TABLE LoaiTienNghi (
    MaLoaiTN VARCHAR(20) NOT NULL,
    TenLoaiTN VARCHAR(100) NOT NULL,

    PRIMARY KEY (MaLoaiTN),
    UNIQUE KEY UQ_LoaiTienNghi_Ten (TenLoaiTN)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 5. TIỆN NGHI
-- =====================================================

CREATE TABLE TienNghi (
    MaTienNghi VARCHAR(30) NOT NULL,
    MaLoaiTN VARCHAR(20) NOT NULL,
    SoThuTu INT NOT NULL,
    TinhTrangHienTai VARCHAR(100) NULL,

    PRIMARY KEY (MaTienNghi),

    UNIQUE KEY UQ_TienNghi_Loai_STT
        (MaLoaiTN, SoThuTu),

    CONSTRAINT CK_TienNghi_SoThuTu
        CHECK (SoThuTu > 0),

    CONSTRAINT FK_TienNghi_Loai
        FOREIGN KEY (MaLoaiTN)
        REFERENCES LoaiTienNghi(MaLoaiTN)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 6. PHIẾU LẮP ĐẶT
-- =====================================================

CREATE TABLE PhieuLapDat (
    SoPhieuLapDat VARCHAR(30) NOT NULL,
    MaTienNghi VARCHAR(30) NOT NULL,
    SoPhong VARCHAR(20) NOT NULL,
    NgayLap DATE NOT NULL,
    TinhTrang VARCHAR(100) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    GhiChu VARCHAR(250) NULL,

    PRIMARY KEY (SoPhieuLapDat),

    UNIQUE KEY UQ_PhieuLapDat_ThietBi_Ngay
        (MaTienNghi, NgayLap),

    CONSTRAINT FK_PhieuLapDat_TienNghi
        FOREIGN KEY (MaTienNghi)
        REFERENCES TienNghi(MaTienNghi),

    CONSTRAINT FK_PhieuLapDat_Phong
        FOREIGN KEY (SoPhong)
        REFERENCES Phong(SoPhong),

    CONSTRAINT FK_PhieuLapDat_NV
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 7. KHÁCH HÀNG
-- =====================================================

CREATE TABLE KhachHang (
    MaKhach VARCHAR(20) NOT NULL,
    HoTen VARCHAR(120) NOT NULL,
    SoCMND VARCHAR(30) NOT NULL,
    QuocTich VARCHAR(80) NOT NULL,
    SoDienThoai VARCHAR(20) NULL,

    PRIMARY KEY (MaKhach),
    UNIQUE KEY UQ_KhachHang_CMND (SoCMND)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 8. PHIẾU ĐẶT PHÒNG
-- =====================================================

CREATE TABLE PhieuDatPhong (
    SoPhieuDat VARCHAR(30) NOT NULL,
    MaKhach VARCHAR(20) NOT NULL,
    MaNVLeTan VARCHAR(20) NOT NULL,
    NgayLap DATETIME NOT NULL,
    NgayNhan DATE NOT NULL,
    NgayTraDuKien DATE NOT NULL,
    TienCoc DECIMAL(18,2) NOT NULL DEFAULT 0,
    KenhDat VARCHAR(20) NOT NULL,
    TrangThai VARCHAR(30) NOT NULL DEFAULT 'Đã đặt',
    NgayNhanThucTe DATETIME NULL,
    NgayTraThucTe DATETIME NULL,

    PRIMARY KEY (SoPhieuDat),

    CONSTRAINT CK_PhieuDat_TienCoc
        CHECK (TienCoc >= 0),

    CONSTRAINT CK_PhieuDat_Ngay
        CHECK (NgayTraDuKien >= NgayNhan),

    CONSTRAINT CK_PhieuDat_Kenh
        CHECK (KenhDat IN ('Điện thoại', 'Website', 'Trực tiếp')),

    CONSTRAINT CK_PhieuDat_TrangThai
        CHECK (TrangThai IN ('Đã đặt', 'Đang ở', 'Đã trả', 'No-show', 'Hủy')),

    CONSTRAINT FK_PhieuDat_Khach
        FOREIGN KEY (MaKhach)
        REFERENCES KhachHang(MaKhach),

    CONSTRAINT FK_PhieuDat_NV
        FOREIGN KEY (MaNVLeTan)
        REFERENCES NhanVien(MaNV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 9. CHI TIẾT ĐẶT PHÒNG
-- =====================================================

CREATE TABLE ChiTietDatPhong (
    SoPhieuDat VARCHAR(30) NOT NULL,
    SoPhong VARCHAR(20) NOT NULL,
    SoNguoi INT NOT NULL,

    PRIMARY KEY (SoPhieuDat, SoPhong),

    CONSTRAINT CK_CTDat_SoNguoi
        CHECK (SoNguoi > 0),

    CONSTRAINT FK_CTDat_Phieu
        FOREIGN KEY (SoPhieuDat)
        REFERENCES PhieuDatPhong(SoPhieuDat),

    CONSTRAINT FK_CTDat_Phong
        FOREIGN KEY (SoPhong)
        REFERENCES Phong(SoPhong)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 10. NGƯỜI LƯU TRÚ
-- =====================================================

CREATE TABLE NguoiLuuTru (
    MaNguoiLT INT NOT NULL AUTO_INCREMENT,
    SoPhieuDat VARCHAR(30) NOT NULL,
    SoPhong VARCHAR(20) NOT NULL,
    HoTen VARCHAR(120) NOT NULL,
    SoCMND VARCHAR(30) NOT NULL,
    QuocTich VARCHAR(80) NOT NULL,

    PRIMARY KEY (MaNguoiLT),

    CONSTRAINT FK_NguoiLT_CTDat
        FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 11. DỊCH VỤ
-- =====================================================

CREATE TABLE DichVu (
    MaDV VARCHAR(20) NOT NULL,
    TenDV VARCHAR(120) NOT NULL,
    DonViTinh VARCHAR(40) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,

    PRIMARY KEY (MaDV),

    CONSTRAINT CK_DichVu_DonGia
        CHECK (DonGia >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 12. PHIẾU SỬ DỤNG DỊCH VỤ
-- =====================================================

CREATE TABLE PhieuSuDungDV (
    SoPhieuSDDV VARCHAR(30) NOT NULL,
    SoPhieuDat VARCHAR(30) NOT NULL,
    SoPhong VARCHAR(20) NOT NULL,
    NgaySuDung DATE NOT NULL,
    MaNV VARCHAR(20) NOT NULL,

    PRIMARY KEY (SoPhieuSDDV),

    UNIQUE KEY UQ_PhieuSDDV_PhongNgay
        (SoPhieuDat, SoPhong, NgaySuDung),

    CONSTRAINT FK_PhieuSDDV_CTDat
        FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),

    CONSTRAINT FK_PhieuSDDV_NV
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 13. CHI TIẾT PHIẾU SỬ DỤNG DỊCH VỤ
-- =====================================================

CREATE TABLE ChiTietPhieuSuDungDV (
    SoPhieuSDDV VARCHAR(30) NOT NULL,
    MaDV VARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,

    ThanhTien DECIMAL(18,2)
        GENERATED ALWAYS AS (SoLuong * DonGia) STORED,

    PRIMARY KEY (SoPhieuSDDV, MaDV),

    CONSTRAINT CK_CTSDDV_SoLuong
        CHECK (SoLuong > 0),

    CONSTRAINT CK_CTSDDV_DonGia
        CHECK (DonGia >= 0),

    CONSTRAINT FK_CTSDDV_Phieu
        FOREIGN KEY (SoPhieuSDDV)
        REFERENCES PhieuSuDungDV(SoPhieuSDDV),

    CONSTRAINT FK_CTSDDV_DV
        FOREIGN KEY (MaDV)
        REFERENCES DichVu(MaDV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 14. QUY ĐỊNH ĐỀN BÙ
-- =====================================================

CREATE TABLE QuyDinhDenBu (
    MaQuyDinh VARCHAR(30) NOT NULL,
    MaLoaiTN VARCHAR(20) NOT NULL,
    MucDoThietHai VARCHAR(80) NOT NULL,
    MucDenBu DECIMAL(18,2) NOT NULL,

    PRIMARY KEY (MaQuyDinh),

    UNIQUE KEY UQ_QDDB_Loai_MucDo
        (MaLoaiTN, MucDoThietHai),

    CONSTRAINT CK_QDDB_MucDenBu
        CHECK (MucDenBu >= 0),

    CONSTRAINT FK_QDDB_Loai
        FOREIGN KEY (MaLoaiTN)
        REFERENCES LoaiTienNghi(MaLoaiTN)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 15. PHIẾU ĐỀN BÙ
-- =====================================================

CREATE TABLE PhieuDenBu (
    SoPhieuDenBu VARCHAR(30) NOT NULL,
    SoPhieuDat VARCHAR(30) NOT NULL,
    SoPhong VARCHAR(20) NOT NULL,
    NgayLap DATETIME NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0,

    PRIMARY KEY (SoPhieuDenBu),

    CONSTRAINT CK_PhieuDB_TongTien
        CHECK (TongTien >= 0),

    CONSTRAINT FK_PhieuDB_CTDat
        FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong),

    CONSTRAINT FK_PhieuDB_NV
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 16. CHI TIẾT PHIẾU ĐỀN BÙ
-- =====================================================

CREATE TABLE ChiTietPhieuDenBu (
    SoPhieuDenBu VARCHAR(30) NOT NULL,
    MaTienNghi VARCHAR(30) NOT NULL,
    MucDoThietHai VARCHAR(80) NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL,

    PRIMARY KEY (SoPhieuDenBu, MaTienNghi),

    CONSTRAINT CK_CTDB_SoTien
        CHECK (SoTien >= 0),

    CONSTRAINT FK_CTDB_Phieu
        FOREIGN KEY (SoPhieuDenBu)
        REFERENCES PhieuDenBu(SoPhieuDenBu),

    CONSTRAINT FK_CTDB_TienNghi
        FOREIGN KEY (MaTienNghi)
        REFERENCES TienNghi(MaTienNghi)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 17. HÓA ĐƠN
-- =====================================================

CREATE TABLE HoaDon (
    SoHoaDon VARCHAR(30) NOT NULL,
    SoPhieuDat VARCHAR(30) NOT NULL,
    NgayLap DATETIME NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    SoNgayTinhTien INT NOT NULL,
    TienPhong DECIMAL(18,2) NOT NULL,
    TienDichVu DECIMAL(18,2) NOT NULL,

    TongTien DECIMAL(18,2)
        GENERATED ALWAYS AS (TienPhong + TienDichVu) STORED,

    TrangThai VARCHAR(30) NOT NULL DEFAULT 'Chưa thanh toán',

    PRIMARY KEY (SoHoaDon),

    UNIQUE KEY UQ_HoaDon_PhieuDat (SoPhieuDat),

    CONSTRAINT CK_HoaDon_SoNgay
        CHECK (SoNgayTinhTien > 0),

    CONSTRAINT CK_HoaDon_TienPhong
        CHECK (TienPhong >= 0),

    CONSTRAINT CK_HoaDon_TienDichVu
        CHECK (TienDichVu >= 0),

    CONSTRAINT CK_HoaDon_TrangThai
        CHECK (TrangThai IN ('Chưa thanh toán', 'Đã thanh toán')),

    CONSTRAINT FK_HoaDon_PhieuDat
        FOREIGN KEY (SoPhieuDat)
        REFERENCES PhieuDatPhong(SoPhieuDat),

    CONSTRAINT FK_HoaDon_NV
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- 18. THANH TOÁN
-- =====================================================

CREATE TABLE ThanhToan (
    MaThanhToan VARCHAR(30) NOT NULL,
    SoHoaDon VARCHAR(30) NOT NULL,
    NgayThanhToan DATETIME NOT NULL,
    HinhThuc VARCHAR(30) NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL,

    PRIMARY KEY (MaThanhToan),

    CONSTRAINT CK_ThanhToan_HinhThuc
        CHECK (HinhThuc IN ('Tiền mặt', 'Chuyển khoản', 'Thẻ', 'Ví điện tử')),

    CONSTRAINT CK_ThanhToan_SoTien
        CHECK (SoTien > 0),

    CONSTRAINT FK_ThanhToan_HoaDon
        FOREIGN KEY (SoHoaDon)
        REFERENCES HoaDon(SoHoaDon)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- =====================================================
-- INDEX
-- =====================================================

CREATE INDEX IX_PhieuDatPhong_Ngay
ON PhieuDatPhong(NgayNhan, NgayTraDuKien, TrangThai);

CREATE INDEX IX_CTDat_Phong
ON ChiTietDatPhong(SoPhong, SoPhieuDat);

CREATE INDEX IX_PhieuSDDV_DatPhong
ON PhieuSuDungDV(SoPhieuDat, SoPhong, NgaySuDung);


-- =====================================================
-- DỮ LIỆU MẪU
-- =====================================================

INSERT INTO NhanVien
(MaNV, HoTen, VaiTro, SoDienThoai)
VALUES
('NV01', 'Nguyễn Thu Hà', 'Lễ tân', '0901000001'),
('NV02', 'Trần Minh An', 'Phục vụ phòng', '0901000002'),
('NV03', 'Lê Hoàng Nam', 'Thanh toán', '0901000003');


INSERT INTO KhuVuc
(MaKhuVuc, TenKhuVuc)
VALUES
('A', 'Khu A'),
('B', 'Khu B');


INSERT INTO Phong
(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai)
VALUES
('A101', 'A', 2, 600000, 'Trống'),
('A102', 'A', 3, 800000, 'Trống'),
('B201', 'B', 4, 1200000, 'Trống');


INSERT INTO LoaiTienNghi
(MaLoaiTN, TenLoaiTN)
VALUES
('TV', 'Ti vi'),
('TL', 'Tủ lạnh'),
('DT', 'Điện thoại');


INSERT INTO TienNghi
(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai)
VALUES
('TV01', 'TV', 1, 'Tốt'),
('TV02', 'TV', 2, 'Tốt'),
('TL01', 'TL', 1, 'Tốt');


INSERT INTO DichVu
(MaDV, TenDV, DonViTinh, DonGia)
VALUES
('DV01', 'Ăn sáng', 'Suất', 120000),
('DV02', 'Tắm hơi', 'Lượt', 250000),
('DV03', 'Karaoke', 'Giờ', 300000);


INSERT INTO QuyDinhDenBu
(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu)
VALUES
('QD01', 'TV', 'Hư hỏng nhẹ', 500000),
('QD02', 'TV', 'Mất', 5000000),
('QD03', 'TL', 'Hư hỏng nhẹ', 400000),
('QD04', 'TL', 'Mất', 4000000);