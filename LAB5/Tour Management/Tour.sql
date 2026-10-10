/* =====================================================================
   Lab05 - HỆ THỐNG QUẢN LÝ TOUR DU LỊCH  (MySQL 8.0+)
   Chạy toàn bộ file bằng Ctrl+Shift+Enter trong MySQL Workbench.
   ===================================================================== */

SET NAMES utf8mb4 COLLATE utf8mb4_unicode_ci;

-- Tạo lại database sạch để tránh lỗi do lần chạy dở trước đó
DROP DATABASE IF EXISTS QuanLyTour;
CREATE DATABASE QuanLyTour DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE QuanLyTour;

/* ===================== PHẦN 1: TẠO BẢNG ===================== */

CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhauHash VARBINARY(32) NOT NULL,       -- SHA-256 (32 bytes)
    VaiTro      VARCHAR(50)  NOT NULL
        CHECK (VaiTro IN ('Lễ tân', 'Nhân viên hướng dẫn du lịch', 'Thanh toán', 'Quản lý tour')),
    MaNV        INT NULL
);

CREATE TABLE PhuongTien (
    MaPT  INT AUTO_INCREMENT PRIMARY KEY,
    TenPT VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Tour (
    MaTour   VARCHAR(10)   PRIMARY KEY,
    TenTour  VARCHAR(150)  NOT NULL,
    SoNgay   INT NOT NULL CHECK (SoNgay > 0),
    SoDem    INT NOT NULL CHECK (SoDem >= 0),
    DonGia   DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0),
    LuongHDV DECIMAL(18,0) NOT NULL DEFAULT 0,
    CONSTRAINT CK_Tour_NgayDem CHECK (SoDem BETWEEN SoNgay - 1 AND SoNgay)
);

CREATE TABLE Tour_PhuongTien (
    MaTour VARCHAR(10),
    MaPT   INT,
    PRIMARY KEY (MaTour, MaPT),
    FOREIGN KEY (MaTour) REFERENCES Tour(MaTour) ON DELETE CASCADE,
    FOREIGN KEY (MaPT) REFERENCES PhuongTien(MaPT)
);

CREATE TABLE NoiDungChan (
    MaNoi         INT AUTO_INCREMENT PRIMARY KEY,
    MaTour        VARCHAR(10) NOT NULL,
    TenNoi        VARCHAR(150) NOT NULL,
    DoiPhuongTien TINYINT(1) NOT NULL DEFAULT 0,
    CoNoiAn       TINYINT(1) NOT NULL DEFAULT 0,
    CoKhachSan    TINYINT(1) NOT NULL DEFAULT 0,
    LoaiKhachSan  TINYINT NULL CHECK (LoaiKhachSan BETWEEN 2 AND 5),
    FOREIGN KEY (MaTour) REFERENCES Tour(MaTour) ON DELETE CASCADE,
    CONSTRAINT CK_NDC_KS CHECK ((CoKhachSan = 1 AND LoaiKhachSan IS NOT NULL) OR (CoKhachSan = 0 AND LoaiKhachSan IS NULL))
);

CREATE TABLE DiemThamQuan (
    MaDiem  VARCHAR(10) PRIMARY KEY,
    TenDiem VARCHAR(150) NOT NULL,
    DiaDiem VARCHAR(200) NOT NULL,
    NoiDung VARCHAR(500) NULL,
    YNghia  VARCHAR(500) NULL
);

CREATE TABLE Tour_DiemThamQuan (
    MaTour VARCHAR(10),
    MaDiem VARCHAR(10),
    PRIMARY KEY (MaTour, MaDiem),
    FOREIGN KEY (MaTour) REFERENCES Tour(MaTour) ON DELETE CASCADE,
    FOREIGN KEY (MaDiem) REFERENCES DiemThamQuan(MaDiem) ON DELETE CASCADE
);

CREATE TABLE NhanVien (
    MaNV       INT AUTO_INCREMENT PRIMARY KEY,
    HoTen      VARCHAR(100) NOT NULL,
    DienThoai  VARCHAR(15) NULL,
    LuongCoBan DECIMAL(18,0) NOT NULL DEFAULT 0
);

ALTER TABLE TaiKhoan ADD CONSTRAINT FK_TK_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV);

CREATE TABLE ChuyenDi (
    MaChuyen  VARCHAR(15) PRIMARY KEY,
    MaTour    VARCHAR(10) NOT NULL,
    NgayDi    DATE NOT NULL,
    NgayVe    DATE NOT NULL,
    TinhTrang VARCHAR(30) NOT NULL DEFAULT 'Chưa khởi hành'
        CHECK (TinhTrang IN ('Chưa khởi hành', 'Đang diễn ra', 'Đã kết thúc', 'Đã hủy')),
    FOREIGN KEY (MaTour) REFERENCES Tour(MaTour),
    CONSTRAINT CK_Chuyen_Ngay CHECK (NgayVe >= NgayDi)
);

CREATE TABLE DiemBanVe (
    MaDiemBan INT AUTO_INCREMENT PRIMARY KEY,
    TenDiem   VARCHAR(100) NOT NULL,
    DiaChi    VARCHAR(200) NULL
);

CREATE TABLE KhachLe (
    MaKhach  INT AUTO_INCREMENT PRIMARY KEY,
    TenKhach VARCHAR(100) NOT NULL,
    CCCD     VARCHAR(20) NOT NULL UNIQUE,
    DiaChi   VARCHAR(200) NULL,
    QuocTich VARCHAR(50) NOT NULL DEFAULT 'Việt Nam'
);

CREATE TABLE DangKyKhachLe (
    MaDK       INT AUTO_INCREMENT PRIMARY KEY,
    MaChuyen   VARCHAR(15) NOT NULL,
    MaKhach    INT NOT NULL,
    MaDiemBan  INT NULL,
    DiemDon    VARCHAR(200) NULL,
    SoTien     DECIMAL(18,0) NOT NULL CHECK (SoTien >= 0),
    NgayDangKy DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaChuyen) REFERENCES ChuyenDi(MaChuyen),
    FOREIGN KEY (MaKhach) REFERENCES KhachLe(MaKhach),
    FOREIGN KEY (MaDiemBan) REFERENCES DiemBanVe(MaDiemBan),
    CONSTRAINT UQ_DKLe UNIQUE (MaChuyen, MaKhach)
);

CREATE TABLE DoanKhach (
    MaDoan         INT AUTO_INCREMENT PRIMARY KEY,
    TenCoQuan      VARCHAR(150) NOT NULL,
    DiaChi         VARCHAR(200) NOT NULL,
    DienThoai      VARCHAR(15)  NOT NULL,
    NguoiDaiDien   VARCHAR(100) NOT NULL,
    MaTour         VARCHAR(10) NOT NULL,
    NgayDi         DATE NOT NULL,
    NgayVe         DATE NOT NULL,
    SoNguoi        INT  NOT NULL CHECK (SoNguoi > 12),
    DiaDiemDon     VARCHAR(200) NULL,
    CoBaoHiem      TINYINT(1) NOT NULL DEFAULT 0,
    SoNguoiBaoHiem INT NOT NULL DEFAULT 0,
    TienDatCoc     DECIMAL(18,0) NOT NULL CHECK (TienDatCoc > 0),
    TrangThai      VARCHAR(30) NOT NULL DEFAULT 'Đã đặt cọc'
        CHECK (TrangThai IN ('Đã đặt cọc', 'Đã hủy (mất cọc)', 'Đã kết thúc', 'Đã quyết toán')),
    FOREIGN KEY (MaTour) REFERENCES Tour(MaTour),
    CONSTRAINT CK_Doan_Ngay CHECK (NgayVe >= NgayDi),
    CONSTRAINT CK_Doan_BH   CHECK (SoNguoiBaoHiem <= SoNguoi AND (CoBaoHiem = 1 OR SoNguoiBaoHiem = 0))
);

CREATE TABLE NguoiDiDoan (
    MaNguoi    INT AUTO_INCREMENT PRIMARY KEY,
    MaDoan     INT NOT NULL,
    HoTen      VARCHAR(100) NOT NULL,
    CCCD       VARCHAR(20) NULL,
    MuaBaoHiem TINYINT(1) NOT NULL DEFAULT 0,
    FOREIGN KEY (MaDoan) REFERENCES DoanKhach(MaDoan) ON DELETE CASCADE
);

CREATE TABLE PhanCong (
    MaPC     INT AUTO_INCREMENT PRIMARY KEY,
    MaNV     INT NOT NULL,
    MaChuyen VARCHAR(15) NULL,
    MaDoan   INT NULL,
    TuNgay   DATE NOT NULL,
    DenNgay  DATE NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaChuyen) REFERENCES ChuyenDi(MaChuyen),
    FOREIGN KEY (MaDoan) REFERENCES DoanKhach(MaDoan),
    CONSTRAINT CK_PC_Ngay CHECK (DenNgay >= TuNgay),
    CONSTRAINT CK_PC_Loai CHECK ((MaChuyen IS NOT NULL AND MaDoan IS NULL) OR (MaChuyen IS NULL AND MaDoan IS NOT NULL))
);

CREATE UNIQUE INDEX UX_PhanCong_Chuyen ON PhanCong(MaChuyen);

CREATE TABLE HoaDon (
    MaHD          INT AUTO_INCREMENT PRIMARY KEY,
    SoHoaDon      VARCHAR(20) NOT NULL UNIQUE,
    LoaiTour      VARCHAR(20) NOT NULL CHECK (LoaiTour IN ('Khách lẻ', 'Khách đoàn')),
    MaDK          INT NULL,
    MaDoan        INT NULL,
    SoKhach       INT NOT NULL CHECK (SoKhach > 0),
    TongTien      DECIMAL(18,0) NOT NULL,
    DaDatCoc      DECIMAL(18,0) NOT NULL DEFAULT 0,
    SoTienThu     DECIMAL(18,0) NOT NULL,
    PhuongThuc    VARCHAR(30) NOT NULL CHECK (PhuongThuc IN ('Tiền mặt', 'Chuyển khoản', 'Thẻ')),
    NgayThanhToan DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TrangThai     VARCHAR(30) NOT NULL DEFAULT 'Đã thanh toán',
    FOREIGN KEY (MaDK) REFERENCES DangKyKhachLe(MaDK),
    FOREIGN KEY (MaDoan) REFERENCES DoanKhach(MaDoan),
    CONSTRAINT CK_HD_Loai CHECK ((LoaiTour = 'Khách lẻ' AND MaDK IS NOT NULL AND MaDoan IS NULL)
                              OR (LoaiTour = 'Khách đoàn' AND MaDoan IS NOT NULL AND MaDK IS NULL))
);

CREATE TABLE BangLuong (
    MaNV          INT NOT NULL,
    Thang         TINYINT NOT NULL CHECK (Thang BETWEEN 1 AND 12),
    Nam           SMALLINT NOT NULL,
    LuongCoBan    DECIMAL(18,0) NOT NULL,
    SoTour        INT NOT NULL,
    LuongTheoTour DECIMAL(18,0) NOT NULL,
    TongLuong     DECIMAL(18,0) GENERATED ALWAYS AS (LuongCoBan + LuongTheoTour) STORED,
    PRIMARY KEY (MaNV, Thang, Nam),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE KhaoSat (
    MaKS        INT AUTO_INCREMENT PRIMARY KEY,
    MaChuyen    VARCHAR(15) NULL,
    MaDoan      INT NULL,
    TenKhach    VARCHAR(100) NOT NULL,
    DiemDanhGia TINYINT NOT NULL CHECK (DiemDanhGia BETWEEN 1 AND 5),
    GopY        VARCHAR(1000) NULL,
    NgayKhaoSat DATE NOT NULL DEFAULT (CURRENT_DATE),
    FOREIGN KEY (MaChuyen) REFERENCES ChuyenDi(MaChuyen),
    FOREIGN KEY (MaDoan) REFERENCES DoanKhach(MaDoan),
    CONSTRAINT CK_KS_Loai CHECK ((MaChuyen IS NOT NULL AND MaDoan IS NULL) OR (MaChuyen IS NULL AND MaDoan IS NOT NULL))
);

CREATE TABLE DenBu (
    MaDB        INT AUTO_INCREMENT PRIMARY KEY,
    MaChuyen    VARCHAR(15) NULL,
    MaDoan      INT NULL,
    DichVu      VARCHAR(100) NOT NULL,
    MoTa        VARCHAR(500) NULL,
    MucDo       VARCHAR(20) NOT NULL CHECK (MucDo IN ('Nhẹ', 'Trung bình', 'Nặng')),
    SoTienDenBu DECIMAL(18,0) NOT NULL CHECK (SoTienDenBu >= 0),
    NgayLap     DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (MaChuyen) REFERENCES ChuyenDi(MaChuyen),
    FOREIGN KEY (MaDoan) REFERENCES DoanKhach(MaDoan),
    CONSTRAINT CK_DB_Loai CHECK ((MaChuyen IS NOT NULL AND MaDoan IS NULL) OR (MaChuyen IS NULL AND MaDoan IS NOT NULL))
);

/* ===================== PHẦN 2: VIEW ===================== */
-- Đã sửa lỗi 1271 (Illegal mix of collations for operation 'UNION'):
-- ép collation rõ ràng cho các cột chuỗi ở cả hai nhánh UNION.

CREATE OR REPLACE VIEW vw_LichTrinh AS
SELECT CAST('Khách lẻ' AS CHAR(20)) COLLATE utf8mb4_unicode_ci AS Loai,
       c.MaChuyen                  COLLATE utf8mb4_unicode_ci AS Ma,
       CAST(NULL AS SIGNED)                                   AS MaDoan,
       c.MaChuyen                  COLLATE utf8mb4_unicode_ci AS MaChuyen,
       c.MaTour                    COLLATE utf8mb4_unicode_ci AS MaTour,
       c.NgayDi, c.NgayVe
FROM ChuyenDi c WHERE c.TinhTrang <> 'Đã hủy'
UNION ALL
SELECT CAST('Khách đoàn' AS CHAR(20)) COLLATE utf8mb4_unicode_ci,
       CAST(d.MaDoan AS CHAR(15))      COLLATE utf8mb4_unicode_ci,
       d.MaDoan,
       CAST(NULL AS CHAR(15))          COLLATE utf8mb4_unicode_ci,
       d.MaTour                        COLLATE utf8mb4_unicode_ci,
       d.NgayDi, d.NgayVe
FROM DoanKhach d WHERE d.TrangThai <> 'Đã hủy (mất cọc)';

/* ===================== PHẦN 3: STORED PROCEDURE ===================== */

DELIMITER //

/* ---- FrmLogin ---- */
DROP PROCEDURE IF EXISTS sp_DangNhap //
CREATE PROCEDURE sp_DangNhap(
    IN p_TenDangNhap VARCHAR(50),
    IN p_MatKhau VARCHAR(100),
    IN p_VaiTro VARCHAR(50)
)
BEGIN
    SELECT TenDangNhap, VaiTro, MaNV FROM TaiKhoan
    WHERE TenDangNhap = p_TenDangNhap
      AND MatKhauHash = UNHEX(SHA2(p_MatKhau, 256))
      AND VaiTro = p_VaiTro;
END //

/* ---- FrmTour ---- */
DROP PROCEDURE IF EXISTS sp_Tour_DanhSach //
CREATE PROCEDURE sp_Tour_DanhSach()
BEGIN
    SELECT t.MaTour, t.TenTour, t.SoNgay, t.SoDem, t.DonGia,
           GROUP_CONCAT(p.TenPT SEPARATOR ', ') AS PhuongTien
    FROM Tour t
    LEFT JOIN Tour_PhuongTien tp ON tp.MaTour = t.MaTour
    LEFT JOIN PhuongTien p ON p.MaPT = tp.MaPT
    GROUP BY t.MaTour, t.TenTour, t.SoNgay, t.SoDem, t.DonGia
    ORDER BY t.MaTour;
END //

DROP PROCEDURE IF EXISTS sp_Tour_Them //
CREATE PROCEDURE sp_Tour_Them(
    IN p_MaTour VARCHAR(10),
    IN p_TenTour VARCHAR(150),
    IN p_SoNgay INT,
    IN p_SoDem INT,
    IN p_DonGia DECIMAL(18,0),
    IN p_MaPT INT
)
BEGIN
    START TRANSACTION;
    INSERT INTO Tour(MaTour, TenTour, SoNgay, SoDem, DonGia) VALUES (p_MaTour, p_TenTour, p_SoNgay, p_SoDem, p_DonGia);
    IF p_MaPT IS NOT NULL THEN
        INSERT INTO Tour_PhuongTien(MaTour, MaPT) VALUES (p_MaTour, p_MaPT);
    END IF;
    COMMIT;
END //

DROP PROCEDURE IF EXISTS sp_Tour_Sua //
CREATE PROCEDURE sp_Tour_Sua(
    IN p_MaTour VARCHAR(10),
    IN p_TenTour VARCHAR(150),
    IN p_SoNgay INT,
    IN p_SoDem INT,
    IN p_DonGia DECIMAL(18,0),
    IN p_MaPT INT
)
BEGIN
    START TRANSACTION;
    UPDATE Tour SET TenTour=p_TenTour, SoNgay=p_SoNgay, SoDem=p_SoDem, DonGia=p_DonGia WHERE MaTour=p_MaTour;
    DELETE FROM Tour_PhuongTien WHERE MaTour=p_MaTour;
    IF p_MaPT IS NOT NULL THEN
        INSERT INTO Tour_PhuongTien(MaTour, MaPT) VALUES (p_MaTour, p_MaPT);
    END IF;
    COMMIT;
END //

DROP PROCEDURE IF EXISTS sp_Tour_Xoa //
CREATE PROCEDURE sp_Tour_Xoa(IN p_MaTour VARCHAR(10))
BEGIN
    IF EXISTS (SELECT 1 FROM ChuyenDi WHERE MaTour=p_MaTour) OR EXISTS (SELECT 1 FROM DoanKhach WHERE MaTour=p_MaTour) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Tour đã có chuyến/đoàn đăng ký, không thể xóa.';
    ELSE
        DELETE FROM Tour WHERE MaTour=p_MaTour;
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_Tour_TimKiem //
CREATE PROCEDURE sp_Tour_TimKiem(IN p_TuKhoa VARCHAR(150))
BEGIN
    SELECT * FROM Tour WHERE MaTour LIKE CONCAT('%', p_TuKhoa, '%') OR TenTour LIKE CONCAT('%', p_TuKhoa, '%');
END //

/* ---- FrmNoiDungChan ---- */
DROP PROCEDURE IF EXISTS sp_NoiDungChan_DanhSach //
CREATE PROCEDURE sp_NoiDungChan_DanhSach(IN p_MaTour VARCHAR(10))
BEGIN
    SELECT n.MaNoi, n.MaTour, n.TenNoi, n.DoiPhuongTien, n.CoNoiAn, n.CoKhachSan, n.LoaiKhachSan
    FROM NoiDungChan n WHERE p_MaTour IS NULL OR n.MaTour = p_MaTour;
END //

DROP PROCEDURE IF EXISTS sp_NoiDungChan_Them //
CREATE PROCEDURE sp_NoiDungChan_Them(
    IN p_MaTour VARCHAR(10),
    IN p_TenNoi VARCHAR(150),
    IN p_DoiPT TINYINT(1),
    IN p_CoAn TINYINT(1),
    IN p_CoKS TINYINT(1),
    IN p_LoaiKS TINYINT
)
BEGIN
    INSERT INTO NoiDungChan(MaTour, TenNoi, DoiPhuongTien, CoNoiAn, CoKhachSan, LoaiKhachSan)
    VALUES (p_MaTour, p_TenNoi, p_DoiPT, p_CoAn, p_CoKS, IF(p_CoKS=1, p_LoaiKS, NULL));
END //

DROP PROCEDURE IF EXISTS sp_NoiDungChan_Sua //
CREATE PROCEDURE sp_NoiDungChan_Sua(
    IN p_MaNoi INT,
    IN p_TenNoi VARCHAR(150),
    IN p_DoiPT TINYINT(1),
    IN p_CoAn TINYINT(1),
    IN p_CoKS TINYINT(1),
    IN p_LoaiKS TINYINT
)
BEGIN
    UPDATE NoiDungChan
    SET TenNoi=p_TenNoi, DoiPhuongTien=p_DoiPT, CoNoiAn=p_CoAn, CoKhachSan=p_CoKS,
        LoaiKhachSan = IF(p_CoKS=1, p_LoaiKS, NULL)
    WHERE MaNoi=p_MaNoi;
END //

DROP PROCEDURE IF EXISTS sp_NoiDungChan_Xoa //
CREATE PROCEDURE sp_NoiDungChan_Xoa(IN p_MaNoi INT)
BEGIN
    DELETE FROM NoiDungChan WHERE MaNoi=p_MaNoi;
END //

/* ---- FrmDiemThamQuan ---- */
DROP PROCEDURE IF EXISTS sp_Diem_DanhSach //
CREATE PROCEDURE sp_Diem_DanhSach()
BEGIN
    SELECT d.MaDiem, d.TenDiem, d.DiaDiem, d.NoiDung, d.YNghia,
           GROUP_CONCAT(t.TenTour SEPARATOR ', ') AS CacTour
    FROM DiemThamQuan d
    LEFT JOIN Tour_DiemThamQuan x ON x.MaDiem = d.MaDiem
    LEFT JOIN Tour t ON t.MaTour = x.MaTour
    GROUP BY d.MaDiem, d.TenDiem, d.DiaDiem, d.NoiDung, d.YNghia;
END //

DROP PROCEDURE IF EXISTS sp_Diem_Them //
CREATE PROCEDURE sp_Diem_Them(
    IN p_MaDiem VARCHAR(10),
    IN p_TenDiem VARCHAR(150),
    IN p_DiaDiem VARCHAR(200),
    IN p_NoiDung VARCHAR(500),
    IN p_YNghia VARCHAR(500),
    IN p_MaTour VARCHAR(10)
)
BEGIN
    START TRANSACTION;
    INSERT INTO DiemThamQuan VALUES (p_MaDiem, p_TenDiem, p_DiaDiem, p_NoiDung, p_YNghia);
    IF p_MaTour IS NOT NULL THEN
        INSERT INTO Tour_DiemThamQuan VALUES (p_MaTour, p_MaDiem);
    END IF;
    COMMIT;
END //

DROP PROCEDURE IF EXISTS sp_Diem_Sua //
CREATE PROCEDURE sp_Diem_Sua(
    IN p_MaDiem VARCHAR(10),
    IN p_TenDiem VARCHAR(150),
    IN p_DiaDiem VARCHAR(200),
    IN p_NoiDung VARCHAR(500),
    IN p_YNghia VARCHAR(500),
    IN p_MaTour VARCHAR(10)
)
BEGIN
    START TRANSACTION;
    UPDATE DiemThamQuan SET TenDiem=p_TenDiem, DiaDiem=p_DiaDiem, NoiDung=p_NoiDung, YNghia=p_YNghia WHERE MaDiem=p_MaDiem;
    IF p_MaTour IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Tour_DiemThamQuan WHERE MaTour=p_MaTour AND MaDiem=p_MaDiem) THEN
        INSERT INTO Tour_DiemThamQuan VALUES (p_MaTour, p_MaDiem);
    END IF;
    COMMIT;
END //

DROP PROCEDURE IF EXISTS sp_Diem_Xoa //
CREATE PROCEDURE sp_Diem_Xoa(IN p_MaDiem VARCHAR(10))
BEGIN
    DELETE FROM DiemThamQuan WHERE MaDiem=p_MaDiem;
END //

/* ---- FrmChuyen ---- */
DROP PROCEDURE IF EXISTS sp_Chuyen_DanhSach //
CREATE PROCEDURE sp_Chuyen_DanhSach()
BEGIN
    SELECT c.MaChuyen, c.MaTour, t.TenTour, c.NgayDi, c.NgayVe, c.TinhTrang,
           (SELECT COUNT(*) FROM DangKyKhachLe d WHERE d.MaChuyen=c.MaChuyen) AS SoKhach
    FROM ChuyenDi c JOIN Tour t ON t.MaTour=c.MaTour ORDER BY c.NgayDi DESC;
END //

DROP PROCEDURE IF EXISTS sp_Chuyen_Them //
CREATE PROCEDURE sp_Chuyen_Them(
    IN p_MaChuyen VARCHAR(15),
    IN p_MaTour VARCHAR(10),
    IN p_NgayDi DATE,
    IN p_NgayVe DATE,
    IN p_TinhTrang VARCHAR(30)
)
BEGIN
    INSERT INTO ChuyenDi(MaChuyen, MaTour, NgayDi, NgayVe, TinhTrang)
    VALUES (p_MaChuyen, p_MaTour, p_NgayDi, p_NgayVe, p_TinhTrang);
END //

DROP PROCEDURE IF EXISTS sp_Chuyen_Sua //
CREATE PROCEDURE sp_Chuyen_Sua(
    IN p_MaChuyen VARCHAR(15),
    IN p_MaTour VARCHAR(10),
    IN p_NgayDi DATE,
    IN p_NgayVe DATE,
    IN p_TinhTrang VARCHAR(30)
)
BEGIN
    UPDATE ChuyenDi SET MaTour=p_MaTour, NgayDi=p_NgayDi, NgayVe=p_NgayVe, TinhTrang=p_TinhTrang WHERE MaChuyen=p_MaChuyen;
END //

DROP PROCEDURE IF EXISTS sp_Chuyen_Xoa //
CREATE PROCEDURE sp_Chuyen_Xoa(IN p_MaChuyen VARCHAR(15))
BEGIN
    IF EXISTS (SELECT 1 FROM DangKyKhachLe WHERE MaChuyen=p_MaChuyen) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Chuyến đã có khách đăng ký, hãy chuyển sang trạng thái "Đã hủy".';
    ELSE
        DELETE FROM ChuyenDi WHERE MaChuyen=p_MaChuyen;
    END IF;
END //

/* ---- FrmDangKyKhachLe ---- */
DROP PROCEDURE IF EXISTS sp_DKLe_Them //
CREATE PROCEDURE sp_DKLe_Them(
    IN p_TenKhach VARCHAR(100),
    IN p_CCCD VARCHAR(20),
    IN p_DiaChi VARCHAR(200),
    IN p_QuocTich VARCHAR(50),
    IN p_MaChuyen VARCHAR(15),
    IN p_MaDiemBan INT,
    IN p_DiemDon VARCHAR(200),
    IN p_SoTien DECIMAL(18,0)
)
BEGIN
    DECLARE v_MaKhach INT DEFAULT NULL;

    START TRANSACTION;
    IF NOT EXISTS (SELECT 1 FROM ChuyenDi WHERE MaChuyen=p_MaChuyen AND TinhTrang='Chưa khởi hành') THEN
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Chuyến không tồn tại hoặc không còn nhận đăng ký.';
    ELSE
        SELECT MaKhach INTO v_MaKhach FROM KhachLe WHERE CCCD=p_CCCD LIMIT 1;

        IF v_MaKhach IS NULL THEN
            INSERT INTO KhachLe(TenKhach, CCCD, DiaChi, QuocTich) VALUES (p_TenKhach, p_CCCD, p_DiaChi, p_QuocTich);
            SET v_MaKhach = LAST_INSERT_ID();
        END IF;

        IF EXISTS (SELECT 1 FROM DangKyKhachLe WHERE MaChuyen=p_MaChuyen AND MaKhach=v_MaKhach) THEN
            ROLLBACK;
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Khách đã đăng ký chuyến này.';
        ELSE
            INSERT INTO DangKyKhachLe(MaChuyen, MaKhach, MaDiemBan, DiemDon, SoTien)
            VALUES (p_MaChuyen, v_MaKhach, p_MaDiemBan, p_DiemDon, p_SoTien);
            COMMIT;
        END IF;
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_DKLe_DanhSach //
CREATE PROCEDURE sp_DKLe_DanhSach(
    IN p_MaChuyen VARCHAR(15),
    IN p_TuKhoa VARCHAR(100)
)
BEGIN
    SELECT d.MaDK, k.TenKhach, k.CCCD, k.QuocTich, d.MaChuyen, c.NgayDi, c.NgayVe, b.TenDiem AS DiemBanVe, d.DiemDon, d.SoTien
    FROM DangKyKhachLe d
    JOIN KhachLe k ON k.MaKhach=d.MaKhach
    JOIN ChuyenDi c ON c.MaChuyen=d.MaChuyen
    LEFT JOIN DiemBanVe b ON b.MaDiemBan=d.MaDiemBan
    WHERE (p_MaChuyen IS NULL OR d.MaChuyen=p_MaChuyen)
      AND (p_TuKhoa IS NULL OR k.TenKhach LIKE CONCAT('%', p_TuKhoa, '%') OR k.CCCD LIKE CONCAT('%', p_TuKhoa, '%'));
END //

/* ---- FrmDangKyDoan ---- */
DROP PROCEDURE IF EXISTS sp_Doan_Them //
CREATE PROCEDURE sp_Doan_Them(
    IN p_TenCoQuan VARCHAR(150),
    IN p_DiaChi VARCHAR(200),
    IN p_DienThoai VARCHAR(15),
    IN p_NguoiDaiDien VARCHAR(100),
    IN p_MaTour VARCHAR(10),
    IN p_NgayDi DATE,
    IN p_SoNguoi INT,
    IN p_DiaDiemDon VARCHAR(200),
    IN p_CoBaoHiem TINYINT(1),
    IN p_SoNguoiBaoHiem INT,
    IN p_TienDatCoc DECIMAL(18,0)
)
BEGIN
    DECLARE v_SoNgay INT DEFAULT NULL;
    DECLARE v_NgayVe DATE;

    SELECT SoNgay INTO v_SoNgay FROM Tour WHERE MaTour=p_MaTour;
    IF v_SoNgay IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Tour không tồn tại.';
    ELSE
        SET v_NgayVe = DATE_ADD(p_NgayDi, INTERVAL (v_SoNgay - 1) DAY);
        INSERT INTO DoanKhach(TenCoQuan, DiaChi, DienThoai, NguoiDaiDien, MaTour, NgayDi, NgayVe, SoNguoi, DiaDiemDon, CoBaoHiem, SoNguoiBaoHiem, TienDatCoc)
        VALUES (p_TenCoQuan, p_DiaChi, p_DienThoai, p_NguoiDaiDien, p_MaTour, p_NgayDi, v_NgayVe, p_SoNguoi, p_DiaDiemDon, p_CoBaoHiem, p_SoNguoiBaoHiem, p_TienDatCoc);

        SELECT LAST_INSERT_ID() AS MaDoan;
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_Doan_ThemNguoiDi //
CREATE PROCEDURE sp_Doan_ThemNguoiDi(
    IN p_MaDoan INT,
    IN p_HoTen VARCHAR(100),
    IN p_CCCD VARCHAR(20),
    IN p_MuaBaoHiem TINYINT(1)
)
BEGIN
    INSERT INTO NguoiDiDoan(MaDoan, HoTen, CCCD, MuaBaoHiem) VALUES (p_MaDoan, p_HoTen, p_CCCD, p_MuaBaoHiem);
END //

DROP PROCEDURE IF EXISTS sp_Doan_DanhSach //
CREATE PROCEDURE sp_Doan_DanhSach()
BEGIN
    SELECT d.MaDoan, d.TenCoQuan, d.NguoiDaiDien, d.DienThoai, t.TenTour, d.NgayDi, d.NgayVe, d.SoNguoi, d.TienDatCoc, d.TrangThai
    FROM DoanKhach d JOIN Tour t ON t.MaTour=d.MaTour ORDER BY d.NgayDi DESC;
END //

DROP PROCEDURE IF EXISTS sp_Doan_Huy //
CREATE PROCEDURE sp_Doan_Huy(IN p_MaDoan INT)
BEGIN
    UPDATE DoanKhach SET TrangThai='Đã hủy (mất cọc)' WHERE MaDoan=p_MaDoan AND TrangThai='Đã đặt cọc';
END //

/* ---- FrmPhanCongHDV ---- */
DROP PROCEDURE IF EXISTS sp_PhanCong_Them //
CREATE PROCEDURE sp_PhanCong_Them(
    IN p_MaNV INT,
    IN p_MaChuyen VARCHAR(15),
    IN p_MaDoan INT,
    IN p_TuNgay DATE,
    IN p_DenNgay DATE
)
BEGIN
    START TRANSACTION;
    IF (p_MaChuyen IS NULL AND p_MaDoan IS NULL) OR (p_MaChuyen IS NOT NULL AND p_MaDoan IS NOT NULL) THEN
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Chọn chuyến khách lẻ hoặc đoàn.';
    ELSEIF EXISTS (SELECT 1 FROM PhanCong WHERE MaNV=p_MaNV AND TuNgay<=p_DenNgay AND DenNgay>=p_TuNgay) THEN
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Hướng dẫn viên đã có lịch trùng trong khoảng thời gian này.';
    ELSEIF p_MaChuyen IS NOT NULL AND EXISTS (SELECT 1 FROM PhanCong WHERE MaChuyen=p_MaChuyen) THEN
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Chuyến khách lẻ đã được phân công một hướng dẫn viên.';
    ELSE
        INSERT INTO PhanCong(MaNV, MaChuyen, MaDoan, TuNgay, DenNgay) VALUES (p_MaNV, p_MaChuyen, p_MaDoan, p_TuNgay, p_DenNgay);
        COMMIT;
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_PhanCong_Huy //
CREATE PROCEDURE sp_PhanCong_Huy(IN p_MaPC INT)
BEGIN
    DELETE FROM PhanCong WHERE MaPC=p_MaPC;
END //

DROP PROCEDURE IF EXISTS sp_PhanCong_DanhSach //
CREATE PROCEDURE sp_PhanCong_DanhSach(IN p_MaNV INT)
BEGIN
    SELECT p.MaPC, n.HoTen, p.MaChuyen, p.MaDoan, p.TuNgay, p.DenNgay
    FROM PhanCong p JOIN NhanVien n ON n.MaNV=p.MaNV WHERE p_MaNV IS NULL OR p.MaNV=p_MaNV ORDER BY p.TuNgay;
END //

/* ---- FrmThanhToanVe ---- */
DROP PROCEDURE IF EXISTS sp_TinhTien //
CREATE PROCEDURE sp_TinhTien(
    IN p_LoaiTour VARCHAR(20),
    IN p_Ma INT
)
BEGIN
    IF p_LoaiTour = 'Khách lẻ' THEN
        SELECT 1 AS SoKhach, d.SoTien AS TongTien, CAST(0 AS DECIMAL(18,0)) AS DaDatCoc
        FROM DangKyKhachLe d WHERE d.MaDK=p_Ma;
    ELSE
        SELECT d.SoNguoi AS SoKhach, d.SoNguoi * t.DonGia AS TongTien, d.TienDatCoc AS DaDatCoc
        FROM DoanKhach d JOIN Tour t ON t.MaTour=d.MaTour WHERE d.MaDoan=p_Ma;
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_ThanhToan //
CREATE PROCEDURE sp_ThanhToan(
    IN p_SoHoaDon VARCHAR(20),
    IN p_LoaiTour VARCHAR(20),
    IN p_Ma INT,
    IN p_SoTienThu DECIMAL(18,0),
    IN p_PhuongThuc VARCHAR(30)
)
BEGIN
    DECLARE v_SoKhach INT DEFAULT NULL;
    DECLARE v_Tong DECIMAL(18,0) DEFAULT NULL;
    DECLARE v_Coc DECIMAL(18,0) DEFAULT 0;
    DECLARE v_CanThu DECIMAL(18,0);
    DECLARE v_NgayVe DATE DEFAULT NULL;

    START TRANSACTION;

    IF p_LoaiTour = 'Khách lẻ' THEN
        SELECT 1, d.SoTien, 0 INTO v_SoKhach, v_Tong, v_Coc
        FROM DangKyKhachLe d WHERE d.MaDK=p_Ma;
    ELSE
        SELECT d.SoNguoi, d.SoNguoi * t.DonGia, d.TienDatCoc, d.NgayVe INTO v_SoKhach, v_Tong, v_Coc, v_NgayVe
        FROM DoanKhach d JOIN Tour t ON t.MaTour=d.MaTour WHERE d.MaDoan=p_Ma;
    END IF;

    IF v_Tong IS NULL THEN
        ROLLBACK;
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Không tìm thấy phiếu đăng ký.';
    ELSE
        SET v_CanThu = IF(p_LoaiTour = 'Khách đoàn', v_Tong - v_Coc, v_Tong);

        IF p_SoTienThu < v_CanThu THEN
            ROLLBACK;
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Số tiền thanh toán chưa đủ.';
        ELSEIF p_LoaiTour = 'Khách đoàn' AND (v_NgayVe IS NULL OR v_NgayVe > CURDATE()) THEN
            ROLLBACK;
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Khách đoàn chỉ quyết toán sau khi kết thúc chuyến đi.';
        ELSE
            INSERT INTO HoaDon(SoHoaDon, LoaiTour, MaDK, MaDoan, SoKhach, TongTien, DaDatCoc, SoTienThu, PhuongThuc)
            VALUES (
                p_SoHoaDon, p_LoaiTour,
                IF(p_LoaiTour='Khách lẻ', p_Ma, NULL),
                IF(p_LoaiTour='Khách đoàn', p_Ma, NULL),
                v_SoKhach, v_Tong, v_Coc, p_SoTienThu, p_PhuongThuc
            );

            IF p_LoaiTour = 'Khách đoàn' THEN
                UPDATE DoanKhach SET TrangThai='Đã quyết toán' WHERE MaDoan=p_Ma;
            END IF;

            COMMIT;
        END IF;
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_HoaDon_BienNhan //
CREATE PROCEDURE sp_HoaDon_BienNhan(IN p_SoHoaDon VARCHAR(20))
BEGIN
    SELECT * FROM HoaDon WHERE SoHoaDon=p_SoHoaDon;
END //

/* ---- FrmLuong ---- */
DROP PROCEDURE IF EXISTS sp_Luong_Tinh //
CREATE PROCEDURE sp_Luong_Tinh(
    IN p_MaNV INT,
    IN p_Thang TINYINT,
    IN p_Nam SMALLINT
)
BEGIN
    DECLARE v_Dau DATE;
    DECLARE v_Cuoi DATE;

    SET v_Dau = STR_TO_DATE(CONCAT(p_Nam, '-', p_Thang, '-01'), '%Y-%m-%d');
    SET v_Cuoi = LAST_DAY(v_Dau);

    SELECT n.LuongCoBan,
           COUNT(l.Ma) AS SoTour,
           IFNULL(SUM(t.LuongHDV), 0) AS LuongTheoTour,
           n.LuongCoBan + IFNULL(SUM(t.LuongHDV), 0) AS TongLuong
    FROM NhanVien n
    LEFT JOIN PhanCong p ON p.MaNV=n.MaNV
    LEFT JOIN vw_LichTrinh l ON ((p.MaChuyen IS NOT NULL AND l.MaChuyen=p.MaChuyen) OR (p.MaDoan IS NOT NULL AND l.MaDoan=p.MaDoan))
                             AND l.NgayVe BETWEEN v_Dau AND v_Cuoi
    LEFT JOIN Tour t ON t.MaTour=l.MaTour
    WHERE n.MaNV=p_MaNV
    GROUP BY n.MaNV, n.LuongCoBan;
END //

DROP PROCEDURE IF EXISTS sp_Luong_Luu //
CREATE PROCEDURE sp_Luong_Luu(
    IN p_MaNV INT,
    IN p_Thang TINYINT,
    IN p_Nam SMALLINT
)
BEGIN
    DECLARE v_Dau DATE;
    DECLARE v_Cuoi DATE;
    DECLARE v_LuongCoBan DECIMAL(18,0) DEFAULT NULL;
    DECLARE v_SoTour INT DEFAULT 0;
    DECLARE v_LuongTheoTour DECIMAL(18,0) DEFAULT 0;

    SET v_Dau = STR_TO_DATE(CONCAT(p_Nam, '-', p_Thang, '-01'), '%Y-%m-%d');
    SET v_Cuoi = LAST_DAY(v_Dau);

    SELECT n.LuongCoBan, COUNT(l.Ma), IFNULL(SUM(t.LuongHDV), 0)
    INTO v_LuongCoBan, v_SoTour, v_LuongTheoTour
    FROM NhanVien n
    LEFT JOIN PhanCong p ON p.MaNV=n.MaNV
    LEFT JOIN vw_LichTrinh l ON ((p.MaChuyen IS NOT NULL AND l.MaChuyen=p.MaChuyen) OR (p.MaDoan IS NOT NULL AND l.MaDoan=p.MaDoan))
                             AND l.NgayVe BETWEEN v_Dau AND v_Cuoi
    LEFT JOIN Tour t ON t.MaTour=l.MaTour
    WHERE n.MaNV=p_MaNV
    GROUP BY n.MaNV, n.LuongCoBan;

    IF v_LuongCoBan IS NOT NULL THEN
        DELETE FROM BangLuong WHERE MaNV=p_MaNV AND Thang=p_Thang AND Nam=p_Nam;
        INSERT INTO BangLuong(MaNV, Thang, Nam, LuongCoBan, SoTour, LuongTheoTour)
        VALUES (p_MaNV, p_Thang, p_Nam, v_LuongCoBan, v_SoTour, v_LuongTheoTour);
    END IF;
END //

/* ---- FrmThongKe ---- */
DROP PROCEDURE IF EXISTS sp_ThongKe //
CREATE PROCEDURE sp_ThongKe(
    IN p_Loai INT,
    IN p_TuNgay DATE,
    IN p_DenNgay DATE
)
BEGIN
    IF p_Loai = 0 THEN
        SELECT t.MaTour, t.TenTour, COUNT(l.Ma) AS SoChuyenDoan
        FROM Tour t LEFT JOIN vw_LichTrinh l ON l.MaTour=t.MaTour AND l.NgayDi BETWEEN p_TuNgay AND p_DenNgay
        GROUP BY t.MaTour, t.TenTour ORDER BY SoChuyenDoan DESC;
    ELSEIF p_Loai = 1 THEN
        SELECT CONCAT('Khách sạn ', n.LoaiKhachSan, ' sao') AS DichVu, COUNT(*) AS SoLanSuDung
        FROM NoiDungChan n JOIN vw_LichTrinh l ON l.MaTour=n.MaTour AND l.NgayDi BETWEEN p_TuNgay AND p_DenNgay
        WHERE n.CoKhachSan=1 GROUP BY n.LoaiKhachSan
        UNION ALL
        SELECT 'Nơi ăn', COUNT(*) FROM NoiDungChan n JOIN vw_LichTrinh l ON l.MaTour=n.MaTour AND l.NgayDi BETWEEN p_TuNgay AND p_DenNgay WHERE n.CoNoiAn=1
        UNION ALL
        SELECT 'Đổi phương tiện', COUNT(*) FROM NoiDungChan n JOIN vw_LichTrinh l ON l.MaTour=n.MaTour AND l.NgayDi BETWEEN p_TuNgay AND p_DenNgay WHERE n.DoiPhuongTien=1;
    ELSEIF p_Loai = 2 THEN
        SELECT 'Khách lẻ' AS Loai, COUNT(*) AS SoKhach FROM DangKyKhachLe d JOIN ChuyenDi c ON c.MaChuyen=d.MaChuyen
               WHERE c.NgayDi BETWEEN p_TuNgay AND p_DenNgay AND c.TinhTrang <> 'Đã hủy'
        UNION ALL
        SELECT 'Khách đoàn', IFNULL(SUM(SoNguoi), 0) FROM DoanKhach
               WHERE NgayDi BETWEEN p_TuNgay AND p_DenNgay AND TrangThai <> 'Đã hủy (mất cọc)';
    ELSEIF p_Loai = 3 THEN
        SELECT 'Hóa đơn' AS Nguon, IFNULL(SUM(SoTienThu), 0) AS DoanhThu FROM HoaDon
               WHERE DATE(NgayThanhToan) BETWEEN p_TuNgay AND p_DenNgay
        UNION ALL
        SELECT 'Cọc bị mất (hủy)', IFNULL(SUM(TienDatCoc), 0) FROM DoanKhach
               WHERE TrangThai='Đã hủy (mất cọc)' AND NgayDi BETWEEN p_TuNgay AND p_DenNgay;
    ELSE
        SELECT n.MaNV, n.HoTen, COUNT(l.Ma) AS SoTour
        FROM NhanVien n
        LEFT JOIN PhanCong p ON p.MaNV=n.MaNV
        LEFT JOIN vw_LichTrinh l ON ((p.MaChuyen IS NOT NULL AND l.MaChuyen=p.MaChuyen) OR (p.MaDoan IS NOT NULL AND l.MaDoan=p.MaDoan))
                                 AND l.NgayDi BETWEEN p_TuNgay AND p_DenNgay
        GROUP BY n.MaNV, n.HoTen ORDER BY SoTour DESC;
    END IF;
END //

/* ---- FrmKhaoSat ---- */
DROP PROCEDURE IF EXISTS sp_KhaoSat_Them //
CREATE PROCEDURE sp_KhaoSat_Them(
    IN p_MaChuyen VARCHAR(15),
    IN p_MaDoan INT,
    IN p_TenKhach VARCHAR(100),
    IN p_Diem TINYINT,
    IN p_GopY VARCHAR(1000),
    IN p_Ngay DATE
)
BEGIN
    IF p_MaChuyen IS NOT NULL AND NOT EXISTS (SELECT 1 FROM ChuyenDi WHERE MaChuyen=p_MaChuyen AND TinhTrang='Đã kết thúc') THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Chỉ khảo sát sau khi tour kết thúc.';
    ELSE
        INSERT INTO KhaoSat(MaChuyen, MaDoan, TenKhach, DiemDanhGia, GopY, NgayKhaoSat)
        VALUES (p_MaChuyen, p_MaDoan, p_TenKhach, p_Diem, p_GopY, p_Ngay);
    END IF;
END //

DROP PROCEDURE IF EXISTS sp_KhaoSat_DanhSach //
CREATE PROCEDURE sp_KhaoSat_DanhSach()
BEGIN
    SELECT * FROM KhaoSat ORDER BY NgayKhaoSat DESC;
END //

DROP PROCEDURE IF EXISTS sp_KhaoSat_Xoa //
CREATE PROCEDURE sp_KhaoSat_Xoa(IN p_MaKS INT)
BEGIN
    DELETE FROM KhaoSat WHERE MaKS=p_MaKS;
END //

/* ---- FrmDenBu ---- */
DROP PROCEDURE IF EXISTS sp_DenBu_Them //
CREATE PROCEDURE sp_DenBu_Them(
    IN p_MaChuyen VARCHAR(15),
    IN p_MaDoan INT,
    IN p_DichVu VARCHAR(100),
    IN p_MoTa VARCHAR(500),
    IN p_MucDo VARCHAR(20),
    IN p_SoTien DECIMAL(18,0)
)
BEGIN
    INSERT INTO DenBu(MaChuyen, MaDoan, DichVu, MoTa, MucDo, SoTienDenBu)
    VALUES (p_MaChuyen, p_MaDoan, p_DichVu, p_MoTa, p_MucDo, p_SoTien);
END //

DROP PROCEDURE IF EXISTS sp_DenBu_DanhSach //
CREATE PROCEDURE sp_DenBu_DanhSach()
BEGIN
    SELECT * FROM DenBu ORDER BY NgayLap DESC;
END //

DROP PROCEDURE IF EXISTS sp_DenBu_Xoa //
CREATE PROCEDURE sp_DenBu_Xoa(IN p_MaDB INT)
BEGIN
    DELETE FROM DenBu WHERE MaDB=p_MaDB;
END //

DELIMITER ;

/* ===================== PHẦN 4: DỮ LIỆU MẪU ===================== */

INSERT INTO PhuongTien(TenPT) VALUES ('Xe du lịch'),('Tàu hỏa'),('Máy bay'),('Tàu thủy');

INSERT INTO NhanVien(HoTen, DienThoai, LuongCoBan) VALUES
('Nguyễn Văn An', '0901000001', 8000000),
('Trần Thị Bình', '0901000002', 8000000);

INSERT INTO TaiKhoan(TenDangNhap, MatKhauHash, VaiTro, MaNV) VALUES
('admin',  UNHEX(SHA2('123456', 256)), 'Quản lý tour', NULL),
('letan',  UNHEX(SHA2('123456', 256)), 'Lễ tân', NULL),
('ketoan', UNHEX(SHA2('123456', 256)), 'Thanh toán', NULL),
('hdv1',   UNHEX(SHA2('123456', 256)), 'Nhân viên hướng dẫn du lịch', 1);

INSERT INTO Tour(MaTour, TenTour, SoNgay, SoDem, DonGia, LuongHDV) VALUES
('T001', 'Hà Nội - Hạ Long', 3, 2, 3500000, 500000),
('T002', 'Đà Nẵng - Hội An', 4, 3, 5200000, 700000);

INSERT INTO Tour_PhuongTien(MaTour, MaPT) VALUES ('T001', 1), ('T001', 3), ('T002', 3), ('T002', 1);

INSERT INTO NoiDungChan(MaTour, TenNoi, DoiPhuongTien, CoNoiAn, CoKhachSan, LoaiKhachSan) VALUES
('T001', 'Hạ Long', 1, 1, 1, 4),
('T002', 'Hội An', 0, 1, 1, 3);

INSERT INTO DiemThamQuan(MaDiem, TenDiem, DiaDiem, NoiDung, YNghia) VALUES
('D001', 'Vịnh Hạ Long', 'Quảng Ninh', 'Du thuyền, thăm hang động', 'Di sản thiên nhiên thế giới'),
('D002', 'Phố cổ Hội An', 'Quảng Nam', 'Dạo phố cổ', 'Di sản văn hóa thế giới');

INSERT INTO Tour_DiemThamQuan(MaTour, MaDiem) VALUES ('T001', 'D001'), ('T002', 'D002');

INSERT INTO DiemBanVe(TenDiem, DiaChi) VALUES ('Quận 1', '12 Lê Lợi, Q1'), ('Quận 7', '45 Nguyễn Thị Thập, Q7');

INSERT INTO ChuyenDi(MaChuyen, MaTour, NgayDi, NgayVe, TinhTrang) VALUES
('C001', 'T001', '2026-11-05', '2026-11-07', 'Chưa khởi hành'),
('C002', 'T002', '2026-09-01', '2026-09-04', 'Đã kết thúc');

/* ===================== KIỂM TRA KẾT QUẢ ===================== */
SELECT TenDangNhap, VaiTro FROM TaiKhoan;
SELECT COUNT(*) AS SoProcedure FROM information_schema.ROUTINES WHERE ROUTINE_SCHEMA = 'QuanLyTour';