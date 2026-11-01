namespace QuanLyThuVien.Forms
{
    partial class FrmDanhMuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.dtNVNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.cboNVPhai = new System.Windows.Forms.ComboBox();
            this.txtNVChucVu = new System.Windows.Forms.TextBox();
            this.btnNVMoi = new System.Windows.Forms.Button();
            this.txtNVHo = new System.Windows.Forms.TextBox();
            this.btnNVThem = new System.Windows.Forms.Button();
            this.btnNVXoa = new System.Windows.Forms.Button();
            this.btnNVCapNhat = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTLMoi = new System.Windows.Forms.Button();
            this.btnTLXoa = new System.Windows.Forms.Button();
            this.btnTLCapNhat = new System.Windows.Forms.Button();
            this.btnTLThem = new System.Windows.Forms.Button();
            this.dgvTL = new System.Windows.Forms.DataGridView();
            this.ColMaTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTLTen = new System.Windows.Forms.TextBox();
            this.txtTLMa = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnNXBMoi = new System.Windows.Forms.Button();
            this.btnNXBXoa = new System.Windows.Forms.Button();
            this.btnNXBCapNhat = new System.Windows.Forms.Button();
            this.btnNXBThem = new System.Windows.Forms.Button();
            this.dgvNXB = new System.Windows.Forms.DataGridView();
            this.ColMaNXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNXBSDT = new System.Windows.Forms.TextBox();
            this.txtNXBDiaChi = new System.Windows.Forms.TextBox();
            this.txtNXBMa = new System.Windows.Forms.TextBox();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabs.Location = new System.Drawing.Point(32, 44);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(841, 560);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtNVSDT);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvNV);
            this.tabPage1.Controls.Add(this.txtNVMa);
            this.tabPage1.Controls.Add(this.dtNVNgaySinh);
            this.tabPage1.Controls.Add(this.txtNVTen);
            this.tabPage1.Controls.Add(this.cboNVPhai);
            this.tabPage1.Controls.Add(this.txtNVChucVu);
            this.tabPage1.Controls.Add(this.btnNVMoi);
            this.tabPage1.Controls.Add(this.txtNVHo);
            this.tabPage1.Controls.Add(this.btnNVThem);
            this.tabPage1.Controls.Add(this.btnNVXoa);
            this.tabPage1.Controls.Add(this.btnNVCapNhat);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhân viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtNVSDT
            // 
            this.txtNVSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNVSDT.Location = new System.Drawing.Point(646, 37);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(164, 30);
            this.txtNVSDT.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(547, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 23);
            this.label9.TabIndex = 20;
            this.label9.Text = "Điện thoại:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ngày sinh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Phái:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Chức vụ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Họ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mã nhân viên:";
            // 
            // dgvNV
            // 
            this.dgvNV.AllowUserToAddRows = false;
            this.dgvNV.AllowUserToDeleteRows = false;
            this.dgvNV.AllowUserToResizeRows = false;
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNV,
            this.colHo,
            this.colTen,
            this.colPhai,
            this.colNgaySinh,
            this.colChucVu,
            this.colSDT});
            this.dgvNV.EnableHeadersVisualStyles = false;
            this.dgvNV.GridColor = System.Drawing.Color.LightGray;
            this.dgvNV.Location = new System.Drawing.Point(28, 206);
            this.dgvNV.MultiSelect = false;
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.ReadOnly = true;
            this.dgvNV.RowHeadersVisible = false;
            this.dgvNV.RowHeadersWidth = 51;
            this.dgvNV.RowTemplate.Height = 25;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.Size = new System.Drawing.Size(782, 291);
            this.dgvNV.TabIndex = 11;
            // 
            // colMaNV
            // 
            this.colMaNV.HeaderText = "Mã NV";
            this.colMaNV.MinimumWidth = 6;
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.ReadOnly = true;
            // 
            // colHo
            // 
            this.colHo.HeaderText = "Họ";
            this.colHo.MinimumWidth = 6;
            this.colHo.Name = "colHo";
            this.colHo.ReadOnly = true;
            // 
            // colTen
            // 
            this.colTen.HeaderText = "Tên";
            this.colTen.MinimumWidth = 6;
            this.colTen.Name = "colTen";
            this.colTen.ReadOnly = true;
            // 
            // colPhai
            // 
            this.colPhai.HeaderText = "Phái";
            this.colPhai.MinimumWidth = 6;
            this.colPhai.Name = "colPhai";
            this.colPhai.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.MinimumWidth = 6;
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            // 
            // colChucVu
            // 
            this.colChucVu.HeaderText = "Chức vụ";
            this.colChucVu.MinimumWidth = 6;
            this.colChucVu.Name = "colChucVu";
            this.colChucVu.ReadOnly = true;
            // 
            // colSDT
            // 
            this.colSDT.HeaderText = "Điện thoại";
            this.colSDT.MinimumWidth = 6;
            this.colSDT.Name = "colSDT";
            this.colSDT.ReadOnly = true;
            // 
            // txtNVMa
            // 
            this.txtNVMa.BackColor = System.Drawing.SystemColors.Window;
            this.txtNVMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNVMa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNVMa.Location = new System.Drawing.Point(166, 35);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(121, 30);
            this.txtNVMa.TabIndex = 0;
            // 
            // dtNVNgaySinh
            // 
            this.dtNVNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNVNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNVNgaySinh.Location = new System.Drawing.Point(401, 84);
            this.dtNVNgaySinh.Name = "dtNVNgaySinh";
            this.dtNVNgaySinh.Size = new System.Drawing.Size(127, 30);
            this.dtNVNgaySinh.TabIndex = 4;
            // 
            // txtNVTen
            // 
            this.txtNVTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNVTen.Location = new System.Drawing.Point(166, 130);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(121, 30);
            this.txtNVTen.TabIndex = 2;
            // 
            // cboNVPhai
            // 
            this.cboNVPhai.BackColor = System.Drawing.SystemColors.Window;
            this.cboNVPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNVPhai.FormattingEnabled = true;
            this.cboNVPhai.Location = new System.Drawing.Point(401, 34);
            this.cboNVPhai.Name = "cboNVPhai";
            this.cboNVPhai.Size = new System.Drawing.Size(127, 31);
            this.cboNVPhai.TabIndex = 3;
            // 
            // txtNVChucVu
            // 
            this.txtNVChucVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNVChucVu.Location = new System.Drawing.Point(401, 130);
            this.txtNVChucVu.Name = "txtNVChucVu";
            this.txtNVChucVu.Size = new System.Drawing.Size(127, 30);
            this.txtNVChucVu.TabIndex = 5;
            // 
            // btnNVMoi
            // 
            this.btnNVMoi.Location = new System.Drawing.Point(705, 130);
            this.btnNVMoi.Name = "btnNVMoi";
            this.btnNVMoi.Size = new System.Drawing.Size(105, 30);
            this.btnNVMoi.TabIndex = 10;
            this.btnNVMoi.Text = "Làm mới";
            this.btnNVMoi.UseVisualStyleBackColor = true;
            this.btnNVMoi.Click += new System.EventHandler(this.btnNVMoi_Click);
            // 
            // txtNVHo
            // 
            this.txtNVHo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNVHo.Location = new System.Drawing.Point(166, 83);
            this.txtNVHo.Name = "txtNVHo";
            this.txtNVHo.Size = new System.Drawing.Size(121, 30);
            this.txtNVHo.TabIndex = 1;
            // 
            // btnNVThem
            // 
            this.btnNVThem.Location = new System.Drawing.Point(551, 84);
            this.btnNVThem.Name = "btnNVThem";
            this.btnNVThem.Size = new System.Drawing.Size(82, 30);
            this.btnNVThem.TabIndex = 7;
            this.btnNVThem.Text = "Thêm";
            this.btnNVThem.UseVisualStyleBackColor = true;
            // 
            // btnNVXoa
            // 
            this.btnNVXoa.Location = new System.Drawing.Point(551, 130);
            this.btnNVXoa.Name = "btnNVXoa";
            this.btnNVXoa.Size = new System.Drawing.Size(82, 30);
            this.btnNVXoa.TabIndex = 9;
            this.btnNVXoa.Text = "Xóa";
            this.btnNVXoa.UseVisualStyleBackColor = true;
            // 
            // btnNVCapNhat
            // 
            this.btnNVCapNhat.Location = new System.Drawing.Point(705, 84);
            this.btnNVCapNhat.Name = "btnNVCapNhat";
            this.btnNVCapNhat.Size = new System.Drawing.Size(105, 30);
            this.btnNVCapNhat.TabIndex = 8;
            this.btnNVCapNhat.Text = "Cập nhật";
            this.btnNVCapNhat.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnTLMoi);
            this.tabPage2.Controls.Add(this.btnTLXoa);
            this.tabPage2.Controls.Add(this.btnTLCapNhat);
            this.tabPage2.Controls.Add(this.btnTLThem);
            this.tabPage2.Controls.Add(this.dgvTL);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtTLTen);
            this.tabPage2.Controls.Add(this.txtTLMa);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thể loại";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTLMoi
            // 
            this.btnTLMoi.Location = new System.Drawing.Point(704, 131);
            this.btnTLMoi.Name = "btnTLMoi";
            this.btnTLMoi.Size = new System.Drawing.Size(105, 30);
            this.btnTLMoi.TabIndex = 16;
            this.btnTLMoi.Text = "Làm mới";
            this.btnTLMoi.UseVisualStyleBackColor = true;
            // 
            // btnTLXoa
            // 
            this.btnTLXoa.Location = new System.Drawing.Point(572, 131);
            this.btnTLXoa.Name = "btnTLXoa";
            this.btnTLXoa.Size = new System.Drawing.Size(82, 30);
            this.btnTLXoa.TabIndex = 15;
            this.btnTLXoa.Text = "Xóa";
            this.btnTLXoa.UseVisualStyleBackColor = true;
            // 
            // btnTLCapNhat
            // 
            this.btnTLCapNhat.Location = new System.Drawing.Point(704, 72);
            this.btnTLCapNhat.Name = "btnTLCapNhat";
            this.btnTLCapNhat.Size = new System.Drawing.Size(105, 30);
            this.btnTLCapNhat.TabIndex = 14;
            this.btnTLCapNhat.Text = "Cập nhật";
            this.btnTLCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnTLThem
            // 
            this.btnTLThem.Location = new System.Drawing.Point(572, 72);
            this.btnTLThem.Name = "btnTLThem";
            this.btnTLThem.Size = new System.Drawing.Size(82, 30);
            this.btnTLThem.TabIndex = 13;
            this.btnTLThem.Text = "Thêm";
            this.btnTLThem.UseVisualStyleBackColor = true;
            // 
            // dgvTL
            // 
            this.dgvTL.AllowUserToAddRows = false;
            this.dgvTL.AllowUserToDeleteRows = false;
            this.dgvTL.AllowUserToResizeRows = false;
            this.dgvTL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTL.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaTL,
            this.ColTenTL});
            this.dgvTL.EnableHeadersVisualStyles = false;
            this.dgvTL.GridColor = System.Drawing.Color.LightGray;
            this.dgvTL.Location = new System.Drawing.Point(27, 216);
            this.dgvTL.MultiSelect = false;
            this.dgvTL.Name = "dgvTL";
            this.dgvTL.ReadOnly = true;
            this.dgvTL.RowHeadersVisible = false;
            this.dgvTL.RowHeadersWidth = 51;
            this.dgvTL.RowTemplate.Height = 25;
            this.dgvTL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTL.Size = new System.Drawing.Size(782, 291);
            this.dgvTL.TabIndex = 12;
            // 
            // ColMaTL
            // 
            this.ColMaTL.HeaderText = "Mã TL";
            this.ColMaTL.MinimumWidth = 6;
            this.ColMaTL.Name = "ColMaTL";
            this.ColMaTL.ReadOnly = true;
            // 
            // ColTenTL
            // 
            this.ColTenTL.HeaderText = "Tên TL";
            this.ColTenTL.MinimumWidth = 6;
            this.ColTenTL.Name = "ColTenTL";
            this.ColTenTL.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tên thể loại:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "Mã thể loại:";
            // 
            // txtTLTen
            // 
            this.txtTLTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTLTen.Location = new System.Drawing.Point(158, 131);
            this.txtTLTen.Name = "txtTLTen";
            this.txtTLTen.Size = new System.Drawing.Size(336, 30);
            this.txtTLTen.TabIndex = 1;
            // 
            // txtTLMa
            // 
            this.txtTLMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTLMa.Location = new System.Drawing.Point(158, 49);
            this.txtTLMa.Name = "txtTLMa";
            this.txtTLMa.Size = new System.Drawing.Size(226, 30);
            this.txtTLMa.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDong);
            this.tabPage3.Controls.Add(this.btnNXBMoi);
            this.tabPage3.Controls.Add(this.btnNXBXoa);
            this.tabPage3.Controls.Add(this.btnNXBCapNhat);
            this.tabPage3.Controls.Add(this.btnNXBThem);
            this.tabPage3.Controls.Add(this.dgvNXB);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtNXBSDT);
            this.tabPage3.Controls.Add(this.txtNXBDiaChi);
            this.tabPage3.Controls.Add(this.txtNXBMa);
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(833, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Nhà xuất bản";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(628, 163);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(82, 30);
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnNXBMoi
            // 
            this.btnNXBMoi.Location = new System.Drawing.Point(691, 102);
            this.btnNXBMoi.Name = "btnNXBMoi";
            this.btnNXBMoi.Size = new System.Drawing.Size(105, 30);
            this.btnNXBMoi.TabIndex = 19;
            this.btnNXBMoi.Text = "Làm mới";
            this.btnNXBMoi.UseVisualStyleBackColor = true;
            // 
            // btnNXBXoa
            // 
            this.btnNXBXoa.Location = new System.Drawing.Point(559, 102);
            this.btnNXBXoa.Name = "btnNXBXoa";
            this.btnNXBXoa.Size = new System.Drawing.Size(82, 30);
            this.btnNXBXoa.TabIndex = 18;
            this.btnNXBXoa.Text = "Xóa";
            this.btnNXBXoa.UseVisualStyleBackColor = true;
            // 
            // btnNXBCapNhat
            // 
            this.btnNXBCapNhat.Location = new System.Drawing.Point(691, 43);
            this.btnNXBCapNhat.Name = "btnNXBCapNhat";
            this.btnNXBCapNhat.Size = new System.Drawing.Size(105, 30);
            this.btnNXBCapNhat.TabIndex = 17;
            this.btnNXBCapNhat.Text = "Cập nhật";
            this.btnNXBCapNhat.UseVisualStyleBackColor = true;
            // 
            // btnNXBThem
            // 
            this.btnNXBThem.Location = new System.Drawing.Point(558, 43);
            this.btnNXBThem.Name = "btnNXBThem";
            this.btnNXBThem.Size = new System.Drawing.Size(82, 30);
            this.btnNXBThem.TabIndex = 14;
            this.btnNXBThem.Text = "Thêm";
            this.btnNXBThem.UseVisualStyleBackColor = true;
            // 
            // dgvNXB
            // 
            this.dgvNXB.AllowUserToAddRows = false;
            this.dgvNXB.AllowUserToDeleteRows = false;
            this.dgvNXB.AllowUserToResizeRows = false;
            this.dgvNXB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNXB.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNXB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaNXB,
            this.ColDiaChi,
            this.ColDienThoai});
            this.dgvNXB.EnableHeadersVisualStyles = false;
            this.dgvNXB.GridColor = System.Drawing.Color.LightGray;
            this.dgvNXB.Location = new System.Drawing.Point(29, 217);
            this.dgvNXB.MultiSelect = false;
            this.dgvNXB.Name = "dgvNXB";
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.RowHeadersVisible = false;
            this.dgvNXB.RowHeadersWidth = 51;
            this.dgvNXB.RowTemplate.Height = 25;
            this.dgvNXB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXB.Size = new System.Drawing.Size(782, 291);
            this.dgvNXB.TabIndex = 13;
            // 
            // ColMaNXB
            // 
            this.ColMaNXB.HeaderText = "Mã NXB";
            this.ColMaNXB.MinimumWidth = 6;
            this.ColMaNXB.Name = "ColMaNXB";
            this.ColMaNXB.ReadOnly = true;
            // 
            // ColDiaChi
            // 
            this.ColDiaChi.HeaderText = "Địa chỉ";
            this.ColDiaChi.MinimumWidth = 6;
            this.ColDiaChi.Name = "ColDiaChi";
            this.ColDiaChi.ReadOnly = true;
            // 
            // ColDienThoai
            // 
            this.ColDienThoai.HeaderText = "Điện thoại";
            this.ColDienThoai.MinimumWidth = 6;
            this.ColDienThoai.Name = "ColDienThoai";
            this.ColDienThoai.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 23);
            this.label12.TabIndex = 6;
            this.label12.Text = "Điện thoại:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "Địa chỉ:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "Mã nhà xuất bản:";
            // 
            // txtNXBSDT
            // 
            this.txtNXBSDT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNXBSDT.Location = new System.Drawing.Point(197, 163);
            this.txtNXBSDT.Name = "txtNXBSDT";
            this.txtNXBSDT.Size = new System.Drawing.Size(226, 30);
            this.txtNXBSDT.TabIndex = 3;
            // 
            // txtNXBDiaChi
            // 
            this.txtNXBDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNXBDiaChi.Location = new System.Drawing.Point(197, 107);
            this.txtNXBDiaChi.Name = "txtNXBDiaChi";
            this.txtNXBDiaChi.Size = new System.Drawing.Size(226, 30);
            this.txtNXBDiaChi.TabIndex = 2;
            // 
            // txtNXBMa
            // 
            this.txtNXBMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNXBMa.Location = new System.Drawing.Point(197, 48);
            this.txtNXBMa.Name = "txtNXBMa";
            this.txtNXBMa.Size = new System.Drawing.Size(226, 30);
            this.txtNXBMa.TabIndex = 1;
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục và nhân viên";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Button btnNVMoi;
        private System.Windows.Forms.Button btnNVXoa;
        private System.Windows.Forms.Button btnNVCapNhat;
        private System.Windows.Forms.Button btnNVThem;
        private System.Windows.Forms.TextBox txtNVChucVu;
        private System.Windows.Forms.DateTimePicker dtNVNgaySinh;
        private System.Windows.Forms.ComboBox cboNVPhai;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.TextBox txtNVHo;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTLTen;
        private System.Windows.Forms.TextBox txtTLMa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvTL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Button btnTLMoi;
        private System.Windows.Forms.Button btnTLXoa;
        private System.Windows.Forms.Button btnTLCapNhat;
        private System.Windows.Forms.Button btnTLThem;
        private System.Windows.Forms.TextBox txtNXBSDT;
        private System.Windows.Forms.TextBox txtNXBDiaChi;
        private System.Windows.Forms.TextBox txtNXBMa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvNXB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDienThoai;
        private System.Windows.Forms.Button btnNXBMoi;
        private System.Windows.Forms.Button btnNXBXoa;
        private System.Windows.Forms.Button btnNXBCapNhat;
        private System.Windows.Forms.Button btnNXBThem;
        private System.Windows.Forms.Button btnDong;
    }
}