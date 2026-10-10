using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmDangKyKhachLe : Form
    {
        private readonly DangKyKhachLeService _svc = new DangKyKhachLeService();
        private readonly ChuyenService _chuyenSvc = new ChuyenService();
        private readonly TourService _tourSvc = new TourService();
        private Dictionary<string, decimal> _giaTour = new Dictionary<string, decimal>();
        private readonly string _maTour;
        private readonly DateTime? _ngayDi;
        private static readonly string[] Headers = {
            "MaDK", "Mã ĐK", "TenKhach", "Tên khách", "CCCD", "CCCD", "QuocTich", "Quốc tịch",
            "MaChuyen", "Chuyến", "NgayDi", "Ngày đi", "NgayVe", "Ngày về", "DiemBanVe", "Điểm bán vé",
            "DiemDon", "Điểm đón", "SoTien", "Số tiền" };

        public FrmDangKyKhachLe() : this(null, null) { }

        /// <summary>Mở từ FrmDatTour: chọn sẵn chuyến theo tour và ngày đi.</summary>
        public FrmDangKyKhachLe(string maTour, DateTime? ngayDi)
        {
            InitializeComponent();
            _maTour = maTour; _ngayDi = ngayDi;
        }

        private void FrmDangKyKhachLe_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                _giaTour = _tourSvc.GetAll().ToDictionary(t => t.MaTour, t => t.DonGia);
                var chuyens = _chuyenSvc.GetChuyenChuaKhoiHanh();
                FormHelper.BindCombo(cboChuyen, chuyens, null, "MaChuyen");
                FormHelper.BindCombo(cboDiemBanVe, _svc.GetDiemBanVe(), "TenDiem", "MaDiemBan", true);
                txtQuocTich.Text = "Việt Nam";

                int idx = -1;
                if (_maTour != null)
                    idx = chuyens.FindIndex(c => c.MaTour == _maTour && (_ngayDi == null || c.NgayDi.Date == _ngayDi.Value.Date));
                if (idx < 0 && _maTour != null) idx = chuyens.FindIndex(c => c.MaTour == _maTour);
                if (idx >= 0) cboChuyen.SelectedIndex = idx;

                cboChuyen.SelectedIndexChanged += (s, ev) => CapNhatGia();
                CapNhatGia();
                LoadData();
            });
        }

        /// <summary>Tự điền số tiền vé theo đơn giá của tour trong chuyến đã chọn.</summary>
        private void CapNhatGia()
        {
            var ch = cboChuyen.SelectedItem as ChuyenDi;
            decimal gia;
            if (ch != null && _giaTour.TryGetValue(ch.MaTour, out gia)) FormHelper.SetNum(numSoTien, gia);
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private void ResetForm()
        {
            txtTenKhach.Clear(); txtCCCD.Clear(); txtDiaChi.Clear(); txtDiemDon.Clear();
            txtQuocTich.Text = "Việt Nam";
            cboDiemBanVe.SelectedIndex = -1;
            CapNhatGia();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvDanhSach.Rows[e.RowIndex];
            txtTenKhach.Text = FormHelper.Str(r, "TenKhach");
            txtCCCD.Text = FormHelper.Str(r, "CCCD");
            txtQuocTich.Text = FormHelper.Str(r, "QuocTich");
            txtDiemDon.Text = FormHelper.Str(r, "DiemDon");
            FormHelper.SetNum(numSoTien, FormHelper.Dec(r, "SoTien"));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var k = new KhachLe { TenKhach = txtTenKhach.Text, CCCD = txtCCCD.Text, DiaChi = txtDiaChi.Text, QuocTich = txtQuocTich.Text };
                var ch = cboChuyen.SelectedItem as ChuyenDi;
                var diem = cboDiemBanVe.SelectedItem as DiemBanVe;
                _svc.DangKy(k, ch == null ? null : ch.MaChuyen, diem == null ? (int?)null : diem.MaDiemBan, txtDiemDon.Text, numSoTien.Value);
                FormHelper.Info("Đã lưu phiếu đăng ký khách lẻ.");
                LoadData(); ResetForm();
            });
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                string kw = txtCCCD.Text.Trim() != "" ? txtCCCD.Text : txtTenKhach.Text;
                FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(null, string.IsNullOrWhiteSpace(kw) ? null : kw), Headers);
            });
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
