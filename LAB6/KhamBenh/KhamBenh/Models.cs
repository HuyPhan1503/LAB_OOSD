using System;

namespace QL_KhamBenh
{
    /* ---------- Danh muc ---------- */

    public class Khoa
    {
        public int MaKhoa { get; set; }
        public string TenKhoa { get; set; } = string.Empty;
        public override string ToString() => TenKhoa;
    }

    public class BacSi
    {
        public int MaBS { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public int MaKhoa { get; set; }
        public string ChuyenMon { get; set; }
        public string DienThoai { get; set; }
        public override string ToString() => HoTen;
    }

    public class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; } = string.Empty;
        // TiepNhan | ThuNgan | ChamSocKH | QuanLy
        public string ChucVu { get; set; } = string.Empty;
        public string TenDangNhap { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
    }

    public class Thuoc
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; } = string.Empty;
        public string DonVi { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public override string ToString() => TenThuoc;
    }

    public class XetNghiem
    {
        public int MaXN { get; set; }
        public string TenXN { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public override string ToString() => TenXN;
    }

    /* ---------- Dang ky & ho so benh an ---------- */

    public class PhieuDangKy
    {
        public int MaPhieu { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; } = string.Empty;
        public string AnhThe3x4 { get; set; }
        public string CCCD { get; set; } = string.Empty;
        public string SoBHYT { get; set; }
        public DateTime NgayDangKy { get; set; } = DateTime.Today;
    }

    public class HoSoBenhAn
    {
        public int MaHS { get; set; }
        public int MaPhieu { get; set; }
        public DateTime NgayCap { get; set; } = DateTime.Today;
        public DateTime NgayHetHan { get; set; }

        public bool ConHieuLuc => NgayHetHan.Date >= DateTime.Today;
    }

    public class LePhi
    {
        public int MaLP { get; set; }
        public int MaHS { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayDong { get; set; } = DateTime.Today;
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public decimal SoTien { get; set; }
    }

    /* ---------- Lich hen & kham benh ---------- */

    public class LichHen
    {
        public int MaLH { get; set; }
        public int MaHS { get; set; }
        public int MaBS { get; set; }
        public int? MaNV { get; set; }
        public DateTime NgayGioHen { get; set; }
        // "Đã hẹn" | "Đã khám" | "Hủy"
        public string TrangThai { get; set; } = "Đã hẹn";
    }

    public class PhieuKham
    {
        public int MaPK { get; set; }
        public int MaHS { get; set; }
        public int MaBS { get; set; }
        public int MaKhoa { get; set; }
        public int? MaLH { get; set; }
        public DateTime NgayGioKham { get; set; } = DateTime.Now;
        // "Benh" | "DinhKy"
        public string LoaiKham { get; set; } = "Benh";
        public byte? Quy { get; set; }
        public short? Nam { get; set; }
        public string TrieuChung { get; set; }
        public string KetLuan { get; set; }
    }

    public class ToaThuoc
    {
        public int MaToa { get; set; }
        public int MaPK { get; set; }
        public DateTime NgayKe { get; set; } = DateTime.Now;
        public string GhiChu { get; set; }
    }

    public class ChiTietToa
    {
        public int MaToa { get; set; }
        public int MaThuoc { get; set; }
        public int SoLuong { get; set; }
        public string LieuDung { get; set; } = string.Empty;
        public string CachDung { get; set; }
    }

    public class ChiTietXetNghiem
    {
        public int MaPK { get; set; }
        public int MaXN { get; set; }
        public DateTime NgayChiDinh { get; set; } = DateTime.Now;
        public string KetQua { get; set; }
        public DateTime? NgayCoKQ { get; set; }
    }

    /* ---------- Xuat vien, vien phi, theo doi ---------- */

    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaPK { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public decimal TongTien { get; set; }
        public string HinhThucTT { get; set; } = "Tiền mặt";
        // "Chưa thanh toán" | "Đã thanh toán"
        public string TrangThai { get; set; } = "Đã thanh toán";
        public DateTime? NgayXuatVien { get; set; }
    }

    public class TheoDoi
    {
        public int MaTD { get; set; }
        public int MaHD { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayGhiNhan { get; set; } = DateTime.Now;
        public string DienBienBenh { get; set; }
        public string PhanUngPhu { get; set; }
        public string HieuQuaDieuTri { get; set; }
        public string TrachNhiemBacSi { get; set; }
    }
}