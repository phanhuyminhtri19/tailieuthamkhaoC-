USE [SaleDB]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/19/2018 8:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](255) NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [Quantity], [UnitPrice]) VALUES (3, N'C#', 12, CAST(123 AS Decimal(18, 0)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Quantity], [UnitPrice]) VALUES (4, N'Swing', 123, CAST(123 AS Decimal(18, 0)))
INSERT [dbo].[Products] ([ProductID], [ProductName], [Quantity], [UnitPrice]) VALUES (7, N'Java', 456, CAST(87 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Products] OFF
