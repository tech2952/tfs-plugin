-- =============================================
-- This procedure returns current values to the calling program
-- =============================================

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spReturnCurrentValues' 
	   AND 	  type = 'P')
    DROP PROCEDURE spReturnCurrentValues
GO

CREATE PROCEDURE spReturnCurrentValues (	@LOCATORID int,
						@PRODUCTYEAR smallint,
						@STARTTIME datetime,						
						@OUTPUTERROR int output)
	
AS
BEGIN

   select lor.Record_ID as Record_ID, lor.Page_ID as Page_ID, lor.GraphicObject_ID as GraphicObject_ID, lor.Row_DisplayOrder as Row_DisplayOrder,     
   (case lor.DataType_EnumValue when 0 then convert(varchar(500),lov.BooleanValue)
			when 1 then convert(varchar(500),lov.NumericValue)
			when 2 then lov.StringValue
			when 3 then convert(varchar(500),lov.DateValue)
			when 7 then convert(varchar(500),lov.FractionValue)
			when 8 then convert(varchar(500),lov.NumericValue)
		end) as DataValue
   from LocatorObjectRecord lor, TempComputeFields tcf, LocatorObjectValue lov
   where tcf.FullComputeStartTime = @STARTTIME
   and tcf.Page_ID = lor.Page_ID
   and tcf.GraphicObject_ID = lor.GraphicObject_ID
   and lor.Product_Year = @PRODUCTYEAR
   and lor.Locator_ID = @LOCATORID
   and lov.Record_ID = lor.Record_ID
   and lov.DataSource_EnumValue = lor.DatasourceUsed

   order by lor.GraphicObject_ID, lor.Page_ID, lor.Row_DisplayOrder

   select @OUTPUTERROR = @@ERROR

if (@OUTPUTERROR = 0)
begin
  delete from TempComputeFields
  where FullComputeStartTime = @STARTTIME
end

END
GO

-- =============================================
-- This procedure returns current values to the calling program
-- =============================================

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spReturnRecordRowAndLineage' 
	   AND 	  type = 'P')
    DROP PROCEDURE spReturnRecordRowAndLineage
GO

CREATE PROCEDURE spReturnRecordRowAndLineage (	@LOCATORID int,
												@PRODUCTYEAR smallint,
												@STARTTIME datetime,
												@OUTPUTERROR int output)
	
AS
BEGIN

   select lor.Record_ID, lor.Record_Lineage, lor.Row_DisplayOrder
   from LocatorObjectRecord lor, TempComputeFields tcf
   where tcf.FullComputeStartTime = @STARTTIME
   and tcf.Page_ID = lor.Page_ID
   and tcf.GraphicObject_ID = lor.GraphicObject_ID
   and lor.Product_Year = @PRODUCTYEAR
   and lor.Locator_ID = @LOCATORID
   
   select @OUTPUTERROR = @@ERROR

END
GO


