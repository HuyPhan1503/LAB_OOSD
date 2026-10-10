using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmChuyen : Form
    {
        private readonly ChuyenService _svc = new ChuyenService();
        private readonly TourService _tourSvc = new TourService();
        private static readonly string[] Headers = {
            "MaChuyen", "Mã chuyến", "MaTour", "Mã tour", "TenTour", "Tên tour", "NgayDi", "Ngày đi",
            "NgayVe", "Ngày về", "TinhTrang", "Tình trạng", "SoKhach", "Số khách" };

        public FrmChuyen() { InitializeComponent(); }

        private void FrmChuyen_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboTour, _tourSvc.GetAll(), "TenTour", "MaTour");
                cboTinhTrang.SelectedIndex = 0;
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private ChuyenDi ReadForm()
        {
            return new ChuyenDi
            {
                MaChuyen = txtMaChuyen.Text,
                MaTour = cboTour.SelectedValue as string,
                NgayDi = dtpNgayDi.Value.Date,
                NgayVe = dtpNgayVe.Value.Date,
                TinhTrang = cboTinhTrang.Text
            };
        }

        private void ResetForm()
        {
            FormHelper.ClearInputs(grpThongTin);
            txtMaChuyen.ReadOnly = false;
            cboTour.SelectedIndex = cboTour.Items.Count > 0 ? 0 : -1;
            cboTinhTrang.SelectedIndex = 0;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            txtMaChuyen.Text = FormHelper.Str(r, "MaChuyen"); txtMaChuyen.ReadOnly = true;
            FormHelper.SelectValue(cboTour, FormHelper.Str(r, "MaTour"));
            dtpNgayDi.Value = FormHelper.Date(r, "NgayDi");
            dtpNgayVe.Value = FormHelper.Date(r, "NgayVe");
            FormHelper.SetNum(numSoKhach, FormHelper.Dec(r, "SoKhach"));
            cboTinhTrang.SelectedIndex = cboTinhTrang.FindStringExact(FormHelper.Str(r, "TinhTrang"));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() => { _svc.Them(ReadForm()); LoadData(); ResetForm(); FormHelper.Info("Đã thêm chuyến."); });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() => { _svc.Sua(ReadForm()); LoadData(); FormHelper.Info("Đã cập nhật chuyến."); });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!FormHelper.Confirm("Xóa chuyến \"" + txtMaChuyen.Text + "\"?")) return;
            FormHelper.TryRun(() => { _svc.Xoa(txtMaChuyen.Text); LoadData(); ResetForm(); });
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var dt = _svc.GetDanhSach();
                string k = FormHelper.EscapeFilter(txtMaChuyen.Text);
                dt.DefaultView.RowFilter = "MaChuyen LIKE '%" + k + "%' OR TenTour LIKE '%" + k + "%'";
                FormHelper.BindGrid(dgvDanhSach, dt.DefaultView, Headers);
            });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
