using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using QuanLyNGK.Data;
using QuanLyNGK.Models;

namespace QuanLyNGK.Services
{
    public class BanHangService
    {
        private readonly BanHangRepository _repo = new BanHangRepository();
        private readonly DanhMucRepository _danhMuc = new DanhMucRepository();
        private readonly NuocGiaiKhatRepository _ngk = new NuocGiaiKhatRepository();

        public List<NuocGiaiKhat> LayDanhSachNGK()
        {
            return _ngk.GetList();
        }

        public ServiceResult LapHoaDon(LapHoaDonRequest rq)
        {
            if (string.IsNullOrWhiteSpace(rq.MaKH))
                return ServiceResult.Fail("Mã khách hàng không được để trống. Vui lòng chọn khách hàng.");
            if (string.IsNullOrWhiteSpace(rq.MaNV))
                return ServiceResult.Fail("Vui lòng chọn nhân viên lập hóa đơn.");
            if (rq.ChiTiet == null || rq.ChiTiet.Count == 0)
                return ServiceResult.Fail("Hóa đơn chưa có mặt hàng nào.");
            if (rq.ChiTiet.Any(c => c.SoLuong <= 0))
                return ServiceResult.Fail("Số lượng mua phải lớn hơn 0.");
            if (rq.ChiTiet.GroupBy(c => c.MaNGK).Any(g => g.Count() > 1))
                return ServiceResult.Fail("Hóa đơn có mặt hàng bị trùng dòng.");

            try
            {
                // Loại khách luôn lấy từ CSDL, không tin dữ liệu từ giao diện
                KhachHang kh = _danhMuc.GetKhachHangById(rq.MaKH);
                if (kh == null) return ServiceResult.Fail("Không tìm thấy khách hàng " + rq.MaKH + ".");

                LapHoaDonKetQua kq = _repo.LapHoaDon(rq, kh.LaKhachQuen);

                string msg = "Lập hóa đơn " + kq.MaHD + " thành công. Tổng tiền: " + kq.TongTien.ToString("N0") + " đ.";
                if (kq.CoPhieuHen) msg += "\nĐã lập Phiếu hẹn giao cho phần hàng còn thiếu.";
                if (kq.SoTienNo > 0) msg += "\nĐã lập Phiếu ghi nợ: " + kq.SoTienNo.ToString("N0") + " đ.";
                return ServiceResult.Ok(msg, kq);
            }
            catch (BusinessException ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
            catch (SqlException ex)
            {
                return ServiceResult.Fail("Lỗi cơ sở dữ liệu, giao dịch đã được hoàn tác: " + ex.Message);
            }
        }
    }
}
