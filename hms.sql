USE [hms]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 02-05-2022 07:00:27 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUsers]') AND type in (N'U'))
DROP TABLE [dbo].[tblUsers]
GO
/****** Object:  Table [dbo].[tblRooms]    Script Date: 02-05-2022 07:00:27 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblRooms]') AND type in (N'U'))
DROP TABLE [dbo].[tblRooms]
GO
/****** Object:  Table [dbo].[tblBookings]    Script Date: 02-05-2022 07:00:27 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblBookings]') AND type in (N'U'))
DROP TABLE [dbo].[tblBookings]
GO
/****** Object:  Table [dbo].[tblBookings]    Script Date: 02-05-2022 07:00:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomId] [int] NULL,
	[BookedBy] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRooms]    Script Date: 02-05-2022 07:00:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](50) NULL,
	[RoomName] [nvarchar](50) NULL,
	[RoomType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 02-05-2022 07:00:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[LoginName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[LoginHash] [nvarchar](max) NULL,
	[IsAdmin] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblRooms] ON 
GO
INSERT [dbo].[tblRooms] ([Id], [RoomNo], [RoomName], [RoomType]) VALUES (1, N'G1', N'Room GOne', N'Single')
GO
INSERT [dbo].[tblRooms] ([Id], [RoomNo], [RoomName], [RoomType]) VALUES (2, N'G2', N'Room GTwo', N'Single')
GO
INSERT [dbo].[tblRooms] ([Id], [RoomNo], [RoomName], [RoomType]) VALUES (3, N'G3', N'Room GThree', N'Single')
GO
INSERT [dbo].[tblRooms] ([Id], [RoomNo], [RoomName], [RoomType]) VALUES (4, N'F1', N'Room Fone', N'Double')
GO
INSERT [dbo].[tblRooms] ([Id], [RoomNo], [RoomName], [RoomType]) VALUES (5, N'F2', N'Room FTwo', N'Double')
GO
INSERT [dbo].[tblRooms] ([Id], [RoomNo], [RoomName], [RoomType]) VALUES (6, N'F3', N'Room FThree', N'Double')
GO
SET IDENTITY_INSERT [dbo].[tblRooms] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUsers] ON 
GO
INSERT [dbo].[tblUsers] ([Id], [UserName], [LoginName], [Email], [LoginHash], [IsAdmin]) VALUES (3, N'Test Admin', N'admin', N'admin@test.com', N'd2abaa37a7c3db1137d385e1d8c15fd2', 1)
GO
INSERT [dbo].[tblUsers] ([Id], [UserName], [LoginName], [Email], [LoginHash], [IsAdmin]) VALUES (4, N'Test User', N'user', N'user@test.com', N'7b758957f2063eb16b781634eac6880c', 0)
GO
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
GO
