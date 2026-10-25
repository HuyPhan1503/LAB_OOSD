using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Theo doi sau dieu tri (chi ghi sau khi da xuat vien va thanh toan).</summary>
    public partial class FrmTheoDoi : Form
    {
        private DataGridView gridHD, gridLS;
        private TextBox txtDienBien, txtPhanUng, txtHieuQua, txtTrachNhiem;

        public FrmTheoDoi()
        {
            Text = "Theo dõi sau điều trị";
            ClientSize = new Size(800, 600);

            UI.Lbl(this, "Bệnh nhân đã xuất viện & thanh toán", 15, 8, 400);
            gridHD = UI.Grid(this, 15, 33, 770, 130);

            UI.Lbl(this, "Diễn biến bệnh", 15, 178, 120);
            txtDienBien = UI.TxtMulti(this, 140, 175, 645, 45);
            UI.Lbl(this, "Phản ứng phụ", 15, 230, 120);
            txtPhanUng = UI.TxtMulti(this, 140, 227, 645, 45);
            UI.Lbl(this, "Hiệu quả điều trị", 15, 282, 120);
            txtHieuQua = UI.TxtMulti(this, 140, 279, 645, 45);
            UI.Lbl(this, "Trách nhiệm BS", 15, 334, 120);
            txtTrachNhiem = UI.TxtMulti(this, 140, 331, 645, 45);

            UI.Btn(this, "Lưu theo dõi", 140, 386, 120, (s, e) => Luu());

            UI.Lbl(this, "Lịch sử theo dõi của hóa đơn đang chọn", 15, 428, 400);
            gridLS = UI.Grid(this, 15, 453, 770, 130);

            gridHD.SelectionChanged += (s, e) => LoadLichSu();
            LoadHD();
        }

        private int MaHDDangChon()
        {
            if (gridHD.CurrentRow == null || gridHD.CurrentRow.Cells[0].Value == null) return 0;
            return Convert.ToInt32(gridHD.CurrentRow.Cells[0].Value);
        }

        private void LoadHD()
        {
            gridHD.DataSource = Db.Query(
                @"SELECT hd.MaHD AS [Mã HĐ], p.HoTen AS [Bệnh nhân], pk.NgayGioKham AS [Ngày khám],
                         hd.NgayXuatVien AS [Xuất viện],
                         (SELECT COUNT(*) FROM THEODOI td WHERE td.MaHD = hd.MaHD) AS [Số lần theo dõi]
                  FROM HOADON hd
                  JOIN PHIEUKHAM pk ON pk.MaPK = hd.MaPK
                  JOIN HOSOBENHAN h ON h.MaHS = pk.MaHS
                  JOIN PHIEUDANGKY p ON p.MaPhieu = h.MaPhieu
                  WHERE hd.TrangThai = N'Đã thanh toán'
                  ORDER BY hd.NgayLap DESC");
        }

        private void LoadLichSu()
        {
            int maHD = MaHDDangChon();
            if (maHD == 0)
            {
                gridLS.DataSource = null;
                return;
            }
            gridLS.DataSource = Db.Query(
                @"SELECT td.NgayGhiNhan AS [Ngày ghi], nv.HoTen AS [Nhân viên],
                         td.DienBienBenh AS [Diễn biến], td.PhanUngPhu AS [Phản ứng phụ],
                         td.HieuQuaDieuTri AS [Hiệu quả], td.TrachNhiemBacSi AS [Trách nhiệm BS]
                  FROM THEODOI td JOIN NHANVIEN nv ON nv.MaNV = td.MaNV
                  WHERE td.MaHD = @m ORDER BY td.NgayGhiNhan DESC", Db.P("@m", maHD));
        }

        private static object NullIfEmpty(string s)
        {
            s = s.Trim();
            return s == "" ? null : s;
        }

        private void Luu()
        {
            int maHD = MaHDDangChon();
            if (maHD == 0)
            {
                UI.Error("Hãy chọn một hóa đơn trong danh sách.");
                return;
            }
            if (txtDienBien.Text.Trim() == "" && txtPhanUng.Text.Trim() == "" &&
                txtHieuQua.Text.Trim() == "" && txtTrachNhiem.Text.Trim() == "")
            {
                UI.Error("Nhập ít nhất một nội dung theo dõi.");
                return;
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO THEODOI(MaHD, MaNV, DienBienBenh, PhanUngPhu, HieuQuaDieuTri, TrachNhiemBacSi)
                      VALUES(@hd, @nv, @db, @pu, @hq, @tn)",
                    Db.P("@hd", maHD), Db.P("@nv", Session.MaNV),
                    Db.P("@db", NullIfEmpty(txtDienBien.Text)),
                    Db.P("@pu", NullIfEmpty(txtPhanUng.Text)),
                    Db.P("@hq", NullIfEmpty(txtHieuQua.Text)),
                    Db.P("@tn", NullIfEmpty(txtTrachNhiem.Text)));

                txtDienBien.Clear(); txtPhanUng.Clear(); txtHieuQua.Clear(); txtTrachNhiem.Clear();
                UI.Info("Đã ghi nhận theo dõi.");
                LoadHD();
            }
            catch (Exception ex)
            {
                UI.Error("Không lưu được: " + ex.Message);
            }
        }
    }
}