using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Tra cuu ho so benh an (ma ho so, CCCD, so BHYT hoac ho ten) + ly lich kham.</summary>
    public partial class FrmTraCuuHoSo : Form
    {
        private TextBox txtKey;
        private DataGridView gridHS, gridKham;

        public FrmTraCuuHoSo() : this("") { }

        public FrmTraCuuHoSo(string key)
        {
            Text = "Tra cứu hồ sơ bệnh án";
            ClientSize = new Size(860, 560);

            UI.Lbl(this, "Từ khóa", 20, 20, 60);
            txtKey = UI.Txt(this, 85, 20, 300);
            UI.Lbl(this, "(mã hồ sơ / CCCD / số BHYT / họ tên)", 395, 20, 300);
            Button btn = UI.Btn(this, "Tìm", 700, 18, 80, (s, e) => Tim());
            AcceptButton = btn;

            UI.Lbl(this, "Kết quả tìm kiếm", 20, 58, 200);
            gridHS = UI.Grid(this, 20, 83, 820, 170);

            UI.Lbl(this, "Lý lịch khám bệnh của hồ sơ đang chọn", 20, 268, 400);
            gridKham = UI.Grid(this, 20, 293, 820, 245);

            gridHS.SelectionChanged += (s, e) => LoadKham();

            if (!string.IsNullOrEmpty(key))
            {
                txtKey.Text = key;
                Tim();
            }
        }

        private void Tim()
        {
            string k = txtKey.Text.Trim();
            if (k == "")
            {
                UI.Error("Nhập mã hồ sơ, CCCD, số BHYT hoặc họ tên cần tìm.");
                return;
            }

            gridHS.DataSource = Db.Query(
                @"SELECT h.MaHS AS [Mã hồ sơ], p.HoTen AS [Họ tên], p.NgaySinh AS [Ngày sinh],
                         p.DienThoai AS [Điện thoại], p.CCCD AS [CCCD], p.SoBHYT AS [Số BHYT],
                         h.NgayHetHan AS [Hiệu lực đến],
                         CASE WHEN h.NgayHetHan >= CAST(GETDATE() AS DATE) THEN N'Còn hạn' ELSE N'Hết hạn' END AS [Tình trạng]
                  FROM HOSOBENHAN h JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu
                  WHERE CAST(h.MaHS AS VARCHAR(10)) = @k OR p.CCCD = @k OR p.SoBHYT = @k OR p.HoTen LIKE @like
                  ORDER BY p.HoTen",
                Db.P("@k", k), Db.P("@like", "%" + k + "%"));

            if (gridHS.Rows.Count == 0)
            {
                gridKham.DataSource = null;
                UI.Info("Không tìm thấy hồ sơ phù hợp.");
            }
        }

        private void LoadKham()
        {
            if (gridHS.CurrentRow == null || gridHS.CurrentRow.Cells[0].Value == null)
            {
                gridKham.DataSource = null;
                return;
            }

            int maHS = Convert.ToInt32(gridHS.CurrentRow.Cells[0].Value);
            gridKham.DataSource = Db.Query(
                @"SELECT pk.MaPK AS [Mã phiếu], pk.NgayGioKham AS [Ngày giờ khám], bs.HoTen AS [Bác sĩ],
                         k.TenKhoa AS [Khoa],
                         CASE pk.LoaiKham WHEN 'DinhKy' THEN N'Định kỳ' ELSE N'Khám bệnh' END AS [Loại],
                         pk.TrieuChung AS [Triệu chứng], pk.KetLuan AS [Kết luận]
                  FROM PHIEUKHAM pk
                  JOIN BACSI bs ON bs.MaBS = pk.MaBS
                  JOIN KHOA k ON k.MaKhoa = pk.MaKhoa
                  WHERE pk.MaHS = @m ORDER BY pk.NgayGioKham DESC",
                Db.P("@m", maHS));
        }
    }
}