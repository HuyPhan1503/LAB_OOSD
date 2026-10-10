namespace LAB5
{
    partial class FrmChuyen
    {
        /// <summary>Required designer variable.</summary>
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
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaChuyen = new System.Windows.Forms.Label();
            this.txtMaChuyen = new System.Windows.Forms.TextBox();
            this.lblTour = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.dtpNgayVe = new System.Windows.Forms.DateTimePicker();
            this.lblSoKhach = new System.Windows.Forms.Label();
            this.numSoKhach = new System.Windows.Forms.NumericUpDown();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoKhach)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtMaChuyen);
            this.grpThongTin.Controls.Add(this.lblMaChuyen);
            this.grpThongTin.Controls.Add(this.cboTour);
            this.grpThongTin.Controls.Add(this.lblTour);
            this.grpThongTin.Controls.Add(this.dtpNgayDi);
            this.grpThongTin.Controls.Add(this.lblNgayDi);
            this.grpThongTin.Controls.Add(this.dtpNgayVe);
            this.grpThongTin.Controls.Add(this.lblNgayVe);
            this.grpThongTin.Controls.Add(this.numSoKhach);
            this.grpThongTin.Controls.Add(this.lblSoKhach);
            this.grpThongTin.Controls.Add(this.cboTinhTrang);
            this.grpThongTin.Controls.Add(this.lblTinhTrang);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 132);
            this.grpThongTin.TabIndex = 19;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblMaChuyen
            // 
            this.lblMaChuyen.AutoSize = false;
            this.lblMaChuyen.Location = new System.Drawing.Point(12, 27);
            this.lblMaChuyen.Name = "lblMaChuyen";
            this.lblMaChuyen.Size = new System.Drawing.Size(110, 22);
            this.lblMaChuyen.TabIndex = 0;
            this.lblMaChuyen.Text = "Mã chuyến";
            // 
            // txtMaChuyen
            // 
            this.txtMaChuyen.Location = new System.Drawing.Point(124, 24);
            this.txtMaChuyen.Name = "txtMaChuyen";
            this.txtMaChuyen.Size = new System.Drawing.Size(290, 27);
            this.txtMaChuyen.TabIndex = 1;
            // 
            // lblTour
            // 
            this.lblTour.AutoSize = false;
            this.lblTour.Location = new System.Drawing.Point(442, 27);
            this.lblTour.Name = "lblTour";
            this.lblTour.Size = new System.Drawing.Size(110, 22);
            this.lblTour.TabIndex = 2;
            this.lblTour.Text = "Tour";
            // 
            // cboTour
            // 
            this.cboTour.Location = new System.Drawing.Point(554, 24);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(290, 27);
            this.cboTour.TabIndex = 3;
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.AutoSize = false;
            this.lblNgayDi.Location = new System.Drawing.Point(12, 61);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Size = new System.Drawing.Size(110, 22);
            this.lblNgayDi.TabIndex = 4;
            this.lblNgayDi.Text = "Ngày đi";
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.Location = new System.Drawing.Point(124, 58);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(290, 27);
            this.dtpNgayDi.TabIndex = 5;
            this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblNgayVe
            // 
            this.lblNgayVe.AutoSize = false;
            this.lblNgayVe.Location = new System.Drawing.Point(442, 61);
            this.lblNgayVe.Name = "lblNgayVe";
            this.lblNgayVe.Size = new System.Drawing.Size(110, 22);
            this.lblNgayVe.TabIndex = 6;
            this.lblNgayVe.Text = "Ngày về";
            // 
            // dtpNgayVe
            // 
            this.dtpNgayVe.Location = new System.Drawing.Point(554, 58);
            this.dtpNgayVe.Name = "dtpNgayVe";
            this.dtpNgayVe.Size = new System.Drawing.Size(290, 27);
            this.dtpNgayVe.TabIndex = 7;
            this.dtpNgayVe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblSoKhach
            // 
            this.lblSoKhach.AutoSize = false;
            this.lblSoKhach.Location = new System.Drawing.Point(12, 95);
            this.lblSoKhach.Name = "lblSoKhach";
            this.lblSoKhach.Size = new System.Drawing.Size(110, 22);
            this.lblSoKhach.TabIndex = 8;
            this.lblSoKhach.Text = "Số khách hiện tại";
            // 
            // numSoKhach
            // 
            this.numSoKhach.Location = new System.Drawing.Point(124, 92);
            this.numSoKhach.Name = "numSoKhach";
            this.numSoKhach.Size = new System.Drawing.Size(290, 27);
            this.numSoKhach.TabIndex = 9;
            this.numSoKhach.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numSoKhach.ReadOnly = true;
            this.numSoKhach.Increment = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = false;
            this.lblTinhTrang.Location = new System.Drawing.Point(442, 95);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(110, 22);
            this.lblTinhTrang.TabIndex = 10;
            this.lblTinhTrang.Text = "Tình trạng";
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.Location = new System.Drawing.Point(554, 92);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(290, 27);
            this.cboTinhTrang.TabIndex = 11;
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.Items.AddRange(new object[] { "Chưa khởi hành", "Đang diễn ra", "Đã kết thúc", "Đã hủy" });
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 154);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(130, 154);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 34);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(248, 154);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(366, 154);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 34);
            this.btnTimKiem.TabIndex = 15;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(484, 154);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(602, 154);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 17;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 198);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(860, 260);
            this.dgvDanhSach.TabIndex = 18;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // FrmChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 472);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý chuyến đi";
            this.Load += new System.EventHandler(this.FrmChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoKhach)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaChuyen;
        private System.Windows.Forms.TextBox txtMaChuyen;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.DateTimePicker dtpNgayDi;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.DateTimePicker dtpNgayVe;
        private System.Windows.Forms.Label lblSoKhach;
        private System.Windows.Forms.NumericUpDown numSoKhach;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
