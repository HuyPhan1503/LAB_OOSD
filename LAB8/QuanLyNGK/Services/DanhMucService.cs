using System.Collections.Generic;
using QuanLyNGK.Data;
using QuanLyNGK.Models;

namespace QuanLyNGK.Services
{
    public class DanhMucService
    {
        private readonly DanhMucRepository _repo = new DanhMucRepository();

        public List<NhanHieu> LayNhanHieu() { return _repo.GetNhanHieu(); }
        public List<NhaCungUng> LayNhaCungUng() { return _repo.GetNhaCungUng(); }
        public List<NhanVien> LayNhanVien() { return _repo.GetNhanVien(); }
        public List<KhachHang> LayKhachHang() { return _repo.GetKhachHang(); }
    }
}
