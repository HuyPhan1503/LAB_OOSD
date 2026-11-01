using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyNGK.Data
{
    public static class Db
    {
        public static SqlConnection CreateConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["QuanLyNGK"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
