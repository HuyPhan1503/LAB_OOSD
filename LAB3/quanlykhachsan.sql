IF DB_ID(N'QuanLyKhachSan') IS NULL
BEGIN
    CREATE DATABASE QuanLyKhachSan;
END
GO

USE QuanLyKhachSan;
GO

CREATE TABLE LoaiTienNghi
(
    MaLoaiTN    VARCHAR(20)   NOT NULL,
    TenLoaiTN   NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_LoaiTienNghi
        PRIMARY KEY (MaLoaiTN)
);
GO

CREATE TABLE KhuVuc
(
    MaKhuVuc    VARCHAR(20)   NOT NULL,
    TenKhuVuc   NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_KhuVuc
        PRIMARY KEY (MaKhuVuc)
);
GO

CREATE TABLE NhanVien
(
    MaNV         VARCHAR(20)   NOT NULL,
    HoTen        NVARCHAR(120) NOT NULL,
    VaiTro       NVARCHAR(50)  NULL,
    SoDienThoai  VARCHAR(20)   NULL,

    CONSTRAINT PK_NhanVien
        PRIMARY KEY (MaNV)
);
GO

CREATE TABLE KhachHang
(
    MaKhach      VARCHAR(20)   NOT NULL,
    HoTen        NVARCHAR(120) NOT NULL,
    SoCMND       VARCHAR(30)   NULL,
    QuocTich     NVARCHAR(80)  NULL,
    SoDienThoai  VARCHAR(20)   NULL,

    CONSTRAINT PK_KhachHang
        PRIMARY KEY (MaKhach)
);
GO

CREATE TABLE DichVu
(
    MaDV        VARCHAR(20)   NOT NULL,
    TenDV       NVARCHAR(120) NOT NULL,
    DonViTinh   NVARCHAR(40)  NULL,
    DonGia      DECIMAL(18,2) NOT NULL
                CONSTRAINT DF_DichVu_DonGia DEFAULT 0,

    CONSTRAINT PK_DichVu
        PRIMARY KEY (MaDV)
);
GO

CREATE TABLE QuyDinhDenBu
(
    MaQuyDinh     VARCHAR(30)   NOT NULL,
    MaLoaiTN      VARCHAR(20)   NOT NULL,
    MucDoThietHai NVARCHAR(80)  NULL,
    MucDenBu      DECIMAL(18,2) NOT NULL
                  CONSTRAINT DF_QuyDinhDenBu_MucDenBu DEFAULT 0,

    CONSTRAINT PK_QuyDinhDenBu
        PRIMARY KEY (MaQuyDinh),

    CONSTRAINT FK_QuyDinhDenBu_LoaiTienNghi
        FOREIGN KEY (MaLoaiTN)
        REFERENCES LoaiTienNghi(MaLoaiTN)
        ON UPDATE CASCADE
);
GO

CREATE TABLE TienNghi
(
    MaTienNghi       VARCHAR(30)   NOT NULL,
    MaLoaiTN         VARCHAR(20)   NOT NULL,
    SoThuTu          INT           NULL,
    TinhTrangHienTai NVARCHAR(100) NULL,

    CONSTRAINT PK_TienNghi
        PRIMARY KEY (MaTienNghi),

    CONSTRAINT FK_TienNghi_LoaiTienNghi
        FOREIGN KEY (MaLoaiTN)
        REFERENCES LoaiTienNghi(MaLoaiTN)
        ON UPDATE CASCADE
);
GO

CREATE TABLE Phong
(
    SoPhong      VARCHAR(20)   NOT NULL,
    MaKhuVuc     VARCHAR(20)   NOT NULL,
    SoNguoiToiDa INT           NULL,
    DonGiaNgay   DECIMAL(18,2) NOT NULL
                 CONSTRAINT DF_Phong_DonGiaNgay DEFAULT 0,
    TrangThai    NVARCHAR(30)  NULL,

    CONSTRAINT PK_Phong
        PRIMARY KEY (SoPhong),

    CONSTRAINT FK_Phong_KhuVuc
        FOREIGN KEY (MaKhuVuc)
        REFERENCES KhuVuc(MaKhuVuc)
        ON UPDATE CASCADE
);
GO

CREATE TABLE PhieuDatPhong
(
    SoPhieuDat     VARCHAR(30)   NOT NULL,
    MaKhach        VARCHAR(20)   NOT NULL,
    MaNVLeTan      VARCHAR(20)   NOT NULL,
    NgayLap        DATETIME      NOT NULL,
    NgayNhan       DATE          NOT NULL,
    NgayTraDuKien  DATE          NOT NULL,
    TienCoc        DECIMAL(18,2) NULL
                   CONSTRAINT DF_PhieuDatPhong_TienCoc DEFAULT 0,
    KenhDat        NVARCHAR(20)  NULL,
    TrangThai      NVARCHAR(30)  NULL,
    NgayNhanThucTe DATETIME      NULL,
    NgayTraThucTe  DATETIME      NULL,

    CONSTRAINT PK_PhieuDatPhong
        PRIMARY KEY (SoPhieuDat),

    CONSTRAINT FK_PhieuDatPhong_KhachHang
        FOREIGN KEY (MaKhach)
        REFERENCES KhachHang(MaKhach)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuDatPhong_NhanVien
        FOREIGN KEY (MaNVLeTan)
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
);
GO

CREATE TABLE ChiTietDatPhong
(
    SoPhieuDat VARCHAR(30) NOT NULL,
    SoPhong    VARCHAR(20) NOT NULL,
    SoNguoi    INT         NULL,

    CONSTRAINT PK_ChiTietDatPhong
        PRIMARY KEY (SoPhieuDat, SoPhong),

    CONSTRAINT FK_ChiTietDatPhong_PhieuDatPhong
        FOREIGN KEY (SoPhieuDat)
        REFERENCES PhieuDatPhong(SoPhieuDat)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    CONSTRAINT FK_ChiTietDatPhong_Phong
        FOREIGN KEY (SoPhong)
        REFERENCES Phong(SoPhong)
        ON UPDATE CASCADE
);
GO

CREATE TABLE NguoiLuuTru
(
    MaNguoiLT  INT IDENTITY(1,1) NOT NULL,
    SoPhieuDat VARCHAR(30)   NOT NULL,
    SoPhong    VARCHAR(20)   NOT NULL,
    HoTen      NVARCHAR(120) NOT NULL,
    SoCMND     VARCHAR(30)   NULL,
    QuocTich   NVARCHAR(80)  NULL,

    CONSTRAINT PK_NguoiLuuTru
        PRIMARY KEY (MaNguoiLT),

    CONSTRAINT FK_NguoiLuuTru_ChiTietDatPhong
        FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES ChiTietDatPhong(SoPhieuDat, SoPhong)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);
GO

CREATE TABLE HoaDon
(
    SoHoaDon       VARCHAR(30)   NOT NULL,
    SoPhieuDat     VARCHAR(30)   NOT NULL,
    NgayLap        DATETIME      NOT NULL,
    MaNV           VARCHAR(20)   NOT NULL,
    SoNgayTinhTien INT           NULL,
    TienPhong      DECIMAL(18,2) NOT NULL
                   CONSTRAINT DF_HoaDon_TienPhong DEFAULT 0,
    TienDichVu     DECIMAL(18,2) NOT NULL
                   CONSTRAINT DF_HoaDon_TienDichVu DEFAULT 0,
    TongTien       DECIMAL(18,2) NOT NULL
                   CONSTRAINT DF_HoaDon_TongTien DEFAULT 0,
    TrangThai      VARCHAR(30)   NULL,

    CONSTRAINT PK_HoaDon
        PRIMARY KEY (SoHoaDon),

    CONSTRAINT FK_HoaDon_PhieuDatPhong
        FOREIGN KEY (SoPhieuDat)
        REFERENCES PhieuDatPhong(SoPhieuDat)
        ON UPDATE CASCADE,

    CONSTRAINT FK_HoaDon_NhanVien
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
);
GO

CREATE TABLE ThanhToan
(
    MaThanhToan   VARCHAR(30)   NOT NULL,
    SoHoaDon      VARCHAR(30)   NOT NULL,
    NgayThanhToan DATETIME      NOT NULL,
    HinhThuc      NVARCHAR(30)  NULL,
    SoTien        DECIMAL(18,2) NOT NULL
                  CONSTRAINT DF_ThanhToan_SoTien DEFAULT 0,

    CONSTRAINT PK_ThanhToan
        PRIMARY KEY (MaThanhToan),

    CONSTRAINT FK_ThanhToan_HoaDon
        FOREIGN KEY (SoHoaDon)
        REFERENCES HoaDon(SoHoaDon)
        ON UPDATE CASCADE
);
GO

CREATE TABLE PhieuLapDat
(
    SoPhieuLapDat VARCHAR(30)   NOT NULL,
    MaTienNghi    VARCHAR(30)   NOT NULL,
    SoPhong       VARCHAR(20)   NOT NULL,
    NgayLap       DATE          NOT NULL,
    TinhTrang     NVARCHAR(100) NULL,
    MaNV          VARCHAR(20)   NOT NULL,
    GhiChu        NVARCHAR(250) NULL,

    CONSTRAINT PK_PhieuLapDat
        PRIMARY KEY (SoPhieuLapDat),

    CONSTRAINT FK_PhieuLapDat_TienNghi
        FOREIGN KEY (MaTienNghi)
        REFERENCES TienNghi(MaTienNghi)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuLapDat_Phong
        FOREIGN KEY (SoPhong)
        REFERENCES Phong(SoPhong)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuLapDat_NhanVien
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
);
GO

CREATE TABLE PhieuDenBu
(
    SoPhieuDenBu VARCHAR(30)   NOT NULL,
    SoPhieuDat   VARCHAR(30)   NOT NULL,
    SoPhong      VARCHAR(20)   NOT NULL,
    NgayLap      DATETIME      NOT NULL,
    MaNV         VARCHAR(20)   NOT NULL,
    TongTien     DECIMAL(18,2) NOT NULL
                 CONSTRAINT DF_PhieuDenBu_TongTien DEFAULT 0,

    CONSTRAINT PK_PhieuDenBu
        PRIMARY KEY (SoPhieuDenBu),

    CONSTRAINT FK_PhieuDenBu_PhieuDatPhong
        FOREIGN KEY (SoPhieuDat)
        REFERENCES PhieuDatPhong(SoPhieuDat)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuDenBu_Phong
        FOREIGN KEY (SoPhong)
        REFERENCES Phong(SoPhong)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuDenBu_NhanVien
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
);
GO

CREATE TABLE ChiTietPhieuDenBu
(
    SoPhieuDenBu  VARCHAR(30)   NOT NULL,
    MaTienNghi    VARCHAR(30)   NOT NULL,
    MucDoThietHai NVARCHAR(80)  NULL,
    SoTien        DECIMAL(18,2) NOT NULL
                  CONSTRAINT DF_ChiTietPhieuDenBu_SoTien DEFAULT 0,

    CONSTRAINT PK_ChiTietPhieuDenBu
        PRIMARY KEY (SoPhieuDenBu, MaTienNghi),

    CONSTRAINT FK_ChiTietPhieuDenBu_PhieuDenBu
        FOREIGN KEY (SoPhieuDenBu)
        REFERENCES PhieuDenBu(SoPhieuDenBu)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    CONSTRAINT FK_ChiTietPhieuDenBu_TienNghi
        FOREIGN KEY (MaTienNghi)
        REFERENCES TienNghi(MaTienNghi)
        ON UPDATE CASCADE
);
GO

CREATE TABLE PhieuSuDungDV
(
    SoPhieuSDDV VARCHAR(30) NOT NULL,
    SoPhieuDat  VARCHAR(30) NOT NULL,
    SoPhong     VARCHAR(20) NOT NULL,
    NgaySuDung  DATE        NOT NULL,
    MaNV        VARCHAR(20) NOT NULL,

    CONSTRAINT PK_PhieuSuDungDV
        PRIMARY KEY (SoPhieuSDDV),

    CONSTRAINT FK_PhieuSuDungDV_PhieuDatPhong
        FOREIGN KEY (SoPhieuDat)
        REFERENCES PhieuDatPhong(SoPhieuDat)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuSuDungDV_Phong
        FOREIGN KEY (SoPhong)
        REFERENCES Phong(SoPhong)
        ON UPDATE CASCADE,

    CONSTRAINT FK_PhieuSuDungDV_NhanVien
        FOREIGN KEY (MaNV)
        REFERENCES NhanVien(MaNV)
        ON UPDATE CASCADE
);
GO

CREATE TABLE ChiTietPhieuSuDungDV
(
    SoPhieuSDDV VARCHAR(30)   NOT NULL,
    MaDV        VARCHAR(20)   NOT NULL,
    SoLuong     INT           NOT NULL
                CONSTRAINT DF_ChiTietPhieuSuDungDV_SoLuong DEFAULT 1,
    DonGia      DECIMAL(18,2) NOT NULL
                CONSTRAINT DF_ChiTietPhieuSuDungDV_DonGia DEFAULT 0,
    ThanhTien   DECIMAL(18,2) NOT NULL
                CONSTRAINT DF_ChiTietPhieuSuDungDV_ThanhTien DEFAULT 0,

    CONSTRAINT PK_ChiTietPhieuSuDungDV
        PRIMARY KEY (SoPhieuSDDV, MaDV),

    CONSTRAINT FK_ChiTietPhieuSuDungDV_PhieuSuDungDV
        FOREIGN KEY (SoPhieuSDDV)
        REFERENCES PhieuSuDungDV(SoPhieuSDDV)
        ON UPDATE CASCADE
        ON DELETE CASCADE,

    CONSTRAINT FK_ChiTietPhieuSuDungDV_DichVu
        FOREIGN KEY (MaDV)
        REFERENCES DichVu(MaDV)
        ON UPDATE CASCADE
);
GO

CREATE INDEX IX_PhieuDatPhong_MaKhach
ON PhieuDatPhong(MaKhach);

CREATE INDEX IX_PhieuDatPhong_MaNVLeTan
ON PhieuDatPhong(MaNVLeTan);

CREATE INDEX IX_HoaDon_SoPhieuDat
ON HoaDon(SoPhieuDat);

CREATE INDEX IX_Phong_MaKhuVuc
ON Phong(MaKhuVuc);

CREATE INDEX IX_TienNghi_MaLoaiTN
ON TienNghi(MaLoaiTN);
GO

INSERT INTO NhanVien(MaNV,HoTen,VaiTro,SoDienThoai) VALUES
('NV01',N'Nguyễn Thu Hà',N'Lễ tân','0901000001'),
('NV02',N'Trần Minh An',N'Phục vụ phòng','0901000002'),
('NV03',N'Lê Hoàng Nam',N'Thanh toán','0901000003');
INSERT INTO KhuVuc(MaKhuVuc,TenKhuVuc) VALUES ('A',N'Khu A'),('B',N'Khu B');
INSERT INTO Phong(SoPhong,MaKhuVuc,SoNguoiToiDa,DonGiaNgay,TrangThai)
VALUES
('A101','A',2,600000,N'Trống'),('A102','A',3,800000,N'Trống'),('B201','B',4,1200000,N'Trống');
INSERT INTO LoaiTienNghi(MaLoaiTN,TenLoaiTN) VALUES ('TV',N'Ti vi'),('TL',N'Tủ
lạnh'),('DT',N'Điện thoại');
INSERT INTO TienNghi(MaTienNghi,MaLoaiTN,SoThuTu,TinhTrangHienTai) VALUES
('TV01','TV',1,N'Tốt'),('TV02','TV',2,N'Tốt'),('TL01','TL',1,N'Tốt');
INSERT INTO DichVu(MaDV,TenDV,DonViTinh,DonGia) VALUES
('DV01',N'Ăn sáng',N'Suất',120000),('DV02',N'Tắm
hơi',N'Lượt',250000),('DV03',N'Karaoke',N'Giờ',300000);
INSERT INTO QuyDinhDenBu(MaQuyDinh,MaLoaiTN,MucDoThietHai,MucDenBu)
VALUES
('QD01','TV',N'Hư hỏng nhẹ',500000),('QD02','TV',N'Mất',5000000),('QD03','TL',N'Hư hỏng
nhẹ',400000),('QD04','TL',N'Mất',4000000);