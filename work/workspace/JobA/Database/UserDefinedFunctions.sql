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

