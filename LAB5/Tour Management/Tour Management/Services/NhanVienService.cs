using System.Collections.Generic;
using System.Data;
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public class NhanVienService
    {
        public List<NhanVien> GetAll()
        {
            var list = new List<NhanVien>();
            foreach (DataRow r in Db.Query("SELECT MaNV, HoTen, DienThoai, LuongCoBan FROM NhanVien ORDER BY HoTen").Rows)
                list.Add(new NhanVien { MaNV = r.Int("MaNV"), HoTen = r.Str("HoTen"), DienThoai = r.Str("DienThoai"), LuongCoBan = r.Dec("LuongCoBan") });
            return list;
        }
    }
}
