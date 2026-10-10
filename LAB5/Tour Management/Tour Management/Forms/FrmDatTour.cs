using System;
using System.Windows.Forms;
using LAB5.Models;
using LAB5.Services;

namespace LAB5
{
    public partial class FrmDatTour : Form
    {
        private readonly TourService _tourSvc = new TourService();

        public FrmDatTour() { InitializeComponent(); }

        private void FrmDatTour_Load(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                FormHelper.BindCombo(cboTour, _tourSvc.GetAll(), "TenTour", "MaTour");
                cboLoaiKhach.SelectedIndex = 1;
                FormHelper.SetNum(numSoNguoi, 1);
                dtpNgayDi.Value = DateTime.Today.AddDays(7);
                dtpNgayVe.Value = DateTime.Today.AddDays(9);
            });
        }

        /// <summary>Kiểm tra thông tin và phân loại khách theo số người (BR01). Trả về "Khách đoàn" / "Khách lẻ".</summary>
        private string KiemTra()
        {
            var tour = cboTour.SelectedItem as Tour;
            if (tour == null) throw new NghiepVuException("Chọn tour.");
            if (dtpNgayDi.Value.Date < DateTime.Today) throw new NghiepVuException("Ngày đi không được ở quá khứ.");
            if (dtpNgayVe.Value.Date < dtpNgayDi.Value.Date) throw new NghiepVuException("Ngày về phải sau hoặc bằng ngày đi.");
            string loai = DoanKhachService.PhanLoai((int)numSoNguoi.Value);   // ném lỗi nếu đúng 12 người
            cboLoaiKhach.SelectedIndex = loai == "Khách đoàn" ? 0 : 1;
            return loai;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                string loai = KiemTra();
                var tour = (Tour)cboTour.SelectedItem;
                decimal tam = tour.DonGia * numSoNguoi.Value;
                FormHelper.Info(loai + " - tour \"" + tour.TenTour + "\"\nSố người: " + numSoNguoi.Value
                    + "\nChi phí dự kiến: " + tam.ToString("N0") + " đ"
                    + (loai == "Khách đoàn" ? "\nKhách đoàn phải đặt cọc trước; quyết toán sau khi kết thúc chuyến." : "\nKhách lẻ đăng ký theo chuyến và thanh toán tiền vé."));
            });
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            FormHelper.TryRun(() =>
            {
                string loai = KiemTra();
                var tour = (Tour)cboTour.SelectedItem;
                if (loai == "Khách đoàn")
                    new FrmDangKyDoan(tour.MaTour, dtpNgayDi.Value.Date, (int)numSoNguoi.Value).ShowDialog();
                else
                    new FrmDangKyKhachLe(tour.MaTour, dtpNgayDi.Value.Date).ShowDialog();
            });
        }

        private void btnDong_Click(object sender, EventArgs e) { Close(); }
    }
}
