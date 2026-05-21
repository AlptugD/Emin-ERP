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


                    SqlCommand checkProductsTableCmd = new SqlCommand("SELECT OBJECT_ID(N'EminERP_DB.dbo.Products', N'U')", conn);
                    var productsTableId = checkProductsTableCmd.ExecuteScalar();
                    if (productsTableId == null || productsTableId == DBNull.Value)
                    {
                        string createProductsTableSql = @"
                            CREATE TABLE Products (
                                Id INT PRIMARY KEY IDENTITY(1,1),
                                Name NVARCHAR(150) UNIQUE NOT NULL,
                                Brand NVARCHAR(100) NOT NULL,
                                Price DECIMAL(18,2) NOT NULL,
                                Category NVARCHAR(100) NOT NULL,
                                ImageFileName NVARCHAR(150) NOT NULL,
                                PrimaryColorArgb INT NOT NULL,
                                Stock INT NOT NULL DEFAULT 0
                            );
                        ";
                        SqlCommand createProductsTableCmd = new SqlCommand(createProductsTableSql, conn);
                        createProductsTableCmd.ExecuteNonQuery();
                    }


                    SqlCommand countProductsCmd = new SqlCommand("SELECT COUNT(*) FROM Products", conn);
                    int productCount = (int)countProductsCmd.ExecuteScalar();
                    if (productCount == 0)
                    {
                        string seedProductsSql = @"
                            INSERT INTO Products (Name, Brand, Price, Category, ImageFileName, PrimaryColorArgb, Stock)
                            VALUES
                            (N'Mavi Premium Kablosuz Kulaklık', N'ProCompute', 3499.00, N'Kablosuz Kulaklıklar', N'blue_headphones.png', -10579516, 10),
                            (N'Taşınabilir Oyun Konsolu', N'PlayAnywhere', 12999.00, N'Masaüstü Bilgisayarlar', N'white_controller.png', -2305818, 5),
                            (N'Çiçek Desenli Tablet Kılıfı', N'SkinArt', 699.00, N'Kılıflar & Ekran Koruyucular', N'tablet_case.png', -991433, 0),
                            (N'Lavanta Rengi Kablosuz Kulaklık', N'SonicWave', 1999.00, N'Kablosuz Kulaklıklar', N'lavender_headphones.png', -2635541, 8),
                            (N'White Graphic Crop Top', N'woden''s Brand', 449.00, N'Telefon Aksesuarları', N'white_crop_top.png', -1318928, 0),
                            (N'Black Shorts', N'MM''s Brand', 549.00, N'Dizüstü Bilgisayarlar', N'black_shorts.png', -1644826, 15);
                        ";
                        SqlCommand seedProductsCmd = new SqlCommand(seedProductsSql, conn);
                        seedProductsCmd.ExecuteNonQuery();
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