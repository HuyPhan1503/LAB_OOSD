
using System;
using System.Data;
using System.Windows.Forms;
using LAB07.Models;
using LAB07.Services;

namespace LAB07.Forms
{
    public partial class FrmQuyetDinhTuyenDung : Form
    {
        private readonly QuyetDinhTuyenDungService service =
            new QuyetDinhTuyenDungService();

        private int maQuyetDinh = 0;

        public FrmQuyetDinhTuyenDung()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;
            Load += FrmQuyetDinhTuyenDung_Load;
        }

        private void FrmQuyetDinhTuyenDung_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxes();
                LoadDanhSach();
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxes()
        {
            DataTable dtNhanVien = service.GetNhanVien();
            DataTable dtHoSo = service.GetHoSoUngTuyen();
            DataTable dtPhongBan = service.GetPhongBan();

            BindCombo(cboNhanVien, dtNhanVien, "HoTen", "MaNhanVien");
            BindCombo(cboNguoiKy, dtNhanVien.Copy(), "HoTen", "MaNhanVien");
            BindCombo(cboPhongBan, dtPhongBan, "TenPhongBan", "MaPhongBan");

            DataTable dtHoSoOptional = dtHoSo.Copy();

            DataRow row = dtHoSoOptional.NewRow();
            row["MaHoSo"] = DBNull.Value;
            row["HoTen"] = "-- Không chọn hồ sơ --";
            dtHoSoOptional.Rows.InsertAt(row, 0);

            BindCombo(cboHoSo, dtHoSoOptional, "HoTen", "MaHoSo");
        }

        private void BindCombo(
            ComboBox combo,
            DataTable table,
            string displayMember,
            string valueMember)
        {
            combo.DataSource = null;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            combo.DataSource = table;
            combo.SelectedIndex = -1;
        }

        private void LoadDanhSach()
        {
            dgvDanhSach.DataSource = service.GetAll();

            DoiTenCot("MaQuyetDinh", "Mã quyết định");
            DoiTenCot("MaNhanVien", "Mã nhân viên");
            DoiTenCot("HoTen", "Nhân viên");
            DoiTenCot("MaHoSo", "Mã hồ sơ");
            DoiTenCot("MaPhongBan", "Mã phòng ban");
            DoiTenCot("TenPhongBan", "Phòng ban");
            DoiTenCot("NgayKy", "Ngày ký");
            DoiTenCot("NgayBatDauThuViec", "Bắt đầu thử việc");
            DoiTenCot("NgayKetThucThuViec", "Kết thúc thử việc");
            DoiTenCot("LuongThuViec", "Lương thử việc");
            DoiTenCot("DieuKhoan", "Điều khoản");
            DoiTenCot("NguoiKy", "Mã người ký");
            DoiTenCot("TrangThai", "Trạng thái");

            if (dgvDanhSach.Columns.Contains("LuongThuViec"))
            {
                dgvDanhSach.Columns["LuongThuViec"]
                    .DefaultCellStyle.Format = "N0";
            }
        }

        private void DoiTenCot(string tenCot, string tieuDe)
        {
            if (dgvDanhSach.Columns.Contains(tenCot))
                dgvDanhSach.Columns[tenCot].HeaderText = tieuDe;
        }

        private QuyetDinhTuyenDung GetFormData()
        {
            if (cboNhanVien.SelectedValue == null)
                throw new Exception("Vui lòng chọn nhân viên.");

            if (cboPhongBan.SelectedValue == null)
                throw new Exception("Vui lòng chọn phòng ban.");

            if (cboTrangThai.SelectedItem == null)
                throw new Exception("Vui lòng chọn trạng thái.");

            int? maHoSo = null;

            if (cboHoSo.SelectedValue != null &&
                cboHoSo.SelectedValue != DBNull.Value)
            {
                maHoSo = Convert.ToInt32(cboHoSo.SelectedValue);
            }

            int? nguoiKy = null;

            if (cboNguoiKy.SelectedValue != null &&
                cboNguoiKy.SelectedValue != DBNull.Value)
            {
                nguoiKy = Convert.ToInt32(cboNguoiKy.SelectedValue);
            }

            QuyetDinhTuyenDung q = new QuyetDinhTuyenDung
            {
                MaQuyetDinh = maQuyetDinh,
                MaNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue),
                MaHoSo = maHoSo,
                MaPhongBan = Convert.ToString(cboPhongBan.SelectedValue),
                NgayKy = dtpNgayKy.Value.Date,
                NgayBatDauThuViec = dtpNgayBatDau.Value.Date,
                NgayKetThucThuViec = dtpNgayKetThuc.Value.Date,
                LuongThuViec = nudLuong.Value,
                DieuKhoan = txtDieuKhoan.Text.Trim(),
                NguoiKy = nguoiKy,
                TrangThai = cboTrangThai.SelectedItem.ToString()
            };

            // Kiểm tra ứng viên đủ 18 tuổi tại ngày bắt đầu thử việc.
            if (q.MaHoSo.HasValue)
            {
                DataTable thongTin = LAB07.Data.Db.Query(
                    @"SELECT NgaySinh
                      FROM HoSoUngTuyen
                      WHERE MaHoSo = @MaHoSo",
                    LAB07.Data.Db.Param(
                        "@MaHoSo",
                        SqlDbType.Int,
                        q.MaHoSo.Value));

                if (thongTin.Rows.Count > 0 &&
                    thongTin.Rows[0]["NgaySinh"] != DBNull.Value)
                {
                    DateTime ngaySinh =
                        Convert.ToDateTime(thongTin.Rows[0]["NgaySinh"]);

                    if (ngaySinh.AddYears(18) > q.NgayBatDauThuViec.Date)
                    {
                        throw new Exception(
                            "Ứng viên phải đủ 18 tuổi tại ngày bắt đầu thử việc.");
                    }
                }
            }

            return q;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int result = service.Insert(GetFormData());

                if (result > 0)
                {
                    MessageBox.Show("Thêm quyết định thành công.");
                    LoadDanhSach();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu được thêm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (maQuyetDinh <= 0)
                    throw new Exception("Vui lòng chọn quyết định cần sửa.");

                int result = service.Update(GetFormData());

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật quyết định thành công.");
                    LoadDanhSach();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quyết định để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (maQuyetDinh <= 0)
                    throw new Exception("Vui lòng chọn quyết định cần xóa.");

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa quyết định này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                int result = service.Delete(maQuyetDinh);

                if (result > 0)
                {
                    MessageBox.Show("Xóa quyết định thành công.");
                    LoadDanhSach();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quyết định để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSach();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                if (keyword == "Nhập mã quyết định, nhân viên hoặc phòng ban...")
                    keyword = "";

                dgvDanhSach.DataSource = service.Search(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi tìm kiếm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDanhSach.Rows[e.RowIndex];

            if (row.Cells["MaQuyetDinh"].Value == null ||
                row.Cells["MaQuyetDinh"].Value == DBNull.Value)
                return;

            maQuyetDinh = Convert.ToInt32(
                row.Cells["MaQuyetDinh"].Value);

            SelectCombo(cboNhanVien, row, "MaNhanVien");
            SelectCombo(cboHoSo, row, "MaHoSo");
            SelectCombo(cboPhongBan, row, "MaPhongBan");
            SelectCombo(cboNguoiKy, row, "NguoiKy");

            SetDate(row, "NgayKy", dtpNgayKy);
            SetDate(row, "NgayBatDauThuViec", dtpNgayBatDau);
            SetDate(row, "NgayKetThucThuViec", dtpNgayKetThuc);

            if (row.Cells["LuongThuViec"].Value != null &&
                row.Cells["LuongThuViec"].Value != DBNull.Value)
            {
                decimal luong =
                    Convert.ToDecimal(row.Cells["LuongThuViec"].Value);

                nudLuong.Value = Math.Min(
                    nudLuong.Maximum,
                    Math.Max(nudLuong.Minimum, luong));
            }

            txtDieuKhoan.Text =
                row.Cells["DieuKhoan"].Value == null ||
                row.Cells["DieuKhoan"].Value == DBNull.Value
                    ? ""
                    : Convert.ToString(row.Cells["DieuKhoan"].Value);

            cboTrangThai.SelectedItem =
                Convert.ToString(row.Cells["TrangThai"].Value);
        }

        private void SelectCombo(
            ComboBox combo,
            DataGridViewRow row,
            string columnName)
        {
            if (!dgvDanhSach.Columns.Contains(columnName))
            {
                combo.SelectedIndex = -1;
                return;
            }

            object value = row.Cells[columnName].Value;

            if (value == null || value == DBNull.Value)
            {
                combo.SelectedIndex = -1;
                return;
            }

            combo.SelectedValue = value;
        }

        private void SetDate(
            DataGridViewRow row,
            string columnName,
            DateTimePicker picker)
        {
            if (!dgvDanhSach.Columns.Contains(columnName))
                return;

            object value = row.Cells[columnName].Value;

            if (value != null && value != DBNull.Value)
                picker.Value = Convert.ToDateTime(value);
        }

        private void LamMoi()
        {
            maQuyetDinh = 0;

            cboNhanVien.SelectedIndex = -1;
            cboHoSo.SelectedIndex = cboHoSo.Items.Count > 0 ? 0 : -1;
            cboPhongBan.SelectedIndex = -1;
            cboNguoiKy.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = -1;

            dtpNgayKy.Value = DateTime.Today;
            dtpNgayBatDau.Value = DateTime.Today.AddDays(1);
            dtpNgayKetThuc.Value = DateTime.Today.AddDays(61);

            nudLuong.Value = 0;
            txtDieuKhoan.Clear();
            txtTimKiem.Clear();

            dgvDanhSach.ClearSelection();
        }
    }
}
