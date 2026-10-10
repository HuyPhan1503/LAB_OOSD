using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmNoiDungChan : Form
    {
        private readonly NoiDungChanService _svc = new NoiDungChanService();
        private readonly TourService _tourSvc = new TourService();
        private int _maNoi;
        private bool _loading;
        private static readonly string[] Headers = {
            "MaNoi", "Mã", "MaTour", "Tour", "TenNoi", "Nơi dừng chân", "DoiPhuongTien", "Đổi PT",
            "CoNoiAn", "Nơi ăn", "CoKhachSan", "Khách sạn", "LoaiKhachSan", "Số sao" };

        public FrmNoiDungChan() { InitializeComponent(); }

        private void FrmNoiDungChan_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                _loading = true;
                FormHelper.BindCombo(cboTour, _tourSvc.GetAll(), "TenTour", "MaTour");
                _loading = false;
                cboLoaiKhachSan.Enabled = false;
                cboTour.SelectedIndexChanged += (s, ev) => { if (!_loading) FormHelper.TryRun(LoadData); };
                LoadData();
            });
        }

        private void LoadData()
        {
            var tour = cboTour.SelectedValue as string;
            FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(tour), Headers);
        }

        private NoiDungChan ReadForm()
        {
            byte? sao = null;
            if (chkCoKhachSan.Checked && cboLoaiKhachSan.SelectedIndex >= 0)
                sao = (byte)(cboLoaiKhachSan.SelectedIndex + 2);        // "2 sao".."5 sao"
            return new NoiDungChan
            {
                MaNoi = _maNoi,
                MaTour = cboTour.SelectedValue as string,
                TenNoi = txtTenNoiDung.Text,
                DoiPhuongTien = chkDoiPhuongTien.Checked,
                CoNoiAn = chkCoNoiAn.Checked,
                CoKhachSan = chkCoKhachSan.Checked,
                LoaiKhachSan = sao
            };
        }

        private void ResetForm()
        {
            _maNoi = 0;
            txtTenNoiDung.Clear();
            chkDoiPhuongTien.Checked = chkCoNoiAn.Checked = chkCoKhachSan.Checked = false;
            cboLoaiKhachSan.SelectedIndex = -1;
        }

        private void chkCoKhachSan_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiKhachSan.Enabled = chkCoKhachSan.Checked;   // chỉ chọn loại KS (2-5 sao) khi có khách sạn
            if (!chkCoKhachSan.Checked) cboLoaiKhachSan.SelectedIndex = -1;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            _maNoi = (int)FormHelper.Dec(r, "MaNoi");
            txtTenNoiDung.Text = FormHelper.Str(r, "TenNoi");
            chkDoiPhuongTien.Checked = FormHelper.Bool(r, "DoiPhuongTien");
            chkCoNoiAn.Checked = FormHelper.Bool(r, "CoNoiAn");
            chkCoKhachSan.Checked = FormHelper.Bool(r, "CoKhachSan");
            int sao = (int)FormHelper.Dec(r, "LoaiKhachSan");
            cboLoaiKhachSan.SelectedIndex = sao >= 2 ? sao - 2 : -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() => { _svc.Them(ReadForm()); LoadData(); ResetForm(); });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                if (_maNoi <= 0) throw new NghiepVuException("Chọn dòng cần sửa.");
                _svc.Sua(ReadForm()); LoadData();
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maNoi <= 0) { FormHelper.Info("Chọn dòng cần xóa."); return; }
            if (!FormHelper.Confirm("Xóa nơi dừng chân này?")) return;
            FormHelper.TryRun(() => { _svc.Xoa(_maNoi); LoadData(); ResetForm(); });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
