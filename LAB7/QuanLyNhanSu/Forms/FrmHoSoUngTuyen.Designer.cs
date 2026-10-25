
namespace LAB07.Forms
{
    partial class FrmHoSoUngTuyen
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblTrinhDo;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.Label lblPhongBan;
        private System.Windows.Forms.Label lblNgayUngTuyen;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTimKiem;

        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTrinhDo;
        private System.Windows.Forms.TextBox txtViTriUngTuyen;
        private System.Windows.Forms.TextBox txtTimKiem;

        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgayUngTuyen;

        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.ComboBox cboPhongBan;
        private System.Windows.Forms.ComboBox cboTrangThai;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;

        private System.Windows.Forms.DataGridView dgvHoSo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblTrinhDo = new System.Windows.Forms.Label();
            this.lblViTri = new System.Windows.Forms.Label();
            this.lblPhongBan = new System.Windows.Forms.Label();
            this.lblNgayUngTuyen = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();

            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTrinhDo = new System.Windows.Forms.TextBox();
            this.txtViTriUngTuyen = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();

            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayUngTuyen = new System.Windows.Forms.DateTimePicker();

            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();

            this.dgvHoSo = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 760);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hồ sơ ứng tuyển";
            this.Load += new System.EventHandler(this.FrmHoSoUngTuyen_Load);

            // Title
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(390, 15);
            this.lblTieuDe.Text = "QUẢN LÝ HỒ SƠ ỨNG TUYỂN";

            // Labels
            SetLabel(this.lblHoTen, "Họ và tên:", 25, 75);
            SetLabel(this.lblNgaySinh, "Ngày sinh:", 430, 75);
            SetLabel(this.lblGioiTinh, "Giới tính:", 835, 75);

            SetLabel(this.lblCCCD, "CCCD:", 25, 120);
            SetLabel(this.lblDiaChi, "Địa chỉ:", 430, 120);
            SetLabel(this.lblDienThoai, "Điện thoại:", 835, 120);

            SetLabel(this.lblEmail, "Email:", 25, 165);
            SetLabel(this.lblTrinhDo, "Trình độ:", 430, 165);
            SetLabel(this.lblViTri, "Vị trí ứng tuyển:", 835, 165);

            SetLabel(this.lblPhongBan, "Phòng ban:", 25, 210);
            SetLabel(this.lblNgayUngTuyen, "Ngày ứng tuyển:", 430, 210);
            SetLabel(this.lblTrangThai, "Trạng thái:", 835, 210);

            // TextBoxes
            SetTextBox(this.txtHoTen, 135, 72, 260);
            SetTextBox(this.txtCCCD, 135, 117, 260);
            SetTextBox(this.txtEmail, 135, 162, 260);

            SetTextBox(this.txtDiaChi, 540, 117, 260);
            SetTextBox(this.txtTrinhDo, 540, 162, 260);

            SetTextBox(this.txtDienThoai, 950, 117, 260);
            SetTextBox(this.txtViTriUngTuyen, 950, 162, 260);

            // DateTimePickers
            this.dtpNgaySinh.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Location = new System.Drawing.Point(540, 72);
            this.dtpNgaySinh.Size = new System.Drawing.Size(260, 27);

            this.dtpNgayUngTuyen.Format =
                System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayUngTuyen.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayUngTuyen.Location = new System.Drawing.Point(540, 207);
            this.dtpNgayUngTuyen.Size = new System.Drawing.Size(260, 27);

            // ComboBoxes
            SetComboBox(this.cboGioiTinh, 950, 72, 260);
            SetComboBox(this.cboPhongBan, 135, 207, 260);
            SetComboBox(this.cboTrangThai, 950, 207, 260);

            // Buttons
            SetButton(this.btnThem, "Thêm", 135, 255, 100);
            SetButton(this.btnSua, "Sửa", 245, 255, 100);
            SetButton(this.btnXoa, "Xóa", 355, 255, 100);
            SetButton(this.btnLamMoi, "Làm mới", 465, 255, 110);

            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // Search
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(25, 310);
            this.lblTimKiem.Size = new System.Drawing.Size(75, 20);
            this.lblTimKiem.Text = "Tìm kiếm:";

            this.txtTimKiem.Location = new System.Drawing.Point(110, 307);
            this.txtTimKiem.Size = new System.Drawing.Size(400, 27);
            this.txtTimKiem.KeyDown +=
                new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);

            this.btnTimKiem.Location = new System.Drawing.Point(520, 305);
            this.btnTimKiem.Size = new System.Drawing.Size(110, 32);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click +=
                new System.EventHandler(this.btnTimKiem_Click);

            // DataGridView
            this.dgvHoSo.Location = new System.Drawing.Point(25, 350);
            this.dgvHoSo.Size = new System.Drawing.Size(1200, 385);
            this.dgvHoSo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;
            this.dgvHoSo.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoSo.ColumnHeadersHeight = 35;
            this.dgvHoSo.RowTemplate.Height = 28;
            this.dgvHoSo.ReadOnly = true;
            this.dgvHoSo.AllowUserToAddRows = false;
            this.dgvHoSo.AllowUserToDeleteRows = false;
            this.dgvHoSo.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoSo.MultiSelect = false;
            this.dgvHoSo.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHoSo.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvHoSo_CellClick);

            // Add controls
            this.Controls.Add(this.lblTieuDe);

            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblDienThoai);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTrinhDo);
            this.Controls.Add(this.lblViTri);
            this.Controls.Add(this.lblPhongBan);
            this.Controls.Add(this.lblNgayUngTuyen);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblTimKiem);

            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTrinhDo);
            this.Controls.Add(this.txtViTriUngTuyen);
            this.Controls.Add(this.txtTimKiem);

            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.dtpNgayUngTuyen);

            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.cboTrangThai);

            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);

            this.Controls.Add(this.dgvHoSo);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetLabel(
            System.Windows.Forms.Label label,
            string text,
            int x,
            int y)
        {
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(90, 20);
            label.Text = text;
        }

        private void SetTextBox(
            System.Windows.Forms.TextBox textBox,
            int x,
            int y,
            int width)
        {
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(width, 27);
        }

        private void SetComboBox(
            System.Windows.Forms.ComboBox comboBox,
            int x,
            int y,
            int width)
        {
            comboBox.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox.Location = new System.Drawing.Point(x, y);
            comboBox.Size = new System.Drawing.Size(width, 28);
        }

        private void SetButton(
            System.Windows.Forms.Button button,
            string text,
            int x,
            int y,
            int width)
        {
            button.Location = new System.Drawing.Point(x, y);
            button.Size = new System.Drawing.Size(width, 34);
            button.Text = text;
            button.UseVisualStyleBackColor = true;
        }
    }
}
