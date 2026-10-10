namespace LAB5
{
    partial class FrmDiemThamQuan
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
            this.lblMaDiem = new System.Windows.Forms.Label();
            this.txtMaDiem = new System.Windows.Forms.TextBox();
            this.lblTenDiem = new System.Windows.Forms.Label();
            this.txtTenDiem = new System.Windows.Forms.TextBox();
            this.lblDiaDiem = new System.Windows.Forms.Label();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.lblTour = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblYNghia = new System.Windows.Forms.Label();
            this.txtYNghia = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtMaDiem);
            this.grpThongTin.Controls.Add(this.lblMaDiem);
            this.grpThongTin.Controls.Add(this.txtTenDiem);
            this.grpThongTin.Controls.Add(this.lblTenDiem);
            this.grpThongTin.Controls.Add(this.txtDiaDiem);
            this.grpThongTin.Controls.Add(this.lblDiaDiem);
            this.grpThongTin.Controls.Add(this.cboTour);
            this.grpThongTin.Controls.Add(this.lblTour);
            this.grpThongTin.Controls.Add(this.txtNoiDung);
            this.grpThongTin.Controls.Add(this.lblNoiDung);
            this.grpThongTin.Controls.Add(this.txtYNghia);
            this.grpThongTin.Controls.Add(this.lblYNghia);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(860, 132);
            this.grpThongTin.TabIndex = 19;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // lblMaDiem
            // 
            this.lblMaDiem.AutoSize = false;
            this.lblMaDiem.Location = new System.Drawing.Point(12, 27);
            this.lblMaDiem.Name = "lblMaDiem";
            this.lblMaDiem.Size = new System.Drawing.Size(110, 22);
            this.lblMaDiem.TabIndex = 0;
            this.lblMaDiem.Text = "Mã điểm tham quan";
            // 
            // txtMaDiem
            // 
            this.txtMaDiem.Location = new System.Drawing.Point(124, 24);
            this.txtMaDiem.Name = "txtMaDiem";
            this.txtMaDiem.Size = new System.Drawing.Size(290, 27);
            this.txtMaDiem.TabIndex = 1;
            // 
            // lblTenDiem
            // 
            this.lblTenDiem.AutoSize = false;
            this.lblTenDiem.Location = new System.Drawing.Point(442, 27);
            this.lblTenDiem.Name = "lblTenDiem";
            this.lblTenDiem.Size = new System.Drawing.Size(110, 22);
            this.lblTenDiem.TabIndex = 2;
            this.lblTenDiem.Text = "Tên điểm tham quan";
            // 
            // txtTenDiem
            // 
            this.txtTenDiem.Location = new System.Drawing.Point(554, 24);
            this.txtTenDiem.Name = "txtTenDiem";
            this.txtTenDiem.Size = new System.Drawing.Size(290, 27);
            this.txtTenDiem.TabIndex = 3;
            // 
            // lblDiaDiem
            // 
            this.lblDiaDiem.AutoSize = false;
            this.lblDiaDiem.Location = new System.Drawing.Point(12, 61);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.lblDiaDiem.Size = new System.Drawing.Size(110, 22);
            this.lblDiaDiem.TabIndex = 4;
            this.lblDiaDiem.Text = "Địa điểm tham quan";
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(124, 58);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(290, 27);
            this.txtDiaDiem.TabIndex = 5;
            // 
            // lblTour
            // 
            this.lblTour.AutoSize = false;
            this.lblTour.Location = new System.Drawing.Point(442, 61);
            this.lblTour.Name = "lblTour";
            this.lblTour.Size = new System.Drawing.Size(110, 22);
            this.lblTour.TabIndex = 6;
            this.lblTour.Text = "Liên kết với tour";
            // 
            // cboTour
            // 
            this.cboTour.Location = new System.Drawing.Point(554, 58);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(290, 27);
            this.cboTour.TabIndex = 7;
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = false;
            this.lblNoiDung.Location = new System.Drawing.Point(12, 95);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(110, 22);
            this.lblNoiDung.TabIndex = 8;
            this.lblNoiDung.Text = "Nội dung";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(124, 92);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(290, 27);
            this.txtNoiDung.TabIndex = 9;
            // 
            // lblYNghia
            // 
            this.lblYNghia.AutoSize = false;
            this.lblYNghia.Location = new System.Drawing.Point(442, 95);
            this.lblYNghia.Name = "lblYNghia";
            this.lblYNghia.Size = new System.Drawing.Size(110, 22);
            this.lblYNghia.TabIndex = 10;
            this.lblYNghia.Text = "Ý nghĩa";
            // 
            // txtYNghia
            // 
            this.txtYNghia.Location = new System.Drawing.Point(554, 92);
            this.txtYNghia.Name = "txtYNghia";
            this.txtYNghia.Size = new System.Drawing.Size(290, 27);
            this.txtYNghia.TabIndex = 11;
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
            // FrmDiemThamQuan
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
            this.Name = "FrmDiemThamQuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý điểm tham quan";
            this.Load += new System.EventHandler(this.FrmDiemThamQuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaDiem;
        private System.Windows.Forms.TextBox txtMaDiem;
        private System.Windows.Forms.Label lblTenDiem;
        private System.Windows.Forms.TextBox txtTenDiem;
        private System.Windows.Forms.Label lblDiaDiem;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblYNghia;
        private System.Windows.Forms.TextBox txtYNghia;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
