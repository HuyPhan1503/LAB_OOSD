using System;
using System.Collections.Generic;

namespace LAB5.Models
{
    // ===== Tài khoản / nhân viên =====
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }          // chỉ dùng khi đăng nhập/đổi mật khẩu (DB lưu hash)
        public string VaiTro { get; set; }           // Lễ tân | Nhân viên hướng dẫn du lịch | Thanh toán | Quản lý tour
        public int? MaNV { get; set; }
    }

    public class NhanVien
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public decimal LuongCoBan { get; set; }
        public override string ToString() { return HoTen; }
    }

    // ===== Tour =====
    public class PhuongTien
    {
        public int MaPT { get; set; }
        public string TenPT { get; set; }
        public override string ToString() { return TenPT; }
    }

    public class Tour
    {
        public string MaTour { get; set; }
        public string TenTour { get; set; }
        public int SoNgay { get; set; }
        public int SoDem { get; set; }
        public decimal DonGia { get; set; }          // giá cho 1 khách
        public decimal LuongHDV { get; set; }        // lương HDV cho mỗi lần dẫn tour
        public List<PhuongTien> PhuongTiens { get; set; } = new List<PhuongTien>();
        public override string ToString() { return TenTour; }
    }

    public class NoiDungChan
    {
        public int MaNoi { get; set; }
        public string MaTour { get; set; }
        public string TenNoi { get; set; }
        public bool DoiPhuongTien { get; set; }
        public bool CoNoiAn { get; set; }
        public bool CoKhachSan { get; set; }
        public byte? LoaiKhachSan { get; set; }      // 2-5 sao, null nếu không có khách sạn
    }

    public class DiemThamQuan
    {
        public string MaDiem { get; set; }
        public string TenDiem { get; set; }
        public string DiaDiem { get; set; }
        public string NoiDung { get; set; }
        public string YNghia { get; set; }
    }

    // ===== Chuyến & khách lẻ =====
    public class ChuyenDi
    {
        public string MaChuyen { get; set; }
        public string MaTour { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayVe { get; set; }
        public string TinhTrang { get; set; }        // Chưa khởi hành | Đang diễn ra | Đã kết thúc | Đã hủy
        public int SoKhach { get; set; }             // đếm từ DangKyKhachLe (chỉ để hiển thị)
        public override string ToString()
        { return MaChuyen + " (" + NgayDi.ToString("dd/MM/yyyy") + " - " + NgayVe.ToString("dd/MM/yyyy") + ")"; }
    }

    public class DiemBanVe
    {
        public int MaDiemBan { get; set; }
        public string TenDiem { get; set; }
        public string DiaChi { get; set; }
        public override string ToString() { return TenDiem; }
    }

    public class KhachLe
    {
        public int MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string QuocTich { get; set; } = "Việt Nam";
    }

    public class DangKyKhachLe
    {
        public int MaDK { get; set; }
        public string MaChuyen { get; set; }
        public int MaKhach { get; set; }
        public int? MaDiemBan { get; set; }
        public string DiemDon { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayDangKy { get; set; }
    }

    // ===== Khách đoàn =====
    public class DoanKhach
    {
        public int MaDoan { get; set; }
        public string TenCoQuan { get; set; }        // hoặc tên đại diện gia đình
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string NguoiDaiDien { get; set; }
        public string MaTour { get; set; }
        public DateTime NgayDi { get; set; }
        public DateTime NgayVe { get; set; }
        public int SoNguoi { get; set; }             // > 12
        public string DiaDiemDon { get; set; }
        public bool CoBaoHiem { get; set; }
        public int SoNguoiBaoHiem { get; set; }
        public decimal TienDatCoc { get; set; }
        public string TrangThai { get; set; }        // Đã đặt cọc | Đã hủy (mất cọc) | Đã kết thúc | Đã quyết toán
        public List<NguoiDiDoan> NguoiDis { get; set; } = new List<NguoiDiDoan>();
        public override string ToString() { return TenCoQuan + " (" + NgayDi.ToString("dd/MM/yyyy") + ")"; }
    }

    public class NguoiDiDoan
    {
        public int MaNguoi { get; set; }
        public int MaDoan { get; set; }
        public string HoTen { get; set; }
        public string CCCD { get; set; }
        public bool MuaBaoHiem { get; set; }
    }

    // ===== Phân công / thanh toán / lương =====
    public class PhanCong
    {
        public int MaPC { get; set; }
        public int MaNV { get; set; }
        public string MaChuyen { get; set; }         // khách lẻ (null nếu là đoàn)
        public int? MaDoan { get; set; }             // khách đoàn (null nếu là chuyến lẻ)
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
    }

    public class HoaDon
    {
        public int MaHD { get; set; }
        public string SoHoaDon { get; set; }
        public string LoaiTour { get; set; }         // Khách lẻ | Khách đoàn
        public int? MaDK { get; set; }
        public int? MaDoan { get; set; }
        public int SoKhach { get; set; }
        public decimal TongTien { get; set; }
        public decimal DaDatCoc { get; set; }
        public decimal SoTienThu { get; set; }
        public string PhuongThuc { get; set; }       // Tiền mặt | Chuyển khoản | Thẻ
        public DateTime NgayThanhToan { get; set; }
        public string TrangThai { get; set; }
        public decimal ConPhaiThu
        { get { return LoaiTour == "Khách đoàn" ? TongTien - DaDatCoc : TongTien; } }
    }

    public class BangLuong
    {
        public int MaNV { get; set; }
        public byte Thang { get; set; }
        public short Nam { get; set; }
        public decimal LuongCoBan { get; set; }
        public int SoTour { get; set; }
        public decimal LuongTheoTour { get; set; }
        public decimal TongLuong { get { return LuongCoBan + LuongTheoTour; } }
    }

    // ===== Khảo sát / đền bù =====
    public class KhaoSat
    {
        public int MaKS { get; set; }
        public string MaChuyen { get; set; }
        public int? MaDoan { get; set; }
        public string TenKhach { get; set; }
        public byte DiemDanhGia { get; set; }
        public string GopY { get; set; }
        public DateTime NgayKhaoSat { get; set; }
    }

    public class DenBu
    {
        public int MaDB { get; set; }
        public string MaChuyen { get; set; }
        public int? MaDoan { get; set; }
        public string DichVu { get; set; }
        public string MoTa { get; set; }
        public string MucDo { get; set; }            // Nhẹ | Trung bình | Nặng
        public decimal SoTienDenBu { get; set; }
        public DateTime NgayLap { get; set; }
    }
}