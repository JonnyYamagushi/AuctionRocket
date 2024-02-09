USE master
GO
CREATE DATABASE Auction
GO
USE [Auction]
GO
/****** Object:  Table [dbo].[Auctions]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auctions](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[starts] [datetime] NOT NULL,
	[ends] [datetime] NOT NULL,
 CONSTRAINT [PK_Aictions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auctions_Items]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auctions_Items](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_Auction] [numeric](18, 0) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[brand] [varchar](100) NOT NULL,
	[condition] [numeric](18, 0) NOT NULL,
	[basePrice] [money] NOT NULL,
 CONSTRAINT [PK_Auctions_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[id_Item] [numeric](18, 0) NULL,
	[id_User] [numeric](18, 0) NULL,
	[createdOn] [datetime] NULL,
	[price] [money] NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[email] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Auctions] ON 
GO
INSERT [dbo].[Auctions] ([id], [name], [starts], [ends]) VALUES (CAST(1 AS Numeric(18, 0)), N'Elite Motorcycles', CAST(N'2024-02-07T00:00:00.000' AS DateTime), CAST(N'2024-02-10T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Auctions] OFF
GO
SET IDENTITY_INSERT [dbo].[Auctions_Items] ON 
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Neiman Marcus Limited Edition Fighter', N'Neiman Marcus', CAST(0 AS Numeric(18, 0)), 11000000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Ecosse ES1 Superbike', N'Custom', CAST(1 AS Numeric(18, 0)), 3600000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'BMS Nehmesis', N'Yamaha', CAST(2 AS Numeric(18, 0)), 3000000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Medusa de Tarhan Telli', N'Custom', CAST(0 AS Numeric(18, 0)), 1000000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'Harley-Davidson Cosmic Starship', N'Harley-Davidson', CAST(1 AS Numeric(18, 0)), 1000000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'1949 E90 AJS Porcupine', N'AJS', CAST(2 AS Numeric(18, 0)), 7000000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'1939 Brough Superior SS100', N'Custom', CAST(0 AS Numeric(18, 0)), 5000000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'1971 Harley-Davidson XR-750', N'Harley-Davidson', CAST(1 AS Numeric(18, 0)), 3500000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'1946 Vincent Black Lightning', N'Vicente HRD', CAST(2 AS Numeric(18, 0)), 2600000.0000)
GO
INSERT [dbo].[Auctions_Items] ([id], [id_Auction], [name], [brand], [condition], [basePrice]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'1935 Indian Scout', N'Indian Motorcycle Manufacturing Company', CAST(1 AS Numeric(18, 0)), 2500000.0000)
GO
SET IDENTITY_INSERT [dbo].[Auctions_Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Offers] ON 
GO
SET IDENTITY_INSERT [dbo].[Offers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([id], [name], [email]) VALUES (CAST(1 AS Numeric(18, 0)), N'Ana Silva', N'ana.silva@example.com')
GO
INSERT [dbo].[Users] ([id], [name], [email]) VALUES (CAST(2 AS Numeric(18, 0)), N'Pedro Santos', N'pedro.santos@example.com')
GO
INSERT [dbo].[Users] ([id], [name], [email]) VALUES (CAST(3 AS Numeric(18, 0)), N'Maria Oliveira', N'maria.oliveira@example.com')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Auctions_Items]  WITH CHECK ADD  CONSTRAINT [FK_Auctions_Items_Auctions] FOREIGN KEY([id_Auction])
REFERENCES [dbo].[Auctions] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Auctions_Items] CHECK CONSTRAINT [FK_Auctions_Items_Auctions]
GO
/****** Object:  StoredProcedure [dbo].[CreateOffer]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateOffer]
    @Id_Item INT,
    @Id_User INT,
    @Price DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [Auction].[dbo].[Offers] (id_Item, id_User, createdOn, price)
    VALUES (@Id_Item, @Id_User, GETDATE(), @Price);
	SELECT SCOPE_IDENTITY();
END;
GO
/****** Object:  StoredProcedure [dbo].[ExistUser]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistUser]
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
	
    IF EXISTS (SELECT 1 FROM [Auction].[dbo].[Users] WHERE [email] = @Email)
    BEGIN
        Select 1
    END
    ELSE
    BEGIN
        Select 0
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetActiveAuctions]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetActiveAuctions]
AS
BEGIN
    -- Seleciona dados da tabela Auctions
    SELECT *
    FROM Auctions AS Auction
    WHERE (GETDATE() BETWEEN Auction.starts AND Auction.ends);

    -- Seleciona dados da tabela Auctions_Items com junção
    SELECT Items.*
    FROM Auctions_Items AS Items
    INNER JOIN Auctions AS Auction ON Items.id_Auction = Auction.Id
    WHERE (GETDATE() BETWEEN Auction.starts AND Auction.ends);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 09/02/2024 17:04:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUser]
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
	
    SELECT * FROM [Auction].[dbo].[Users] WHERE [email] = @Email
END;
GO
