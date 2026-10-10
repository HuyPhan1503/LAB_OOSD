using System;
using System.Data;
using MySql.Data.MySqlClient; 

namespace LAB5.Services
{
    /// <summary>Lỗi nghiệp vụ (hiển thị thẳng cho người dùng bằng MessageBox).</summary>
    public class NghiepVuException : Exception
    {
        public NghiepVuException(string message) : base(message) { }
    }

    internal static class Sql
    {
        public static MySqlParameter P(string name, object value)
        {
            return new MySqlParameter(name, value ?? DBNull.Value);
        }
    }

    /// <summary>Hàm hỗ trợ đọc DataRow -> kiểu C# (xử lý DBNull).</summary>
    internal static class RowExt
    {
        private static bool IsNull(DataRow r, string c)
        {
            return !r.Table.Columns.Contains(c) || r[c] == DBNull.Value;
        }
        public static string Str(this DataRow r, string c) { return IsNull(r, c) ? null : Convert.ToString(r[c]); }
        public static int Int(this DataRow r, string c) { return IsNull(r, c) ? 0 : Convert.ToInt32(r[c]); }
        public static int? IntN(this DataRow r, string c) { return IsNull(r, c) ? (int?)null : Convert.ToInt32(r[c]); }
        public static byte? ByteN(this DataRow r, string c) { return IsNull(r, c) ? (byte?)null : Convert.ToByte(r[c]); }
        public static decimal Dec(this DataRow r, string c) { return IsNull(r, c) ? 0m : Convert.ToDecimal(r[c]); }
        public static bool Bool(this DataRow r, string c) { return !IsNull(r, c) && Convert.ToBoolean(r[c]); }
        public static DateTime Date(this DataRow r, string c) { return IsNull(r, c) ? DateTime.MinValue : Convert.ToDateTime(r[c]); }
    }
}