using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class DenBuService
    {
        public static readonly string[] MucDos = { "Nhẹ", "Trung bình", "Nặng" };

        public DataTable GetDanhSach()
        {
            return Db.Query("CALL sp_DenBu_DanhSach();");
        }

        /// <summary>Lập phiếu đền bù theo dịch vụ và mức độ thiệt hại (BR08).</summary>
        public void Them(DenBu d)
        {
            if (string.IsNullOrWhiteSpace(d.DichVu)) throw new NghiepVuException("Chọn dịch vụ.");
            if (System.Array.IndexOf(MucDos, d.MucDo) < 0) throw new NghiepVuException("Mức độ thiệt hại không hợp lệ.");
            if (d.SoTienDenBu < 0) throw new NghiepVuException("Số tiền đền bù không hợp lệ.");
            if ((d.MaChuyen == null) == (d.MaDoan == null)) throw new NghiepVuException("Chọn chuyến khách lẻ hoặc đoàn (chỉ một trong hai).");

            Db.Execute("CALL sp_DenBu_Them(@p_MaChuyen, @p_MaDoan, @p_DichVu, @p_MoTa, @p_MucDo, @p_SoTien);",
                new MySqlParameter("p_MaChuyen", d.MaChuyen),
                new MySqlParameter("p_MaDoan", d.MaDoan),
                new MySqlParameter("p_DichVu", d.DichVu.Trim()),
                new MySqlParameter("p_MoTa", d.MoTa),
                new MySqlParameter("p_MucDo", d.MucDo),
                new MySqlParameter("p_SoTien", d.SoTienDenBu));
        }

        public void Xoa(int maDB)
        {
            Db.Execute("CALL sp_DenBu_Xoa(@p_MaDB);",
                new MySqlParameter("p_MaDB", maDB));
        }
    }
}