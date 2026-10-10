using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmTour : Form
    {
        private readonly TourService _svc = new TourService();
        private static readonly string[] Headers = {
            "MaTour", "Mã tour", "TenTour", "Tên tour", "SoNgay", "Số ngày", "SoDem", "Số đêm",
            "DonGia", "Đơn giá (1 khách)", "LuongHDV", "Lương HDV", "PhuongTien", "Phương tiện" };

        public FrmTour() { InitializeComponent(); }

        private void FrmTour_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboPhuongTien, _svc.GetPhuongTien(), "TenPT", "MaPT", true);
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSachHienThi(), Headers); }

        private Tour ReadForm()
        {
            return new Tour
            {
                MaTour = txtMaTour.Text,
                TenTour = txtTenTour.Text,
                SoNgay = (int)numSoNgay.Value,
                SoDem = (int)numSoDem.Value,
                DonGia = numDonGia.Value
            };
        }

        private int? SelectedPT()
        {
            var p = cboPhuongTien.SelectedItem as PhuongTien;
            return p == null ? (int?)null : p.MaPT;
        }

        private void ResetForm()
        {
            FormHelper.ClearInputs(grpThongTin);
            txtMaTour.ReadOnly = false;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            txtMaTour.Text = FormHelper.Str(r, "MaTour");
            txtMaTour.ReadOnly = true;                    // khóa khóa chính khi sửa
            txtTenTour.Text = FormHelper.Str(r, "TenTour");
            FormHelper.SetNum(numSoNgay, FormHelper.Dec(r, "SoNgay"));
            FormHelper.SetNum(numSoDem, FormHelper.Dec(r, "SoDem"));
            FormHelper.SetNum(numDonGia, FormHelper.Dec(r, "DonGia"));
            string pt = FormHelper.Str(r, "PhuongTien").Split(',')[0].Trim();
            cboPhuongTien.SelectedIndex = cboPhuongTien.FindStringExact(pt);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                _svc.Them(ReadForm(), SelectedPT());
                LoadData(); ResetForm();
                FormHelper.Info("Đã thêm tour.");
            });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                _svc.Sua(ReadForm(), SelectedPT());
                LoadData();
                FormHelper.Info("Đã cập nhật tour.");
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!FormHelper.Confirm("Xóa tour \"" + txtMaTour.Text + "\"?")) return;
            FormHelper.TryRun(() => { _svc.Xoa(txtMaTour.Text); LoadData(); ResetForm(); });
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                string kw = txtMaTour.Text.Trim() != "" ? txtMaTour.Text : txtTenTour.Text;
                FormHelper.BindGrid(dgvDanhSach, _svc.TimKiem(kw), Headers);
            });
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
            FormHelper.TryRun(LoadData);
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
