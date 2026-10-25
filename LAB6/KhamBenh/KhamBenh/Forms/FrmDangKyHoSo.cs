using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Dang ky ho so benh an (phieu dang ky + cap ma ho so + thu le phi nam dau).</summary>
    public partial class FrmDangKyHoSo : Form
    {
        private TextBox txtHoTen, txtDiaChi, txtDienThoai, txtCCCD, txtBHYT, txtAnh;
        private DateTimePicker dtpNgaySinh;
        private NumericUpDown numLePhi;

        public FrmDangKyHoSo()
        {
            Text = "Đăng ký hồ sơ bệnh án";
            ClientSize = new Size(560, 410);

            int y = 20;
            UI.Lbl(this, "Họ tên", 20, y);
            txtHoTen = UI.Txt(this, 140, y, 380); y += 36;

            UI.Lbl(this, "Địa chỉ", 20, y);
            txtDiaChi = UI.Txt(this, 140, y, 380); y += 36;

            UI.Lbl(this, "Ngày sinh", 20, y);
            dtpNgaySinh = UI.Dtp(this, 140, y, 150);
            dtpNgaySinh.Value = new DateTime(1990, 1, 1); y += 36;

            UI.Lbl(this, "Điện thoại", 20, y);
            txtDienThoai = UI.Txt(this, 140, y, 150);
            txtDienThoai.MaxLength = 11; y += 36;

            UI.Lbl(this, "CCCD (12 số)", 20, y);
            txtCCCD = UI.Txt(this, 140, y, 150);
            txtCCCD.MaxLength = 12; y += 36;

            UI.Lbl(this, "Số BHYT", 20, y);
            txtBHYT = UI.Txt(this, 140, y, 150);
            txtBHYT.MaxLength = 15; y += 36;

            UI.Lbl(this, "Ảnh 3x4", 20, y);
            txtAnh = UI.Txt(this, 140, y, 280);
            txtAnh.ReadOnly = true;
            UI.Btn(this, "Chọn...", 430, y - 2, 90, (s, e) => ChonAnh()); y += 36;

            UI.Lbl(this, "Lệ phí năm đầu", 20, y);
            numLePhi = UI.Num(this, 140, y, 150, 0, 100000000, 200000, 10000); y += 50;

            UI.Btn(this, "Lưu & cấp hồ sơ", 140, y, 140, (s, e) => Luu());
            UI.Btn(this, "Làm mới", 290, y, 100, (s, e) => LamMoi());
        }

        private void ChonAnh()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (dlg.ShowDialog() == DialogResult.OK) txtAnh.Text = dlg.FileName;
            }
        }

        private void LamMoi()
        {
            txtHoTen.Clear(); txtDiaChi.Clear(); txtDienThoai.Clear();
            txtCCCD.Clear(); txtBHYT.Clear(); txtAnh.Clear();
            dtpNgaySinh.Value = new DateTime(1990, 1, 1);
            numLePhi.Value = 200000;
            txtHoTen.Focus();
        }

        private void Luu()
        {
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string bhyt = txtBHYT.Text.Trim();

            if (hoTen == "" || diaChi == "" || dienThoai == "")
            {
                UI.Error("Vui lòng nhập đầy đủ họ tên, địa chỉ và điện thoại.");
                return;
            }
            if (!Regex.IsMatch(dienThoai, @"^\d{9,11}$"))
            {
                UI.Error("Số điện thoại phải gồm 9 đến 11 chữ số.");
                return;
            }
            if (!Regex.IsMatch(cccd, @"^\d{12}$"))
            {
                UI.Error("CCCD phải gồm đúng 12 chữ số.");
                return;
            }
            if (dtpNgaySinh.Value.Date >= DateTime.Today)
            {
                UI.Error("Ngày sinh phải nhỏ hơn ngày hiện tại.");
                return;
            }
            if (Db.Scalar<int>("SELECT COUNT(*) FROM PHIEUDANGKY WHERE CCCD = @c", Db.P("@c", cccd)) > 0)
            {
                UI.Error("CCCD này đã có hồ sơ bệnh án trong hệ thống.");
                return;
            }

            DateTime today = DateTime.Today;
            DateTime hetHan = today.AddYears(1);
            int maHS = 0;

            try
            {
                Db.RunInTransaction((conn, tran) =>
                {
                    int maPhieu = Convert.ToInt32(Db.Cmd(conn, tran,
                        @"INSERT INTO PHIEUDANGKY(HoTen, DiaChi, NgaySinh, DienThoai, AnhThe3x4, CCCD, SoBHYT)
                          VALUES(@ten, @dc, @ns, @dt, @anh, @cccd, @bhyt);
                          SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        Db.P("@ten", hoTen),
                        Db.P("@dc", diaChi),
                        Db.P("@ns", dtpNgaySinh.Value.Date),
                        Db.P("@dt", dienThoai),
                        Db.P("@anh", string.IsNullOrEmpty(txtAnh.Text) ? null : txtAnh.Text),
                        Db.P("@cccd", cccd),
                        Db.P("@bhyt", bhyt == "" ? null : bhyt)).ExecuteScalar());

                    maHS = Convert.ToInt32(Db.Cmd(conn, tran,
                        @"INSERT INTO HOSOBENHAN(MaPhieu, NgayHetHan) VALUES(@p, @h);
                          SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        Db.P("@p", maPhieu),
                        Db.P("@h", hetHan)).ExecuteScalar());

                    Db.Cmd(conn, tran,
                        @"INSERT INTO LEPHI(MaHS, MaNV, TuNgay, DenNgay, SoTien)
                          VALUES(@hs, @nv, @tu, @den, @st)",
                        Db.P("@hs", maHS),
                        Db.P("@nv", Session.MaNV),
                        Db.P("@tu", today),
                        Db.P("@den", hetHan),
                        Db.P("@st", numLePhi.Value)).ExecuteNonQuery();
                });

                UI.Info("Đã cấp hồ sơ bệnh án.\nMã hồ sơ: " + maHS +
                        "\nHiệu lực đến: " + hetHan.ToString("dd/MM/yyyy"));
                LamMoi();
            }
            catch (Exception ex)
            {
                UI.Error("Không lưu được: " + ex.Message);
            }
        }
    }
}