using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNGK.Models;

namespace QuanLyNGK.Data
{
    public class NuocGiaiKhatRepository
    {
        /// <summary>Danh sách NGK kèm tên nhãn hiệu, tên NCC (dùng cho DataGridView).</summary>
        public DataTable GetAll(string keyword)
        {
            const string sql = @"
SELECT n.maNGK, n.tenNGK, n.donViTinh, n.soLuongTon, n.donGiaBan,
       n.maLoai, h.tenLoai, n.maNCU, c.tenNCU
FROM NuocGiaiKhat n
JOIN NhanHieu  h ON n.maLoai = h.maLoai
JOIN NhaCungUng c ON n.maNCU = c.maNCU
WHERE (@kw = N'' OR n.maNGK LIKE @like OR n.tenNGK LIKE @like OR h.tenLoai LIKE @like OR c.tenNCU LIKE @like)
ORDER BY n.maNGK";

            var table = new DataTable();
            using (var conn = Db.CreateConnection())
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@kw", keyword ?? "");
                da.SelectCommand.Parameters.AddWithValue("@like", "%" + (keyword ?? "") + "%");
                da.Fill(table);
            }
            return table;
        }

        /// <summary>Danh sách NGK dạng object (dùng cho ComboBox ở form bán hàng).</summary>
        public List<NuocGiaiKhat> GetList()
        {
            var list = new List<NuocGiaiKhat>();
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand(
                "SELECT maNGK, tenNGK, donViTinh, soLuongTon, donGiaBan, maLoai, maNCU FROM NuocGiaiKhat ORDER BY maNGK", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(new NuocGiaiKhat
                        {
                            MaNGK = rd.GetString(0),
                            TenNGK = rd.GetString(1),
                            DonViTinh = rd.GetString(2),
                            SoLuongTon = rd.GetInt32(3),
                            DonGiaBan = rd.GetDecimal(4),
                            MaLoai = rd.GetString(5),
                            MaNCU = rd.GetString(6)
                        });
                }
            }
            return list;
        }

        public bool Exists(string maNGK)
        {
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM NuocGiaiKhat WHERE maNGK = @ma", conn))
            {
                cmd.Parameters.AddWithValue("@ma", maNGK);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public void Insert(NuocGiaiKhat n)
        {
            const string sql = @"
INSERT INTO NuocGiaiKhat(maNGK, tenNGK, donViTinh, soLuongTon, donGiaBan, maLoai, maNCU)
VALUES (@ma, @ten, @dvt, @ton, @gia, @loai, @ncu)";
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma", n.MaNGK);
                cmd.Parameters.AddWithValue("@ten", n.TenNGK);
                cmd.Parameters.AddWithValue("@dvt", n.DonViTinh);
                cmd.Parameters.AddWithValue("@ton", n.SoLuongTon);
                cmd.Parameters.AddWithValue("@gia", n.DonGiaBan);
                cmd.Parameters.AddWithValue("@loai", n.MaLoai);
                cmd.Parameters.AddWithValue("@ncu", n.MaNCU);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Không cập nhật số lượng tồn: tồn kho chỉ biến động qua phiếu giao hàng / hóa đơn (BR10).</summary>
        public int Update(NuocGiaiKhat n)
        {
            const string sql = @"
UPDATE NuocGiaiKhat
SET tenNGK = @ten, donViTinh = @dvt, donGiaBan = @gia, maLoai = @loai, maNCU = @ncu
WHERE maNGK = @ma";
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ma", n.MaNGK);
                cmd.Parameters.AddWithValue("@ten", n.TenNGK);
                cmd.Parameters.AddWithValue("@dvt", n.DonViTinh);
                cmd.Parameters.AddWithValue("@gia", n.DonGiaBan);
                cmd.Parameters.AddWithValue("@loai", n.MaLoai);
                cmd.Parameters.AddWithValue("@ncu", n.MaNCU);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Ném SqlException (Number 547) nếu NGK đã phát sinh giao dịch.</summary>
        public int Delete(string maNGK)
        {
            using (var conn = Db.CreateConnection())
            using (var cmd = new SqlCommand("DELETE FROM NuocGiaiKhat WHERE maNGK = @ma", conn))
            {
                cmd.Parameters.AddWithValue("@ma", maNGK);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
