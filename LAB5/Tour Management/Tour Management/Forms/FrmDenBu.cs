using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmDenBu : Form
    {
        private readonly DenBuService _svc = new DenBuService();
        private int _maDB;
        private static readonly string[] Headers = {
            "MaDB", "Mã phiếu", "MaChuyen", "Chuyến lẻ", "MaDoan", "Mã đoàn", "DichVu", "Dịch vụ",
            "MoTa", "Mô tả", "MucDo", "Mức độ", "SoTienDenBu", "Số tiền đền bù", "NgayLap", "Ngày lập" };

        public FrmDenBu() { InitializeComponent(); }

        private void FrmDenBu_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboChuyen, ChuyenDoanLookup.GetAll(false, null), "Ten", "Ma");
                cboDichVu.Items.AddRange(new object[] { "Khách sạn", "Phương tiện", "Nơi ăn", "Hướng dẫn viên", "Điểm tham quan", "Khác" });
                cboDichVu.SelectedIndex = 0;
                cboMucDo.SelectedIndex = 0;
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            _maDB = (int)FormHelper.Dec(r, "MaDB");
            cboDichVu.SelectedIndex = cboDichVu.FindStringExact(FormHelper.Str(r, "DichVu"));
            txtMoTa.Text = FormHelper.Str(r, "MoTa");
            cboMucDo.SelectedIndex = cboMucDo.FindStringExact(FormHelper.Str(r, "MucDo"));
            FormHelper.SetNum(numSoTienDenBu, FormHelper.Dec(r, "SoTienDenBu"));
        }

        /// <summary>BR08: lập phiếu đền bù theo dịch vụ và mức độ thiệt hại.</summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var it = cboChuyen.SelectedItem as ChuyenDoanItem;
                if (it == null) throw new NghiepVuException("Chọn chuyến / đoàn.");
                _svc.Them(new DenBu
                {
                    MaChuyen = it.Loai == "C" ? it.Ma : null,
                    MaDoan = it.Loai == "D" ? (int?)int.Parse(it.Ma) : null,
                    DichVu = cboDichVu.Text,
                    MoTa = txtMoTa.Text,
                    MucDo = cboMucDo.Text,
                    SoTienDenBu = numSoTienDenBu.Value
                });
                LoadData(); ResetForm();
                FormHelper.Info("Đã lập phiếu đền bù.");
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_maDB <= 0) { FormHelper.Info("Chọn dòng cần xóa."); return; }
            if (!FormHelper.Confirm("Xóa phiếu đền bù này?")) return;
            FormHelper.TryRun(() => { _svc.Xoa(_maDB); LoadData(); ResetForm(); });
        }

        private void ResetForm()
        {
            _maDB = 0;
            txtMoTa.Clear();
            cboDichVu.SelectedIndex = 0; cboMucDo.SelectedIndex = 0;
            FormHelper.SetNum(numSoTienDenBu, 0);
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
