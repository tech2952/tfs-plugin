IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spAudit_NewerVersionsOfFormsExist' 
	   AND 	  type = 'P')
    DROP PROCEDURE spAudit_NewerVersionsOfFormsExist
GO

CREATE PROCEDURE spAudit_NewerVersionsOfFormsExist 
	
AS
BEGIN

select nn.DeveloperRole_ID, nn.Navigation_Node_ID, nn.Node_Name, nn.Page_ID, i1.Document_Code --, p.Page_Name, p.Page_ID, i1.Document_Code, i1.Version as OldVersion, i2.Version as NewVersion, i2.ImageInfo_ID
from Page p, PropertyValuesForPage pvp, ImageInfo i1, ImageInfo i2, NavigationNode nn
where pvp.Page_ID = p.Page_ID
and p.Page_ID = nn.Page_ID
and nn.Navigation_ID = 1
and pvp.Property_Name = 'Page.Background.ImageInfo_ID'
and pvp.Property_Value = i1.ImageInfo_ID
and i1.Document_Code = i2.Document_Code
and i1.Version < i2.Version
and i2.Version = (select max(i3.Version) from ImageInfo i3
					where i3.Document_Code = i2.Document_Code)
order by nn.Navigation_Node_ID


END
GO