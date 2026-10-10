using System;
using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class PhanCongService
    {
        public DataTable GetDanhSach(int? maNV = null)
        {
            return Db.Query("CALL sp_PhanCong_DanhSach(@p_MaNV);",
                new MySqlParameter("p_MaNV", maNV));
        }

        /// <summary>
        /// Phân công HDV (BR05, BR10). Chỉ truyền MỘT trong hai: maChuyen (khách lẻ) hoặc maDoan (đoàn).
        /// Lịch chồng chéo và chuyến lẻ đã có HDV sẽ bị CSDL từ chối.
        /// </summary>
        public void PhanCong(int maNV, string maChuyen, int? maDoan, DateTime tuNgay, DateTime denNgay)
        {
            if (maNV <= 0) throw new NghiepVuException("Chọn hướng dẫn viên.");
            if ((maChuyen == null) == (maDoan == null)) throw new NghiepVuException("Chọn chuyến khách lẻ hoặc đoàn (chỉ một trong hai).");
            if (denNgay.Date < tuNgay.Date) throw new NghiepVuException("Khoảng ngày không hợp lệ.");

            Db.Execute("CALL sp_PhanCong_Them(@p_MaNV, @p_MaChuyen, @p_MaDoan, @p_TuNgay, @p_DenNgay);",
                new MySqlParameter("p_MaNV", maNV),
                new MySqlParameter("p_MaChuyen", maChuyen),
                new MySqlParameter("p_MaDoan", maDoan),
                new MySqlParameter("p_TuNgay", tuNgay.Date),
                new MySqlParameter("p_DenNgay", denNgay.Date));
        }

        public void Huy(int maPC)
        {
            Db.Execute("CALL sp_PhanCong_Huy(@p_MaPC);",
                new MySqlParameter("p_MaPC", maPC));
        }
    }
}