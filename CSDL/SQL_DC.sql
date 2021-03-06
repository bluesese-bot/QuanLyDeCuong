USE [master]
GO
/****** Object:  Database [QuanLyDeCuong]    Script Date: 6/14/2021 3:02:08 PM ******/
CREATE DATABASE [QuanLyDeCuong]
GO
ALTER DATABASE [QuanLyDeCuong] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyDeCuong].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyDeCuong] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyDeCuong] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyDeCuong] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyDeCuong] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyDeCuong] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyDeCuong] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyDeCuong] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyDeCuong] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyDeCuong] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyDeCuong] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyDeCuong] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyDeCuong', N'ON'
GO
USE [QuanLyDeCuong]
GO
/****** Object:  Table [dbo].[DeCuong]    Script Date: 6/14/2021 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeCuong](
	[MaDeCuong] [nvarchar](10) NOT NULL,
	[TenDeCuong] [nvarchar](50) NULL,
	[TenHocPhan] [nvarchar](50) NULL,
	[TomTat] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[SoTinChi] [nvarchar](50) NULL,
	[TaiLieuThamKhao] [nvarchar](50) NULL,
	[MaGiaoVien] [nvarchar](10) NULL,
	[MaKhoa] [nvarchar](10) NULL,
 CONSTRAINT [PK_DeCuong] PRIMARY KEY CLUSTERED 
(
	[MaDeCuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 6/14/2021 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGiaoVien] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[MaKhoa] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGiaoVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 6/14/2021 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [nvarchar](10) NOT NULL,
	[TenKhoa] [nvarchar](50) NOT NULL,
	[DienThoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/14/2021 3:02:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[magv] [nvarchar](50) NULL,
	[loaitk] [nvarchar](50) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[DeCuong] ([MaDeCuong], [TenDeCuong], [TenHocPhan], [TomTat], [NoiDung], [SoTinChi], [TaiLieuThamKhao], [MaGiaoVien], [MaKhoa]) VALUES (N'01', N'Cơ Sở Dữ Liệu', N'CSDL', N'Tìm hiểu Về CSDL 1', N'Chúng ta phải hiểu rằng tất cả.', N'03', N'Cập Nhập 1', N'01', N'cntt')
INSERT [dbo].[GiaoVien] ([MaGiaoVien], [HoTen], [SDT], [MaKhoa]) VALUES (N'01', N'LeuQuangHuy', N'09434223', N'cntt')
INSERT [dbo].[GiaoVien] ([MaGiaoVien], [HoTen], [SDT], [MaKhoa]) VALUES (N'02', N'Lê Thu Hà', N'08432121', N'cntt')
INSERT [dbo].[GiaoVien] ([MaGiaoVien], [HoTen], [SDT], [MaKhoa]) VALUES (N'03', N'TranVanMinh', N'05429323', N'mm')
INSERT [dbo].[GiaoVien] ([MaGiaoVien], [HoTen], [SDT], [MaKhoa]) VALUES (N'04', N'NguyenDinhKhang', N'05402344', N'kt')
INSERT [dbo].[GiaoVien] ([MaGiaoVien], [HoTen], [SDT], [MaKhoa]) VALUES (N'05', N'LaPhuongNam', N'09434232', N'ck')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [DienThoai]) VALUES (N'ck', N'CoKhi', N'09382623')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [DienThoai]) VALUES (N'cntt', N'CongNgheThongTin', N'09372842')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [DienThoai]) VALUES (N'kt', N'KeToan', N'03829746')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [DienThoai]) VALUES (N'mm', N'MayMac', N'08274231')
INSERT [dbo].[TaiKhoan] ([username], [password], [magv], [loaitk]) VALUES (N'admin', N'admin', N'01', N'Admin')
ALTER TABLE [dbo].[DeCuong]  WITH CHECK ADD  CONSTRAINT [FK_DeCuong_GiaoVien] FOREIGN KEY([MaGiaoVien])
REFERENCES [dbo].[GiaoVien] ([MaGiaoVien])
GO
ALTER TABLE [dbo].[DeCuong] CHECK CONSTRAINT [FK_DeCuong_GiaoVien]
GO
ALTER TABLE [dbo].[DeCuong]  WITH CHECK ADD  CONSTRAINT [FK_DeCuong_Khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[DeCuong] CHECK CONSTRAINT [FK_DeCuong_Khoa]
GO
USE [master]
GO
ALTER DATABASE [QuanLyDeCuong] SET  READ_WRITE 
GO
