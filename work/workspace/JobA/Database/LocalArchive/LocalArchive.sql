SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomLetters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomLetters](
	[Firm] [int] NULL,
	[Account] [int] NULL,
	[TaxYear] [int] NULL,
	[FName] [text] NULL,
	[Master] [bit] NULL,
	[CustomFirm] [bit] NULL,
	[CustomAcct] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[AccessTime] [datetime] NULL,
	[ModifyTime] [datetime] NULL,
	[FSize] [int] NULL,
	[Doc] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetArchiveID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetArchiveID]
	-- Add the parameters for the stored procedure here
	@LOCATOR_ID nchar(8),
    @XMLVERSION int,
	@ARCHIVENO int output
AS
BEGIN
  	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  select @ARCHIVENO = 0

  select @ARCHIVENO = ArchiveNo
  from PntXMLVersion
  where LocatorID = @LOCATOR_ID
  and XMLVerNo = @XMLVERSION
    
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locators]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locators](
	[LocatorID] [nchar](8) NOT NULL,
	[TaxYear] [int] NULL,
	[TaxPayerCompanyName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Locators] PRIMARY KEY CLUSTERED 
(
	[LocatorID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PntXMLVersion]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PntXMLVersion](
	[ArchiveNo] [int] IDENTITY(1,1) NOT NULL,
	[PrintXML] [varbinary](max) NULL,
	[LocatorID] [nchar](8) NOT NULL,
	[Compare] [bit] NULL,
	[PrintDesc] [nvarchar](100) NULL,
	[UserName] [nvarchar](15) NULL,
	[FileTimeStamp] [datetime] NULL,
	[PrintXMLPath] [nvarchar](255) NULL,
	[LastModifyTime] [datetime] NULL,
	[XMLVerNo] [int] NOT NULL,
 CONSTRAINT [PK_PntXMLVersion] PRIMARY KEY CLUSTERED 
(
	[ArchiveNo] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CreatePrintXMLVersion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreatePrintXMLVersion]
	-- Add the parameters for the stored procedure here
	@LOCATOR_ID nchar(8),
	@COMPARE bit,
	@PRINTDESC  nvarchar(100),
	@USERNAME nvarchar(15),
	@FILETIMESTAMP datetime,
	@PRINTXMLPATH nvarchar(255),
    @ARCHIVENO int output,
    @XMLVERSION int output
AS
BEGIN
  declare @CURRENT datetime
  declare @PRINTXML varbinary(max)
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  select @XMLVERSION = 0
  select @ARCHIVENO = 0
  if exists (select 1 from Locators
			 where LocatorID = @LOCATOR_ID)
  begin  --Locator Exists?

    select @XMLVERSION = isnull(max(XMLVerNo),0) + 1
    from PntXMLVersion
    where LocatorID = @LOCATOR_ID

    select @PRINTXML = 0x0
    select @CURRENT = CURRENT_TIMESTAMP
 
    insert into PntXMLVersion (PrintXML, LocatorID, Compare, PrintDesc, UserName, FileTimeStamp, 
							   PrintXMLPath, LastModifyTime, XMLVerNo)
    values (@PRINTXML, @LOCATOR_ID, @COMPARE, @PRINTDESC,@USERNAME, @FILETIMESTAMP, @PRINTXMLPATH, 
		     @CURRENT, @XMLVERSION)

    select @ARCHIVENO = ArchiveNo
    from PntXMLVersion
    where LocatorID = @LOCATOR_ID
    and LastModifyTime = @CURRENT
    and FileTimeStamp = @FILETIMESTAMP
    and PrintDesc = @PRINTDESC
    and UserName = @USERNAME
    and XMLVerNo = @XMLVERSION

  end --Locator Exists?
    
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CreateLocator]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_CreateLocator] 
	-- Add the parameters for the stored procedure here
	@LOCATOR_ID nchar(8), 
	@TAXYEAR int,
	@COMPANYNAME nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	If not exists (select 1 from Locators
					where LocatorID = @LOCATOR_ID)
    BEGIN  --insert
	  insert into Locators (LocatorID, TaxYear, TaxPayerCompanyName)
	  values (@LOCATOR_ID, @TAXYEAR, @COMPANYNAME)

    END  --insert
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_ReadLocator]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_ReadLocator] 
	-- Add the parameters for the stored procedure here
	@LOCATOR_ID nchar(8), 
	@TAXYEAR int output,
	@COMPANYNAME nvarchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	If exists (select 1 from Locators
					where LocatorID = @LOCATOR_ID)
    BEGIN  --update
	  select @TAXYEAR = TaxYear, @COMPANYNAME = TaxPayerCompanyName
	  from Locators
	  where LocatorID = @LOCATOR_ID

      --select @TAXYEAR, @COMPANYNAME
    END  --update
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdateLocator]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_UpdateLocator] 
	-- Add the parameters for the stored procedure here
	@LOCATOR_ID nchar(8), 
	@TAXYEAR int,
	@COMPANYNAME nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	If exists (select 1 from Locators
					where LocatorID = @LOCATOR_ID)
    BEGIN  --update
	  update Locators 
	  set TaxYear = @TAXYEAR, TaxPayerCompanyName = @COMPANYNAME

    END  --update
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_WriteXMLImage]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_WriteXMLImage]
	-- Add the parameters for the stored procedure here
	@LOCATOR_ID nchar(8),
    @XMLVERSION int
AS
BEGIN
   declare @PRINTXML varbinary(max)
   
  	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  select @PRINTXML = PrintXML
  from PntXMLVersion
  where LocatorID = @LOCATOR_ID
  and XMLVerNo = 10

  Update PntXMLVersion
  set PrintXML.WRITE(@PRINTXML,0,null)
  where LocatorID = @LOCATOR_ID
  and XMLVerNo = @XMLVERSION
    
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetPrintXML]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetPrintXML]
	-- Add the parameters for the stored procedure here
	@ARCHIVENO int
AS
BEGIN
  --declare @PRINTXML varbinary(max)
  	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  select isnull(PrintXML, 0x0)
  from PntXMLVersion
  where ArchiveNo = @ARCHIVENO
    
END
' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PntXMLVersion_Locators]') AND parent_object_id = OBJECT_ID(N'[dbo].[PntXMLVersion]'))
ALTER TABLE [dbo].[PntXMLVersion]  WITH CHECK ADD  CONSTRAINT [FK_PntXMLVersion_Locators] FOREIGN KEY([LocatorID])
REFERENCES [dbo].[Locators] ([LocatorID])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Related to Locator table' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N'PntXMLVersion', @level2type=N'CONSTRAINT', @level2name=N'FK_PntXMLVersion_Locators'

