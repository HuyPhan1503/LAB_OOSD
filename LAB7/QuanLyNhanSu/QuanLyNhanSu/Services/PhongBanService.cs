
using System;
using System.Data;
using System.Data.SqlClient;
using LAB07.Data;
using LAB07.Models;

namespace LAB07.Services
{
    public class PhongBanService
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT MaPhongBan, TenPhongBan, MoTa, TrangThai
                FROM PhongBan
                ORDER BY MaPhongBan";

            return Db.Query(sql);
        }

        public DataTable Search(string keyword)
        {
            string sql = @"
                SELECT MaPhongBan, TenPhongBan, MoTa, TrangThai
                FROM PhongBan
                WHERE MaPhongBan LIKE @Keyword
                   OR TenPhongBan LIKE @Keyword
                ORDER BY MaPhongBan";

            return Db.Query(
                sql,
                Db.Param("@Keyword", SqlDbType.NVarChar,
                    "%" + (keyword ?? "").Trim() + "%")
            );
        }

        public void Insert(PhongBan phongBan)
        {
            Validate(phongBan);

            string sql = @"
                INSERT INTO PhongBan
                    (MaPhongBan, TenPhongBan, MoTa, TrangThai)
                VALUES
                    (@Ma, @Ten, @MoTa, @TrangThai)";

            Db.Execute(sql,
                Db.Param("@Ma", SqlDbType.VarChar, phongBan.MaPhongBan),
                Db.Param("@Ten", SqlDbType.NVarChar, phongBan.TenPhongBan),
                Db.Param("@MoTa", SqlDbType.NVarChar,
                    (object)phongBan.MoTa ?? DBNull.Value),
                Db.Param("@TrangThai", SqlDbType.Bit, phongBan.TrangThai)
            );
        }

        public void Update(PhongBan phongBan)
        {
            Validate(phongBan);

            string sql = @"
                UPDATE PhongBan
                SET TenPhongBan = @Ten,
                    MoTa = @MoTa,
                    TrangThai = @TrangThai
                WHERE MaPhongBan = @Ma";

            int rows = Db.Execute(sql,
                Db.Param("@Ma", SqlDbType.VarChar, phongBan.MaPhongBan),
                Db.Param("@Ten", SqlDbType.NVarChar, phongBan.TenPhongBan),
                Db.Param("@MoTa", SqlDbType.NVarChar,
                    (object)phongBan.MoTa ?? DBNull.Value),
                Db.Param("@TrangThai", SqlDbType.Bit, phongBan.TrangThai)
            );

            if (rows == 0)
                throw new InvalidOperationException(
                    "Phòng ban không tồn tại hoặc đã bị xóa.");
        }

        public void Delete(string maPhongBan)
        {
            if (string.IsNullOrWhiteSpace(maPhongBan))
                throw new ArgumentException("Mã phòng ban không hợp lệ.");

            string sql = @"
                DELETE FROM PhongBan
                WHERE MaPhongBan = @Ma";

            int rows = Db.Execute(sql,
                Db.Param("@Ma", SqlDbType.VarChar, maPhongBan.Trim())
            );

            if (rows == 0)
                throw new InvalidOperationException(
                    "Không tìm thấy phòng ban cần xóa.");
        }

        private void Validate(PhongBan phongBan)
        {
            if (phongBan == null)
                throw new ArgumentNullException(nameof(phongBan));

            phongBan.MaPhongBan =
                (phongBan.MaPhongBan ?? "").Trim();

            phongBan.TenPhongBan =
                (phongBan.TenPhongBan ?? "").Trim();

            if (phongBan.MaPhongBan.Length == 0)
                throw new ArgumentException("Vui lòng nhập mã phòng ban.");

            if (phongBan.MaPhongBan.Length > 10)
                throw new ArgumentException(
                    "Mã phòng ban không được vượt quá 10 ký tự.");

            if (phongBan.TenPhongBan.Length == 0)
                throw new ArgumentException("Vui lòng nhập tên phòng ban.");

            if (phongBan.TenPhongBan.Length > 100)
                throw new ArgumentException(
                    "Tên phòng ban không được vượt quá 100 ký tự.");

            if (phongBan.MoTa != null && phongBan.MoTa.Length > 255)
                throw new ArgumentException(
                    "Mô tả không được vượt quá 255 ký tự.");
        }
    }
}
