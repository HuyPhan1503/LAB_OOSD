namespace LAB5
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNoiDungChan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiemThamQuan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatTour = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyDoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyKhachLe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanCong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhaoSat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDenBu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThanhToanVe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // menuStrip1
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuDanhMuc,
            this.mnuNghiepVu,
            this.mnuThanhToan,
            this.mnuBaoCao});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 0;
            // mnuHeThong
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Text = "Hệ thống";
            // mnuDangXuat
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // mnuThoat
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // mnuDanhMuc
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTour,
            this.mnuNoiDungChan,
            this.mnuDiemThamQuan});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Text = "Danh mục";
            // mnuTour
            this.mnuTour.Name = "mnuTour";
            this.mnuTour.Text = "Quản lý tour";
            this.mnuTour.Click += new System.EventHandler(this.mnuTour_Click);
            // mnuNoiDungChan
            this.mnuNoiDungChan.Name = "mnuNoiDungChan";
            this.mnuNoiDungChan.Text = "Nơi dừng chân";
            this.mnuNoiDungChan.Click += new System.EventHandler(this.mnuNoiDungChan_Click);
            // mnuDiemThamQuan
            this.mnuDiemThamQuan.Name = "mnuDiemThamQuan";
            this.mnuDiemThamQuan.Text = "Điểm tham quan";
            this.mnuDiemThamQuan.Click += new System.EventHandler(this.mnuDiemThamQuan_Click);
            // mnuNghiepVu
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatTour,
            this.mnuDangKyDoan,
            this.mnuDangKyKhachLe,
            this.mnuChuyen,
            this.mnuPhanCong,
            this.mnuKhaoSat,
            this.mnuDenBu});
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            // mnuDatTour
            this.mnuDatTour.Name = "mnuDatTour";
            this.mnuDatTour.Text = "Đặt tour";
            this.mnuDatTour.Click += new System.EventHandler(this.mnuDatTour_Click);
            // mnuDangKyDoan
            this.mnuDangKyDoan.Name = "mnuDangKyDoan";
            this.mnuDangKyDoan.Text = "Đăng ký khách đoàn";
            this.mnuDangKyDoan.Click += new System.EventHandler(this.mnuDangKyDoan_Click);
            // mnuDangKyKhachLe
            this.mnuDangKyKhachLe.Name = "mnuDangKyKhachLe";
            this.mnuDangKyKhachLe.Text = "Đăng ký khách lẻ";
            this.mnuDangKyKhachLe.Click += new System.EventHandler(this.mnuDangKyKhachLe_Click);
            // mnuChuyen
            this.mnuChuyen.Name = "mnuChuyen";
            this.mnuChuyen.Text = "Quản lý chuyến";
            this.mnuChuyen.Click += new System.EventHandler(this.mnuChuyen_Click);
            // mnuPhanCong
            this.mnuPhanCong.Name = "mnuPhanCong";
            this.mnuPhanCong.Text = "Phân công hướng dẫn viên";
            this.mnuPhanCong.Click += new System.EventHandler(this.mnuPhanCong_Click);
            // mnuKhaoSat
            this.mnuKhaoSat.Name = "mnuKhaoSat";
            this.mnuKhaoSat.Text = "Phiếu khảo sát";
            this.mnuKhaoSat.Click += new System.EventHandler(this.mnuKhaoSat_Click);
            // mnuDenBu
            this.mnuDenBu.Name = "mnuDenBu";
            this.mnuDenBu.Text = "Phiếu đền bù";
            this.mnuDenBu.Click += new System.EventHandler(this.mnuDenBu_Click);
            // mnuThanhToan
            this.mnuThanhToan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThanhToanVe,
            this.mnuLuong});
            this.mnuThanhToan.Name = "mnuThanhToan";
            this.mnuThanhToan.Text = "Thanh toán";
            // mnuThanhToanVe
            this.mnuThanhToanVe.Name = "mnuThanhToanVe";
            this.mnuThanhToanVe.Text = "Thanh toán vé tour";
            this.mnuThanhToanVe.Click += new System.EventHandler(this.mnuThanhToanVe_Click);
            // mnuLuong
            this.mnuLuong.Name = "mnuLuong";
            this.mnuLuong.Text = "Thanh toán lương";
            this.mnuLuong.Click += new System.EventHandler(this.mnuLuong_Click);
            // mnuBaoCao
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongKe});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Text = "Thống kê";
            // mnuThongKe
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Text = "Thống kê";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // statusStrip1
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblTrangThai });
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Text = "statusStrip1";
            // lblTrangThai
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Sẵn sàng";
            // FrmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý tour du lịch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuTour;
        private System.Windows.Forms.ToolStripMenuItem mnuNoiDungChan;
        private System.Windows.Forms.ToolStripMenuItem mnuDiemThamQuan;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem mnuDatTour;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyDoan;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyKhachLe;
        private System.Windows.Forms.ToolStripMenuItem mnuChuyen;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanCong;
        private System.Windows.Forms.ToolStripMenuItem mnuKhaoSat;
        private System.Windows.Forms.ToolStripMenuItem mnuDenBu;
        private System.Windows.Forms.ToolStripMenuItem mnuThanhToan;
        private System.Windows.Forms.ToolStripMenuItem mnuThanhToanVe;
        private System.Windows.Forms.ToolStripMenuItem mnuLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKe;
    }
}
