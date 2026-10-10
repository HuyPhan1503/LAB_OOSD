namespace LAB5
{
    partial class FrmThanhToanVe
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
            this.lblLoaiTour = new System.Windows.Forms.Label();
            this.cboLoaiTour = new System.Windows.Forms.ComboBox();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.lblChuyen = new System.Windows.Forms.Label();
            this.cboChuyen = new System.Windows.Forms.ComboBox();
            this.lblSoKhach = new System.Windows.Forms.Label();
            this.numSoKhach = new System.Windows.Forms.NumericUpDown();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.numTongTien = new System.Windows.Forms.NumericUpDown();
            this.lblDaDatCoc = new System.Windows.Forms.Label();
            this.numDaDatCoc = new System.Windows.Forms.NumericUpDown();
            this.lblSoTienThu = new System.Windows.Forms.Label();
            this.numSoTienThu = new System.Windows.Forms.NumericUpDown();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.btnTinhTien = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnInBienNhan = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoKhach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTongTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDaDatCoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienThu)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboLoaiTour);
            this.grpThongTin.Controls.Add(this.lblLoaiTour);
            this.grpThongTin.Controls.Add(this.txtSoHoaDon);
            this.grpThongTin.Controls.Add(this.lblSoHoaDon);
            this.grpThongTin.Controls.Add(this.cboChuyen);
            this.grpThongTin.Controls.Add(this.lblChuyen);
            this.grpThongTin.Controls.Add(this.numSoKhach);
            this.grpThongTin.Controls.Add(this.lblSoKhach);
            this.grpThongTin.Controls.Add(this.numTongTien);
            this.grpThongTin.Controls.Add(this.lblTongTien);
            this.grpThongTin.Controls.Add(this.numDaDatCoc);
            this.grpThongTin.Controls.Add(this.lblDaDatCoc);
            this.grpThongTin.Controls.Add(this.numSoTienThu);
            this.grpThongTin.Controls.Add(this.lblSoTienThu);
            this.grpThongTin.Controls.Add(this.cboPhuongThuc);
            this.grpThongTin.Controls.Add(this.lblPhuongThuc);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 166);
            this.grpThongTin.TabIndex = 21;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblLoaiTour
            // 
            this.lblLoaiTour.AutoSize = false;
            this.lblLoaiTour.Location = new System.Drawing.Point(12, 27);
            this.lblLoaiTour.Name = "lblLoaiTour";
            this.lblLoaiTour.Size = new System.Drawing.Size(110, 22);
            this.lblLoaiTour.TabIndex = 0;
            this.lblLoaiTour.Text = "Loại tour";
            // 
            // cboLoaiTour
            // 
            this.cboLoaiTour.Location = new System.Drawing.Point(124, 24);
            this.cboLoaiTour.Name = "cboLoaiTour";
            this.cboLoaiTour.Size = new System.Drawing.Size(290, 27);
            this.cboLoaiTour.TabIndex = 1;
            this.cboLoaiTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiTour.Items.AddRange(new object[] { "Khách lẻ", "Khách đoàn" });
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.AutoSize = false;
            this.lblSoHoaDon.Location = new System.Drawing.Point(442, 27);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(110, 22);
            this.lblSoHoaDon.TabIndex = 2;
            this.lblSoHoaDon.Text = "Số hóa đơn";
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(554, 24);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(290, 27);
            this.txtSoHoaDon.TabIndex = 3;
            // 
            // lblChuyen
            // 
            this.lblChuyen.AutoSize = false;
            this.lblChuyen.Location = new System.Drawing.Point(12, 61);
            this.lblChuyen.Name = "lblChuyen";
            this.lblChuyen.Size = new System.Drawing.Size(110, 22);
            this.lblChuyen.TabIndex = 4;
            this.lblChuyen.Text = "Chuyến / Đoàn";
            // 
            // cboChuyen
            // 
            this.cboChuyen.Location = new System.Drawing.Point(124, 58);
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Size = new System.Drawing.Size(290, 27);
            this.cboChuyen.TabIndex = 5;
            this.cboChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblSoKhach
            // 
            this.lblSoKhach.AutoSize = false;
            this.lblSoKhach.Location = new System.Drawing.Point(442, 61);
            this.lblSoKhach.Name = "lblSoKhach";
            this.lblSoKhach.Size = new System.Drawing.Size(110, 22);
            this.lblSoKhach.TabIndex = 6;
            this.lblSoKhach.Text = "Số khách";
            // 
            // numSoKhach
            // 
            this.numSoKhach.Location = new System.Drawing.Point(554, 58);
            this.numSoKhach.Name = "numSoKhach";
            this.numSoKhach.Size = new System.Drawing.Size(290, 27);
            this.numSoKhach.TabIndex = 7;
            this.numSoKhach.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = false;
            this.lblTongTien.Location = new System.Drawing.Point(12, 95);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(110, 22);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "Tổng tiền phải trả";
            // 
            // numTongTien
            // 
            this.numTongTien.Location = new System.Drawing.Point(124, 92);
            this.numTongTien.Name = "numTongTien";
            this.numTongTien.Size = new System.Drawing.Size(290, 27);
            this.numTongTien.TabIndex = 9;
            this.numTongTien.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numTongTien.ThousandsSeparator = true;
            this.numTongTien.ReadOnly = true;
            this.numTongTien.Increment = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblDaDatCoc
            // 
            this.lblDaDatCoc.AutoSize = false;
            this.lblDaDatCoc.Location = new System.Drawing.Point(442, 95);
            this.lblDaDatCoc.Name = "lblDaDatCoc";
            this.lblDaDatCoc.Size = new System.Drawing.Size(110, 22);
            this.lblDaDatCoc.TabIndex = 10;
            this.lblDaDatCoc.Text = "Đã đặt cọc";
            // 
            // numDaDatCoc
            // 
            this.numDaDatCoc.Location = new System.Drawing.Point(554, 92);
            this.numDaDatCoc.Name = "numDaDatCoc";
            this.numDaDatCoc.Size = new System.Drawing.Size(290, 27);
            this.numDaDatCoc.TabIndex = 11;
            this.numDaDatCoc.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numDaDatCoc.ThousandsSeparator = true;
            this.numDaDatCoc.ReadOnly = true;
            this.numDaDatCoc.Increment = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblSoTienThu
            // 
            this.lblSoTienThu.AutoSize = false;
            this.lblSoTienThu.Location = new System.Drawing.Point(12, 129);
            this.lblSoTienThu.Name = "lblSoTienThu";
            this.lblSoTienThu.Size = new System.Drawing.Size(110, 22);
            this.lblSoTienThu.TabIndex = 12;
            this.lblSoTienThu.Text = "Số tiền thanh toán";
            // 
            // numSoTienThu
            // 
            this.numSoTienThu.Location = new System.Drawing.Point(124, 126);
            this.numSoTienThu.Name = "numSoTienThu";
            this.numSoTienThu.Size = new System.Drawing.Size(290, 27);
            this.numSoTienThu.TabIndex = 13;
            this.numSoTienThu.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numSoTienThu.ThousandsSeparator = true;
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoSize = false;
            this.lblPhuongThuc.Location = new System.Drawing.Point(442, 129);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(110, 22);
            this.lblPhuongThuc.TabIndex = 14;
            this.lblPhuongThuc.Text = "Phương thức";
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.Location = new System.Drawing.Point(554, 126);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(290, 27);
            this.cboPhuongThuc.TabIndex = 15;
            this.cboPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ" });
            // 
            // btnTinhTien
            // 
            this.btnTinhTien.Location = new System.Drawing.Point(12, 188);
            this.btnTinhTien.Name = "btnTinhTien";
            this.btnTinhTien.Size = new System.Drawing.Size(110, 34);
            this.btnTinhTien.TabIndex = 16;
            this.btnTinhTien.Text = "Tính tiền";
            this.btnTinhTien.UseVisualStyleBackColor = true;
            this.btnTinhTien.Click += new System.EventHandler(this.btnTinhTien_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(130, 188);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(110, 34);
            this.btnThanhToan.TabIndex = 17;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnInBienNhan
            // 
            this.btnInBienNhan.Location = new System.Drawing.Point(248, 188);
            this.btnInBienNhan.Name = "btnInBienNhan";
            this.btnInBienNhan.Size = new System.Drawing.Size(110, 34);
            this.btnInBienNhan.TabIndex = 18;
            this.btnInBienNhan.Text = "In biên nhận";
            this.btnInBienNhan.UseVisualStyleBackColor = true;
            this.btnInBienNhan.Click += new System.EventHandler(this.btnInBienNhan_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(366, 188);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 34);
            this.btnDong.TabIndex = 19;
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
            this.dgvDanhSach.TabIndex = 20;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            // 
            // FrmThanhToanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 506);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnTinhTien);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnInBienNhan);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmThanhToanVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán vé tour";
            this.Load += new System.EventHandler(this.FrmThanhToanVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoKhach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTongTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDaDatCoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienThu)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblLoaiTour;
        private System.Windows.Forms.ComboBox cboLoaiTour;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label lblChuyen;
        private System.Windows.Forms.ComboBox cboChuyen;
        private System.Windows.Forms.Label lblSoKhach;
        private System.Windows.Forms.NumericUpDown numSoKhach;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.NumericUpDown numTongTien;
        private System.Windows.Forms.Label lblDaDatCoc;
        private System.Windows.Forms.NumericUpDown numDaDatCoc;
        private System.Windows.Forms.Label lblSoTienThu;
        private System.Windows.Forms.NumericUpDown numSoTienThu;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnInBienNhan;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
