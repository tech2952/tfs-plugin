USE [TaxBuilder2010]
GO
/****** Object:  StoredProcedure [dbo].[spGet_Overlapping_Graphics]    Script Date: 03/25/2010 14:55:15 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROCEDURE [dbo].[spGet_Overlapping_Graphics]
	@IsSingleAudit bit,
	@PageId int
AS
begin

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation


IF(@IsSingleAudit = 0)
BEGIN
--Default Layer
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID	
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION --Now check against a page's Living Template
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION --Now flip the page with the Living Template in checking for the overlap placement
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	--TFS 66441 Non-DefaultLayers
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID	
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION --Now check against a page's Living Template
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION --Now flip the page with the Living Template in checking for the overlap placement
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	order by n.DeveloperRole_ID, g1.Page_ID, g1.GraphicObject_ID
END
ELSE
BEGIN
--Default Layer
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION --Now check against a page's Living Template
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION --Now flip the page with the Living Template in checking for the overlap placement
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = @PageId
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = @PageId
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
--TFS 66441 ADD CHECKS AGAINST THE PVG TABLE FOR LAYER PROPERTIES
	and not exists (select 1 from PropertyValuesForGraphic pvg1
					where pvg1.Page_ID = g1.Page_ID
					and pvg1.GraphicObject_ID = g1.GraphicObject_ID
					and pvg1.Property_Name = 'Graphic.LayerName')
	and not exists (select 1 from PropertyValuesForGraphic pvg2
					where pvg2.Page_ID = g2.Page_ID
					and pvg2.GraphicObject_ID = g2.GraphicObject_ID
					and pvg2.Property_Name = 'Graphic.LayerName')
--TFS 66441 Non-DefaultLayers
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION --Now check against a page's Living Template
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g1.Page_ID = @PageId
	and g1.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g2.Page_ID
	and g1.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION --Now flip the page with the Living Template in checking for the overlap placement
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3)  --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX --g1 is to the left of g2
	and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height) --g1 bottom is lower than g2 bottom
	and (g2.PositionY + g2.Height) > (g1.PositionY + 3) --g1 is higher than g2 bottom
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = @PageId
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g2.Page_ID, g2.GraphicObject_ID, g2.GraphicObjectType_EnumValue, g2.PositionX, g2.PositionY, g2.GraphicObject_Name, g2.DataType_EnumValue
	from GraphicObject g1, GraphicObject g2, NavigationNode n, Page p, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
	where g1.PositionX + g1.Width > (g2.PositionX + 3) --g1 right border crosses g2 left border
	and g2.PositionX >= g1.PositionX  --g1 starts to the left of g2
	and g1.PositionY + g1.Height > (g2.PositionY + 3) --g1 bottom crosses g2 top
	and g2.PositionY >= g1.PositionY  --g1 starts higher than g2
	and g1.GraphicObject_ID != g2.GraphicObject_ID
	and g2.Page_ID = @PageId
	and g2.Page_ID = p.Page_ID
	and p.Parent_Page_ID = g1.Page_ID
	and g2.Page_ID = n.Page_ID
    and g1.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
    and g2.GraphicObjectType_EnumValue not in (3,4,6,8) --Groupbox, Entitybox, ParsedValueGroup, RelationalGroup
	and n.Navigation_ID = @NAV_ID
	and pvg1.Page_ID = g1.Page_ID
	and pvg1.GraphicObject_ID = g1.GraphicObject_ID
	and pvg1.Property_Name = 'Graphic.LayerName'
	and pvg2.Page_ID = g2.Page_ID
	and pvg2.GraphicObject_ID = g2.GraphicObject_ID
	and pvg2.Property_Name = 'Graphic.LayerName'
	and pvg1.Property_Value = pvg2.Property_Value
	order by n.DeveloperRole_ID, g1.Page_ID, g1.GraphicObject_ID

END

end




