USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 03/03/2015 21:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[characters](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[hero_name] [varchar](50) NOT NULL,
	[character_level] [int] NOT NULL,
	[exp] [int] NOT NULL,
	[games] [int] NOT NULL,
	[wins] [int] NOT NULL,
	[score] [int] NOT NULL,
 CONSTRAINT [PK_characters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_characters] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[characters] ON
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 16, 29617, 159, 76, 136000)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (46, N'safgdrhtfyu', N'Dies', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (53, N'stas51447', N'Sacura', N'Саисса', 16, 30286, 158, 83, 6631)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (54, N'wertgyuj', N'sADSFGTHJK', N'Эйлад', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (55, N'wrertyui', N'adsfhjkl', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (56, N'qwerghjk', N'ewrgthyj', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (57, N'qwerghjk', N'dasfgyj', N'Саисса', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (58, N'asdfhgj', N'wertyuil', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (59, N'1234567890', N'ewasfd', N'Маэдар', 1, 130, 1, 0, 67)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (60, N'wqeryui', N'asfdghjk', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (61, N'123345', N'asdfghj', N'Саисса', 2, 246, 1, 1, 125)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (62, N'3456789', N'sdfghj', N'Саисса', 1, 130, 1, 0, 64)
SET IDENTITY_INSERT [dbo].[characters] OFF
/****** Object:  Table [dbo].[character_templates]    Script Date: 03/03/2015 21:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[character_templates](
	[hero_card] [int] NOT NULL,
	[first_card] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[character_templates] ([hero_card], [first_card]) VALUES (1, 5)
INSERT [dbo].[character_templates] ([hero_card], [first_card]) VALUES (2, 6)
INSERT [dbo].[character_templates] ([hero_card], [first_card]) VALUES (3, 7)
INSERT [dbo].[character_templates] ([hero_card], [first_card]) VALUES (4, 5)
INSERT [dbo].[character_templates] ([hero_card], [first_card]) VALUES (8, 6)
INSERT [dbo].[character_templates] ([hero_card], [first_card]) VALUES (12, 7)
/****** Object:  Table [dbo].[character_cards]    Script Date: 03/03/2015 21:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[character_cards](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[char_id] [int] NOT NULL,
	[card_id] [int] NOT NULL,
	[slot] [int] NOT NULL,
 CONSTRAINT [PK_character_cards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[character_cards] ON
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (27, 45, 3, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (29, 46, 4, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (72, 46, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (81, 45, 6, 24)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (209, 53, 8, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (210, 53, 6, 35)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (211, 53, 6, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (212, 53, 7, 31)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (213, 45, 5, 23)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (214, 53, 7, 29)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (215, 53, 5, 28)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (216, 53, 9, 4)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (217, 45, 5, 22)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (218, 53, 5, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (219, 53, 9, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (220, 53, 6, 12)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (221, 53, 7, 13)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (222, 45, 9, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (223, 45, 6, 11)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (224, 45, 5, 12)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (225, 45, 7, 13)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (226, 45, 9, 61)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (227, 53, 5, 14)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (228, 45, 5, 15)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (229, 45, 5, 16)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (230, 53, 9, 5)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (231, 45, 9, 5)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (232, 45, 9, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (233, 53, 10, 6)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (234, 53, 10, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (235, 45, 7, 19)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (236, 53, 6, 18)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (237, 45, 5, 20)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (238, 45, 10, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (239, 45, 6, 25)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (240, 45, 5, 26)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (241, 53, 5, 19)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (242, 53, 9, 8)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (243, 45, 9, 7)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (244, 45, 7, 28)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (245, 45, 9, 8)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (246, 45, 5, 30)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (247, 45, 7, 31)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (248, 45, 10, 6)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (249, 45, 5, 32)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (250, 45, 10, 33)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (251, 45, 10, 34)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (252, 45, 9, 35)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (253, 53, 7, 21)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (254, 53, 5, 22)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (255, 53, 5, 23)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (256, 53, 6, 24)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (257, 53, 5, 25)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (258, 53, 9, 7)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (259, 53, 6, 27)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (260, 45, 5, 36)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (261, 45, 7, 37)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (262, 45, 10, 38)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (263, 54, 3, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (264, 54, 7, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (265, 55, 4, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (266, 55, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (267, 56, 4, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (268, 56, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (269, 57, 8, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (270, 57, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (271, 58, 4, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (272, 58, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (273, 59, 4, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (274, 59, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (275, 45, 10, 39)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (276, 45, 6, 40)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (277, 53, 7, 32)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (278, 45, 7, 41)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (279, 45, 7, 42)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (280, 45, 6, 43)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (281, 53, 5, 33)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (282, 45, 10, 44)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (283, 60, 4, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (284, 60, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (285, 53, 5, 36)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (286, 45, 6, 45)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (287, 53, 7, 37)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (288, 53, 9, 38)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (289, 53, 6, 39)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (290, 53, 10, 40)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (291, 53, 9, 41)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (292, 53, 5, 42)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (293, 53, 9, 43)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (294, 53, 7, 44)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (295, 53, 6, 45)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (296, 53, 6, 46)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (297, 53, 6, 47)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (298, 53, 6, 48)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (299, 45, 5, 46)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (300, 45, 5, 47)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (301, 45, 5, 48)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (302, 45, 7, 49)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (303, 45, 6, 50)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (304, 45, 9, 51)
GO
print 'Processed 100 total records'
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (305, 53, 10, 49)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (306, 45, 9, 52)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (307, 53, 5, 50)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (308, 45, 6, 53)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (309, 45, 5, 54)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (310, 61, 8, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (311, 61, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (312, 62, 8, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (313, 62, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (314, 61, 7, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (315, 62, 6, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (316, 45, 9, 55)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (317, 45, 5, 56)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (318, 45, 10, 57)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (319, 45, 11, 4)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (320, 45, 9, 59)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (321, 45, 9, 60)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (322, 45, 10, 62)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (323, 45, 9, 63)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (324, 45, 9, 64)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (325, 45, 6, 65)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (326, 45, 11, 66)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (327, 45, 7, 67)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (328, 45, 6, 68)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (329, 45, 9, 69)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (330, 45, 11, 70)
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 03/03/2015 21:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cards](
	[id] [int] NOT NULL,
	[card_name] [varchar](50) NOT NULL,
	[type] [int] NOT NULL,
	[hp] [int] NOT NULL,
	[dmg] [int] NOT NULL,
	[def] [int] NOT NULL,
	[rare] [int] NOT NULL,
	[min_level] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (1, N'Берас', 0, 8, 5, 5, 0, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (2, N'Эвиин', 0, 6, 6, 3, 0, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (3, N'Эйлад', 0, 7, 7, 3, 0, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (4, N'Маэдар', 0, 8, 4, 5, 0, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (5, N'Воин', 1, 5, 4, 4, 1, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (6, N'Лучник', 1, 4, 5, 3, 1, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (7, N'Маг', 1, 3, 5, 2, 1, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (8, N'Саисса', 0, 7, 6, 4, 0, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (9, N'Тёмный Лучник', 1, 4, 6, 4, 2, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (10, N'Элементальный Маг', 1, 5, 5, 5, 2, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (11, N'Рыцарь', 1, 6, 5, 5, 2, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (12, N'Валадор', 0, 8, 6, 4, 0, 1)
/****** Object:  Table [dbo].[accounts]    Script Date: 03/03/2015 21:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accounts](
	[account] [varchar](50) NOT NULL,
	[password] [varchar](255) NOT NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[account] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'123345', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'1234567890', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'3456789', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'asdfhgj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'dsfgh', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'dWAHJstas51447d', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'erfgthj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'ergth', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'esfgrydht', N'sgdhfhg')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'qwerghjk', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sadfbg', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'safgdrhtfyu', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sdgyui', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sfdgfhj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas514', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas5144', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447d', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wertgyuj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wertyu', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wqeryui', N'wertyui')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wrertyui', N'123456')
/****** Object:  Default [DF_cards_type]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_cards_rare]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_rare]  DEFAULT ((1)) FOR [rare]
GO
/****** Object:  Default [DF_cards_min_level]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_min_level]  DEFAULT ((1)) FOR [min_level]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 03/03/2015 21:45:52 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
