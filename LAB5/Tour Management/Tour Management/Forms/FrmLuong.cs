using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmLuong : Form
    {
        private readonly LuongService _svc = new LuongService();
        private readonly NhanVienService _nvSvc = new NhanVienService();
        private bool _loading = true;
        private static readonly string[] Headers = {
            "HoTen", "Nhân viên", "MaNV", "Mã NV", "Thang", "Tháng", "Nam", "Năm",
            "LuongCoBan", "Lương cơ bản", "SoTour", "Số tour", "LuongTheoTour", "Lương theo tour", "TongLuong", "Tổng lương" };

        public FrmLuong() { InitializeComponent(); }

        private void FrmLuong_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboNhanVien, _nvSvc.GetAll(), "HoTen", "MaNV");
                FormHelper.SetNum(numThang, DateTime.Today.Month);
                FormHelper.SetNum(numNam, DateTime.Today.Year);
                numLuongCoBan.ReadOnly = true;        // lấy từ hồ sơ nhân viên
                _loading = false;
                numThang.ValueChanged += (s, ev) => { if (!_loading) FormHelper.TryRun(LoadData); };
                numNam.ValueChanged += (s, ev) => { if (!_loading) FormHelper.TryRun(LoadData); };
                LoadData();
            });
        }

        private void LoadData()
        {
            FormHelper.BindGrid(dgvDanhSach, _svc.GetBangLuongThang((int)numThang.Value, (int)numNam.Value), Headers);
        }

        private int MaNV()
        {
            var nv = cboNhanVien.SelectedItem as NhanVien;
            return nv == null ? 0 : nv.MaNV;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            FormHelper.SelectValue(cboNhanVien, (int)FormHelper.Dec(r, "MaNV"));
            FormHelper.SetNum(numLuongCoBan, FormHelper.Dec(r, "LuongCoBan"));
            FormHelper.SetNum(numSoTour, FormHelper.Dec(r, "SoTour"));
            FormHelper.SetNum(numLuongTheoTour, FormHelper.Dec(r, "LuongTheoTour"));
            FormHelper.SetNum(numTongLuong, FormHelper.Dec(r, "TongLuong"));
        }

        /// <summary>BR06: tổng lương = lương cơ bản + lương theo từng tour trong tháng.</summary>
        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var bl = _svc.Tinh(MaNV(), (int)numThang.Value, (int)numNam.Value);
                FormHelper.SetNum(numLuongCoBan, bl.LuongCoBan);
                FormHelper.SetNum(numSoTour, bl.SoTour);
                FormHelper.SetNum(numLuongTheoTour, bl.LuongTheoTour);
                FormHelper.SetNum(numTongLuong, bl.TongLuong);
            });
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                if (MaNV() <= 0) throw new NghiepVuException("Chọn nhân viên.");
                _svc.Luu(MaNV(), (int)numThang.Value, (int)numNam.Value);
                LoadData();
                FormHelper.Info("Đã lưu bảng lương.");
            });
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
