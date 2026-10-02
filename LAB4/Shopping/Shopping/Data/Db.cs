using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace Shopping.Data
{
    public static class Db
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["eShoppingDb"].ConnectionString; }
        }

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection cn = new MySqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        // SELECT nhieu dong -> DataTable (gan truc tiep cho DataGridView / ComboBox)
        public static DataTable Query(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection cn = OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        // INSERT / UPDATE / DELETE -> so dong bi anh huong
        public static int Execute(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection cn = OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Lay 1 gia tri (COUNT, SUM, LAST_INSERT_ID...)
        public static object Scalar(string sql, params MySqlParameter[] parameters)
        {
            using (MySqlConnection cn = OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
            {
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        // Goi stored procedure tra ve DataTable (vd: sp_DatHang tra ve MaDonHang)
        public static DataTable QueryProc(string procName, params MySqlParameter[] parameters)
        {
            using (MySqlConnection cn = OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(procName, cn))
            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        // Goi stored procedure khong can ket qua (vd: sp_ThemVaoGio)
        public static int ExecuteProc(string procName, params MySqlParameter[] parameters)
        {
            using (MySqlConnection cn = OpenConnection())
            using (MySqlCommand cmd = new MySqlCommand(procName, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        // Tao MySqlParameter, tu doi null thanh DBNull de tranh loi
        public static MySqlParameter P(string name, object value)
        {
            return new MySqlParameter(name, value ?? DBNull.Value);
        }
    }
}