USE [SmartVigilance]
GO

ALTER TABLE [dbo].[Interventions] DROP CONSTRAINT [FK_Interventions_Repertoire]
GO

/****** Object:  Table [dbo].[Interventions]    Script Date: 13/11/2014 17:24:39 ******/
DROP TABLE [dbo].[Interventions]
GO

/****** Object:  Table [dbo].[Interventions]    Script Date: 13/11/2014 17:24:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Interventions](
	[IDUtilisateur] [int] NOT NULL,
	[IDContact] [int] NOT NULL,
	[DateHeure] [datetime] NOT NULL,
	[UrgenceLevel] [int] NOT NULL,
	[GPSLocation] [geography] NOT NULL,
	[Data] [ntext] NULL,
 CONSTRAINT [PK_Interventions] PRIMARY KEY CLUSTERED 
(
	[IDUtilisateur] ASC,
	[IDContact] ASC,
	[DateHeure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Interventions]  WITH CHECK ADD  CONSTRAINT [FK_Interventions_Repertoire] FOREIGN KEY([IDUtilisateur], [IDContact])
REFERENCES [dbo].[Repertoire] ([IDUtilisateur], [IDContact])
GO

ALTER TABLE [dbo].[Interventions] CHECK CONSTRAINT [FK_Interventions_Repertoire]
GO

