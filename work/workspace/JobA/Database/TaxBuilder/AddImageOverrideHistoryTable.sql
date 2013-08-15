if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[History_ImageOverride]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	drop table [dbo].[History_ImageOverride]
GO

CREATE TABLE [dbo].[History_ImageOverride](
	[UserId] [nvarchar](255) not null,
	[FormId] [nvarchar](50) not null,
	[DateTime] [datetime] null
)

GO

