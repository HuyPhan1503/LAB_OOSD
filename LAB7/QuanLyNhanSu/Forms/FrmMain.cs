using System;
using System.Windows.Forms;

namespace LAB07.Forms
{
    public partial class FrmMain : Form
    {
        private Form formDangMo;

        public FrmMain()
        {
            InitializeComponent();
            KhoiTaoGiaoDien();
            TaoMenuHoSoUngTuyen();
        }

        private void KhoiTaoGiaoDien()
        {
            lblNgay.Text = "Ngày làm việc: " +
                           DateTime.Now.ToString("dd/MM/yyyy");

            lblNguoiDung.Text = "Người dùng: Chưa đăng nhập";
            lblTrangThai.Text = "Hệ thống quản lý nhân sự và tiền lương";
        }

        private void MoFormCon(Form form)
        {
            if (form == null)
                return;

            // Nếu form đang mở đã đúng loại thì đưa lên trước.
            if (formDangMo != null &&
                formDangMo.GetType() == form.GetType())
            {
                form.Dispose();
                formDangMo.BringToFront();
                return;
            }

            // Đóng form con hiện tại.
            if (formDangMo != null)
            {
                pnlNoiDung.Controls.Remove(formDangMo);
                formDangMo.Close();
                formDangMo.Dispose();
                formDangMo = null;
            }

            // Thiết lập form con hiển thị trong panel.
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            pnlNoiDung.Controls.Clear();
            pnlNoiDung.Controls.Add(form);

            formDangMo = form;

            form.Show();
            form.BringToFront();
        }

        private void mnuPhongBan_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmPhongBan());
        }

        private void mnuChucVu_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmChucVu());
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmNhanVien());
        }

        private void mnuQuyetDinh_Click(object sender, EventArgs e)
        {
            MoFormCon(new FrmQuyetDinhTuyenDung());
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuThongTin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "LAB07 - QUẢN LÝ NHÂN SỰ VÀ TIỀN LƯƠNG\n\n" +
                "Sinh viên: Phan Nguyễn Gia Huy\n" +
                "MSSV: 1250080076\n" +
                "Lớp: 12_ĐH_CNPM2\n\n" +
                "Công nghệ: C# Windows Forms, SQL Server",
                "Thông tin chương trình",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void TaoMenuHoSoUngTuyen()
        {
            MenuStrip menuStrip = this.MainMenuStrip;

            if (menuStrip == null)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is MenuStrip)
                    {
                        menuStrip = (MenuStrip)control;
                        break;
                    }
                }
            }

            if (menuStrip == null)
            {
                menuStrip = new MenuStrip();
                this.MainMenuStrip = menuStrip;
                this.Controls.Add(menuStrip);
            }

            ToolStripMenuItem menuNhanSu = null;

            foreach (ToolStripItem item in menuStrip.Items)
            {
                if (item is ToolStripMenuItem &&
                    item.Text == "Nhân sự")
                {
                    menuNhanSu = (ToolStripMenuItem)item;
                    break;
                }
            }

            if (menuNhanSu == null)
            {
                menuNhanSu = new ToolStripMenuItem("Nhân sự");
                menuStrip.Items.Add(menuNhanSu);
            }

            foreach (ToolStripItem item in menuNhanSu.DropDownItems)
            {
                if (item.Text == "Hồ sơ ứng tuyển")
                    return;
            }

            ToolStripMenuItem menuHoSoUngTuyen =
                new ToolStripMenuItem("Hồ sơ ứng tuyển");

            menuHoSoUngTuyen.Click += mnuHoSoUngTuyen_Click;
            menuNhanSu.DropDownItems.Add(menuHoSoUngTuyen);
        }

        private void mnuHoSoUngTuyen_Click(object sender, EventArgs e)
        {
            using (FrmHoSoUngTuyen form = new FrmHoSoUngTuyen())
            {
                form.ShowDialog();
            }
        }
    }
}