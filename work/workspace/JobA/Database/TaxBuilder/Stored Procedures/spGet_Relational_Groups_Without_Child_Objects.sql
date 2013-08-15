SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

Create  PROCEDURE spGet_Relational_Groups_Without_Child_Objects AS

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation
print 'navigation id: ' + cast(@NAV_ID as varchar(10))


select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g.Page_ID,g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
from GraphicObject g, Page p, NavigationNode n
where g.GraphicObjectType_EnumValue in (8) --Textbox, ParsedValueGroup
and g.Page_ID = p.Page_ID
and p.PageType_EnumValue in (0,1,3)--pages that are TaxForms, Attachments, or TaxForm Living Templates
and g.Page_ID = n.Page_ID
and n.Navigation_ID = @NAV_ID
and g.graphicobject_id not in (
				select distinct  g.Parent_graphicobject_id				
				from GraphicObject g, Page p, NavigationNode n
				where g.Parent_graphicobject_id in(
								select distinct g.GraphicObject_ID		
								from GraphicObject g, Page p, NavigationNode n
								where g.GraphicObjectType_EnumValue in (8) 
								and g.Page_ID = p.Page_ID
								and p.PageType_EnumValue in (0,1,3)--pages that are TaxForms, Attachments, or TaxForm Living Templates
					   			and g.Page_ID = n.Page_ID
				                                )	
				and g.Page_ID = p.Page_ID
				and p.PageType_EnumValue in (0,1,3)--pages that are TaxForms, Attachments, or TaxForm Living Templates
				and g.Page_ID = n.Page_ID
				and n.Navigation_ID = @NAV_ID
			     )
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

