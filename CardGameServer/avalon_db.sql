USE [master]
GO
/****** Object:  Database [avalon_db]    Script Date: 02/14/2015 20:58:28 ******/
CREATE DATABASE [avalon_db] ON  PRIMARY 
( NAME = N'avalon_db', FILENAME = N'D:\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\avalon_db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'avalon_db_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\avalon_db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [avalon_db] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [avalon_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [avalon_db] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [avalon_db] SET ANSI_NULLS OFF
GO
ALTER DATABASE [avalon_db] SET ANSI_PADDING OFF
GO
ALTER DATABASE [avalon_db] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [avalon_db] SET ARITHABORT OFF
GO
ALTER DATABASE [avalon_db] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [avalon_db] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [avalon_db] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [avalon_db] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [avalon_db] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [avalon_db] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [avalon_db] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [avalon_db] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [avalon_db] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [avalon_db] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [avalon_db] SET  DISABLE_BROKER
GO
ALTER DATABASE [avalon_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [avalon_db] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [avalon_db] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [avalon_db] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [avalon_db] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [avalon_db] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [avalon_db] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [avalon_db] SET  READ_WRITE
GO
ALTER DATABASE [avalon_db] SET RECOVERY FULL
GO
ALTER DATABASE [avalon_db] SET  MULTI_USER
GO
ALTER DATABASE [avalon_db] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [avalon_db] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'avalon_db', N'ON'
GO
USE [avalon_db]
GO
/****** Object:  Table [dbo].[characters]    Script Date: 02/14/2015 20:58:29 ******/
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
	[character_level] [int] NOT NULL,
	[exp] [int] NOT NULL,
	[games] [int] NOT NULL,
	[wins] [int] NOT NULL,
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
/****** Object:  Table [dbo].[character_templates]    Script Date: 02/14/2015 20:58:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[character_templates](
	[hero_card] [int] NOT NULL,
	[first_card] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[character_cards]    Script Date: 02/14/2015 20:58:29 ******/
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
/****** Object:  Table [dbo].[cards]    Script Date: 02/14/2015 20:58:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cards](
	[id] [int] NOT NULL,
	[card_name] [varchar](50) NOT NULL,
	[hp] [int] NOT NULL,
	[dmg] [int] NOT NULL,
	[def] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 02/14/2015 20:58:29 ******/
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
/****** Object:  Default [DF_characters_character_level]    Script Date: 02/14/2015 20:58:29 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_character_level]  DEFAULT ((1)) FOR [character_level]
GO
/****** Object:  Default [DF_characters_exp]    Script Date: 02/14/2015 20:58:29 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_exp]  DEFAULT ((0)) FOR [exp]
GO
/****** Object:  Default [DF_characters_games]    Script Date: 02/14/2015 20:58:29 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_games]  DEFAULT ((0)) FOR [games]
GO
/****** Object:  Default [DF_characters_wins]    Script Date: 02/14/2015 20:58:29 ******/
ALTER TABLE [dbo].[characters] ADD  CONSTRAINT [DF_characters_wins]  DEFAULT ((0)) FOR [wins]
GO
/****** Object:  Default [DF_character_cards_slot]    Script Date: 02/14/2015 20:58:29 ******/
ALTER TABLE [dbo].[character_cards] ADD  CONSTRAINT [DF_character_cards_slot]  DEFAULT ((-1)) FOR [slot]
GO
