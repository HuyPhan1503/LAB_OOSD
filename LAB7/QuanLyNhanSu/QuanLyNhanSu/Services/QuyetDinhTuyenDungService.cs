
using System;
using System.Data;
using System.Data.SqlClient;
using LAB07.Data;
using LAB07.Models;

namespace LAB07.Services
{
    public class QuyetDinhTuyenDungService
    {
        // Lấy danh sách quyết định tuyển dụng
        public DataTable GetAll()
        {
            string sql = @"
                SELECT
                    q.MaQuyetDinh,
                    q.MaNhanVien,
                    nv.HoTen,
                    q.MaHoSo,
                    q.MaPhongBan,
                    pb.TenPhongBan,
                    q.NgayKy,
                    q.NgayBatDauThuViec,
                    q.NgayKetThucThuViec,
                    q.LuongThuViec,
                    q.DieuKhoan,
                    q.NguoiKy,
                    q.TrangThai
                FROM QuyetDinhTuyenDung q
                LEFT JOIN NhanVien nv
                    ON q.MaNhanVien = nv.MaNhanVien
                LEFT JOIN PhongBan pb
                    ON q.MaPhongBan = pb.MaPhongBan
                ORDER BY q.MaQuyetDinh DESC";

            return Db.Query(sql);
        }

        // Tìm kiếm theo tên nhân viên, mã nhân viên hoặc phòng ban
        public DataTable Search(string keyword)
        {
            string sql = @"
                SELECT
                    q.MaQuyetDinh,
                    q.MaNhanVien,
                    nv.HoTen,
                    q.MaHoSo,
                    q.MaPhongBan,
                    pb.TenPhongBan,
                    q.NgayKy,
                    q.NgayBatDauThuViec,
                    q.NgayKetThucThuViec,
                    q.LuongThuViec,
                    q.DieuKhoan,
                    q.NguoiKy,
                    q.TrangThai
                FROM QuyetDinhTuyenDung q
                LEFT JOIN NhanVien nv
                    ON q.MaNhanVien = nv.MaNhanVien
                LEFT JOIN PhongBan pb
                    ON q.MaPhongBan = pb.MaPhongBan
                WHERE
                    CONVERT(NVARCHAR(20), q.MaQuyetDinh)
                        LIKE @TuKhoa
                    OR CONVERT(NVARCHAR(20), q.MaNhanVien)
                        LIKE @TuKhoa
                    OR nv.HoTen LIKE @TuKhoa
                    OR pb.TenPhongBan LIKE @TuKhoa
                ORDER BY q.MaQuyetDinh DESC";

            return Db.Query(
                sql,
                Db.Param(
                    "@TuKhoa",
                    SqlDbType.NVarChar,
                    "%" + (keyword ?? "").Trim() + "%"
                )
            );
        }

        // Lấy danh sách nhân viên
        public DataTable GetNhanVien()
        {
            string sql = @"
                SELECT MaNhanVien, HoTen
                FROM NhanVien
                ORDER BY HoTen";

            return Db.Query(sql);
        }

        // Lấy danh sách hồ sơ ứng tuyển
        public DataTable GetHoSoUngTuyen()
        {
            string sql = @"
                SELECT MaHoSo, HoTen
                FROM HoSoUngTuyen
                ORDER BY HoTen";

            return Db.Query(sql);
        }

        // Lấy danh sách phòng ban đang hoạt động
        public DataTable GetPhongBan()
        {
            string sql = @"
                SELECT MaPhongBan, TenPhongBan
                FROM PhongBan
                WHERE TrangThai = 1
                ORDER BY TenPhongBan";

            return Db.Query(sql);
        }

        // Thêm quyết định tuyển dụng
        public int Insert(QuyetDinhTuyenDung q)
        {
            Validate(q);

            string sql = @"
                INSERT INTO QuyetDinhTuyenDung
                (
                    MaNhanVien,
                    MaHoSo,
                    MaPhongBan,
                    NgayKy,
                    NgayBatDauThuViec,
                    NgayKetThucThuViec,
                    LuongThuViec,
                    DieuKhoan,
                    NguoiKy,
                    TrangThai
                )
                VALUES
                (
                    @MaNhanVien,
                    @MaHoSo,
                    @MaPhongBan,
                    @NgayKy,
                    @NgayBatDauThuViec,
                    @NgayKetThucThuViec,
                    @LuongThuViec,
                    @DieuKhoan,
                    @NguoiKy,
                    @TrangThai
                )";

            return Db.Execute(sql, BuildParameters(q));
        }

        // Cập nhật quyết định tuyển dụng
        public int Update(QuyetDinhTuyenDung q)
        {
            if (q.MaQuyetDinh <= 0)
                throw new Exception("Mã quyết định không hợp lệ.");

            Validate(q);

            string sql = @"
                UPDATE QuyetDinhTuyenDung
                SET
                    MaNhanVien = @MaNhanVien,
                    MaHoSo = @MaHoSo,
                    MaPhongBan = @MaPhongBan,
                    NgayKy = @NgayKy,
                    NgayBatDauThuViec = @NgayBatDauThuViec,
                    NgayKetThucThuViec = @NgayKetThucThuViec,
                    LuongThuViec = @LuongThuViec,
                    DieuKhoan = @DieuKhoan,
                    NguoiKy = @NguoiKy,
                    TrangThai = @TrangThai
                WHERE MaQuyetDinh = @MaQuyetDinh";

            return Db.Execute(
                sql,
                CombineParameters(
                    BuildParameters(q),
                    Db.Param(
                        "@MaQuyetDinh",
                        SqlDbType.Int,
                        q.MaQuyetDinh
                    )
                )
            );
        }

        // Xóa quyết định tuyển dụng
        public int Delete(int maQuyetDinh)
        {
            if (maQuyetDinh <= 0)
                throw new Exception("Mã quyết định không hợp lệ.");

            string sql = @"
                DELETE FROM QuyetDinhTuyenDung
                WHERE MaQuyetDinh = @MaQuyetDinh";

            return Db.Execute(
                sql,
                Db.Param(
                    "@MaQuyetDinh",
                    SqlDbType.Int,
                    maQuyetDinh
                )
            );
        }

        // Tạo danh sách tham số SQL
        private SqlParameter[] BuildParameters(
            QuyetDinhTuyenDung q)
        {
            return new SqlParameter[]
            {
                Db.Param(
                    "@MaNhanVien",
                    SqlDbType.Int,
                    q.MaNhanVien
                ),

                Db.Param(
                    "@MaHoSo",
                    SqlDbType.Int,
                    (object)q.MaHoSo ?? DBNull.Value
                ),

                Db.Param(
                    "@MaPhongBan",
                    SqlDbType.VarChar,
                    q.MaPhongBan
                ),

                Db.Param(
                    "@NgayKy",
                    SqlDbType.Date,
                    q.NgayKy.Date
                ),

                Db.Param(
                    "@NgayBatDauThuViec",
                    SqlDbType.Date,
                    q.NgayBatDauThuViec.Date
                ),

                Db.Param(
                    "@NgayKetThucThuViec",
                    SqlDbType.Date,
                    q.NgayKetThucThuViec.Date
                ),

                Db.DecimalParam(
                    "@LuongThuViec",
                    q.LuongThuViec
                ),

                Db.Param(
                    "@DieuKhoan",
                    SqlDbType.NVarChar,
                    (object)q.DieuKhoan ?? DBNull.Value
                ),

                Db.Param(
                    "@NguoiKy",
                    SqlDbType.Int,
                    (object)q.NguoiKy ?? DBNull.Value
                ),

                Db.Param(
                    "@TrangThai",
                    SqlDbType.NVarChar,
                    q.TrangThai
                )
            };
        }

        // Ghép các tham số khi cập nhật
        private SqlParameter[] CombineParameters(
            SqlParameter[] parameters,
            SqlParameter additionalParameter)
        {
            SqlParameter[] result =
                new SqlParameter[parameters.Length + 1];

            Array.Copy(
                parameters,
                result,
                parameters.Length
            );

            result[result.Length - 1] = additionalParameter;

            return result;
        }

        // Kiểm tra dữ liệu
        private void Validate(QuyetDinhTuyenDung q)
        {
            if (q == null)
                throw new Exception(
                    "Dữ liệu quyết định tuyển dụng không hợp lệ.");

            if (q.MaNhanVien <= 0)
                throw new Exception(
                    "Vui lòng chọn nhân viên.");

            if (string.IsNullOrWhiteSpace(q.MaPhongBan))
                throw new Exception(
                    "Vui lòng chọn phòng ban.");

            if (q.NgayKy.Date > q.NgayBatDauThuViec.Date)
                throw new Exception(
                    "Ngày ký không được sau ngày bắt đầu thử việc.");

            if (q.NgayKetThucThuViec.Date
                < q.NgayBatDauThuViec.Date)
                throw new Exception(
                    "Ngày kết thúc thử việc phải sau hoặc bằng ngày bắt đầu.");

            if (q.LuongThuViec < 0)
                throw new Exception(
                    "Lương thử việc không được âm.");

            if (string.IsNullOrWhiteSpace(q.TrangThai))
                throw new Exception(
                    "Vui lòng chọn trạng thái.");
        }
    }
}
