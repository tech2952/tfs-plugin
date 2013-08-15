USE [MetadataDB]
GO
/****** Object:  User [tlr\G-TTA-TaxBuilder]    Script Date: 08/30/2010 15:55:00 ******/
EXEC dbo.sp_grantdbaccess @loginame = N'TLR\G-TTA-TaxBuilder', @name_in_db = N'tlr\G-TTA-TaxBuilder'
GO
/****** Object:  Table [dbo].[ReleaseMetadata]    Script Date: 08/30/2010 15:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseMetadata](
	[SnapShotName] [varchar](255) NOT NULL,
	[BasedOn] [varchar](255) NOT NULL,
	[Description] [varchar](4000) NOT NULL,
	[Server] [varchar](255) NOT NULL,
	[Database] [varchar](255) NOT NULL,
	[CreatedBy] [varchar](255) NOT NULL,
	[TbVersion] [varchar](255) NOT NULL,
	[BackupDate] [datetime] NOT NULL,
	[DataLogicalName] [varchar](255) NOT NULL,
	[LogLogicalName] [varchar](255) NOT NULL,
	[ProductYear] [varchar](255) NOT NULL,
	[AppPrefix] [varchar](255) NOT NULL,
 CONSTRAINT [PK_ReleaseMetadata] PRIMARY KEY CLUSTERED 
(
	[SnapShotName] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
