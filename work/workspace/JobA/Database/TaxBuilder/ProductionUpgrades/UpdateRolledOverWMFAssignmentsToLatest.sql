--update images to latest version if it is currently assigned to a rolled-over version of the form
USE [TaxBuilder2012]
GO

update pvp
set pvp.Property_Value = ii2.ImageInfo_ID
from PropertyValuesForPage pvp, TaxBuilderImages.dbo.ImageInfo ii, NavigationNode nn, 
	TaxBuilderImages.dbo.ImageInfo ii2, Navigation n
where pvp.Property_Name = 'Page.Background.ImageInfo_ID'
and pvp.Property_Value = ii.ImageInfo_ID
and nn.Navigation_ID = n.Navigation_ID
and n.NavigationType_EnumValue = 1 --runtime print tree
and isnull(nn.Page_ID,0) > 0
and nn.Page_ID = pvp.Page_ID
and ii.Version = 0.00
and ii.Version < ii2.Version
and ii.Document_Code = ii2.Document_Code
and ii2.Version = (select max(ii3.Version)
					from TaxBuilderImages.dbo.ImageInfo ii3
					where ii3.Document_Code = ii.Document_Code)




