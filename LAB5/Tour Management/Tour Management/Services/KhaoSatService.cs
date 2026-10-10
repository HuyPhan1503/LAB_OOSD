using System;
using System.Data;
using MySql.Data.MySqlClient;
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class KhaoSatService
    {
        public DataTable GetDanhSach()
        {
            return Db.Query("CALL sp_KhaoSat_DanhSach();");
        }

        /// <summary>Ghi nhận khảo sát sau khi tour kết thúc (BR07).</summary>
        public void Them(KhaoSat k)
        {
            if (string.IsNullOrWhiteSpace(k.TenKhach)) throw new NghiepVuException("Nhập tên khách.");
            if (k.DiemDanhGia < 1 || k.DiemDanhGia > 5) throw new NghiepVuException("Điểm đánh giá từ 1 đến 5.");
            if ((k.MaChuyen == null) == (k.MaDoan == null)) throw new NghiepVuException("Chọn chuyến khách lẻ hoặc đoàn (chỉ một trong hai).");

            Db.Execute("CALL sp_KhaoSat_Them(@p_MaChuyen, @p_MaDoan, @p_TenKhach, @p_Diem, @p_GopY, @p_Ngay);",
                new MySqlParameter("p_MaChuyen", k.MaChuyen),
                new MySqlParameter("p_MaDoan", k.MaDoan),
                new MySqlParameter("p_TenKhach", k.TenKhach.Trim()),
                new MySqlParameter("p_Diem", k.DiemDanhGia),
                new MySqlParameter("p_GopY", k.GopY),
                new MySqlParameter("p_Ngay", k.NgayKhaoSat.Date));
        }

        public void Xoa(int maKS)
        {
            Db.Execute("CALL sp_KhaoSat_Xoa(@p_MaKS);",
                new MySqlParameter("p_MaKS", maKS));
        }
    }
}