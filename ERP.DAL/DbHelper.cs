using Microsoft.Data.SqlClient;
namespace ERP.DAL
{
    public static class DbHelper
    {
        public static string ConnectionString = @"Server=AD\SQLEXPRESS;Database=EminERP_DB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}