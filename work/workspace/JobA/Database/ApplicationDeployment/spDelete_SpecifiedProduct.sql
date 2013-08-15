if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDelete_SpecifiedProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDelete_SpecifiedProduct]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.spDelete_SpecifiedProduct 	@PRODUCTNAME varchar(50)
AS
begin

declare @PRINTNAVIGATION tinyint

ALTER TABLE [dbo].[NavigationNode] DROP CONSTRAINT FK_NavigationNode_Page

select @PRINTNAVIGATION = Navigation_ID
from Navigation
where Product_Name = @PRODUCTNAME
and NavigationType_EnumValue = 1


delete from PropertyValuesForGraphic
where Page_ID in (select distinct Page_ID 
from NavigationNode
where Navigation_ID = @PRINTNAVIGATION
and isnull(Page_ID,0) <> 0)

delete  from PropertyValuesForPage
where Page_ID in (select distinct Page_ID 
from NavigationNode
where Navigation_ID = @PRINTNAVIGATION
and isnull(Page_ID,0) <> 0)

delete  from PropertyValuesForNode
where Navigation_Node_ID in (select Navigation_Node_ID
							from NavigationNode
							where Navigation_ID = @PRINTNAVIGATION)

--delete FADSConstraintDependency on Page
delete fcd
from CodeScriptAssignment csa, GraphicObject g, FADSConstraintDependency fcd
where csa.Dependent_Page_ID = g.Page_ID
and csa.CodeScriptAssignment_ID = fcd.CodeScriptAssignment_ID
and csa.Dependent_ID = g.GraphicObject_ID
and csa.CodeType_EnumValue = 0
and g.Page_ID in (select distinct Page_ID 
				  from NavigationNode
				  where Navigation_ID = @PRINTNAVIGATION
				  and isnull(Page_ID,0) <> 0)


--delete FADSConstraintDependency on Node
delete fcd
from CodeScriptAssignment csa, NavigationNode nn, FADSConstraintDependency fcd
where csa.Dependent_Page_ID = 0
and csa.Dependent_ID = nn.Navigation_Node_ID
and csa.CodeScriptAssignment_ID = fcd.CodeScriptAssignment_ID
and csa.CodeType_EnumValue = 0
and nn.Navigation_ID = @PRINTNAVIGATION

--delete from CodeScriptAssignment for Page
delete csa
from CodeScriptAssignment csa, GraphicObject g
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and csa.CodeType_EnumValue = 0
and g.Page_ID in (select distinct Page_ID 
				  from NavigationNode
				  where Navigation_ID = @PRINTNAVIGATION
				  and isnull(Page_ID,0) <> 0)

--delete from CodeScriptAssignment for Node
delete csa
from CodeScriptAssignment csa, NavigationNode nn
where csa.Dependent_Page_ID = 0
and csa.Dependent_ID = nn.Navigation_Node_ID
and csa.CodeType_EnumValue = 0
and nn.Navigation_ID = @PRINTNAVIGATION


delete  from GraphicObject
where Page_ID in (select distinct Page_ID 
from NavigationNode
where Navigation_ID = @PRINTNAVIGATION
and isnull(Page_ID,0) <> 0)

delete  from Page
where Page_ID in (select distinct Page_ID 
from NavigationNode
where Navigation_ID = @PRINTNAVIGATION
and isnull(Page_ID,0) <> 0)

delete pvn
from PropertyValuesForNode pvn, NavigationNode nn
where pvn.Navigation_Node_ID = nn.Navigation_Node_ID 
and nn.Navigation_ID = 1 --Designer
and nn.Page_ID not in (select Page_ID from Page)

delete from NavigationNode
where Navigation_ID = @PRINTNAVIGATION

delete from NavigationNode
where Navigation_ID = 1 --Designer
and Page_ID not in (select Page_ID from Page)

delete from Navigation
where Navigation_ID = @PRINTNAVIGATION

--delete unused CodeScriptTestCaseValues
delete cstcv
from CodeScriptTestCaseValues cstcv, CodeScriptParameters csp, CodeScript cs
where cstcv.Parameter_ID = csp.Parameter_ID
and csp.Code_ID = cs.Code_ID
and isnull(cs.IsSystemCode,0) = 0
and cs.Code_ID not in (select distinct CodeScript_ID
						from CodeScriptAssignment)

--delete unused CodeScriptTestCase
delete cstc
from CodeScriptTestCase cstc, CodeScript cs
where cstc.Code_ID = cs.Code_ID
and isnull(cs.IsSystemCode,0) = 0
and cs.Code_ID not in (select distinct CodeScript_ID
						from CodeScriptAssignment)

--delete unused CodeScriptParameters
delete csp
from CodeScriptParameters csp, CodeScript cs
where csp.Code_ID = cs.Code_ID
and isnull(cs.IsSystemCode,0) = 0
and cs.Code_ID not in (select distinct CodeScript_ID
						from CodeScriptAssignment) 

--delete unused CodeScriptDiagnostics
delete d
from Diagnostic d, CodeScript cs
where d.CodeScript_ID = cs.Code_ID
and isnull(cs.IsSystemCode,0) = 0
and cs.Code_ID not in (select distinct CodeScript_ID
						from CodeScriptAssignment) 

--delete unused CodeScript
delete from CodeScript
where isnull(IsSystemCode,0) = 0
and Code_ID not in (select distinct CodeScript_ID
						from CodeScriptAssignment) 

ALTER TABLE [dbo].[NavigationNode] ADD 
	CONSTRAINT [FK_NavigationNode_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)

--clear out the unused FADS Fields for Product
delete from FADSField
where Product_Name = @PRODUCTNAME
and FADS_Field_ID not in (select Property_Value
							from PropertyValuesForNode
							where Property_Name = 'LoopName.FADSFieldID'
							UNION
							select Property_Value
							from PropertyValuesForGraphic
							where Property_Name = 'SourceField.FADSFieldID')

delete fs 
from FADSScreen fs
where fs.Product_Name = @PRODUCTNAME
and fs.FADS_Screen not in (select ff.FADS_Screen
						    from FADSField ff
							where ff.Product_Name = @PRODUCTNAME
							and ff.Product_Name = fs.Product_Name
							and ff.FADS_Area = fs.FADS_Area)

delete fa
from FADSArea fa
where fa.Product_Name = @PRODUCTNAME
and fa.FADS_Area not in (select fs.FADS_Area
						  from FADSScreen fs
						  where fs.Product_Name = @PRODUCTNAME
						  and fa.Product_Name = fs.Product_Name
						  and fs.FADS_Area = fa.FADS_Area)

--Now, delete any prior-year unused image files.  We could delete unused current-year files, but then they wouldn't be available
--if the users wanted to make a late change that incorporated these images.
delete ii
from ImageInfo ii, Enterprise_Information ei
where substring(ii.Document_Code, 1,1) = substring(cast((ei.Product_Year - 1) as char(4)), 4,1)
and ii.ImageInfo_ID not in (select distinct Property_Value
							from PropertyValuesForPage
							where Property_Name = 'Page.Background.ImageInfo_ID')

delete
from ImageObject
where Image_ID not in (select Image_ID
						from ImageInfo)


end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO