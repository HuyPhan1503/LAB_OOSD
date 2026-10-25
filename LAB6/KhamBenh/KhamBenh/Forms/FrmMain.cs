using System;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QL_KhamBenh
{
    public partial class FrmMain : Form
    {
        private readonly MenuStrip menu = new MenuStrip();

        public FrmMain()
        {
            Text = "Hệ thống quản lý khám bệnh - " + Session.HoTen + " (" + Session.ChucVu + ")";
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;

            var mHoSo = new ToolStripMenuItem("Hồ sơ bệnh án");
            AddItem(mHoSo, "Đăng ký hồ sơ bệnh án", () => new FrmDangKyHoSo(), "TiepNhan");
            AddItem(mHoSo, "Gia hạn lệ phí hằng năm", () => new FrmGiaHanLePhi(), "TiepNhan", "ThuNgan");
            AddItem(mHoSo, "Tra cứu hồ sơ bệnh án", () => new FrmTraCuuHoSo());

            var mKham = new ToolStripMenuItem("Khám bệnh");
            AddItem(mKham, "Đặt lịch hẹn khám", () => new FrmDatLich(), "TiepNhan", "ChamSocKH");
            AddItem(mKham, "Lập phiếu khám / kê toa", () => new FrmPhieuKham());

            var mTien = new ToolStripMenuItem("Thanh toán");
            AddItem(mTien, "Xuất viện & thanh toán viện phí", () => new FrmThanhToan(), "ThuNgan");

            var mTheoDoi = new ToolStripMenuItem("Chăm sóc khách hàng");
            AddItem(mTheoDoi, "Theo dõi sau điều trị", () => new FrmTheoDoi(), "ChamSocKH");

            var mBaoCao = new ToolStripMenuItem("Báo cáo");
            AddItem(mBaoCao, "Thống kê", () => new FrmThongKe(), "QuanLy");

            var mHeThong = new ToolStripMenuItem("Hệ thống");
            var thoat = new ToolStripMenuItem("Thoát");
            thoat.Click += (s, e) => Close();
            mHeThong.DropDownItems.Add(thoat);

            foreach (var m in new[] { mHoSo, mKham, mTien, mTheoDoi, mBaoCao })
                if (m.DropDownItems.Count > 0) menu.Items.Add(m);
            menu.Items.Add(mHeThong);

            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        /// <summary>Them muc menu; roles rong = ai cung dung duoc. QuanLy luon duoc dung.</summary>
        private void AddItem(ToolStripMenuItem parent, string text, Func<Form> factory, params string[] roles)
        {
            bool ok = Session.ChucVu == "QuanLy" || roles.Length == 0 || Array.IndexOf(roles, Session.ChucVu) >= 0;
            if (!ok) return;

            var item = new ToolStripMenuItem(text);
            item.Click += (s, e) =>
            {
                Form f = factory();
                f.MdiParent = this;
                f.Show();
            };
            parent.DropDownItems.Add(item);
        }
    }
}