namespace LAB5
{
    partial class FrmKhaoSat
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
            this.lblChuyen = new System.Windows.Forms.Label();
            this.cboChuyen = new System.Windows.Forms.ComboBox();
            this.lblTenKhach = new System.Windows.Forms.Label();
            this.txtTenKhach = new System.Windows.Forms.TextBox();
            this.lblDiemDanhGia = new System.Windows.Forms.Label();
            this.numDiemDanhGia = new System.Windows.Forms.NumericUpDown();
            this.lblGopY = new System.Windows.Forms.Label();
            this.txtGopY = new System.Windows.Forms.TextBox();
            this.lblNgayKhaoSat = new System.Windows.Forms.Label();
            this.dtpNgayKhaoSat = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemDanhGia)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboChuyen);
            this.grpThongTin.Controls.Add(this.lblChuyen);
            this.grpThongTin.Controls.Add(this.txtTenKhach);
            this.grpThongTin.Controls.Add(this.lblTenKhach);
            this.grpThongTin.Controls.Add(this.numDiemDanhGia);
            this.grpThongTin.Controls.Add(this.lblDiemDanhGia);
            this.grpThongTin.Controls.Add(this.txtGopY);
            this.grpThongTin.Controls.Add(this.lblGopY);
            this.grpThongTin.Controls.Add(this.dtpNgayKhaoSat);
            this.grpThongTin.Controls.Add(this.lblNgayKhaoSat);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 132);
            this.grpThongTin.TabIndex = 15;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblChuyen
            // 
            this.lblChuyen.AutoSize = false;
            this.lblChuyen.Location = new System.Drawing.Point(12, 27);
            this.lblChuyen.Name = "lblChuyen";
            this.lblChuyen.Size = new System.Drawing.Size(110, 22);
            this.lblChuyen.TabIndex = 0;
            this.lblChuyen.Text = "Chuyến / Đoàn";
            // 
            // cboChuyen
            // 
            this.cboChuyen.Location = new System.Drawing.Point(124, 24);
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Size = new System.Drawing.Size(290, 27);
            this.cboChuyen.TabIndex = 1;
            this.cboChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblTenKhach
            // 
            this.lblTenKhach.AutoSize = false;
            this.lblTenKhach.Location = new System.Drawing.Point(442, 27);
            this.lblTenKhach.Name = "lblTenKhach";
            this.lblTenKhach.Size = new System.Drawing.Size(110, 22);
            this.lblTenKhach.TabIndex = 2;
            this.lblTenKhach.Text = "Tên khách";
            // 
            // txtTenKhach
            // 
            this.txtTenKhach.Location = new System.Drawing.Point(554, 24);
            this.txtTenKhach.Name = "txtTenKhach";
            this.txtTenKhach.Size = new System.Drawing.Size(290, 27);
            this.txtTenKhach.TabIndex = 3;
            // 
            // lblDiemDanhGia
            // 
            this.lblDiemDanhGia.AutoSize = false;
            this.lblDiemDanhGia.Location = new System.Drawing.Point(12, 61);
            this.lblDiemDanhGia.Name = "lblDiemDanhGia";
            this.lblDiemDanhGia.Size = new System.Drawing.Size(110, 22);
            this.lblDiemDanhGia.TabIndex = 4;
            this.lblDiemDanhGia.Text = "Điểm đánh giá (1-5)";
            // 
            // numDiemDanhGia
            // 
            this.numDiemDanhGia.Location = new System.Drawing.Point(124, 58);
            this.numDiemDanhGia.Name = "numDiemDanhGia";
            this.numDiemDanhGia.Size = new System.Drawing.Size(290, 27);
            this.numDiemDanhGia.TabIndex = 5;
            this.numDiemDanhGia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDiemDanhGia.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblGopY
            // 
            this.lblGopY.AutoSize = false;
            this.lblGopY.Location = new System.Drawing.Point(442, 61);
            this.lblGopY.Name = "lblGopY";
            this.lblGopY.Size = new System.Drawing.Size(110, 22);
            this.lblGopY.TabIndex = 6;
            this.lblGopY.Text = "Góp ý";
            // 
            // txtGopY
            // 
            this.txtGopY.Location = new System.Drawing.Point(554, 58);
            this.txtGopY.Name = "txtGopY";
            this.txtGopY.Size = new System.Drawing.Size(290, 27);
            this.txtGopY.TabIndex = 7;
            // 
            // lblNgayKhaoSat
            // 
            this.lblNgayKhaoSat.AutoSize = false;
            this.lblNgayKhaoSat.Location = new System.Drawing.Point(12, 95);
            this.lblNgayKhaoSat.Name = "lblNgayKhaoSat";
            this.lblNgayKhaoSat.Size = new System.Drawing.Size(110, 22);
            this.lblNgayKhaoSat.TabIndex = 8;
            this.lblNgayKhaoSat.Text = "Ngày khảo sát";
            // 
            // dtpNgayKhaoSat
            // 
            this.dtpNgayKhaoSat.Location = new System.Drawing.Point(124, 92);
            this.dtpNgayKhaoSat.Name = "dtpNgayKhaoSat";
            this.dtpNgayKhaoSat.Size = new System.Drawing.Size(290, 27);
            this.dtpNgayKhaoSat.TabIndex = 9;
            this.dtpNgayKhaoSat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 154);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Ghi nhận";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(130, 154);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(248, 154);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(366, 154);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 13;
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
            this.dgvDanhSach.TabIndex = 14;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // FrmKhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 472);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmKhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phiếu khảo sát khách hàng";
            this.Load += new System.EventHandler(this.FrmKhaoSat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiemDanhGia)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblChuyen;
        private System.Windows.Forms.ComboBox cboChuyen;
        private System.Windows.Forms.Label lblTenKhach;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.Label lblDiemDanhGia;
        private System.Windows.Forms.NumericUpDown numDiemDanhGia;
        private System.Windows.Forms.Label lblGopY;
        private System.Windows.Forms.TextBox txtGopY;
        private System.Windows.Forms.Label lblNgayKhaoSat;
        private System.Windows.Forms.DateTimePicker dtpNgayKhaoSat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
