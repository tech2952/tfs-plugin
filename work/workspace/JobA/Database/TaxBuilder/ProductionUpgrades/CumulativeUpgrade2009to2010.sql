--Script to Upgrade TaxBuilder2009 to TaxBuilder2010 Schema
--TFS 84879, 60608, 84020, 84644, 88713


/*************  Table Updates     *****************/

ALTER TABLE [dbo].[DeveloperName]
  ADD [IsDA] [booleanvalue] NULL

GO

ALTER TABLE [dbo].[Enterprise_Information]
  ADD [ImageDB_ConnectionString] [varchar] (300) NULL

GO

ALTER TABLE [GraphicObject]
ALTER COLUMN [PositionY] int

GO

ALTER TABLE [GraphicObject]
ALTER COLUMN [PositionX] int

GO

insert into Enum_GraphicObjectType (Enum_Value, Enum_Description)
values (24, 'Watermark')

insert into Enum_GraphicObjectType (Enum_Value, Enum_Description)
values (25, 'HeaderBoundary')

insert into Enum_GraphicObjectType (Enum_Value, Enum_Description)
values (26, 'FooterBoundary')


--watermark
insert into enum_Pagetype 
values (11, 'CustomLetter')

insert into enum_Pagetype 
values (12, 'WatermarkTemplate')


update Enterprise_Information
set Product_Year = 2010, DB_Version = 4.13, 
	ImageDB_ConnectionString = 'data source=cr-fcsql-a02r,1600;initial catalog=TaxBuilderImages;integrated security=SSPI;persist security info=False;packet size=4096'


GO





/*************  Update Procs     *****************/
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

GO

/****** Object:  StoredProcedure [dbo].[spGet_GraphicObjectsThatAreOutOfBounds]    Script Date: 07/06/2010 12:47:00 ******/
ALTER PROCEDURE [dbo].[spGet_GraphicObjectsThatAreOutOfBounds] AS

declare @NAV_ID int
declare @LetterLongSide int
declare @ShortSide int 
declare @LegalLongSide int

select @LetterLongSide = 3250
select @ShortSide = 2520
select @LegalLongSide = 4150


select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation

--Portrait, letter paper
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g.Page_ID,g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
from GraphicObject g, Page p, NavigationNode n
where g.Page_ID = p.Page_ID
and g.Page_Id = n.Page_ID
and (((g.positionx + g.width) > @ShortSide) or ((g.positiony + g.height) > @LetterLongSide))
and n.Navigation_ID = @NAV_ID
and g.Page_ID not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and isnull(p.Parent_Page_ID,0) not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and g.Page_ID not in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)
UNION
--Landscape, letter paper
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g.Page_ID,g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
from GraphicObject g, Page p, NavigationNode n
where g.Page_ID = p.Page_ID
and g.Page_Id = n.Page_ID
and (((g.positionx + g.width) > @LetterLongSide) or ((g.positiony + g.height) > @ShortSide))
and n.Navigation_ID = @NAV_ID
and (g.Page_ID in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1)
	OR isnull(p.Parent_Page_ID,0) in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1))
and g.Page_ID not in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)
UNION
--Portrait, legal paper
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g.Page_ID,g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
from GraphicObject g, Page p, NavigationNode n
where g.Page_ID = p.Page_ID
and g.Page_Id = n.Page_ID
and (((g.positionx + g.width) > @ShortSide) or ((g.positiony + g.height) > @LegalLongSide))
and n.Navigation_ID = @NAV_ID
and g.Page_ID not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and isnull(p.Parent_Page_ID,0) not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and g.Page_ID in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)
UNION
--Landscape, legal paper
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g.Page_ID,g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
from GraphicObject g, Page p, NavigationNode n
where g.Page_ID = p.Page_ID
and g.Page_Id = n.Page_ID
and (((g.positionx + g.width) > @LegalLongSide) or ((g.positiony + g.height) > @ShortSide))
and n.Navigation_ID = @NAV_ID
and (g.Page_ID in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1)
	OR isnull(p.Parent_Page_ID,0) in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1))
and g.Page_ID in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)


GO

/*************  New Procs     *****************/
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
GO

GRANT EXECUTE ON [dbo].[spGet_GraphicsInWrongLayer] TO [G-TTA-TaxBuilder]
GO