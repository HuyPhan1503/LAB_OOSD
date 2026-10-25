
namespace LAB07.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;

        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuPhongBan;
        private System.Windows.Forms.ToolStripMenuItem mnuChucVu;

        private System.Windows.Forms.ToolStripMenuItem mnuNhanSu;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuTuyenDung;
        private System.Windows.Forms.ToolStripMenuItem mnuThuViec;
        private System.Windows.Forms.ToolStripMenuItem mnuHopDong;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoHiem;
        private System.Windows.Forms.ToolStripMenuItem mnuQuyetDinh;

        private System.Windows.Forms.ToolStripMenuItem mnuChamCong;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanCong;
        private System.Windows.Forms.ToolStripMenuItem mnuPhuTroi;

        private System.Windows.Forms.ToolStripMenuItem mnuTienLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuBangLuong;

        private System.Windows.Forms.ToolStripMenuItem mnuThuongPhat;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel lblNgay;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.menuStripMain = new System.Windows.Forms.MenuStrip();

            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhongBan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChucVu = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuNhanSu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTuyenDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThuViec = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHopDong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoHiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuyetDinh = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuChamCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhuTroi = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuTienLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangLuong = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuThuongPhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.pnlNoiDung = new System.Windows.Forms.Panel();

            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNgay = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();

            this.menuStripMain.SuspendLayout();
            this.pnlTieuDe.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();

            // Menu hệ thống
            this.mnuHeThong.Text = "Hệ thống";
            this.mnuThongTin.Text = "Thông tin chương trình";
            this.mnuThoat.Text = "Thoát";

            this.mnuThongTin.Click +=
                new System.EventHandler(this.mnuThongTin_Click);

            this.mnuThoat.Click +=
                new System.EventHandler(this.mnuThoat_Click);

            this.mnuHeThong.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuThongTin,
                    new System.Windows.Forms.ToolStripSeparator(),
                    this.mnuThoat
                });

            // Danh mục
            this.mnuDanhMuc.Text = "Danh mục";
            this.mnuPhongBan.Text = "Quản lý phòng ban";
            this.mnuChucVu.Text = "Quản lý chức vụ";
            this.mnuChucVu.Click +=
                new System.EventHandler(this.mnuChucVu_Click);
            this.mnuChucVu.Enabled = true;

            this.mnuPhongBan.Click +=
                new System.EventHandler(this.mnuPhongBan_Click);

            this.mnuDanhMuc.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuPhongBan,
                    this.mnuChucVu
                });

            // Nhân sự
            this.mnuNhanSu.Text = "Nhân sự";

            this.mnuNhanVien.Text = "Quản lý nhân viên";
            this.mnuTuyenDung.Text = "Quản lý tuyển dụng";
            this.mnuThuViec.Text = "Quản lý thử việc";
            this.mnuHopDong.Text = "Hợp đồng lao động";
            this.mnuBaoHiem.Text = "Hồ sơ bảo hiểm";
            this.mnuQuyetDinh.Text = "Quyết định nhân sự và lương";

            this.mnuNhanSu.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuNhanVien,
                    this.mnuTuyenDung,
                    this.mnuThuViec,
                    this.mnuHopDong,
                    this.mnuBaoHiem,
                    this.mnuQuyetDinh
                });

            this.mnuNhanSu.Enabled = true;
            this.mnuNhanVien.Click +=
                new System.EventHandler(this.mnuNhanVien_Click);
            this.mnuQuyetDinh.Click +=
                new System.EventHandler(this.mnuQuyetDinh_Click);

            // Chấm công
            this.mnuChamCong.Text = "Chấm công";
            this.mnuPhanCong.Text = "Phân công ca làm";
            this.mnuPhuTroi.Text = "Quản lý giờ phụ trội";

            this.mnuChamCong.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuPhanCong,
                    this.mnuPhuTroi
                });

            this.mnuChamCong.Enabled = false;

            // Tiền lương
            this.mnuTienLuong.Text = "Tiền lương";
            this.mnuBangLuong.Text = "Bảng lương tháng";
            this.mnuTienLuong.DropDownItems.Add(this.mnuBangLuong);
            this.mnuTienLuong.Enabled = false;

            // Thưởng phạt và thống kê
            this.mnuThuongPhat.Text = "Khen thưởng - Kỷ luật";
            this.mnuThongKe.Text = "Thống kê - Báo cáo";

            this.mnuThuongPhat.Enabled = false;
            this.mnuThongKe.Enabled = false;

            // Thanh menu chính
            this.menuStripMain.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.mnuHeThong,
                    this.mnuDanhMuc,
                    this.mnuNhanSu,
                    this.mnuChamCong,
                    this.mnuTienLuong,
                    this.mnuThuongPhat,
                    this.mnuThongKe
                });

            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuStripMain.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            // Tiêu đề
            this.pnlTieuDe.BackColor =
                System.Drawing.Color.FromArgb(31, 41, 55);

            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Controls.Add(this.lblMoTa);
            this.pnlTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDe.Height = 105;

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font =
                new System.Drawing.Font(
                    "Segoe UI", 21F,
                    System.Drawing.FontStyle.Bold);

            this.lblTieuDe.ForeColor =
                System.Drawing.Color.White;

            this.lblTieuDe.Location =
                new System.Drawing.Point(25, 12);

            this.lblTieuDe.Text =
                "QUẢN LÝ NHÂN SỰ VÀ TIỀN LƯƠNG";

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.lblMoTa.ForeColor =
                System.Drawing.Color.FromArgb(209, 213, 219);

            this.lblMoTa.Location =
                new System.Drawing.Point(29, 66);

            this.lblMoTa.Text =
                "Hệ thống quản lý nhân sự doanh nghiệp";

            // Vùng hiển thị Form con
            this.pnlNoiDung.BackColor =
                System.Drawing.Color.FromArgb(243, 244, 246);

            this.pnlNoiDung.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.pnlNoiDung.Padding =
                new System.Windows.Forms.Padding(12);

            // Thanh trạng thái
            this.lblTrangThai.Text = "Sẵn sàng";
            this.lblTrangThai.Spring = true;
            this.lblTrangThai.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.lblNgay.Text = "Ngày làm việc";
            this.lblNguoiDung.Text = "Người dùng";

            this.statusStripMain.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.lblTrangThai,
                    this.lblNgay,
                    this.lblNguoiDung
                });

            this.statusStripMain.Dock =
                System.Windows.Forms.DockStyle.Bottom;

            // Form chính
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 20F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1200, 720);

            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlTieuDe);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);

            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(1000, 600);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Quản lý nhân sự và tiền lương";

            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
