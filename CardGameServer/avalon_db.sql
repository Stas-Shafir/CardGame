USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 03/05/2015 17:02:39 ******/
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
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 4, 1884, 176, 88, 77717)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (46, N'safgdrhtfyu', N'Dies', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (53, N'stas51447', N'Sacura', N'Саисса', 4, 1499, 175, 88, 8060)
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
/****** Object:  Table [dbo].[character_templates]    Script Date: 03/05/2015 17:02:39 ******/
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
/****** Object:  Table [dbo].[character_cards]    Script Date: 03/05/2015 17:02:39 ******/
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
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (222, 45, 9, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (371, 45, 10, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (374, 45, 9, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (375, 45, 11, 4)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (376, 45, 10, 5)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (377, 45, 5, 8)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (378, 45, 9, 7)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (379, 45, 6, 6)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (380, 45, 5, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (381, 45, 7, 11)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (382, 45, 7, 12)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (383, 45, 9, 13)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (384, 45, 5, 14)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (385, 45, 11, 15)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (386, 45, 10, 16)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (387, 45, 10, 17)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (388, 45, 5, 18)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (389, 45, 11, 19)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (390, 45, 9, 20)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (391, 45, 11, 21)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (392, 45, 10, 22)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (393, 45, 6, 23)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (394, 45, 6, 24)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (395, 45, 10, 25)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (396, 45, 11, 26)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (397, 45, 10, 27)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (398, 45, 10, 28)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (399, 45, 5, 29)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (401, 45, 9, 31)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (402, 45, 11, 32)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (403, 45, 9, 33)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (404, 45, 9, 34)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (405, 45, 9, 35)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (406, 45, 7, 36)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (407, 45, 10, 37)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (408, 45, 10, 38)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (419, 45, 9, 39)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (420, 45, 5, 40)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (421, 45, 11, 41)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (422, 45, 7, 42)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (423, 45, 6, 43)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (424, 45, 5, 44)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (425, 45, 11, 45)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (426, 45, 11, 46)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (427, 45, 10, 47)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (428, 45, 9, 48)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (429, 45, 10, 49)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (430, 45, 10, 50)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (431, 45, 11, 51)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (432, 45, 10, 52)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (433, 45, 10, 53)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (434, 45, 9, 54)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (435, 45, 7, 55)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (436, 53, 8, 0)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (437, 53, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (438, 53, 6, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (439, 45, 11, 56)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (440, 53, 6, 11)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (441, 53, 7, 12)
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 03/05/2015 17:02:39 ******/
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
/****** Object:  Table [dbo].[accounts]    Script Date: 03/05/2015 17:02:39 ******/
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
/****** Object:  Default [DF_cards_type]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_cards_rare]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_rare]  DEFAULT ((1)) FOR [rare]
GO
/****** Object:  Default [DF_cards_min_level]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_min_level]  DEFAULT ((1)) FOR [min_level]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 03/05/2015 17:02:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
