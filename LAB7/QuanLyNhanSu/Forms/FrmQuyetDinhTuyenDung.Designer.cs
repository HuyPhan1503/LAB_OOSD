
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LAB07.Forms
{
    partial class FrmQuyetDinhTuyenDung
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTieuDe;
        private Panel pnlNhap;
        private FlowLayoutPanel pnlNut;
        private Panel pnlTimKiem;

        private ComboBox cboNhanVien;
        private ComboBox cboHoSo;
        private ComboBox cboPhongBan;
        private ComboBox cboNguoiKy;
        private ComboBox cboTrangThai;

        private DateTimePicker dtpNgayKy;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayKetThuc;

        private NumericUpDown nudLuong;
        private TextBox txtDieuKhoan;
        private TextBox txtTimKiem;

        private DataGridView dgvDanhSach;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTieuDe = new Label();
            pnlNhap = new Panel();
            pnlNut = new FlowLayoutPanel();
            pnlTimKiem = new Panel();

            cboNhanVien = new ComboBox();
            cboHoSo = new ComboBox();
            cboPhongBan = new ComboBox();
            cboNguoiKy = new ComboBox();
            cboTrangThai = new ComboBox();

            dtpNgayKy = new DateTimePicker();
            dtpNgayBatDau = new DateTimePicker();
            dtpNgayKetThuc = new DateTimePicker();

            nudLuong = new NumericUpDown();
            txtDieuKhoan = new TextBox();
            txtTimKiem = new TextBox();

            dgvDanhSach = new DataGridView();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnTimKiem = new Button();

            SuspendLayout();

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 741);
            MinimumSize = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ QUYẾT ĐỊNH TUYỂN DỤNG";

            // Tiêu đề
            lblTieuDe.Text = "QUẢN LÝ QUYẾT ĐỊNH TUYỂN DỤNG";
            lblTieuDe.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Height = 50;

            // Khu vực nhập liệu
            pnlNhap.Dock = DockStyle.Top;
            pnlNhap.Height = 310;
            pnlNhap.Padding = new Padding(15);

            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHoSo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguoiKy.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            cboTrangThai.Items.AddRange(new object[]
            {
                "Chờ nhận việc",
                "Đang thử việc",
                "Đã hoàn thành",
                "Đã hủy"
            });

            dtpNgayKy.Format = DateTimePickerFormat.Short;

            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayBatDau.Value = DateTime.Today.AddDays(1);

            dtpNgayKetThuc.Format = DateTimePickerFormat.Short;
            dtpNgayKetThuc.Value = DateTime.Today.AddDays(61);

            nudLuong.Minimum = 0;
            nudLuong.Maximum = 1000000000;
            nudLuong.DecimalPlaces = 0;
            nudLuong.ThousandsSeparator = true;

            txtDieuKhoan.Multiline = true;
            txtDieuKhoan.ScrollBars = ScrollBars.Vertical;
            txtDieuKhoan.Height = 55;

            AddField("Nhân viên:", cboNhanVien, 15, 15);
            AddField("Hồ sơ ứng tuyển:", cboHoSo, 400, 15);
            AddField("Phòng ban:", cboPhongBan, 15, 65);
            AddField("Người ký:", cboNguoiKy, 400, 65);
            AddField("Ngày ký:", dtpNgayKy, 15, 115);
            AddField("Bắt đầu thử việc:", dtpNgayBatDau, 400, 115);
            AddField("Kết thúc thử việc:", dtpNgayKetThuc, 15, 165);
            AddField("Lương thử việc:", nudLuong, 400, 165);
            AddField("Trạng thái:", cboTrangThai, 15, 215);
            AddField("Điều khoản:", txtDieuKhoan, 400, 215);

            // Nút chức năng
            pnlNut.Dock = DockStyle.Top;
            pnlNut.Height = 45;
            pnlNut.Padding = new Padding(15, 3, 0, 3);
            pnlNut.WrapContents = false;

            ConfigureButton(btnThem, "Thêm");
            ConfigureButton(btnSua, "Sửa");
            ConfigureButton(btnXoa, "Xóa");
            ConfigureButton(btnLamMoi, "Làm mới");

            pnlNut.Controls.AddRange(new Control[]
            {
                btnThem,
                btnSua,
                btnXoa,
                btnLamMoi
            });

            // Tìm kiếm
            pnlTimKiem.Dock = DockStyle.Top;
            pnlTimKiem.Height = 45;
            pnlTimKiem.Padding = new Padding(15, 5, 15, 5);

            txtTimKiem.Location = new Point(15, 8);
            txtTimKiem.Width = 350;

            ConfigureButton(btnTimKiem, "Tìm kiếm");
            btnTimKiem.Location = new Point(375, 5);

            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Controls.Add(btnTimKiem);

            // Danh sách
            dgvDanhSach.Dock = DockStyle.Fill;
            dgvDanhSach.ReadOnly = true;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.AllowUserToDeleteRows = false;
            dgvDanhSach.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDanhSach.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvDanhSach.MultiSelect = false;
            dgvDanhSach.RowHeadersVisible = false;

            // Thứ tự thêm control: Dock Fill trước, Dock Top sau
            Controls.Add(dgvDanhSach);
            Controls.Add(pnlTimKiem);
            Controls.Add(pnlNut);
            Controls.Add(pnlNhap);
            Controls.Add(lblTieuDe);

            ResumeLayout(false);
        }

        private void AddField(
            string text,
            Control control,
            int x,
            int y)
        {
            Label lbl = new Label
            {
                Text = text,
                Location = new Point(x, y + 4),
                Size = new Size(125, 25)
            };

            control.Location = new Point(x + 130, y);
            control.Width = 250;

            pnlNhap.Controls.Add(lbl);
            pnlNhap.Controls.Add(control);
        }

        private void ConfigureButton(Button button, string text)
        {
            button.Text = text;
            button.Width = 100;
            button.Height = 30;
            button.Margin = new Padding(0, 0, 8, 0);
        }
    }
}
