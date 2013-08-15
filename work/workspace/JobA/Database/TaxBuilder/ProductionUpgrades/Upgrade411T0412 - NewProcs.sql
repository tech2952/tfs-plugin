USE [TaxBuilder2010]
GO
/****** Object:  StoredProcedure [dbo].[spGet_GraphicsInWrongLayer]    Script Date: 03/25/2010 14:55:15 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_GraphicsInWrongLayer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_GraphicsInWrongLayer]
GO


CREATE PROCEDURE [dbo].[spGet_GraphicsInWrongLayer]
	@IsSingleAudit bit,
	@PageId int
AS
begin

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation


IF(@IsSingleAudit = 0) --multiple page audit
BEGIN

	select nn.DeveloperRole_ID, nn.Navigation_Node_ID, nn.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from NavigationNode nn, GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where nn.Navigation_ID = @NAV_ID
	and nn.Page_ID = g1.Page_ID
	and nn.Page_ID = g2.Page_ID
	and isnull(g1.Parent_GraphicObject_ID,0) > 0
	and g1.Parent_GraphicObject_ID = g2.GraphicObject_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value <> pvg2.Property_Value

END
ELSE --single page audit
BEGIN

	select nn.DeveloperRole_ID, nn.Navigation_Node_ID, nn.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from NavigationNode nn, GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where nn.Navigation_ID = @NAV_ID
	and isnull(nn.Page_ID,0) = @PageId
	and nn.Page_ID = g1.Page_ID
	and nn.Page_ID = g2.Page_ID
	and isnull(g1.Parent_GraphicObject_ID,0) > 0
	and g1.Parent_GraphicObject_ID = g2.GraphicObject_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value <> pvg2.Property_Value

END

end

GRANT EXECUTE on spGet_GraphicsInWrongLayer TO [G-TTA-TaxBuilder]