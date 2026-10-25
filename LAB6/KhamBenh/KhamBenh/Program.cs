using System;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string error;
            if (!Db.TestConnection(out error))
            {
                MessageBox.Show("Không kết nối được CSDL:\n" + error + "\n\nHãy kiểm tra ConnectionString trong db.cs.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK) return;
            }

            Application.Run(new FrmMain());
        }
    }
}