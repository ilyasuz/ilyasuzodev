USE [master]
GO
/****** Object:  Database [ILYASUZ]    Script Date: 07.12.2023 14:36:41 ******/
CREATE DATABASE [ILYASUZ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ILYASUZ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ILYASUZ.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ILYASUZ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ILYASUZ_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ILYASUZ] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ILYASUZ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ILYASUZ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ILYASUZ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ILYASUZ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ILYASUZ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ILYASUZ] SET ARITHABORT OFF 
GO
ALTER DATABASE [ILYASUZ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ILYASUZ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ILYASUZ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ILYASUZ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ILYASUZ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ILYASUZ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ILYASUZ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ILYASUZ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ILYASUZ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ILYASUZ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ILYASUZ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ILYASUZ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ILYASUZ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ILYASUZ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ILYASUZ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ILYASUZ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ILYASUZ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ILYASUZ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ILYASUZ] SET  MULTI_USER 
GO
ALTER DATABASE [ILYASUZ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ILYASUZ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ILYASUZ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ILYASUZ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ILYASUZ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ILYASUZ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ILYASUZ] SET QUERY_STORE = ON
GO
ALTER DATABASE [ILYASUZ] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ILYASUZ]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_CategoryTable] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Stock] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Kırtasiye')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'teknoloji')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Stock], [Price], [CategoryId]) VALUES (1, N'asd', 1234123, CAST(1234 AS Decimal(18, 0)), 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Stock], [Price], [CategoryId]) VALUES (2, N'kalem', 2, CAST(2 AS Decimal(18, 0)), 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Stock], [Price], [CategoryId]) VALUES (3, N'12', 123, CAST(1243 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Password]) VALUES (1, N'admin', N'deneme')
INSERT [dbo].[Users] ([UserId], [UserName], [Password]) VALUES (2, N'ilyasuz', N'1')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCategory]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCategory]
    @CategoryId INT
AS
BEGIN
    DELETE FROM Categories WHERE CategoryId = @CategoryId;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct]
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @UserId INT
AS
BEGIN
    DELETE FROM Users WHERE UserId = @UserId;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCategories]
AS
BEGIN
    SELECT CategoryId, CategoryName FROM Categories;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllProducts]
AS
BEGIN
    SELECT *
    FROM Products;
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SELECT UserId, UserName, Password FROM Users;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetProductById]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductById]
    @ProductId INT
AS
BEGIN
    SELECT *
    FROM Products
    WHERE ProductId = @ProductId;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCategory]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCategory]
    @CategoryName NVARCHAR(255)
AS
BEGIN
    INSERT INTO Categories (CategoryName) VALUES (@CategoryName);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertProduct]
    @ProductName NVARCHAR(100),
    @Stock INT,
    @Price DECIMAL(18, 2),
    @CategoryId INT
AS
BEGIN
    INSERT INTO Products(ProductName, Stock, Price, CategoryId)
    VALUES (@ProductName, @Stock, @Price, @CategoryId);
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
    @UserName NVARCHAR(255),
    @Password NVARCHAR(255)
AS
BEGIN
    INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password);
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateCategory]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCategory]
    @CategoryId INT,
    @CategoryName NVARCHAR(255)
AS
BEGIN
    UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
    @ProductId INT,
    @ProductName NVARCHAR(100),
    @Stock INT,
    @Price DECIMAL(18, 2),
    @CategoryId INT
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Stock = @Stock,
        Price = @Price,
        CategoryId = @CategoryId
    WHERE ProductId = @ProductId;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 07.12.2023 14:36:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
    @UserId INT,
    @UserName NVARCHAR(255),
    @Password NVARCHAR(255)
AS
BEGIN
    UPDATE Users SET UserName = @UserName, Password = @Password WHERE UserId = @UserId;
END;
GO
USE [master]
GO
ALTER DATABASE [ILYASUZ] SET  READ_WRITE 
GO
