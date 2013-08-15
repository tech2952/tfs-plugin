if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ImageInfo_ImageObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ImageInfo] DROP CONSTRAINT FK_ImageInfo_ImageObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetImageByCode]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetImageByCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetImagesByList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetImagesByList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetListByYear]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetListByYear]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WriteImage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WriteImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageObject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageObject]
GO

CREATE TABLE [dbo].[ImageInfo] (
	[ImageInfo_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Version] [decimal](5, 2) NOT NULL ,
	[Image_Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Image_ID] [int] NOT NULL ,
	[FileName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Jurisdiction] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ImageSize] [int] NOT NULL ,
	[ImageType] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[IsDraftForm] [bit] NOT NULL ,
	[DateCreated] [datetime] NOT NULL ,
	[DateLastSaved] [datetime] NOT NULL ,
	[Document_Code] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ImageObject] (
	[Image_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ImageObject] [image] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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

ALTER TABLE [dbo].[ImageInfo] ADD 
	CONSTRAINT [FK_ImageInfo_ImageObject] FOREIGN KEY 
	(
		[Image_ID]
	) REFERENCES [dbo].[ImageObject] (
		[Image_ID]
	)
GO

CREATE  INDEX [ImageInfo_DocVersionIndex] ON [dbo].[ImageInfo]([Document_Code], [Version]) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROC dbo.GetImageByCode ( @DocumentCode varchar(50), @Version decimal(5,2) )
AS
BEGIN
	SET NOCOUNT ON

	SELECT i.Document_Code, i.Version, i.Image_Name, i.FileName, i.Jurisdiction, i.IsDraftForm, i.ImageSize, i.DateLastSaved, i.DateCreated, o.ImageObject
	FROM dbo.ImageObject o, (select distinct max(Image_ID) as Image_ID, Document_Code, Version, Image_Name, FileName, Jurisdiction, IsDraftForm, ImageSize, DateLastSaved, DateCreated
				  from ImageInfo
				  group by Document_Code, Version, Image_Name, FileName, Jurisdiction, IsDraftForm, ImageSize, DateLastSaved, DateCreated) as i
	WHERE i.Image_ID = o.Image_ID 
	AND i.Document_Code = @DocumentCode 
	AND  i.Version = @Version

	SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE PROC dbo.GetImagesByList ( @ImageList varchar(4096) )
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @DocHandle int

	EXEC sp_xml_preparedocument @DocHandle OUTPUT, @ImageList

 	SELECT k.Image_ID, k.Document_Code, k.Version, k.Image_Name, k.FileName, k.Jurisdiction, k.IsDraftForm, k.ImageSize, k.DateLastSaved, k.DateCreated, o.ImageObject
	FROM dbo.ImageObject AS o, dbo.ImageInfo k
		JOIN (  SELECT DISTINCT max(i.ImageInfo_ID) as ImageInfo_ID, i.Document_Code, i.Version
   			FROM  dbo.ImageInfo AS i
   				JOIN OPENXML (@DocHandle, '/ROOT/H',1) WITH (DC varchar(50), V decimal(5,2)) AS x 
   				ON i.Document_Code = x.DC AND i.Version = x.V
   			GROUP BY i.Document_Code, i.Version) AS j
  		ON k.ImageInfo_ID = j.ImageInfo_ID
  	WHERE o.Image_ID = k.Image_ID
	
	EXEC sp_xml_removedocument @DocHandle 

	SET NOCOUNT OFF
END


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE PROC dbo.GetListByYear ( @Year varchar(16) )
AS
BEGIN
	SET NOCOUNT ON

	SELECT k.Document_Code, k.Version, k.Image_Name, k.FileName, k.Jurisdiction, k.IsDraftForm, k.ImageSize, k.DateLastSaved, k.DateCreated
	FROM dbo.ImageObject AS o, dbo.ImageInfo k, 
		(SELECT DISTINCT MAX(ImageInfo_ID) as ImageInfo_ID, Document_Code, Version
		 FROM dbo.ImageInfo
		 WHERE (SUBSTRING(Document_Code, 1, 1) = SUBSTRING(@Year, LEN(@Year), 1)  --Get year-specific forms
	   	 OR SUBSTRING(Document_Code, 1, 1) > '9') --Get non-year-specific forms
		 GROUP BY Document_Code, Version ) j
	where k.ImageInfo_ID = j.ImageInfo_ID
	and o.Image_ID = k.Image_ID
	ORDER BY k.Document_Code, k.Version

	SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROC dbo.WriteImage ( @DocumentCode varchar(10), @Version decimal(5,2), @ImageName varchar(50), @FileName varchar(50),
                             @Jurisdiction varchar(50), @ImageSize int, @ImageType varchar(50), @IsDraftForm bit,
                             @DateCreated datetime, @DateLastSaved datetime, @ImageData image )
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @ImageID int
	DECLARE @ImageInfoID int

        if exists (select 1 from ImageInfo WHERE Document_Code = @DocumentCode AND Version = @Version)
	begin  -- DocumentCode / Version exists
	   select @ImageInfoID = ImageInfo_ID, @ImageID = Image_ID
	   from ImageInfo
	   where Document_Code = @DocumentCode
	   and Version = @Version

	   update ImageInfo
	   set Image_Name = @ImageName, FileName = @FileName ,Jurisdiction = @Jurisdiction ,ImageSize = @ImageSize ,
		ImageType = @ImageType ,IsDraftForm = @IsDraftForm ,DateCreated = @DateCreated, DateLastSaved = @DateLastSaved
	   where ImageInfo_ID = @ImageInfoID

	   update ImageObject
	   set ImageObject = @ImageData
	   where Image_ID = @ImageID

	end  -- DocumentCode / Version exists
	else
	begin -- DocumentCode / Version does not exist
	   INSERT INTO ImageObject (ImageObject)
	   VALUES (@ImageData)
	
	   select @ImageID = SCOPE_IDENTITY()

	   INSERT INTO ImageInfo (Version, Image_Name, Image_ID, FileName, Jurisdiction, ImageSize, 
			       ImageType, IsDraftForm, DateCreated, DateLastSaved, Document_Code)
	   VALUES (@Version, @ImageName, @ImageID, @FileName, @Jurisdiction, @ImageSize,
                @ImageType, @IsDraftForm, @DateCreated, @DateLastSaved, @DocumentCode)

	end  -- DocumentCode / Version does not exist
	

	SET NOCOUNT OFF
END
GO

drop table #myUsers
GO
   CREATE TABLE #myUsers
	( 
		zUserName sysname collate database_default Null ,
		zGroupName sysname collate database_default Null ,
		zLoginName sysname collate database_default Null ,
		zDefDBName sysname collate database_default Null ,
		zUID smallint Null ,zSID varbinary(85) Null 
	)

INSERT INTO #myUsers exec sp_helpuser

-- ASPNET
DECLARE @ExistingAspName varchar(100)
DECLARE @TheAspLogin varchar(100)
SET @ExistingAspName = (SELECT zLoginName FROM #myUsers WHERE zUserName like '%ASPNET')
SET @TheAspLogin = (SELECT name FROM [master].[dbo].syslogins WHERE name LIKE '%ASPNET')

IF (@ExistingAspName IS NULL) AND (@TheAspLogin IS NOT NULL)
BEGIN
	EXEC sp_grantdbaccess @TheAspLogin
	EXEC ('GRANT  EXECUTE  ON [dbo].[GetListByYear]  TO [' + @TheAspLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[GetImagesByList]  TO [' + @TheAspLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[GetImageByCode]  TO [' + @TheAspLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[WriteImage]  TO [' + @TheAspLogin + ']')
	SELECT @TheAspLogin + ' User added.'
END

-- NETWORK SERVICE
DECLARE @ExistingNetName varchar(100)
DECLARE @TheNetLogin varchar(100)
SET @ExistingNetName = (SELECT zLoginName FROM #myUsers WHERE zUserName like '%NETWORK SERVICE')
SET @TheNetLogin = (SELECT name FROM [master].[dbo].syslogins WHERE name LIKE '%NETWORK SERVICE')

IF @ExistingNetName IS NULL AND @TheNetLogin IS NOT NULL
BEGIN
	EXEC ('EXEC sp_grantdbaccess [' + @TheNetLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[GetListByYear]  TO [' + @TheNetLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[GetImagesByList]  TO [' + @TheNetLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[GetImageByCode]  TO [' + @TheNetLogin + ']')
	EXEC ('GRANT  EXECUTE  ON [dbo].[WriteImage]  TO [' + @TheNetLogin + ']')
	SELECT @TheNetLogin + ' User added.'
END

drop table #myUsers

GO
