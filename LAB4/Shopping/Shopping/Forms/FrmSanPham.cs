using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Shopping.Models;
using Shopping.Services;

namespace Shopping.Forms
{
    public partial class FrmSanPham : Form
    {
        private ComboBox cboNhom;
        private TextBox txtTimKiem;
        private Button btnTim;
        private DataGridView dgv;
        private NumericUpDown nudSoLuong;
        private Button btnThem;

        public FrmSanPham()
        {
            InitializeComponent();
            TaoGiaoDien();
            LoadNhom();
            LoadSanPham();
        }

        private void TaoGiaoDien()
        {
            Text = "Danh sách sản phẩm";
            Size = new Size(820, 640);
            StartPosition = FormStartPosition.CenterParent;

            cboNhom = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Left = 10,
                Top = 10,
                Width = 260,
                Name = "cboNhom"
            };

            txtTimKiem = new TextBox()
            {
                Left = 280,
                Top = 10,
                Width = 360,
                Name = "txtTimKiem"
            };

            btnTim = new Button()
            {
                Text = "Tìm",
                Left = 650,
                Top = 8,
                Width = 120,
                Name = "btnTim"
            };
            btnTim.Click += (s, e) => LoadSanPham();

            dgv = new DataGridView()
            {
                Left = 10,
                Top = 44,
                Width = 760,
                Height = 480,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Name = "dgvSanPham"
            };
            dgv.CellDoubleClick += Dgv_CellDoubleClick;

            Label lblSL = new Label() { Text = "Số lượng", Left = 10, Top = 540, Width = 70 };
            nudSoLuong = new NumericUpDown() { Left = 88, Top = 536, Width = 80, Minimum = 1, Maximum = 100, Value = 1, Name = "nudSoLuong" };

            btnThem = new Button() { Text = "Thêm vào giỏ", Left = 180, Top = 532, Width = 140, Name = "btnThem" };
            btnThem.Click += BtnThem_Click;

            Controls.AddRange(new Control[] { cboNhom, txtTimKiem, btnTim, dgv, lblSL, nudSoLuong, btnThem });
        }

        private void LoadNhom()
        {
            try
            {
                var ds = SanPhamService.LayNhom();
                cboNhom.Items.Clear();
                cboNhom.Items.Add(new NhomSanPham { MaNhomSP = -1, TenNhomSP = "-- Tất cả --" });
                foreach (var n in ds) cboNhom.Items.Add(n);
                cboNhom.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhóm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPham()
        {
            try
            {
                int? maNhom = null;
                if (cboNhom.SelectedItem is NhomSanPham nm && nm.MaNhomSP != -1) maNhom = nm.MaNhomSP;
                string kw = string.IsNullOrWhiteSpace(txtTimKiem.Text) ? null : txtTimKiem.Text.Trim();
                var ds = SanPhamService.Lay(maNhom, kw);
                dgv.DataSource = null;
                dgv.DataSource = ds.Select(s => new
                {
                    s.MaSP,
                    s.TenSP,
                    s.TenNhomSP,
                    Gia = s.GiaBan.ToString("N0"),
                    CoHang = s.CoHang ? "Có" : "Hết"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { MessageBox.Show("Vui lòng chọn sản phẩm."); return; }
            string ma = dgv.CurrentRow.Cells["MaSP"].Value as string;
            int sl = (int)nudSoLuong.Value;
            try
            {
                if (!PhienService.DaDangNhap) { MessageBox.Show("Vui lòng đăng nhập trước."); return; }
                GioHangService.Them(PhienService.KhachHienTai.MaKhachHang, ma, sl);
                MessageBox.Show("Đã thêm vào giỏ hàng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm vào giỏ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[0];
            nudSoLuong.Value = 1;
            BtnThem_Click(this, EventArgs.Empty);
        }
    }
}