using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient; 
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class DangKyKhachLeService
    {
        public List<DiemBanVe> GetDiemBanVe()
        {
            var list = new List<DiemBanVe>();
            foreach (DataRow r in Db.Query("SELECT MaDiemBan, TenDiem, DiaChi FROM DiemBanVe ORDER BY TenDiem").Rows)
                list.Add(new DiemBanVe { MaDiemBan = r.Int("MaDiemBan"), TenDiem = r.Str("TenDiem"), DiaChi = r.Str("DiaChi") });
            return list;
        }

        public DataTable GetDanhSach(string maChuyen = null, string tuKhoa = null)
        {
            return Db.Query("CALL sp_DKLe_DanhSach(@p_MaChuyen, @p_TuKhoa);",
                new MySqlParameter("p_MaChuyen", maChuyen),
                new MySqlParameter("p_TuKhoa", tuKhoa));
        }

        /// <summary>Đăng ký khách lẻ (BR04): đi theo chuyến, thanh toán tiền vé, không đăng ký trùng.</summary>
        public void DangKy(KhachLe k, string maChuyen, int? maDiemBan, string diemDon, decimal soTien)
        {
            if (string.IsNullOrWhiteSpace(k.TenKhach)) throw new NghiepVuException("Nhập tên khách.");
            if (string.IsNullOrWhiteSpace(k.CCCD)) throw new NghiepVuException("Nhập CCCD.");
            if (string.IsNullOrWhiteSpace(maChuyen)) throw new NghiepVuException("Chọn chuyến.");
            if (soTien < 0) throw new NghiepVuException("Số tiền không hợp lệ.");

            Db.Execute("CALL sp_DKLe_Them(@p_TenKhach, @p_CCCD, @p_DiaChi, @p_QuocTich, @p_MaChuyen, @p_MaDiemBan, @p_DiemDon, @p_SoTien);",
                new MySqlParameter("p_TenKhach", k.TenKhach.Trim()),
                new MySqlParameter("p_CCCD", k.CCCD.Trim()),
                new MySqlParameter("p_DiaChi", k.DiaChi),
                new MySqlParameter("p_QuocTich", string.IsNullOrWhiteSpace(k.QuocTich) ? "Việt Nam" : k.QuocTich),
                new MySqlParameter("p_MaChuyen", maChuyen),
                new MySqlParameter("p_MaDiemBan", maDiemBan),
                new MySqlParameter("p_DiemDon", diemDon),
                new MySqlParameter("p_SoTien", soTien));
        }
    }
}