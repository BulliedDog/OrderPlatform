USE [master]
GO
/****** Object:  Database [OrderPlatformDB]    Script Date: 3/9/2021 6:27:11 PM ******/
CREATE DATABASE [OrderPlatformDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderPlatformDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OrderPlatformDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderPlatformDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OrderPlatformDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OrderPlatformDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderPlatformDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderPlatformDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderPlatformDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderPlatformDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OrderPlatformDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderPlatformDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET RECOVERY FULL 
GO
ALTER DATABASE [OrderPlatformDB] SET  MULTI_USER 
GO
ALTER DATABASE [OrderPlatformDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderPlatformDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderPlatformDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderPlatformDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrderPlatformDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderPlatformDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OrderPlatformDB] SET QUERY_STORE = OFF
GO
USE [OrderPlatformDB]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/9/2021 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[userId] [int] NOT NULL,
	[stateId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/9/2021 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 3/9/2021 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[Id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[total_price] [decimal](18, 2) NOT NULL,
	[orderId] [int] NOT NULL,
	[productId] [int] NOT NULL,
 CONSTRAINT [PK_ProductOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 3/9/2021 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/9/2021 6:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[able] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [date], [userId], [stateId]) VALUES (1, CAST(N'2021-11-03T00:00:00.000' AS DateTime), 2, 3)
INSERT [dbo].[Order] ([Id], [date], [userId], [stateId]) VALUES (2, CAST(N'2021-09-03T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Order] ([Id], [date], [userId], [stateId]) VALUES (3, CAST(N'2021-01-03T00:00:00.000' AS DateTime), 1, 3)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [name]) VALUES (1, N'Active')
INSERT [dbo].[State] ([Id], [name]) VALUES (2, N'Inactive')
INSERT [dbo].[State] ([Id], [name]) VALUES (3, N'On Hold')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [username], [password], [able]) VALUES (1, N'Alberto', N'Alberto1234', 1)
INSERT [dbo].[User] ([Id], [username], [password], [able]) VALUES (2, N'Mario', N'Mario1234', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_able]  DEFAULT ((1)) FOR [able]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_State] FOREIGN KEY([stateId])
REFERENCES [dbo].[State] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_State]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Order]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrder_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [FK_ProductOrder_Product]
GO
USE [master]
GO
ALTER DATABASE [OrderPlatformDB] SET  READ_WRITE 
GO
