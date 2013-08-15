SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Overlapping_Graphics]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Overlapping_Graphics]
GO

CREATE PROCEDURE dbo.spGet_Overlapping_Graphics
AS
begin

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation

select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
from GraphicObject g1, GraphicObject g2, NavigationNode n
where g1.PositionX + g1.Width > g2.PositionX 
and g2.PositionX >= g1.PositionX
and g1.PositionY + g1.Height >= (g2.PositionY + g2.Height)
and (g2.PositionY + g2.Height) > g1.PositionY
and g1.GraphicObject_ID != g2.GraphicObject_ID
and g1.Page_ID = g2.Page_ID
and g1.Page_ID = n.Page_ID
and ((g1.Parent_GraphicObject_ID is null and g2.Parent_GraphicObject_ID is null) or 
(g1.Parent_GraphicObject_ID = g2.Parent_GraphicObject_ID))
and n.Navigation_ID = @NAV_ID
UNION
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, g1.Page_ID, g1.GraphicObject_ID, g1.GraphicObjectType_EnumValue, g1.PositionX, g1.PositionY, g1.GraphicObject_Name, g1.DataType_EnumValue
from GraphicObject g1, GraphicObject g2, NavigationNode n
where g1.PositionX + g1.Width > g2.PositionX 
and g2.PositionX >= g1.PositionX
and g1.PositionY + g1.Height > g2.PositionY
and g2.PositionY >= g1.PositionY
and g1.GraphicObject_ID != g2.GraphicObject_ID
and g1.Page_ID = g2.Page_ID
and g1.Page_ID = n.Page_ID
and ((g1.Parent_GraphicObject_ID is null and g2.Parent_GraphicObject_ID is null) or 
(g1.Parent_GraphicObject_ID = g2.Parent_GraphicObject_ID))
and n.Navigation_ID = @NAV_ID
order by n.DeveloperRole_ID, g1.Page_ID, g1.GraphicObject_ID


end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

