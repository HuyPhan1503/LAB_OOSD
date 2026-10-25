using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_KhamBenh
{
    /// <summary>Use case: Lap phieu kham, ke toa thuoc, chi dinh xet nghiem, kham dinh ky.</summary>
    public partial class FrmPhieuKham : Form
    {
        private TextBox txtMaHS, txtTrieuChung, txtKetLuan, txtLieu, txtCach;
        private Label lblHoTen, lblHan;
        private ComboBox cboBS, cboKhoa, cboLoai, cboQuy, cboThuoc;
        private NumericUpDown numNam, numSL;
        private DataGridView gridToa;
        private CheckedListBox clbXN;
        private DataTable dtToa;
        private int _maHS;
        private bool _conHan;

        public FrmPhieuKham()
        {
            Text = "Lập phiếu khám / kê toa";
            ClientSize = new Size(815, 640);

            UI.Lbl(this, "Mã hồ sơ", 15, 15, 90);
            txtMaHS = UI.Txt(this, 110, 15, 100);
            UI.Btn(this, "Tìm", 220, 13, 70, (s, e) => TimHoSo());
            UI.Btn(this, "Xem lý lịch", 295, 13, 100, (s, e) => XemLyLich());
            lblHoTen = UI.Val(this, 410, 15, 390, true);
            lblHan = UI.Val(this, 110, 42, 600);

            UI.Lbl(this, "Bác sĩ", 15, 80, 90);
            cboBS = UI.Cbo(this, 110, 80, 220);
            UI.Lbl(this, "Khoa", 350, 80, 45);
            cboKhoa = UI.Cbo(this, 400, 80, 200);
            UI.Bind(cboBS, Db.Query("SELECT MaBS, HoTen, MaKhoa FROM BACSI ORDER BY HoTen"), "HoTen", "MaBS");
            UI.Bind(cboKhoa, Db.Query("SELECT MaKhoa, TenKhoa FROM KHOA ORDER BY TenKhoa"), "TenKhoa", "MaKhoa");
            cboBS.SelectedIndexChanged += (s, e) => ChonKhoaTheoBS();
            ChonKhoaTheoBS();

            UI.Lbl(this, "Loại khám", 15, 116, 90);
            cboLoai = UI.Cbo(this, 110, 116, 220);
            cboLoai.Items.AddRange(new object[] { "Khám bệnh", "Khám sức khỏe định kỳ" });
            cboLoai.SelectedIndex = 0;
            UI.Lbl(this, "Quý", 350, 116, 45);
            cboQuy = UI.Cbo(this, 400, 116, 60);
            cboQuy.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cboQuy.SelectedIndex = (DateTime.Today.Month - 1) / 3;
            UI.Lbl(this, "Năm", 480, 116, 40);
            numNam = UI.Num(this, 520, 116, 80, 2000, 2100, DateTime.Today.Year);
            numNam.ThousandsSeparator = false;
            cboLoai.SelectedIndexChanged += (s, e) => CapNhatLoai();
            CapNhatLoai();

            UI.Lbl(this, "Triệu chứng", 15, 154, 90);
            txtTrieuChung = UI.TxtMulti(this, 110, 152, 690, 55);
            UI.Lbl(this, "Kết luận", 15, 220, 90);
            txtKetLuan = UI.TxtMulti(this, 110, 218, 690, 45);

            GroupBox gToa = UI.Grp(this, "Toa thuốc", 15, 275, 520, 290);
            UI.Lbl(gToa, "Thuốc", 10, 25, 50);
            cboThuoc = UI.Cbo(gToa, 62, 25, 190);
            UI.Bind(cboThuoc, Db.Query("SELECT MaThuoc, TenThuoc FROM THUOC ORDER BY TenThuoc"), "TenThuoc", "MaThuoc");
            UI.Lbl(gToa, "SL", 258, 25, 25);
            numSL = UI.Num(gToa, 285, 25, 55, 1, 999, 1);
            UI.Btn(gToa, "Thêm", 350, 23, 70, (s, e) => ThemThuoc());
            UI.Btn(gToa, "Xóa dòng", 425, 23, 80, (s, e) => XoaThuoc());
            UI.Lbl(gToa, "Liều", 10, 58, 50);
            txtLieu = UI.Txt(gToa, 62, 58, 190);
            UI.Lbl(gToa, "Cách dùng", 258, 58, 70);
            txtCach = UI.Txt(gToa, 330, 58, 175);

            dtToa = new DataTable();
            dtToa.Columns.Add("MaThuoc", typeof(int));
            dtToa.Columns.Add("TenThuoc", typeof(string));
            dtToa.Columns.Add("SoLuong", typeof(int));
            dtToa.Columns.Add("LieuDung", typeof(string));
            dtToa.Columns.Add("CachDung", typeof(string));
            gridToa = UI.Grid(gToa, 10, 92, 500, 185);
            gridToa.DataSource = dtToa;
            gridToa.Columns["MaThuoc"].Visible = false;
            gridToa.Columns["TenThuoc"].HeaderText = "Tên thuốc";
            gridToa.Columns["SoLuong"].HeaderText = "SL";
            gridToa.Columns["LieuDung"].HeaderText = "Liều dùng";
            gridToa.Columns["CachDung"].HeaderText = "Cách dùng";

            GroupBox gXN = UI.Grp(this, "Chỉ định xét nghiệm", 545, 275, 255, 290);
            clbXN = new CheckedListBox { Left = 10, Top = 25, Width = 235, Height = 255, CheckOnClick = true };
            gXN.Controls.Add(clbXN);
            clbXN.DataSource = Db.Query("SELECT MaXN, TenXN FROM XETNGHIEM ORDER BY TenXN");
            clbXN.DisplayMember = "TenXN";
            clbXN.ValueMember = "MaXN";

            UI.Btn(this, "Lưu phiếu khám", 110, 585, 140, (s, e) => Luu());
            UI.Btn(this, "Làm mới", 260, 585, 100, (s, e) => LamMoi());
        }

        private void ChonKhoaTheoBS()
        {
            var drv = cboBS.SelectedItem as DataRowView;
            if (drv != null && cboKhoa.DataSource != null)
                cboKhoa.SelectedValue = drv["MaKhoa"];
        }

        private void CapNhatLoai()
        {
            bool dinhKy = cboLoai.SelectedIndex == 1;
            cboQuy.Enabled = dinhKy;
            numNam.Enabled = dinhKy;
        }

        private void TimHoSo()
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
                _maHS = 0;
                _conHan = false;
                lblHoTen.Text = "Không tìm thấy hồ sơ.";
                lblHan.Text = "";
                return;
            }
            _maHS = m;
            DateTime han = (DateTime)dt.Rows[0]["NgayHetHan"];
            _conHan = han.Date >= DateTime.Today;
            lblHoTen.Text = dt.Rows[0]["HoTen"].ToString();
            lblHan.Text = "Hiệu lực đến " + han.ToString("dd/MM/yyyy") +
                (_conHan ? "  (còn hiệu lực)" : "  (ĐÃ HẾT HẠN - cần gia hạn lệ phí)");
        }

        private void XemLyLich()
        {
            if (_maHS == 0)
            {
                UI.Error("Hãy nhập mã hồ sơ và bấm Tìm trước.");
                return;
            }
            Form f = new FrmTraCuuHoSo(_maHS.ToString());
            if (MdiParent != null) f.MdiParent = MdiParent;
            f.Show();
        }

        private void ThemThuoc()
        {
            if (cboThuoc.SelectedValue == null) return;
            if (txtLieu.Text.Trim() == "")
            {
                UI.Error("Nhập liều dùng (ví dụ: 2 viên/lần, 3 lần/ngày).");
                return;
            }
            int maThuoc = Convert.ToInt32(cboThuoc.SelectedValue);
            foreach (DataRow r in dtToa.Rows)
            {
                if ((int)r["MaThuoc"] == maThuoc)
                {
                    UI.Error("Thuốc này đã có trong toa.");
                    return;
                }
            }
            string ten = ((DataRowView)cboThuoc.SelectedItem)["TenThuoc"].ToString();
            dtToa.Rows.Add(maThuoc, ten, (int)numSL.Value, txtLieu.Text.Trim(), txtCach.Text.Trim());
            txtLieu.Clear();
            txtCach.Clear();
            numSL.Value = 1;
        }

        private void XoaThuoc()
        {
            if (gridToa.CurrentRow != null)
                dtToa.Rows.RemoveAt(gridToa.CurrentRow.Index);
        }

        private void LamMoi()
        {
            txtMaHS.Clear();
            _maHS = 0;
            _conHan = false;
            lblHoTen.Text = "";
            lblHan.Text = "";
            txtTrieuChung.Clear();
            txtKetLuan.Clear();
            cboLoai.SelectedIndex = 0;
            dtToa.Rows.Clear();
            for (int i = 0; i < clbXN.Items.Count; i++) clbXN.SetItemChecked(i, false);
        }

        private void Luu()
        {
            int tmp;
            if (_maHS == 0 || !int.TryParse(txtMaHS.Text.Trim(), out tmp) || tmp != _maHS)
            {
                UI.Error("Hãy nhập mã hồ sơ và bấm Tìm trước.");
                return;
            }
            if (!_conHan)
            {
                UI.Error("Hồ sơ đã hết hạn lệ phí. Cần gia hạn trước khi khám.");
                return;
            }
            if (cboBS.SelectedValue == null || cboKhoa.SelectedValue == null)
            {
                UI.Error("Chưa chọn bác sĩ hoặc khoa.");
                return;
            }

            bool dinhKy = cboLoai.SelectedIndex == 1;
            if (!dinhKy && txtTrieuChung.Text.Trim() == "")
            {
                UI.Error("Vui lòng nhập triệu chứng.");
                return;
            }

            object quy = null, nam = null;
            if (dinhKy)
            {
                quy = (byte)(cboQuy.SelectedIndex + 1);
                nam = (short)numNam.Value;
                int daKham = Db.Scalar<int>(
                    "SELECT COUNT(*) FROM PHIEUKHAM WHERE MaHS=@h AND LoaiKham='DinhKy' AND Nam=@n AND Quy=@q",
                    Db.P("@h", _maHS), Db.P("@n", nam), Db.P("@q", quy));
                if (daKham > 0)
                {
                    UI.Error("Hồ sơ này đã khám định kỳ quý " + quy + " năm " + nam + ".");
                    return;
                }
            }

            int maPK = 0;
            try
            {
                Db.RunInTransaction((conn, tran) =>
                {
                    maPK = Convert.ToInt32(Db.Cmd(conn, tran,
                        @"INSERT INTO PHIEUKHAM(MaHS, MaBS, MaKhoa, NgayGioKham, LoaiKham, Quy, Nam, TrieuChung, KetLuan)
                          VALUES(@hs, @bs, @kh, GETDATE(), @loai, @q, @n, @tc, @kl);
                          SELECT CAST(SCOPE_IDENTITY() AS INT);",
                        Db.P("@hs", _maHS),
                        Db.P("@bs", Convert.ToInt32(cboBS.SelectedValue)),
                        Db.P("@kh", Convert.ToInt32(cboKhoa.SelectedValue)),
                        Db.P("@loai", dinhKy ? "DinhKy" : "Benh"),
                        Db.P("@q", quy),
                        Db.P("@n", nam),
                        Db.P("@tc", txtTrieuChung.Text.Trim() == "" ? null : txtTrieuChung.Text.Trim()),
                        Db.P("@kl", txtKetLuan.Text.Trim() == "" ? null : txtKetLuan.Text.Trim())).ExecuteScalar());

                    if (dtToa.Rows.Count > 0)
                    {
                        int maToa = Convert.ToInt32(Db.Cmd(conn, tran,
                            "INSERT INTO TOATHUOC(MaPK) VALUES(@pk); SELECT CAST(SCOPE_IDENTITY() AS INT);",
                            Db.P("@pk", maPK)).ExecuteScalar());

                        foreach (DataRow r in dtToa.Rows)
                        {
                            Db.Cmd(conn, tran,
                                @"INSERT INTO CHITIETTOA(MaToa, MaThuoc, SoLuong, LieuDung, CachDung)
                                  VALUES(@t, @m, @sl, @ld, @cd)",
                                Db.P("@t", maToa),
                                Db.P("@m", r["MaThuoc"]),
                                Db.P("@sl", r["SoLuong"]),
                                Db.P("@ld", r["LieuDung"]),
                                Db.P("@cd", r["CachDung"].ToString() == "" ? null : r["CachDung"])).ExecuteNonQuery();
                        }
                    }

                    foreach (DataRowView drv in clbXN.CheckedItems)
                    {
                        Db.Cmd(conn, tran,
                            "INSERT INTO CHITIETXETNGHIEM(MaPK, MaXN) VALUES(@pk, @xn)",
                            Db.P("@pk", maPK), Db.P("@xn", drv["MaXN"])).ExecuteNonQuery();
                    }
                });

                UI.Info("Đã lập phiếu khám. Mã phiếu: " + maPK);
                LamMoi();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                UI.Error("Trùng dữ liệu (bác sĩ đã có ca khám cùng giờ hoặc khám định kỳ trùng quý). Vui lòng thử lại.");
            }
            catch (Exception ex)
            {
                UI.Error("Không lưu được phiếu khám: " + ex.Message);
            }
        }
    }
}