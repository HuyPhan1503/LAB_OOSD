using MySql.Data.MySqlClient; // Đã đổi sang MySQL Client
using LAB5.Data;
using LAB5.Models;

namespace LAB5.Services
{
    public static class AuthService
    {
        /// <summary>Tài khoản đang đăng nhập (dùng để phân quyền).</summary>
        public static TaiKhoan CurrentUser { get; private set; }

        public static TaiKhoan DangNhap(string tenDangNhap, string matKhau, string vaiTro)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                throw new NghiepVuException("Vui lòng nhập tên đăng nhập và mật khẩu.");

            // Trong MySQL dùng từ khóa CALL thay cho EXEC
            var dt = Db.Query("CALL sp_DangNhap(@p_TenDangNhap, @p_MatKhau, @p_VaiTro);",
                new MySqlParameter("p_TenDangNhap", tenDangNhap.Trim()),
                new MySqlParameter("p_MatKhau", matKhau),
                new MySqlParameter("p_VaiTro", vaiTro));

            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            CurrentUser = new TaiKhoan
            {
                TenDangNhap = r.Str("TenDangNhap"),
                VaiTro = r.Str("VaiTro"),
                MaNV = r.IntN("MaNV")
            };
            return CurrentUser;
        }

        public static void DangXuat() { CurrentUser = null; }

        public static bool CoVaiTro(params string[] vaiTros)
        {
            if (CurrentUser == null) return false;
            foreach (var v in vaiTros) if (CurrentUser.VaiTro == v) return true;
            return false;
        }
    }
}