
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LAB07.Data
{
    public static class Db
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["QL_NhanSu"]?.ConnectionString;

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new InvalidOperationException(
                    "Không tìm thấy connection string 'QL_NhanSu' trong App.config."
                );
            }

            return new SqlConnection(ConnectionString);
        }

        // Mở kết nối và trả về kết nối đã mở.
        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = GetConnection();

            try
            {
                connection.Open();
                return connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }

        // Truy vấn SELECT trả về DataTable.
        public static DataTable Query(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection connection = OpenConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        // INSERT, UPDATE, DELETE.
        public static int Execute(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection connection = OpenConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                return command.ExecuteNonQuery();
            }
        }

        // SELECT COUNT, SUM hoặc truy vấn một giá trị.
        public static object Scalar(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection connection = OpenConnection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                return command.ExecuteScalar();
            }
        }

        // Tạo tham số SQL có kiểu dữ liệu rõ ràng.
        public static SqlParameter Param(
            string name,
            SqlDbType type,
            object value)
        {
            return new SqlParameter(name, type)
            {
                Value = value ?? DBNull.Value
            };
        }

        // Tạo tham số decimal với độ chính xác phù hợp.
        public static SqlParameter DecimalParam(
            string name,
            decimal value)
        {
            SqlParameter parameter =
                new SqlParameter(name, SqlDbType.Decimal);

            parameter.Precision = 18;
            parameter.Scale = 2;
            parameter.Value = value;

            return parameter;
        }
    }
}
