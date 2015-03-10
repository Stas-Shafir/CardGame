USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 03/10/2015 21:18:39 ******/
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
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 6, 6665, 275, 141, 75584)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (53, N'stas51447', N'Sacura', N'Саисса', 6, 6891, 274, 134, 17467)
SET IDENTITY_INSERT [dbo].[characters] OFF
/****** Object:  Table [dbo].[character_templates]    Script Date: 03/10/2015 21:18:39 ******/
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
/****** Object:  Table [dbo].[character_cards]    Script Date: 03/10/2015 21:18:39 ******/
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
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 03/10/2015 21:18:39 ******/
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
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (7, N'Химера', 1, 3, 5, 2, 1, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (8, N'Саисса', 0, 7, 6, 4, 0, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (9, N'Тёмный Лучник', 1, 4, 6, 4, 2, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (10, N'Грифон', 1, 5, 5, 5, 2, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (11, N'Рыцарь', 1, 6, 5, 5, 2, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def], [rare], [min_level]) VALUES (12, N'Валадор', 0, 8, 6, 4, 0, 1)
/****** Object:  Table [dbo].[accounts]    Script Date: 03/10/2015 21:18:39 ******/
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
/****** Object:  Default [DF_cards_type]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_cards_rare]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_rare]  DEFAULT ((1)) FOR [rare]
GO
/****** Object:  Default [DF_cards_min_level]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_min_level]  DEFAULT ((1)) FOR [min_level]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 03/10/2015 21:18:39 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
