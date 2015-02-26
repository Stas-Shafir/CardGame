USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 02/26/2015 22:03:27 ******/
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
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 12, 12295, 57, 41, 54759)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (46, N'stas51447', N'Dies', N'Маэдар', 11, 9503, 58, 17, 137)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (51, N'stas5144', N'ewruio', N'Эвиин', 1, 132, 1, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (52, N'stas514', N'sdfghj', N'Эвиин', 2, 629, 4, 1, 0)
SET IDENTITY_INSERT [dbo].[characters] OFF
/****** Object:  Table [dbo].[character_templates]    Script Date: 02/26/2015 22:03:27 ******/
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
/****** Object:  Table [dbo].[character_cards]    Script Date: 02/26/2015 22:03:27 ******/
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
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (58, 45, 7, 4)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (72, 46, 5, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (73, 45, 5, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (74, 45, 5, 7)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (75, 45, 6, 10)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (76, 45, 7, 8)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (77, 45, 7, 6)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (79, 45, 5, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (80, 45, 5, 5)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (81, 45, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (82, 45, 6, 11)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (83, 45, 6, 12)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (84, 45, 6, 13)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (85, 45, 6, 14)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (86, 45, 6, 15)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (87, 45, 5, 16)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (88, 45, 6, 17)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (89, 45, 6, 18)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (90, 45, 5, 19)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (91, 45, 6, 20)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (92, 45, 5, 21)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (93, 45, 5, 22)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (94, 45, 6, 23)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (95, 45, 5, 24)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (96, 45, 6, 25)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (97, 45, 6, 26)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (98, 45, 6, 27)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (99, 45, 6, 28)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (100, 45, 5, 29)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (101, 45, 6, 30)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (102, 45, 5, 31)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (103, 45, 6, 32)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (104, 45, 6, 33)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (105, 45, 5, 34)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (106, 45, 5, 35)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (107, 45, 6, 36)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (108, 45, 5, 37)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (109, 45, 5, 38)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (110, 45, 6, 39)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (111, 45, 5, 40)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (112, 45, 6, 41)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (113, 45, 6, 42)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (114, 45, 6, 43)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (115, 45, 5, 44)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (116, 45, 5, 45)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (117, 45, 5, 46)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (118, 45, 6, 47)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (119, 45, 5, 48)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (120, 45, 6, 49)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (121, 45, 6, 50)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (122, 45, 5, 51)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (123, 45, 6, 52)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (124, 45, 6, 53)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (125, 45, 6, 54)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (126, 45, 5, 55)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (127, 45, 6, 56)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (128, 45, 5, 57)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (129, 45, 6, 58)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (130, 45, 6, 59)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (131, 45, 6, 60)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (132, 45, 6, 61)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (133, 45, 5, 62)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (134, 45, 5, 63)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (135, 45, 6, 64)
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 02/26/2015 22:03:27 ******/
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
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (1, N'Берас', 0, 3, 5, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (2, N'Эвиин', 0, 3, 6, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (3, N'Эйлад', 0, 3, 4, 4)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (4, N'Маэдар', 0, 3, 4, 5)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (5, N'Воин', 1, 5, 2, 3)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (6, N'Лучник', 1, 4, 3, 2)
INSERT [dbo].[cards] ([id], [card_name], [type], [hp], [dmg], [def]) VALUES (7, N'Маг', 1, 3, 3, 1)
/****** Object:  Table [dbo].[accounts]    Script Date: 02/26/2015 22:03:27 ******/
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
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas514', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas5144', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447', N'123456')
INSERT [dbo].[accounts] ([account], [password]) VALUES (N'stas51447d', N'123456')
/****** Object:  Default [DF_cards_type]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 02/26/2015 22:03:27 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
