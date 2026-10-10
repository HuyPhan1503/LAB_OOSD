using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class NoiDungChanService
    {
        public List<NoiDungChan> GetByTour(string maTour)
        {
            var list = new List<NoiDungChan>();
            var dt = Db.Query("CALL sp_NoiDungChan_DanhSach(@p_MaTour);", new MySqlParameter("p_MaTour", maTour));
            foreach (DataRow r in dt.Rows)
                list.Add(new NoiDungChan
                {
                    MaNoi = r.Int("MaNoi"),
                    MaTour = r.Str("MaTour"),
                    TenNoi = r.Str("TenNoi"),
                    DoiPhuongTien = r.Bool("DoiPhuongTien"),
                    CoNoiAn = r.Bool("CoNoiAn"),
                    CoKhachSan = r.Bool("CoKhachSan"),
                    LoaiKhachSan = r.ByteN("LoaiKhachSan")
                });
            return list;
        }

        public DataTable GetDanhSach(string maTour = null)
        {
            return Db.Query("CALL sp_NoiDungChan_DanhSach(@p_MaTour);", new MySqlParameter("p_MaTour", maTour));
        }

        private static void Validate(NoiDungChan n)
        {
            if (string.IsNullOrWhiteSpace(n.MaTour)) throw new NghiepVuException("Chọn tour.");
            if (string.IsNullOrWhiteSpace(n.TenNoi)) throw new NghiepVuException("Nhập tên nơi dừng chân.");
            if (n.CoKhachSan && (n.LoaiKhachSan == null || n.LoaiKhachSan < 2 || n.LoaiKhachSan > 5))
                throw new NghiepVuException("Loại khách sạn phải từ 2 đến 5 sao.");
        }

        public void Them(NoiDungChan n)
        {
            Validate(n);
            Db.Execute("CALL sp_NoiDungChan_Them(@p_MaTour, @p_TenNoi, @p_DoiPT, @p_CoAn, @p_CoKS, @p_LoaiKS);",
                new MySqlParameter("p_MaTour", n.MaTour),
                new MySqlParameter("p_TenNoi", n.TenNoi.Trim()),
                new MySqlParameter("p_DoiPT", n.DoiPhuongTien),
                new MySqlParameter("p_CoAn", n.CoNoiAn),
                new MySqlParameter("p_CoKS", n.CoKhachSan),
                new MySqlParameter("p_LoaiKS", n.LoaiKhachSan));
        }

        public void Sua(NoiDungChan n)
        {
            Validate(n);
            Db.Execute("CALL sp_NoiDungChan_Sua(@p_MaNoi, @p_TenNoi, @p_DoiPT, @p_CoAn, @p_CoKS, @p_LoaiKS);",
                new MySqlParameter("p_MaNoi", n.MaNoi),
                new MySqlParameter("p_TenNoi", n.TenNoi.Trim()),
                new MySqlParameter("p_DoiPT", n.DoiPhuongTien),
                new MySqlParameter("p_CoAn", n.CoNoiAn),
                new MySqlParameter("p_CoKS", n.CoKhachSan),
                new MySqlParameter("p_LoaiKS", n.LoaiKhachSan));
        }

        public void Xoa(int maNoi)
        {
            Db.Execute("CALL sp_NoiDungChan_Xoa(@p_MaNoi);",
                new MySqlParameter("p_MaNoi", maNoi));
        }
    }
}