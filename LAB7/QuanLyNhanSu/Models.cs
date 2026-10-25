
using System;

namespace LAB07.Models
{
    public class PhongBan
    {
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; }
    }

    public class ChucVu
    {
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public decimal PhuCapChucVu { get; set; }
        public bool TrangThai { get; set; }
    }

    public class NhanVien
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string TrinhDo { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public string MaPhongBan { get; set; }
        public string MaChucVu { get; set; }
        public string TrangThai { get; set; }
    }

    public class HoSoUngTuyen
    {
        public int MaHoSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string TrinhDo { get; set; }
        public string ViTriUngTuyen { get; set; }
        public string MaPhongBan { get; set; }
        public DateTime NgayUngTuyen { get; set; }
        public string TrangThai { get; set; }
    }

    public class QuyetDinhTuyenDung
    {
        public int MaQuyetDinh { get; set; }
        public int MaNhanVien { get; set; }
        public int? MaHoSo { get; set; }
        public string MaPhongBan { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayBatDauThuViec { get; set; }
        public DateTime NgayKetThucThuViec { get; set; }
        public decimal LuongThuViec { get; set; }
        public string DieuKhoan { get; set; }
        public int? NguoiKy { get; set; }
        public string TrangThai { get; set; }
    }

    public class ThuViec
    {
        public int MaThuViec { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime? NgayDanhGia { get; set; }
        public string KetQua { get; set; }
        public string NhanXet { get; set; }
    }

    public class HopDongLaoDong
    {
        public int MaHopDong { get; set; }
        public int MaNhanVien { get; set; }
        public string SoHopDong { get; set; }
        public string LoaiHopDong { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string DieuKhoan { get; set; }
        public string TrangThai { get; set; }
    }

    public class QuyetDinhNhanSu
    {
        public int MaQuyetDinhNS { get; set; }
        public string SoQuyetDinh { get; set; }
        public int MaNhanVien { get; set; }
        public string LoaiQuyetDinh { get; set; }
        public string MaPhongBanCu { get; set; }
        public string MaPhongBanMoi { get; set; }
        public string MaChucVuCu { get; set; }
        public string MaChucVuMoi { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string NoiDung { get; set; }
        public int NguoiKy { get; set; }
    }

    public class QuyetDinhLuong
    {
        public int MaQuyetDinhLuong { get; set; }
        public string SoQuyetDinh { get; set; }
        public int MaNhanVien { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal PhuCapLuong { get; set; }
        public decimal PhuCapDocHai { get; set; }
        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string NoiDung { get; set; }
        public int NguoiKy { get; set; }
    }

    public class HoSoBaoHiem
    {
        public int MaHoSoBaoHiem { get; set; }
        public int MaNhanVien { get; set; }
        public string LoaiBaoHiem { get; set; }
        public string SoThe { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public decimal MucLuongDong { get; set; }
        public decimal TyLeDong { get; set; }
        public bool TrangThai { get; set; }
    }

    public class CaLamViec
    {
        public string MaCa { get; set; }
        public string TenCa { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }
        public bool TrangThai { get; set; }
    }

    public class PhanCongCa
    {
        public int MaPhanCong { get; set; }
        public int MaNhanVien { get; set; }
        public string MaCa { get; set; }
        public DateTime NgayLam { get; set; }
        public int NguoiLap { get; set; }
        public DateTime NgayLap { get; set; }
    }

    public class ChamCong
    {
        public int MaChamCong { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime NgayChamCong { get; set; }
        public string MaCa { get; set; }
        public TimeSpan? GioVao { get; set; }
        public TimeSpan? GioRa { get; set; }
        public decimal SoGioLam { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public int NguoiCham { get; set; }
    }

    public class PhieuPhuTroi
    {
        public int MaPhieu { get; set; }
        public string SoPhieu { get; set; }
        public DateTime NgayPhuTroi { get; set; }
        public string HinhThuc { get; set; }
        public string GhiChu { get; set; }
        public int NguoiLap { get; set; }
        public DateTime NgayLap { get; set; }
    }

    public class ChiTietPhuTroi
    {
        public int MaChiTiet { get; set; }
        public int MaPhieu { get; set; }
        public int MaNhanVien { get; set; }
        public decimal SoGio { get; set; }
        public decimal HeSo { get; set; }
    }

    public class BangLuong
    {
        public int MaBangLuong { get; set; }
        public int MaNhanVien { get; set; }
        public byte Thang { get; set; }
        public short Nam { get; set; }
        public decimal TongGioCong { get; set; }
        public decimal TongGioPhuTroi { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal PhuCapLuong { get; set; }
        public decimal PhuCapChucVu { get; set; }
        public decimal PhuCapDocHai { get; set; }
        public decimal TienPhuTroi { get; set; }
        public decimal TienThuong { get; set; }
        public decimal TienPhat { get; set; }
        public decimal TienBaoHiem { get; set; }
        public decimal ThucLanh { get; set; }
        public DateTime NgayLap { get; set; }
        public int NguoiLap { get; set; }
        public string TrangThai { get; set; }
    }

    public class QuyetDinhThuongPhat
    {
        public int MaQuyetDinh { get; set; }
        public string SoQuyetDinh { get; set; }
        public int? MaNhanVien { get; set; }
        public string MaPhongBan { get; set; }
        public string LoaiQuyetDinh { get; set; }
        public string HinhThuc { get; set; }
        public string LyDo { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayKy { get; set; }
        public int NguoiKy { get; set; }
        public string CachXuLy { get; set; }
        public string TrangThai { get; set; }
    }

    public class PhieuThuChi
    {
        public int MaPhieu { get; set; }
        public string SoPhieu { get; set; }
        public string LoaiPhieu { get; set; }
        public int MaQuyetDinh { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayLap { get; set; }
        public string NoiDung { get; set; }
        public int NguoiLap { get; set; }
    }

    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string VaiTro { get; set; }
        public int? MaNhanVien { get; set; }
        public bool TrangThai { get; set; }
    }
}
