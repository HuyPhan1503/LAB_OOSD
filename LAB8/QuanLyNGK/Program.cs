using System;
using System.Windows.Forms;
using QuanLyNGK.UI;

namespace QuanLyNGK
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Form chính: Bán hàng & Lập hóa đơn. Từ đây mở được form Quản lý NGK.
            Application.Run(new frmBanHang());
        }
    }
}
