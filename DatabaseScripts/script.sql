USE [master]
GO
/****** Object:  Database [DotNetChallangeDb]    Script Date: 2.11.2024 16:55:53 ******/
CREATE DATABASE [DotNetChallangeDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotNetChallangeDb', FILENAME = N'F:\Program Files\MSSQL16.SQLEXPRESS\MSSQL\DATA\DotNetChallangeDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetChallangeDb_log', FILENAME = N'F:\Program Files\MSSQL16.SQLEXPRESS\MSSQL\DATA\DotNetChallangeDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DotNetChallangeDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetChallangeDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNetChallangeDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DotNetChallangeDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNetChallangeDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNetChallangeDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DotNetChallangeDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNetChallangeDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DotNetChallangeDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DotNetChallangeDb] SET  MULTI_USER 
GO
ALTER DATABASE [DotNetChallangeDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNetChallangeDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DotNetChallangeDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DotNetChallangeDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DotNetChallangeDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DotNetChallangeDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DotNetChallangeDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [DotNetChallangeDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DotNetChallangeDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2.11.2024 16:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrier]    Script Date: 2.11.2024 16:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](max) NOT NULL,
	[CarrierIsActive] [bit] NOT NULL,
	[CarrierPlusDesiCost] [int] NOT NULL,
	[CarrierConfigurationId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Carrier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarrierConfigurations]    Script Date: 2.11.2024 16:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierConfigurations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierMaxDesi] [int] NOT NULL,
	[CarrierMinDesi] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2.11.2024 16:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDesi] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderCarrierCost] [decimal](18, 2) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UpdatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_CarrierConfigurations_CarrierId]    Script Date: 2.11.2024 16:55:53 ******/
CREATE NONCLUSTERED INDEX [IX_CarrierConfigurations_CarrierId] ON [dbo].[CarrierConfigurations]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_CarrierId]    Script Date: 2.11.2024 16:55:54 ******/
CREATE NONCLUSTERED INDEX [IX_Order_CarrierId] ON [dbo].[Order]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrier] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[CarrierConfigurations] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdatedDate]
GO
ALTER TABLE [dbo].[CarrierConfigurations]  WITH CHECK ADD  CONSTRAINT [FK_CarrierConfigurations_Carrier_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carrier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarrierConfigurations] CHECK CONSTRAINT [FK_CarrierConfigurations_Carrier_CarrierId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Carrier_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carrier] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Carrier_CarrierId]
GO
USE [master]
GO
ALTER DATABASE [DotNetChallangeDb] SET  READ_WRITE 
GO
