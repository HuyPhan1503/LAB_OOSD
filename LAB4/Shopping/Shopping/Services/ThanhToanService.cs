using System;
using Shopping.Models;

namespace Shopping.Services
{
    // Giả lập "Hệ thống dịch vụ thanh toán trực tuyến".
    // Khi có hệ thống thật, chỉ cần thay nội dung hàm KiemTraThe bằng lời gọi API.
    public static class ThanhToanService
    {
        public const bool KIEM_TRA_LUHN = true;   // đặt false nếu muốn nhập số thẻ bất kỳ khi demo

        // Trả về null nếu hợp lệ, ngược lại trả về thông báo lỗi
        public static string KiemTraThe(LoaiThe loai, ThongTinThe the, decimal soTien)
        {
            if (loai == null) return "Chưa chọn loại thẻ.";
            if (string.IsNullOrWhiteSpace(the.TenChuThe)) return "Họ tên chủ thẻ không được để trống.";

            string so = (the.SoThe ?? "").Replace(" ", "");
            if (!IsDigits(so) || so.Length != loai.DoDaiSoThe)
                return "Số thẻ " + loai.TenLoaiThe + " phải gồm " + loai.DoDaiSoThe + " chữ số.";

            string csv = the.CSV ?? "";
            if (!IsDigits(csv) || csv.Length != loai.DoDaiCSV)
                return "Mã CSV của thẻ " + loai.TenLoaiThe + " phải gồm " + loai.DoDaiCSV + " chữ số.";

            if (the.NgayHetHan < DateTime.Today) return "Thẻ đã hết hạn.";
            if (KIEM_TRA_LUHN && !Luhn(so)) return "Số thẻ không hợp lệ.";
            if (soTien <= 0) return "Số tiền thanh toán không hợp lệ.";
            return null;   // giả lập: thẻ hợp lệ và đủ khả năng thanh toán
        }

        private static bool IsDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            foreach (char c in s) if (c < '0' || c > '9') return false;
            return true;
        }

        private static bool Luhn(string s)
        {
            int sum = 0; bool alt = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int n = s[i] - '0';
                if (alt) { n *= 2; if (n > 9) n -= 9; }
                sum += n; alt = !alt;
            }
            return sum % 10 == 0;
        }
    }
}