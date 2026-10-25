
namespace LAB07.Forms
{
    partial class FrmPhongBan
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaPhongBan;
        private System.Windows.Forms.Label lblTenPhongBan;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaPhongBan;
        private System.Windows.Forms.TextBox txtTenPhongBan;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.CheckBox chkTrangThai;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvPhongBan;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.GroupBox grpDanhSach;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMaPhongBan = new System.Windows.Forms.Label();
            this.lblTenPhongBan = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();

            this.txtMaPhongBan = new System.Windows.Forms.TextBox();
            this.txtTenPhongBan = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.chkTrangThai = new System.Windows.Forms.CheckBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvPhongBan = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvPhongBan)).BeginInit();

            this.grpThongTin.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            this.SuspendLayout();

            // Tiêu đề
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);

            this.lblTieuDe.ForeColor =
                System.Drawing.Color.FromArgb(31, 41, 55);

            this.lblTieuDe.Location =
                new System.Drawing.Point(20, 15);

            this.lblTieuDe.Text = "QUẢN LÝ PHÒNG BAN";

            // Group thông tin
            this.grpThongTin.Text = "Thông tin phòng ban";
            this.grpThongTin.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.grpThongTin.Location =
                new System.Drawing.Point(25, 65);

            this.grpThongTin.Size =
                new System.Drawing.Size(900, 205);

            // Mã phòng ban
            this.lblMaPhongBan.AutoSize = true;
            this.lblMaPhongBan.Location =
                new System.Drawing.Point(20, 35);

            this.lblMaPhongBan.Text = "Mã phòng ban:";

            this.txtMaPhongBan.Location =
                new System.Drawing.Point(155, 32);

            this.txtMaPhongBan.Size =
                new System.Drawing.Size(260, 25);

            this.txtMaPhongBan.MaxLength = 10;

            // Tên phòng ban
            this.lblTenPhongBan.AutoSize = true;
            this.lblTenPhongBan.Location =
                new System.Drawing.Point(20, 75);

            this.lblTenPhongBan.Text = "Tên phòng ban:";

            this.txtTenPhongBan.Location =
                new System.Drawing.Point(155, 72);

            this.txtTenPhongBan.Size =
                new System.Drawing.Size(260, 25);

            this.txtTenPhongBan.MaxLength = 100;

            // Mô tả
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location =
                new System.Drawing.Point(450, 35);

            this.lblMoTa.Text = "Mô tả:";

            this.txtMoTa.Location =
                new System.Drawing.Point(525, 32);

            this.txtMoTa.Size =
                new System.Drawing.Size(340, 65);

            this.txtMoTa.Multiline = true;
            this.txtMoTa.MaxLength = 255;

            // Trạng thái
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Location =
                new System.Drawing.Point(525, 110);

            this.chkTrangThai.Text = "Đang hoạt động";
            this.chkTrangThai.Checked = true;

            // Nút thêm
            this.btnThem.Location =
                new System.Drawing.Point(25, 145);

            this.btnThem.Size =
                new System.Drawing.Size(110, 38);

            this.btnThem.Text = "Thêm";
            this.btnThem.BackColor =
                System.Drawing.Color.FromArgb(22, 163, 74);

            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // Nút sửa
            this.btnSua.Location =
                new System.Drawing.Point(145, 145);

            this.btnSua.Size =
                new System.Drawing.Size(110, 38);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 235);

            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // Nút xóa
            this.btnXoa.Location =
                new System.Drawing.Point(265, 145);

            this.btnXoa.Size =
                new System.Drawing.Size(110, 38);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.BackColor =
                System.Drawing.Color.FromArgb(220, 38, 38);

            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);

            // Nút làm mới
            this.btnLamMoi.Location =
                new System.Drawing.Point(385, 145);

            this.btnLamMoi.Size =
                new System.Drawing.Size(110, 38);

            this.btnLamMoi.Text = "Làm mới";

            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            this.grpThongTin.Controls.AddRange(
                new System.Windows.Forms.Control[]
                {
                    this.lblMaPhongBan,
                    this.txtMaPhongBan,
                    this.lblTenPhongBan,
                    this.txtTenPhongBan,
                    this.lblMoTa,
                    this.txtMoTa,
                    this.chkTrangThai,
                    this.btnThem,
                    this.btnSua,
                    this.btnXoa,
                    this.btnLamMoi
                });

            // Group danh sách
            this.grpDanhSach.Text = "Danh sách phòng ban";
            this.grpDanhSach.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.grpDanhSach.Location =
                new System.Drawing.Point(25, 285);

            this.grpDanhSach.Size =
                new System.Drawing.Size(900, 330);

            // Ô tìm kiếm
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location =
                new System.Drawing.Point(15, 30);

            this.lblTimKiem.Text = "Tìm kiếm:";

            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 27);

            this.txtTimKiem.Size =
                new System.Drawing.Size(350, 25);

            this.txtTimKiem.MaxLength = 100;

            this.btnTimKiem.Location =
                new System.Drawing.Point(455, 24);

            this.btnTimKiem.Size =
                new System.Drawing.Size(100, 32);

            this.btnTimKiem.Text = "Tìm";

            this.btnTimKiem.Click +=
                new System.EventHandler(this.btnTimKiem_Click);

            this.txtTimKiem.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    this.btnTimKiem.PerformClick();
                }
            };

            // DataGridView
            this.dgvPhongBan.Location =
                new System.Drawing.Point(15, 65);

            this.dgvPhongBan.Size =
                new System.Drawing.Size(865, 245);

            this.dgvPhongBan.ReadOnly = true;

            this.dgvPhongBan.AllowUserToAddRows = false;
            this.dgvPhongBan.AllowUserToDeleteRows = false;

            this.dgvPhongBan.MultiSelect = false;

            this.dgvPhongBan.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvPhongBan.AutoGenerateColumns = true;

            this.dgvPhongBan.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvPhongBan.RowHeadersVisible = false;

            this.dgvPhongBan.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvPhongBan_CellClick);

            this.grpDanhSach.Controls.AddRange(
                new System.Windows.Forms.Control[]
                {
                    this.lblTimKiem,
                    this.txtTimKiem,
                    this.btnTimKiem,
                    this.dgvPhongBan
                });

            // Form
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 20F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(243, 244, 246);

            this.ClientSize =
                new System.Drawing.Size(960, 650);

            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lblTieuDe);

            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmPhongBan";

            this.Text = "Quản lý phòng ban";

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvPhongBan)).EndInit();

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();

            this.grpDanhSach.ResumeLayout(false);
            this.grpDanhSach.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
