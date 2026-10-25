using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Xuat vien va thanh toan vien phi. Kham dinh ky mien phi.</summary>
    public partial class FrmThanhToan : Form
    {
        private TextBox txtMaPK;
        private Label lblBN, lblLoai, lblThuoc, lblXN, lblTong;
        private ComboBox cboHT;
        private DateTimePicker dtpXV;
        private DataGridView grid;
        private int _maPK;
        private decimal _tong;

        public FrmThanhToan()
        {
            Text = "Xuất viện & thanh toán viện phí";
            ClientSize = new Size(700, 530);

            UI.Lbl(this, "Mã phiếu khám", 20, 15);
            txtMaPK = UI.Txt(this, 135, 15, 100);
            UI.Btn(this, "Tính tiền", 245, 13, 90, (s, e) => Tinh());

            UI.Lbl(this, "Bệnh nhân", 20, 52); lblBN = UI.Val(this, 135, 52, 500, true);
            UI.Lbl(this, "Loại khám", 20, 78); lblLoai = UI.Val(this, 135, 78, 500);
            UI.Lbl(this, "Tiền thuốc", 20, 104); lblThuoc = UI.Val(this, 135, 104, 300);
            UI.Lbl(this, "Tiền xét nghiệm", 20, 130); lblXN = UI.Val(this, 135, 130, 300);
            UI.Lbl(this, "Tổng thanh toán", 20, 160); lblTong = UI.Val(this, 135, 160, 300, true);

            UI.Lbl(this, "Hình thức TT", 20, 195);
            cboHT = UI.Cbo(this, 135, 195, 150);
            cboHT.Items.AddRange(new object[] { "Tiền mặt", "Thẻ", "Chuyển khoản" });
            cboHT.SelectedIndex = 0;

            UI.Lbl(this, "Ngày xuất viện", 20, 230);
            dtpXV = UI.Dtp(this, 135, 230, 170, true);

            UI.Btn(this, "Thanh toán & xuất viện", 135, 268, 180, (s, e) => ThanhToan());

            UI.Lbl(this, "Phiếu khám chưa thanh toán (bấm đúp để chọn)", 20, 312, 450);
            grid = UI.Grid(this, 20, 337, 660, 170);
            grid.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                txtMaPK.Text = grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                Tinh();
            };
            LoadGrid();
        }

        private void LoadGrid()
        {
            grid.DataSource = Db.Query(
                @"SELECT pk.MaPK AS [Mã phiếu], p.HoTen AS [Bệnh nhân], pk.NgayGioKham AS [Ngày khám],
                         CASE pk.LoaiKham WHEN 'DinhKy' THEN N'Định kỳ' ELSE N'Khám bệnh' END AS [Loại]
                  FROM PHIEUKHAM pk
                  JOIN HOSOBENHAN h ON h.MaHS = pk.MaHS
                  JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu
                  LEFT JOIN HOADON hd ON hd.MaPK = pk.MaPK
                  WHERE hd.MaHD IS NULL
                  ORDER BY pk.NgayGioKham DESC");
        }

        private void Tinh()
        {
            _maPK = 0;
            int m;
            if (!int.TryParse(txtMaPK.Text.Trim(), out m))
            {
                UI.Error("Mã phiếu khám phải là số.");
                return;
            }

            var info = Db.Query(
                @"SELECT pk.LoaiKham, p.HoTen FROM PHIEUKHAM pk
                  JOIN HOSOBENHAN h ON h.MaHS = pk.MaHS
                  JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu
                  WHERE pk.MaPK = @m", Db.P("@m", m));
            if (info.Rows.Count == 0)
            {
                UI.Error("Không tìm thấy phiếu khám.");
                return;
            }
            if (Db.Scalar<int>("SELECT COUNT(*) FROM HOADON WHERE MaPK = @m", Db.P("@m", m)) > 0)
            {
                UI.Error("Phiếu khám này đã được thanh toán.");
                return;
            }

            decimal thuoc = Db.Scalar<decimal>(
                @"SELECT ISNULL(SUM(ct.SoLuong * t.DonGia), 0)
                  FROM TOATHUOC tt
                  JOIN CHITIETTOA ct ON ct.MaToa = tt.MaToa
                  JOIN THUOC t ON t.MaThuoc = ct.MaThuoc
                  WHERE tt.MaPK = @m", Db.P("@m", m));
            decimal xn = Db.Scalar<decimal>(
                @"SELECT ISNULL(SUM(x.DonGia), 0)
                  FROM CHITIETXETNGHIEM c JOIN XETNGHIEM x ON x.MaXN = c.MaXN
                  WHERE c.MaPK = @m", Db.P("@m", m));

            bool dinhKy = info.Rows[0]["LoaiKham"].ToString() == "DinhKy";
            lblBN.Text = info.Rows[0]["HoTen"].ToString();
            lblLoai.Text = dinhKy ? "Khám sức khỏe định kỳ (miễn phí)" : "Khám bệnh";
            lblThuoc.Text = UI.Money(thuoc);
            lblXN.Text = UI.Money(xn);
            _tong = dinhKy ? 0 : thuoc + xn;
            lblTong.Text = UI.Money(_tong);
            _maPK = m;
        }

        private void ThanhToan()
        {
            if (_maPK == 0)
            {
                UI.Error("Hãy nhập mã phiếu khám và bấm Tính tiền trước.");
                return;
            }
            if (!UI.Confirm("Thu " + UI.Money(_tong) + " (" + cboHT.Text + ") và làm thủ tục xuất viện?")) return;

            try
            {
                Db.Execute(
                    @"INSERT INTO HOADON(MaPK, MaNV, TongTien, HinhThucTT, TrangThai, NgayXuatVien)
                      VALUES(@pk, @nv, @tong, @ht, N'Đã thanh toán', @xv)",
                    Db.P("@pk", _maPK), Db.P("@nv", Session.MaNV), Db.P("@tong", _tong),
                    Db.P("@ht", cboHT.Text), Db.P("@xv", dtpXV.Value));

                UI.Info("Đã thanh toán và xuất viện.");
                _maPK = 0;
                txtMaPK.Clear();
                lblBN.Text = lblLoai.Text = lblThuoc.Text = lblXN.Text = lblTong.Text = "";
                LoadGrid();
            }
            catch (Exception ex)
            {
                UI.Error("Không thanh toán được: " + ex.Message);
            }
        }
    }
}