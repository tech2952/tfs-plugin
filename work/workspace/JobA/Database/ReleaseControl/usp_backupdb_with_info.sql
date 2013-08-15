USE [master]
GO

/****** Object:  StoredProcedure [dbo].[usp_backupdb_with_info]    Script Date: 02/07/2011 15:50:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_backupdb_with_info]
 @dbname sysname, 
 @backup_location varchar(1000),
 @backupname varchar(128),
 @backupdescription varchar(2048)
as
-- This proc will run a full db backup for a database name passed as a parameter
-- The backup will be overlayed and has a file name of dbname.bak, which can't be overridden
-- Optionally a directory or share, without a trailing backslash, can be passed as a parameter
-- If no directory is passed as a parameter, the backup location will default to F:\da\dba_archive
declare @myCommand nvarchar(1000)
set @myCommand='BACKUP DATABASE ' + 
				'[' +
				@dbname + 
				']' +
				' to disk=''' + @backup_location + '\' + @dbname + '.bak''' + 
				' with format,' +
				' name=''' + @backupname + ''',' +
				' description=''' + @backupdescription + ''''
				
select @myCommand

exec sp_executesql @myCommand

GO

