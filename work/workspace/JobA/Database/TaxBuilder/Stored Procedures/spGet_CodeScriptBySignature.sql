if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_CodeScriptBySignature]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_CodeScriptBySignature]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.spGet_CodeScriptBySignature	@RETURNTYPE tinyint,
							@BOOLCOUNT smallint = 0,
							@INTCOUNT smallint = 0,
							@STRCOUNT smallint = 0,
							@DATECOUNT smallint = 0,
							@RATIOCOUNT smallint = 0,
							@MONEYCOUNT smallint = 0,
							@IMAGECOUNT smallint = 0
AS
begin
  select a.Code_ID, a.Code_Name,  substring(a.Code_Syntax, 1, 200) as Syntax
  from CodeScript a, CodeScriptParameterCount b
  where a.Code_ID = b.Code_ID
  and a.Return_Enum_DataType = @RETURNTYPE
  and b.BoolParm = @BOOLCOUNT
  and b.IntParm = @INTCOUNT
  and b.StrParm = @STRCOUNT
  and b.DateParm = @DATECOUNT
  and b.RatioParm = @RATIOCOUNT
  and b.MoneyParm = @MONEYCOUNT
  and b.ImageParm = @IMAGECOUNT
  order by Syntax


end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

