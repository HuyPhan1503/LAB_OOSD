using System;
using Shopping.Models;

namespace Shopping.Services
{
    /// <summary>
    /// Quản lý phiên đăng nhập của ứng dụng.
    /// </summary>
    public static class PhienService
    {
        private static KhachHang _khachHienTai;

        public static KhachHang KhachHienTai
        {
            get => _khachHienTai;
            set
            {
                if (ReferenceEquals(_khachHienTai, value))
                    return;

                _khachHienTai = value;
                SessionChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static bool DaDangNhap => KhachHienTai != null;

        public static event EventHandler SessionChanged;
    }
}