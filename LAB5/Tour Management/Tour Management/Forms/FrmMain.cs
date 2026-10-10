using System;
using LAB5.Data;
using System.Windows.Forms;
using LAB5.Services;
using LAB5;

namespace LAB5
{
    public partial class FrmMain : Form
    {
        private string _vaiTro = string.Empty;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            using (var login = new FrmLogin())
            {
                if (login.ShowDialog() != DialogResult.OK) { Close(); return; }
                _vaiTro = login.VaiTro;
            }
            lblTrangThai.Text = "Vai trò: " + _vaiTro;
            PhanQuyen();
        }

        /// <summary>Phân quyền menu theo vai trò (Lễ tân / HDV / Thanh toán / Quản lý tour).</summary>
        private void PhanQuyen()
        {
            bool quanLy = _vaiTro == "Quản lý tour";
            bool leTan = _vaiTro == "Lễ tân";
            bool thanhToan = _vaiTro == "Thanh toán";
            mnuDanhMuc.Enabled = quanLy || leTan;
            mnuNghiepVu.Enabled = quanLy || leTan || _vaiTro == "Nhân viên hướng dẫn du lịch";
            mnuThanhToan.Enabled = quanLy || thanhToan;
            mnuBaoCao.Enabled = quanLy;
        }

        /// <summary>Mở form con trong MDI, không mở trùng.</summary>
        private void OpenChild<T>() where T : Form, new()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is T) { f.Activate(); return; }
            }
            var frm = new T { MdiParent = this };
            frm.Show();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            AuthService.DangXuat();
            foreach (Form f in MdiChildren) f.Close();
            FrmMain_Load(sender, e);
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuTour_Click(object sender, EventArgs e)
        {
            OpenChild<FrmTour>();
        }

        private void mnuNoiDungChan_Click(object sender, EventArgs e)
        {
            OpenChild<FrmNoiDungChan>();
        }

        private void mnuDiemThamQuan_Click(object sender, EventArgs e)
        {
            OpenChild<FrmDiemThamQuan>();
        }

        private void mnuDatTour_Click(object sender, EventArgs e)
        {
            OpenChild<FrmDatTour>();
        }

        private void mnuDangKyDoan_Click(object sender, EventArgs e)
        {
            OpenChild<FrmDangKyDoan>();
        }

        private void mnuDangKyKhachLe_Click(object sender, EventArgs e)
        {
            OpenChild<FrmDangKyKhachLe>();
        }

        private void mnuChuyen_Click(object sender, EventArgs e)
        {
            OpenChild<FrmChuyen>();
        }

        private void mnuPhanCong_Click(object sender, EventArgs e)
        {
            OpenChild<FrmPhanCongHDV>();
        }

        private void mnuKhaoSat_Click(object sender, EventArgs e)
        {
            OpenChild<FrmKhaoSat>();
        }

        private void mnuDenBu_Click(object sender, EventArgs e)
        {
            OpenChild<FrmDenBu>();
        }

        private void mnuThanhToanVe_Click(object sender, EventArgs e)
        {
            OpenChild<FrmThanhToanVe>();
        }

        private void mnuLuong_Click(object sender, EventArgs e)
        {
            OpenChild<FrmLuong>();
        }

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            OpenChild<FrmThongKe>();
        }

    }
}
