namespace QuanLyThuVien.Forms
{
    partial class FrmMuonTra
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.cboNhanVienMuon = new System.Windows.Forms.ComboBox();
            this.dtNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.dtHenTra = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dgvSachCon = new System.Windows.Forms.DataGridView();
            this.dgvSachChon = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.btnBoSach = new System.Windows.Forms.Button();
            this.ColMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNamXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboDocGiaTra = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboNhanVienTra = new System.Windows.Forms.ComboBox();
            this.dgvDangMuon = new System.Windows.Forms.DataGridView();
            this.ColMaCTPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuaHan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numPhiPhat = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 623);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBoSach);
            this.tabPage1.Controls.Add(this.btnLapPhieu);
            this.tabPage1.Controls.Add(this.btnThemSach);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dgvSachChon);
            this.tabPage1.Controls.Add(this.dgvSachCon);
            this.tabPage1.Controls.Add(this.lblTrangThai);
            this.tabPage1.Controls.Add(this.btnKiemTra);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dtHenTra);
            this.tabPage1.Controls.Add(this.dtNgayMuon);
            this.tabPage1.Controls.Add(this.cboNhanVienMuon);
            this.tabPage1.Controls.Add(this.cboDocGia);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(868, 587);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mượn sách";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDong);
            this.tabPage2.Controls.Add(this.btnTraSach);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.numPhiPhat);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.cboTinhTrang);
            this.tabPage2.Controls.Add(this.dtNgayTra);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.dgvDangMuon);
            this.tabPage2.Controls.Add(this.cboNhanVienTra);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cboDocGiaTra);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trả sách";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Độc giả:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên lập phiếu:";
            // 
            // cboDocGia
            // 
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(213, 31);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(208, 31);
            this.cboDocGia.TabIndex = 2;
            // 
            // cboNhanVienMuon
            // 
            this.cboNhanVienMuon.FormattingEnabled = true;
            this.cboNhanVienMuon.Location = new System.Drawing.Point(213, 79);
            this.cboNhanVienMuon.Name = "cboNhanVienMuon";
            this.cboNhanVienMuon.Size = new System.Drawing.Size(208, 31);
            this.cboNhanVienMuon.TabIndex = 3;
            // 
            // dtNgayMuon
            // 
            this.dtNgayMuon.CustomFormat = "dd/MM/yyyy";
            this.dtNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayMuon.Location = new System.Drawing.Point(144, 127);
            this.dtNgayMuon.Name = "dtNgayMuon";
            this.dtNgayMuon.Size = new System.Drawing.Size(200, 30);
            this.dtNgayMuon.TabIndex = 4;
            // 
            // dtHenTra
            // 
            this.dtHenTra.CustomFormat = "dd/MM/yyyy";
            this.dtHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHenTra.Location = new System.Drawing.Point(479, 127);
            this.dtHenTra.Name = "dtHenTra";
            this.dtHenTra.Size = new System.Drawing.Size(200, 30);
            this.dtHenTra.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày mượn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày hẹn trả:";
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Location = new System.Drawing.Point(479, 30);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(169, 31);
            this.btnKiemTra.TabIndex = 8;
            this.btnKiemTra.Text = "Kiểm tra điều kiện";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(654, 34);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(195, 23);
            this.lblTrangThai.TabIndex = 9;
            this.lblTrangThai.Text = "Đủ điều kiện mượn sách";
            // 
            // dgvSachCon
            // 
            this.dgvSachCon.AllowUserToAddRows = false;
            this.dgvSachCon.AllowUserToDeleteRows = false;
            this.dgvSachCon.AllowUserToResizeRows = false;
            this.dgvSachCon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachCon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSachCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachCon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMa,
            this.ColTenSach,
            this.ColNamXB,
            this.ColCon});
            this.dgvSachCon.EnableHeadersVisualStyles = false;
            this.dgvSachCon.GridColor = System.Drawing.Color.LightGray;
            this.dgvSachCon.Location = new System.Drawing.Point(38, 214);
            this.dgvSachCon.MultiSelect = false;
            this.dgvSachCon.Name = "dgvSachCon";
            this.dgvSachCon.ReadOnly = true;
            this.dgvSachCon.RowHeadersVisible = false;
            this.dgvSachCon.RowHeadersWidth = 51;
            this.dgvSachCon.RowTemplate.Height = 25;
            this.dgvSachCon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachCon.Size = new System.Drawing.Size(341, 337);
            this.dgvSachCon.TabIndex = 10;
            // 
            // dgvSachChon
            // 
            this.dgvSachChon.AllowUserToAddRows = false;
            this.dgvSachChon.AllowUserToDeleteRows = false;
            this.dgvSachChon.AllowUserToResizeRows = false;
            this.dgvSachChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSachChon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSachChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachChon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSachChon.EnableHeadersVisualStyles = false;
            this.dgvSachChon.GridColor = System.Drawing.Color.LightGray;
            this.dgvSachChon.Location = new System.Drawing.Point(482, 214);
            this.dgvSachChon.MultiSelect = false;
            this.dgvSachChon.Name = "dgvSachChon";
            this.dgvSachChon.ReadOnly = true;
            this.dgvSachChon.RowHeadersVisible = false;
            this.dgvSachChon.RowHeadersWidth = 51;
            this.dgvSachChon.RowTemplate.Height = 25;
            this.dgvSachChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachChon.Size = new System.Drawing.Size(341, 182);
            this.dgvSachChon.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sách còn trong kho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(478, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Sách đã chọn (tối đa 3):";
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(385, 253);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(91, 31);
            this.btnThemSach.TabIndex = 14;
            this.btnThemSach.Text = "Thêm >>";
            this.btnThemSach.UseVisualStyleBackColor = true;
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(564, 418);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(180, 43);
            this.btnLapPhieu.TabIndex = 16;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            // 
            // btnBoSach
            // 
            this.btnBoSach.Location = new System.Drawing.Point(385, 307);
            this.btnBoSach.Name = "btnBoSach";
            this.btnBoSach.Size = new System.Drawing.Size(91, 31);
            this.btnBoSach.TabIndex = 17;
            this.btnBoSach.Text = "<< Bỏ";
            this.btnBoSach.UseVisualStyleBackColor = true;
            // 
            // ColMa
            // 
            this.ColMa.HeaderText = "Mã";
            this.ColMa.MinimumWidth = 6;
            this.ColMa.Name = "ColMa";
            this.ColMa.ReadOnly = true;
            // 
            // ColTenSach
            // 
            this.ColTenSach.HeaderText = "Tên sách";
            this.ColTenSach.MinimumWidth = 6;
            this.ColTenSach.Name = "ColTenSach";
            this.ColTenSach.ReadOnly = true;
            // 
            // ColNamXB
            // 
            this.ColNamXB.HeaderText = "Năm XB";
            this.ColNamXB.MinimumWidth = 6;
            this.ColNamXB.Name = "ColNamXB";
            this.ColNamXB.ReadOnly = true;
            // 
            // ColCon
            // 
            this.ColCon.HeaderText = "Còn";
            this.ColCon.MinimumWidth = 6;
            this.ColCon.Name = "ColCon";
            this.ColCon.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên sách";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // cboDocGiaTra
            // 
            this.cboDocGiaTra.FormattingEnabled = true;
            this.cboDocGiaTra.Location = new System.Drawing.Point(209, 36);
            this.cboDocGiaTra.Name = "cboDocGiaTra";
            this.cboDocGiaTra.Size = new System.Drawing.Size(328, 31);
            this.cboDocGiaTra.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Độc giả trả sách:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nhân viên nhận trả:";
            // 
            // cboNhanVienTra
            // 
            this.cboNhanVienTra.FormattingEnabled = true;
            this.cboNhanVienTra.Location = new System.Drawing.Point(209, 91);
            this.cboNhanVienTra.Name = "cboNhanVienTra";
            this.cboNhanVienTra.Size = new System.Drawing.Size(328, 31);
            this.cboNhanVienTra.TabIndex = 3;
            // 
            // dgvDangMuon
            // 
            this.dgvDangMuon.AllowUserToAddRows = false;
            this.dgvDangMuon.AllowUserToDeleteRows = false;
            this.dgvDangMuon.AllowUserToResizeRows = false;
            this.dgvDangMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangMuon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangMuon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaCTPM,
            this.ColMaSach,
            this.dataGridViewTextBoxColumn3,
            this.ColNgayMuon,
            this.ColHanTra,
            this.ColQuaHan,
            this.ColTinhTrang});
            this.dgvDangMuon.EnableHeadersVisualStyles = false;
            this.dgvDangMuon.GridColor = System.Drawing.Color.LightGray;
            this.dgvDangMuon.Location = new System.Drawing.Point(33, 154);
            this.dgvDangMuon.MultiSelect = false;
            this.dgvDangMuon.Name = "dgvDangMuon";
            this.dgvDangMuon.ReadOnly = true;
            this.dgvDangMuon.RowHeadersVisible = false;
            this.dgvDangMuon.RowHeadersWidth = 51;
            this.dgvDangMuon.RowTemplate.Height = 25;
            this.dgvDangMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangMuon.Size = new System.Drawing.Size(800, 194);
            this.dgvDangMuon.TabIndex = 11;
            // 
            // ColMaCTPM
            // 
            this.ColMaCTPM.HeaderText = "Mã CTPM";
            this.ColMaCTPM.MinimumWidth = 6;
            this.ColMaCTPM.Name = "ColMaCTPM";
            this.ColMaCTPM.ReadOnly = true;
            // 
            // ColMaSach
            // 
            this.ColMaSach.HeaderText = "Mã sách";
            this.ColMaSach.MinimumWidth = 6;
            this.ColMaSach.Name = "ColMaSach";
            this.ColMaSach.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên sách";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ColNgayMuon
            // 
            this.ColNgayMuon.HeaderText = "Ngày mượn";
            this.ColNgayMuon.MinimumWidth = 6;
            this.ColNgayMuon.Name = "ColNgayMuon";
            this.ColNgayMuon.ReadOnly = true;
            // 
            // ColHanTra
            // 
            this.ColHanTra.HeaderText = "Hạn trả";
            this.ColHanTra.MinimumWidth = 6;
            this.ColHanTra.Name = "ColHanTra";
            this.ColHanTra.ReadOnly = true;
            // 
            // ColQuaHan
            // 
            this.ColQuaHan.HeaderText = "Quá hạn";
            this.ColQuaHan.MinimumWidth = 6;
            this.ColQuaHan.Name = "ColQuaHan";
            this.ColQuaHan.ReadOnly = true;
            // 
            // ColTinhTrang
            // 
            this.ColTinhTrang.HeaderText = "Tình trạng";
            this.ColTinhTrang.MinimumWidth = 6;
            this.ColTinhTrang.Name = "ColTinhTrang";
            this.ColTinhTrang.ReadOnly = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 374);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Ngày trả:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Tình trạng:";
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayTra.Location = new System.Drawing.Point(146, 368);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(276, 30);
            this.dtNgayTra.TabIndex = 14;
            // 
            // cboTinhTrang
            // 
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(146, 421);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(276, 31);
            this.cboTinhTrang.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 478);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 23);
            this.label11.TabIndex = 16;
            this.label11.Text = "Phí phạt:";
            // 
            // numPhiPhat
            // 
            this.numPhiPhat.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPhiPhat.Location = new System.Drawing.Point(146, 476);
            this.numPhiPhat.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPhiPhat.Name = "numPhiPhat";
            this.numPhiPhat.Size = new System.Drawing.Size(276, 30);
            this.numPhiPhat.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(428, 483);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 23);
            this.label12.TabIndex = 18;
            this.label12.Text = "VNĐ";
            // 
            // btnTraSach
            // 
            this.btnTraSach.Location = new System.Drawing.Point(546, 516);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(174, 37);
            this.btnTraSach.TabIndex = 19;
            this.btnTraSach.Text = "Xác nhận trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(750, 516);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 37);
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // FrmMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 647);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mượn - Trả sách";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtHenTra;
        private System.Windows.Forms.DateTimePicker dtNgayMuon;
        private System.Windows.Forms.ComboBox cboNhanVienMuon;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.DataGridView dgvSachCon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvSachChon;
        private System.Windows.Forms.Button btnBoSach;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNamXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDocGiaTra;
        private System.Windows.Forms.ComboBox cboNhanVienTra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDangMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaCTPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNgayMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHanTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuaHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTinhTrang;
        private System.Windows.Forms.NumericUpDown numPhiPhat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTraSach;
    }
}