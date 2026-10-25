
using System;
using System.Data;
using System.Data.SqlClient;
using LAB07.Data;
using LAB07.Models;

namespace LAB07.Services
{
    public class HoSoUngTuyenService
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT
                    hs.MaHoSo,
                    hs.HoTen,
                    hs.NgaySinh,
                    hs.GioiTinh,
                    hs.CCCD,
                    hs.DiaChi,
                    hs.DienThoai,
                    hs.Email,
                    hs.TrinhDo,
                    hs.ViTriUngTuyen,
                    hs.MaPhongBan,
                    pb.TenPhongBan,
                    hs.NgayUngTuyen,
                    hs.TrangThai
                FROM HoSoUngTuyen hs
                INNER JOIN PhongBan pb
                    ON hs.MaPhongBan = pb.MaPhongBan
                ORDER BY hs.MaHoSo DESC";

            return Db.Query(sql);
        }

        public DataTable Search(string keyword)
        {
            string sql = @"
                SELECT
                    hs.MaHoSo,
                    hs.HoTen,
                    hs.NgaySinh,
                    hs.GioiTinh,
                    hs.CCCD,
                    hs.DiaChi,
                    hs.DienThoai,
                    hs.Email,
                    hs.TrinhDo,
                    hs.ViTriUngTuyen,
                    hs.MaPhongBan,
                    pb.TenPhongBan,
                    hs.NgayUngTuyen,
                    hs.TrangThai
                FROM HoSoUngTuyen hs
                INNER JOIN PhongBan pb
                    ON hs.MaPhongBan = pb.MaPhongBan
                WHERE
                    CAST(hs.MaHoSo AS NVARCHAR(20)) LIKE @Keyword
                    OR hs.HoTen LIKE @Keyword
                    OR hs.CCCD LIKE @Keyword
                    OR hs.DienThoai LIKE @Keyword
                    OR hs.ViTriUngTuyen LIKE @Keyword
                    OR pb.TenPhongBan LIKE @Keyword
                ORDER BY hs.MaHoSo DESC";

            return Db.Query(
                sql,
                new SqlParameter("@Keyword", "%" + (keyword ?? "").Trim() + "%")
            );
        }

        public DataTable GetPhongBan()
        {
            string sql = @"
                SELECT MaPhongBan, TenPhongBan
                FROM PhongBan
                WHERE TrangThai = 1
                ORDER BY TenPhongBan";

            return Db.Query(sql);
        }

        public int Insert(HoSoUngTuyen hs)
        {
            Validate(hs);

            string sql = @"
                INSERT INTO HoSoUngTuyen
                (
                    HoTen,
                    NgaySinh,
                    GioiTinh,
                    CCCD,
                    DiaChi,
                    DienThoai,
                    Email,
                    TrinhDo,
                    ViTriUngTuyen,
                    MaPhongBan,
                    NgayUngTuyen,
                    TrangThai
                )
                VALUES
                (
                    @HoTen,
                    @NgaySinh,
                    @GioiTinh,
                    @CCCD,
                    @DiaChi,
                    @DienThoai,
                    @Email,
                    @TrinhDo,
                    @ViTriUngTuyen,
                    @MaPhongBan,
                    @NgayUngTuyen,
                    @TrangThai
                )";

            return Db.Execute(sql, BuildParameters(hs));
        }

        public int Update(HoSoUngTuyen hs)
        {
            if (hs.MaHoSo <= 0)
                throw new Exception("Mã hồ sơ không hợp lệ.");

            Validate(hs);

            string sql = @"
                UPDATE HoSoUngTuyen
                SET
                    HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    CCCD = @CCCD,
                    DiaChi = @DiaChi,
                    DienThoai = @DienThoai,
                    Email = @Email,
                    TrinhDo = @TrinhDo,
                    ViTriUngTuyen = @ViTriUngTuyen,
                    MaPhongBan = @MaPhongBan,
                    NgayUngTuyen = @NgayUngTuyen,
                    TrangThai = @TrangThai
                WHERE MaHoSo = @MaHoSo";

            SqlParameter[] parameters = BuildParameters(hs);

            Array.Resize(ref parameters, parameters.Length + 1);
            parameters[parameters.Length - 1] =
                new SqlParameter("@MaHoSo", SqlDbType.Int)
                {
                    Value = hs.MaHoSo
                };

            return Db.Execute(sql, parameters);
        }

        public int Delete(int maHoSo)
        {
            if (maHoSo <= 0)
                throw new Exception("Mã hồ sơ không hợp lệ.");

            // Không xóa hồ sơ đã được dùng để lập quyết định tuyển dụng.
            string checkSql = @"
                SELECT COUNT(*)
                FROM QuyetDinhTuyenDung
                WHERE MaHoSo = @MaHoSo";

            object result = Db.Scalar(
                checkSql,
                new SqlParameter("@MaHoSo", SqlDbType.Int)
                {
                    Value = maHoSo
                });

            if (Convert.ToInt32(result) > 0)
            {
                throw new Exception(
                    "Hồ sơ đã được sử dụng trong quyết định tuyển dụng, không thể xóa."
                );
            }

            string sql = @"
                DELETE FROM HoSoUngTuyen
                WHERE MaHoSo = @MaHoSo";

            return Db.Execute(
                sql,
                new SqlParameter("@MaHoSo", SqlDbType.Int)
                {
                    Value = maHoSo
                });
        }

        private SqlParameter[] BuildParameters(HoSoUngTuyen hs)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100)
                {
                    Value = hs.HoTen.Trim()
                },
                new SqlParameter("@NgaySinh", SqlDbType.Date)
                {
                    Value = hs.NgaySinh.Date
                },
                new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 10)
                {
                    Value = hs.GioiTinh
                },
                new SqlParameter("@CCCD", SqlDbType.VarChar, 20)
                {
                    Value = hs.CCCD.Trim()
                },
                new SqlParameter("@DiaChi", SqlDbType.NVarChar, 255)
                {
                    Value = string.IsNullOrWhiteSpace(hs.DiaChi)
                        ? (object)DBNull.Value
                        : hs.DiaChi.Trim()
                },
                new SqlParameter("@DienThoai", SqlDbType.VarChar, 15)
                {
                    Value = string.IsNullOrWhiteSpace(hs.DienThoai)
                        ? (object)DBNull.Value
                        : hs.DienThoai.Trim()
                },
                new SqlParameter("@Email", SqlDbType.VarChar, 150)
                {
                    Value = string.IsNullOrWhiteSpace(hs.Email)
                        ? (object)DBNull.Value
                        : hs.Email.Trim()
                },
                new SqlParameter("@TrinhDo", SqlDbType.NVarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(hs.TrinhDo)
                        ? (object)DBNull.Value
                        : hs.TrinhDo.Trim()
                },
                new SqlParameter("@ViTriUngTuyen", SqlDbType.NVarChar, 100)
                {
                    Value = hs.ViTriUngTuyen.Trim()
                },
                new SqlParameter("@MaPhongBan", SqlDbType.VarChar, 10)
                {
                    Value = hs.MaPhongBan
                },
                new SqlParameter("@NgayUngTuyen", SqlDbType.Date)
                {
                    Value = hs.NgayUngTuyen.Date
                },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 30)
                {
                    Value = hs.TrangThai
                }
            };
        }

        private void Validate(HoSoUngTuyen hs)
        {
            if (hs == null)
                throw new Exception("Thông tin hồ sơ không hợp lệ.");

            if (string.IsNullOrWhiteSpace(hs.HoTen))
                throw new Exception("Vui lòng nhập họ tên.");

            if (hs.NgaySinh.Date >= DateTime.Today)
                throw new Exception("Ngày sinh phải trước ngày hiện tại.");

            if (string.IsNullOrWhiteSpace(hs.GioiTinh))
                throw new Exception("Vui lòng chọn giới tính.");

            if (string.IsNullOrWhiteSpace(hs.CCCD))
                throw new Exception("Vui lòng nhập CCCD.");

            if (hs.CCCD.Trim().Length > 20)
                throw new Exception("CCCD không được vượt quá 20 ký tự.");

            if (string.IsNullOrWhiteSpace(hs.ViTriUngTuyen))
                throw new Exception("Vui lòng nhập vị trí ứng tuyển.");

            if (string.IsNullOrWhiteSpace(hs.MaPhongBan))
                throw new Exception("Vui lòng chọn phòng ban.");

            if (hs.NgayUngTuyen.Date > DateTime.Today)
                throw new Exception("Ngày ứng tuyển không được ở tương lai.");

            if (string.IsNullOrWhiteSpace(hs.TrangThai))
                throw new Exception("Vui lòng chọn trạng thái hồ sơ.");

            if (hs.NgaySinh.Date >= hs.NgayUngTuyen.Date)
                throw new Exception(
                    "Ngày sinh phải trước ngày ứng tuyển."
                );
        }
    }
}
