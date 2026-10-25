
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LAB07.Models;
using LAB07.Services;

namespace LAB07.Forms
{
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienService _service =
            new NhanVienService();

        public FrmNhanVien()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            try
            {
                cboPhongBan.DataSource = _service.GetPhongBan();
                cboPhongBan.DisplayMember = "TenPhongBan";
                cboPhongBan.ValueMember = "MaPhongBan";
                cboPhongBan.SelectedIndex = -1;

                cboChucVu.DataSource = _service.GetChucVu();
                cboChucVu.DisplayMember = "TenChucVu";
                cboChucVu.ValueMember = "MaChucVu";
                cboChucVu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh mục phòng ban/chức vụ.\n" +
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvNhanVien.DataSource = _service.GetAll();
                FormatGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách nhân viên.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            string[,] headers =
            {
                { "MaNhanVien", "Mã nhân viên" },
                { "HoTen", "Họ và tên" },
                { "NgaySinh", "Ngày sinh" },
                { "GioiTinh", "Giới tính" },
                { "CCCD", "CCCD" },
                { "DienThoai", "Điện thoại" },
                { "Email", "Email" },
                { "TrinhDo", "Trình độ" },
                { "NgayVaoLam", "Ngày vào làm" },
                { "TenPhongBan", "Phòng ban" },
                { "TenChucVu", "Chức vụ" },
                { "TrangThai", "Trạng thái" },
                { "DiaChi", "Địa chỉ" }
            };

            for (int i = 0; i < headers.GetLength(0); i++)
            {
                string columnName = headers[i, 0];

                if (dgvNhanVien.Columns[columnName] != null)
                    dgvNhanVien.Columns[columnName].HeaderText =
                        headers[i, 1];
            }

            if (dgvNhanVien.Columns["MaPhongBan"] != null)
                dgvNhanVien.Columns["MaPhongBan"].Visible = false;

            if (dgvNhanVien.Columns["MaChucVu"] != null)
                dgvNhanVien.Columns["MaChucVu"].Visible = false;

            if (dgvNhanVien.Columns["NgaySinh"] != null)
                dgvNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format =
                    "dd/MM/yyyy";

            if (dgvNhanVien.Columns["NgayVaoLam"] != null)
                dgvNhanVien.Columns["NgayVaoLam"].DefaultCellStyle.Format =
                    "dd/MM/yyyy";

            dgvNhanVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private string GetComboValue(ComboBox combo)
        {
            if (combo.SelectedIndex < 0 || combo.SelectedValue == null)
                return null;

            return Convert.ToString(combo.SelectedValue);
        }

        private NhanVien GetInput()
        {
            return new NhanVien
            {
                MaNhanVien = int.TryParse(txtMaNhanVien.Text, out int id)
                    ? id : 0,

                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.Text,
                CCCD = txtCCCD.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                TrinhDo = txtTrinhDo.Text.Trim(),

                NgayVaoLam = dtpNgayVaoLam.Checked
                    ? dtpNgayVaoLam.Value.Date
                    : (DateTime?)null,

                MaPhongBan = GetComboValue(cboPhongBan),
                MaChucVu = GetComboValue(cboChucVu),
                TrangThai = cboTrangThai.Text
            };
        }

        private void ClearInputs()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtTrinhDo.Clear();

            dtpNgaySinh.Value = DateTime.Today.AddYears(-22);
            dtpNgayVaoLam.Value = DateTime.Today;
            dtpNgayVaoLam.Checked = false;

            cboGioiTinh.SelectedIndex = 0;
            cboTrangThai.SelectedIndex = 0;
            cboPhongBan.SelectedIndex = -1;
            cboChucVu.SelectedIndex = -1;

            txtMaNhanVien.ReadOnly = true;
            dgvNhanVien.ClearSelection();
            txtHoTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _service.Insert(GetInput());

                MessageBox.Show(
                    "Thêm nhân viên thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể thêm nhân viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNhanVien.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật.");
                return;
            }

            try
            {
                _service.Update(GetInput());

                MessageBox.Show(
                    "Cập nhật nhân viên thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể cập nhật nhân viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNhanVien.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên mã " + id + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _service.Delete(id);

                MessageBox.Show("Xóa nhân viên thành công.");
                LoadData();
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Không thể xóa nhân viên",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvNhanVien.DataSource =
                    _service.Search(txtTimKiem.Text.Trim());

                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi tìm kiếm: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            txtMaNhanVien.Text =
                Convert.ToString(row.Cells["MaNhanVien"].Value);

            txtHoTen.Text =
                Convert.ToString(row.Cells["HoTen"].Value);

            if (row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value =
                    Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            cboGioiTinh.Text =
                Convert.ToString(row.Cells["GioiTinh"].Value);

            txtCCCD.Text =
                Convert.ToString(row.Cells["CCCD"].Value);

            txtDiaChi.Text =
                Convert.ToString(row.Cells["DiaChi"].Value);

            txtDienThoai.Text =
                Convert.ToString(row.Cells["DienThoai"].Value);

            txtEmail.Text =
                Convert.ToString(row.Cells["Email"].Value);

            txtTrinhDo.Text =
                Convert.ToString(row.Cells["TrinhDo"].Value);

            object ngayVaoLam = row.Cells["NgayVaoLam"].Value;

            if (ngayVaoLam != DBNull.Value && ngayVaoLam != null)
            {
                dtpNgayVaoLam.Value = Convert.ToDateTime(ngayVaoLam);
                dtpNgayVaoLam.Checked = true;
            }
            else
            {
                dtpNgayVaoLam.Checked = false;
            }

            object maPhongBan = row.Cells["MaPhongBan"].Value;
            cboPhongBan.SelectedValue =
                maPhongBan == DBNull.Value ? null : maPhongBan;

            object maChucVu = row.Cells["MaChucVu"].Value;
            cboChucVu.SelectedValue =
                maChucVu == DBNull.Value ? null : maChucVu;

            cboTrangThai.Text =
                Convert.ToString(row.Cells["TrangThai"].Value);
        }

        private void ShowDatabaseError(SqlException ex)
        {
            string message;

            if (ex.Number == 2627 || ex.Number == 2601)
            {
                message = "Số CCCD đã tồn tại trong hệ thống.";
            }
            else if (ex.Number == 547)
            {
                message =
                    "Không thể xóa nhân viên vì đã có hồ sơ nghiệp vụ " +
                    "tham chiếu đến nhân viên này.";
            }
            else
            {
                message = "Lỗi cơ sở dữ liệu: " + ex.Message;
            }

            MessageBox.Show(
                message,
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
