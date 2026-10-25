using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Gia han le phi hang nam.</summary>
    public partial class FrmGiaHanLePhi : Form
    {
        private TextBox txtMaHS;
        private Label lblHoTen, lblHan;
        private NumericUpDown numLePhi;
        private DataGridView grid;
        private int _maHS;
        private DateTime _hetHan;

        public FrmGiaHanLePhi()
        {
            Text = "Gia hạn lệ phí hằng năm";
            ClientSize = new Size(620, 440);

            UI.Lbl(this, "Mã hồ sơ", 20, 20);
            txtMaHS = UI.Txt(this, 130, 20, 100);
            UI.Btn(this, "Tìm", 240, 18, 80, (s, e) => Tim());

            UI.Lbl(this, "Bệnh nhân", 20, 58);
            lblHoTen = UI.Val(this, 130, 58, 450, true);
            UI.Lbl(this, "Hiệu lực đến", 20, 86);
            lblHan = UI.Val(this, 130, 86, 450);

            UI.Lbl(this, "Lệ phí 1 năm", 20, 120);
            numLePhi = UI.Num(this, 130, 120, 150, 0, 100000000, 200000, 10000);
            UI.Btn(this, "Gia hạn thêm 1 năm", 300, 118, 160, (s, e) => GiaHan());

            UI.Lbl(this, "Lịch sử đóng lệ phí", 20, 160, 200);
            grid = UI.Grid(this, 20, 185, 580, 235);
        }

        private void Tim()
        {
            int m;
            if (!int.TryParse(txtMaHS.Text.Trim(), out m))
            {
                UI.Error("Mã hồ sơ phải là số.");
                return;
            }

            var dt = Db.Query(
                @"SELECT p.HoTen, h.NgayHetHan
                  FROM HOSOBENHAN h JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu
                  WHERE h.MaHS = @m", Db.P("@m", m));

            if (dt.Rows.Count == 0)
            {
                _maHS = 0;
                lblHoTen.Text = "Không tìm thấy hồ sơ.";
                lblHan.Text = "";
                grid.DataSource = null;
                return;
            }

            _maHS = m;
            _hetHan = (DateTime)dt.Rows[0]["NgayHetHan"];
            lblHoTen.Text = dt.Rows[0]["HoTen"].ToString();
            lblHan.Text = _hetHan.ToString("dd/MM/yyyy") +
                (_hetHan.Date >= DateTime.Today ? "  (còn hiệu lực)" : "  (đã hết hạn)");
            LoadLichSu();
        }

        private void LoadLichSu()
        {
            grid.DataSource = Db.Query(
                @"SELECT lp.MaLP AS [Mã LP], lp.NgayDong AS [Ngày đóng], lp.TuNgay AS [Từ ngày],
                         lp.DenNgay AS [Đến ngày], lp.SoTien AS [Số tiền], nv.HoTen AS [Nhân viên thu]
                  FROM LEPHI lp JOIN NHANVIEN nv ON nv.MaNV = lp.MaNV
                  WHERE lp.MaHS = @m ORDER BY lp.NgayDong DESC, lp.MaLP DESC",
                Db.P("@m", _maHS));
        }

        private void GiaHan()
        {
            if (_maHS == 0)
            {
                UI.Error("Hãy nhập mã hồ sơ và bấm Tìm trước.");
                return;
            }

            DateTime tu = _hetHan.Date > DateTime.Today ? _hetHan.Date : DateTime.Today;
            DateTime den = tu.AddYears(1);

            if (!UI.Confirm("Gia hạn từ " + tu.ToString("dd/MM/yyyy") + " đến " + den.ToString("dd/MM/yyyy") +
                            "\nLệ phí: " + UI.Money(numLePhi.Value) + "\n\nXác nhận?"))
                return;

            try
            {
                Db.RunInTransaction((conn, tran) =>
                {
                    Db.Cmd(conn, tran,
                        @"INSERT INTO LEPHI(MaHS, MaNV, TuNgay, DenNgay, SoTien)
                          VALUES(@hs, @nv, @tu, @den, @st)",
                        Db.P("@hs", _maHS), Db.P("@nv", Session.MaNV),
                        Db.P("@tu", tu), Db.P("@den", den),
                        Db.P("@st", numLePhi.Value)).ExecuteNonQuery();

                    Db.Cmd(conn, tran,
                        "UPDATE HOSOBENHAN SET NgayHetHan = @den WHERE MaHS = @hs",
                        Db.P("@den", den), Db.P("@hs", _maHS)).ExecuteNonQuery();
                });

                UI.Info("Gia hạn thành công. Hồ sơ có hiệu lực đến " + den.ToString("dd/MM/yyyy") + ".");
                Tim();
            }
            catch (Exception ex)
            {
                UI.Error("Không gia hạn được: " + ex.Message);
            }
        }
    }
}