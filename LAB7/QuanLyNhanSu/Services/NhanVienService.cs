
using System;
using System.Data;
using System.Data.SqlClient;
using LAB07.Data;
using LAB07.Models;

namespace LAB07.Services
{
    public class NhanVienService
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT nv.MaNhanVien, nv.HoTen, nv.NgaySinh,
                       nv.GioiTinh, nv.CCCD, nv.DienThoai,
                       nv.Email, nv.TrinhDo, nv.NgayVaoLam,
                       nv.MaPhongBan, pb.TenPhongBan,
                       nv.MaChucVu, cv.TenChucVu, nv.TrangThai,
                       nv.DiaChi
                FROM NhanVien nv
                LEFT JOIN PhongBan pb ON nv.MaPhongBan = pb.MaPhongBan
                LEFT JOIN ChucVu cv ON nv.MaChucVu = cv.MaChucVu
                ORDER BY nv.MaNhanVien DESC";

            return Db.Query(sql);
        }

        public DataTable Search(string keyword)
        {
            string sql = @"
                SELECT nv.MaNhanVien, nv.HoTen, nv.NgaySinh,
                       nv.GioiTinh, nv.CCCD, nv.DienThoai,
                       nv.Email, nv.TrinhDo, nv.NgayVaoLam,
                       nv.MaPhongBan, pb.TenPhongBan,
                       nv.MaChucVu, cv.TenChucVu, nv.TrangThai,
                       nv.DiaChi
                FROM NhanVien nv
                LEFT JOIN PhongBan pb ON nv.MaPhongBan = pb.MaPhongBan
                LEFT JOIN ChucVu cv ON nv.MaChucVu = cv.MaChucVu
                WHERE nv.HoTen LIKE @Keyword
                   OR nv.CCCD LIKE @Keyword
                   OR nv.DienThoai LIKE @Keyword
                   OR nv.Email LIKE @Keyword
                ORDER BY nv.MaNhanVien DESC";

            return Db.Query(
                sql,
                Db.Param(
                    "@Keyword",
                    SqlDbType.NVarChar,
                    "%" + (keyword ?? "").Trim() + "%"
                )
            );
        }

        public void Insert(NhanVien nv)
        {
            Validate(nv);

            string sql = @"
                INSERT INTO NhanVien
                    (HoTen, NgaySinh, GioiTinh, CCCD, DiaChi,
                     DienThoai, Email, TrinhDo, NgayVaoLam,
                     MaPhongBan, MaChucVu, TrangThai)
                VALUES
                    (@HoTen, @NgaySinh, @GioiTinh, @CCCD, @DiaChi,
                     @DienThoai, @Email, @TrinhDo, @NgayVaoLam,
                     @MaPhongBan, @MaChucVu, @TrangThai)";

            Db.Execute(sql, BuildParameters(nv));
        }

        public void Update(NhanVien nv)
        {
            Validate(nv);

            if (nv.MaNhanVien <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ.");

            string sql = @"
                UPDATE NhanVien
                SET HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    CCCD = @CCCD,
                    DiaChi = @DiaChi,
                    DienThoai = @DienThoai,
                    Email = @Email,
                    TrinhDo = @TrinhDo,
                    NgayVaoLam = @NgayVaoLam,
                    MaPhongBan = @MaPhongBan,
                    MaChucVu = @MaChucVu,
                    TrangThai = @TrangThai
                WHERE MaNhanVien = @MaNhanVien";

            SqlParameter[] parameters = BuildParameters(nv);
            Array.Resize(ref parameters, parameters.Length + 1);
            parameters[parameters.Length - 1] =
                Db.Param("@MaNhanVien", SqlDbType.Int, nv.MaNhanVien);

            int rows = Db.Execute(sql, parameters);

            if (rows == 0)
                throw new InvalidOperationException(
                    "Không tìm thấy nhân viên cần cập nhật.");
        }

        public void Delete(int maNhanVien)
        {
            if (maNhanVien <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ.");

            int rows = Db.Execute(
                "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien",
                Db.Param("@MaNhanVien", SqlDbType.Int, maNhanVien)
            );

            if (rows == 0)
                throw new InvalidOperationException(
                    "Không tìm thấy nhân viên cần xóa.");
        }

        public DataTable GetPhongBan()
        {
            return Db.Query(@"
                SELECT MaPhongBan, TenPhongBan
                FROM PhongBan
                WHERE TrangThai = 1
                ORDER BY TenPhongBan");
        }

        public DataTable GetChucVu()
        {
            return Db.Query(@"
                SELECT MaChucVu, TenChucVu
                FROM ChucVu
                WHERE TrangThai = 1
                ORDER BY TenChucVu");
        }

        private SqlParameter[] BuildParameters(NhanVien nv)
        {
            return new SqlParameter[]
            {
                Db.Param("@HoTen", SqlDbType.NVarChar, nv.HoTen),
                Db.Param("@NgaySinh", SqlDbType.Date, nv.NgaySinh.Date),
                Db.Param("@GioiTinh", SqlDbType.NVarChar, nv.GioiTinh),
                Db.Param("@CCCD", SqlDbType.VarChar, nv.CCCD),
                Db.Param("@DiaChi", SqlDbType.NVarChar,
                    (object)nv.DiaChi ?? DBNull.Value),
                Db.Param("@DienThoai", SqlDbType.VarChar,
                    (object)nv.DienThoai ?? DBNull.Value),
                Db.Param("@Email", SqlDbType.VarChar,
                    (object)nv.Email ?? DBNull.Value),
                Db.Param("@TrinhDo", SqlDbType.NVarChar,
                    (object)nv.TrinhDo ?? DBNull.Value),
                Db.Param("@NgayVaoLam", SqlDbType.Date,
                    nv.NgayVaoLam.HasValue
                        ? (object)nv.NgayVaoLam.Value.Date
                        : DBNull.Value),
                Db.Param("@MaPhongBan", SqlDbType.VarChar,
                    (object)nv.MaPhongBan ?? DBNull.Value),
                Db.Param("@MaChucVu", SqlDbType.VarChar,
                    (object)nv.MaChucVu ?? DBNull.Value),
                Db.Param("@TrangThai", SqlDbType.NVarChar, nv.TrangThai)
            };
        }

        private void Validate(NhanVien nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            nv.HoTen = (nv.HoTen ?? "").Trim();
            nv.GioiTinh = (nv.GioiTinh ?? "").Trim();
            nv.CCCD = (nv.CCCD ?? "").Trim();
            nv.DiaChi = (nv.DiaChi ?? "").Trim();
            nv.DienThoai = (nv.DienThoai ?? "").Trim();
            nv.Email = (nv.Email ?? "").Trim();
            nv.TrinhDo = (nv.TrinhDo ?? "").Trim();
            nv.TrangThai = (nv.TrangThai ?? "").Trim();

            if (nv.HoTen.Length == 0)
                throw new ArgumentException("Vui lòng nhập họ tên.");

            if (nv.HoTen.Length > 100)
                throw new ArgumentException(
                    "Họ tên không được vượt quá 100 ký tự.");

            if (nv.NgaySinh.Date >= DateTime.Today)
                throw new ArgumentException(
                    "Ngày sinh phải nhỏ hơn ngày hiện tại.");

            if (nv.GioiTinh.Length == 0)
                throw new ArgumentException("Vui lòng chọn giới tính.");

            if (nv.CCCD.Length == 0)
                throw new ArgumentException("Vui lòng nhập số CCCD.");

            if (nv.CCCD.Length > 20)
                throw new ArgumentException(
                    "Số CCCD không được vượt quá 20 ký tự.");

            if (nv.DienThoai.Length > 15)
                throw new ArgumentException(
                    "Số điện thoại không được vượt quá 15 ký tự.");

            if (nv.Email.Length > 150)
                throw new ArgumentException(
                    "Email không được vượt quá 150 ký tự.");

            if (nv.TrangThai.Length == 0)
                throw new ArgumentException("Vui lòng chọn trạng thái.");

            if (nv.NgayVaoLam.HasValue &&
                nv.NgayVaoLam.Value.Date < nv.NgaySinh.Date)
            {
                throw new ArgumentException(
                    "Ngày vào làm không thể trước ngày sinh.");
            }
        }
    }
}
