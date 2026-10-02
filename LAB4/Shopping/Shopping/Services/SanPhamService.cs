using System;
using System.Collections.Generic;
using System.Data;
using Shopping.Data;
using Shopping.Models;

namespace Shopping.Services
{
    public static class SanPhamService
    {
        public static List<NhomSanPham> LayNhom()
        {
            List<NhomSanPham> ds = new List<NhomSanPham>();
            foreach (DataRow r in Db.Query("SELECT MaNhomSP, TenNhomSP FROM NhomSanPham ORDER BY TenNhomSP").Rows)
                ds.Add(new NhomSanPham { MaNhomSP = Convert.ToInt32(r["MaNhomSP"]), TenNhomSP = r["TenNhomSP"] as string });
            return ds;
        }

        // maNhom = null -> tat ca nhom; tuKhoa rong -> khong loc theo ten
        public static List<SanPham> Lay(int? maNhom, string tuKhoa)
        {
            string kw = string.IsNullOrWhiteSpace(tuKhoa) ? null : "%" + tuKhoa.Trim() + "%";

            // Trong MySQL, so sánh với NULL trong hàm lọc nên dùng IFNULL hoặc COALESCE để tránh lỗi kiểm tra NULL
            DataTable dt = Db.Query(
                "SELECT sp.*, n.TenNhomSP FROM SanPham sp JOIN NhomSanPham n ON n.MaNhomSP = sp.MaNhomSP " +
                "WHERE (@nhom IS NULL OR sp.MaNhomSP = @nhom) AND (@kw IS NULL OR sp.TenSP LIKE @kw) ORDER BY sp.TenSP",
                Db.P("@nhom", maNhom.HasValue ? (object)maNhom.Value : DBNull.Value),
                Db.P("@kw", kw != null ? (object)kw : DBNull.Value));

            List<SanPham> ds = new List<SanPham>();
            foreach (DataRow r in dt.Rows) ds.Add(Map(r));
            return ds;
        }

        public static SanPham LayTheoMa(string maSP)
        {
            DataTable dt = Db.Query(
                "SELECT sp.*, n.TenNhomSP FROM SanPham sp JOIN NhomSanPham n ON n.MaNhomSP = sp.MaNhomSP WHERE sp.MaSP=@ma",
                Db.P("@ma", maSP));
            return dt.Rows.Count == 0 ? null : Map(dt.Rows[0]);
        }

        private static SanPham Map(DataRow r)
        {
            return new SanPham
            {
                MaSP = r["MaSP"] as string,
                TenSP = r["TenSP"] as string,
                NhaSanXuat = r["NhaSanXuat"] as string,
                HinhAnh = r["HinhAnh"] as string,
                MoTa = r["MoTa"] as string,
                ThongSoKT = r["ThongSoKT"] as string,
                GiaBan = Convert.ToDecimal(r["GiaBan"]),
                CoHang = Convert.ToBoolean(r["CoHang"]),
                MaNhomSP = Convert.ToInt32(r["MaNhomSP"]),
                TenNhomSP = r["TenNhomSP"] as string
            };
        }
    }
}