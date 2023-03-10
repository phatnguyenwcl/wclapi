USE [wclDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/27/2023 12:08:58 AM ******/
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
/****** Object:  Table [dbo].[AppConfigs]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfigs](
	[Key] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AppConfigs] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoleClaims]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoles]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserClaims]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserLogins]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
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
	[Discriminator] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Dob] [datetime2](7) NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserTokens]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Imgage] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Marital] [int] NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[CCCD] [nvarchar](15) NOT NULL,
	[Gender] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[IsManager] [bit] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSheets]    Script Date: 1/27/2023 12:08:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSheets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[StartWorking] [datetime2](7) NOT NULL,
	[EndWorking] [datetime2](7) NOT NULL,
	[BreakStart] [datetime2](7) NOT NULL,
	[BreakEnd] [datetime2](7) NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[DateModified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TimeSheets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230119104626_initDatabase', N'7.0.2')
GO
INSERT [dbo].[AppRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Discriminator], [Description]) VALUES (N'b00cc2c4-385e-4452-b9fe-80b11e6e8917', N'Admin', N'ADMIN', N'00000000-0000-0000-0000-000000000000', N'AppRole', N'Administrator')
INSERT [dbo].[AppRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Discriminator], [Description]) VALUES (N'f3dab7a0-a8fa-450b-8cec-b22703ff5233', N'Editor', N'EDITOR', N'00000000-0000-0000-0000-000000000000', N'AppRole', N'Editor')
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'b7f8ab44-dc1e-48c0-9c84-210a2efb1892', N'f3dab7a0-a8fa-450b-8cec-b22703ff5233')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'19aef916-f24e-438c-9529-54419867ce85', N'b00cc2c4-385e-4452-b9fe-80b11e6e8917')
GO
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [Dob]) VALUES (N'185931cb-c111-4f9e-66dd-08dafa0cd901', N'nhkphat2', N'NHKPHAT2', N'nhkphat2@gmail.com', N'NHKPHAT2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEA+2mcgInccxJoz2zMFNBTEyZ/4Sy+mX0AvqWivyWveKD8OB8zWnO7JAli8CaXky/Q==', N'UYIHLY7L6UVRLIWQ3PPXYQI5B22NKMD6', N'221b16b7-f9bb-4f68-8db9-329fb1c3585f', N'0972532752', 0, 0, NULL, 1, 0, N'AppUser', N'Phat', N'Nguyen', CAST(N'2000-01-20T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [Dob]) VALUES (N'b7f8ab44-dc1e-48c0-9c84-210a2efb1892', N'vinhnx', N'VINHNX', N'vinhnx@gmail.com', N'VINHNX@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEA+2mcgInccxJoz2zMFNBTEyZ/4Sy+mX0AvqWivyWveKD8OB8zWnO7JAli8CaXky/Q==', N'UYIHLY7L6UVRLIWQ3PPXYQI5B22NKMD6', N'955f39e0-c3a9-4960-a784-091d2ece29b3', N'0935532758', 0, 0, NULL, 1, 0, N'AppUser', N'Vinh', N'Nguyen', CAST(N'1990-02-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [FirstName], [LastName], [Dob]) VALUES (N'19aef916-f24e-438c-9529-54419867ce85', N'nhkphat', N'NHKPHAT', N'nhkphat@gmail.com', N'NHKPHAT@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEA+2mcgInccxJoz2zMFNBTEyZ/4Sy+mX0AvqWivyWveKD8OB8zWnO7JAli8CaXky/Q==', N'UYIHLY7L6UVRLIWQ3PPXYQI5B22NKMD6', N'004d7abd-9ca9-494a-9610-2a07df0cfa8f', N'0972532751', 0, 0, NULL, 1, 0, N'AppUser', N'Phat', N'Nguyen', CAST(N'1994-05-10T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [Name], [EmployeeID], [DateCreated], [DateModified]) VALUES (1, N'IT / IT Dev', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Departments] ([ID], [Name], [EmployeeID], [DateCreated], [DateModified]) VALUES (2, N'Import', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Departments] ([ID], [Name], [EmployeeID], [DateCreated], [DateModified]) VALUES (3, N'HR', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Departments] ([ID], [Name], [EmployeeID], [DateCreated], [DateModified]) VALUES (4, N'Accounting', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Departments] ([ID], [Name], [EmployeeID], [DateCreated], [DateModified]) VALUES (5, N'Inventory', 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Imgage], [Address], [Marital], [DOB], [CCCD], [Gender], [DepartmentID], [UserId], [IsManager], [DateCreated], [DateModified]) VALUES (1, N'Nguyen Xuan Vinh', N'vinhnx@gmail.com', N'string', N'string', N'Dien Khanh', 0, CAST(N'1990-11-20T00:00:00.0000000' AS DateTime2), N'225574345', 1, 1, N'00000000-0000-0000-0000-000000000000', 1, CAST(N'2023-01-19T17:51:38.5900000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Imgage], [Address], [Marital], [DOB], [CCCD], [Gender], [DepartmentID], [UserId], [IsManager], [DateCreated], [DateModified]) VALUES (2, N'Nguyen Huu Khanh Phat', N'nhkphat@gmail.com', N'string', N'string', N'Vinh Luong', 1, CAST(N'1994-05-10T00:00:00.0000000' AS DateTime2), N'225574510', 1, 1, N'00000000-0000-0000-0000-000000000000', 0, CAST(N'2023-01-19T17:51:43.2066667' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Imgage], [Address], [Marital], [DOB], [CCCD], [Gender], [DepartmentID], [UserId], [IsManager], [DateCreated], [DateModified]) VALUES (3, N'Anni', N'anni@gmail.com', N'string', N'string', N'Nha Trang', 1, CAST(N'1991-03-08T00:00:00.0000000' AS DateTime2), N'295574598', 0, 2, N'00000000-0000-0000-0000-000000000000', 0, CAST(N'2023-01-19T17:51:48.8333333' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([ID], [Name], [Email], [Phone], [Imgage], [Address], [Marital], [DOB], [CCCD], [Gender], [DepartmentID], [UserId], [IsManager], [DateCreated], [DateModified]) VALUES (4, N'Alice', N'alice@gmail.com', N'string', N'string', N'Nha Trang', 0, CAST(N'2000-10-03T00:00:00.0000000' AS DateTime2), N'225574513', 0, 3, N'00000000-0000-0000-0000-000000000000', 0, CAST(N'2023-01-19T17:51:53.8300000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeSheets] ON 

INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (2, 1, CAST(N'2022-12-01T17:00:00.0000000' AS DateTime2), CAST(N'2022-12-02T02:08:22.1100000' AS DateTime2), CAST(N'2022-12-01T21:00:22.1100000' AS DateTime2), CAST(N'2022-12-01T22:00:22.1100000' AS DateTime2), CAST(N'2023-01-20T11:16:48.6856404' AS DateTime2), CAST(N'2023-01-26T21:01:14.0484079' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (3, 1, CAST(N'2022-12-02T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-03T02:00:00.3330000' AS DateTime2), CAST(N'2022-12-02T21:00:52.3330000' AS DateTime2), CAST(N'2022-12-02T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:19:35.2934508' AS DateTime2), CAST(N'2023-01-26T18:15:47.2066667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (4, 1, CAST(N'2022-12-05T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-06T02:00:00.3330000' AS DateTime2), CAST(N'2022-12-05T21:00:52.3330000' AS DateTime2), CAST(N'2022-12-05T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:20:36.4980632' AS DateTime2), CAST(N'2023-01-26T18:16:21.7966667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (5, 1, CAST(N'2022-12-06T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-07T02:00:00.3330000' AS DateTime2), CAST(N'2022-12-06T21:00:52.3330000' AS DateTime2), CAST(N'2022-12-06T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:20:48.7975756' AS DateTime2), CAST(N'2023-01-26T18:16:42.7233333' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (6, 1, CAST(N'2022-12-07T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-08T02:20:00.3330000' AS DateTime2), CAST(N'2022-12-07T21:20:52.3330000' AS DateTime2), CAST(N'2022-12-07T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:21:47.6149656' AS DateTime2), CAST(N'2023-01-26T18:17:04.8466667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (7, 1, CAST(N'2022-12-08T16:45:22.3330000' AS DateTime2), CAST(N'2022-12-09T02:20:00.3330000' AS DateTime2), CAST(N'2022-12-08T21:20:52.3330000' AS DateTime2), CAST(N'2022-12-08T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:22:12.6927812' AS DateTime2), CAST(N'2023-01-26T18:17:33.2866667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (8, 1, CAST(N'2022-12-09T16:45:22.3330000' AS DateTime2), CAST(N'2022-12-10T02:20:00.3330000' AS DateTime2), CAST(N'2022-12-09T21:20:52.3330000' AS DateTime2), CAST(N'2022-12-09T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:22:26.0128117' AS DateTime2), CAST(N'2023-01-26T18:17:54.8533333' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (9, 1, CAST(N'2022-12-12T16:45:22.3330000' AS DateTime2), CAST(N'2022-12-13T02:20:00.3330000' AS DateTime2), CAST(N'2022-12-12T21:20:52.3330000' AS DateTime2), CAST(N'2022-12-12T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:23:15.3208917' AS DateTime2), CAST(N'2023-01-26T18:18:18.5600000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (10, 1, CAST(N'2022-12-13T16:50:22.3330000' AS DateTime2), CAST(N'2022-12-14T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-13T21:20:52.3330000' AS DateTime2), CAST(N'2022-12-13T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:23:41.9410053' AS DateTime2), CAST(N'2023-01-26T18:18:39.1600000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (11, 1, CAST(N'2022-12-14T16:50:22.3330000' AS DateTime2), CAST(N'2022-12-15T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-14T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-14T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:24:10.4962244' AS DateTime2), CAST(N'2023-01-26T18:18:59.1866667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (12, 1, CAST(N'2022-12-15T16:50:22.3330000' AS DateTime2), CAST(N'2022-12-16T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-15T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-15T22:10:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:24:19.7122823' AS DateTime2), CAST(N'2023-01-26T18:19:34.3466667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (13, 1, CAST(N'2022-12-16T16:50:22.3330000' AS DateTime2), CAST(N'2022-12-17T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-16T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-16T22:05:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:24:57.5253412' AS DateTime2), CAST(N'2023-01-26T18:19:53.3600000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (14, 1, CAST(N'2022-12-19T16:50:22.3330000' AS DateTime2), CAST(N'2022-12-20T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-19T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-19T22:05:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:25:18.4693065' AS DateTime2), CAST(N'2023-01-26T18:20:28.3466667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (15, 1, CAST(N'2022-12-20T16:50:22.3330000' AS DateTime2), CAST(N'2022-12-21T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-20T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-20T22:05:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:25:30.9135368' AS DateTime2), CAST(N'2023-01-26T18:20:57.2200000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (16, 1, CAST(N'2022-12-21T16:55:22.3330000' AS DateTime2), CAST(N'2022-12-22T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-21T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-21T22:05:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:25:43.9749518' AS DateTime2), CAST(N'2023-01-26T18:21:22.9966667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (17, 1, CAST(N'2022-12-22T16:55:22.3330000' AS DateTime2), CAST(N'2022-12-23T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-22T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-22T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:25:56.7378702' AS DateTime2), CAST(N'2023-01-26T18:21:45.3866667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (18, 1, CAST(N'2022-12-23T16:55:22.3330000' AS DateTime2), CAST(N'2022-12-24T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-23T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-23T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:26:05.4097245' AS DateTime2), CAST(N'2023-01-26T18:22:15.8133333' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (19, 1, CAST(N'2022-12-26T16:55:22.3330000' AS DateTime2), CAST(N'2022-12-27T02:08:00.3330000' AS DateTime2), CAST(N'2022-12-26T21:15:52.3330000' AS DateTime2), CAST(N'2022-12-26T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:26:43.1815546' AS DateTime2), CAST(N'2023-01-26T18:22:47.5600000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (20, 1, CAST(N'2022-12-27T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-28T02:05:00.3330000' AS DateTime2), CAST(N'2022-12-27T21:08:52.3330000' AS DateTime2), CAST(N'2022-12-27T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:27:10.9827776' AS DateTime2), CAST(N'2023-01-26T18:23:08.7700000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (21, 1, CAST(N'2022-12-28T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-29T02:05:00.3330000' AS DateTime2), CAST(N'2022-12-28T21:08:52.3330000' AS DateTime2), CAST(N'2022-12-28T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:27:22.0357008' AS DateTime2), CAST(N'2023-01-26T18:23:47.1800000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (22, 1, CAST(N'2022-12-29T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-30T02:05:00.3330000' AS DateTime2), CAST(N'2022-12-29T21:08:52.3330000' AS DateTime2), CAST(N'2022-12-29T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:27:34.0215399' AS DateTime2), CAST(N'2023-01-26T18:24:12.9566667' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (23, 1, CAST(N'2022-12-30T17:00:22.3330000' AS DateTime2), CAST(N'2022-12-31T02:05:00.3330000' AS DateTime2), CAST(N'2022-12-30T21:08:52.3330000' AS DateTime2), CAST(N'2022-12-30T22:00:00.3330000' AS DateTime2), CAST(N'2023-01-20T11:27:51.3242264' AS DateTime2), CAST(N'2023-01-26T18:25:23.0933333' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (25, 2, CAST(N'2023-01-02T16:45:25.9930000' AS DateTime2), CAST(N'2023-01-03T02:10:25.9930000' AS DateTime2), CAST(N'2023-01-02T21:03:25.9930000' AS DateTime2), CAST(N'2023-01-02T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:05:40.4570643' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (26, 2, CAST(N'2023-01-03T16:50:25.9930000' AS DateTime2), CAST(N'2023-01-04T02:10:25.9930000' AS DateTime2), CAST(N'2023-01-03T21:09:25.9930000' AS DateTime2), CAST(N'2023-01-03T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:06:47.2618670' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (27, 2, CAST(N'2023-01-04T16:50:25.9930000' AS DateTime2), CAST(N'2023-01-05T02:10:25.9930000' AS DateTime2), CAST(N'2023-01-04T21:09:25.9930000' AS DateTime2), CAST(N'2023-01-04T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:06:59.2505724' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (28, 2, CAST(N'2023-01-05T16:50:25.9930000' AS DateTime2), CAST(N'2023-01-06T02:10:25.9930000' AS DateTime2), CAST(N'2023-01-05T21:09:25.9930000' AS DateTime2), CAST(N'2023-01-05T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:07:12.0534525' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (29, 2, CAST(N'2023-01-08T16:50:25.9930000' AS DateTime2), CAST(N'2023-01-09T02:10:25.9930000' AS DateTime2), CAST(N'2023-01-08T21:09:25.9930000' AS DateTime2), CAST(N'2023-01-08T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:07:57.6725209' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (30, 2, CAST(N'2023-01-09T16:55:25.9930000' AS DateTime2), CAST(N'2023-01-10T02:06:25.9930000' AS DateTime2), CAST(N'2023-01-09T21:07:25.9930000' AS DateTime2), CAST(N'2023-01-09T22:06:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:08:26.4360324' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (31, 2, CAST(N'2023-01-10T16:55:25.9930000' AS DateTime2), CAST(N'2023-01-11T02:06:25.9930000' AS DateTime2), CAST(N'2023-01-10T21:07:25.9930000' AS DateTime2), CAST(N'2023-01-10T22:06:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:08:46.3125739' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (32, 2, CAST(N'2023-01-11T16:55:25.9930000' AS DateTime2), CAST(N'2023-01-12T02:06:25.9930000' AS DateTime2), CAST(N'2023-01-11T21:07:25.9930000' AS DateTime2), CAST(N'2023-01-11T22:06:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:08:57.8386060' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (33, 2, CAST(N'2023-01-12T16:40:25.9930000' AS DateTime2), CAST(N'2023-01-13T02:15:25.9930000' AS DateTime2), CAST(N'2023-01-12T21:00:25.9930000' AS DateTime2), CAST(N'2023-01-12T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:09:28.1637803' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (34, 2, CAST(N'2023-01-16T16:48:25.9930000' AS DateTime2), CAST(N'2023-01-17T02:00:25.9930000' AS DateTime2), CAST(N'2023-01-16T21:00:25.9930000' AS DateTime2), CAST(N'2023-01-16T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:12:59.3837336' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (35, 2, CAST(N'2023-01-17T16:49:25.9930000' AS DateTime2), CAST(N'2023-01-18T02:07:25.9930000' AS DateTime2), CAST(N'2023-01-17T21:00:25.9930000' AS DateTime2), CAST(N'2023-01-17T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:13:28.0266494' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (36, 2, CAST(N'2023-01-18T16:44:25.9930000' AS DateTime2), CAST(N'2023-01-19T02:30:25.9930000' AS DateTime2), CAST(N'2023-01-18T21:10:25.9930000' AS DateTime2), CAST(N'2023-01-18T22:05:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:14:06.5073710' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (37, 2, CAST(N'2023-01-19T16:44:25.9930000' AS DateTime2), CAST(N'2023-01-20T02:30:25.9930000' AS DateTime2), CAST(N'2023-01-19T21:10:25.9930000' AS DateTime2), CAST(N'2023-01-19T22:05:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:14:25.9445263' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (38, 2, CAST(N'2023-01-20T16:44:25.9930000' AS DateTime2), CAST(N'2023-01-21T02:30:25.9930000' AS DateTime2), CAST(N'2023-01-20T21:10:25.9930000' AS DateTime2), CAST(N'2023-01-20T22:05:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:15:41.9879941' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (39, 2, CAST(N'2023-01-15T16:44:25.9930000' AS DateTime2), CAST(N'2023-01-16T02:30:25.9930000' AS DateTime2), CAST(N'2023-01-15T21:10:25.9930000' AS DateTime2), CAST(N'2023-01-15T22:05:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:17:09.2954987' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (40, 2, CAST(N'2023-01-06T16:44:25.9930000' AS DateTime2), CAST(N'2023-01-07T02:11:25.9930000' AS DateTime2), CAST(N'2023-01-06T21:00:25.9930000' AS DateTime2), CAST(N'2023-01-06T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:18:09.5144920' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[TimeSheets] ([ID], [EmployeeID], [StartWorking], [EndWorking], [BreakStart], [BreakEnd], [DateCreated], [DateModified]) VALUES (41, 2, CAST(N'2023-01-22T16:44:25.9930000' AS DateTime2), CAST(N'2023-01-23T02:11:25.9930000' AS DateTime2), CAST(N'2023-01-22T21:00:25.9930000' AS DateTime2), CAST(N'2023-01-22T22:00:25.9930000' AS DateTime2), CAST(N'2023-01-26T21:19:00.2365937' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TimeSheets] OFF
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments_DepartmentID]
GO
ALTER TABLE [dbo].[TimeSheets]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheets_Employees_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeSheets] CHECK CONSTRAINT [FK_TimeSheets_Employees_EmployeeID]
GO
