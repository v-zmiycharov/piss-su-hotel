SET QUOTED_IDENTIFIER ON
GO

USE [master]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'PissHotel')
BEGIN
	ALTER DATABASE [PissHotel] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [PissHotel]
END	
GO

CREATE DATABASE [PissHotel]
GO

USE [PissHotel]
GO

/****** Object:  Table [dbo].[Rooms] ******/
CREATE TABLE [dbo].[Rooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[TitleBG] [nvarchar](200) NOT NULL,
	[TitleEN] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	PRIMARY KEY ([RoomId])	
)
GO

/****** Object:  Table [dbo].[Albums] ******/
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[TitleBG] [nvarchar](200) NOT NULL,
	[TitleEN] [nvarchar](200) NOT NULL,
	PRIMARY KEY ([AlbumId])	
)
GO

/****** Object:  Table [dbo].[Users] ******/
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
	PRIMARY KEY ([UserId]),
	UNIQUE NONCLUSTERED([UserName])	
)
GO

/****** Object:  Table [dbo].[webpages_Membership] ******/
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
	PRIMARY KEY ([UserId]) 
)
GO

/****** Object:  Table [dbo].[webpages_Roles] ******/
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	PRIMARY KEY ([RoleId]),
	UNIQUE NONCLUSTERED ([RoleName])
)
GO

/****** Object:  Table [dbo].[webpages_UsersInRoles] ******/
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	PRIMARY KEY  ([UserId], [RoleId]),
    CONSTRAINT [FK_UsersInRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_UsersInRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
)
GO

SET IDENTITY_INSERT [dbo].[Rooms] ON
INSERT INTO [dbo].[Rooms] ([RoomId],[TitleBG],[TitleEN],[Price]) VALUES (1, 'Двойна стая', 'Double room', 40)
INSERT INTO [dbo].[Rooms] ([RoomId],[TitleBG],[TitleEN],[Price]) VALUES (2, 'Мансардна стая', 'Garret room', 46)
INSERT INTO [dbo].[Rooms] ([RoomId],[TitleBG],[TitleEN],[Price]) VALUES (3, 'Апартамент стая', 'Apartment', 56)
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO

SET IDENTITY_INSERT [dbo].[Albums] ON
INSERT INTO [dbo].[Albums] ([AlbumId],[TitleBG],[TitleEN]) VALUES (1, 'Ресторант', 'Restaurant')
INSERT INTO [dbo].[Albums] ([AlbumId],[TitleBG],[TitleEN]) VALUES (2, 'Местността', 'The village')
INSERT INTO [dbo].[Albums] ([AlbumId],[TitleBG],[TitleEN]) VALUES (3, 'Помещения', 'Premises')
INSERT INTO [dbo].[Albums] ([AlbumId],[TitleBG],[TitleEN]) VALUES (4, 'Природа', 'Nature')
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserId], [UserName]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(0x0000A31600A978F6 AS DateTime), NULL, 1, NULL, 0, N'AKq29J1UfStrJLHBmNHszXvpe1juiHxL/4htf7rouOXyRUzu8psbazAF7u3QEBz/EQ==', CAST(0x0000A31600A978F6 AS DateTime), N'', NULL, NULL)
GO
