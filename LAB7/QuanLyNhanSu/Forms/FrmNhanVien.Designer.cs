
namespace LAB07.Forms
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMaNhanVien;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblTrinhDo;
        private System.Windows.Forms.Label lblNgayVaoLam;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTrinhDo;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;

        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.ComboBox cboPhongBan;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.ComboBox cboTrangThai;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvNhanVien;
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
            this.lblMaNhanVien = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblTrinhDo = new System.Windows.Forms.Label();
            this.lblNgayVaoLam = new System.Windows.Forms.Label();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();

            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTrinhDo = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();

            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvNhanVien)).BeginInit();

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
                new System.Drawing.Point(20, 10);

            this.lblTieuDe.Text = "QUẢN LÝ NHÂN VIÊN";

            // Khung thông tin
            this.grpThongTin.Text = "Thông tin nhân viên";
            this.grpThongTin.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.grpThongTin.Location =
                new System.Drawing.Point(20, 50);

            this.grpThongTin.Size =
                new System.Drawing.Size(1250, 285);

            // Cột trái
            this.lblMaNhanVien.Location = new System.Drawing.Point(15, 30);
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.Text = "Mã nhân viên:";

            this.txtMaNhanVien.Location = new System.Drawing.Point(125, 27);
            this.txtMaNhanVien.Size = new System.Drawing.Size(220, 25);
            this.txtMaNhanVien.ReadOnly = true;

            this.lblHoTen.Location = new System.Drawing.Point(15, 65);
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Text = "Họ và tên:";

            this.txtHoTen.Location = new System.Drawing.Point(125, 62);
            this.txtHoTen.Size = new System.Drawing.Size(220, 25);
            this.txtHoTen.MaxLength = 100;

            this.lblNgaySinh.Location = new System.Drawing.Point(15, 100);
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Text = "Ngày sinh:";

            this.dtpNgaySinh.Location = new System.Drawing.Point(125, 97);
            this.dtpNgaySinh.Size = new System.Drawing.Size(220, 25);
            this.dtpNgaySinh.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.MaxDate = System.DateTime.Today;

            this.lblGioiTinh.Location = new System.Drawing.Point(15, 135);
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Text = "Giới tính:";

            this.cboGioiTinh.Location = new System.Drawing.Point(125, 132);
            this.cboGioiTinh.Size = new System.Drawing.Size(220, 25);
            this.cboGioiTinh.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Items.AddRange(
                new object[] { "Nam", "Nữ", "Khác" });

            this.lblCCCD.Location = new System.Drawing.Point(15, 170);
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Text = "CCCD:";

            this.txtCCCD.Location = new System.Drawing.Point(125, 167);
            this.txtCCCD.Size = new System.Drawing.Size(220, 25);
            this.txtCCCD.MaxLength = 20;

            // Cột giữa
            this.lblDienThoai.Location = new System.Drawing.Point(370, 30);
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Text = "Điện thoại:";

            this.txtDienThoai.Location = new System.Drawing.Point(475, 27);
            this.txtDienThoai.Size = new System.Drawing.Size(230, 25);
            this.txtDienThoai.MaxLength = 15;

            this.lblEmail.Location = new System.Drawing.Point(370, 65);
            this.lblEmail.AutoSize = true;
            this.lblEmail.Text = "Email:";

            this.txtEmail.Location = new System.Drawing.Point(475, 62);
            this.txtEmail.Size = new System.Drawing.Size(230, 25);
            this.txtEmail.MaxLength = 150;

            this.lblTrinhDo.Location = new System.Drawing.Point(370, 100);
            this.lblTrinhDo.AutoSize = true;
            this.lblTrinhDo.Text = "Trình độ:";

            this.txtTrinhDo.Location = new System.Drawing.Point(475, 97);
            this.txtTrinhDo.Size = new System.Drawing.Size(230, 25);
            this.txtTrinhDo.MaxLength = 100;

            this.lblNgayVaoLam.Location =
                new System.Drawing.Point(370, 135);
            this.lblNgayVaoLam.AutoSize = true;
            this.lblNgayVaoLam.Text = "Ngày vào làm:";

            this.dtpNgayVaoLam.Location =
                new System.Drawing.Point(475, 132);
            this.dtpNgayVaoLam.Size =
                new System.Drawing.Size(230, 25);
            this.dtpNgayVaoLam.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayVaoLam.ShowCheckBox = true;
            this.dtpNgayVaoLam.Checked = false;
            this.dtpNgayVaoLam.MaxDate = System.DateTime.Today;

            // Cột phải
            this.lblPhongBan.Location = new System.Drawing.Point(730, 30);
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.Text = "Phòng ban:";

            this.cboPhongBan.Location = new System.Drawing.Point(840, 27);
            this.cboPhongBan.Size = new System.Drawing.Size(370, 25);
            this.cboPhongBan.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblChucVu.Location = new System.Drawing.Point(730, 65);
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Text = "Chức vụ:";

            this.cboChucVu.Location = new System.Drawing.Point(840, 62);
            this.cboChucVu.Size = new System.Drawing.Size(370, 25);
            this.cboChucVu.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblTrangThai.Location = new System.Drawing.Point(730, 100);
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Text = "Trạng thái:";

            this.cboTrangThai.Location = new System.Drawing.Point(840, 97);
            this.cboTrangThai.Size = new System.Drawing.Size(370, 25);
            this.cboTrangThai.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboTrangThai.Items.AddRange(
                new object[]
                {
                    "Thử việc",
                    "Đang làm việc",
                    "Tạm nghỉ",
                    "Đã nghỉ việc"
                });

            this.lblDiaChi.Location = new System.Drawing.Point(730, 135);
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Text = "Địa chỉ:";

            this.txtDiaChi.Location = new System.Drawing.Point(840, 132);
            this.txtDiaChi.Size = new System.Drawing.Size(370, 55);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.MaxLength = 255;

            // Các nút thao tác
            this.btnThem.Location = new System.Drawing.Point(20, 220);
            this.btnThem.Size = new System.Drawing.Size(110, 38);
            this.btnThem.Text = "Thêm";
            this.btnThem.BackColor =
                System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Click +=
                new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(140, 220);
            this.btnSua.Size = new System.Drawing.Size(110, 38);
            this.btnSua.Text = "Cập nhật";
            this.btnSua.BackColor =
                System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Click +=
                new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(260, 220);
            this.btnXoa.Size = new System.Drawing.Size(110, 38);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.BackColor =
                System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Click +=
                new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(380, 220);
            this.btnLamMoi.Size = new System.Drawing.Size(110, 38);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click +=
                new System.EventHandler(this.btnLamMoi_Click);

            this.grpThongTin.Controls.AddRange(
                new System.Windows.Forms.Control[]
                {
                    this.lblMaNhanVien, this.txtMaNhanVien,
                    this.lblHoTen, this.txtHoTen,
                    this.lblNgaySinh, this.dtpNgaySinh,
                    this.lblGioiTinh, this.cboGioiTinh,
                    this.lblCCCD, this.txtCCCD,
                    this.lblDienThoai, this.txtDienThoai,
                    this.lblEmail, this.txtEmail,
                    this.lblTrinhDo, this.txtTrinhDo,
                    this.lblNgayVaoLam, this.dtpNgayVaoLam,
                    this.lblPhongBan, this.cboPhongBan,
                    this.lblChucVu, this.cboChucVu,
                    this.lblTrangThai, this.cboTrangThai,
                    this.lblDiaChi, this.txtDiaChi,
                    this.btnThem, this.btnSua,
                    this.btnXoa, this.btnLamMoi
                });

            // Khung danh sách
            this.grpDanhSach.Text = "Danh sách nhân viên";
            this.grpDanhSach.Font =
                new System.Drawing.Font("Segoe UI", 9F);
            this.grpDanhSach.Location =
                new System.Drawing.Point(20, 345);
            this.grpDanhSach.Size =
                new System.Drawing.Size(1250, 350);

            this.lblTimKiem.Location = new System.Drawing.Point(15, 28);
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Text = "Tìm theo tên, CCCD, điện thoại hoặc email:";

            this.txtTimKiem.Location =
                new System.Drawing.Point(300, 25);
            this.txtTimKiem.Size =
                new System.Drawing.Size(400, 25);

            this.btnTimKiem.Location =
                new System.Drawing.Point(710, 22);
            this.btnTimKiem.Size =
                new System.Drawing.Size(100, 32);
            this.btnTimKiem.Text = "Tìm kiếm";
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

            this.dgvNhanVien.Location =
                new System.Drawing.Point(15, 65);
            this.dgvNhanVien.Size =
                new System.Drawing.Size(1215, 265);
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.AutoGenerateColumns = true;
            this.dgvNhanVien.BackgroundColor =
                System.Drawing.Color.White;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvNhanVien_CellClick);

            this.grpDanhSach.Controls.AddRange(
                new System.Windows.Forms.Control[]
                {
                    this.lblTimKiem,
                    this.txtTimKiem,
                    this.btnTimKiem,
                    this.dgvNhanVien
                });

            // Form
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor =
                System.Drawing.Color.FromArgb(243, 244, 246);
            this.ClientSize =
                new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmNhanVien";
            this.Text = "Quản lý nhân viên";

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvNhanVien)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            this.grpDanhSach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
