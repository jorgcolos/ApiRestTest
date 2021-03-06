USE [master]
GO
/****** Object:  Database [ComputerSupplies]    Script Date: 3/5/2020 15:30:56 ******/
CREATE DATABASE [ComputerSupplies]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComputerSupplies', FILENAME = N'C:\Users\jaherrera\ComputerSupplies.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComputerSupplies_log', FILENAME = N'C:\Users\jaherrera\ComputerSupplies_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComputerSupplies] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputerSupplies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputerSupplies] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComputerSupplies] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComputerSupplies] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComputerSupplies] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComputerSupplies] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComputerSupplies] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ComputerSupplies] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComputerSupplies] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComputerSupplies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComputerSupplies] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComputerSupplies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComputerSupplies] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComputerSupplies] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComputerSupplies] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComputerSupplies] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ComputerSupplies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComputerSupplies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComputerSupplies] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComputerSupplies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComputerSupplies] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComputerSupplies] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ComputerSupplies] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComputerSupplies] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ComputerSupplies] SET  MULTI_USER 
GO
ALTER DATABASE [ComputerSupplies] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComputerSupplies] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComputerSupplies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComputerSupplies] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ComputerSupplies]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/5/2020 15:30:56 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Birthday] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](max) NULL,
	[IsMain] [bit] NOT NULL,
	[ProductId] [int] NULL,
	[IdCloudinary] [nvarchar](max) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/5/2020 15:30:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Created] [datetime2](7) NOT NULL,
	[AppUserId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200501035924_InitialCreate', N'3.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200501234000_AddedIdentity', N'3.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200502211858_EFrelationships', N'3.1.2')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200502230217_AddIdCloudinary', N'3.1.2')
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Birthday]) VALUES (1, N'jorge', N'JORGE', N'jorgcolos@gmail.com', N'JORGCOLOS@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDOfXSojl5XPM0+saycOLkdEHxWY+IwxjMhHJRo7hkFlOF9ltptaLc2m/UI76TVirQ==', N'75R2BCASBJ46YCZTSYZYDUGEAXWRVVWM', N'41eac4e4-63fc-4d18-9cd0-d13df79a4708', N'22577777', 0, 0, NULL, 1, 0, N'Jorge Herrera', CAST(N'1989-08-22 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Birthday]) VALUES (2, N'efrain', N'EFRAIN', N'efrain@elaniin.com', N'EFRAIN@ELANIIN.COM', 0, N'AQAAAAEAACcQAAAAEBnaCWTSMBoxB1Ij9WtW48Enh77wGxbDYMl74YMIZRLqMatQT5HNte+EkCepIaeQZg==', N'VSWICFNQIIVTU7FQ72KZHPK7KV7LQX5Y', N'73d61619-b3d4-44d5-a6eb-dc59760b4c58', N'71000000', 0, 0, NULL, 1, 0, N'Efrain Ortiz', CAST(N'1987-01-01 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Birthday]) VALUES (3, N'rony', N'RONY', N'rony@elaniin.com', N'RONY@ELANIIN.COM', 0, N'AQAAAAEAACcQAAAAEFcyr6YevwM43aMBcVGJ6SZkxSt6HTf7sX8YAuW+oT9oazt/1XnIA51bQSb57owpVw==', N'QO5UVHGQW5TFJ4OF62VRURCJ7U75ERHW', N'e2a2a25e-325f-4e70-97ab-4b903ce85029', N'22777777', 0, 0, NULL, 1, 0, N'Rony Almendarez', CAST(N'1991-02-02 00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Birthday]) VALUES (4, N'test', N'TEST', N'test@email.com', N'TEST@EMAIL.COM', 0, N'AQAAAAEAACcQAAAAECtZ7reD5ufkZm23bIMmzFb1VUvbz/+wSMZaZbIuARKrKH2zRDFWWmvzVPrqBkatnA==', N'7Z4CY4444RTDQS33WLPVHWXOBHM7DWJ4', N'e49f4bb9-9848-4cae-8934-508d12482641', N'12345678', 0, 0, NULL, 1, 0, N'User Test', CAST(N'1980-04-04 00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (1, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468717/qnrbxcieshmymrcpoh1d.jpg', 1, 1, N'qnrbxcieshmymrcpoh1d')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (2, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468744/nygbzw1ogeifginejcgx.jpg', 0, 1, N'nygbzw1ogeifginejcgx')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (3, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468765/brcbugdrhijds5bqqvpz.jpg', 1, 2, N'brcbugdrhijds5bqqvpz')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (4, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468803/w3hphsodt4gie7buvtoo.jpg', 0, 2, N'w3hphsodt4gie7buvtoo')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (5, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468835/f6zh7jjzvfhgbtkcolr3.jpg', 1, 3, N'f6zh7jjzvfhgbtkcolr3')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (6, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468867/daxhuvprrhnxjoynrjov.jpg', 1, 4, N'daxhuvprrhnxjoynrjov')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (7, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468901/emmd4wq7b1uuzql02jc6.jpg', 0, 4, N'emmd4wq7b1uuzql02jc6')
INSERT [dbo].[Images] ([Id], [Url], [IsMain], [ProductId], [IdCloudinary]) VALUES (8, N'https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468925/ef2t8veexkf9vhqvnwdl.jpg', 1, 5, N'ef2t8veexkf9vhqvnwdl')
SET IDENTITY_INSERT [dbo].[Images] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (1, N'CPU1', N'Intel Core i7-9700K', 55, 379.99, N'Intel Core i7-9700K Coffee Lake 8-Core 3.6 GHz (4.9 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I79700K Desktop Processor Intel UHD Graphics 630', CAST(N'2020-05-03 12:44:34.3435088' AS DateTime2), 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (2, N'CPU2', N'Intel Core i5-9600K', 288, 199.99, N'Intel Core i5-9600K Coffee Lake 6-Core 3.7 GHz (4.6 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I59600K Desktop Processor Intel UHD Graphics 630', CAST(N'2020-05-03 12:44:34.3488609' AS DateTime2), 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (3, N'CPU3', N'AMD RYZEN 7 3700X', 104, 308.99, N'AMD RYZEN 7 3700X 8-Core 3.6 GHz (4.4 GHz Max Boost) Socket AM4 65W 100-100000071BOX Desktop Processor', CAST(N'2020-05-03 12:44:34.3489861' AS DateTime2), 2)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (4, N'SSD1', N'WD Blue 3D NAND 1TB', 144, 119.99, N'WD Blue 3D NAND 1TB Internal SSD - SATA III 6Gb/s 2.5 Solid State Drive - WDS100T2B0A', CAST(N'2020-05-03 12:44:34.3490574' AS DateTime2), 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (5, N'SSD2', N'SAMSUNG 860 QVO Series 1TB', 41, 113.55, N'SAMSUNG 860 QVO Series 2.5 1TB SATA III Internal Solid State Drive (SSD) MZ-76Q1T0B/AM', CAST(N'2020-05-03 12:44:34.3491432' AS DateTime2), 2)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (6, N'RAM1', N'G.SKILL TridentZ RGB Series 16GB', 68, 100.99, N'G.SKILL TridentZ RGB Series 16GB (2 x 8GB) 288-Pin DDR4 SDRAM DDR4 3200 (PC4 25600) Desktop Memory Model F4-3200C16D-16GTZR', CAST(N'2020-05-03 12:44:34.3492113' AS DateTime2), 2)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Quantity], [Price], [Description], [Created], [AppUserId]) VALUES (7, N'RAM2', N'G.SKILL Ripjaws V Series 16GB', 420, 72.49, N'G.SKILL Ripjaws V Series 16GB (2 x 8GB) 288-Pin DDR4 SDRAM DDR4 3200 (PC4 25600) Desktop Memory Model F4-3200C16D-16GVKB', CAST(N'2020-05-03 12:44:34.3492117' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/5/2020 15:30:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/5/2020 15:30:56 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Images_ProductId]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [IX_Images_ProductId] ON [dbo].[Images]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_AppUserId]    Script Date: 3/5/2020 15:30:56 ******/
CREATE NONCLUSTERED INDEX [IX_Products_AppUserId] ON [dbo].[Products]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_AspNetUsers_AppUserId]
GO
USE [master]
GO
ALTER DATABASE [ComputerSupplies] SET  READ_WRITE 
GO
