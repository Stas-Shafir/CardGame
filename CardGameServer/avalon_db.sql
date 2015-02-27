USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 02/27/2015 21:47:31 ******/
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
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (45, N'stas51447d', N'ZeT', N'Эйлад', 14, 17031, 77, 59, 96109)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (46, N'stas51447', N'Dies', N'Маэдар', 14, 12437, 79, 19, 1655)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (51, N'stas5144', N'ewruio', N'Эвиин', 1, 132, 1, 0, 0)
INSERT [dbo].[characters] ([id], [account], [name], [hero_name], [character_level], [exp], [games], [wins], [score]) VALUES (52, N'stas514', N'sdfghj', N'Эвиин', 2, 629, 4, 1, 0)
SET IDENTITY_INSERT [dbo].[characters] OFF
/****** Object:  Table [dbo].[character_templates]    Script Date: 02/27/2015 21:47:31 ******/
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
/****** Object:  Table [dbo].[character_cards]    Script Date: 02/27/2015 21:47:31 ******/
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
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (81, 45, 6, 1)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (201, 45, 5, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (202, 46, 6, 2)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (203, 45, 5, 3)
INSERT [dbo].[character_cards] ([id], [char_id], [card_id], [slot]) VALUES (205, 45, 5, 10)
SET IDENTITY_INSERT [dbo].[character_cards] OFF
/****** Object:  Table [dbo].[cards]    Script Date: 02/27/2015 21:47:31 ******/
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
/****** Object:  Table [dbo].[accounts]    Script Date: 02/27/2015 21:47:31 ******/
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
/****** Object:  Default [DF_cards_type]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[cards] ADD  CONSTRAINT [DF_cards_type]  DEFAULT ((1)) FOR [type]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
/****** Object:  Default [DF_characters_character_level]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_characters_score]    Script Date: 02/27/2015 21:47:31 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_score]  DEFAULT ((0)) FOR [score]
GO
