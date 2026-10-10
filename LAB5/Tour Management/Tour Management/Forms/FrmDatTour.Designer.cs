namespace LAB5
{
    partial class FrmDatTour
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
            this.lblLoaiKhach = new System.Windows.Forms.Label();
            this.cboLoaiKhach = new System.Windows.Forms.ComboBox();
            this.lblTour = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.dtpNgayVe = new System.Windows.Forms.DateTimePicker();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.numSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboLoaiKhach);
            this.grpThongTin.Controls.Add(this.lblLoaiKhach);
            this.grpThongTin.Controls.Add(this.cboTour);
            this.grpThongTin.Controls.Add(this.lblTour);
            this.grpThongTin.Controls.Add(this.dtpNgayDi);
            this.grpThongTin.Controls.Add(this.lblNgayDi);
            this.grpThongTin.Controls.Add(this.dtpNgayVe);
            this.grpThongTin.Controls.Add(this.lblNgayVe);
            this.grpThongTin.Controls.Add(this.numSoNguoi);
            this.grpThongTin.Controls.Add(this.lblSoNguoi);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 132);
            this.grpThongTin.TabIndex = 13;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblLoaiKhach
            // 
            this.lblLoaiKhach.AutoSize = false;
            this.lblLoaiKhach.Location = new System.Drawing.Point(12, 27);
            this.lblLoaiKhach.Name = "lblLoaiKhach";
            this.lblLoaiKhach.Size = new System.Drawing.Size(110, 22);
            this.lblLoaiKhach.TabIndex = 0;
            this.lblLoaiKhach.Text = "Loại khách";
            // 
            // cboLoaiKhach
            // 
            this.cboLoaiKhach.Location = new System.Drawing.Point(124, 24);
            this.cboLoaiKhach.Name = "cboLoaiKhach";
            this.cboLoaiKhach.Size = new System.Drawing.Size(290, 27);
            this.cboLoaiKhach.TabIndex = 1;
            this.cboLoaiKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKhach.Items.AddRange(new object[] { "Khách đoàn (trên 12 người)", "Khách lẻ (dưới 12 người)" });
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
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = false;
            this.lblSoNguoi.Location = new System.Drawing.Point(12, 95);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Size = new System.Drawing.Size(110, 22);
            this.lblSoNguoi.TabIndex = 8;
            this.lblSoNguoi.Text = "Số người";
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.Location = new System.Drawing.Point(124, 92);
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Size = new System.Drawing.Size(290, 27);
            this.numSoNguoi.TabIndex = 9;
            this.numSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNguoi.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(12, 154);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(110, 34);
            this.btnKiemTra.TabIndex = 10;
            this.btnKiemTra.Text = "Kiểm tra";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(130, 154);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(110, 34);
            this.btnLapPhieu.TabIndex = 11;
            this.btnLapPhieu.Text = "Lập phiếu đăng ký";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
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
            // FrmDatTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 208);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.btnLapPhieu);
            this.Controls.Add(this.btnDong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmDatTour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt tour";
            this.Load += new System.EventHandler(this.FrmDatTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblLoaiKhach;
        private System.Windows.Forms.ComboBox cboLoaiKhach;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.DateTimePicker dtpNgayDi;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.DateTimePicker dtpNgayVe;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.NumericUpDown numSoNguoi;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Button btnDong;
    }
}
