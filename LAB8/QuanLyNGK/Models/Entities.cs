using System;
using System.Collections.Generic;

namespace QuanLyNGK.Models
{
    public class NhanHieu
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
    }

    public class NhaCungUng
    {
        public string MaNCU { get; set; }
        public string TenNCU { get; set; }
    }

    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public string HienThi { get { return HoTen + " (" + ChucVu + ")"; } }
    }

    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string LoaiKhachHang { get; set; }

        public bool LaKhachQuen { get { return LoaiKhachHang == "KhachQuen"; } }

        public string HienThi
        {
            get { return MaKH + " - " + TenKH + (LaKhachQuen ? " (Quen)" : " (Vãng lai)"); }
        }
    }

    public class NuocGiaiKhat
    {
        public string MaNGK { get; set; }
        public string TenNGK { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGiaBan { get; set; }
        public string MaLoai { get; set; }
        public string MaNCU { get; set; }

        public string HienThi { get { return MaNGK + " - " + TenNGK; } }
    }

    /// <summary>Một dòng trong giỏ hàng / chi tiết hóa đơn đang lập.</summary>
    public class ChiTietBan
    {
        public string MaNGK { get; set; }
        public string TenNGK { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongTon { get; set; }   // tồn kho tại thời điểm chọn
        public int SoLuong { get; set; }      // số lượng khách đặt mua
        public decimal DonGia { get; set; }

        public decimal ThanhTien { get { return SoLuong * DonGia; } }

        /// <summary>Phần kho chưa đủ -> sẽ đưa vào Phiếu hẹn giao (chỉ Khách quen).</summary>
        public int SoLuongThieu { get { return Math.Max(0, SoLuong - SoLuongTon); } }
    }

    public class LapHoaDonRequest
    {
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayLap { get; set; }
        public List<ChiTietBan> ChiTiet { get; set; }
        public decimal SoTienKhachTra { get; set; }
        public DateTime NgayHenGiao { get; set; }
        public DateTime NgayDuKienTra { get; set; }
        public string LyDoNo { get; set; }
    }

    public class LapHoaDonKetQua
    {
        public string MaHD { get; set; }
        public decimal TongTien { get; set; }
        public decimal SoTienNo { get; set; }
        public bool CoPhieuHen { get; set; }
    }

    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static ServiceResult Ok(string message, object data = null)
        {
            return new ServiceResult { Success = true, Message = message, Data = data };
        }

        public static ServiceResult Fail(string message)
        {
            return new ServiceResult { Success = false, Message = message };
        }
    }
}
