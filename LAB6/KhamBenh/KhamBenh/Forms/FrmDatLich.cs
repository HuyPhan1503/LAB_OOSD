using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Dat lich hen kham (BR06, BR10).</summary>
    public partial class FrmDatLich : Form
    {
        private TextBox txtMaHS;
        private Label lblHoTen;
        private ComboBox cboBS;
        private DateTimePicker dtpGio;
        private DataGridView grid;

        public FrmDatLich()
        {
            Text = "Đặt lịch hẹn khám";
            ClientSize = new Size(760, 480);

            UI.Lbl(this, "Mã hồ sơ", 20, 20);
            txtMaHS = UI.Txt(this, 120, 20, 100);
            UI.Btn(this, "Kiểm tra", 230, 18, 80, (s, e) => KiemTra());
            lblHoTen = UI.Val(this, 320, 20, 400, true);

            UI.Lbl(this, "Bác sĩ", 20, 58);
            cboBS = UI.Cbo(this, 120, 58, 250);
            UI.Bind(cboBS, Db.Query("SELECT MaBS, HoTen FROM BACSI ORDER BY HoTen"), "HoTen", "MaBS");

            UI.Lbl(this, "Ngày giờ hẹn", 20, 96);
            dtpGio = UI.Dtp(this, 120, 96, 170, true);
            dtpGio.Value = DateTime.Now.AddDays(1);

            UI.Btn(this, "Đặt lịch hẹn", 120, 134, 120, (s, e) => Dat());
            UI.Btn(this, "Hủy lịch đang chọn", 250, 134, 150, (s, e) => Huy());

            UI.Lbl(this, "Các lịch hẹn sắp tới", 20, 178, 300);
            grid = UI.Grid(this, 20, 203, 720, 255);
            LoadGrid();
        }

        private void LoadGrid()
        {
            grid.DataSource = Db.Query(
                @"SELECT lh.MaLH AS [Mã hẹn], lh.MaHS AS [Mã hồ sơ], p.HoTen AS [Bệnh nhân],
                         bs.HoTen AS [Bác sĩ], lh.NgayGioHen AS [Giờ hẹn], lh.TrangThai AS [Trạng thái]
                  FROM LICHHEN lh
                  JOIN HOSOBENHAN h ON h.MaHS = lh.MaHS
                  JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu
                  JOIN BACSI bs ON bs.MaBS = lh.MaBS
                  WHERE lh.NgayGioHen >= CAST(GETDATE() AS DATE)
                  ORDER BY lh.NgayGioHen");
        }

        private void KiemTra()
        {
            int m;
            if (!int.TryParse(txtMaHS.Text.Trim(), out m))
            {
                UI.Error("Mã hồ sơ phải là số.");
                return;
            }
            var dt = Db.Query(
                @"SELECT p.HoTen, h.NgayHetHan FROM HOSOBENHAN h
                  JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu WHERE h.MaHS = @m", Db.P("@m", m));
            if (dt.Rows.Count == 0)
            {
                lblHoTen.Text = "Không tìm thấy hồ sơ.";
                return;
            }
            DateTime han = (DateTime)dt.Rows[0]["NgayHetHan"];
            lblHoTen.Text = dt.Rows[0]["HoTen"] + (han.Date >= DateTime.Today ? "" : "  (HẾT HẠN LỆ PHÍ)");
        }

        private void Dat()
        {
            int maHS;
            if (!int.TryParse(txtMaHS.Text.Trim(), out maHS))
            {
                UI.Error("Mã hồ sơ phải là số.");
                return;
            }

            var hs = Db.Query("SELECT NgayHetHan FROM HOSOBENHAN WHERE MaHS = @m", Db.P("@m", maHS));
            if (hs.Rows.Count == 0)
            {
                UI.Error("Không tìm thấy hồ sơ.");
                return;
            }
            if (((DateTime)hs.Rows[0]["NgayHetHan"]).Date < DateTime.Today)
            {
                UI.Error("Hồ sơ đã hết hạn lệ phí. Vui lòng gia hạn trước khi đặt lịch.");
                return;
            }
            if (cboBS.SelectedValue == null)
            {
                UI.Error("Chưa chọn bác sĩ.");
                return;
            }

            DateTime v = dtpGio.Value;
            DateTime gio = new DateTime(v.Year, v.Month, v.Day, v.Hour, v.Minute, 0);
            if (gio <= DateTime.Now)
            {
                UI.Error("Giờ hẹn phải sau thời điểm hiện tại.");
                return;
            }

            try
            {
                Db.Execute(
                    "INSERT INTO LICHHEN(MaHS, MaBS, MaNV, NgayGioHen) VALUES(@hs, @bs, @nv, @g)",
                    Db.P("@hs", maHS),
                    Db.P("@bs", Convert.ToInt32(cboBS.SelectedValue)),
                    Db.P("@nv", Session.MaNV),
                    Db.P("@g", gio));
                UI.Info("Đã đặt lịch hẹn lúc " + gio.ToString("HH:mm dd/MM/yyyy") + ".");
                LoadGrid();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                UI.Error("Bác sĩ này đã có lịch hẹn vào giờ đó. Vui lòng chọn giờ khác.");
            }
            catch (Exception ex)
            {
                UI.Error("Không đặt được lịch: " + ex.Message);
            }
        }

        private void Huy()
        {
            if (grid.CurrentRow == null)
            {
                UI.Error("Chọn lịch hẹn cần hủy.");
                return;
            }
            int maLH = Convert.ToInt32(grid.CurrentRow.Cells[0].Value);
            if (!UI.Confirm("Hủy lịch hẹn mã " + maLH + "?")) return;

            int n = Db.Execute(
                "UPDATE LICHHEN SET TrangThai = N'Hủy' WHERE MaLH = @m AND TrangThai = N'Đã hẹn'",
                Db.P("@m", maLH));
            if (n == 0) UI.Error("Chỉ hủy được lịch đang ở trạng thái 'Đã hẹn'.");
            LoadGrid();
        }
    }
}