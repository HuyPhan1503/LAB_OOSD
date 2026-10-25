using System;
using System.Data;
using System.Data.SqlClient;

namespace QL_KhamBenh
{
    /// <summary>
    /// Lop truy cap CSDL QL_KhamBenh (SQL Server).
    /// Dung System.Data.SqlClient (co san trong .NET Framework).
    /// Neu dung .NET 6+ co the cai NuGet System.Data.SqlClient hoac doi sang Microsoft.Data.SqlClient.
    /// </summary>
    public static class Db
    {
        // Sua Server cho phu hop voi may cua ban.
        public static string ConnectionString { get; set; } =
    @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=QL_KhamBenh;Integrated Security=True;TrustServerCertificate=True;";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>Kiem tra ket noi CSDL.</summary>
        public static bool TestConnection(out string error)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                }

                error = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>Tao tham so SQL, null duoc doi thanh DBNull.Value.</summary>
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>SELECT -> DataTable.</summary>
        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        /// <summary>INSERT / UPDATE / DELETE -> so dong bi anh huong.</summary>
        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Tra ve gia tri dau tien (null/DBNull -> default(T)).</summary>
        public static T Scalar<T>(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return default(T);

                Type targetType =
                    Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

                return (T)Convert.ChangeType(result, targetType);
            }
        }

        /// <summary>INSERT va tra ve ID vua tao.</summary>
        public static int Insert(string sql, params SqlParameter[] parameters)
        {
            return Scalar<int>(
                sql + "; SELECT CAST(SCOPE_IDENTITY() AS INT);",
                parameters
            );
        }

        /// <summary>Thuc hien nhieu lenh trong mot transaction.</summary>
        public static void RunInTransaction(
            Action<SqlConnection, SqlTransaction> work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        work(conn, tran);
                        tran.Commit();
                    }
                    catch
                    {
                        try
                        {
                            tran.Rollback();
                        }
                        catch
                        {
                            // Giu lai loi goc neu rollback that bai.
                        }

                        throw;
                    }
                }
            }
        }

        /// <summary>Tao SqlCommand gan voi transaction hien tai.</summary>
        public static SqlCommand Cmd(
            SqlConnection conn,
            SqlTransaction tran,
            string sql,
            params SqlParameter[] parameters)
        {
            var cmd = new SqlCommand(sql, conn, tran);

            if (parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            return cmd;
        }
    }
}