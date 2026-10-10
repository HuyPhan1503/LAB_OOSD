using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using LAB5.Models;
using LAB5.Services;
using System.Data.SqlClient;

namespace LAB5.Data
{
    public static class Db
    {
        public static string ConnectionString
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["QuanLyTour"];
                if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                {
                    throw new ConfigurationErrorsException("Connection string 'QuanLyTour' not found in App.config. Please add it to the project's App.config and set correct server/database credentials.");
                }
                return cs.ConnectionString;
            }
        }

        public static MySqlConnection OpenConnection()
        {
            var cn = new MySqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static DataTable Query(string sql, params MySqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new MySqlCommand(sql, cn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string sql, params MySqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new MySqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params MySqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new MySqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }
    }
}