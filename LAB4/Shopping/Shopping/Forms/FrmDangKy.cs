using System;
using System.Drawing;
using System.Windows.Forms;
using Shopping.Models;
using Shopping.Services;

namespace Shopping.Forms
{
    public partial class FrmDangKy : Form
    {
        private TextBox txtHoTen, txtNS, txtCMND, txtDiaChi, txtDT, txtUser, txtPass, txtEmail;
        private CheckBox chkEmail;
        private Button btnOk, btnCancel;

        public FrmDangKy()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Đăng ký";
            Size = new Size(420, 420);
            StartPosition = FormStartPosition.CenterParent;

            int leftLabel = 10, leftCtrl = 120, top = 10, gap = 30;

            Controls.Add(new Label { Text = "Họ tên", Left = leftLabel, Top = top, Width = 100 });
            txtHoTen = new TextBox { Left = leftCtrl, Top = top, Width = 260 };
            top += gap;

            Controls.Add(new Label { Text = "Ngày sinh", Left = leftLabel, Top = top, Width = 100 });
            txtNS = new TextBox { Left = leftCtrl, Top = top, Width = 120, Text = "01/01/1990" };
            top += gap;

            Controls.Add(new Label { Text = "CMND/Passport", Left = leftLabel, Top = top, Width = 100 });
            txtCMND = new TextBox { Left = leftCtrl, Top = top, Width = 260 };
            top += gap;

            Controls.Add(new Label { Text = "Địa chỉ", Left = leftLabel, Top = top, Width = 100 });
            txtDiaChi = new TextBox { Left = leftCtrl, Top = top, Width = 260 };
            top += gap;

            Controls.Add(new Label { Text = "Điện thoại", Left = leftLabel, Top = top, Width = 100 });
            txtDT = new TextBox { Left = leftCtrl, Top = top, Width = 260 };
            top += gap;

            Controls.Add(new Label { Text = "Tên đăng nhập", Left = leftLabel, Top = top, Width = 100 });
            txtUser = new TextBox { Left = leftCtrl, Top = top, Width = 260 };
            top += gap;

            Controls.Add(new Label { Text = "Mật khẩu", Left = leftLabel, Top = top, Width = 100 });
            txtPass = new TextBox { Left = leftCtrl, Top = top, Width = 260, UseSystemPasswordChar = true };
            top += gap;

            chkEmail = new CheckBox { Text = "Có email", Left = leftCtrl, Top = top, Width = 100 };
            chkEmail.CheckedChanged += (s, e) => txtEmail.Enabled = chkEmail.Checked;
            Controls.Add(chkEmail);

            txtEmail = new TextBox { Left = leftCtrl + 110, Top = top - 2, Width = 170, Enabled = false };
            Controls.Add(txtEmail);
            top += gap;

            btnOk = new Button { Text = "Đăng ký", Left = 180, Top = top, Width = 100 };
            btnOk.Click += BtnOk_Click;
            btnCancel = new Button { Text = "Hủy", Left = 290, Top = top, Width = 90 };
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[] { txtHoTen, txtNS, txtCMND, txtDiaChi, txtDT, txtUser, txtPass, btnOk, btnCancel });
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang kh = new KhachHang
                {
                    HoTen = txtHoTen.Text?.Trim(),
                    NgaySinh = DateTime.TryParse(txtNS.Text, out DateTime d) ? d : DateTime.MinValue,
                    SoCMND = txtCMND.Text?.Trim(),
                    DiaChi = txtDiaChi.Text?.Trim(),
                    DienThoai = txtDT.Text?.Trim(),
                    TenDangNhap = txtUser.Text?.Trim(),
                    MatKhau = txtPass.Text,
                    Email = chkEmail.Checked ? txtEmail.Text?.Trim() : null
                };

                int id = KhachHangService.DangKy(kh); // may throw InvalidOperationException
                // login user after registration
                KhachHang logged = KhachHangService.DangNhap(kh.TenDangNhap, kh.MatKhau);
                PhienService.KhachHienTai = logged;
                MessageBox.Show("Đăng ký thành công.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex) { MessageBox.Show("Không thể đăng ký: " + ex.Message); }
            catch (Exception ex) { MessageBox.Show("Lỗi khi đăng ký: " + ex.Message); }
        }
    }
}