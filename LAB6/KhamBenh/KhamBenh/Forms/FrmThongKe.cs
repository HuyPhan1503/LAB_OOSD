using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Thong ke theo khoang thoi gian (BR09).</summary>
    public partial class FrmThongKe : Form
    {
        private DateTimePicker dtpTu, dtpDen;
        private DataGridView gridTong, gridKhoa;

        public FrmThongKe()
        {
            Text = "Thống kê";
            ClientSize = new Size(640, 520);

            UI.Lbl(this, "Từ ngày", 20, 20, 60);
            dtpTu = UI.Dtp(this, 85, 20, 130);
            dtpTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            UI.Lbl(this, "Đến ngày", 235, 20, 65);
            dtpDen = UI.Dtp(this, 305, 20, 130);
            UI.Btn(this, "Thống kê", 450, 18, 100, (s, e) => ThongKe());

            UI.Lbl(this, "Tổng hợp", 20, 62, 200);
            gridTong = UI.Grid(this, 20, 87, 600, 150);

            UI.Lbl(this, "Số lượt khám theo khoa", 20, 252, 300);
            gridKhoa = UI.Grid(this, 20, 277, 600, 225);
        }

        private void ThongKe()
        {
            DateTime tu = dtpTu.Value.Date;
            DateTime den = dtpDen.Value.Date.AddDays(1);
            if (tu >= den)
            {
                UI.Error("Khoảng thời gian không hợp lệ.");
                return;
            }

            // Moi lan truy van can bo tham so moi
            SqlParameter[] Ps() { return new[] { Db.P("@tu", tu), Db.P("@den", den) }; }

            int hoSoMoi = Db.Scalar<int>(
                "SELECT COUNT(*) FROM HOSOBENHAN WHERE NgayCap >= @tu AND NgayCap < @den", Ps());
            int khamBenh = Db.Scalar<int>(
                "SELECT COUNT(*) FROM PHIEUKHAM WHERE LoaiKham = 'Benh' AND NgayGioKham >= @tu AND NgayGioKham < @den", Ps());
            int dinhKy = Db.Scalar<int>(
                "SELECT COUNT(*) FROM PHIEUKHAM WHERE LoaiKham = 'DinhKy' AND NgayGioKham >= @tu AND NgayGioKham < @den", Ps());
            decimal lePhi = Db.Scalar<decimal>(
                "SELECT ISNULL(SUM(SoTien), 0) FROM LEPHI WHERE NgayDong >= @tu AND NgayDong < @den", Ps());
            decimal vienPhi = Db.Scalar<decimal>(
                "SELECT ISNULL(SUM(TongTien), 0) FROM HOADON WHERE TrangThai = N'Đã thanh toán' AND NgayLap >= @tu AND NgayLap < @den", Ps());

            var tong = new DataTable();
            tong.Columns.Add("Chỉ tiêu", typeof(string));
            tong.Columns.Add("Giá trị", typeof(string));
            tong.Rows.Add("Hồ sơ bệnh án mới", hoSoMoi.ToString());
            tong.Rows.Add("Lượt khám bệnh", khamBenh.ToString());
            tong.Rows.Add("Lượt khám sức khỏe định kỳ", dinhKy.ToString());
            tong.Rows.Add("Doanh thu lệ phí", UI.Money(lePhi));
            tong.Rows.Add("Doanh thu viện phí", UI.Money(vienPhi));
            gridTong.DataSource = tong;

            gridKhoa.DataSource = Db.Query(
                @"SELECT k.TenKhoa AS [Khoa], COUNT(pk.MaPK) AS [Số lượt khám]
                  FROM KHOA k
                  LEFT JOIN PHIEUKHAM pk ON pk.MaKhoa = k.MaKhoa AND pk.NgayGioKham >= @tu AND pk.NgayGioKham < @den
                  GROUP BY k.TenKhoa
                  ORDER BY COUNT(pk.MaPK) DESC", Ps());
        }
    }
}