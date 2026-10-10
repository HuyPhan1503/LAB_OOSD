namespace LAB5
{
    partial class FrmLuong
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
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblLuongCoBan = new System.Windows.Forms.Label();
            this.numLuongCoBan = new System.Windows.Forms.NumericUpDown();
            this.lblSoTour = new System.Windows.Forms.Label();
            this.numSoTour = new System.Windows.Forms.NumericUpDown();
            this.lblLuongTheoTour = new System.Windows.Forms.Label();
            this.numLuongTheoTour = new System.Windows.Forms.NumericUpDown();
            this.lblTongLuong = new System.Windows.Forms.Label();
            this.numTongLuong = new System.Windows.Forms.NumericUpDown();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongCoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongTheoTour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTongLuong)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboNhanVien);
            this.grpThongTin.Controls.Add(this.lblNhanVien);
            this.grpThongTin.Controls.Add(this.numThang);
            this.grpThongTin.Controls.Add(this.lblThang);
            this.grpThongTin.Controls.Add(this.numNam);
            this.grpThongTin.Controls.Add(this.lblNam);
            this.grpThongTin.Controls.Add(this.numLuongCoBan);
            this.grpThongTin.Controls.Add(this.lblLuongCoBan);
            this.grpThongTin.Controls.Add(this.numSoTour);
            this.grpThongTin.Controls.Add(this.lblSoTour);
            this.grpThongTin.Controls.Add(this.numLuongTheoTour);
            this.grpThongTin.Controls.Add(this.lblLuongTheoTour);
            this.grpThongTin.Controls.Add(this.numTongLuong);
            this.grpThongTin.Controls.Add(this.lblTongLuong);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 166);
            this.grpThongTin.TabIndex = 18;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = false;
            this.lblNhanVien.Location = new System.Drawing.Point(12, 27);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(110, 22);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Nhân viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Location = new System.Drawing.Point(124, 24);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(290, 27);
            this.cboNhanVien.TabIndex = 1;
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = false;
            this.lblThang.Location = new System.Drawing.Point(442, 27);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(110, 22);
            this.lblThang.TabIndex = 2;
            this.lblThang.Text = "Tháng";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(554, 24);
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(290, 27);
            this.numThang.TabIndex = 3;
            this.numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = false;
            this.lblNam.Location = new System.Drawing.Point(12, 61);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(110, 22);
            this.lblNam.TabIndex = 4;
            this.lblNam.Text = "Năm";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(124, 58);
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(290, 27);
            this.numNam.TabIndex = 5;
            this.numNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            // 
            // lblLuongCoBan
            // 
            this.lblLuongCoBan.AutoSize = false;
            this.lblLuongCoBan.Location = new System.Drawing.Point(442, 61);
            this.lblLuongCoBan.Name = "lblLuongCoBan";
            this.lblLuongCoBan.Size = new System.Drawing.Size(110, 22);
            this.lblLuongCoBan.TabIndex = 6;
            this.lblLuongCoBan.Text = "Lương cơ bản";
            // 
            // numLuongCoBan
            // 
            this.numLuongCoBan.Location = new System.Drawing.Point(554, 58);
            this.numLuongCoBan.Name = "numLuongCoBan";
            this.numLuongCoBan.Size = new System.Drawing.Size(290, 27);
            this.numLuongCoBan.TabIndex = 7;
            this.numLuongCoBan.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numLuongCoBan.ThousandsSeparator = true;
            // 
            // lblSoTour
            // 
            this.lblSoTour.AutoSize = false;
            this.lblSoTour.Location = new System.Drawing.Point(12, 95);
            this.lblSoTour.Name = "lblSoTour";
            this.lblSoTour.Size = new System.Drawing.Size(110, 22);
            this.lblSoTour.TabIndex = 8;
            this.lblSoTour.Text = "Số tour trong tháng";
            // 
            // numSoTour
            // 
            this.numSoTour.Location = new System.Drawing.Point(124, 92);
            this.numSoTour.Name = "numSoTour";
            this.numSoTour.Size = new System.Drawing.Size(290, 27);
            this.numSoTour.TabIndex = 9;
            this.numSoTour.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numSoTour.ReadOnly = true;
            this.numSoTour.Increment = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblLuongTheoTour
            // 
            this.lblLuongTheoTour.AutoSize = false;
            this.lblLuongTheoTour.Location = new System.Drawing.Point(442, 95);
            this.lblLuongTheoTour.Name = "lblLuongTheoTour";
            this.lblLuongTheoTour.Size = new System.Drawing.Size(110, 22);
            this.lblLuongTheoTour.TabIndex = 10;
            this.lblLuongTheoTour.Text = "Lương theo tour";
            // 
            // numLuongTheoTour
            // 
            this.numLuongTheoTour.Location = new System.Drawing.Point(554, 92);
            this.numLuongTheoTour.Name = "numLuongTheoTour";
            this.numLuongTheoTour.Size = new System.Drawing.Size(290, 27);
            this.numLuongTheoTour.TabIndex = 11;
            this.numLuongTheoTour.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numLuongTheoTour.ThousandsSeparator = true;
            this.numLuongTheoTour.ReadOnly = true;
            this.numLuongTheoTour.Increment = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblTongLuong
            // 
            this.lblTongLuong.AutoSize = false;
            this.lblTongLuong.Location = new System.Drawing.Point(12, 129);
            this.lblTongLuong.Name = "lblTongLuong";
            this.lblTongLuong.Size = new System.Drawing.Size(110, 22);
            this.lblTongLuong.TabIndex = 12;
            this.lblTongLuong.Text = "Tổng lương";
            // 
            // numTongLuong
            // 
            this.numTongLuong.Location = new System.Drawing.Point(124, 126);
            this.numTongLuong.Name = "numTongLuong";
            this.numTongLuong.Size = new System.Drawing.Size(290, 27);
            this.numTongLuong.TabIndex = 13;
            this.numTongLuong.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numTongLuong.ThousandsSeparator = true;
            this.numTongLuong.ReadOnly = true;
            this.numTongLuong.Increment = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Location = new System.Drawing.Point(12, 188);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(110, 34);
            this.btnTinhLuong.TabIndex = 14;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(130, 188);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 34);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu bảng lương";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(248, 188);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 16;
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
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 232);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(860, 260);
            this.dgvDanhSach.TabIndex = 17;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // FrmLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 506);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán lương hướng dẫn viên";
            this.Load += new System.EventHandler(this.FrmLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongCoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuongTheoTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTongLuong)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblLuongCoBan;
        private System.Windows.Forms.NumericUpDown numLuongCoBan;
        private System.Windows.Forms.Label lblSoTour;
        private System.Windows.Forms.NumericUpDown numSoTour;
        private System.Windows.Forms.Label lblLuongTheoTour;
        private System.Windows.Forms.NumericUpDown numLuongTheoTour;
        private System.Windows.Forms.Label lblTongLuong;
        private System.Windows.Forms.NumericUpDown numTongLuong;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
