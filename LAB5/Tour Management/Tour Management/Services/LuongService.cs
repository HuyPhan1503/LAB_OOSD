using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class LuongService
    {
        /// <summary>Tổng lương = lương cơ bản + lương theo từng tour trong tháng (BR06).</summary>
        public BangLuong Tinh(int maNV, int thang, int nam)
        {
            if (maNV <= 0) throw new NghiepVuException("Chọn nhân viên.");
            if (thang < 1 || thang > 12) throw new NghiepVuException("Tháng không hợp lệ.");

            var dt = Db.Query("CALL sp_Luong_Tinh(@p_MaNV, @p_Thang, @p_Nam);",
                new MySqlParameter("p_MaNV", maNV),
                new MySqlParameter("p_Thang", (byte)thang),
                new MySqlParameter("p_Nam", (short)nam));

            if (dt.Rows.Count == 0) throw new NghiepVuException("Không tìm thấy nhân viên.");
            var r = dt.Rows[0];
            return new BangLuong
            {
                MaNV = maNV,
                Thang = (byte)thang,
                Nam = (short)nam,
                LuongCoBan = r.Dec("LuongCoBan"),
                SoTour = r.Int("SoTour"),
                LuongTheoTour = r.Dec("LuongTheoTour")
            };
        }

        public void Luu(int maNV, int thang, int nam)
        {
            Db.Execute("CALL sp_Luong_Luu(@p_MaNV, @p_Thang, @p_Nam);",
                new MySqlParameter("p_MaNV", maNV),
                new MySqlParameter("p_Thang", (byte)thang),
                new MySqlParameter("p_Nam", (short)nam));
        }

        public DataTable GetBangLuongThang(int thang, int nam)
        {
            return Db.Query(@"SELECT n.HoTen, b.* FROM BangLuong b JOIN NhanVien n ON n.MaNV = b.MaNV
                              WHERE b.Thang = @p_Thang AND b.Nam = @p_Nam ORDER BY n.HoTen",
                new MySqlParameter("p_Thang", (byte)thang),
                new MySqlParameter("p_Nam", (short)nam));
        }
    }
}