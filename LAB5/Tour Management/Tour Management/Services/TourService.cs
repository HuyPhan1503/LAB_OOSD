using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class TourService
    {
        private static Tour Map(DataRow r)
        {
            return new Tour
            {
                MaTour = r.Str("MaTour"),
                TenTour = r.Str("TenTour"),
                SoNgay = r.Int("SoNgay"),
                SoDem = r.Int("SoDem"),
                DonGia = r.Dec("DonGia"),
                LuongHDV = r.Dec("LuongHDV")
            };
        }

        public List<Tour> GetAll()
        {
            var list = new List<Tour>();
            foreach (DataRow r in Db.Query("SELECT * FROM Tour ORDER BY MaTour").Rows) list.Add(Map(r));
            return list;
        }

        /// <summary>Danh sách hiển thị lên DataGridView (có cột phương tiện).</summary>
        public DataTable GetDanhSachHienThi()
        {
            return Db.Query("CALL sp_Tour_DanhSach();");
        }

        public DataTable TimKiem(string tuKhoa)
        {
            return Db.Query("CALL sp_Tour_TimKiem(@p_TuKhoa);",
                new MySqlParameter("p_TuKhoa", tuKhoa ?? ""));
        }

        public List<PhuongTien> GetPhuongTien()
        {
            var list = new List<PhuongTien>();
            foreach (DataRow r in Db.Query("SELECT MaPT, TenPT FROM PhuongTien ORDER BY TenPT").Rows)
                list.Add(new PhuongTien { MaPT = r.Int("MaPT"), TenPT = r.Str("TenPT") });
            return list;
        }

        private static void Validate(Tour t)
        {
            if (string.IsNullOrWhiteSpace(t.MaTour)) throw new NghiepVuException("Mã tour không được để trống.");
            if (string.IsNullOrWhiteSpace(t.TenTour)) throw new NghiepVuException("Tên tour không được để trống.");
            if (t.SoNgay <= 0) throw new NghiepVuException("Số ngày phải lớn hơn 0.");
            if (t.SoDem < t.SoNgay - 1 || t.SoDem > t.SoNgay) throw new NghiepVuException("Số đêm phải bằng số ngày hoặc số ngày - 1.");
            if (t.DonGia < 0) throw new NghiepVuException("Đơn giá không hợp lệ.");
        }

        public void Them(Tour t, int? maPT)
        {
            Validate(t);
            Db.Execute("CALL sp_Tour_Them(@p_MaTour, @p_TenTour, @p_SoNgay, @p_SoDem, @p_DonGia, @p_MaPT);",
                new MySqlParameter("p_MaTour", t.MaTour.Trim()),
                new MySqlParameter("p_TenTour", t.TenTour.Trim()),
                new MySqlParameter("p_SoNgay", t.SoNgay),
                new MySqlParameter("p_SoDem", t.SoDem),
                new MySqlParameter("p_DonGia", t.DonGia),
                new MySqlParameter("p_MaPT", maPT));
        }

        public void Sua(Tour t, int? maPT)
        {
            Validate(t);
            Db.Execute("CALL sp_Tour_Sua(@p_MaTour, @p_TenTour, @p_SoNgay, @p_SoDem, @p_DonGia, @p_MaPT);",
                new MySqlParameter("p_MaTour", t.MaTour.Trim()),
                new MySqlParameter("p_TenTour", t.TenTour.Trim()),
                new MySqlParameter("p_SoNgay", t.SoNgay),
                new MySqlParameter("p_SoDem", t.SoDem),
                new MySqlParameter("p_DonGia", t.DonGia),
                new MySqlParameter("p_MaPT", maPT));
        }

        public void Xoa(string maTour)
        {
            if (string.IsNullOrWhiteSpace(maTour)) throw new NghiepVuException("Chọn tour cần xóa.");
            Db.Execute("CALL sp_Tour_Xoa(@p_MaTour);",
                new MySqlParameter("p_MaTour", maTour));
        }
    }
}