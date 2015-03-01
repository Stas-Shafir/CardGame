USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 03/01/2015 21:28:35 ******/
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
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 14, 18521, 94, 53, 475)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (46, N'safgdrhtfyu', N'Dies', N'Маэдар', 1, 0, 0, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (53, N'stas51447', N'Sacura', N'Саисса', 14, 17021, 94, 41, 800)
SET IDENTITY_INSERT [dbo].[characters] OFF
/****** Object:  Table [dbo].[character_templates]    Script Date: 03/01/2015 21:28:35 ******/
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
/****** Object:  Table [dbo].[character_cards]    Script Date: 03/01/2015 21:28:35 ******/
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
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (210, 53, 6, 30)
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
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (226, 45, 9, 4)
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
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 03/01/2015 21:28:35 ******/
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
	[def] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (1, N'Берас', 0, 8, 5, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (2, N'Эвиин', 0, 6, 6, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (3, N'Эйлад', 0, 7, 4, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (4, N'Маэдар', 0, 9, 4, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (5, N'Воин', 1, 5, 2, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (6, N'Лучник', 1, 4, 3, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (7, N'Маг', 1, 3, 3, 1)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (8, N'Саисса', 0, 8, 6, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (9, N'Тёмный Лучник', 1, 4, 6, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (10, N'Элементальный Маг', 1, 5, 5, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (11, N'Рыцарь', 1, 6, 5, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (12, N'Валадор', 0, 9, 8, 4)
/****** Object:  Table [dbo].[accounts]    Script Date: 03/01/2015 21:28:35 ******/
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
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'dWAHJstas51447d', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'safgdrhtfyu', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'sfdgfhj', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas514', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas5144', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447d', N'123456')
/****** Object:  Default [DF_cards_type]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 03/01/2015 21:28:35 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
