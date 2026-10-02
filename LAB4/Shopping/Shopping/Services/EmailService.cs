using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
using Shopping.Models;

namespace eShopping.Services
{
    public static class EmailService
    {
        // Gui email xac nhan don hang. KHONG bao gio nem loi (dat hang da thanh cong roi).
        // KHONG dua thong tin the tin dung vao email.
        public static bool GuiXacNhan(KhachHang kh, DonHang don, NguoiNhan nn, List<ChiTietDonHang> ct)
        {
            try
            {
                if (!kh.CoEmail) return false;
                string host = ConfigurationManager.AppSettings["SmtpHost"];
                if (string.IsNullOrEmpty(host)) return false;   // chua cau hinh SMTP

                int port = 587;
                int.TryParse(ConfigurationManager.AppSettings["SmtpPort"], out port);
                string user = ConfigurationManager.AppSettings["SmtpUser"];
                string pass = ConfigurationManager.AppSettings["SmtpPass"];
                string from = ConfigurationManager.AppSettings["SmtpFrom"] ?? user;

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Cảm ơn " + kh.HoTen + " đã đặt hàng tại e-Shopping.");
                sb.AppendLine("Mã đơn hàng: " + don.MaDonHang);
                sb.AppendLine("Thời điểm đặt: " + don.ThoiDiemDat.ToString("dd/MM/yyyy HH:mm"));
                sb.AppendLine();
                sb.AppendLine("Người nhận: " + nn.HoTen + " - " + nn.DienThoai);
                sb.AppendLine("Địa chỉ: " + nn.DiaChi);
                sb.AppendLine();
                foreach (ChiTietDonHang c in ct)
                    sb.AppendLine(c.TenSP + " x" + c.SoLuong + " @ " + c.DonGia.ToString("N0") + " = " + c.ThanhTien.ToString("N0") + " đ");
                sb.AppendLine();
                sb.AppendLine("Tiền hàng: " + don.TienHang.ToString("N0") + " đ");
                sb.AppendLine("Phí giao hàng: " + don.PhiGiaoHang.ToString("N0") + " đ");
                sb.AppendLine("Lệ phí thẻ: " + don.LePhiThe.ToString("N0") + " đ");
                sb.AppendLine("TỔNG TRỊ GIÁ: " + don.TongTriGia.ToString("N0") + " đ");

                using (MailMessage m = new MailMessage(from, kh.Email, "Xác nhận đơn hàng #" + don.MaDonHang, sb.ToString()))
                using (SmtpClient smtp = new SmtpClient(host, port))
                {
                    smtp.EnableSsl = true;
                    if (!string.IsNullOrEmpty(user)) smtp.Credentials = new NetworkCredential(user, pass);
                    smtp.Send(m);
                }
                return true;
            }
            catch { return false; }
        }
    }
}