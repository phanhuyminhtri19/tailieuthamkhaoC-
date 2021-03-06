USE [master]
GO
/****** Object:  Database [saleDB]    Script Date: 10/14/2018 2:23:35 PM ******/
CREATE DATABASE [saleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'saleDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\saleDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'saleDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\saleDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [saleDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [saleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [saleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [saleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [saleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [saleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [saleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [saleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [saleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [saleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [saleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [saleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [saleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [saleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [saleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [saleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [saleDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [saleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [saleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [saleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [saleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [saleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [saleDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [saleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [saleDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [saleDB] SET  MULTI_USER 
GO
ALTER DATABASE [saleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [saleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [saleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [saleDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [saleDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [saleDB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[UnitPrice] [float] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Fullname] [nvarchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice], [Quantity]) VALUES (5, N'2', 1231, 123)
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice], [Quantity]) VALUES (9, N'123', 123, 41)
INSERT [dbo].[Products] ([ProductId], [ProductName], [UnitPrice], [Quantity]) VALUES (10, N'Tai oi la tai', 123, 456)
SET IDENTITY_INSERT [dbo].[Products] OFF
INSERT [dbo].[tbl_User] ([Username], [Password], [Fullname], [IsAdmin]) VALUES (N'user1', N'123456', N'Phat Faker', 1)
INSERT [dbo].[tbl_User] ([Username], [Password], [Fullname], [IsAdmin]) VALUES (N'user2', N'123456', N'Faker Phat', 0)
/****** Object:  StoredProcedure [dbo].[AddOrUpdate]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[AddOrUpdate]
@ProductId int,
@ProductName nvarchar(50),
@UnitPrice float,
@Quantity int
AS
begin
if(@ProductId=0)
begin

    insert into Products
    (
    ProductName,UnitPrice,Quantity
    )
    VALUES
    (
    @ProductName,@UnitPrice,@Quantity
    )

end
else
begin
update Products set
ProductName=@ProductName,
UnitPrice = @UnitPrice,
Quantity=@Quantity where ProductId=@ProductId
end
end
GO
/****** Object:  StoredProcedure [dbo].[DeleteById]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteById]
@ProductId int
AS BEGIN delete from Products where @ProductId = ProductId
end

GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Login]
@Username nvarchar(50),
@Password nvarchar(50)
as
begin
select * from tbl_User where Username = @Username and Password = @Password
end
GO
/****** Object:  StoredProcedure [dbo].[SearchById]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SearchById]
@Id int
AS 
BEGIN
Select * from saleDB.dbo.Products where ProductId=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[ViewAllOrSearch]    Script Date: 10/14/2018 2:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ViewAllOrSearch]
@txtSearch nvarchar(50)
AS BEGIN
SELECT * 
FROM Products where @txtSearch='' or ProductName like '%' + @txtSearch +'%'
end
GO
USE [master]
GO
ALTER DATABASE [saleDB] SET  READ_WRITE 
GO
