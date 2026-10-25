
using System;
using System.Data;
using System.Data.SqlClient;
using LAB07.Data;
using LAB07.Models;

namespace LAB07.Services
{
    public class ChucVuService
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT MaChucVu, TenChucVu, PhuCapChucVu, TrangThai
                FROM ChucVu
                ORDER BY MaChucVu";

            return Db.Query(sql);
        }

        public DataTable Search(string keyword)
        {
            string sql = @"
                SELECT MaChucVu, TenChucVu, PhuCapChucVu, TrangThai
                FROM ChucVu
                WHERE MaChucVu LIKE @Keyword
                   OR TenChucVu LIKE @Keyword
                ORDER BY MaChucVu";

            return Db.Query(
                sql,
                Db.Param(
                    "@Keyword",
                    SqlDbType.NVarChar,
                    "%" + (keyword ?? "").Trim() + "%"
                )
            );
        }

        public void Insert(ChucVu chucVu)
        {
            Validate(chucVu);

            string sql = @"
                INSERT INTO ChucVu
                    (MaChucVu, TenChucVu, PhuCapChucVu, TrangThai)
                VALUES
                    (@Ma, @Ten, @PhuCap, @TrangThai)";

            Db.Execute(
                sql,
                Db.Param("@Ma", SqlDbType.VarChar, chucVu.MaChucVu),
                Db.Param("@Ten", SqlDbType.NVarChar, chucVu.TenChucVu),
                Db.DecimalParam("@PhuCap", chucVu.PhuCapChucVu),
                Db.Param("@TrangThai", SqlDbType.Bit, chucVu.TrangThai)
            );
        }

        public void Update(ChucVu chucVu)
        {
            Validate(chucVu);

            string sql = @"
                UPDATE ChucVu
                SET TenChucVu = @Ten,
                    PhuCapChucVu = @PhuCap,
                    TrangThai = @TrangThai
                WHERE MaChucVu = @Ma";

            int rows = Db.Execute(
                sql,
                Db.Param("@Ma", SqlDbType.VarChar, chucVu.MaChucVu),
                Db.Param("@Ten", SqlDbType.NVarChar, chucVu.TenChucVu),
                Db.DecimalParam("@PhuCap", chucVu.PhuCapChucVu),
                Db.Param("@TrangThai", SqlDbType.Bit, chucVu.TrangThai)
            );

            if (rows == 0)
                throw new InvalidOperationException(
                    "Chức vụ không tồn tại hoặc đã bị xóa.");
        }

        public void Delete(string maChucVu)
        {
            if (string.IsNullOrWhiteSpace(maChucVu))
                throw new ArgumentException("Mã chức vụ không hợp lệ.");

            string sql = @"
                DELETE FROM ChucVu
                WHERE MaChucVu = @Ma";

            int rows = Db.Execute(
                sql,
                Db.Param("@Ma", SqlDbType.VarChar, maChucVu.Trim())
            );

            if (rows == 0)
                throw new InvalidOperationException(
                    "Không tìm thấy chức vụ cần xóa.");
        }

        private void Validate(ChucVu chucVu)
        {
            if (chucVu == null)
                throw new ArgumentNullException(nameof(chucVu));

            chucVu.MaChucVu = (chucVu.MaChucVu ?? "").Trim();
            chucVu.TenChucVu = (chucVu.TenChucVu ?? "").Trim();

            if (chucVu.MaChucVu.Length == 0)
                throw new ArgumentException("Vui lòng nhập mã chức vụ.");

            if (chucVu.MaChucVu.Length > 10)
                throw new ArgumentException(
                    "Mã chức vụ không được vượt quá 10 ký tự.");

            if (chucVu.TenChucVu.Length == 0)
                throw new ArgumentException("Vui lòng nhập tên chức vụ.");

            if (chucVu.TenChucVu.Length > 100)
                throw new ArgumentException(
                    "Tên chức vụ không được vượt quá 100 ký tự.");

            if (chucVu.PhuCapChucVu < 0)
                throw new ArgumentException(
                    "Phụ cấp chức vụ không được nhỏ hơn 0.");
        }
    }
}
