using System;
using System.Data;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmDiemThamQuan : Form
    {
        private readonly DiemThamQuanService _svc = new DiemThamQuanService();
        private readonly TourService _tourSvc = new TourService();
        private static readonly string[] Headers = {
            "MaDiem", "Mã điểm", "TenDiem", "Tên điểm tham quan", "DiaDiem", "Địa điểm",
            "NoiDung", "Nội dung", "YNghia", "Ý nghĩa", "CacTour", "Thuộc tour" };

        public FrmDiemThamQuan() { InitializeComponent(); }

        private void FrmDiemThamQuan_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboTour, _tourSvc.GetAll(), "TenTour", "MaTour", true);
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private DiemThamQuan ReadForm()
        {
            return new DiemThamQuan
            {
                MaDiem = txtMaDiem.Text,
                TenDiem = txtTenDiem.Text,
                DiaDiem = txtDiaDiem.Text,
                NoiDung = txtNoiDung.Text,
                YNghia = txtYNghia.Text
            };
        }

        private void ResetForm() { FormHelper.ClearInputs(grpThongTin); txtMaDiem.ReadOnly = false; }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            txtMaDiem.Text = FormHelper.Str(r, "MaDiem"); txtMaDiem.ReadOnly = true;
            txtTenDiem.Text = FormHelper.Str(r, "TenDiem");
            txtDiaDiem.Text = FormHelper.Str(r, "DiaDiem");
            txtNoiDung.Text = FormHelper.Str(r, "NoiDung");
            txtYNghia.Text = FormHelper.Str(r, "YNghia");
            cboTour.SelectedIndex = -1;                   // liên kết tour chọn lại khi cần thêm liên kết mới
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                _svc.Them(ReadForm(), cboTour.SelectedValue as string);
                LoadData(); ResetForm();
                FormHelper.Info("Đã thêm điểm tham quan.");
            });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                _svc.Sua(ReadForm(), cboTour.SelectedValue as string);
                LoadData();
                FormHelper.Info("Đã cập nhật.");
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!FormHelper.Confirm("Xóa điểm tham quan \"" + txtTenDiem.Text + "\"?")) return;
            FormHelper.TryRun(() => { _svc.Xoa(txtMaDiem.Text); LoadData(); ResetForm(); });
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                string kw = txtTenDiem.Text.Trim() != "" ? txtTenDiem.Text : (txtDiaDiem.Text.Trim() != "" ? txtDiaDiem.Text : txtMaDiem.Text);
                var dt = _svc.GetDanhSach();
                string k = FormHelper.EscapeFilter(kw);
                dt.DefaultView.RowFilter = "MaDiem LIKE '%" + k + "%' OR TenDiem LIKE '%" + k + "%' OR DiaDiem LIKE '%" + k + "%'";
                FormHelper.BindGrid(dgvDanhSach, dt.DefaultView, Headers);
            });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
