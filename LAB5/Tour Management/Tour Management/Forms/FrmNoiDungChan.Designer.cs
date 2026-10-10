namespace LAB5
{
    partial class FrmNoiDungChan
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
            this.lblTour = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.lblTenNoiDung = new System.Windows.Forms.Label();
            this.txtTenNoiDung = new System.Windows.Forms.TextBox();
            this.chkDoiPhuongTien = new System.Windows.Forms.CheckBox();
            this.chkCoNoiAn = new System.Windows.Forms.CheckBox();
            this.chkCoKhachSan = new System.Windows.Forms.CheckBox();
            this.lblLoaiKhachSan = new System.Windows.Forms.Label();
            this.cboLoaiKhachSan = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboTour);
            this.grpThongTin.Controls.Add(this.lblTour);
            this.grpThongTin.Controls.Add(this.txtTenNoiDung);
            this.grpThongTin.Controls.Add(this.lblTenNoiDung);
            this.grpThongTin.Controls.Add(this.chkDoiPhuongTien);
            this.grpThongTin.Controls.Add(this.chkCoNoiAn);
            this.grpThongTin.Controls.Add(this.chkCoKhachSan);
            this.grpThongTin.Controls.Add(this.cboLoaiKhachSan);
            this.grpThongTin.Controls.Add(this.lblLoaiKhachSan);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 132);
            this.grpThongTin.TabIndex = 15;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblTour
            // 
            this.lblTour.AutoSize = false;
            this.lblTour.Location = new System.Drawing.Point(12, 27);
            this.lblTour.Name = "lblTour";
            this.lblTour.Size = new System.Drawing.Size(110, 22);
            this.lblTour.TabIndex = 0;
            this.lblTour.Text = "Tour";
            // 
            // cboTour
            // 
            this.cboTour.Location = new System.Drawing.Point(124, 24);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(290, 27);
            this.cboTour.TabIndex = 1;
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblTenNoiDung
            // 
            this.lblTenNoiDung.AutoSize = false;
            this.lblTenNoiDung.Location = new System.Drawing.Point(442, 27);
            this.lblTenNoiDung.Name = "lblTenNoiDung";
            this.lblTenNoiDung.Size = new System.Drawing.Size(110, 22);
            this.lblTenNoiDung.TabIndex = 2;
            this.lblTenNoiDung.Text = "Nơi dừng chân";
            // 
            // txtTenNoiDung
            // 
            this.txtTenNoiDung.Location = new System.Drawing.Point(554, 24);
            this.txtTenNoiDung.Name = "txtTenNoiDung";
            this.txtTenNoiDung.Size = new System.Drawing.Size(290, 27);
            this.txtTenNoiDung.TabIndex = 3;
            // 
            // chkDoiPhuongTien
            // 
            this.chkDoiPhuongTien.AutoSize = true;
            this.chkDoiPhuongTien.Location = new System.Drawing.Point(120, 60);
            this.chkDoiPhuongTien.Name = "chkDoiPhuongTien";
            this.chkDoiPhuongTien.Size = new System.Drawing.Size(200, 24);
            this.chkDoiPhuongTien.TabIndex = 4;
            this.chkDoiPhuongTien.Text = "Có đổi phương tiện";
            this.chkDoiPhuongTien.UseVisualStyleBackColor = true;
            // 
            // chkCoNoiAn
            // 
            this.chkCoNoiAn.AutoSize = true;
            this.chkCoNoiAn.Location = new System.Drawing.Point(550, 60);
            this.chkCoNoiAn.Name = "chkCoNoiAn";
            this.chkCoNoiAn.Size = new System.Drawing.Size(200, 24);
            this.chkCoNoiAn.TabIndex = 5;
            this.chkCoNoiAn.Text = "Có nơi ăn";
            this.chkCoNoiAn.UseVisualStyleBackColor = true;
            // 
            // chkCoKhachSan
            // 
            this.chkCoKhachSan.AutoSize = true;
            this.chkCoKhachSan.Location = new System.Drawing.Point(120, 94);
            this.chkCoKhachSan.Name = "chkCoKhachSan";
            this.chkCoKhachSan.Size = new System.Drawing.Size(200, 24);
            this.chkCoKhachSan.TabIndex = 6;
            this.chkCoKhachSan.Text = "Có khách sạn ở lại";
            this.chkCoKhachSan.UseVisualStyleBackColor = true;
            this.chkCoKhachSan.CheckedChanged += new System.EventHandler(this.chkCoKhachSan_CheckedChanged);
            // 
            // lblLoaiKhachSan
            // 
            this.lblLoaiKhachSan.AutoSize = false;
            this.lblLoaiKhachSan.Location = new System.Drawing.Point(442, 95);
            this.lblLoaiKhachSan.Name = "lblLoaiKhachSan";
            this.lblLoaiKhachSan.Size = new System.Drawing.Size(110, 22);
            this.lblLoaiKhachSan.TabIndex = 7;
            this.lblLoaiKhachSan.Text = "Loại khách sạn";
            // 
            // cboLoaiKhachSan
            // 
            this.cboLoaiKhachSan.Location = new System.Drawing.Point(554, 92);
            this.cboLoaiKhachSan.Name = "cboLoaiKhachSan";
            this.cboLoaiKhachSan.Size = new System.Drawing.Size(290, 27);
            this.cboLoaiKhachSan.TabIndex = 8;
            this.cboLoaiKhachSan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKhachSan.Items.AddRange(new object[] { "2 sao", "3 sao", "4 sao", "5 sao" });
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 154);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(130, 154);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 34);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(248, 154);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 34);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(366, 154);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 34);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(484, 154);
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
            // FrmNoiDungChan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 472);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = false;
            this.Name = "FrmNoiDungChan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nơi dừng chân của tour";
            this.Load += new System.EventHandler(this.FrmNoiDungChan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label lblTenNoiDung;
        private System.Windows.Forms.TextBox txtTenNoiDung;
        private System.Windows.Forms.CheckBox chkDoiPhuongTien;
        private System.Windows.Forms.CheckBox chkCoNoiAn;
        private System.Windows.Forms.CheckBox chkCoKhachSan;
        private System.Windows.Forms.Label lblLoaiKhachSan;
        private System.Windows.Forms.ComboBox cboLoaiKhachSan;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
