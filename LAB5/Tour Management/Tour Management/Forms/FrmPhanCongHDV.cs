using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmPhanCongHDV : Form
    {
        private readonly PhanCongService _svc = new PhanCongService();
        private readonly NhanVienService _nvSvc = new NhanVienService();
        private int _maPC;
        private static readonly string[] Headers = {
            "MaPC", "Mã PC", "HoTen", "Hướng dẫn viên", "MaChuyen", "Chuyến lẻ", "MaDoan", "Mã đoàn",
            "TuNgay", "Từ ngày", "DenNgay", "Đến ngày" };

        public FrmPhanCongHDV() { InitializeComponent(); }

        private void FrmPhanCongHDV_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboNhanVien, _nvSvc.GetAll(), "HoTen", "MaNV");
                cboLoaiPhanCong.SelectedIndexChanged += (s, ev) => FormHelper.TryRun(FillChuyenDoan);
                cboChuyenDoan.SelectedIndexChanged += (s, ev) => CapNhatNgay();
                cboLoaiPhanCong.SelectedIndex = 0;
                FillChuyenDoan();
                LoadData();
            });
        }

        private void FillChuyenDoan()
        {
            string loai = cboLoaiPhanCong.SelectedIndex == 1 ? "D" : "C";
            FormHelper.BindCombo(cboChuyenDoan, ChuyenDoanLookup.GetAll(false, loai), "Ten", "Ma");
            CapNhatNgay();
        }

        /// <summary>Khi chọn chuyến/đoàn thì tự điền khoảng ngày phân công theo lịch của chuyến/đoàn.</summary>
        private void CapNhatNgay()
        {
            var it = cboChuyenDoan.SelectedItem as ChuyenDoanItem;
            if (it == null) return;
            dtpTuNgay.Value = it.NgayDi;
            dtpDenNgay.Value = it.NgayVe;
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _maPC = (int)FormHelper.Dec(dgvDanhSach.Rows[e.RowIndex], "MaPC");
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var it = cboChuyenDoan.SelectedItem as ChuyenDoanItem;
                if (it == null) throw new NghiepVuException("Chọn chuyến / đoàn.");
                var nv = cboNhanVien.SelectedItem as NhanVien;
                // BR05, BR10: chuyến lẻ chỉ 1 HDV; không phân công lịch chồng chéo (CSDL kiểm tra)
                _svc.PhanCong(nv == null ? 0 : nv.MaNV,
                    it.Loai == "C" ? it.Ma : null,
                    it.Loai == "D" ? (int?)int.Parse(it.Ma) : null,
                    dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
                LoadData();
                FormHelper.Info("Đã phân công hướng dẫn viên.");
            });
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (_maPC <= 0) { FormHelper.Info("Chọn dòng phân công cần hủy."); return; }
            if (!FormHelper.Confirm("Hủy phân công này?")) return;
            FormHelper.TryRun(() => { _svc.Huy(_maPC); _maPC = 0; LoadData(); });
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
