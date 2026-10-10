using System;
using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;

namespace LAB5.Services
{
    public enum LoaiThongKe
    {
        Tour = 0,
        DichVu = 1,
        SoLuongKhach = 2,
        DoanhThu = 3,
        SoTourNhanVien = 4
    }

    public class ThongKeService
    {
        /// <summary>Thống kê theo khoảng thời gian (BR09). Thứ tự khớp với ComboBox cboLoaiThongKe.</summary>
        public DataTable ThongKe(LoaiThongKe loai, DateTime tuNgay, DateTime denNgay)
        {
            if (denNgay.Date < tuNgay.Date) throw new NghiepVuException("Khoảng thời gian không hợp lệ.");

            return Db.Query("CALL sp_ThongKe(@p_Loai, @p_TuNgay, @p_DenNgay);",
                new MySqlParameter("p_Loai", (int)loai),
                new MySqlParameter("p_TuNgay", tuNgay.Date),
                new MySqlParameter("p_DenNgay", denNgay.Date));
        }
    }
}