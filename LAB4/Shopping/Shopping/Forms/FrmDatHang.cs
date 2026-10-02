using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Shopping.Models;
using Shopping.Services;

namespace Shopping.Forms
{
    public partial class FrmDatHang : Form
    {
        private List<ChiTietGioHang> gio;
        private TextBox txtTen, txtDiaChi, txtDT;
        private ComboBox cboKhuVuc, cboLoaiPhieu, cboLoaiThe;
        private TextBox txtSoThe, txtCSV, txtTenChu;
        private DateTimePicker dtpHetHan;
        private Label lblTienHang, lblPhi, lblLePhi, lblTong;
        private Button btnDat, btnHuy;

        public FrmDatHang(List<ChiTietGioHang> gioHang)
        {
            gio = gioHang;
            TaoGiaoDien();
            LoadDanhMuc();
            Calculate();
        }

        private void TaoGiaoDien()
        {
            Text = "Đặt hàng";
            Size = new Size(700, 520);
            StartPosition = FormStartPosition.CenterParent;

            Label lbl1 = new Label { Text = "Người nhận", Left = 10, Top = 10, Width = 100 };
            txtTen = new TextBox { Left = 120, Top = 10, Width = 400 };
            txtDT = new TextBox { Left = 120, Top = 40, Width = 200 };
            txtDiaChi = new TextBox { Left = 120, Top = 70, Width = 400 };

            Label lblKV = new Label { Text = "Khu vực", Left = 10, Top = 100, Width = 100 };
            cboKhuVuc = new ComboBox { Left = 120, Top = 100, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblLp = new Label { Text = "Loại phiếu", Left = 10, Top = 130, Width = 100 };
            cboLoaiPhieu = new ComboBox { Left = 120, Top = 130, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoaiPhieu.SelectedIndexChanged += (s, e) => Calculate();

            GroupBox gbCard = new GroupBox { Text = "Thanh toán bằng thẻ", Left = 10, Top = 170, Width = 660, Height = 160 };
            Label lblLoaiThe = new Label { Text = "Loại thẻ", Left = 10, Top = 20, Width = 80 };
            cboLoaiThe = new ComboBox { Left = 100, Top = 18, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoaiThe.SelectedIndexChanged += (s, e) => Calculate();

            Label lblSo = new Label { Text = "Số thẻ", Left = 10, Top = 50, Width = 80 };
            txtSoThe = new TextBox { Left = 100, Top = 50, Width = 220 };

            Label lblCSV = new Label { Text = "CSV", Left = 330, Top = 50, Width = 40 };
            txtCSV = new TextBox { Left = 380, Top = 50, Width = 60 };

            Label lblHetHan = new Label { Text = "Hết hạn", Left = 10, Top = 80, Width = 80 };
            dtpHetHan = new DateTimePicker { Left = 100, Top = 80, Width = 120, Format = DateTimePickerFormat.Short };

            Label lblTenChu = new Label { Text = "Tên chủ thẻ", Left = 10, Top = 110, Width = 80 };
            txtTenChu = new TextBox { Left = 100, Top = 110, Width = 300 };

            gbCard.Controls.AddRange(new Control[] { lblLoaiThe, cboLoaiThe, lblSo, txtSoThe, lblCSV, txtCSV, lblHetHan, dtpHetHan, lblTenChu, txtTenChu });

            lblTienHang = new Label { Left = 10, Top = 340, Width = 660, Font = new Font("Segoe UI", 9, FontStyle.Regular) };
            lblPhi = new Label { Left = 10, Top = 360, Width = 660, Font = new Font("Segoe UI", 9, FontStyle.Regular) };
            lblLePhi = new Label { Left = 10, Top = 380, Width = 660, Font = new Font("Segoe UI", 9, FontStyle.Regular) };
            lblTong = new Label { Left = 10, Top = 410, Width = 660, Font = new Font("Segoe UI", 11, FontStyle.Bold) };

            btnDat = new Button { Text = "Đặt hàng", Left = 420, Top = 440, Width = 120 };
            btnDat.Click += BtnDat_Click;
            btnHuy = new Button { Text = "Hủy", Left = 550, Top = 440, Width = 120 };
            btnHuy.Click += (s, e) => DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[] {
                lbl1, txtTen, txtDT, txtDiaChi, lblKV, cboKhuVuc, lblLp, cboLoaiPhieu, gbCard,
                lblTienHang, lblPhi, lblLePhi, lblTong, btnDat, btnHuy
            });
        }

        private void LoadDanhMuc()
        {
            try
            {
                cboKhuVuc.Items.Clear();
                foreach (var kv in DonHangService.LayKhuVuc()) cboKhuVuc.Items.Add(kv);
                if (cboKhuVuc.Items.Count > 0) cboKhuVuc.SelectedIndex = 0;

                cboLoaiPhieu.Items.Clear();
                foreach (var lp in DonHangService.LayLoaiPhieu()) cboLoaiPhieu.Items.Add(lp);
                if (cboLoaiPhieu.Items.Count > 0) cboLoaiPhieu.SelectedIndex = 0;

                cboLoaiThe.Items.Clear();
                foreach (var lt in DonHangService.LayLoaiThe()) cboLoaiThe.Items.Add(lt);
                if (cboLoaiThe.Items.Count > 0) cboLoaiThe.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message); }
        }

        private void Calculate()
        {
            try
            {
                decimal tienHang = GioHangService.TinhTienHang(gio);
                lblTienHang.Text = "Tiền hàng: " + tienHang.ToString("N0") + " đ";

                decimal phi = 0;
                if (cboKhuVuc.SelectedItem is KhuVuc kv && cboLoaiPhieu.SelectedItem is LoaiPhieu lp)
                {
                    phi = DonHangService.TinhPhiGiaoHang(kv.MaKhuVuc, lp.MaLoaiPhieu, tienHang);
                }
                lblPhi.Text = "Phí giao hàng: " + phi.ToString("N0") + " đ";

                decimal lePhi = 0;
                if (cboLoaiThe.SelectedItem is LoaiThe lt) lePhi = lt.LePhi;
                lblLePhi.Text = "Lệ phí thẻ: " + lePhi.ToString("N0") + " đ";

                decimal tong = tienHang + phi + lePhi;
                lblTong.Text = "TỔNG TRỊ GIÁ: " + tong.ToString("N0") + " đ";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tính toán: " + ex.Message); }
        }

        private void BtnDat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!PhienService.DaDangNhap) { MessageBox.Show("Vui lòng đăng nhập."); return; }
                if (string.IsNullOrWhiteSpace(txtTen.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtDT.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtTen.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtDT.Text))
                    { MessageBox.Show("Vui lòng nhập đầy đủ họ tên, địa chỉ, điện thoại người nhận."); return; }
                }

                NguoiNhan nn = new NguoiNhan
                {
                    HoTen = txtTen.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    DienThoai = txtDT.Text.Trim(),
                    MaKhuVuc = (cboKhuVuc.SelectedItem as KhuVuc)?.MaKhuVuc ?? 0
                };

                LoaiPhieu lp = cboLoaiPhieu.SelectedItem as LoaiPhieu;
                LoaiThe lt = cboLoaiThe.SelectedItem as LoaiThe;
                ThongTinThe the = new ThongTinThe
                {
                    MaLoaiThe = lt.MaLoaiThe,
                    SoThe = txtSoThe.Text?.Trim(),
                    CSV = txtCSV.Text?.Trim(),
                    NgayHetHan = dtpHetHan.Value,
                    TenChuThe = txtTenChu.Text?.Trim()
                };

                // call service to create order
                DonHang don = DonHangService.DatHang(PhienService.KhachHienTai, nn, lp, lt, the, gio);
                MessageBox.Show("Đặt hàng thành công. Mã đơn: " + don.MaDonHang);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex) { MessageBox.Show("Không thể đặt hàng: " + ex.Message); }
            catch (Exception ex) { MessageBox.Show("Lỗi khi đặt hàng: " + ex.Message); }
        }
    }
}