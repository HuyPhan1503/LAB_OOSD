using System.Data;
using System.Data.SqlClient;
using QuanLyNGK.Data;
using QuanLyNGK.Models;

namespace QuanLyNGK.Services
{
    public class NuocGiaiKhatService
    {
        private readonly NuocGiaiKhatRepository _repo = new NuocGiaiKhatRepository();

        public DataTable TimKiem(string keyword)
        {
            return _repo.GetAll(keyword);
        }

        public System.Collections.Generic.List<NuocGiaiKhat> LayDanhSach()
        {
            return _repo.GetList();
        }

        public ServiceResult Them(NuocGiaiKhat n)
        {
            string loi = KiemTra(n);
            if (loi != null) return ServiceResult.Fail(loi);
            try
            {
                if (_repo.Exists(n.MaNGK))
                    return ServiceResult.Fail("Mã NGK '" + n.MaNGK + "' đã tồn tại.");
                _repo.Insert(n);
                return ServiceResult.Ok("Thêm nước giải khát '" + n.TenNGK + "' thành công.");
            }
            catch (SqlException ex)
            {
                return ServiceResult.Fail("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public ServiceResult Sua(NuocGiaiKhat n)
        {
            string loi = KiemTra(n);
            if (loi != null) return ServiceResult.Fail(loi);
            try
            {
                int rows = _repo.Update(n);
                if (rows == 0) return ServiceResult.Fail("Không tìm thấy NGK '" + n.MaNGK + "' để cập nhật.");
                return ServiceResult.Ok("Cập nhật nước giải khát '" + n.MaNGK + "' thành công.");
            }
            catch (SqlException ex)
            {
                return ServiceResult.Fail("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public ServiceResult Xoa(string maNGK)
        {
            if (string.IsNullOrWhiteSpace(maNGK))
                return ServiceResult.Fail("Vui lòng chọn nước giải khát cần xóa.");
            try
            {
                int rows = _repo.Delete(maNGK);
                if (rows == 0) return ServiceResult.Fail("Không tìm thấy NGK '" + maNGK + "'.");
                return ServiceResult.Ok("Đã xóa nước giải khát '" + maNGK + "'.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // vi phạm khóa ngoại
                    return ServiceResult.Fail("Không thể xóa: NGK '" + maNGK +
                        "' đã phát sinh giao dịch (đơn đặt hàng, phiếu giao, hóa đơn...).");
                return ServiceResult.Fail("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        private static string KiemTra(NuocGiaiKhat n)
        {
            if (string.IsNullOrWhiteSpace(n.MaNGK)) return "Mã NGK không được để trống.";
            if (n.MaNGK.Length > 10) return "Mã NGK tối đa 10 ký tự.";
            if (string.IsNullOrWhiteSpace(n.TenNGK)) return "Tên NGK không được để trống.";
            if (n.TenNGK.Length > 100) return "Tên NGK tối đa 100 ký tự.";
            if (string.IsNullOrWhiteSpace(n.DonViTinh)) return "Vui lòng chọn đơn vị tính.";
            if (string.IsNullOrWhiteSpace(n.MaLoai)) return "Vui lòng chọn nhãn hiệu.";
            if (string.IsNullOrWhiteSpace(n.MaNCU)) return "Vui lòng chọn nhà cung ứng (Mã NCC không được để trống).";
            if (n.SoLuongTon < 0) return "Số lượng tồn không được âm.";
            if (n.DonGiaBan <= 0) return "Đơn giá bán phải lớn hơn 0.";
            return null;
        }
    }
}
