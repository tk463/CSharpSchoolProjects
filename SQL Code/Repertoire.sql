USE [SmartVigilance]
GO

ALTER TABLE [dbo].[Repertoire] DROP CONSTRAINT [FK_Repertoire_Utilisateurs]
GO

/****** Object:  Table [dbo].[Repertoire]    Script Date: 13/11/2014 17:27:50 ******/
DROP TABLE [dbo].[Repertoire]
GO

/****** Object:  Table [dbo].[Repertoire]    Script Date: 13/11/2014 17:27:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Repertoire](
	[IDUtilisateur] [int] NOT NULL,
	[IDContact] [int] NOT NULL,
	[Nom] [varchar](20) NOT NULL,
	[Prenom] [varchar](20) NOT NULL,
	[Adresse] [varchar](50) NULL,
	[NTel] [char](15) NOT NULL,
	[Email] [varchar](15) NULL,
	[Photo] [image] NULL,
	[Priorite] [int] NOT NULL,
 CONSTRAINT [PK_Repertoire] PRIMARY KEY CLUSTERED 
(
	[IDUtilisateur] ASC,
	[IDContact] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Repertoire]  WITH CHECK ADD  CONSTRAINT [FK_Repertoire_Utilisateurs] FOREIGN KEY([IDUtilisateur])
REFERENCES [dbo].[Utilisateurs] ([ID])
GO

ALTER TABLE [dbo].[Repertoire] CHECK CONSTRAINT [FK_Repertoire_Utilisateurs]
GO

