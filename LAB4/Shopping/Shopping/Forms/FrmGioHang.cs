using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Shopping.Models;
using Shopping.Services;

namespace Shopping.Forms
{
    public partial class FrmGioHang : Form
    {
        private DataGridView dgv;
        private Button btnCapNhat, btnXoa, btnDatHang, btnDong;
        private Label lblTong;

        private List<ChiTietGioHang> gio;

        public FrmGioHang()
        {
            InitializeComponent();
            TaoGiaoDien();
            LoadGio();
        }

        private void TaoGiaoDien()
        {
            Text = "Giỏ hàng";
            Size = new Size(700, 500);
            StartPosition = FormStartPosition.CenterParent;

            dgv = new DataGridView { Left = 10, Top = 10, Width = 660, Height = 360, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            dgv.CellEndEdit += (s, e) => UpdateTotal();

            btnCapNhat = new Button { Text = "Cập nhật số lượng", Left = 10, Top = 380, Width = 160 };
            btnCapNhat.Click += BtnCapNhat_Click;

            btnXoa = new Button { Text = "Xóa mục", Left = 180, Top = 380, Width = 120 };
            btnXoa.Click += BtnXoa_Click;

            btnDatHang = new Button { Text = "Đặt hàng", Left = 310, Top = 380, Width = 120 };
            btnDatHang.Click += BtnDatHang_Click;

            btnDong = new Button { Text = "Đóng", Left = 440, Top = 380, Width = 120 };
            btnDong.Click += (s, e) => Close();

            lblTong = new Label { Left = 10, Top = 420, Width = 660, Height = 30, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            Controls.AddRange(new Control[] { dgv, btnCapNhat, btnXoa, btnDatHang, btnDong, lblTong });
        }

        private void LoadGio()
        {
            try
            {
                if (!PhienService.DaDangNhap) { MessageBox.Show("Vui lòng đăng nhập trước."); Close(); return; }
                gio = GioHangService.Lay(PhienService.KhachHienTai.MaKhachHang);
                dgv.DataSource = null;
                dgv.DataSource = gio.Select(g => new
                {
                    g.MaSP,
                    g.TenSP,
                    DonGia = g.GiaBan.ToString("N0"),
                    SoLuong = g.SoLuong,
                    ThanhTien = g.ThanhTien.ToString("N0")
                }).ToList();
                UpdateTotal();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải giỏ hàng: " + ex.Message); }
        }

        private void UpdateTotal()
        {
            decimal t = 0;
            if (gio != null) foreach (var c in gio) t += c.ThanhTien;
            lblTong.Text = "Tiền hàng: " + t.ToString("N0") + " đ";
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow == null) { MessageBox.Show("Vui lòng chọn mục cần cập nhật."); return; }
                string ma = dgv.CurrentRow.Cells["MaSP"].Value as string;
                int sl = Convert.ToInt32(dgv.CurrentRow.Cells["SoLuong"].Value);
                GioHangService.CapNhatSoLuong(PhienService.KhachHienTai.MaKhachHang, ma, sl);
                LoadGio();
                MessageBox.Show("Cập nhật thành công.");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi cập nhật: " + ex.Message); }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.CurrentRow == null) { MessageBox.Show("Vui lòng chọn mục cần xóa."); return; }
                string ma = dgv.CurrentRow.Cells["MaSP"].Value as string;
                GioHangService.Xoa(PhienService.KhachHienTai.MaKhachHang, ma);
                LoadGio();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi khi xóa: " + ex.Message); }
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            if (gio == null || gio.Count == 0) { MessageBox.Show("Giỏ hàng trống."); return; }
            using (FrmDatHang f = new FrmDatHang(gio))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    // after successful order, reload
                    LoadGio();
                }
            }
        }
    }
}