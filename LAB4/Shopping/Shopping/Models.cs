using System;

namespace Shopping.Models
{
    public class NhomSanPham
    {
        public int MaNhomSP { get; set; }
        public string TenNhomSP { get; set; }

        public override string ToString() { return TenNhomSP; }
    }

    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string NhaSanXuat { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string ThongSoKT { get; set; }
        public decimal GiaBan { get; set; }
        public bool CoHang { get; set; }
        public int MaNhomSP { get; set; }
        public string TenNhomSP { get; set; }   // lay tu JOIN, khong luu trong bang
    }

    public class KhachHang
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoCMND { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }      // mat khau goc, chi dung luc dang ky/dang nhap, bam truoc khi luu
        public string MatKhauHash { get; set; }
        public string Email { get; set; }

        public bool CoEmail { get { return !string.IsNullOrWhiteSpace(Email); } }
    }

    public class ChiTietGioHang
    {
        public int MaKhachHang { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }

        // lay tu JOIN SanPham
        public string TenSP { get; set; }
        public decimal GiaBan { get; set; }

        public decimal ThanhTien { get { return GiaBan * SoLuong; } }
    }

    public class KhuVuc
    {
        public int MaKhuVuc { get; set; }
        public string TenKhuVuc { get; set; }

        public override string ToString() { return TenKhuVuc; }
    }

    public class LoaiPhieu
    {
        public int MaLoaiPhieu { get; set; }     // 1 thuong, 2 nhanh, 3 nhanh trong ngay
        public string TenLoaiPhieu { get; set; }
        public string ThoiGianXuLy { get; set; }

        public override string ToString() { return TenLoaiPhieu; }
    }

    public class PhiGiaoHang
    {
        public int MaKhuVuc { get; set; }
        public int MaLoaiPhieu { get; set; }
        public decimal Phi { get; set; }
    }

    public class LoaiThe
    {
        public int MaLoaiThe { get; set; }
        public string TenLoaiThe { get; set; }
        public int DoDaiSoThe { get; set; }      // 16 hoac 15
        public int DoDaiCSV { get; set; }        // 3 hoac 4
        public decimal LePhi { get; set; }

        public override string ToString() { return TenLoaiThe; }
    }

    public class NguoiNhan
    {
        public int MaNguoiNhan { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public int MaKhuVuc { get; set; }
    }

    // Thong tin the nhap tu Form, KHONG luu CSV va so the day du vao CSDL
    public class ThongTinThe
    {
        public int MaLoaiThe { get; set; }
        public string SoThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string TenChuThe { get; set; }
        public string CSV { get; set; }

        public string SoTheChe
        {
            get
            {
                if (string.IsNullOrEmpty(SoThe) || SoThe.Length < 4) return "****";
                return "****" + SoThe.Substring(SoThe.Length - 4);
            }
        }
    }

    public class DonHang
    {
        public int MaDonHang { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNguoiNhan { get; set; }
        public int MaLoaiPhieu { get; set; }
        public int MaLoaiThe { get; set; }
        public string SoTheChe { get; set; }
        public string TenChuThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public decimal TienHang { get; set; }
        public decimal PhiGiaoHang { get; set; }
        public decimal LePhiThe { get; set; }
        public decimal TongTriGia { get; set; }
        public DateTime ThoiDiemDat { get; set; }
        public string TrangThai { get; set; }
    }

    public class ChiTietDonHang
    {
        public int MaDonHang { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }      // don gia tai thoi diem dat

        public string TenSP { get; set; }        // lay tu JOIN
        public decimal ThanhTien { get { return DonGia * SoLuong; } }
    }

    // Hang so dung chung de tranh "magic number"
    public static class HangSo
    {
        public const int PHIEU_THUONG = 1;
        public const int PHIEU_NHANH = 2;
        public const int PHIEU_TRONG_NGAY = 3;

        public const decimal NGUONG_MIEN_PHI_NHANH = 1000000m;
        public const decimal NGUONG_MIEN_PHI_TRONG_NGAY = 5000000m;
    }
}
