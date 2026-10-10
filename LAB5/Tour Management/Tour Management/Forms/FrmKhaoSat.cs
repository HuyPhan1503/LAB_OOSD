using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmKhaoSat : Form
    {
        private readonly KhaoSatService _svc = new KhaoSatService();
        private int _maKS;
        private static readonly string[] Headers = {
            "MaKS", "Mã KS", "MaChuyen", "Chuyến lẻ", "MaDoan", "Mã đoàn", "TenKhach", "Tên khách",
            "DiemDanhGia", "Điểm", "GopY", "Góp ý", "NgayKhaoSat", "Ngày khảo sát" };

        public FrmKhaoSat() { InitializeComponent(); }

        private void FrmKhaoSat_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                // BR07: chỉ khảo sát sau khi tour kết thúc
                FormHelper.BindCombo(cboChuyen, ChuyenDoanLookup.GetAll(true, null), "Ten", "Ma");
                FormHelper.SetNum(numDiemDanhGia, 5);
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            _maKS = (int)FormHelper.Dec(r, "MaKS");
            txtTenKhach.Text = FormHelper.Str(r, "TenKhach");
            FormHelper.SetNum(numDiemDanhGia, FormHelper.Dec(r, "DiemDanhGia"));
            txtGopY.Text = FormHelper.Str(r, "GopY");
            dtpNgayKhaoSat.Value = FormHelper.Date(r, "NgayKhaoSat");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var it = cboChuyen.SelectedItem as ChuyenDoanItem;
                if (it == null) throw new NghiepVuException("Chưa có chuyến / đoàn nào đã kết thúc để khảo sát.");
                _svc.Them(new KhaoSat
                {
                    MaChuyen = it.Loai == "C" ? it.Ma : null,
                    MaDoan = it.Loai == "D" ? (int?)int.Parse(it.Ma) : null,
                    TenKhach = txtTenKhach.Text,
                    DiemDanhGia = (byte)numDiemDanhGia.Value,
                    GopY = txtGopY.Text,
                    NgayKhaoSat = dtpNgayKhaoSat.Value.Date
                });
                LoadData(); ResetForm();
                FormHelper.Info("Đã ghi nhận phiếu khảo sát.");
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maKS <= 0) { FormHelper.Info("Chọn dòng cần xóa."); return; }
            if (!FormHelper.Confirm("Xóa phiếu khảo sát này?")) return;
            FormHelper.TryRun(() => { _svc.Xoa(_maKS); LoadData(); ResetForm(); });
        }

        private void ResetForm()
        {
            _maKS = 0;
            txtTenKhach.Clear(); txtGopY.Clear();
            FormHelper.SetNum(numDiemDanhGia, 5);
            dtpNgayKhaoSat.Value = DateTime.Today;
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
