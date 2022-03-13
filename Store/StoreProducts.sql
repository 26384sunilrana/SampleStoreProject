USE [Mall]
GO

/****** Object:  Table [dbo].[StoreProducts]    Script Date: 3/13/2022 10:20:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StoreProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ean] [nvarchar](20) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_StoreProducts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

