USE [master]
GO
/****** Object:  Database [BookDB]    Script Date: 23/10/2018 20:07:47 ******/
CREATE DATABASE [BookDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SANGTSE62863\MSSQL\DATA\BookDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SANGTSE62863\MSSQL\DATA\BookDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookDB] SET  MULTI_USER 
GO
ALTER DATABASE [BookDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookDB', N'ON'
GO
USE [BookDB]
GO
/****** Object:  Table [dbo].[tbl_Book]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](50) NULL,
	[BookPrice] [float] NULL,
 CONSTRAINT [PK_tbl_Book] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[AddOrEdit]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddOrEdit]
@BookId int,
@BookName nvarchar(50),
@BookPrice float
AS
BEGIN
if(@BookId=0)
begin
 insert into tbl_Book (BookName,BookPrice) values(@BookName,@BookPrice)  
end
else
begin
update tbl_Book set BookName=@BookName,BookPrice=@BookPrice where BookId=@BookId
end
END


GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditUser]
@Username nvarchar(50),
@Password nvarchar(50)
AS
BEGIN
update tbl_User set Password=@Password where Username=@Username
END

GO
/****** Object:  StoredProcedure [dbo].[LoadBookPrice]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[LoadBookPrice]
AS
BEGIN
select * from tbl_Book order by tbl_Book.BookPrice DESC
END

GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Login]
@Username nvarchar(50),
@Password nvarchar(50)
AS
BEGIN
SELECT * FROM tbl_User where Username=@Username and Password=@Password
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveBook]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RemoveBook]
@BookId int
AS
BEGIN
DELETE from tbl_Book where BookId=@BookId
END

GO
/****** Object:  StoredProcedure [dbo].[ViewAllOrSearch]    Script Date: 23/10/2018 20:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ViewAllOrSearch]
@txtSearch nvarchar(50)
AS
BEGIN
select * from tbl_Book where @txtSearch='' or  BookName like '%' + @txtSearch +'%'
END

GO
USE [master]
GO
ALTER DATABASE [BookDB] SET  READ_WRITE 
GO
