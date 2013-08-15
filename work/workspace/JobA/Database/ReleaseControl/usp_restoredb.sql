USE [master]
GO

/****** Object:  StoredProcedure [dbo].[usp_restoredb]    Script Date: 02/07/2011 15:50:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_restoredb]
 @dbname			sysname, 
 @backup_file		varchar(1000),
 @datalogicalname	varchar(128),
 @datafilename		varchar(128),
 @loglogicalname	varchar(2048),
 @logfilename		varchar(2048)
as
declare @myCommand nvarchar(1000)

set @myCommand='RESTORE DATABASE ' +
				'[' +
				@dbname + 
				']' +
				' from disk='''+ @backup_file	+ '''' + 
				' with'							+
				' move ''' + @datalogicalname	+ '''' +
				' to   ''' + @datafilename		+ ''',' + 
				' move ''' + @loglogicalname	+ '''' +
				' to   ''' + @logfilename		+ ''''
				
select @myCommand
exec sp_executesql @myCommand
GO

