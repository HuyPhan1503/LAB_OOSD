using System;
using System.Collections.Generic;
using System.Data;
using Shopping.Data;
using Shopping.Models;

namespace Shopping.Services
{
    public static class GioHangService
    {
        public static void Them(int maKhachHang, string maSP, int soLuong)
        {
            if (soLuong <= 0)
                throw new InvalidOperationException("Số lượng phải lớn hơn 0.");

            SanPham sp = SanPhamService.LayTheoMa(maSP);

            if (sp == null)
                throw new InvalidOperationException("Sản phẩm không tồn tại.");

            if (!sp.CoHang)
                throw new InvalidOperationException(
                    "Sản phẩm \"" + sp.TenSP + "\" đã hết hàng."
                );

            // MySQL: da co thi cong don so luong, chua co thi them moi
            // (can PRIMARY KEY (MaKhachHang, MaSP) - script da co san)
            Db.Execute(
                "INSERT INTO ChiTietGioHang(MaKhachHang, MaSP, SoLuong) " +
                "VALUES(@kh, @sp, @sl) " +
                "ON DUPLICATE KEY UPDATE SoLuong = SoLuong + @sl",

                Db.P("@kh", maKhachHang),
                Db.P("@sp", maSP),
                Db.P("@sl", soLuong)
            );
        }

        public static List<ChiTietGioHang> Lay(int maKhachHang)
        {
            DataTable dt = Db.Query(
                "SELECT g.MaKhachHang, g.MaSP, g.SoLuong, " +
                "sp.TenSP, sp.GiaBan " +
                "FROM ChiTietGioHang g " +
                "JOIN SanPham sp ON sp.MaSP = g.MaSP " +
                "WHERE g.MaKhachHang=@kh " +
                "ORDER BY sp.TenSP",

                Db.P("@kh", maKhachHang)
            );

            List<ChiTietGioHang> ds = new List<ChiTietGioHang>();

            foreach (DataRow r in dt.Rows)
            {
                ds.Add(new ChiTietGioHang
                {
                    MaKhachHang = Convert.ToInt32(r["MaKhachHang"]),
                    MaSP = r["MaSP"].ToString(),
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    TenSP = r["TenSP"].ToString(),
                    GiaBan = Convert.ToDecimal(r["GiaBan"])
                });
            }

            return ds;
        }

        // Số lượng <= 0 thì xóa sản phẩm khỏi giỏ
        public static void CapNhatSoLuong(
            int maKhachHang,
            string maSP,
            int soLuong)
        {
            if (soLuong <= 0)
            {
                Xoa(maKhachHang, maSP);
                return;
            }

            Db.Execute(
                "UPDATE ChiTietGioHang " +
                "SET SoLuong=@sl " +
                "WHERE MaKhachHang=@kh AND MaSP=@sp",

                Db.P("@sl", soLuong),
                Db.P("@kh", maKhachHang),
                Db.P("@sp", maSP)
            );
        }

        public static void Xoa(int maKhachHang, string maSP)
        {
            Db.Execute(
                "DELETE FROM ChiTietGioHang " +
                "WHERE MaKhachHang=@kh AND MaSP=@sp",

                Db.P("@kh", maKhachHang),
                Db.P("@sp", maSP)
            );
        }

        public static void XoaTatCa(int maKhachHang)
        {
            Db.Execute(
                "DELETE FROM ChiTietGioHang " +
                "WHERE MaKhachHang=@kh",

                Db.P("@kh", maKhachHang)
            );
        }

        public static decimal TinhTienHang(
            List<ChiTietGioHang> gio)
        {
            decimal t = 0;

            foreach (ChiTietGioHang c in gio)
                t += c.ThanhTien;

            return t;
        }
    }
}