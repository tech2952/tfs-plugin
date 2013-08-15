USE [master]
GO

/****** Object:  StoredProcedure [dbo].[usp_backupdb]    Script Date: 02/07/2011 15:49:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[usp_backupdb] @dbname sysname, @backup_location varchar(1000)
as
-- This proc will run a full db backup for a database name passed as a parameter
-- The backup will be overlayed and has a file name of dbname.bak, which can't be overridden
-- Optionally a directory or share, without a trailing backslash, can be passed as a parameter
-- If no directory is passed as a parameter, the backup location will default to F:\da\dba_archive
declare @myCommand nvarchar(1000)
set @myCommand='BACKUP DATABASE ' +@dbname + ' to disk=''' + @backup_location + '\' + @dbname + '.bak''' + ' with init'
select @myCommand

exec sp_executesql @myCommand
GO

