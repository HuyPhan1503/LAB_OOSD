using System.Data;
using MySql.Data.MySqlClient;
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class DiemThamQuanService
    {
        public DataTable GetDanhSach()
        {
            return Db.Query("CALL sp_Diem_DanhSach();");
        }

        private static void Validate(DiemThamQuan d)
        {
            if (string.IsNullOrWhiteSpace(d.MaDiem)) throw new NghiepVuException("Mã điểm tham quan không được để trống.");
            if (string.IsNullOrWhiteSpace(d.TenDiem)) throw new NghiepVuException("Tên điểm tham quan không được để trống.");
            if (string.IsNullOrWhiteSpace(d.DiaDiem)) throw new NghiepVuException("Địa điểm tham quan không được để trống.");
        }

        public void Them(DiemThamQuan d, string maTour)
        {
            Validate(d);
            Db.Execute("CALL sp_Diem_Them(@p_MaDiem, @p_TenDiem, @p_DiaDiem, @p_NoiDung, @p_YNghia, @p_MaTour);",
                new MySqlParameter("p_MaDiem", d.MaDiem.Trim()),
                new MySqlParameter("p_TenDiem", d.TenDiem.Trim()),
                new MySqlParameter("p_DiaDiem", d.DiaDiem.Trim()),
                new MySqlParameter("p_NoiDung", d.NoiDung),
                new MySqlParameter("p_YNghia", d.YNghia),
                new MySqlParameter("p_MaTour", maTour));
        }

        public void Sua(DiemThamQuan d, string maTour)
        {
            Validate(d);
            Db.Execute("CALL sp_Diem_Sua(@p_MaDiem, @p_TenDiem, @p_DiaDiem, @p_NoiDung, @p_YNghia, @p_MaTour);",
                new MySqlParameter("p_MaDiem", d.MaDiem.Trim()),
                new MySqlParameter("p_TenDiem", d.TenDiem.Trim()),
                new MySqlParameter("p_DiaDiem", d.DiaDiem.Trim()),
                new MySqlParameter("p_NoiDung", d.NoiDung),
                new MySqlParameter("p_YNghia", d.YNghia),
                new MySqlParameter("p_MaTour", maTour));
        }

        public void Xoa(string maDiem)
        {
            Db.Execute("CALL sp_Diem_Xoa(@p_MaDiem);",
                new MySqlParameter("p_MaDiem", maDiem));
        }
    }
}