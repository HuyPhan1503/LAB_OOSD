using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; // Đã đổi sang MySQL Client
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class ChuyenService
    {
        public static readonly string[] TinhTrangs = { "Chưa khởi hành", "Đang diễn ra", "Đã kết thúc", "Đã hủy" };

        private static ChuyenDi Map(DataRow r)
        {
            return new ChuyenDi
            {
                MaChuyen = r.Str("MaChuyen"),
                MaTour = r.Str("MaTour"),
                NgayDi = r.Date("NgayDi"),
                NgayVe = r.Date("NgayVe"),
                TinhTrang = r.Str("TinhTrang"),
                SoKhach = r.Int("SoKhach")
            };
        }

        public DataTable GetDanhSach()
        {
            return Db.Query("CALL sp_Chuyen_DanhSach();");
        }

        /// <summary>Các chuyến còn nhận đăng ký (dùng cho ComboBox ở FrmDangKyKhachLe).</summary>
        public List<ChuyenDi> GetChuyenChuaKhoiHanh()
        {
            var list = new List<ChuyenDi>();
            foreach (DataRow r in Db.Query("SELECT * FROM ChuyenDi WHERE TinhTrang = 'Chưa khởi hành' ORDER BY NgayDi").Rows)
                list.Add(Map(r));
            return list;
        }

        public List<ChuyenDi> GetAll()
        {
            var list = new List<ChuyenDi>();
            foreach (DataRow r in Db.Query("CALL sp_Chuyen_DanhSach();").Rows)
                list.Add(Map(r));
            return list;
        }

        private static void Validate(ChuyenDi c)
        {
            if (string.IsNullOrWhiteSpace(c.MaChuyen)) throw new NghiepVuException("Mã chuyến không được để trống.");
            if (string.IsNullOrWhiteSpace(c.MaTour)) throw new NghiepVuException("Chọn tour.");
            if (c.NgayVe.Date < c.NgayDi.Date) throw new NghiepVuException("Ngày về phải sau hoặc bằng ngày đi.");
        }

        public void Them(ChuyenDi c)
        {
            Validate(c);
            Db.Execute("CALL sp_Chuyen_Them(@p_MaChuyen, @p_MaTour, @p_NgayDi, @p_NgayVe, @p_TinhTrang);",
                new MySqlParameter("p_MaChuyen", c.MaChuyen.Trim()),
                new MySqlParameter("p_MaTour", c.MaTour),
                new MySqlParameter("p_NgayDi", c.NgayDi.Date),
                new MySqlParameter("p_NgayVe", c.NgayVe.Date),
                new MySqlParameter("p_TinhTrang", c.TinhTrang ?? TinhTrangs[0]));
        }

        public void Sua(ChuyenDi c)
        {
            Validate(c);
            Db.Execute("CALL sp_Chuyen_Sua(@p_MaChuyen, @p_MaTour, @p_NgayDi, @p_NgayVe, @p_TinhTrang);",
                new MySqlParameter("p_MaChuyen", c.MaChuyen.Trim()),
                new MySqlParameter("p_MaTour", c.MaTour),
                new MySqlParameter("p_NgayDi", c.NgayDi.Date),
                new MySqlParameter("p_NgayVe", c.NgayVe.Date),
                new MySqlParameter("p_TinhTrang", c.TinhTrang));
        }

        public void Xoa(string maChuyen)
        {
            Db.Execute("CALL sp_Chuyen_Xoa(@p_MaChuyen);",
                new MySqlParameter("p_MaChuyen", maChuyen));
        }
    }
}