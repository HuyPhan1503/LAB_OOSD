using System;
using System.Drawing;
using System.Windows.Forms;
using Shopping.Models;
using Shopping.Services;

namespace Shopping.Forms
{
    public partial class FrmDangNhap : Form
    {
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnOk, btnCancel;

        public FrmDangNhap()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Đăng nhập";
            Size = new Size(380, 200);
            StartPosition = FormStartPosition.CenterParent;
            Label lblUser = new Label { Text = "Tài khoản", Left = 10, Top = 20, Width = 80 };
            txtUser = new TextBox { Left = 100, Top = 18, Width = 240 };
            Label lblPass = new Label { Text = "Mật khẩu", Left = 10, Top = 60, Width = 80 };
            txtPass = new TextBox { Left = 100, Top = 58, Width = 240, UseSystemPasswordChar = true };

            btnOk = new Button { Text = "Đăng nhập", Left = 100, Top = 100, Width = 120 };
            btnOk.Click += BtnOk_Click;
            btnCancel = new Button { Text = "Hủy", Left = 230, Top = 100, Width = 110 };
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[] { lblUser, txtUser, lblPass, txtPass, btnOk, btnCancel });
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string u = txtUser.Text.Trim();
                string p = txtPass.Text;
                if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p)) { MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu."); return; }

                KhachHang kh = KhachHangService.DangNhap(u, p);
                if (kh == null) { MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng."); return; }

                // set session - assumes PhienService exists as in FrmMain
                PhienService.KhachHienTai = kh;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message); }
        }
    }
}