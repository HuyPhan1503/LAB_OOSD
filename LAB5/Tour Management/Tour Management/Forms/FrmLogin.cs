using System;
using System.Windows.Forms;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmLogin : Form
    {
        /// <summary>Vai trò đăng nhập, FrmMain dùng để phân quyền menu.</summary>
        public string VaiTro { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            cboVaiTro.SelectedIndex = 0;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var tk = AuthService.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text, cboVaiTro.Text);
                if (tk == null)
                {
                    MessageBox.Show("Sai tên đăng nhập, mật khẩu hoặc vai trò.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                VaiTro = tk.VaiTro;
                DialogResult = DialogResult.OK;
            });
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
