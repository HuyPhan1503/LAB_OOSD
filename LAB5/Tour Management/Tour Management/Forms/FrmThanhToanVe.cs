using System;
using System.Data;
using System.Windows.Forms;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmThanhToanVe : Form
    {
        private readonly ThanhToanService _svc = new ThanhToanService();
        private readonly DangKyKhachLeService _dkSvc = new DangKyKhachLeService();
        private readonly DoanKhachService _doanSvc = new DoanKhachService();
        private static readonly string[] Headers = {
            "SoHoaDon", "Số hóa đơn", "LoaiTour", "Loại tour", "SoKhach", "Số khách", "TongTien", "Tổng tiền",
            "DaDatCoc", "Đã cọc", "SoTienThu", "Đã thu", "PhuongThuc", "Phương thức",
            "NgayThanhToan", "Ngày thanh toán", "TrangThai", "Trạng thái" };

        public FrmThanhToanVe() { InitializeComponent(); }

        private void FrmThanhToanVe_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                txtSoHoaDon.ReadOnly = true;
                numSoKhach.ReadOnly = true;
                cboPhuongThuc.SelectedIndex = 0;
                cboLoaiTour.SelectedIndexChanged += (s, ev) => FormHelper.TryRun(FillDoiTuong);
                cboLoaiTour.SelectedIndex = 0;
                FillDoiTuong();
                LoadData();
            });
        }

        private void LoadData() { FormHelper.BindGrid(dgvDanhSach, _svc.GetDanhSachHoaDon(), Headers); }

        /// <summary>Khách lẻ: chọn phiếu đăng ký (MaDK). Khách đoàn: chọn đoàn chưa quyết toán (MaDoan).</summary>
        private void FillDoiTuong()
        {
            if (cboLoaiTour.Text == ThanhToanService.KhachDoan)
            {
                var dt = _doanSvc.GetDanhSach();
                dt.Columns.Add("HienThi", typeof(string), "TenCoQuan + ' - ' + TenTour");
                dt.DefaultView.RowFilter = "TrangThai <> 'Đã quyết toán' AND TrangThai NOT LIKE 'Đã hủy%'";
                FormHelper.BindCombo(cboChuyen, dt.DefaultView, "HienThi", "MaDoan");
            }
            else
            {
                var dt = _dkSvc.GetDanhSach();
                dt.Columns.Add("HienThi", typeof(string), "TenKhach + ' - ' + MaChuyen");
                FormHelper.BindCombo(cboChuyen, dt.DefaultView, "HienThi", "MaDK");
            }
            FormHelper.SetNum(numSoKhach, 0); FormHelper.SetNum(numTongTien, 0);
            FormHelper.SetNum(numDaDatCoc, 0); FormHelper.SetNum(numSoTienThu, 0);
        }

        private int ChonMa()
        {
            if (cboChuyen.SelectedValue == null) throw new NghiepVuException("Chọn phiếu đăng ký / đoàn cần thanh toán.");
            return Convert.ToInt32(cboChuyen.SelectedValue);
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var tt = _svc.TinhTien(cboLoaiTour.Text, ChonMa());
                FormHelper.SetNum(numSoKhach, tt.SoKhach);
                FormHelper.SetNum(numTongTien, tt.TongTien);
                FormHelper.SetNum(numDaDatCoc, cboLoaiTour.Text == ThanhToanService.KhachDoan ? tt.DaDatCoc : 0);
                // khách đoàn: số tiền còn phải trả = tổng - cọc
                FormHelper.SetNum(numSoTienThu, cboLoaiTour.Text == ThanhToanService.KhachDoan ? tt.CanThu : tt.TongTien);
            });
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                int ma = ChonMa();
                if (_svc.DaThanhToan(cboLoaiTour.Text, ma)) throw new NghiepVuException("Phiếu này đã được thanh toán.");
                string so = _svc.ThanhToan(cboLoaiTour.Text, ma, numSoTienThu.Value, cboPhuongThuc.Text);
                txtSoHoaDon.Text = so;
                LoadData();
                FormHelper.Info("Thanh toán thành công.\nSố hóa đơn: " + so);
                if (cboLoaiTour.Text == ThanhToanService.KhachDoan) FillDoiTuong();
            });
        }

        private void btnInBienNhan_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                var hd = _svc.GetBienNhan(txtSoHoaDon.Text.Trim());
                if (hd == null) throw new NghiepVuException("Không tìm thấy hóa đơn. Chọn một dòng trong danh sách hoặc thanh toán trước.");
                MessageBox.Show(
                    "BIÊN NHẬN THANH TOÁN\n\nSố hóa đơn: " + hd.SoHoaDon + "\nLoại: " + hd.LoaiTour
                    + "\nSố khách: " + hd.SoKhach + "\nTổng tiền: " + hd.TongTien.ToString("N0") + " đ"
                    + "\nĐã đặt cọc: " + hd.DaDatCoc.ToString("N0") + " đ"
                    + "\nĐã thu: " + hd.SoTienThu.ToString("N0") + " đ"
                    + "\nPhương thức: " + hd.PhuongThuc + "\nNgày: " + hd.NgayThanhToan.ToString("dd/MM/yyyy HH:mm")
                    + "\nTrạng thái: " + hd.TrangThai,
                    "Biên nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtSoHoaDon.Text = FormHelper.Str(dgvDanhSach.Rows[e.RowIndex], "SoHoaDon");
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
