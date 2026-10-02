using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Shopping.Data;
using Shopping.Models;

namespace Shopping.Services
{
    public static class KhachHangService
    {
        public static string BamMatKhau(string matKhau)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau));
                StringBuilder sb = new StringBuilder();
                foreach (byte x in b) sb.Append(x.ToString("x2"));
                return sb.ToString();
            }
        }

        // Dang nhap dung -> tra ve KhachHang, sai -> null
        public static KhachHang DangNhap(string tenDangNhap, string matKhau)
        {
            DataTable dt = Db.Query(
                "SELECT * FROM KhachHang WHERE TenDangNhap=@u AND MatKhauHash=@h",
                Db.P("@u", tenDangNhap), Db.P("@h", BamMatKhau(matKhau)));
            return dt.Rows.Count == 0 ? null : Map(dt.Rows[0]);
        }

        public static bool TonTaiTenDangNhap(string tenDangNhap)
        {
            object o = Db.Scalar("SELECT COUNT(*) FROM KhachHang WHERE TenDangNhap=@u", Db.P("@u", tenDangNhap));
            return Convert.ToInt32(o) > 0;
        }

        // Dang ky khach hang moi, tra ve MaKhachHang. Loi nghiep vu -> InvalidOperationException
        public static int DangKy(KhachHang kh)
        {
            if (string.IsNullOrWhiteSpace(kh.HoTen)) throw new InvalidOperationException("Họ tên không được để trống.");
            if (string.IsNullOrWhiteSpace(kh.SoCMND)) throw new InvalidOperationException("Số CMND/Passport không được để trống.");
            if (string.IsNullOrWhiteSpace(kh.DiaChi)) throw new InvalidOperationException("Địa chỉ không được để trống.");
            if (string.IsNullOrWhiteSpace(kh.DienThoai)) throw new InvalidOperationException("Điện thoại không được để trống.");
            if (string.IsNullOrWhiteSpace(kh.TenDangNhap)) throw new InvalidOperationException("Tên đăng nhập không được để trống.");
            if (string.IsNullOrEmpty(kh.MatKhau) || kh.MatKhau.Length < 6) throw new InvalidOperationException("Mật khẩu tối thiểu 6 ký tự.");
            if (kh.NgaySinh >= DateTime.Today) throw new InvalidOperationException("Ngày sinh không hợp lệ.");
            if (kh.CoEmail && !kh.Email.Contains("@")) throw new InvalidOperationException("Email không hợp lệ.");
            if (TonTaiTenDangNhap(kh.TenDangNhap)) throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");

            // MySQL: Dùng SELECT LAST_INSERT_ID() thay cho SCOPE_IDENTITY()
            object id = Db.Scalar(
                "INSERT INTO KhachHang(HoTen,NgaySinh,SoCMND,DiaChi,DienThoai,TenDangNhap,MatKhauHash,Email) " +
                "VALUES(@ht,@ns,@cmnd,@dc,@dt,@u,@h,@em); SELECT LAST_INSERT_ID();",
                Db.P("@ht", kh.HoTen.Trim()), Db.P("@ns", kh.NgaySinh), Db.P("@cmnd", kh.SoCMND.Trim()),
                Db.P("@dc", kh.DiaChi.Trim()), Db.P("@dt", kh.DienThoai.Trim()), Db.P("@u", kh.TenDangNhap.Trim()),
                Db.P("@h", BamMatKhau(kh.MatKhau)),
                Db.P("@em", kh.CoEmail ? kh.Email.Trim() : null));

            return Convert.ToInt32(id);
        }

        private static KhachHang Map(DataRow r)
        {
            return new KhachHang
            {
                MaKhachHang = Convert.ToInt32(r["MaKhachHang"]),
                HoTen = r["HoTen"] as string,
                NgaySinh = r["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["NgaySinh"]),
                SoCMND = r["SoCMND"] as string,
                DiaChi = r["DiaChi"] as string,
                DienThoai = r["DienThoai"] as string,
                TenDangNhap = r["TenDangNhap"] as string,
                MatKhauHash = r["MatKhauHash"] as string,
                Email = r["Email"] as string
            };
        }
    }
}