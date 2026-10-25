
using System;
using System.Data;
using System.Windows.Forms;
using LAB07.Models;
using LAB07.Services;

namespace LAB07.Forms
{
    public partial class FrmHoSoUngTuyen : Form
    {
        private readonly HoSoUngTuyenService _service =
            new HoSoUngTuyenService();

        private int _maHoSoDangChon = 0;

        public FrmHoSoUngTuyen()
        {
            InitializeComponent();
        }

        private void FrmHoSoUngTuyen_Load(object sender, EventArgs e)
        {
            try
            {
                cboGioiTinh.Items.Clear();
                cboGioiTinh.Items.AddRange(
                    new object[] { "Nam", "Nữ", "Khác" });

                cboTrangThai.Items.Clear();
                cboTrangThai.Items.AddRange(
                    new object[]
                    {
                        "Mới tiếp nhận",
                        "Đang xét duyệt",
                        "Được tuyển",
                        "Không đạt"
                    });

                dtpNgaySinh.MaxDate = DateTime.Today.AddDays(-1);
                dtpNgaySinh.Value = DateTime.Today.AddYears(-22);

                dtpNgayUngTuyen.MaxDate = DateTime.Today;
                dtpNgayUngTuyen.Value = DateTime.Today;

                LoadPhongBan();
                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu hồ sơ ứng tuyển.\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadPhongBan()
        {
            DataTable dt = _service.GetPhongBan();

            cboPhongBan.DataSource = dt;
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "MaPhongBan";
            cboPhongBan.SelectedIndex = -1;
        }

        private void LoadData()
        {
            dgvHoSo.DataSource = _service.GetAll();
            FormatGrid();
        }

        private void FormatGrid()
        {
            if (dgvHoSo.Columns.Count == 0)
                return;

            dgvHoSo.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvHoSo.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHoSo.MultiSelect = false;
            dgvHoSo.ReadOnly = true;
            dgvHoSo.AllowUserToAddRows = false;
            dgvHoSo.RowHeadersVisible = false;

            SetHeader("MaHoSo", "Mã hồ sơ");
            SetHeader("HoTen", "Họ tên");
            SetHeader("NgaySinh", "Ngày sinh");
            SetHeader("GioiTinh", "Giới tính");
            SetHeader("CCCD", "CCCD");
            SetHeader("DiaChi", "Địa chỉ");
            SetHeader("DienThoai", "Điện thoại");
            SetHeader("Email", "Email");
            SetHeader("TrinhDo", "Trình độ");
            SetHeader("ViTriUngTuyen", "Vị trí ứng tuyển");
            SetHeader("MaPhongBan", "Mã phòng ban");
            SetHeader("TenPhongBan", "Phòng ban");
            SetHeader("NgayUngTuyen", "Ngày ứng tuyển");
            SetHeader("TrangThai", "Trạng thái");

            if (dgvHoSo.Columns.Contains("NgaySinh"))
                dgvHoSo.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvHoSo.Columns.Contains("NgayUngTuyen"))
                dgvHoSo.Columns["NgayUngTuyen"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void SetHeader(string columnName, string header)
        {
            if (dgvHoSo.Columns.Contains(columnName))
                dgvHoSo.Columns[columnName].HeaderText = header;
        }

        private HoSoUngTuyen GetInput()
        {
            if (cboPhongBan.SelectedValue == null)
                throw new Exception("Vui lòng chọn phòng ban.");

            if (cboGioiTinh.SelectedItem == null)
                throw new Exception("Vui lòng chọn giới tính.");

            if (cboTrangThai.SelectedItem == null)
                throw new Exception("Vui lòng chọn trạng thái.");

            return new HoSoUngTuyen
            {
                MaHoSo = _maHoSoDangChon,
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = cboGioiTinh.Text,
                CCCD = txtCCCD.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                TrinhDo = txtTrinhDo.Text.Trim(),
                ViTriUngTuyen = txtViTriUngTuyen.Text.Trim(),
                MaPhongBan = Convert.ToString(cboPhongBan.SelectedValue),
                NgayUngTuyen = dtpNgayUngTuyen.Value.Date,
                TrangThai = cboTrangThai.Text
            };
        }

        private void ClearInput()
        {
            _maHoSoDangChon = 0;

            txtHoTen.Clear();
            txtCCCD.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtTrinhDo.Clear();
            txtViTriUngTuyen.Clear();

            cboGioiTinh.SelectedIndex = -1;
            cboPhongBan.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;

            dtpNgaySinh.Value = DateTime.Today.AddYears(-22);
            dtpNgayUngTuyen.Value = DateTime.Today;

            dgvHoSo.ClearSelection();
            txtHoTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                HoSoUngTuyen hs = GetInput();
                hs.MaHoSo = 0;

                _service.Insert(hs);

                MessageBox.Show(
                    "Thêm hồ sơ ứng tuyển thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_maHoSoDangChon <= 0)
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần sửa.");
                    return;
                }

                _service.Update(GetInput());

                MessageBox.Show(
                    "Cập nhật hồ sơ thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (_maHoSoDangChon <= 0)
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần xóa.");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hồ sơ này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                _service.Delete(_maHoSoDangChon);

                MessageBox.Show("Xóa hồ sơ thành công.");

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                ClearInput();
                LoadData();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvHoSo.DataSource = _service.Search(txtTimKiem.Text.Trim());
                FormatGrid();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void dgvHoSo_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvHoSo.Rows[e.RowIndex];

            _maHoSoDangChon =
                Convert.ToInt32(row.Cells["MaHoSo"].Value);

            txtHoTen.Text = GetCellText(row, "HoTen");
            txtCCCD.Text = GetCellText(row, "CCCD");
            txtDiaChi.Text = GetCellText(row, "DiaChi");
            txtDienThoai.Text = GetCellText(row, "DienThoai");
            txtEmail.Text = GetCellText(row, "Email");
            txtTrinhDo.Text = GetCellText(row, "TrinhDo");
            txtViTriUngTuyen.Text = GetCellText(row, "ViTriUngTuyen");

            cboGioiTinh.Text = GetCellText(row, "GioiTinh");
            cboTrangThai.Text = GetCellText(row, "TrangThai");

            if (row.Cells["NgaySinh"].Value != DBNull.Value)
                dtpNgaySinh.Value =
                    Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            if (row.Cells["NgayUngTuyen"].Value != DBNull.Value)
                dtpNgayUngTuyen.Value =
                    Convert.ToDateTime(row.Cells["NgayUngTuyen"].Value);

            string maPhongBan = GetCellText(row, "MaPhongBan");
            cboPhongBan.SelectedValue = maPhongBan;
        }

        private string GetCellText(DataGridViewRow row, string columnName)
        {
            if (!dgvHoSo.Columns.Contains(columnName) ||
                row.Cells[columnName].Value == null ||
                row.Cells[columnName].Value == DBNull.Value)
            {
                return "";
            }

            return Convert.ToString(row.Cells[columnName].Value) ?? "";
        }

        private void ShowError(Exception ex)
        {
            string message = ex.Message;

            if (ex is System.Data.SqlClient.SqlException sqlEx)
            {
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                    message = "CCCD đã tồn tại trong hệ thống.";
                else if (sqlEx.Number == 547)
                    message = "Dữ liệu đang được tham chiếu hoặc phòng ban không hợp lệ.";
                else if (sqlEx.Number == 208)
                    message = "Không tìm thấy bảng dữ liệu. Hãy kiểm tra cấu trúc database.";
            }

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
