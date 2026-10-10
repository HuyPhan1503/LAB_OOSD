namespace LAB5
{
    partial class FrmDenBu
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
            this.lblDichVu = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.cboMucDo = new System.Windows.Forms.ComboBox();
            this.lblSoTienDenBu = new System.Windows.Forms.Label();
            this.numSoTienDenBu = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienDenBu)).BeginInit();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cboChuyen);
            this.grpThongTin.Controls.Add(this.lblChuyen);
            this.grpThongTin.Controls.Add(this.cboDichVu);
            this.grpThongTin.Controls.Add(this.lblDichVu);
            this.grpThongTin.Controls.Add(this.txtMoTa);
            this.grpThongTin.Controls.Add(this.lblMoTa);
            this.grpThongTin.Controls.Add(this.cboMucDo);
            this.grpThongTin.Controls.Add(this.lblMucDo);
            this.grpThongTin.Controls.Add(this.numSoTienDenBu);
            this.grpThongTin.Controls.Add(this.lblSoTienDenBu);
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
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = false;
            this.lblDichVu.Location = new System.Drawing.Point(442, 27);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(110, 22);
            this.lblDichVu.TabIndex = 2;
            this.lblDichVu.Text = "Dịch vụ";
            // 
            // cboDichVu
            // 
            this.cboDichVu.Location = new System.Drawing.Point(554, 24);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(290, 27);
            this.cboDichVu.TabIndex = 3;
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = false;
            this.lblMoTa.Location = new System.Drawing.Point(12, 61);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(110, 22);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mô tả hư hỏng / mất mát";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(124, 58);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(290, 27);
            this.txtMoTa.TabIndex = 5;
            // 
            // lblMucDo
            // 
            this.lblMucDo.AutoSize = false;
            this.lblMucDo.Location = new System.Drawing.Point(442, 61);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Size = new System.Drawing.Size(110, 22);
            this.lblMucDo.TabIndex = 6;
            this.lblMucDo.Text = "Mức độ thiệt hại";
            // 
            // cboMucDo
            // 
            this.cboMucDo.Location = new System.Drawing.Point(554, 58);
            this.cboMucDo.Name = "cboMucDo";
            this.cboMucDo.Size = new System.Drawing.Size(290, 27);
            this.cboMucDo.TabIndex = 7;
            this.cboMucDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMucDo.Items.AddRange(new object[] { "Nhẹ", "Trung bình", "Nặng" });
            // 
            // lblSoTienDenBu
            // 
            this.lblSoTienDenBu.AutoSize = false;
            this.lblSoTienDenBu.Location = new System.Drawing.Point(12, 95);
            this.lblSoTienDenBu.Name = "lblSoTienDenBu";
            this.lblSoTienDenBu.Size = new System.Drawing.Size(110, 22);
            this.lblSoTienDenBu.TabIndex = 8;
            this.lblSoTienDenBu.Text = "Số tiền đền bù";
            // 
            // numSoTienDenBu
            // 
            this.numSoTienDenBu.Location = new System.Drawing.Point(124, 92);
            this.numSoTienDenBu.Name = "numSoTienDenBu";
            this.numSoTienDenBu.Size = new System.Drawing.Size(290, 27);
            this.numSoTienDenBu.TabIndex = 9;
            this.numSoTienDenBu.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numSoTienDenBu.ThousandsSeparator = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 154);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 34);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Lập phiếu";
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
            // FrmDenBu
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
            this.Name = "FrmDenBu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phiếu đền bù";
            this.Load += new System.EventHandler(this.FrmDenBu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTienDenBu)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblChuyen;
        private System.Windows.Forms.ComboBox cboChuyen;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblMucDo;
        private System.Windows.Forms.ComboBox cboMucDo;
        private System.Windows.Forms.Label lblSoTienDenBu;
        private System.Windows.Forms.NumericUpDown numSoTienDenBu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvDanhSach;
    }
}
