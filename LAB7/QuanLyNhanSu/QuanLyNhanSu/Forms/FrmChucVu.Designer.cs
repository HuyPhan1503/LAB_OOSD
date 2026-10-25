
namespace LAB07.Forms
{
    partial class FrmChucVu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaChucVu;
        private System.Windows.Forms.Label lblTenChucVu;
        private System.Windows.Forms.Label lblPhuCap;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaChucVu;
        private System.Windows.Forms.TextBox txtTenChucVu;
        private System.Windows.Forms.TextBox txtPhuCap;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.CheckBox chkTrangThai;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvChucVu;
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
            this.lblMaChucVu = new System.Windows.Forms.Label();
            this.lblTenChucVu = new System.Windows.Forms.Label();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();

            this.txtMaChucVu = new System.Windows.Forms.TextBox();
            this.txtTenChucVu = new System.Windows.Forms.TextBox();
            this.txtPhuCap = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.chkTrangThai = new System.Windows.Forms.CheckBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvChucVu = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvChucVu)).BeginInit();

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

            this.lblTieuDe.Text = "QUẢN LÝ CHỨC VỤ";

            // Thông tin chức vụ
            this.grpThongTin.Text = "Thông tin chức vụ";
            this.grpThongTin.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.grpThongTin.Location =
                new System.Drawing.Point(25, 65);

            this.grpThongTin.Size =
                new System.Drawing.Size(900, 205);

            this.lblMaChucVu.AutoSize = true;
            this.lblMaChucVu.Location =
                new System.Drawing.Point(20, 35);

            this.lblMaChucVu.Text = "Mã chức vụ:";

            this.txtMaChucVu.Location =
                new System.Drawing.Point(145, 32);

            this.txtMaChucVu.Size =
                new System.Drawing.Size(270, 25);

            this.txtMaChucVu.MaxLength = 10;

            this.lblTenChucVu.AutoSize = true;
            this.lblTenChucVu.Location =
                new System.Drawing.Point(20, 75);

            this.lblTenChucVu.Text = "Tên chức vụ:";

            this.txtTenChucVu.Location =
                new System.Drawing.Point(145, 72);

            this.txtTenChucVu.Size =
                new System.Drawing.Size(270, 25);

            this.txtTenChucVu.MaxLength = 100;

            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location =
                new System.Drawing.Point(450, 35);

            this.lblPhuCap.Text = "Phụ cấp (VNĐ):";

            this.txtPhuCap.Location =
                new System.Drawing.Point(575, 32);

            this.txtPhuCap.Size =
                new System.Drawing.Size(280, 25);

            this.txtPhuCap.Text = "0";

            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Location =
                new System.Drawing.Point(575, 75);

            this.chkTrangThai.Text = "Đang hoạt động";
            this.chkTrangThai.Checked = true;

            // Thêm
            this.btnThem.Location =
                new System.Drawing.Point(25, 145);

            this.btnThem.Size =
                new System.Drawing.Size(110, 38);

            this.btnThem.Text = "Thêm";
            this.btnThem.BackColor =
                System.Drawing.Color.FromArgb(22, 163, 74);

            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            // Sửa
            this.btnSua.Location =
                new System.Drawing.Point(145, 145);

            this.btnSua.Size =
                new System.Drawing.Size(110, 38);

            this.btnSua.Text = "Cập nhật";
            this.btnSua.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 235);

            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            // Xóa
            this.btnXoa.Location =
                new System.Drawing.Point(265, 145);

            this.btnXoa.Size =
                new System.Drawing.Size(110, 38);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.BackColor =
                System.Drawing.Color.FromArgb(220, 38, 38);

            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);

            // Làm mới
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
                    this.lblMaChucVu,
                    this.txtMaChucVu,
                    this.lblTenChucVu,
                    this.txtTenChucVu,
                    this.lblPhuCap,
                    this.txtPhuCap,
                    this.chkTrangThai,
                    this.btnThem,
                    this.btnSua,
                    this.btnXoa,
                    this.btnLamMoi
                });

            // Danh sách chức vụ
            this.grpDanhSach.Text = "Danh sách chức vụ";
            this.grpDanhSach.Font =
                new System.Drawing.Font("Segoe UI", 10F);

            this.grpDanhSach.Location =
                new System.Drawing.Point(25, 285);

            this.grpDanhSach.Size =
                new System.Drawing.Size(900, 330);

            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location =
                new System.Drawing.Point(15, 30);

            this.lblTimKiem.Text = "Tìm kiếm:";

            this.txtTimKiem.Location =
                new System.Drawing.Point(95, 27);

            this.txtTimKiem.Size =
                new System.Drawing.Size(350, 25);

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

            this.dgvChucVu.Location =
                new System.Drawing.Point(15, 65);

            this.dgvChucVu.Size =
                new System.Drawing.Size(865, 245);

            this.dgvChucVu.ReadOnly = true;
            this.dgvChucVu.AllowUserToAddRows = false;
            this.dgvChucVu.AllowUserToDeleteRows = false;
            this.dgvChucVu.MultiSelect = false;

            this.dgvChucVu.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvChucVu.AutoGenerateColumns = true;

            this.dgvChucVu.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvChucVu.RowHeadersVisible = false;

            this.dgvChucVu.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvChucVu_CellClick);

            this.grpDanhSach.Controls.AddRange(
                new System.Windows.Forms.Control[]
                {
                    this.lblTimKiem,
                    this.txtTimKiem,
                    this.btnTimKiem,
                    this.dgvChucVu
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
            this.Name = "FrmChucVu";
            this.Text = "Quản lý chức vụ";

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvChucVu)).EndInit();

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();

            this.grpDanhSach.ResumeLayout(false);
            this.grpDanhSach.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
