-- 1. Veritabanını Oluştur
CREATE DATABASE EminERP_DB;
GO

-- 2. Yeni oluşturulan veritabanına geçiş yap
USE EminERP_DB;
GO

-- 3. Users (Kullanıcılar) Tablosunu Oluştur
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(250) NOT NULL,
    Role NVARCHAR(20) DEFAULT 'Staff' -- Varsayılan olarak Staff atanır
);
GO

-- 4. Sistemi test edebilmen için örnek bir Admin hesabı ekle
INSERT INTO Users (Username, Password, Role) 
VALUES ('admin', '123456', 'Admin');
GO