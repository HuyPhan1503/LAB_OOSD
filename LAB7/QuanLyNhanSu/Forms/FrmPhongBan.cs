
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LAB07.Models;
using LAB07.Services;

namespace LAB07.Forms
{
    public partial class FrmPhongBan : Form
    {
        private readonly PhongBanService _service =
            new PhongBanService();

        public FrmPhongBan()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvPhongBan.DataSource = _service.GetAll();
                FormatGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh sách phòng ban.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvPhongBan.Columns["MaPhongBan"] != null)
                dgvPhongBan.Columns["MaPhongBan"].HeaderText = "Mã phòng ban";

            if (dgvPhongBan.Columns["TenPhongBan"] != null)
                dgvPhongBan.Columns["TenPhongBan"].HeaderText = "Tên phòng ban";

            if (dgvPhongBan.Columns["MoTa"] != null)
                dgvPhongBan.Columns["MoTa"].HeaderText = "Mô tả";

            if (dgvPhongBan.Columns["TrangThai"] != null)
            {
                dgvPhongBan.Columns["TrangThai"].HeaderText = "Đang hoạt động";
            }

            dgvPhongBan.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private PhongBan GetInput()
        {
            return new PhongBan
            {
                MaPhongBan = txtMaPhongBan.Text.Trim(),
                TenPhongBan = txtTenPhongBan.Text.Trim(),
                MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text)
                    ? null
                    : txtMoTa.Text.Trim(),
                TrangThai = chkTrangThai.Checked
            };
        }

        private void ClearInputs()
        {
            txtMaPhongBan.Clear();
            txtTenPhongBan.Clear();
            txtMoTa.Clear();
            chkTrangThai.Checked = true;

            txtMaPhongBan.ReadOnly = false;
            dgvPhongBan.ClearSelection();
            txtMaPhongBan.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _service.Insert(GetInput());

                MessageBox.Show(
                    "Thêm phòng ban thành công.",
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
                    ex.Message, "Không thể thêm phòng ban",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhongBan.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần sửa.");
                return;
            }

            try
            {
                _service.Update(GetInput());

                MessageBox.Show(
                    "Cập nhật phòng ban thành công.",
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
                    ex.Message, "Không thể cập nhật",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhongBan.Text.Trim();

            if (ma.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ban cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phòng ban " + ma + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                _service.Delete(ma);

                MessageBox.Show("Xóa phòng ban thành công.");
                LoadData();
            }
            catch (SqlException ex)
            {
                ShowDatabaseError(ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Không thể xóa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPhongBan.DataSource =
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

        private void dgvPhongBan_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPhongBan.Rows[e.RowIndex];

            txtMaPhongBan.Text =
                Convert.ToString(row.Cells["MaPhongBan"].Value);

            txtTenPhongBan.Text =
                Convert.ToString(row.Cells["TenPhongBan"].Value);

            txtMoTa.Text =
                row.Cells["MoTa"].Value == DBNull.Value
                    ? ""
                    : Convert.ToString(row.Cells["MoTa"].Value);

            chkTrangThai.Checked =
                row.Cells["TrangThai"].Value != DBNull.Value &&
                Convert.ToBoolean(row.Cells["TrangThai"].Value);

            txtMaPhongBan.ReadOnly = true;
        }

        private void ShowDatabaseError(SqlException ex)
        {
            string message;

            if (ex.Number == 2627 || ex.Number == 2601)
            {
                message = "Mã phòng ban hoặc tên phòng ban đã tồn tại.";
            }
            else if (ex.Number == 547)
            {
                message =
                    "Không thể xóa hoặc thay đổi dữ liệu vì phòng ban " +
                    "đang được dữ liệu khác tham chiếu.";
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
