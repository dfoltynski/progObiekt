USE [master]
GO
/****** Object:  Database [agregator]    Script Date: 30/06/2022 02:15:27 ******/
CREATE DATABASE [agregator]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'agregator', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\agregator.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'agregator_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\agregator_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [agregator] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [agregator].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [agregator] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [agregator] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [agregator] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [agregator] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [agregator] SET ARITHABORT OFF 
GO
ALTER DATABASE [agregator] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [agregator] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [agregator] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [agregator] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [agregator] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [agregator] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [agregator] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [agregator] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [agregator] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [agregator] SET  ENABLE_BROKER 
GO
ALTER DATABASE [agregator] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [agregator] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [agregator] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [agregator] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [agregator] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [agregator] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [agregator] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [agregator] SET RECOVERY FULL 
GO
ALTER DATABASE [agregator] SET  MULTI_USER 
GO
ALTER DATABASE [agregator] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [agregator] SET DB_CHAINING OFF 
GO
ALTER DATABASE [agregator] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [agregator] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [agregator] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [agregator] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'agregator', N'ON'
GO
ALTER DATABASE [agregator] SET QUERY_STORE = OFF
GO
USE [agregator]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 30/06/2022 02:15:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[company_name] [nchar](128) NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 30/06/2022 02:15:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](32) NULL,
	[last_name] [nchar](64) NULL,
	[role] [int] NOT NULL,
	[company] [int] NOT NULL,
	[manager] [int] NULL,
 CONSTRAINT [PK_employees_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[managers]    Script Date: 30/06/2022 02:15:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[managers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](16) NULL,
	[last_name] [nchar](32) NULL,
 CONSTRAINT [PK_managers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 30/06/2022 02:15:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nchar](32) NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[companies] ON 
GO
INSERT [dbo].[companies] ([id], [company_name]) VALUES (1, N'IBM                                                                                                                             ')
GO
INSERT [dbo].[companies] ([id], [company_name]) VALUES (2, N'Kyndryl                                                                                                                         ')
GO
INSERT [dbo].[companies] ([id], [company_name]) VALUES (3, N'Atos                                                                                                                            ')
GO
INSERT [dbo].[companies] ([id], [company_name]) VALUES (4, N'Comarch                                                                                                                         ')
GO
INSERT [dbo].[companies] ([id], [company_name]) VALUES (5, N'Box Inc.                                                                                                                        ')
GO
INSERT [dbo].[companies] ([id], [company_name]) VALUES (6, N'Apple                                                                                                                           ')
GO
SET IDENTITY_INSERT [dbo].[companies] OFF
GO
SET IDENTITY_INSERT [dbo].[employees] ON 
GO
INSERT [dbo].[employees] ([id], [name], [last_name], [role], [company], [manager]) VALUES (10, N'Dawid                           ', N'Foltyński                                                       ', 1, 1, 2)
GO
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
SET IDENTITY_INSERT [dbo].[managers] ON 
GO
INSERT [dbo].[managers] ([id], [name], [last_name]) VALUES (1, N'Zygmunt         ', N'Jaropelk                        ')
GO
INSERT [dbo].[managers] ([id], [name], [last_name]) VALUES (2, N'Samanta         ', N'Mscislaw                        ')
GO
INSERT [dbo].[managers] ([id], [name], [last_name]) VALUES (3, N'Pawel           ', N'Marian                          ')
GO
INSERT [dbo].[managers] ([id], [name], [last_name]) VALUES (4, N'Gabriela        ', N'Liliana                         ')
GO
INSERT [dbo].[managers] ([id], [name], [last_name]) VALUES (5, N'Ignacja         ', N'Piotr                           ')
GO
SET IDENTITY_INSERT [dbo].[managers] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 
GO
INSERT [dbo].[roles] ([id], [role_name]) VALUES (1, N'Admin                           ')
GO
INSERT [dbo].[roles] ([id], [role_name]) VALUES (2, N'Edytor                          ')
GO
INSERT [dbo].[roles] ([id], [role_name]) VALUES (3, N'Oglądacz                        ')
GO
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
ALTER TABLE [dbo].[companies]  WITH CHECK ADD  CONSTRAINT [FK_companies_companies] FOREIGN KEY([id])
REFERENCES [dbo].[companies] ([id])
GO
ALTER TABLE [dbo].[companies] CHECK CONSTRAINT [FK_companies_companies]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_companies] FOREIGN KEY([company])
REFERENCES [dbo].[companies] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_companies]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_managers] FOREIGN KEY([manager])
REFERENCES [dbo].[managers] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_managers]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_roles1] FOREIGN KEY([role])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_roles1]
GO
USE [master]
GO
ALTER DATABASE [agregator] SET  READ_WRITE 
GO
