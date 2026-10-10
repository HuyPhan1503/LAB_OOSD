namespace LAB5
{
    partial class FrmPhanCongHDV
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
            this.lblLoaiPhanCong = new System.Windows.Forms.Label();
            this.cboLoaiPhanCong = new System.Windows.Forms.ComboBox();
            this.lblChuyenDoan = new System.Windows.Forms.Label();
            this.cboChuyenDoan = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboLoaiPhanCong);
            this.grpThongTin.Controls.Add(this.lblLoaiPhanCong);
            this.grpThongTin.Controls.Add(this.cboChuyenDoan);
            this.grpThongTin.Controls.Add(this.lblChuyenDoan);
            this.grpThongTin.Controls.Add(this.cboNhanVien);
            this.grpThongTin.Controls.Add(this.lblNhanVien);
            this.grpThongTin.Controls.Add(this.dtpTuNgay);
            this.grpThongTin.Controls.Add(this.lblTuNgay);
            this.grpThongTin.Controls.Add(this.dtpDenNgay);
            this.grpThongTin.Controls.Add(this.lblDenNgay);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 132);
            this.grpThongTin.TabIndex = 14;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblLoaiPhanCong
            // 
            this.lblLoaiPhanCong.AutoSize = false;
            this.lblLoaiPhanCong.Location = new System.Drawing.Point(12, 27);
            this.lblLoaiPhanCong.Name = "lblLoaiPhanCong";
            this.lblLoaiPhanCong.Size = new System.Drawing.Size(110, 22);
            this.lblLoaiPhanCong.TabIndex = 0;
            this.lblLoaiPhanCong.Text = "Phân công cho";
            // 
            // cboLoaiPhanCong
            // 
            this.cboLoaiPhanCong.Location = new System.Drawing.Point(124, 24);
            this.cboLoaiPhanCong.Name = "cboLoaiPhanCong";
            this.cboLoaiPhanCong.Size = new System.Drawing.Size(290, 27);
            this.cboLoaiPhanCong.TabIndex = 1;
            this.cboLoaiPhanCong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhanCong.Items.AddRange(new object[] { "Chuyến khách lẻ", "Đoàn" });
            // 
            // lblChuyenDoan
            // 
            this.lblChuyenDoan.AutoSize = false;
            this.lblChuyenDoan.Location = new System.Drawing.Point(442, 27);
            this.lblChuyenDoan.Name = "lblChuyenDoan";
            this.lblChuyenDoan.Size = new System.Drawing.Size(110, 22);
            this.lblChuyenDoan.TabIndex = 2;
            this.lblChuyenDoan.Text = "Chuyến / Đoàn";
            // 
            // cboChuyenDoan
            // 
            this.cboChuyenDoan.Location = new System.Drawing.Point(554, 24);
            this.cboChuyenDoan.Name = "cboChuyenDoan";
            this.cboChuyenDoan.Size = new System.Drawing.Size(290, 27);
            this.cboChuyenDoan.TabIndex = 3;
            this.cboChuyenDoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = false;
            this.lblNhanVien.Location = new System.Drawing.Point(12, 61);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(110, 22);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Hướng dẫn viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Location = new System.Drawing.Point(124, 58);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(290, 27);
            this.cboNhanVien.TabIndex = 5;
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = false;
            this.lblTuNgay.Location = new System.Drawing.Point(442, 61);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(110, 22);
            this.lblTuNgay.TabIndex = 6;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(554, 58);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(290, 27);
            this.dtpTuNgay.TabIndex = 7;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = false;
            this.lblDenNgay.Location = new System.Drawing.Point(12, 95);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(110, 22);
            this.lblDenNgay.TabIndex = 8;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(124, 92);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(290, 27);
            this.dtpDenNgay.TabIndex = 9;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(12, 154);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(110, 34);
            this.btnPhanCong.TabIndex = 10;
            this.btnPhanCong.Text = "Phân công";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(130, 154);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 34);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy phân công";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(248, 154);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 12;
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
            this.dgvDanhSach.TabIndex = 13;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // FrmPhanCongHDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 472);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmPhanCongHDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân công hướng dẫn viên";
            this.Load += new System.EventHandler(this.FrmPhanCongHDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblLoaiPhanCong;
        private System.Windows.Forms.ComboBox cboLoaiPhanCong;
        private System.Windows.Forms.Label lblChuyenDoan;
        private System.Windows.Forms.ComboBox cboChuyenDoan;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
