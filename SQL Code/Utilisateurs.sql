USE [SmartVigilance]
GO

/****** Object:  Table [dbo].[Utilisateurs]    Script Date: 13/11/2014 17:28:23 ******/
DROP TABLE [dbo].[Utilisateurs]
GO

/****** Object:  Table [dbo].[Utilisateurs]    Script Date: 13/11/2014 17:28:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Utilisateurs](
	[ID] [int] NOT NULL,
	[Nom] [varchar](20) NOT NULL,
	[Prenom] [varchar](20) NOT NULL,
	[Adresse] [varchar](50) NULL,
	[NTel] [char](15) NOT NULL,
	[Email] [varchar](15) NULL,
	[Photo] [image] NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Utilisateurs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

