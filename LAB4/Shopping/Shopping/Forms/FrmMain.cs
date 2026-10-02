using Shopping.Forms;
using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Shopping
{
    public partial class FrmMain : Form
    {
        // ==============================
        // KHAI BÁO CÁC CONTROL
        // ==============================

        private Label lblXinChao;

        private Button btnDangNhap;
        private Button btnDangKy;
        private Button btnSanPham;
        private Button btnGioHang;
        private Button btnDatHang;
        private Button btnThoat;


        // ==============================
        // CONSTRUCTOR
        // ==============================

        public FrmMain()
        {
            TaoGiaoDien();
            CapNhatTrangThai();
        }


        // ==============================
        // TẠO GIAO DIỆN
        // ==============================

        private void TaoGiaoDien()
        {
            // Form
            Text = "eShopping";
            Size = new Size(650, 400);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // ==============================
            // LABEL XIN CHÀO
            // ==============================

            lblXinChao = new Label
            {
                Text = "Bạn chưa đăng nhập",
                Left = 30,
                Top = 30,
                Width = 550,
                Height = 35,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };


            // ==============================
            // BUTTON ĐĂNG NHẬP
            // ==============================

            btnDangNhap = new Button
            {
                Text = "Đăng nhập",
                Left = 30,
                Top = 90,
                Width = 130,
                Height = 40
            };

            btnDangNhap.Click += btnDangNhap_Click;


            // ==============================
            // BUTTON ĐĂNG KÝ
            // ==============================

            btnDangKy = new Button
            {
                Text = "Đăng ký",
                Left = 180,
                Top = 90,
                Width = 130,
                Height = 40
            };

            btnDangKy.Click += btnDangKy_Click;


            // ==============================
            // BUTTON SẢN PHẨM
            // ==============================

            btnSanPham = new Button
            {
                Text = "Sản phẩm",
                Left = 30,
                Top = 160,
                Width = 130,
                Height = 40
            };

            btnSanPham.Click += btnSanPham_Click;


            // ==============================
            // BUTTON GIỎ HÀNG
            // ==============================

            btnGioHang = new Button
            {
                Text = "Giỏ hàng",
                Left = 180,
                Top = 160,
                Width = 130,
                Height = 40
            };

            btnGioHang.Click += btnGioHang_Click;


            // ==============================
            // BUTTON ĐẶT HÀNG
            // ==============================

            btnDatHang = new Button
            {
                Text = "Đặt hàng",
                Left = 330,
                Top = 160,
                Width = 130,
                Height = 40
            };

            btnDatHang.Click += btnDatHang_Click;


            // ==============================
            // BUTTON THOÁT
            // ==============================

            btnThoat = new Button
            {
                Text = "Thoát",
                Left = 30,
                Top = 230,
                Width = 130,
                Height = 40
            };

            btnThoat.Click += btnThoat_Click;


            // ==============================
            // THÊM CONTROL VÀO FORM
            // ==============================

            Controls.Add(lblXinChao);
            Controls.Add(btnDangNhap);
            Controls.Add(btnDangKy);
            Controls.Add(btnSanPham);
            Controls.Add(btnGioHang);
            Controls.Add(btnDatHang);
            Controls.Add(btnThoat);
        }


        // ==============================
        // CẬP NHẬT TRẠNG THÁI ĐĂNG NHẬP
        // ==============================

        private void CapNhatTrangThai()
        {
            bool dn = PhienService.DaDangNhap;

            if (dn)
            {
                lblXinChao.Text =
                    "Xin chào, " +
                    PhienService.KhachHienTai.HoTen;

                btnDangNhap.Text = "Đăng xuất";
                btnDangKy.Enabled = false;
            }
            else
            {
                lblXinChao.Text = "Bạn chưa đăng nhập";

                btnDangNhap.Text = "Đăng nhập";
                btnDangKy.Enabled = true;
            }
        }


        // ==============================
        // KIỂM TRA ĐĂNG NHẬP
        // ==============================

        private bool YeuCauDangNhap()
        {
            if (PhienService.DaDangNhap)
                return true;

            MessageBox.Show(
                "Vui lòng đăng nhập trước.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            return false;
        }


        // ==============================
        // MỞ FORM SẢN PHẨM
        // ==============================

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            using (FrmSanPham f = new FrmSanPham())
            {
                f.ShowDialog(this);
            }
        }


        // ==============================
        // MỞ FORM GIỎ HÀNG
        // ==============================

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            if (!YeuCauDangNhap())
                return;

            using (FrmGioHang f = new FrmGioHang())
            {
                f.ShowDialog(this);
            }
        }


        // ==============================
        // MỞ FORM ĐẶT HÀNG
        // ==============================

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (!YeuCauDangNhap())
                return;

            try
            {
                int maKhachHang = PhienService.KhachHienTai.MaKhachHang;

                List<ChiTietGioHang> gioHang = GioHangService.Lay(maKhachHang);

                if (gioHang == null)
                {
                    MessageBox.Show("GioHangService.Lay() trả về null.");
                    return;
                }

                MessageBox.Show("Số sản phẩm trong giỏ: " + gioHang.Count);

                using (FrmDatHang f = new FrmDatHang(gioHang))
                {
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "LỖI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // ==============================
        // MỞ FORM ĐĂNG KÝ
        // ==============================

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (FrmDangKy f = new FrmDangKy())
            {
                f.ShowDialog(this);
            }

            // Cập nhật lại giao diện sau khi đóng Form đăng ký
            CapNhatTrangThai();
        }


        // ==============================
        // ĐĂNG NHẬP / ĐĂNG XUẤT
        // ==============================

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Nếu đang đăng nhập -> đăng xuất
            if (PhienService.DaDangNhap)
            {
                PhienService.KhachHienTai = null;
            }
            else
            {
                // Nếu chưa đăng nhập -> mở Form đăng nhập
                using (FrmDangNhap f = new FrmDangNhap())
                {
                    f.ShowDialog(this);
                }
            }

            // Cập nhật lại giao diện
            CapNhatTrangThai();
        }


        // ==============================
        // THOÁT CHƯƠNG TRÌNH
        // ==============================

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có thực sự muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}