using Microsoft.Data.SqlClient;
using System;

namespace ERP.DAL
{
    public static class DbHelper
    {
        public static string ConnectionString = @"Server=AD\SQLEXPRESS;Database=EminERP_DB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static void EnsureDatabaseAndTableCreated()
        {
            string masterConnStr = ConnectionString.Replace("Database=EminERP_DB;", "Database=master;").Replace("Database=EminERP_DB", "Database=master");

            try
            {
                using (SqlConnection masterConn = new SqlConnection(masterConnStr))
                {
                    masterConn.Open();
                    SqlCommand checkDbCmd = new SqlCommand("SELECT database_id FROM sys.databases WHERE name = 'EminERP_DB'", masterConn);
                    var dbId = checkDbCmd.ExecuteScalar();
                    if (dbId == null || dbId == DBNull.Value)
                    {
                        SqlCommand createDbCmd = new SqlCommand("CREATE DATABASE EminERP_DB", masterConn);
                        createDbCmd.ExecuteNonQuery();
                    }
                }

                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand checkTableCmd = new SqlCommand("SELECT OBJECT_ID(N'EminERP_DB.dbo.Users', N'U')", conn);
                    var tableId = checkTableCmd.ExecuteScalar();
                    if (tableId == null || tableId == DBNull.Value)
                    {
                        string createTableSql = @"
                            CREATE TABLE Users (
                                Id INT PRIMARY KEY IDENTITY(1,1),
                                Username NVARCHAR(50) UNIQUE NOT NULL,
                                Password NVARCHAR(250) NOT NULL,
                                Role NVARCHAR(20) DEFAULT 'Staff'
                            );
                            
                            IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'admin')
                            BEGIN
                                INSERT INTO Users (Username, Password, Role) 
                                VALUES ('admin', '123456', 'Admin');
                            END;
                        ";
                        SqlCommand createTableCmd = new SqlCommand(createTableSql, conn);
                        createTableCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanı veya Tablo otomatik oluşturulamadı! Detay: " + ex.Message, ex);
            }
        }
    }
}