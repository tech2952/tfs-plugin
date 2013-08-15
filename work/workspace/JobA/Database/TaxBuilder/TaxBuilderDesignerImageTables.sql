if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ImageInfo_ImageObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ImageInfo] DROP CONSTRAINT FK_ImageInfo_ImageObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enterprise_Information]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enterprise_Information]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageObject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageObject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageWatermark]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageWatermark]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[JurisdictionXref]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[JurisdictionXref]
GO


CREATE TABLE [dbo].[Enterprise_Information] (
	[DB_Version] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Product_Year] [productyear] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImageInfo] (
	[ImageInfo_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Version] [numeric](5, 2) NOT NULL ,
	[Image_Name] [objectname] NOT NULL ,
	[Image_ID] [objectid] NOT NULL ,
	[FileName] [objectname] NULL ,
	[Jurisdiction] [varchar] (255) NULL ,
	[Document_Code] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ImageSize] [int] NOT NULL ,
	[ImageType] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[IsDraftForm] [booleanvalue] NOT NULL ,
	[IsRolloverForm] [booleanvalue] NULL,
	[DateCreated] [datetime] NOT NULL ,
	[DateLastSaved] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImageObject] (
	[Image_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[ImageObject] [image] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImageWatermark] (
	[ImageInfo_ID] [objectid] NOT NULL ,
	[WatermarkStatus] [tinyint] NULL ,
	[WatermarkTemplate] [varchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[JurisdictionXref](
	[ImageJurisExtended] [varchar](255) NOT NULL,
	[ImageJuris] [objectname] NULL,
	[EnumJuris] [objectname] NULL,
	[PublicName][objectname] NULL,
 CONSTRAINT [PK_JurisdictionXref] PRIMARY KEY CLUSTERED 
(
	[ImageJurisExtended] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ImageInfo] WITH NOCHECK ADD 
	CONSTRAINT [PK_ImageInfo] PRIMARY KEY  CLUSTERED 
	(
		[ImageInfo_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ImageObject] WITH NOCHECK ADD 
	CONSTRAINT [PK_ImageObject] PRIMARY KEY  CLUSTERED 
	(
		[Image_ID]
	)  ON [PRIMARY] 
GO

CREATE  UNIQUE  INDEX [ImageInfo_DocVersionIndex] ON [dbo].[ImageInfo]([Document_Code], [Version]) ON [PRIMARY]
GO

 CREATE  INDEX [ImageInfo_JurisdictionIndex] ON [dbo].[ImageInfo]([Jurisdiction]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ImageInfo] ADD 
	CONSTRAINT [FK_ImageInfo_ImageObject] FOREIGN KEY 
	(
		[Image_ID]
	) REFERENCES [dbo].[ImageObject] (
		[Image_ID]
	)
GO

ALTER TABLE [dbo].[ImageWatermark] WITH NOCHECK ADD 
	CONSTRAINT [PK_ImageWatermark] PRIMARY KEY  CLUSTERED 
	(
		[ImageInfo_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ImageWatermark] ADD 
	CONSTRAINT [FK_ImageWatermark_ImageInfo] FOREIGN KEY 
	(
		[ImageInfo_ID]
	) REFERENCES [dbo].[ImageInfo] (
		[ImageInfo_ID]
	)
GO

