USE [lesuser25]
GO
/****** Object:  Table [dbo].[Корабли]    Script Date: 12.10.2023 12:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Корабли](
	[Код_корабля] [int] IDENTITY(1,1) NOT NULL,
	[Название_корабля] [nchar](30) NULL,
	[Водоизмещение] [int] NOT NULL,
	[Порт_приписки] [nchar](20) NOT NULL,
	[Капитан] [nchar](20) NULL,
	[Photo] [nchar](50) NULL,
 CONSTRAINT [PK_Судоходство] PRIMARY KEY CLUSTERED 
(
	[Код_корабля] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Порты]    Script Date: 12.10.2023 12:10:57 ******/
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
/****** Object:  Table [dbo].[Посещения]    Script Date: 12.10.2023 12:10:57 ******/
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
SET IDENTITY_INSERT [dbo].[Корабли] ON 

INSERT [dbo].[Корабли] ([Код_корабля], [Название_корабля], [Водоизмещение], [Порт_приписки], [Капитан], [Photo]) VALUES (1, N'Веселый Роджер                ', 258, N'1                   ', N'Эдвард Инглэнд      ', N'/Resources/veselchak.png                          ')
INSERT [dbo].[Корабли] ([Код_корабля], [Название_корабля], [Водоизмещение], [Порт_приписки], [Капитан], [Photo]) VALUES (2, N'Летучий Голландец             ', 200, N'2                   ', N'Филипп ван Страатен ', N'/Resources/letchik.jpg                            ')
INSERT [dbo].[Корабли] ([Код_корабля], [Название_корабля], [Водоизмещение], [Порт_приписки], [Капитан], [Photo]) VALUES (3, N'Месть королевы Анны           ', 200, N'3                   ', N'Эдвард Тич          ', N'/Resources/mestkorolevianni.jpg                   ')
INSERT [dbo].[Корабли] ([Код_корабля], [Название_корабля], [Водоизмещение], [Порт_приписки], [Капитан], [Photo]) VALUES (4, N'Немая Мэри                    ', 5500, N'4                   ', N'Армандо Салазар     ', N'/Resources/nemaya.jpg                             ')
INSERT [dbo].[Корабли] ([Код_корабля], [Название_корабля], [Водоизмещение], [Порт_приписки], [Капитан], [Photo]) VALUES (5, N'Черная Жемчужина              ', 4000, N'5                   ', N'Джек Уорд           ', N'/Resources/blackperl.jpg                          ')
INSERT [dbo].[Корабли] ([Код_корабля], [Название_корабля], [Водоизмещение], [Порт_приписки], [Капитан], [Photo]) VALUES (6, N'Майнсруфт                     ', 0, N'0                   ', N'Черный Денчик       ', NULL)
SET IDENTITY_INSERT [dbo].[Корабли] OFF
GO
SET IDENTITY_INSERT [dbo].[Порты] ON 

INSERT [dbo].[Порты] ([Код_порта], [Название_порта], [Страна]) VALUES (1, N'Азов                                              ', N'Россия                                            ')
INSERT [dbo].[Порты] ([Код_порта], [Название_порта], [Страна]) VALUES (2, N'Каликут                                           ', N'Индия                                             ')
INSERT [dbo].[Порты] ([Код_порта], [Название_порта], [Страна]) VALUES (3, N'Бристоль                                          ', N'Англия                                            ')
INSERT [dbo].[Порты] ([Код_порта], [Название_порта], [Страна]) VALUES (4, N'Уэльва                                            ', N'Испания                                           ')
INSERT [dbo].[Порты] ([Код_порта], [Название_порта], [Страна]) VALUES (5, N'Сан-Педро                                         ', N'Африка                                            ')
SET IDENTITY_INSERT [dbo].[Порты] OFF
GO
SET IDENTITY_INSERT [dbo].[Посещения] ON 

INSERT [dbo].[Посещения] ([Код_посещения], [Код_корабля], [Код_порта], [Дата_прибытия], [Дата_отплытия], [Номер_причала], [Цель_посещения]) VALUES (1, 2, 3, N'13.07.1990', N'20.07.1990', 1, N'Туризм                                            ')
INSERT [dbo].[Посещения] ([Код_посещения], [Код_корабля], [Код_порта], [Дата_прибытия], [Дата_отплытия], [Номер_причала], [Цель_посещения]) VALUES (2, 1, 2, N'15.08.1990', N'21.08.1990', 1, N'Туризм                                            ')
INSERT [dbo].[Посещения] ([Код_посещения], [Код_корабля], [Код_порта], [Дата_прибытия], [Дата_отплытия], [Номер_причала], [Цель_посещения]) VALUES (3, 3, 1, N'08.10.1990', N'30.10.1990', 3, N'Починка кормы                                     ')
INSERT [dbo].[Посещения] ([Код_посещения], [Код_корабля], [Код_порта], [Дата_прибытия], [Дата_отплытия], [Номер_причала], [Цель_посещения]) VALUES (4, 4, 4, N'10.05.1992', N'15.05.1992', 2, N'Пополнение припасов 70%                           ')
INSERT [dbo].[Посещения] ([Код_посещения], [Код_корабля], [Код_порта], [Дата_прибытия], [Дата_отплытия], [Номер_причала], [Цель_посещения]) VALUES (5, 5, 2, N'22.04.1991', N'23.04.1991', 1, N'Загрузка пассажиров                               ')
INSERT [dbo].[Посещения] ([Код_посещения], [Код_корабля], [Код_порта], [Дата_прибытия], [Дата_отплытия], [Номер_причала], [Цель_посещения]) VALUES (6, 3, 1, N'20.12.1990', N'10.01.1991', 3, N'Починка такелажа                                  ')
SET IDENTITY_INSERT [dbo].[Посещения] OFF
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
