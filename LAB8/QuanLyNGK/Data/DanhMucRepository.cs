using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyNGK.Models;

namespace QuanLyNGK.Data
{
    /// <summary>Truy vấn các danh mục dùng cho ComboBox (khóa ngoại).</summary>
    public class DanhMucRepository
    {
        public List<NhanHieu> GetNhanHieu()
        {
            var list = new List<NhanHieu>();
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand("SELECT maLoai, tenLoai FROM NhanHieu ORDER BY tenLoai", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new NhanHieu { MaLoai = rd.GetString(0), TenLoai = rd.GetString(1) });
                }
            }
            return list;
        }

        public List<NhaCungUng> GetNhaCungUng()
        {
            var list = new List<NhaCungUng>();
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand("SELECT maNCU, tenNCU FROM NhaCungUng ORDER BY tenNCU", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new NhaCungUng { MaNCU = rd.GetString(0), TenNCU = rd.GetString(1) });
                }
            }
            return list;
        }

        public List<NhanVien> GetNhanVien()
        {
            var list = new List<NhanVien>();
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand("SELECT maNV, hoTen, chucVu FROM NhanVien ORDER BY maNV", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new NhanVien { MaNV = rd.GetString(0), HoTen = rd.GetString(1), ChucVu = rd.GetString(2) });
                }
            }
            return list;
        }

        public List<KhachHang> GetKhachHang()
        {
            var list = new List<KhachHang>();
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT maKH, tenKH, soDienThoai, loaiKhachHang FROM KhachHang ORDER BY maKH", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new KhachHang
                        {
                            MaKH = rd.GetString(0),
                            TenKH = rd.GetString(1),
                            SoDienThoai = rd.GetString(2),
                            LoaiKhachHang = rd.GetString(3)
                        });
                }
            }
            return list;
        }

        public KhachHang GetKhachHangById(string maKH)
        {
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT maKH, tenKH, soDienThoai, loaiKhachHang FROM KhachHang WHERE maKH = @ma", conn))
            {
                cmd.Parameters.AddWithValue("@ma", maKH);
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return null;
                    return new KhachHang
                    {
                        MaKH = rd.GetString(0),
                        TenKH = rd.GetString(1),
                        SoDienThoai = rd.GetString(2),
                        LoaiKhachHang = rd.GetString(3)
                    };
                }
            }
        }
    }
}
