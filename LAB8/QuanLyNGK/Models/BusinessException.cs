using System;

namespace QuanLyNGK.Models
{
    /// <summary>Lỗi vi phạm quy tắc nghiệp vụ (hiển thị trực tiếp cho người dùng).</summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
