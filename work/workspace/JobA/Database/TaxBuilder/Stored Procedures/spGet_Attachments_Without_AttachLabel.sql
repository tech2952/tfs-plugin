SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Attachments_Without_AttachLabel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Attachments_Without_AttachLabel]
GO

CREATE PROCEDURE dbo.spGet_Attachments_Without_AttachLabel
AS
begin

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation

select distinct n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name
from NavigationNode n, Page p
where p.PageType_EnumValue = 1 --Attachment
and n.Page_ID = p.Page_ID
and n.Navigation_ID = @NAV_ID
and p.Page_ID not in (select g.Page_ID 
	from GraphicObject g, PropertyValuesForGraphic pvg, Page pg 
	where g.GraphicObjectType_EnumValue = 2 -- Label
	and pvg.GraphicObject_ID = g.GraphicObject_ID
	and pvg.Page_ID = pg.Page_ID
	and pvg.Property_Name = 'Appearance.SpecialText'
	and pvg.Property_Value = 7
	and pg.PageType_EnumValue = 1)


order by n.DeveloperRole_ID


end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

