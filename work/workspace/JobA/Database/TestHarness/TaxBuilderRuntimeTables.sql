if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ClientCustomer_Client]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ClientCustomer] DROP CONSTRAINT FK_ClientCustomer_Client
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ClientLocator_Client]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ClientLocator] DROP CONSTRAINT FK_ClientLocator_Client
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ClientCustomer_CustomerName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ClientCustomer] DROP CONSTRAINT FK_ClientCustomer_CustomerName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerLocatorAuthorization_CustomerName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerLocatorAuthorization] DROP CONSTRAINT FK_CustomerLocatorAuthorization_CustomerName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerLocatorAuthorization_CustomerName1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerLocatorAuthorization] DROP CONSTRAINT FK_CustomerLocatorAuthorization_CustomerName1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerAuthorization_CustomerName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerNamespaceAuthorization] DROP CONSTRAINT FK_CustomerAuthorization_CustomerName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerNamespaceAuthorization_CustomerName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerNamespaceAuthorization] DROP CONSTRAINT FK_CustomerNamespaceAuthorization_CustomerName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerLocatorAuthorization_Enum_AuthorizationType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerLocatorAuthorization] DROP CONSTRAINT FK_CustomerLocatorAuthorization_Enum_AuthorizationType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerNamespaceAuthorization_Enum_AuthorizationType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerNamespaceAuthorization] DROP CONSTRAINT FK_CustomerNamespaceAuthorization_Enum_AuthorizationType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorObjectRecord_Enum_DataSource]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorObjectRecord] DROP CONSTRAINT FK_LocatorObjectRecord_Enum_DataSource
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorObjectValue_Enum_DataSource]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorObjectValue] DROP CONSTRAINT FK_LocatorObjectValue_Enum_DataSource
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorObjectRecord_Enum_DataType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorObjectRecord] DROP CONSTRAINT FK_LocatorObjectRecord_Enum_DataType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ClientLocator_Locator]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ClientLocator] DROP CONSTRAINT FK_ClientLocator_Locator
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorNodeComputedValue_Locator]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorNodeComputedValue] DROP CONSTRAINT FK_LocatorNodeComputedValue_Locator
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorObjectRow_Locator]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorObjectRecord] DROP CONSTRAINT FK_LocatorObjectRow_Locator
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorRollover_Locator]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorRollover] DROP CONSTRAINT FK_LocatorRollover_Locator
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorRollover_Locator1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorRollover] DROP CONSTRAINT FK_LocatorRollover_Locator1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorObjectValue_LocatorImage]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorObjectValue] DROP CONSTRAINT FK_LocatorObjectValue_LocatorImage
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_LocatorObjectValue_LocatorObjectRecord]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[LocatorObjectValue] DROP CONSTRAINT FK_LocatorObjectValue_LocatorObjectRecord
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Client]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Client]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClientCustomer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ClientCustomer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClientLocator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ClientLocator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerLocatorAuthorization]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CustomerLocatorAuthorization]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerName]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CustomerName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerNamespaceAuthorization]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CustomerNamespaceAuthorization]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enterprise_Information]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enterprise_Information]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_AuthorizationType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_AuthorizationType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_DataSource]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_DataSource]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_DataType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_DataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Firm]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Firm]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Locator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Locator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocatorGridRow]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocatorGridRow]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocatorImage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocatorImage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocatorNodeComputedValue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocatorNodeComputedValue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocatorObjectRecord]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocatorObjectRecord]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocatorObjectValue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocatorObjectValue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocatorRollover]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocatorRollover]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TempComputeFields]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TempComputeFields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TempComputedResults]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TempComputedResults]
GO

CREATE TABLE [dbo].[Client] (
	[Product_Year] [productyear] NOT NULL ,
	[Client_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Client_Name] [objectname] NOT NULL ,
	[Firm_Code] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Account_Code] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Product_License] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClientCustomer] (
	[Product_Year] [productyear] NOT NULL ,
	[Client_ID] [objectid] NOT NULL ,
	[Customer_ID] [objectid] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ClientLocator] (
	[Product_Year] [productyear] NOT NULL ,
	[Client_ID] [objectid] NOT NULL ,
	[Locator_ID] [objectid] NOT NULL ,
	[IsTaxDefault] [booleanvalue] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CustomerLocatorAuthorization] (
	[Product_Year] [productyear] NOT NULL ,
	[Customer_ID] [objectid] NOT NULL ,
	[Authorized_Locator_ID] [objectid] NOT NULL ,
	[AuthorizationType_EnumValue] [tinyint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CustomerName] (
	[Customer_ID] [objectid] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[WindowsDomainLogin] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AlternateLogin] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FirstName] [objectname] NULL ,
	[LastName] [objectname] NULL ,
	[IsAdministrator] [booleanvalue] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CustomerNamespaceAuthorization] (
	[Product_Year] [productyear] NOT NULL ,
	[Customer_ID] [objectid] NOT NULL ,
	[Authorized_Namespace] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AuthorizationType_EnumValue] [tinyint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enterprise_Information] (
	[DB_Version] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_AuthorizationType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_DataSource] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_DataType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Firm] (
	[Product_Year] [productyear] NOT NULL ,
	[Firm_Code] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Firm_Name] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Locator] (
	[Product_Year] [productyear] NOT NULL ,
	[Locator_ID] [objectid] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Locator_Name] [varchar] (250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TaxPeriod] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LocatorGridRow] (
	[GridRecord_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Product_Year] [productyear] NULL ,
	[Locator_ID] [objectid] NULL ,
	[Page_ID] [objectid] NULL ,
	[GraphicObject_ID] [objectid] NULL ,
	[Record_Lineage] [objectid] NULL ,
	[Row_Count] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LocatorImage] (
	[LocatorImage_ID] [objectid] NOT NULL ,
	[LocatorImage] [image] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[LocatorNodeComputedValue] (
	[Product_Year] [productyear] NOT NULL ,
	[Locator_ID] [objectid] NOT NULL ,
	[Navigation_Node_ID] [objectid] NOT NULL ,
	[Constraint_Result] [booleanvalue] NULL ,
	[Save_History] [xmlstream] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[LocatorObjectRecord] (
	[Record_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Product_Year] [productyear] NOT NULL ,
	[Locator_ID] [objectid] NOT NULL ,
	[Page_ID] [objectid] NOT NULL ,
	[GraphicObject_ID] [objectid] NOT NULL ,
	[DataType_EnumValue] [tinyint] NOT NULL ,
	[Row_DisplayOrder] [int] NULL ,
	[Record_Lineage] [int] NULL ,
	[DatasourceUsed] [tinyint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[LocatorObjectValue] (
	[Record_ID] [objectid] NOT NULL ,
	[DataSource_EnumValue] [tinyint] NOT NULL ,
	[BooleanValue] [booleanvalue] NULL ,
	[StringValue] [stringvalue] NULL ,
	[NumericValue] [numericvalue] NULL ,
	[DateValue] [datetime] NULL ,
	[FractionValue] [fractionvalue] NULL ,
	[LocatorImage_ID] [objectid] NULL ,
	[Save_History] [xmlstream] NULL ,
	[DateLastSaved] [datetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[LocatorRollover] (
	[Product_Year] [productyear] NOT NULL ,
	[Target_Locator_ID] [objectid] NOT NULL ,
	[Rollover_Namespace] [varchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Source_Locator_ID] [objectid] NULL ,
	[Rollover_History] [xmlstream] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[TempComputeFields] (
	[FullComputeStartTime] [datetime] NOT NULL ,
	[Page_ID] [objectid] NOT NULL ,
	[GraphicObject_ID] [objectid] NOT NULL ,
	[Parent_GraphicObject_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TempComputedResults] (
	[Product_Year] [productyear] NOT NULL ,
	[Locator_ID] [objectid] NOT NULL ,
	[FullComputeStartTime] [datetime] NOT NULL ,
	[Page_ID] [objectid] NOT NULL ,
	[GraphicObject_ID] [objectid] NOT NULL ,
	[Row_DisplayOrder] [int] NOT NULL ,
	[Record_Lineage] [int] NOT NULL ,
	[DataType_EnumValue] [tinyint] NULL ,
	[Computed_Value] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client] WITH NOCHECK ADD 
	CONSTRAINT [PK_Client] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Client_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ClientCustomer] WITH NOCHECK ADD 
	CONSTRAINT [PK_ClientCustomer] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Client_ID],
		[Customer_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ClientLocator] WITH NOCHECK ADD 
	CONSTRAINT [PK_ClientLocator] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Client_ID],
		[Locator_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CustomerLocatorAuthorization] WITH NOCHECK ADD 
	CONSTRAINT [PK_CustomerLocatorAuthorization] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Customer_ID],
		[Authorized_Locator_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CustomerName] WITH NOCHECK ADD 
	CONSTRAINT [PK_CustomerName] PRIMARY KEY  CLUSTERED 
	(
		[Customer_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CustomerNamespaceAuthorization] WITH NOCHECK ADD 
	CONSTRAINT [PK_CustomerNamespaceAuthorization] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Customer_ID],
		[Authorized_Namespace]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enterprise_Information] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enterprise_Information] PRIMARY KEY  CLUSTERED 
	(
		[DB_Version]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_AuthorizationType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_AuthorizationType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_DataSource] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_DataSource] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_DataType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_DataType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Firm] WITH NOCHECK ADD 
	CONSTRAINT [PK_Firm] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Firm_Code]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Locator] WITH NOCHECK ADD 
	CONSTRAINT [PK_Locator] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Locator_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LocatorGridRow] WITH NOCHECK ADD 
	CONSTRAINT [PK_LocatorGridRow] PRIMARY KEY  CLUSTERED 
	(
		[GridRecord_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LocatorImage] WITH NOCHECK ADD 
	CONSTRAINT [PK_LocatorImage] PRIMARY KEY  CLUSTERED 
	(
		[LocatorImage_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LocatorNodeComputedValue] WITH NOCHECK ADD 
	CONSTRAINT [PK_LocatorNodeComputedValue] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Locator_ID],
		[Navigation_Node_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LocatorObjectValue] WITH NOCHECK ADD 
	CONSTRAINT [PK_LocatorObjectValue] PRIMARY KEY  CLUSTERED 
	(
		[Record_ID],
		[DataSource_EnumValue]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LocatorRollover] WITH NOCHECK ADD 
	CONSTRAINT [PK_LocatorRollover] PRIMARY KEY  CLUSTERED 
	(
		[Product_Year],
		[Target_Locator_ID],
		[Rollover_Namespace]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[TempComputeFields] WITH NOCHECK ADD 
	CONSTRAINT [PK_TempComputeFields] PRIMARY KEY  CLUSTERED 
	(
		[FullComputeStartTime],
		[Page_ID],
		[GraphicObject_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[TempComputedResults] WITH NOCHECK ADD 
	CONSTRAINT [PK_TempComputedResults] PRIMARY KEY  CLUSTERED 
	(
		[Locator_ID],
		[Product_Year],
		[FullComputeStartTime],
		[Page_ID],
		[GraphicObject_ID],
		[Row_DisplayOrder],
		[Record_Lineage]
	)  ON [PRIMARY] 
GO

 CREATE  CLUSTERED  INDEX [IX_LocatorObjectRecord] ON [dbo].[LocatorObjectRecord]([Product_Year], [Locator_ID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LocatorObjectRecord] ADD 
	CONSTRAINT [PK_LocatorObjectRecord] PRIMARY KEY  NONCLUSTERED 
	(
		[Record_ID]
	)  ON [PRIMARY] 
GO

 CREATE  INDEX [LocatorObjectRecord_Index_1] ON [dbo].[LocatorObjectRecord]([Product_Year], [Locator_ID], [Page_ID], [GraphicObject_ID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClientCustomer] ADD 
	CONSTRAINT [FK_ClientCustomer_Client] FOREIGN KEY 
	(
		[Product_Year],
		[Client_ID]
	) REFERENCES [dbo].[Client] (
		[Product_Year],
		[Client_ID]
	),
	CONSTRAINT [FK_ClientCustomer_CustomerName] FOREIGN KEY 
	(
		[Customer_ID]
	) REFERENCES [dbo].[CustomerName] (
		[Customer_ID]
	)
GO

ALTER TABLE [dbo].[ClientLocator] ADD 
	CONSTRAINT [FK_ClientLocator_Client] FOREIGN KEY 
	(
		[Product_Year],
		[Client_ID]
	) REFERENCES [dbo].[Client] (
		[Product_Year],
		[Client_ID]
	),
	CONSTRAINT [FK_ClientLocator_Locator] FOREIGN KEY 
	(
		[Product_Year],
		[Locator_ID]
	) REFERENCES [dbo].[Locator] (
		[Product_Year],
		[Locator_ID]
	)
GO

ALTER TABLE [dbo].[CustomerLocatorAuthorization] ADD 
	CONSTRAINT [FK_CustomerLocatorAuthorization_CustomerName] FOREIGN KEY 
	(
		[Customer_ID]
	) REFERENCES [dbo].[CustomerName] (
		[Customer_ID]
	),
	CONSTRAINT [FK_CustomerLocatorAuthorization_CustomerName1] FOREIGN KEY 
	(
		[Customer_ID]
	) REFERENCES [dbo].[CustomerName] (
		[Customer_ID]
	),
	CONSTRAINT [FK_CustomerLocatorAuthorization_Enum_AuthorizationType] FOREIGN KEY 
	(
		[AuthorizationType_EnumValue]
	) REFERENCES [dbo].[Enum_AuthorizationType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[CustomerNamespaceAuthorization] ADD 
	CONSTRAINT [FK_CustomerAuthorization_CustomerName] FOREIGN KEY 
	(
		[Customer_ID]
	) REFERENCES [dbo].[CustomerName] (
		[Customer_ID]
	),
	CONSTRAINT [FK_CustomerNamespaceAuthorization_CustomerName] FOREIGN KEY 
	(
		[Customer_ID]
	) REFERENCES [dbo].[CustomerName] (
		[Customer_ID]
	),
	CONSTRAINT [FK_CustomerNamespaceAuthorization_Enum_AuthorizationType] FOREIGN KEY 
	(
		[AuthorizationType_EnumValue]
	) REFERENCES [dbo].[Enum_AuthorizationType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[LocatorNodeComputedValue] ADD 
	CONSTRAINT [FK_LocatorNodeComputedValue_Locator] FOREIGN KEY 
	(
		[Product_Year],
		[Locator_ID]
	) REFERENCES [dbo].[Locator] (
		[Product_Year],
		[Locator_ID]
	)
GO

ALTER TABLE [dbo].[LocatorObjectRecord] ADD 
	CONSTRAINT [FK_LocatorObjectRecord_Enum_DataSource] FOREIGN KEY 
	(
		[DatasourceUsed]
	) REFERENCES [dbo].[Enum_DataSource] (
		[Enum_Value]
	),
	CONSTRAINT [FK_LocatorObjectRecord_Enum_DataType] FOREIGN KEY 
	(
		[DataType_EnumValue]
	) REFERENCES [dbo].[Enum_DataType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_LocatorObjectRow_Locator] FOREIGN KEY 
	(
		[Product_Year],
		[Locator_ID]
	) REFERENCES [dbo].[Locator] (
		[Product_Year],
		[Locator_ID]
	)
GO

ALTER TABLE [dbo].[LocatorObjectValue] ADD 
	CONSTRAINT [FK_LocatorObjectValue_Enum_DataSource] FOREIGN KEY 
	(
		[DataSource_EnumValue]
	) REFERENCES [dbo].[Enum_DataSource] (
		[Enum_Value]
	),
	CONSTRAINT [FK_LocatorObjectValue_LocatorImage] FOREIGN KEY 
	(
		[LocatorImage_ID]
	) REFERENCES [dbo].[LocatorImage] (
		[LocatorImage_ID]
	),
	CONSTRAINT [FK_LocatorObjectValue_LocatorObjectRecord] FOREIGN KEY 
	(
		[Record_ID]
	) REFERENCES [dbo].[LocatorObjectRecord] (
		[Record_ID]
	)
GO

ALTER TABLE [dbo].[LocatorRollover] ADD 
	CONSTRAINT [FK_LocatorRollover_Locator] FOREIGN KEY 
	(
		[Product_Year],
		[Target_Locator_ID]
	) REFERENCES [dbo].[Locator] (
		[Product_Year],
		[Locator_ID]
	),
	CONSTRAINT [FK_LocatorRollover_Locator1] FOREIGN KEY 
	(
		[Product_Year],
		[Source_Locator_ID]
	) REFERENCES [dbo].[Locator] (
		[Product_Year],
		[Locator_ID]
	)
GO

