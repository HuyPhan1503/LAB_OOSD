using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmDangKyDoan : Form
    {
        private readonly DoanKhachService _svc = new DoanKhachService();
        private readonly TourService _tourSvc = new TourService();
        private List<NguoiDiDoan> _nguoiDis = new List<NguoiDiDoan>();
        private readonly string _maTour;
        private readonly DateTime _ngayDi;
        private readonly int _soNguoi;
        private static readonly string[] Headers = {
            "MaDoan", "Mã đoàn", "TenCoQuan", "Cơ quan / đại diện", "NguoiDaiDien", "Người đại diện",
            "DienThoai", "Điện thoại", "TenTour", "Tour", "NgayDi", "Ngày đi", "NgayVe", "Ngày về",
            "SoNguoi", "Số người", "TienDatCoc", "Tiền cọc", "TrangThai", "Trạng thái" };

        public FrmDangKyDoan() : this(null, DateTime.Today.AddDays(7), 13) { }

        /// <summary>Mở từ FrmDatTour: điền sẵn tour, ngày đi, số người.</summary>
        public FrmDangKyDoan(string maTour, DateTime ngayDi, int soNguoi)
        {
            InitializeComponent();
            _maTour = maTour; _ngayDi = ngayDi; _soNguoi = soNguoi;
        }

        private void FrmDangKyDoan_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboTour, _tourSvc.GetAll(), "TenTour", "MaTour");
                if (_maTour != null) cboTour.SelectedValue = _maTour;
                dtpNgayDi.Value = _ngayDi < dtpNgayDi.MinDate ? DateTime.Today : _ngayDi;
                FormHelper.SetNum(numSoNguoi, _soNguoi);
                numSoNguoiBaoHiem.Enabled = false;
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSach(), Headers); }

        private void chkMuaBaoHiem_CheckedChanged(object sender, EventArgs e)
        {
            numSoNguoiBaoHiem.Enabled = chkMuaBaoHiem.Checked;
            if (!chkMuaBaoHiem.Checked) numSoNguoiBaoHiem.Value = numSoNguoiBaoHiem.Minimum;
        }

        /// <summary>Nhập danh sách người đi: mỗi dòng "Họ tên; CCCD". Bắt buộc nếu có mua bảo hiểm (BR02).</summary>
        private void btnDanhSachNguoi_Click(object sender, EventArgs e)
        {
            using (var dlg = new Form
            {
                Text = "Danh sách người đi (mỗi dòng: Họ tên; CCCD)",
                Width = 540,
                Height = 440,
                StartPosition = FormStartPosition.CenterParent
            })
            {
                var txt = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    Dock = DockStyle.Fill,
                    Text = string.Join(Environment.NewLine, _nguoiDis.Select(n => n.HoTen + "; " + n.CCCD))
                };
                var btn = new Button { Text = "Xong", Dock = DockStyle.Bottom, Height = 38, DialogResult = DialogResult.OK };
                dlg.Controls.AddRange(new Control[] { txt, btn });
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                _nguoiDis = new List<NguoiDiDoan>();
                foreach (var line in txt.Lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(new[] { ';' }, 2);
                    _nguoiDis.Add(new NguoiDiDoan
                    {
                        HoTen = parts[0].Trim(),
                        CCCD = parts.Length > 1 ? parts[1].Trim() : null
                    });
                }
                FormHelper.Info("Đã ghi nhận " + _nguoiDis.Count + " người đi.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var d = new DoanKhach
                {
                    TenCoQuan = txtTenCoQuan.Text,
                    DiaChi = txtDiaChi.Text,
                    DienThoai = txtDienThoai.Text,
                    NguoiDaiDien = txtNguoiDaiDien.Text,
                    MaTour = cboTour.SelectedValue as string,
                    NgayDi = dtpNgayDi.Value.Date,
                    SoNguoi = (int)numSoNguoi.Value,
                    DiaDiemDon = txtDiaDiemDon.Text,
                    CoBaoHiem = chkMuaBaoHiem.Checked,
                    SoNguoiBaoHiem = chkMuaBaoHiem.Checked ? (int)numSoNguoiBaoHiem.Value : 0,
                    TienDatCoc = numTienDatCoc.Value
                };
                foreach (var n in _nguoiDis) n.MuaBaoHiem = chkMuaBaoHiem.Checked;

                int maDoan = _svc.DangKy(d, _nguoiDis);
                FormHelper.Info("Đã lưu phiếu đăng ký đoàn. Mã đoàn: " + maDoan);
                LoadData(); ResetForm();
            });
        }

        private void ResetForm()
        {
            FormHelper.ClearInputs(grpThongTin);
            _nguoiDis = new List<NguoiDiDoan>();
            cboTour.SelectedIndex = cboTour.Items.Count > 0 ? 0 : -1;
            FormHelper.SetNum(numSoNguoi, 13);
            dtpNgayDi.Value = DateTime.Today.AddDays(7);
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { ResetForm(); FormHelper.TryRun(LoadData); }
        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
