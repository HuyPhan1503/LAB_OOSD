using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Thong tin nhan vien dang dang nhap.</summary>
    public static class Session
    {
        public static int MaNV;
        public static string HoTen = "";
        public static string ChucVu = "";   // TiepNhan | ThuNgan | ChamSocKH | QuanLy
    }

    public partial class FrmLogin : Form
    {
        private TextBox txtUser;
        private TextBox txtPass;

        public FrmLogin()
        {
            Text = "Đăng nhập hệ thống khám bệnh";
            ClientSize = new Size(350, 170);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            UI.Lbl(this, "Tên đăng nhập", 20, 25, 100);
            txtUser = UI.Txt(this, 130, 25, 190);
            UI.Lbl(this, "Mật khẩu", 20, 65, 100);
            txtPass = UI.Txt(this, 130, 65, 190);
            txtPass.UseSystemPasswordChar = true;

            Button btnOk = UI.Btn(this, "Đăng nhập", 130, 110, 100, (s, e) => DangNhap());
            Button btnThoat = UI.Btn(this, "Thoát", 240, 110, 80, (s, e) => { DialogResult = DialogResult.Cancel; });
            AcceptButton = btnOk;
            CancelButton = btnThoat;
        }

        private void DangNhap()
        {
            var dt = Db.Query(
                @"SELECT MaNV, HoTen, ChucVu FROM NHANVIEN
                  WHERE TenDangNhap = @u
                    AND MatKhau COLLATE Latin1_General_CS_AS = @p",
                Db.P("@u", txtUser.Text.Trim()),
                Db.P("@p", txtPass.Text));

            if (dt.Rows.Count == 0)
            {
                UI.Error("Sai tên đăng nhập hoặc mật khẩu.");
                return;
            }

            Session.MaNV = Convert.ToInt32(dt.Rows[0]["MaNV"]);
            Session.HoTen = dt.Rows[0]["HoTen"].ToString();
            Session.ChucVu = dt.Rows[0]["ChucVu"].ToString();
            DialogResult = DialogResult.OK;
        }
    }
}