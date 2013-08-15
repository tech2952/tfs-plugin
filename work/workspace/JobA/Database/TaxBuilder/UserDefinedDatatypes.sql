if exists (select * from dbo.systypes where name = N'booleanvalue')
exec sp_droptype N'booleanvalue'
GO

if exists (select * from dbo.systypes where name = N'fractionvalue')
exec sp_droptype N'fractionvalue'
GO

if exists (select * from dbo.systypes where name = N'numericvalue')
exec sp_droptype N'numericvalue'
GO

if exists (select * from dbo.systypes where name = N'objectdescription')
exec sp_droptype N'objectdescription'
GO

if exists (select * from dbo.systypes where name = N'objectid')
exec sp_droptype N'objectid'
GO

if exists (select * from dbo.systypes where name = N'objectname')
exec sp_droptype N'objectname'
GO

if exists (select * from dbo.systypes where name = N'productyear')
exec sp_droptype N'productyear'
GO

if exists (select * from dbo.systypes where name = N'stringvalue')
exec sp_droptype N'stringvalue'
GO

if exists (select * from dbo.systypes where name = N'xmlstream')
exec sp_droptype N'xmlstream'
GO

setuser
GO

EXEC sp_addtype N'booleanvalue', N'bit', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'fractionvalue', N'numeric(20,9)', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'numericvalue', N'numeric(22,2)', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'objectdescription', N'varchar (100)', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'objectid', N'int', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'objectname', N'varchar (50)', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'productyear', N'smallint', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'stringvalue', N'varchar (500)', N'null'
GO

setuser
GO

setuser
GO

EXEC sp_addtype N'xmlstream', N'text', N'null'
GO

setuser
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DefaultGraphicObjectID]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[DefaultGraphicObjectID]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE FUNCTION dbo.DefaultGraphicObjectID() 
RETURNS int  AS  
BEGIN 
declare @id int

select @id = isnull(NextGraphicObject_ID,1) 
from NextGraphicObject

return @id
 
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

