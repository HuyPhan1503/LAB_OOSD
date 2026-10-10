namespace LAB5
{
    partial class FrmThongKe
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
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiThongKe = new System.Windows.Forms.Label();
            this.cboLoaiThongKe = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.dtpTuNgay);
            this.grpThongTin.Controls.Add(this.lblTuNgay);
            this.grpThongTin.Controls.Add(this.dtpDenNgay);
            this.grpThongTin.Controls.Add(this.lblDenNgay);
            this.grpThongTin.Controls.Add(this.cboLoaiThongKe);
            this.grpThongTin.Controls.Add(this.lblLoaiThongKe);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 98);
            this.grpThongTin.TabIndex = 10;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = false;
            this.lblTuNgay.Location = new System.Drawing.Point(12, 27);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(110, 22);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(124, 24);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(290, 27);
            this.dtpTuNgay.TabIndex = 1;
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = false;
            this.lblDenNgay.Location = new System.Drawing.Point(442, 27);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(110, 22);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(554, 24);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(290, 27);
            this.dtpDenNgay.TabIndex = 3;
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            // 
            // lblLoaiThongKe
            // 
            this.lblLoaiThongKe.AutoSize = false;
            this.lblLoaiThongKe.Location = new System.Drawing.Point(12, 61);
            this.lblLoaiThongKe.Name = "lblLoaiThongKe";
            this.lblLoaiThongKe.Size = new System.Drawing.Size(110, 22);
            this.lblLoaiThongKe.TabIndex = 4;
            this.lblLoaiThongKe.Text = "Loại thống kê";
            // 
            // cboLoaiThongKe
            // 
            this.cboLoaiThongKe.Location = new System.Drawing.Point(124, 58);
            this.cboLoaiThongKe.Name = "cboLoaiThongKe";
            this.cboLoaiThongKe.Size = new System.Drawing.Size(290, 27);
            this.cboLoaiThongKe.TabIndex = 5;
            this.cboLoaiThongKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThongKe.Items.AddRange(new object[] { "Tour", "Dịch vụ", "Số lượng khách", "Doanh thu", "Số tour của nhân viên" });
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(12, 120);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(110, 34);
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(130, 120);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(110, 34);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất file";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(248, 120);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 8;
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
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 164);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(860, 260);
            this.dgvDanhSach.TabIndex = 9;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 438);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLoaiThongKe;
        private System.Windows.Forms.ComboBox cboLoaiThongKe;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
