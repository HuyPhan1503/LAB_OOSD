
USE master;
GO

IF DB_ID(N'QL_NhanSu') IS NULL
    CREATE DATABASE QL_NhanSu;
GO

USE QL_NhanSu;
GO

/* 1. PHONG BAN */
CREATE TABLE PhongBan (
    MaPhongBan VARCHAR(10) PRIMARY KEY,
    TenPhongBan NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(255),
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

/* 2. CHUC VU */
CREATE TABLE ChucVu (
    MaChucVu VARCHAR(10) PRIMARY KEY,
    TenChucVu NVARCHAR(100) NOT NULL UNIQUE,
    PhuCapChucVu DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (PhuCapChucVu >= 0),
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

/* 3. NHAN VIEN */
CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10),
    CCCD VARCHAR(20) NOT NULL UNIQUE,
    DiaChi NVARCHAR(255),
    DienThoai VARCHAR(15),
    Email VARCHAR(150),
    TrinhDo NVARCHAR(100),
    NgayVaoLam DATE,
    MaPhongBan VARCHAR(10) NULL,
    MaChucVu VARCHAR(10) NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Thử việc',
    CONSTRAINT FK_NV_PhongBan
        FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    CONSTRAINT FK_NV_ChucVu
        FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu),
    CONSTRAINT CK_NV_TrangThai CHECK (
        TrangThai IN (N'Thử việc', N'Chính thức', N'Nghỉ việc')
    ),
    CONSTRAINT CK_NV_NgaySinh CHECK (
        NgaySinh < CAST(GETDATE() AS DATE)
    )
);
GO

/* 4. HO SO UNG TUYEN */
CREATE TABLE HoSoUngTuyen (
    MaHoSo INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10),
    CCCD VARCHAR(20),
    DiaChi NVARCHAR(255),
    DienThoai VARCHAR(15),
    Email VARCHAR(150),
    TrinhDo NVARCHAR(100),
    ViTriUngTuyen NVARCHAR(100) NOT NULL,
    MaPhongBan VARCHAR(10) NOT NULL,
    NgayUngTuyen DATE NOT NULL DEFAULT (CAST(GETDATE() AS DATE)),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Mới',
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    CHECK (TrangThai IN (
        N'Mới', N'Đang xét', N'Đã tuyển', N'Từ chối'
    ))
);
GO

/* 5. QUYET DINH TUYEN DUNG */
CREATE TABLE QuyetDinhTuyenDung (
    MaQuyetDinh INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL UNIQUE,
    MaHoSo INT NULL,
    MaPhongBan VARCHAR(10) NOT NULL,
    NgayKy DATE NOT NULL,
    NgayBatDauThuViec DATE NOT NULL,
    NgayKetThucThuViec DATE NOT NULL,
    LuongThuViec DECIMAL(18,2) NOT NULL
        CHECK (LuongThuViec >= 0),
    DieuKhoan NVARCHAR(MAX) NOT NULL,
    NguoiKy INT NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đã duyệt',
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaHoSo) REFERENCES HoSoUngTuyen(MaHoSo),
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (NguoiKy) REFERENCES NhanVien(MaNhanVien),
    CHECK (NgayKetThucThuViec >= NgayBatDauThuViec),
    CHECK (DATEDIFF(YEAR, NgayBatDauThuViec,
                    CAST(NgayBatDauThuViec AS DATE)) >= 0)
);
GO

/* 6. KET QUA THU VIEC */
CREATE TABLE ThuViec (
    MaThuViec INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL UNIQUE,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    NgayDanhGia DATE NULL,
    KetQua NVARCHAR(30) NOT NULL DEFAULT N'Chưa đánh giá',
    NhanXet NVARCHAR(1000),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    CHECK (NgayKetThuc >= NgayBatDau),
    CHECK (KetQua IN (N'Chưa đánh giá', N'Đạt', N'Không đạt'))
);
GO

/* 7. HOP DONG LAO DONG */
CREATE TABLE HopDongLaoDong (
    MaHopDong INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL,
    SoHopDong VARCHAR(30) NOT NULL UNIQUE,
    LoaiHopDong NVARCHAR(20) NOT NULL,
    NgayKy DATE NOT NULL,
    NgayHieuLuc DATE NOT NULL,
    NgayKetThuc DATE NULL,
    DieuKhoan NVARCHAR(MAX) NOT NULL,
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Hiệu lực',
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    CHECK (LoaiHopDong IN (N'Dài hạn', N'Ngắn hạn')),
    CHECK (TrangThai IN (N'Hiệu lực', N'Hết hạn', N'Đã chấm dứt')),
    CHECK (NgayHieuLuc >= NgayKy),
    CHECK (NgayKetThuc IS NULL OR NgayKetThuc >= NgayHieuLuc),
    CHECK (
        (LoaiHopDong = N'Dài hạn' AND NgayKetThuc IS NULL)
        OR
        (LoaiHopDong = N'Ngắn hạn' AND NgayKetThuc IS NOT NULL)
    )
);
GO

/* Không cho phép hai hợp đồng hiệu lực chồng nhau
   được kiểm tra thêm tại Service khi ký hợp đồng. */

/* 8. QUYET DINH NHAN SU */
CREATE TABLE QuyetDinhNhanSu (
    MaQuyetDinhNS INT IDENTITY(1,1) PRIMARY KEY,
    SoQuyetDinh VARCHAR(30) NOT NULL UNIQUE,
    MaNhanVien INT NOT NULL,
    LoaiQuyetDinh NVARCHAR(30) NOT NULL,
    MaPhongBanCu VARCHAR(10) NULL,
    MaPhongBanMoi VARCHAR(10) NULL,
    MaChucVuCu VARCHAR(10) NULL,
    MaChucVuMoi VARCHAR(10) NULL,
    NgayKy DATE NOT NULL,
    NgayHieuLuc DATE NOT NULL,
    NoiDung NVARCHAR(1000) NOT NULL,
    NguoiKy INT NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaPhongBanCu) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaPhongBanMoi) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (MaChucVuCu) REFERENCES ChucVu(MaChucVu),
    FOREIGN KEY (MaChucVuMoi) REFERENCES ChucVu(MaChucVu),
    FOREIGN KEY (NguoiKy) REFERENCES NhanVien(MaNhanVien),
    CHECK (LoaiQuyetDinh IN (
        N'Bổ nhiệm', N'Điều chuyển', N'Miễn nhiệm', N'Khác'
    )),
    CHECK (NgayHieuLuc >= NgayKy)
);
GO

/* 9. QUYET DINH LUONG */
CREATE TABLE QuyetDinhLuong (
    MaQuyetDinhLuong INT IDENTITY(1,1) PRIMARY KEY,
    SoQuyetDinh VARCHAR(30) NOT NULL UNIQUE,
    MaNhanVien INT NOT NULL,
    LuongCoBan DECIMAL(18,2) NOT NULL CHECK (LuongCoBan >= 0),
    PhuCapLuong DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (PhuCapLuong >= 0),
    PhuCapDocHai DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (PhuCapDocHai >= 0),
    NgayKy DATE NOT NULL,
    NgayHieuLuc DATE NOT NULL,
    NoiDung NVARCHAR(1000),
    NguoiKy INT NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (NguoiKy) REFERENCES NhanVien(MaNhanVien),
    CHECK (NgayHieuLuc >= NgayKy)
);
GO

/* 10. HO SO BAO HIEM */
CREATE TABLE HoSoBaoHiem (
    MaHoSoBaoHiem INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL,
    LoaiBaoHiem NVARCHAR(10) NOT NULL,
    SoThe VARCHAR(30) NOT NULL UNIQUE,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NULL,
    MucLuongDong DECIMAL(18,2) NOT NULL CHECK (MucLuongDong >= 0),
    TyLeDong DECIMAL(5,2) NOT NULL CHECK (TyLeDong >= 0 AND TyLeDong <= 100),
    TrangThai BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    CHECK (LoaiBaoHiem IN (N'BHYT', N'BHXH')),
    CHECK (NgayKetThuc IS NULL OR NgayKetThuc >= NgayBatDau)
);
GO

CREATE UNIQUE INDEX UX_BaoHiem_NV_Loai_DangKy
ON HoSoBaoHiem(MaNhanVien, LoaiBaoHiem)
WHERE TrangThai = 1;
GO

/* 11. CA LAM VIEC */
CREATE TABLE CaLamViec (
    MaCa VARCHAR(10) PRIMARY KEY,
    TenCa NVARCHAR(50) NOT NULL,
    GioBatDau TIME NOT NULL,
    GioKetThuc TIME NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

/* 12. PHAN CONG CA LAM */
CREATE TABLE PhanCongCa (
    MaPhanCong INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL,
    MaCa VARCHAR(10) NOT NULL,
    NgayLam DATE NOT NULL,
    NguoiLap INT NOT NULL,
    NgayLap DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa),
    FOREIGN KEY (NguoiLap) REFERENCES NhanVien(MaNhanVien),
    UNIQUE (MaNhanVien, NgayLam, MaCa)
);
GO

/* 13. CHAM CONG */
CREATE TABLE ChamCong (
    MaChamCong INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL,
    NgayChamCong DATE NOT NULL,
    MaCa VARCHAR(10) NOT NULL,
    GioVao TIME NULL,
    GioRa TIME NULL,
    SoGioLam DECIMAL(5,2) NOT NULL DEFAULT 0
        CHECK (SoGioLam >= 0),
    TrangThai NVARCHAR(30) NOT NULL DEFAULT N'Đủ công',
    GhiChu NVARCHAR(255),
    NguoiCham INT NOT NULL,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaCa) REFERENCES CaLamViec(MaCa),
    FOREIGN KEY (NguoiCham) REFERENCES NhanVien(MaNhanVien),
    UNIQUE (MaNhanVien, NgayChamCong, MaCa),
    CHECK (TrangThai IN (
        N'Đủ công', N'Nghỉ phép', N'Nghỉ không phép', N'Nửa ngày'
    ))
);
GO

/* 14. PHIEU PHU TROI */
CREATE TABLE PhieuPhuTroi (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    SoPhieu VARCHAR(30) NOT NULL UNIQUE,
    NgayPhuTroi DATE NOT NULL,
    HinhThuc NVARCHAR(30) NOT NULL,
    GhiChu NVARCHAR(500),
    NguoiLap INT NOT NULL,
    NgayLap DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    FOREIGN KEY (NguoiLap) REFERENCES NhanVien(MaNhanVien),
    CHECK (HinhThuc IN (N'Tăng ca', N'Ngày lễ', N'Ngày nghỉ'))
);
GO

/* 15. CHI TIET PHIEU PHU TROI */
CREATE TABLE ChiTietPhuTroi (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu INT NOT NULL,
    MaNhanVien INT NOT NULL,
    SoGio DECIMAL(5,2) NOT NULL CHECK (SoGio > 0),
    HeSo DECIMAL(4,2) NOT NULL DEFAULT 1.5 CHECK (HeSo = 1.5),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuPhuTroi(MaPhieu)
        ON DELETE CASCADE,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    UNIQUE (MaPhieu, MaNhanVien)
);
GO

/* 16. BANG LUONG */
CREATE TABLE BangLuong (
    MaBangLuong INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL,
    Thang TINYINT NOT NULL CHECK (Thang BETWEEN 1 AND 12),
    Nam SMALLINT NOT NULL,
    TongGioCong DECIMAL(8,2) NOT NULL DEFAULT 0,
    TongGioPhuTroi DECIMAL(8,2) NOT NULL DEFAULT 0,
    LuongCoBan DECIMAL(18,2) NOT NULL DEFAULT 0,
    PhuCapLuong DECIMAL(18,2) NOT NULL DEFAULT 0,
    PhuCapChucVu DECIMAL(18,2) NOT NULL DEFAULT 0,
    PhuCapDocHai DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienPhuTroi DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienThuong DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienPhat DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienBaoHiem DECIMAL(18,2) NOT NULL DEFAULT 0,
    ThucLanh DECIMAL(18,2) NOT NULL DEFAULT 0,
    NgayLap DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    NguoiLap INT NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Nháp',
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (NguoiLap) REFERENCES NhanVien(MaNhanVien),
    UNIQUE (MaNhanVien, Thang, Nam),
    CHECK (TrangThai IN (N'Nháp', N'Đã duyệt', N'Đã thanh toán'))
);
GO

/* 17. QUYET DINH THUONG / KY LUAT */
CREATE TABLE QuyetDinhThuongPhat (
    MaQuyetDinh INT IDENTITY(1,1) PRIMARY KEY,
    SoQuyetDinh VARCHAR(30) NOT NULL UNIQUE,
    MaNhanVien INT NULL,
    MaPhongBan VARCHAR(10) NULL,
    LoaiQuyetDinh NVARCHAR(20) NOT NULL,
    HinhThuc NVARCHAR(50) NOT NULL,
    LyDo NVARCHAR(1000) NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL CHECK (SoTien >= 0),
    NgayKy DATE NOT NULL,
    NguoiKy INT NOT NULL,
    CachXuLy NVARCHAR(30) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đã duyệt',
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan),
    FOREIGN KEY (NguoiKy) REFERENCES NhanVien(MaNhanVien),
    CHECK (LoaiQuyetDinh IN (N'Khen thưởng', N'Kỷ luật')),
    CHECK (CachXuLy IN (N'Phiếu chi', N'Phiếu thu', N'Trừ lương')),
    CHECK (TrangThai IN (N'Chờ duyệt', N'Đã duyệt', N'Từ chối')),
    CHECK (
        (MaNhanVien IS NOT NULL AND MaPhongBan IS NULL)
        OR (MaNhanVien IS NULL AND MaPhongBan IS NOT NULL)
    )
);
GO

/* 18. PHIEU THU CHI */
CREATE TABLE PhieuThuChi (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    SoPhieu VARCHAR(30) NOT NULL UNIQUE,
    LoaiPhieu NVARCHAR(10) NOT NULL,
    MaQuyetDinh INT NOT NULL,
    SoTien DECIMAL(18,2) NOT NULL CHECK (SoTien >= 0),
    NgayLap DATE NOT NULL DEFAULT (CAST(GETDATE() AS DATE)),
    NoiDung NVARCHAR(500),
    NguoiLap INT NOT NULL,
    FOREIGN KEY (MaQuyetDinh) REFERENCES QuyetDinhThuongPhat(MaQuyetDinh),
    FOREIGN KEY (NguoiLap) REFERENCES NhanVien(MaNhanVien),
    CHECK (LoaiPhieu IN (N'Phiếu thu', N'Phiếu chi'))
);
GO

/* 19. TAI KHOAN */
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhauHash VARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(30) NOT NULL,
    MaNhanVien INT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    CHECK (VaiTro IN (
        N'Giám đốc', N'Phòng ban', N'Ban chấm công',
        N'Ban lãnh đạo', N'Quản trị viên'
    ))
);
GO

/* 20. NHAT KY HE THONG */
CREATE TABLE NhatKyHeThong (
    MaNhatKy BIGINT IDENTITY(1,1) PRIMARY KEY,
    MaTaiKhoan INT NULL,
    ThaoTac NVARCHAR(100) NOT NULL,
    BangDuLieu NVARCHAR(100),
    KhoaDuLieu NVARCHAR(100),
    ThoiGian DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    ChiTiet NVARCHAR(1000),
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);
GO

/* INDEX PHUC VU TRA CUU */
CREATE INDEX IX_NhanVien_HoTen ON NhanVien(HoTen);
CREATE INDEX IX_NhanVien_PhongBan ON NhanVien(MaPhongBan);
CREATE INDEX IX_HopDong_NhanVien ON HopDongLaoDong(MaNhanVien);
CREATE INDEX IX_ChamCong_Ngay ON ChamCong(NgayChamCong);
CREATE INDEX IX_BangLuong_ThangNam ON BangLuong(Nam, Thang);
GO
