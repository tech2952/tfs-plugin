SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property]
GO

CREATE PROCEDURE dbo.spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property
AS
begin

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation

select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
from GraphicObject g, Page p, NavigationNode n
where g.GraphicObject_ID not in (select GraphicObject_ID from PropertyValuesForGraphic where Property_Name = 'SourceField.FADSField')
and g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
and g.Page_ID = p.Page_ID
and p.PageType_EnumValue in (0,1,3)--pages that are TaxForms, Attachments, or TaxForm Living Templates
and g.Page_ID = n.Page_ID
and n.Navigation_ID = @NAV_ID
order by n.DeveloperRole_ID, g.Page_ID, g.GraphicObject_ID

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

