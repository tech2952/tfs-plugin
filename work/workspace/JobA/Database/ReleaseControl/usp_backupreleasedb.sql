USE [master]
GO

/****** Object:  StoredProcedure [dbo].[usp_BackupReleaseDb]    Script Date: 02/07/2011 15:50:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[usp_BackupReleaseDb]
	@backup_location varchar(1000) = 'D:\ReleaseDailyBackups'
as
-- This proc will run a full db backup for a database name passed as a parameter
-- The backup will be overlayed and has a file name of dbname.bak, which can't be overridden
-- Optionally a directory or share, without a trailing backslash, can be passed as a parameter
-- If no directory is passed as a parameter, the backup location will default to F:\da\dba_archive
declare @dbname sysname
declare @CurrentDate nvarchar(10)
declare @myCommand nvarchar(1000)

select @CurrentDate = convert(nvarchar(10),CURRENT_TIMESTAMP, 112)  --convert date into yyyymmdd format

declare Cursor_DBNames insensitive scroll cursor for
select name 
from master.dbo.sysdatabases
where dbid > 5
--and name <> 'MetadataDB'

open     Cursor_DBNames 

fetch from Cursor_DBNames 
into    @dbname

while (@@FETCH_STATUS <> -1)
begin --Cursor_DBNames


	set @myCommand='BACKUP DATABASE ' +@dbname + ' to disk=''' + @backup_location + '\' + @dbname + '_' + @CurrentDate + '.bak''' + ' with init'
	select @myCommand

	exec sp_executesql @myCommand

fetch from Cursor_DBNames 
   into    @dbname
end --Cursor_DBNames
close Cursor_DBNames
deallocate Cursor_DBNames


GO

