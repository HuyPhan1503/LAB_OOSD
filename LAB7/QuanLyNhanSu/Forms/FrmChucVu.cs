
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LAB07.Models;
using LAB07.Services;

namespace LAB07.Forms
{
    public partial class FrmChucVu : Form
    {
        private readonly ChucVuService _service =
            new ChucVuService();

        public FrmChucVu()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvChucVu.DataSource = _service.GetAll();
                FormatGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách chức vụ.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvChucVu.Columns["MaChucVu"] != null)
                dgvChucVu.Columns["MaChucVu"].HeaderText = "Mã chức vụ";

            if (dgvChucVu.Columns["TenChucVu"] != null)
                dgvChucVu.Columns["TenChucVu"].HeaderText = "Tên chức vụ";

            if (dgvChucVu.Columns["PhuCapChucVu"] != null)
            {
                dgvChucVu.Columns["PhuCapChucVu"].HeaderText =
                    "Phụ cấp chức vụ";

                dgvChucVu.Columns["PhuCapChucVu"].DefaultCellStyle
                    .Format = "N0";
            }

            if (dgvChucVu.Columns["TrangThai"] != null)
                dgvChucVu.Columns["TrangThai"].HeaderText = "Hoạt động";

            dgvChucVu.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private ChucVu GetInput()
        {
            decimal phuCap;

            if (!decimal.TryParse(txtPhuCap.Text.Trim(), out phuCap))
                throw new ArgumentException(
                    "Phụ cấp chức vụ phải là số hợp lệ.");

            return new ChucVu
            {
                MaChucVu = txtMaChucVu.Text.Trim(),
                TenChucVu = txtTenChucVu.Text.Trim(),
                PhuCapChucVu = phuCap,
                TrangThai = chkTrangThai.Checked
            };
        }

        private void ClearInputs()
        {
            txtMaChucVu.Clear();
            txtTenChucVu.Clear();
            txtPhuCap.Text = "0";
            chkTrangThai.Checked = true;

            txtMaChucVu.ReadOnly = false;
            dgvChucVu.ClearSelection();
            txtMaChucVu.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _service.Insert(GetInput());

                MessageBox.Show(
                    "Thêm chức vụ thành công.",
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
                    "Không thể thêm chức vụ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChucVu.Text))
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần sửa.");
                return;
            }

            try
            {
                _service.Update(GetInput());

                MessageBox.Show(
                    "Cập nhật chức vụ thành công.",
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
                    "Không thể cập nhật chức vụ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaChucVu.Text.Trim();

            if (ma.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa chức vụ " + ma + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _service.Delete(ma);

                MessageBox.Show("Xóa chức vụ thành công.");
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
                    "Không thể xóa chức vụ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvChucVu.DataSource =
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

        private void dgvChucVu_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvChucVu.Rows[e.RowIndex];

            txtMaChucVu.Text =
                Convert.ToString(row.Cells["MaChucVu"].Value);

            txtTenChucVu.Text =
                Convert.ToString(row.Cells["TenChucVu"].Value);

            txtPhuCap.Text =
                row.Cells["PhuCapChucVu"].Value == DBNull.Value
                    ? "0"
                    : Convert.ToDecimal(
                        row.Cells["PhuCapChucVu"].Value).ToString("0.##");

            chkTrangThai.Checked =
                row.Cells["TrangThai"].Value != DBNull.Value &&
                Convert.ToBoolean(row.Cells["TrangThai"].Value);

            txtMaChucVu.ReadOnly = true;
        }

        private void ShowDatabaseError(SqlException ex)
        {
            string message;

            if (ex.Number == 2627 || ex.Number == 2601)
            {
                message = "Mã chức vụ hoặc tên chức vụ đã tồn tại.";
            }
            else if (ex.Number == 547)
            {
                message =
                    "Không thể xóa chức vụ vì đang được dữ liệu khác tham chiếu.";
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
