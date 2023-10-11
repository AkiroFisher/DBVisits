USE [lesuser25]
GO
/****** Object:  Table [dbo].[Корабли]    Script Date: 09.10.2023 13:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Корабли](
	[Код_корабля] [int] IDENTITY(1,1) NOT NULL,
	[Название_корабля] [nchar](30) NULL,
	[Водоизмещение,т] [int] NOT NULL,
	[Порт_приписки] [nchar](20) NOT NULL,
	[Капитан] [nchar](20) NULL,
 CONSTRAINT [PK_Судоходство] PRIMARY KEY CLUSTERED 
(
	[Код_корабля] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Порты]    Script Date: 09.10.2023 13:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Порты](
	[Код_порта] [int] IDENTITY(1,1) NOT NULL,
	[Название_порта] [nchar](50) NULL,
	[Страна] [nchar](50) NULL,
 CONSTRAINT [PK_Порты] PRIMARY KEY CLUSTERED 
(
	[Код_порта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Посещения]    Script Date: 09.10.2023 13:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Посещения](
	[Код_посещения] [int] IDENTITY(1,1) NOT NULL,
	[Код_корабля] [int] NOT NULL,
	[Код_порта] [int] NOT NULL,
	[Дата_прибытия] [nchar](10) NULL,
	[Дата_отплытия] [nchar](10) NULL,
	[Номер_причала] [int] NOT NULL,
	[Цель_посещения] [nchar](50) NULL,
 CONSTRAINT [PK_Посещения] PRIMARY KEY CLUSTERED 
(
	[Код_посещения] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Посещения]  WITH CHECK ADD  CONSTRAINT [FK_Посещения_Корабли] FOREIGN KEY([Код_корабля])
REFERENCES [dbo].[Корабли] ([Код_корабля])
GO
ALTER TABLE [dbo].[Посещения] CHECK CONSTRAINT [FK_Посещения_Корабли]
GO
ALTER TABLE [dbo].[Посещения]  WITH CHECK ADD  CONSTRAINT [FK_Посещения_Порты] FOREIGN KEY([Код_порта])
REFERENCES [dbo].[Порты] ([Код_порта])
GO
ALTER TABLE [dbo].[Посещения] CHECK CONSTRAINT [FK_Посещения_Порты]
GO
