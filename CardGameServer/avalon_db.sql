USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 03/11/2015 20:54:30 ******/
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
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 10, 6793, 276, 141, 526666)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (53, N'stas51447', N'Sacura', N'Саисса', 6, 7137, 275, 135, 565645)
SET IDENTITY_INSERT [dbo].[characters] OFF
/****** Object:  Table [dbo].[character_templates]    Script Date: 03/11/2015 20:54:30 ******/
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
/****** Object:  Table [dbo].[character_cards]    Script Date: 03/11/2015 20:54:30 ******/
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
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (29, 53, 8, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (72, 53, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (222, 45, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (503, 45, 5, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (504, 45, 9, 4)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (505, 53, 11, 4)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (506, 45, 6, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (507, 53, 5, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (508, 53, 11, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (509, 45, 9, 5)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (510, 45, 5, 6)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (511, 45, 11, 7)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (512, 53, 9, 5)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (513, 45, 6, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (514, 45, 10, 11)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (515, 53, 7, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (516, 45, 9, 12)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (517, 45, 10, 13)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (518, 45, 9, 14)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (519, 45, 10, 15)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (520, 45, 10, 16)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (521, 45, 7, 17)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (522, 45, 11, 18)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (523, 45, 10, 19)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (524, 45, 7, 20)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (525, 45, 11, 21)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (526, 45, 11, 22)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (527, 45, 6, 23)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (528, 45, 10, 24)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (529, 45, 9, 25)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (530, 45, 9, 26)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (531, 45, 9, 27)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (532, 45, 9, 28)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (533, 45, 10, 29)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (534, 45, 11, 30)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (535, 45, 11, 31)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (536, 45, 6, 32)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (537, 45, 9, 33)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (538, 45, 5, 34)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (539, 45, 5, 35)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (540, 45, 9, 36)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (541, 45, 6, 37)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (542, 45, 5, 38)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (543, 45, 10, 39)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (544, 45, 10, 40)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (545, 45, 7, 41)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (546, 45, 9, 42)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (547, 45, 11, 43)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (548, 45, 5, 44)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (549, 45, 10, 45)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (550, 45, 11, 46)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (551, 45, 5, 47)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (552, 45, 11, 48)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (553, 45, 5, 49)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (554, 45, 10, 50)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (555, 45, 9, 51)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (556, 45, 10, 52)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (557, 45, 9, 53)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (558, 45, 9, 54)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (559, 45, 7, 55)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (560, 45, 11, 56)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (561, 45, 6, 57)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (562, 45, 10, 58)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (563, 45, 6, 59)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (564, 45, 6, 60)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (565, 45, 5, 61)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (566, 45, 10, 62)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (567, 45, 11, 63)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (568, 45, 10, 64)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (569, 45, 11, 65)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (570, 45, 5, 66)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (571, 45, 10, 67)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (572, 45, 9, 68)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (573, 45, 18, 69)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (574, 45, 21, 70)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (575, 45, 13, 71)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (576, 45, 23, 72)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (577, 45, 22, 73)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (578, 45, 10, 74)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (579, 45, 25, 75)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (580, 45, 21, 76)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (581, 45, 15, 77)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (582, 45, 11, 78)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (583, 45, 16, 79)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (584, 45, 20, 80)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (585, 45, 24, 81)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (586, 45, 16, 82)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (587, 45, 13, 83)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (588, 45, 25, 84)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (589, 45, 15, 85)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (590, 45, 21, 86)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (591, 45, 24, 87)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (592, 45, 25, 88)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (593, 45, 23, 89)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (594, 45, 23, 90)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (595, 45, 21, 91)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (596, 45, 14, 92)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (597, 45, 13, 93)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (598, 45, 16, 94)
GO
print 'Processed 100 total records'
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (599, 45, 21, 95)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (600, 45, 18, 96)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (601, 45, 25, 97)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (602, 45, 15, 98)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (603, 45, 18, 99)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (604, 45, 16, 100)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (605, 45, 9, 101)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (606, 45, 22, 102)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (607, 45, 14, 103)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (608, 45, 23, 104)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (609, 45, 11, 105)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (610, 45, 20, 106)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (611, 45, 22, 107)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (612, 45, 25, 108)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (613, 45, 19, 109)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (614, 45, 17, 110)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (615, 45, 24, 111)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (616, 45, 22, 112)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (617, 45, 24, 113)
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 03/11/2015 20:54:30 ******/
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
	[min_level] [int] NOT NULL,
	[initiative] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (1, N'Берас', 0, 8, 5, 5, 0, 1, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (2, N'Эвиин', 0, 6, 6, 3, 0, 1, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (3, N'Эйлад', 0, 7, 7, 3, 0, 1, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (4, N'Маэдар', 0, 8, 4, 5, 0, 1, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (5, N'Воин', 1, 5, 4, 4, 1, 1, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (6, N'Лучник', 1, 4, 5, 3, 1, 1, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (7, N'Волшебник', 1, 3, 7, 2, 1, 1, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (8, N'Саисса', 0, 7, 6, 4, 0, 1, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (9, N'Тёмный Лучник', 1, 5, 6, 4, 2, 3, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (10, N'Элементальный маг', 1, 4, 7, 3, 2, 3, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (11, N'Рыцарь', 1, 6, 5, 5, 2, 3, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (12, N'Валадор', 0, 8, 6, 4, 0, 1, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (13, N'Палладин', 1, 7, 6, 6, 2, 5, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (14, N'Страж', 1, 8, 5, 6, 2, 6, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (15, N'Ведьма', 1, 5, 8, 4, 2, 5, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (16, N'Азриэль', 1, 9, 6, 7, 3, 6, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (17, N'Свирепый Волк', 1, 7, 6, 5, 3, 6, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (18, N'Амфисбена', 1, 6, 7, 5, 2, 5, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (19, N'Ламия', 1, 6, 9, 5, 3, 6, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (20, N'Огненная Колдунья', 1, 6, 8, 4, 2, 6, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (21, N'Эльфийка', 1, 7, 8, 6, 2, 8, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (22, N'Стрелок', 1, 7, 9, 5, 3, 8, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (23, N'Воин Света', 1, 9, 6, 7, 2, 8, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (24, N'Принцесса', 1, 7, 9, 5, 2, 10, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level], [initiative]) VALUES (25, N'Охотница', 1, 8, 10, 6, 3, 10, 3)
/****** Object:  Table [dbo].[accounts]    Script Date: 03/11/2015 20:54:30 ******/
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
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'12345', N'12345')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'1234567890', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'3456789', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'asdfhgj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'dies1233', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'dsfgh', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'dWAHJstas51447d', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'erfgthj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'ergth', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'esfgrydht', N'sgdhfhg')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'karl13', N'1313')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'mshdn', N'msh24578')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'nerk13', N'nekr13')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'qwerghjk', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sadfbg', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'safgdrhtfyu', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sdfsdfdsg', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sdgyui', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sfdgfhj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas514', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas5144', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447d', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wertgyuj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'werty', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wertyu', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wqeryui', N'wertyui')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'wrertyui', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'zet35040', N'123456')
/****** Object:  Default [DF_cards_type]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_cards_rare]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_rare]  DEFAULT ((1)) FOR [rare]
GO
/****** Object:  Default [DF_cards_min_level]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_min_level]  DEFAULT ((1)) FOR [min_level]
GO
/****** Object:  Default [DF_cards_initiative]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_initiative]  DEFAULT ((1)) FOR [initiative]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 03/11/2015 20:54:30 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
