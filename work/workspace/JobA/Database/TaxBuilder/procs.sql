if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Attachments_Without_AttachLabel]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Attachments_Without_AttachLabel]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_CodeScriptBySignature]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_CodeScriptBySignature]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_CodeScriptParmMappingsCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_CodeScriptParmMappingsCount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_ComputeProcessingInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_ComputeProcessingInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Overlapping_Graphics]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Overlapping_Graphics]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_Relational_Groups_Without_Child_Objects]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_Relational_Groups_Without_Child_Objects]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSet_FADS_Length_And_Precision_In_PropertyTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spSet_FADS_Length_And_Precision_In_PropertyTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_GraphicObjectsThatAreOutOfBounds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_GraphicObjectsThatAreOutOfBounds]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spBuildMyTree]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spBuildMyTree]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spBuildMyCodeScripts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spBuildMyCodeScripts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spBuildBaseScripts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spBuildBaseScripts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCreatePageByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCreatePageByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCreateFADSFieldByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCreateFADSFieldByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCreateGraphicByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCreateGraphicByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCreateNavigationNodeByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCreateNavigationNodeByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_CodeScriptDataTypeMismatches]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_CodeScriptDataTypeMismatches]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAudit_NewerVersionsOfFormsExist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAudit_NewerVersionsOfFormsExist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAudit_CodeScriptCompilation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAudit_CodeScriptCompilation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAudit_CodeScriptTestCaseErrors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spAudit_CodeScriptTestCaseErrors]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_PotentialHyperlinkTargets]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_PotentialHyperlinkTargets]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].spGetFormImageInformationByDeveloperRole') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].spGetFormImageInformationByDeveloperRole
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].spGetFormImageVersionInformationByDeveloperRole') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].spGetFormImageVersionInformationByDeveloperRole
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].spUpdatePageFormImageVersions') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].spUpdatePageFormImageVersions
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].spGetPageGraphicObjectInformation') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].spGetPageGraphicObjectInformation
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].spBuildPrintOrderByNav') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].spBuildPrintOrderByNav
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].spBuildPrintOrderByPage') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].spBuildPrintOrderByPage
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFullDisclosureWatermarkStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFullDisclosureWatermarkStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFullDisclosureFormStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFullDisclosureFormStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spFullDisclosureFormStatusByAssignment]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spFullDisclosureFormStatusByAssignment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_GraphicsInWrongLayer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_GraphicsInWrongLayer]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE dbo.spGet_CodeScriptBySignature	@RETURNTYPE tinyint,
							@BOOLCOUNT smallint = 0,
							@INTCOUNT smallint = 0,
							@STRCOUNT smallint = 0,
							@DATECOUNT smallint = 0,
							@RATIOCOUNT smallint = 0,
							@MONEYCOUNT smallint = 0,
							@IMAGECOUNT smallint = 0
AS
begin

  if (@RETURNTYPE < 255)
  begin --filter on return value data type

    select a.Code_ID, a.Code_Name,  substring(a.Code_Syntax, 1, 200) as Syntax, isnull(a.IsSystemCode,0) as IsSystemCode
    from CodeScript a, CodeScriptParameterCount b
    where a.Code_ID = b.Code_ID
    and a.Return_Enum_DataType = @RETURNTYPE
    and b.BoolParm = @BOOLCOUNT
    and b.IntParm = @INTCOUNT
    and b.StrParm = @STRCOUNT
    and b.DateParm = @DATECOUNT
    and b.RatioParm = @RATIOCOUNT
    and b.MoneyParm = @MONEYCOUNT
    and b.ImageParm = @IMAGECOUNT
    order by Syntax

  end
  else
  begin --do not filter on return value data type
    select a.Code_ID, a.Code_Name,  substring(a.Code_Syntax, 1, 200) as Syntax, isnull(a.IsSystemCode,0) as IsSystemCode
    from CodeScript a, CodeScriptParameterCount b
    where a.Code_ID = b.Code_ID
    and b.BoolParm = @BOOLCOUNT
    and b.IntParm = @INTCOUNT
    and b.StrParm = @STRCOUNT
    and b.DateParm = @DATECOUNT
    and b.RatioParm = @RATIOCOUNT
    and b.MoneyParm = @MONEYCOUNT
    and b.ImageParm = @IMAGECOUNT
  order by Syntax

  end

end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE spGet_CodeScriptDataTypeMismatches  	
	@IsSingleAudit bit,
	@Page_ID as integer 
AS 
BEGIN

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation

IF (@IsSingleAudit = 1)
BEGIN
--select p.Page_ID, p.Page_Name, g.PositionX, g.PositionY, ego.Enum_Description as 'GraphicType', 
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue as 'GraphicType', g.PositionX, g.PositionY, g.GraphicObject_Name, g.GraphicObjectType_EnumValue,
csp.Parameter_Name, (case csp.Parameter_Enum_DataType 
						when 1 then 'Integer'
						when 2 then 'String'
						when 3 then 'Date'
						when 7 then  'Ratio'
						when 8 then 'Money'
						else 'Other'
					 end )as 'ParameterDataType',(case ff.Field_Datatype 
													when 1 then 'Integer'
													when 2 then 'String'
													when 3 then 'Date'
													when 7 then  'Ratio'
													when 8 then 'Money'
													else 'Other'
													end )as 'FieldDataType'
from CodeScriptParameters csp, FADSField ff, FADSConstraintDependency fcd, CodeScriptAssignment csa, Page p,
GraphicObject g, Enum_GraphicObjectType ego,NavigationNode n
where fcd.Parameter_ID = csp.Parameter_ID
and fcd.FADS_Field_ID = ff.FADS_Field_ID
and (( csp.Parameter_Enum_DataType not in (1,7,8)
		AND csp.Parameter_Enum_DataType <> ff.Field_Datatype)
	  or (csp.Parameter_Enum_DataType in (1,7,8)
			AND ff.Field_Datatype not in (1,7,8) ))
and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
and csp.Parameter_Enum_DataType <> 0
and p.Page_ID = @page_ID
and csa.Dependent_Page_ID = p.Page_ID
and p.Page_ID = g.Page_ID
and p.Page_ID = n.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and g.GraphicObjectType_EnumValue = ego.Enum_Value
and n.Navigation_ID = @NAV_ID 
order by p.Page_ID, p.Page_Name, g.PositionX, g.PositionY
END
ELSE
BEGIN
--select p.Page_ID, p.Page_Name, g.PositionX, g.PositionY, ego.Enum_Description as 'GraphicType', 
select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue as 'GraphicType', g.PositionX, g.PositionY, g.GraphicObject_Name, g.GraphicObjectType_EnumValue,
csp.Parameter_Name, (case csp.Parameter_Enum_DataType 
						when 1 then 'Integer'
						when 2 then 'String'
						when 3 then 'Date'
						when 7 then 'Ratio'
						when 8 then 'Money'
						else 'Other'
					 end )as 'ParameterDataType',(case ff.Field_Datatype 
													when 1 then 'Integer'
													when 2 then 'String'
													when 3 then 'Date'
													when 7 then  'Ratio'
													when 8 then 'Money'
													else 'Other'
													end )as 'FieldDataType'
from CodeScriptParameters csp, FADSField ff, FADSConstraintDependency fcd, CodeScriptAssignment csa, Page p,
GraphicObject g, Enum_GraphicObjectType ego,NavigationNode n
where fcd.Parameter_ID = csp.Parameter_ID
and fcd.FADS_Field_ID = ff.FADS_Field_ID
and (( csp.Parameter_Enum_DataType not in (1,7,8)
		AND csp.Parameter_Enum_DataType <> ff.Field_Datatype)
	  or (csp.Parameter_Enum_DataType in (1,7,8)
			AND ff.Field_Datatype not in (1,7,8) ))
and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
and csp.Parameter_Enum_DataType <> 0
and csa.Dependent_Page_ID = p.Page_ID
and p.Page_ID = g.Page_ID
and p.Page_ID = n.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and n.Navigation_ID = @NAV_ID
and g.GraphicObjectType_EnumValue = ego.Enum_Value
order by p.Page_ID, p.Page_Name, g.PositionX, g.PositionY
END
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.spGet_CodeScriptParmMappingsCount
AS
begin

if object_id('dbo.#ParmMappings') is null
begin
   CREATE TABLE dbo.#ParmMappings
	( 
		zPageID int NULL ,
		zObjectID int NULL ,
		zActualParm int NULL ,
		zExpectedParm int NULL 
	)
end

--Populate temporary table with info about objects with code scripts and their parm counts
insert into dbo.#ParmMappings (zPageID, zObjectID, zActualParm, zExpectedParm)
select c.Dependent_Page_ID, c.Dependent_ID, isnull(c.ActualParm,0) as ActualParm, count(d.Parameter_ID) as ExpectedParm
from CodeScriptParameters d, (select a.CodeScriptAssignment_ID, a.Dependent_Page_ID, a.Dependent_ID, a.CodeScript_ID, count(b.Parameter_ID) as ActualParm
				from CodeScriptAssignment a LEFT OUTER JOIN FADSConstraintDependency b
 				ON a.CodeScriptAssignment_ID = b.CodeScriptAssignment_ID
				where a.CodeType_EnumValue = 0 -- TaxForms
				group by a.CodeScriptAssignment_ID, a.Dependent_Page_ID, a.Dependent_ID, a.CodeScript_ID) c
where c.CodeScript_ID = d.Code_ID
group by c.Dependent_Page_ID, c.Dependent_ID, isnull(c.ActualParm,0)
UNION
select c.Dependent_Page_ID, c.Dependent_ID, isnull(c.ActualParm,0) as ActualParm, count(d.Parameter_ID) as ExpectedParm
from CodeScriptParameters d, (select a.CodeScriptAssignment_ID, a.Dependent_Page_ID, a.Dependent_ID, a.CodeScript_ID, count(b.Parameter_ID) as ActualParm
				from CodeScriptAssignment a LEFT OUTER JOIN ComputedObjectDependency b
 				ON a.CodeScriptAssignment_ID = b.CodeScriptAssignment_ID
				where a.CodeType_EnumValue > 0 -- Not TaxForms
				group by a.CodeScriptAssignment_ID, a.Dependent_Page_ID, a.Dependent_ID, a.CodeScript_ID) c
where c.CodeScript_ID = d.Code_ID
group by c.Dependent_Page_ID, c.Dependent_ID, isnull(c.ActualParm,0)
order by c.Dependent_Page_ID, c.Dependent_ID

--Return to the caller a list of those objects with unmapped parms
select * from dbo.#ParmMappings
where zActualParm <> zExpectedParm

end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE spGet_ComputeProcessingInfo (@CODETYPE tinyint,
					      @OUTPUTERROR int output)
	
AS
BEGIN

declare @DETAILLINK tinyint

create table #ProcessInfo (  CodeType_EnumValue tinyint,
				Dependent_ID int,
				Dependent_Page_ID int,
				CodeScript_ID int,
				Return_Enum_DataType tinyint,
				ParameterSource_Page_ID int,
				ParameterSource_Object_ID int,
				Parameter_Enum_DataType tinyint,
				ParameterIsDetail bit,
				ProcessDependentDetail bit,
				Parameter_Position tinyint,
				DependentIsColumn bit,
				ParameterIsColumn bit,
				DependentParent_Object_ID int,
				ParameterParent_Object_ID int,
				Processing_Scheme tinyint
			   )

select @DETAILLINK = 1

insert into #ProcessInfo (CodeType_EnumValue, Dependent_ID, Dependent_Page_ID, CodeScript_ID, Return_Enum_DataType, ParameterSource_Page_ID,
ParameterSource_Object_ID, Parameter_Enum_DataType, ParameterIsDetail, ProcessDependentDetail,
Parameter_Position, DependentIsColumn, ParameterIsColumn, DependentParent_Object_ID, ParameterParent_Object_ID, Processing_Scheme)
select csa.CodeType_EnumValue, csa.Dependent_ID, csa.Dependent_Page_ID, csbsx.BaseCodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, csp.Parameter_Enum_DataType, 1 as ParameterIsDetail, 1 as ProcessDependentDetail, csp.Parameter_Position, 
(case isnull(g1.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as DependentIsColumn, 
(case isnull(g2.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as ParameterIsColumn, isnull(g1.Parent_GraphicObject_ID,0), isnull(g2.Parent_GraphicObject_ID,0), isnull(cod.Processing_Scheme,0)
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp, GraphicObject g1, GraphicObject g2,
	 CodeScriptBaseScriptXref csbsx
where csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScript_ID = csbsx.CodeScript_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and exists (select 1 from DataLink dl2
		where (dl2.LinkSource_Page_ID = csa.Dependent_Page_ID
		or dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID)
		and dl2.LinkType_EnumValue = @DETAILLINK)
and isnull(csa.Dependent_Page_ID,0) = g1.Page_ID
and csa.Dependent_ID = g1.GraphicObject_ID
and cod.ParameterSource_Page_ID = g2.Page_ID
and cod.ParameterSource_Object_ID = g2.GraphicObject_ID
UNION
select csa.CodeType_EnumValue, csa.Dependent_ID, csa.Dependent_Page_ID, csbsx.BaseCodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, csp.Parameter_Enum_DataType, 0 as ParameterIsDetail, 1 as ProcessDependentDetail, csp.Parameter_Position,
(case isnull(g1.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as DependentIsColumn, 
(case isnull(g2.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as ParameterIsColumn, isnull(g1.Parent_GraphicObject_ID,0), isnull(g2.Parent_GraphicObject_ID,0), isnull(cod.Processing_Scheme,0)
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp, GraphicObject g1, GraphicObject g2,
	CodeScriptBaseScriptXref csbsx
where csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScript_ID = csbsx.CodeScript_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and not exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and exists (select 1 from DataLink dl2
		where (dl2.LinkSource_Page_ID = csa.Dependent_Page_ID
		or dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID)
		and dl2.LinkType_EnumValue = @DETAILLINK)
and isnull(csa.Dependent_Page_ID,0) = g1.Page_ID
and csa.Dependent_ID = g1.GraphicObject_ID
and cod.ParameterSource_Page_ID = g2.Page_ID
and cod.ParameterSource_Object_ID = g2.GraphicObject_ID
UNION
select csa.CodeType_EnumValue, csa.Dependent_ID, csa.Dependent_Page_ID, csbsx.BaseCodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, csp.Parameter_Enum_DataType, 1 as ParameterIsDetail, 0 as ProcessDependentDetail, csp.Parameter_Position,
(case isnull(g1.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as DependentIsColumn, 
(case isnull(g2.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as ParameterIsColumn, isnull(g1.Parent_GraphicObject_ID,0), isnull(g2.Parent_GraphicObject_ID,0), isnull(cod.Processing_Scheme,0)
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp, GraphicObject g1, GraphicObject g2,
	CodeScriptBaseScriptXref csbsx
where csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScript_ID = csbsx.CodeScript_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and not exists (select 1 from DataLink dl2
		where (dl2.LinkSource_Page_ID = csa.Dependent_Page_ID
		or dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID)
		and dl2.LinkType_EnumValue = @DETAILLINK)
and isnull(csa.Dependent_Page_ID,0) = g1.Page_ID
and csa.Dependent_ID = g1.GraphicObject_ID
and cod.ParameterSource_Page_ID = g2.Page_ID
and cod.ParameterSource_Object_ID = g2.GraphicObject_ID
UNION
select csa.CodeType_EnumValue, csa.Dependent_ID, csa.Dependent_Page_ID, csbsx.BaseCodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, csp.Parameter_Enum_DataType, 0 as ParameterIsDetail, 0 as ProcessDependentDetail, csp.Parameter_Position,
(case isnull(g1.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as DependentIsColumn, 
(case isnull(g2.Parent_GraphicObject_ID,0)
	when 0 then 0
	else 1
 end) as ParameterIsColumn, isnull(g1.Parent_GraphicObject_ID,0), isnull(g2.Parent_GraphicObject_ID,0), isnull(cod.Processing_Scheme,0)
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp, GraphicObject g1, GraphicObject g2,
	CodeScriptBaseScriptXref csbsx
where csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScript_ID = csbsx.CodeScript_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and not exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and not exists (select 1 from DataLink dl2
		where (dl2.LinkSource_Page_ID = csa.Dependent_Page_ID
		or dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID)
		and dl2.LinkType_EnumValue = @DETAILLINK)
and isnull(csa.Dependent_Page_ID,0) = g1.Page_ID
and csa.Dependent_ID = g1.GraphicObject_ID
and cod.ParameterSource_Page_ID = g2.Page_ID
and cod.ParameterSource_Object_ID = g2.GraphicObject_ID
order by csa.Dependent_ID, csa.Dependent_Page_ID, csbsx.BaseCodeScript_ID, csp.Parameter_Position
 
select @OUTPUTERROR = @@ERROR

if @OUTPUTERROR = 0
begin
select cpi.CodeType_EnumValue, cpi.Dependent_ID, cpi.Dependent_Page_ID, cpi.CodeScript_ID, cpi.Return_Enum_DataType, cpi.ParameterSource_Page_ID,
cpi.ParameterSource_Object_ID, cpi.Parameter_Enum_DataType, cpi.ParameterIsDetail, cpi.ProcessDependentDetail,
cpi.Parameter_Position, cpi.DependentIsColumn, cpi.ParameterIsColumn, dl.LoopingColumn_ID, dl.LinkSource_Page_ID,
cpi.DependentParent_Object_ID, cpi.ParameterParent_Object_ID, cpi.Processing_Scheme
from #ProcessInfo cpi, DataLink dl
where dl.LinkType_EnumValue = @DETAILLINK
and dl.LinkTarget_Page_ID = cpi.Dependent_Page_ID
and isnull(dl.LoopingColumn_ID,0)<> 0
and cpi.CodeType_EnumValue = @CODETYPE
UNION
select cpi.CodeType_EnumValue, cpi.Dependent_ID, cpi.Dependent_Page_ID, cpi.CodeScript_ID, cpi.Return_Enum_DataType, cpi.ParameterSource_Page_ID,
cpi.ParameterSource_Object_ID, cpi.Parameter_Enum_DataType, cpi.ParameterIsDetail, cpi.ProcessDependentDetail,
cpi.Parameter_Position, cpi.DependentIsColumn, cpi.ParameterIsColumn, 0, 0,
cpi.DependentParent_Object_ID, cpi.ParameterParent_Object_ID, cpi.Processing_Scheme
from #ProcessInfo cpi
where cpi.CodeType_EnumValue = @CODETYPE
and not exists (select 1
		  from DataLink dl
		  where dl.LinkType_EnumValue = @DETAILLINK
		  and dl.LinkTarget_Page_ID = cpi.Dependent_Page_ID
		  and isnull(dl.LoopingColumn_ID,0)<> 0)
order by cpi.Dependent_ID, cpi.Dependent_Page_ID, cpi.CodeScript_ID,cpi.Parameter_Position

end

drop table #ProcessInfo

END	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property
	@IsSingleAudit bit,
	@Page_ID as integer
AS
begin

declare @NAV_ID int

select @NAV_ID = Navigation_ID
from Navigation
where NavigationType_EnumValue = 0 --Design Navigation

IF (@IsSingleAudit = 1)
BEGIN
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
	from GraphicObject g, Page p, NavigationNode n
	where g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
	and (g.Page_ID = p.Page_ID
		OR g.Page_ID = p.Parent_Page_ID)
	and p.Page_ID = @Page_ID
	and p.PageType_EnumValue in (0,1,3,9,10)--pages that are TaxForms, Attachments, Reports, Continuations, TaxForm Living Templates
	and p.Page_ID = n.Page_ID
	and n.Navigation_ID = @NAV_ID
	and not exists (select 1 from PropertyValuesForGraphic pvg
							where pvg.Property_Name = 'SourceField.FADSFieldID'
							and (pvg.Page_ID = p.Page_ID
								OR pvg.Page_ID = p.Parent_Page_ID)
							and pvg.GraphicObject_ID = g.GraphicObject_ID)
	UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
	from GraphicObject g, Page p, NavigationNode n, PropertyValuesForGraphic pvg, FADSField ff
	where g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
	and (g.Page_ID = p.Page_ID
		OR g.Page_ID = p.Parent_Page_ID)
	and p.Page_ID = @Page_ID
	and p.PageType_EnumValue in (0,1,3,9,10)--pages that are TaxForms, Attachments, Reports, Continuations, TaxForm Living Templates
	and p.Page_ID = n.Page_ID
	and n.Navigation_ID = @NAV_ID
	and pvg.Property_Name = 'SourceField.FADSFieldID'
	and (pvg.Page_ID = p.Page_ID
			OR pvg.Page_ID = p.Parent_Page_ID)
	and pvg.GraphicObject_ID = g.GraphicObject_ID
	and pvg.Property_Value = ff.FADS_Field_ID
	and isnull(ff.ExpiryDate, '1/1/1911') <> '1/1/1911'
	
	order by n.DeveloperRole_ID, p.Page_ID, g.GraphicObject_ID
END
	ELSE
	BEGIN
	   --first, get the bad graphics owned directly by pages -- this is fast
	  select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
	  from GraphicObject g, Page p, NavigationNode n
	  where g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
	  and g.Page_ID = p.Page_ID
	  and p.PageType_EnumValue in (0,1,9,10)
	  and p.Page_ID = n.Page_ID
	  and n.Navigation_ID = @NAV_ID
	  and not exists (select 1 from PropertyValuesForGraphic pvg
							where pvg.Property_Name = 'SourceField.FADSFieldID'
							and pvg.Page_ID = p.Page_ID
							and pvg.GraphicObject_ID = g.GraphicObject_ID)
	  UNION
	  select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
	  from GraphicObject g, Page p, NavigationNode n, PropertyValuesForGraphic pvg, FADSField ff
	  where g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
	  and g.Page_ID = p.Page_ID
	  and p.PageType_EnumValue in (0,1,9,10)
	  and p.Page_ID = n.Page_ID
	  and n.Navigation_ID = @NAV_ID
	  and pvg.Property_Name = 'SourceField.FADSFieldID'
	  and pvg.Page_ID = p.Page_ID
	  and pvg.GraphicObject_ID = g.GraphicObject_ID
	  and pvg.Property_Value = ff.FADS_Field_ID
	  and isnull(ff.ExpiryDate, '1/1/1911') <> '1/1/1911'
	  UNION
--now, search all pages that inherit from a parent page to see if any of the bad graphics from Living templates
--are also missing assignments by the child pages
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
	from GraphicObject g, Page p, NavigationNode n, 
								(select ltp.Page_ID, ltg.GraphicObject_ID --find the fields that are not mapped on the Living Template
								from GraphicObject ltg, Page ltp
								where ltg.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
								and ltg.Page_ID = ltp.Page_ID
								and ltp.PageType_EnumValue = 3
								and not exists (select 1 from PropertyValuesForGraphic ltpvg
												where ltpvg.Property_Name = 'SourceField.FADSFieldID'
												and ltpvg.Page_ID = ltp.Page_ID
												and ltpvg.GraphicObject_ID = ltg.GraphicObject_ID)  ) lt
	where g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
	and g.Page_ID = lt.Page_ID
	and p.PageType_EnumValue in (0,1,9,10)
	and p.Parent_Page_ID = lt.Page_ID
	and p.Page_ID = n.Page_ID
	and n.Navigation_ID = @NAV_ID
	and not exists (select 1 from PropertyValuesForGraphic pvg
							where pvg.Property_Name = 'SourceField.FADSFieldID'
							and pvg.Page_ID = p.Page_ID
							and pvg.GraphicObject_ID = g.GraphicObject_ID)
    UNION
	select n.DeveloperRole_ID, n.Navigation_Node_ID, n.Node_Name, p.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionX, g.PositionY, g.GraphicObject_Name, g.DataType_EnumValue
	from GraphicObject g, Page p, NavigationNode n, PropertyValuesForGraphic pvg, FADSField ff,
								(select ltp.Page_ID, ltg.GraphicObject_ID --find the fields that are not mapped on the Living Template
								from GraphicObject ltg, Page ltp, PropertyValuesForGraphic ltpvg, FADSField ltff
								where ltg.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
								and ltg.Page_ID = ltp.Page_ID
								and ltp.PageType_EnumValue = 3
								and ltpvg.Property_Name = 'SourceField.FADSFieldID'
								and ltpvg.Page_ID = ltp.Page_ID
								and ltpvg.GraphicObject_ID = ltg.GraphicObject_ID
								and ltpvg.Property_Value = ltff.FADS_Field_ID
							    and isnull(ltff.ExpiryDate, '1/1/1911') <> '1/1/1911') lt
	where g.GraphicObjectType_EnumValue in (1,6) --Textbox, ParsedValueGroup
	and g.Page_ID = lt.Page_ID
	and p.PageType_EnumValue in (0,1,9,10)
	and p.Parent_Page_ID = lt.Page_ID
	and p.Page_ID = n.Page_ID
	and n.Navigation_ID = @NAV_ID
	and pvg.Property_Name = 'SourceField.FADSFieldID'
	and pvg.Page_ID = p.Page_ID
	and pvg.GraphicObject_ID = g.GraphicObject_ID
	and pvg.Property_Value = ff.FADS_Field_ID
	and isnull(ff.ExpiryDate, '1/1/1911') <> '1/1/1911'
	order by n.DeveloperRole_ID, p.Page_ID, g.GraphicObject_ID
	END
END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.spGet_Overlapping_Graphics
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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE spGet_Relational_Groups_Without_Child_Objects AS

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

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.spSet_FADS_Length_And_Precision_In_PropertyTable
AS
begin

update p1
set p1.Property_Value = f.Field_Length
from PropertyValuesForGraphic p1, PropertyValuesForGraphic p3, FadsField f
where p1.Property_Name = 'Data.Length'
and p3.Property_name = 'SourceField.FADSFieldID'
and p1.GraphicObject_ID = p3.GraphicObject_ID
and p1.Page_ID = p3.Page_ID
and f.Fads_Field_ID = p3.Property_Value
and f.Field_Length != p1.Property_Value
 
update p2
set p2.Property_Value = f.Field_Precision
from PropertyValuesForGraphic p2, PropertyValuesForGraphic p3, FadsField f
where p2.Property_Name = 'Data.Precision'
and p3.Property_name = 'SourceField.FADSFieldID'
and p2.GraphicObject_ID = p3.GraphicObject_ID
and p2.Page_ID = p3.Page_ID
and f.Fads_Field_ID = p3.Property_Value
and f.Field_Precision != p2.Property_Value

end

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE [dbo].[spGet_GraphicObjectsThatAreOutOfBounds] AS

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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE spBuildMyTree (	@DEVELOPERID int,
									@NAVIGATIONID int)
	
AS
BEGIN
declare @NAVIGATION_NODE_ID int
declare @NODETYPE_ENUMVALUE tinyint
declare @NODE_NAME varchar(50)
declare @PARENT_NODE_ID int
declare @DISPLAYORDER nvarchar(50)
declare @INDENT_LEVEL tinyint
declare @DEVELOPER_ROLE_ID int
declare @PAGE_ID int
declare @ALTERNATE_ACTION_NODE_ID int
declare @SHORTCUT_NODE_ID int
declare @TARGET_INDENT_LEVEL tinyint
declare @TARGET_NAV_NODE int
declare @CHILDEXISTS tinyint

create table #TempNavTree (Navigation_Node_ID int, 
							NodeType_EnumValue tinyint,
							Node_Name varchar(50), 
							Parent_Node_ID int, 
							DisplayOrder nvarchar(50), 
							Indent_Level tinyint, 
							DeveloperRole_ID int, 
							Page_ID int, 
							AlternateAction_Node_ID int, 
							ShortCut_Node_ID int)

create table #TempNavShortCutTree (Navigation_Node_ID int, 
									NodeType_EnumValue tinyint,
									Node_Name varchar(50), 
									Parent_Node_ID int, 
									DisplayOrder nvarchar(50), 
									Indent_Level tinyint, 
									DeveloperRole_ID int, 
									Page_ID int, 
									AlternateAction_Node_ID int, 
									ShortCut_Node_ID int)

declare NavigationNode CURSOR FOR
select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
from NavigationNode nn, DeveloperRoleXref drx
where nn.Navigation_ID = @NAVIGATIONID
and nn.DeveloperRole_ID = drx.DeveloperRole_ID
and drx.Developer_ID = @DEVELOPERID
and nn.NodeType_EnumValue not in (4,5) --,11) --Root or Header node  -- TFS 25860 to include shortcuts 
UNION  --TFS 49628, include shortcut sources that are not assigned to the Developer (this code will only walk up the tree, need
	--to make additional changes to this proc to walk down the tree in the case where the shortcut source is a parent node)
select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
from NavigationNode nn, DeveloperRoleXref drx, NavigationNode nn1
where nn.Navigation_ID = @NAVIGATIONID
and nn.Navigation_ID = nn1.Navigation_ID
and nn1.DeveloperRole_ID = drx.DeveloperRole_ID
and drx.Developer_ID = @DEVELOPERID
and nn1.NodeType_EnumValue = 11 --shortcut
and nn1.ShortCut_Node_ID = nn.Navigation_Node_ID
--TFS 65835 Add a query here to pull in Header nodes that are mapped to special user function
UNION
select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
from NavigationNode nn, DeveloperRoleXref drx, PropertyValuesForNode pvn
where nn.Navigation_ID = @NAVIGATIONID
and nn.DeveloperRole_ID = drx.DeveloperRole_ID
and drx.Developer_ID = @DEVELOPERID
and nn.NodeType_EnumValue = 5 --Header
and pvn.Navigation_Node_ID = nn.Navigation_Node_ID
and pvn.Property_Name = 'Function.SpecialUserFunction'

Open NavigationNode

Fetch Next From NavigationNode into @NAVIGATION_NODE_ID, @NODETYPE_ENUMVALUE, @NODE_NAME, @PARENT_NODE_ID, 
	@DISPLAYORDER, @INDENT_LEVEL, @DEVELOPER_ROLE_ID, @PAGE_ID, @ALTERNATE_ACTION_NODE_ID, @SHORTCUT_NODE_ID
While @@FETCH_STATUS = 0
BEGIN
--Populate this record into a temptable
  if not exists (select 1 from #TempNavTree where Navigation_Node_ID = @NAVIGATION_NODE_ID)
  begin -- if not exists
	insert into #TempNavTree
    values (@NAVIGATION_NODE_ID, @NODETYPE_ENUMVALUE, @NODE_NAME, @PARENT_NODE_ID, 
	@DISPLAYORDER, @INDENT_LEVEL, @DEVELOPER_ROLE_ID, @PAGE_ID, @ALTERNATE_ACTION_NODE_ID, @SHORTCUT_NODE_ID)
  end -- if not exists
--go find all the parent nodes, and put them into the temp table
  select @TARGET_NAV_NODE = @NAVIGATION_NODE_ID
  select @TARGET_INDENT_LEVEL = @INDENT_LEVEL
  WHILE (@TARGET_INDENT_LEVEL > 0)
  BEGIN

	select @TARGET_NAV_NODE = Parent_Node_ID
	from NavigationNode
	where Navigation_Node_ID = @TARGET_NAV_NODE
	and Navigation_ID = @NAVIGATIONID
  
	 insert into #TempNavTree
     select np.Navigation_Node_ID, np.NodeType_EnumValue, np.Node_Name, np.Parent_Node_ID, np.DisplayOrder, 
		np.Indent_Level, np.DeveloperRole_ID, np.Page_ID, np.AlternateAction_Node_ID, np.ShortCut_Node_ID
     from NavigationNode np
	 where np.Navigation_ID = @NAVIGATIONID
	 and np.Navigation_Node_ID = @TARGET_NAV_NODE
	 and not exists (select 1 from #TempNavTree tnt
					 where tnt.Navigation_Node_ID = np.Navigation_Node_ID)

	 select @TARGET_INDENT_LEVEL = @TARGET_INDENT_LEVEL - 1

END

Fetch Next From NavigationNode into @NAVIGATION_NODE_ID, @NODETYPE_ENUMVALUE, @NODE_NAME, @PARENT_NODE_ID, 
	@DISPLAYORDER, @INDENT_LEVEL, @DEVELOPER_ROLE_ID, @PAGE_ID, @ALTERNATE_ACTION_NODE_ID, @SHORTCUT_NODE_ID
END
close NavigationNode
deallocate NavigationNode
--For TFS 49628, need to walk down the tree for all shortcut sources that are parent nodes.

--insert shortcut sources in temp table
insert into #TempNavShortCutTree (Navigation_Node_ID,NodeType_EnumValue, Node_Name, Parent_Node_ID,DisplayOrder, 
			Indent_Level,DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID)
select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
from NavigationNode nn, DeveloperRoleXref drx, NavigationNode nn1
where nn.Navigation_ID = @NAVIGATIONID
and nn.Navigation_ID = nn1.Navigation_ID
and nn1.DeveloperRole_ID = drx.DeveloperRole_ID
and drx.Developer_ID = @DEVELOPERID
and nn1.NodeType_EnumValue = 11 --shortcut
and nn1.ShortCut_Node_ID = nn.Navigation_Node_ID


select @CHILDEXISTS = 0
--walk down the tree until there are no more descendents
if exists (select nn.Navigation_Node_ID from NavigationNode nn, #TempNavShortCutTree tn1
			where nn.Navigation_ID = @NAVIGATIONID
			and nn.Parent_Node_ID = tn1.Navigation_Node_ID
			and nn.Navigation_Node_ID not in (select tn2.Navigation_Node_ID from #TempNavShortCutTree tn2))
begin
  select @CHILDEXISTS = 1
end

while (@CHILDEXISTS = 1)
begin
	insert into #TempNavShortCutTree (Navigation_Node_ID,NodeType_EnumValue, Node_Name, Parent_Node_ID,DisplayOrder, 
			Indent_Level,DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID)
	select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
		nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
	from NavigationNode nn, #TempNavShortCutTree tn1
	where nn.Navigation_ID = @NAVIGATIONID
	and nn.Parent_Node_ID = tn1.Navigation_Node_ID
	and nn.Navigation_Node_ID not in (select tn2.Navigation_Node_ID from #TempNavShortCutTree tn2)

	if not exists (select nn.Navigation_Node_ID from NavigationNode nn, #TempNavShortCutTree tn1
			where nn.Navigation_ID = @NAVIGATIONID
			and nn.Parent_Node_ID = tn1.Navigation_Node_ID
			and nn.Navigation_Node_ID not in (select tn2.Navigation_Node_ID from #TempNavShortCutTree tn2))
	begin
		select @CHILDEXISTS = 0
	end

end --while

--insert contents of shortcut temp table into main temp table
insert into #TempNavTree(Navigation_Node_ID,NodeType_EnumValue, Node_Name, Parent_Node_ID,DisplayOrder, 
			Indent_Level,DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID)
select tns.Navigation_Node_ID,tns.NodeType_EnumValue, tns.Node_Name, tns.Parent_Node_ID,tns.DisplayOrder, 
			tns.Indent_Level,tns.DeveloperRole_ID, tns.Page_ID, tns.AlternateAction_Node_ID, tns.ShortCut_Node_ID
from #TempNavShortCutTree tns
where tns.Navigation_Node_ID not in (select tnt.Navigation_Node_ID from #TempNavTree tnt)


select * from #TempNavTree
order by Indent_Level, DisplayOrder

drop table #TempNavTree
drop table #TempNavShortCutTree

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[spBuildBaseScripts] (	@NAVIGATIONID int,
										@LASTSAVED smalldatetime,
										@CODETYPE tinyint)
	
AS
BEGIN

   select distinct csx.BaseCodeScript_ID 
   from CodeScriptAssignment csa, NavigationNode nn, CodeScript cs, CodeScriptBaseScriptXref csx
   where nn.Navigation_ID = @NAVIGATIONID
   and csa.Dependent_Page_ID = nn.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.CodeType_EnumValue = @CODETYPE
   and csa.CodeScript_ID = cs.Code_ID
   and csa.CodeScript_ID = csx.CodeScript_ID
   and isnull(cs.DateLastSaved, '01/02/1900') > @LASTSAVED
   UNION
   select distinct csx.BaseCodeScript_ID 
   from CodeScriptAssignment csa, NavigationNode nn, CodeScript cs, CodeScriptBaseScriptXref csx
   where nn.Navigation_ID = @NAVIGATIONID
   and csa.Dependent_Page_ID = 0
   and csa.Dependent_ID = nn.Navigation_Node_ID
   and csa.CodeType_EnumValue = @CODETYPE
   and csa.CodeScript_ID = cs.Code_ID
   and csa.CodeScript_ID = csx.CodeScript_ID
   and isnull(cs.DateLastSaved, '01/02/1900') > @LASTSAVED
   UNION
   select distinct csx.BaseCodeScript_ID 
   from CodeScriptAssignment csa, NavigationNode nn, Page p, CodeScript cs, CodeScriptBaseScriptXref csx
   where nn.Navigation_ID = @NAVIGATIONID
   and p.Page_ID = nn.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.Dependent_Page_ID = p.Parent_Page_ID
   and csa.CodeType_EnumValue = @CODETYPE
   and csa.CodeScript_ID = cs.Code_ID
   and csa.CodeScript_ID = csx.CodeScript_ID
   and isnull(cs.DateLastSaved, '01/02/1900') > @LASTSAVED
   UNION
   select distinct csx.BaseCodeScript_ID
   from CodeScriptAssignment csa, NavigationNode nn, NavigationNode nn1, NavigationNode nn2, Navigation nv, 
		CodeScript cs, CodeScriptBaseScriptXref csx
   where csa.Dependent_Page_ID = nn2.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.CodeType_EnumValue = @CODETYPE
   and csa.CodeScript_ID = cs.Code_ID
   and csa.CodeScript_ID = csx.CodeScript_ID
   and isnull(cs.DateLastSaved, '01/02/1900') > @LASTSAVED
   and nn2.NodeType_EnumValue = 37 --ContinuationPage
   and nv.NavigationType_EnumValue = 0 --Designer
   and nv.Navigation_ID = nn2.Navigation_ID
   and nv.Navigation_ID = nn1.Navigation_ID
   and nn1.Navigation_Node_ID = nn2.Parent_Node_ID
   and nn.Page_ID = nn1.Page_ID
   and nn.Navigation_ID = @NAVIGATIONID
   ORDER by csx.BaseCodeScript_ID


END

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
CREATE PROCEDURE spBuildMyCodeScripts (	@DEVELOPERID int,
										@NAVIGATIONID int,
										@CODETYPE tinyint)
	
AS
BEGIN

if (@DEVELOPERID > 0)
begin --@DEVELOPERID > 0
   declare @NAVIGATION_NODE_ID int
   declare @NODETYPE_ENUMVALUE tinyint
   declare @NODE_NAME varchar(50)
   declare @PARENT_NODE_ID int
   declare @DISPLAYORDER nvarchar(50)
   declare @INDENT_LEVEL tinyint
   declare @DEVELOPER_ROLE_ID int
   declare @PAGE_ID int
   declare @ALTERNATE_ACTION_NODE_ID int
   declare @SHORTCUT_NODE_ID int
   declare @TARGET_INDENT_LEVEL tinyint
   declare @TARGET_NAV_NODE int
   declare @CHILDEXISTS tinyint

   create table #TempNavTree (Navigation_Node_ID int, 
							NodeType_EnumValue tinyint,
							Node_Name varchar(50), 
							Parent_Node_ID int, 
							DisplayOrder nvarchar(50), 
							Indent_Level tinyint, 
							DeveloperRole_ID int, 
							Page_ID int, 
							AlternateAction_Node_ID int, 
							ShortCut_Node_ID int)

	create table #TempNavShortCutTree (Navigation_Node_ID int, 
									NodeType_EnumValue tinyint,
									Node_Name varchar(50), 
									Parent_Node_ID int, 
									DisplayOrder nvarchar(50), 
									Indent_Level tinyint, 
									DeveloperRole_ID int, 
									Page_ID int, 
									AlternateAction_Node_ID int, 
									ShortCut_Node_ID int)

   declare NavigationNode CURSOR FOR
   select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
	nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
	from NavigationNode nn, DeveloperRoleXref drx
	where nn.Navigation_ID = @NAVIGATIONID
	and nn.DeveloperRole_ID = drx.DeveloperRole_ID
	and drx.Developer_ID = @DEVELOPERID
	and nn.NodeType_EnumValue not in (4,5) --,11) --Root or Header node  -- TFS 25860 to include shortcuts 
	UNION  --TFS 49628, include shortcut sources that are not assigned to the Developer (this code will only walk up the tree, need
	--to make additional changes to this proc to walk down the tree in the case where the shortcut source is a parent node)
	select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
	nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
	from NavigationNode nn, DeveloperRoleXref drx, NavigationNode nn1
	where nn.Navigation_ID = @NAVIGATIONID
	and nn.Navigation_ID = nn1.Navigation_ID
	and nn1.DeveloperRole_ID = drx.DeveloperRole_ID
	and drx.Developer_ID = @DEVELOPERID
	and nn1.NodeType_EnumValue = 11 --shortcut
	and nn1.ShortCut_Node_ID = nn.Navigation_Node_ID

   Open NavigationNode

   Fetch Next From NavigationNode into @NAVIGATION_NODE_ID, @NODETYPE_ENUMVALUE, @NODE_NAME, @PARENT_NODE_ID, 
	   @DISPLAYORDER, @INDENT_LEVEL, @DEVELOPER_ROLE_ID, @PAGE_ID, @ALTERNATE_ACTION_NODE_ID, @SHORTCUT_NODE_ID
   While @@FETCH_STATUS = 0
   BEGIN
   --Populate this record into a temptable
     if not exists (select 1 from #TempNavTree where Navigation_Node_ID = @NAVIGATION_NODE_ID)
     begin -- if not exists
	   insert into #TempNavTree
       values (@NAVIGATION_NODE_ID, @NODETYPE_ENUMVALUE, @NODE_NAME, @PARENT_NODE_ID, 
	   @DISPLAYORDER, @INDENT_LEVEL, @DEVELOPER_ROLE_ID, @PAGE_ID, @ALTERNATE_ACTION_NODE_ID, @SHORTCUT_NODE_ID)
     end -- if not exists
   --go find all the parent nodes, and put them into the temp table
     select @TARGET_NAV_NODE = @NAVIGATION_NODE_ID
     select @TARGET_INDENT_LEVEL = @INDENT_LEVEL
     WHILE (@TARGET_INDENT_LEVEL > 0)
     BEGIN

	   select @TARGET_NAV_NODE = Parent_Node_ID
	   from NavigationNode
	   where Navigation_Node_ID = @TARGET_NAV_NODE
	   and Navigation_ID = @NAVIGATIONID
  
	    insert into #TempNavTree
        select np.Navigation_Node_ID, np.NodeType_EnumValue, np.Node_Name, np.Parent_Node_ID, np.DisplayOrder, 
		   np.Indent_Level, np.DeveloperRole_ID, np.Page_ID, np.AlternateAction_Node_ID, np.ShortCut_Node_ID
        from NavigationNode np
	    where np.Navigation_ID = @NAVIGATIONID
	    and np.Navigation_Node_ID = @TARGET_NAV_NODE
	    and not exists (select 1 from #TempNavTree tnt
					    where tnt.Navigation_Node_ID = np.Navigation_Node_ID)

	    select @TARGET_INDENT_LEVEL = @TARGET_INDENT_LEVEL - 1

   END

   Fetch Next From NavigationNode into @NAVIGATION_NODE_ID, @NODETYPE_ENUMVALUE, @NODE_NAME, @PARENT_NODE_ID, 
	   @DISPLAYORDER, @INDENT_LEVEL, @DEVELOPER_ROLE_ID, @PAGE_ID, @ALTERNATE_ACTION_NODE_ID, @SHORTCUT_NODE_ID
   END
   close NavigationNode
   deallocate NavigationNode

	--For TFS 49628, need to walk down the tree for all shortcut sources that are parent nodes.

	--insert shortcut sources in temp table
	insert into #TempNavShortCutTree (Navigation_Node_ID,NodeType_EnumValue, Node_Name, Parent_Node_ID,DisplayOrder, 
				Indent_Level,DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID)
	select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
	nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
	from NavigationNode nn, DeveloperRoleXref drx, NavigationNode nn1
	where nn.Navigation_ID = @NAVIGATIONID
	and nn.Navigation_ID = nn1.Navigation_ID
	and nn1.DeveloperRole_ID = drx.DeveloperRole_ID
	and drx.Developer_ID = @DEVELOPERID
	and nn1.NodeType_EnumValue = 11 --shortcut
	and nn1.ShortCut_Node_ID = nn.Navigation_Node_ID


	select @CHILDEXISTS = 0
	--walk down the tree until there are no more descendents
	if exists (select nn.Navigation_Node_ID from NavigationNode nn, #TempNavShortCutTree tn1
				where nn.Navigation_ID = @NAVIGATIONID
				and nn.Parent_Node_ID = tn1.Navigation_Node_ID
				and nn.Navigation_Node_ID not in (select tn2.Navigation_Node_ID from #TempNavShortCutTree tn2))
	begin
	  select @CHILDEXISTS = 1
	end

	while (@CHILDEXISTS = 1)
	begin
		insert into #TempNavShortCutTree (Navigation_Node_ID,NodeType_EnumValue, Node_Name, Parent_Node_ID,DisplayOrder, 
				Indent_Level,DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID)
		select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
			nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
		from NavigationNode nn, #TempNavShortCutTree tn1
		where nn.Navigation_ID = @NAVIGATIONID
		and nn.Parent_Node_ID = tn1.Navigation_Node_ID
		and nn.Navigation_Node_ID not in (select tn2.Navigation_Node_ID from #TempNavShortCutTree tn2)

		if not exists (select nn.Navigation_Node_ID from NavigationNode nn, #TempNavShortCutTree tn1
				where nn.Navigation_ID = @NAVIGATIONID
				and nn.Parent_Node_ID = tn1.Navigation_Node_ID
				and nn.Navigation_Node_ID not in (select tn2.Navigation_Node_ID from #TempNavShortCutTree tn2))
		begin
			select @CHILDEXISTS = 0
		end

	end --while

	--insert contents of shortcut temp table into main temp table
	insert into #TempNavTree(Navigation_Node_ID,NodeType_EnumValue, Node_Name, Parent_Node_ID,DisplayOrder, 
				Indent_Level,DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID)
	select tns.Navigation_Node_ID,tns.NodeType_EnumValue, tns.Node_Name, tns.Parent_Node_ID,tns.DisplayOrder, 
				tns.Indent_Level,tns.DeveloperRole_ID, tns.Page_ID, tns.AlternateAction_Node_ID, tns.ShortCut_Node_ID
	from #TempNavShortCutTree tns
	where tns.Navigation_Node_ID not in (select tnt.Navigation_Node_ID from #TempNavTree tnt)

	--build the code scripts
   select distinct csa.CodeScript_ID 
   from CodeScriptAssignment csa, #TempNavTree nn
   where csa.Dependent_Page_ID = nn.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.CodeType_EnumValue = @CODETYPE
   UNION
   select distinct csa.CodeScript_ID 
   from CodeScriptAssignment csa, #TempNavTree nn
   where csa.Dependent_Page_ID = 0
   and csa.Dependent_ID = nn.Navigation_Node_ID
   and csa.CodeType_EnumValue = @CODETYPE
   UNION
   select distinct csa.CodeScript_ID 
   from CodeScriptAssignment csa, #TempNavTree nn, Page p
   where p.Page_ID = nn.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.Dependent_Page_ID = p.Parent_Page_ID
   and csa.CodeType_EnumValue = @CODETYPE
   UNION
   select distinct csa.CodeScript_ID
   from CodeScriptAssignment csa, #TempNavTree nn, NavigationNode nn1, NavigationNode nn2, Navigation nv
   where csa.Dependent_Page_ID = nn2.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.CodeType_EnumValue = @CODETYPE
   and nv.NavigationType_EnumValue = 0 --Designer
   and nv.Navigation_ID = nn1.Navigation_ID
   and nv.Navigation_ID = nn2.Navigation_ID
   and nn.Page_ID = nn1.Page_ID
   and nn1.Navigation_Node_ID = nn2.Parent_Node_ID
   and nn2.NodeType_EnumValue = 37 --ContinuationPage
   ORDER by csa.CodeScript_ID
   
   drop table #TempNavTree
   drop table #TempNavShortCutTree
end --@DEVELOPERID > 0
else
begin --Get All Code Scripts for this Product
   select distinct csa.CodeScript_ID 
   from CodeScriptAssignment csa, NavigationNode nn
   where nn.Navigation_ID = @NAVIGATIONID
   and csa.Dependent_Page_ID = nn.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.CodeType_EnumValue = @CODETYPE
   UNION
   select distinct csa.CodeScript_ID 
   from CodeScriptAssignment csa, NavigationNode nn
   where nn.Navigation_ID = @NAVIGATIONID
   and csa.Dependent_Page_ID = 0
   and csa.Dependent_ID = nn.Navigation_Node_ID
   and csa.CodeType_EnumValue = @CODETYPE
   UNION
   select distinct csa.CodeScript_ID 
   from CodeScriptAssignment csa, NavigationNode nn, Page p
   where nn.Navigation_ID = @NAVIGATIONID
   and p.Page_ID = nn.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.Dependent_Page_ID = p.Parent_Page_ID
   and csa.CodeType_EnumValue = @CODETYPE
   UNION
   select distinct csa.CodeScript_ID
   from CodeScriptAssignment csa, NavigationNode nn, NavigationNode nn1, NavigationNode nn2, Navigation nv
   where csa.Dependent_Page_ID = nn2.Page_ID
   and csa.Dependent_Page_ID > 0
   and csa.CodeType_EnumValue = @CODETYPE
   and nn2.NodeType_EnumValue = 37 --ContinuationPage
   and nv.NavigationType_EnumValue = 0 --Designer
   and nv.Navigation_ID = nn2.Navigation_ID
   and nv.Navigation_ID = nn1.Navigation_ID
   and nn1.Navigation_Node_ID = nn2.Parent_Node_ID
   and nn.Page_ID = nn1.Page_ID
   and nn.Navigation_ID = @NAVIGATIONID
   ORDER by csa.CodeScript_ID
end


END
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[spCreatePageByID] (	@PAGEID int )
								
AS
BEGIN

if (@PAGEID > 0)
begin --pageID != 0
	if not exists (select 1 from Page where Page_ID = @PAGEID)
	begin -- if not exists
		SET @PAGEID = @PAGEID - 1

		DBCC CHECKIDENT (Page, RESEED, @PAGEID)

	   insert into Page (PageType_EnumValue, Page_Name, Parent_Page_ID)
	       values (0, "InsertedPage", 0) 

		DECLARE @lastPageID int
		SET @lastPageID = (select Max(Page_ID) from Page)
		
		DBCC CHECKIDENT (Page, RESEED, @lastPageID)

	end -- if not exists
end --pageID != 0
END
GO

CREATE PROCEDURE [dbo].[spCreateNavigationNodeByID] (	@NODE_ID int)
								
AS
BEGIN

if (@NODE_ID > 0)
begin --nodeID != 0
	if not exists (select 1 from NavigationNode where Navigation_Node_ID = @NODE_ID)
	begin -- if not exists
		SET @NODE_ID = @NODE_ID - 1

		DBCC CHECKIDENT (NavigationNode, RESEED, @NODE_ID)

	   insert into NavigationNode(Node_Name)
	       values ('Inserted Node') 

		DECLARE @lastNodeID int
		SET @lastNodeID = (select Max(Navigation_Node_ID) from NavigationNode)
		
		DBCC CHECKIDENT (NavigationNode, RESEED, @lastNodeID)

	end -- if not exists
end --nodeID != 0
END
GO

CREATE PROCEDURE [dbo].[spCreateFADSFieldByID] (	@FADSFIELDID int, 
													@FIELD_NAME nvarchar(50), 
													@PRODUCT_NAME nvarchar(50), 
													@FADS_AREA tinyint,
													@FADS_FIELD tinyint,
													@FADS_LEVEL tinyint,
													@FIELD_DATATYPE tinyint)
								
AS
BEGIN

if (@FADSFIELDID > 0)
begin --pageID != 0
	if not exists (select 1 from FadsField where FADS_Field_ID = @FADSFIELDID)
	begin -- if not exists
		SET @FADSFIELDID = @FADSFIELDID - 1

		DBCC CHECKIDENT (FadsField, RESEED, @FADSFIELDID)

	   insert into FADSField (Field_Name, Product_Name, FADS_Area, FADS_Field, FADS_Level, Field_Datatype)
	       values (@FIELD_NAME, @PRODUCT_NAME, @FADS_AREA, @FADS_FIELD, @FADS_LEVEL, @FIELD_DATATYPE) 

		DECLARE @lastFADSFieldID int
		SET @lastFADSFieldID = (select Max(FADS_Field_ID) from FADSField)
		
		DBCC CHECKIDENT (FADSField, RESEED, @lastFADSFieldID)

	end -- if not exists
end --fadsfieldID != 0
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE spCreateGraphicByID (	@PAGEID int, @GRAPHICID int )
								
AS
BEGIN

if (@GRAPHICID > 0)
begin --graphic id != 0
	if (@PAGEID > 0)
	begin --page id != 0
		if not exists (select 1 from GraphicObject where GraphicObject_ID = @GRAPHICID)
		begin -- if not exists
			declare @nextID int
			SET @nextID = (select NextGraphicObject_ID from NextGraphicObject)
			
			insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width, DateCreated, DateLastSaved)
			values (@GRAPHICID, 0, @PAGEID, 0, 0, 0, 0, '01/01/1999', '01/01/1999')

			if (@nextID > @GRAPHICID)
			begin
			  update NextGraphicObject
			  set NextGraphicObject_ID = @nextID
			end

		end -- if not exists
	end  --page id != 0
end --grahpic id != 0
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE spAudit_NewerVersionsOfFormsExist 
	
AS
BEGIN

select nn.DeveloperRole_ID, nn.Navigation_Node_ID, nn.Node_Name, nn.Page_ID, pvp.Property_Value
from Page p, PropertyValuesForPage pvp, NavigationNode nn
where pvp.Page_ID = p.Page_ID
and p.Page_ID = nn.Page_ID
and nn.Navigation_ID = 1
and pvp.Property_Name = 'Page.Background.ImageInfo_ID'
order by nn.Navigation_Node_ID


END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE spAudit_CodeScriptCompilation (@DEVELOPER_ROLE_ID int, 
												@NODE_ID int,
												@NAV_ID int)
	
AS
BEGIN

declare @NAVTYPE tinyint

select @NAVTYPE = 0
select @NAVTYPE = NavigationType_EnumValue
from Navigation
where Navigation_ID = @NAV_ID


if (@NAVTYPE = 0) -- Design Tree
begin --Design Tree

  if (@DEVELOPER_ROLE_ID > 0)
  begin -- for Role

     select csa.CodeScript_ID, cs.Code_Name, p.Page_ID, p.Page_Name, g.PositionX, g.PositionY, egot.Enum_Description, 
	        g.GraphicObject_ID, isnull(g.GraphicObject_Name,'') as GraphicObjectName, (case edt.Enum_Value
														when 0 then 'Boolean'
														when 1 then 'Integer'
														when 2 then 'String'
														when 3 then 'Date'
														when 4 then 'Font'
														when 5 then 'Byte'
														when 6 then 'Image'
														when 7 then 'Ratio'
														when 8 then 'Money'
														else 'None'
													end)
     from CodeScriptAssignment csa, NavigationNode nn, CodeScript cs, Page p, GraphicObject g, 
          Enum_GraphicObjectType egot, Enum_DataType edt
     where nn.Navigation_ID = @NAV_ID
     and nn.DeveloperRole_ID = @DEVELOPER_ROLE_ID
     and csa.Dependent_Page_ID = nn.Page_ID
     and csa.CodeScript_ID not in (select CodeScript_ID
								   from CodeScriptBaseScriptXref)
     and csa.CodeScript_ID = cs.Code_ID
     and nn.Page_ID = p.Page_ID
     and nn.Page_ID = g.Page_ID
     and csa.Dependent_ID = g.GraphicObject_ID
     and g.GraphicObjectType_EnumValue = egot.Enum_Value
     and isnull(g.DataType_EnumValue,255) = edt.Enum_Value

  end -- for Role

  if (@NODE_ID > 0)
  begin -- for Node
     select csa.CodeScript_ID, cs.Code_Name, p.Page_ID, p.Page_Name, g.PositionX, g.PositionY, egot.Enum_Description, 
	        g.GraphicObject_ID, isnull(g.GraphicObject_Name,'') as GraphicObjectName, (case edt.Enum_Value
														when 0 then 'Boolean'
														when 1 then 'Integer'
														when 2 then 'String'
														when 3 then 'Date'
														when 4 then 'Font'
														when 5 then 'Byte'
														when 6 then 'Image'
														when 7 then 'Ratio'
														when 8 then 'Money'
														else 'None'
													end)
     from CodeScriptAssignment csa, NavigationNode nn, CodeScript cs, Page p, GraphicObject g, 
          Enum_GraphicObjectType egot, Enum_DataType edt
     where nn.Navigation_ID = @NAV_ID
     and nn.Navigation_Node_ID = @NODE_ID
     and csa.Dependent_Page_ID = nn.Page_ID
     and csa.CodeScript_ID not in (select CodeScript_ID
								   from CodeScriptBaseScriptXref)
     and csa.CodeScript_ID = cs.Code_ID
     and nn.Page_ID = p.Page_ID
     and nn.Page_ID = g.Page_ID
     and csa.Dependent_ID = g.GraphicObject_ID
     and g.GraphicObjectType_EnumValue = egot.Enum_Value
     and isnull(g.DataType_EnumValue,255) = edt.Enum_Value

  end -- for Node
end --Design Tree
else
begin --Other Trees
  if (@DEVELOPER_ROLE_ID > 0)
  begin -- for Role

     select csa.CodeScript_ID, cs.Code_Name, nn.Navigation_Node_ID, nn.Node_Name
     from CodeScriptAssignment csa, NavigationNode nn, CodeScript cs
     where nn.Navigation_ID = @NAV_ID
     and nn.DeveloperRole_ID = @DEVELOPER_ROLE_ID
     and csa.Dependent_Page_ID = 0
	 and csa.Dependent_ID = nn.Navigation_Node_ID
     and csa.CodeScript_ID not in (select CodeScript_ID
								   from CodeScriptBaseScriptXref)
     and csa.CodeScript_ID = cs.Code_ID
     
  end -- for Role

  if (@NODE_ID > 0)
  begin -- for Node
     select csa.CodeScript_ID, cs.Code_Name, nn.Navigation_Node_ID, nn.Node_Name
     from CodeScriptAssignment csa, NavigationNode nn, CodeScript cs
     where nn.Navigation_ID = @NAV_ID
     and nn.Navigation_Node_ID = @NODE_ID
     and csa.Dependent_Page_ID = 0
	 and csa.Dependent_ID = nn.Navigation_Node_ID
     and csa.CodeScript_ID not in (select CodeScript_ID
								   from CodeScriptBaseScriptXref)
     and csa.CodeScript_ID = cs.Code_ID

  end -- for Node

end --Other Trees

END
GO




SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE spAudit_CodeScriptTestCaseErrors (@DEVELOPER_ROLE_ID int, 
												   @NODE_ID int,
												   @NAV_ID int)
	
AS
BEGIN

declare @NAVTYPE tinyint

select @NAVTYPE = 0
select @NAVTYPE = NavigationType_EnumValue
from Navigation
where Navigation_ID = @NAV_ID


if (@NAVTYPE = 0) -- Design Tree
begin --Design Tree

  if (@DEVELOPER_ROLE_ID > 0)
  begin -- for Role
     select csbsx.BaseCodeScript_ID, cstc.TestCase_ID, cstc.ExpectedResult_Value, csp.Parameter_Position,cstcv.ParameterInputValue, 
	     csa.CodeScript_ID, cs.Code_Name, p.Page_ID, p.Page_Name, g.PositionX, g.PositionY, egot.Enum_Description, 
	     g.GraphicObject_ID, isnull(g.GraphicObject_Name,'') as GraphicObjectName, (case edt.Enum_Value
														when 0 then 'Boolean'
														when 1 then 'Integer'
														when 2 then 'String'
														when 3 then 'Date'
														when 4 then 'Font'
														when 5 then 'Byte'
														when 6 then 'Image'
														when 7 then 'Ratio'
														when 8 then 'Money'
														else 'None'
													end)
     from CodeScriptTestCase cstc, CodeScriptTestCaseValues cstcv, CodeScriptParameters csp, CodeScriptAssignment csa, NavigationNode nn, CodeScript cs, Page p, GraphicObject g, 
       Enum_GraphicObjectType egot, Enum_DataType edt, CodeScriptBaseScriptXref csbsx
     where nn.Navigation_ID = @NAV_ID
     and nn.DeveloperRole_ID = @DEVELOPER_ROLE_ID
     and csa.Dependent_Page_ID = nn.Page_ID
     and csa.CodeScript_ID = csbsx.CodeScript_ID
     and csa.CodeScript_ID = cs.Code_ID
     and cstc.Code_ID = cs.Code_ID
     and csp.Code_ID = cs.Code_ID
     and cstcv.TestCase_ID = cstc.TestCase_ID
     and cstcv.Parameter_ID = csp.Parameter_ID
     and nn.Page_ID = p.Page_ID
     and nn.Page_ID = g.Page_ID
     and csa.Dependent_ID = g.GraphicObject_ID
     and g.GraphicObjectType_EnumValue = egot.Enum_Value
     and isnull(g.DataType_EnumValue,255) = edt.Enum_Value
     order by csbsx.BaseCodeScript_ID, csa.CodeScript_ID, cstc.TestCase_ID, csp.Parameter_Position

  end -- for Role

  if (@NODE_ID > 0)
  begin -- for Node
	  select csbsx.BaseCodeScript_ID, cstc.TestCase_ID, cstc.ExpectedResult_Value, csp.Parameter_Position, cstcv.ParameterInputValue, 
	     csa.CodeScript_ID, cs.Code_Name, p.Page_ID, p.Page_Name, g.PositionX, g.PositionY, egot.Enum_Description, 
	     g.GraphicObject_ID, isnull(g.GraphicObject_Name,'') as GraphicObjectName, (case edt.Enum_Value
														when 0 then 'Boolean'
														when 1 then 'Integer'
														when 2 then 'String'
														when 3 then 'Date'
														when 4 then 'Font'
														when 5 then 'Byte'
														when 6 then 'Image'
														when 7 then 'Ratio'
														when 8 then 'Money'
														else 'None'
													end)
     from CodeScriptTestCase cstc, CodeScriptTestCaseValues cstcv, CodeScriptParameters csp, CodeScriptAssignment csa, NavigationNode nn, CodeScript cs, Page p, GraphicObject g, 
       Enum_GraphicObjectType egot, Enum_DataType edt, CodeScriptBaseScriptXref csbsx
     where nn.Navigation_ID = @NAV_ID
     and nn.Navigation_Node_ID = @NODE_ID
     and csa.Dependent_Page_ID = nn.Page_ID
     and csa.CodeScript_ID = csbsx.CodeScript_ID
     and csa.CodeScript_ID = cs.Code_ID
     and cstc.Code_ID = cs.Code_ID
     and csp.Code_ID = cs.Code_ID
     and cstcv.TestCase_ID = cstc.TestCase_ID
     and cstcv.Parameter_ID = csp.Parameter_ID
     and nn.Page_ID = p.Page_ID
     and nn.Page_ID = g.Page_ID
     and csa.Dependent_ID = g.GraphicObject_ID
     and g.GraphicObjectType_EnumValue = egot.Enum_Value
     and isnull(g.DataType_EnumValue,255) = edt.Enum_Value
     order by csbsx.BaseCodeScript_ID, csa.CodeScript_ID, cstc.TestCase_ID, csp.Parameter_Position

  end -- for Node
end --Design Tree
else
begin --Other Trees

if (@DEVELOPER_ROLE_ID > 0)
  begin -- for Role
     select csbsx.BaseCodeScript_ID, cstc.TestCase_ID, cstc.ExpectedResult_Value, csp.Parameter_Position,cstcv.ParameterInputValue, 
	     csa.CodeScript_ID, cs.Code_Name, nn.Navigation_Node_ID, nn.Node_Name
     from CodeScriptTestCase cstc, CodeScriptTestCaseValues cstcv, CodeScriptParameters csp, CodeScriptAssignment csa, NavigationNode nn, 
		  CodeScript cs, CodeScriptBaseScriptXref csbsx
     where nn.Navigation_ID = @NAV_ID
     and nn.DeveloperRole_ID = @DEVELOPER_ROLE_ID
     and csa.Dependent_Page_ID = 0
     and csa.Dependent_ID = nn.Navigation_Node_ID
     and csa.CodeScript_ID = csbsx.CodeScript_ID
     and csa.CodeScript_ID = cs.Code_ID
     and cstc.Code_ID = cs.Code_ID
     and csp.Code_ID = cs.Code_ID
     and cstcv.TestCase_ID = cstc.TestCase_ID
     and cstcv.Parameter_ID = csp.Parameter_ID
     order by csbsx.BaseCodeScript_ID, csa.CodeScript_ID, cstc.TestCase_ID, csp.Parameter_Position

  end -- for Role

  if (@NODE_ID > 0)
  begin -- for Node
	  select csbsx.BaseCodeScript_ID, cstc.TestCase_ID, cstc.ExpectedResult_Value, csp.Parameter_Position, cstcv.ParameterInputValue, 
	     csa.CodeScript_ID, cs.Code_Name, nn.Navigation_Node_ID, nn.Node_Name
     from CodeScriptTestCase cstc, CodeScriptTestCaseValues cstcv, CodeScriptParameters csp, CodeScriptAssignment csa, NavigationNode nn, 
		 CodeScript cs, CodeScriptBaseScriptXref csbsx
     where nn.Navigation_ID = @NAV_ID
     and nn.Navigation_Node_ID = @NODE_ID
     and csa.Dependent_Page_ID = 0
	 and csa.Dependent_ID = nn.Navigation_Node_ID
     and csa.CodeScript_ID = csbsx.CodeScript_ID
     and csa.CodeScript_ID = cs.Code_ID
     and cstc.Code_ID = cs.Code_ID
     and csp.Code_ID = cs.Code_ID
     and cstcv.TestCase_ID = cstc.TestCase_ID
     and cstcv.Parameter_ID = csp.Parameter_ID
     order by csbsx.BaseCodeScript_ID, csa.CodeScript_ID, cstc.TestCase_ID, csp.Parameter_Position

  end -- for Node

end --Other Trees
END
GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE spGet_PotentialHyperlinkTargets (@DEVELOPER_ID int)
	
AS
BEGIN

select p.Page_ID, nn.Node_Name, dr.DeveloperRoleName
from NavigationNode nn, Page p, DeveloperRoleXref drx, DeveloperRole dr
where nn.Navigation_ID = 1
and drx.Developer_ID = @DEVELOPER_ID
and drx.DeveloperRole_ID = nn.DeveloperRole_ID
and drx.DeveloperRole_ID = dr.DeveloperRole_ID
and nn.Page_ID = p.Page_ID
and p.PageType_EnumValue in (1,9)
AND p.Page_ID NOT IN (SELECT Page_ID FROM PropertyValuesForPage WHERE Property_Name = 'Page.IsCheckedOut')
order by dr.DeveloperRoleName, nn.Node_Name


END
GO

CREATE PROCEDURE spGetFormImageInformationByDeveloperRole (	@DeveloperRole varchar(1000),
															@ImageDatabase varchar(64)) AS
BEGIN
		--define variables
declare @DOCCODE varchar(10)
declare @DOCVERS varchar(5)
declare @VERSIONSTRING varchar(50)
declare @Query varchar(2500)

--create temp table to hold Document Code and Version Count
create table #DocCount (Document_Code varchar(10),
						VerCount smallint)

--create temp table to hold superset of Document Code and Versions Used
create table #DocVersion (Document_Code varchar(10),
						  Version varchar(5))

--create temp table to hold Document Code, Jurisdiction, Image Name, List of Versions
create table #FinalDocList (Document_Code varchar(10),
							Jurisdiction varchar(50),
							Image_Name varchar(50),
							VersionList varchar(50))

--Insert into VersionCount temp table
select @Query = 'insert into #DocCount (Document_Code, VerCount)
				select c.Document_Code, count(c.Version)
				from (select distinct ii.Document_Code, ii.Version
				from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn
				where pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and nn.Navigation_ID = 1
				and nn.DeveloperRole_ID in ' + @DeveloperRole +
				' and isnull(nn.Page_ID,0) > 0
				and nn.Page_ID = pvp.Page_ID) c
				group by c.Document_Code'

execute(@Query)

--Insert into Final Doc List those Documents with single versions used
select @Query = 'insert into #FinalDocList (Document_Code, Jurisdiction, Image_Name, VersionList)
			select distinct ii.Document_Code, ii.Jurisdiction, ii.Image_Name , cast(ii.Version as varchar(5))
			from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn, #DocCount dc
			where pvp.Property_Name = ''Page.Background.ImageInfo_ID''
			and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
			and nn.Navigation_ID = 1
			and nn.DeveloperRole_ID in ' + @DeveloperRole +
			' and isnull(nn.Page_ID,0) > 0
			and nn.Page_ID = pvp.Page_ID
			and ii.Document_Code = dc.Document_Code
			and dc.VerCount = 1'

execute(@Query)

--Insert into the DocVersion temp table the Document Code and Versions Used where multiple versions are used
select @Query = 'insert into #DocVersion (Document_Code, Version)
			select distinct ii.Document_Code, cast(ii.Version as varchar(5))
			from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn, #DocCount dc
			where pvp.Property_Name = ''Page.Background.ImageInfo_ID''
			and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
			and nn.Navigation_ID = 1
			and nn.DeveloperRole_ID in ' + @DeveloperRole +
			' and isnull(nn.Page_ID,0) > 0
			and nn.Page_ID = pvp.Page_ID
			and ii.Document_Code = dc.Document_Code
			and dc.VerCount > 1'

execute(@Query)

--Cursor thru the remaining Document Codes in Temp Table 1
declare Cursor_DocCount insensitive scroll cursor for
select Document_Code
from #DocCount
where VerCount > 1

open Cursor_DocCount
fetch from Cursor_DocCount
into @DOCCODE

while (@@FETCH_STATUS <> -1)
begin --Cursor_DocCount
	select @VERSIONSTRING = ''

	declare Cursor_DocVersions insensitive scroll cursor for 
	select Version
	from #DocVersion
	where Document_Code = @DOCCODE

	open    Cursor_DocVersions 

	fetch from Cursor_DocVersions 
	into  @DOCVERS

	while (@@FETCH_STATUS <> -1)
	  begin --Cursor_DocVersions
	----build list of Versions Used
		if @VERSIONSTRING = ''
		begin
		  select @VERSIONSTRING = @DOCVERS
		end
		else
		   begin
			 select @VERSIONSTRING = @VERSIONSTRING + ', ' + @DOCVERS
		   end
	
	  fetch from Cursor_DocVersions 
	  into    @DOCVERS
	   end --Cursor_DocVersions
	   close Cursor_DocVersions
	   deallocate Cursor_DocVersions

 ----populate Temp Table 2
--MDO 09/09/09 for some odd reason, need to add the single quote around the variables
	select @Query =	'insert into #FinalDocList (Document_Code, Jurisdiction, Image_Name, VersionList)
	select Top 1 ''' + @DOCCODE + ''', ii.Jurisdiction, ii.Image_Name , ''' + @VERSIONSTRING + '''
	from ' + @ImageDatabase + '.dbo.ImageInfo ii
	where ii.Document_Code = ''' + @DOCCODE + '''
	order by ii.Version desc'

execute(@Query)
   
fetch from Cursor_DocCount 
into    @DOCCODE
end --Cursor_DocCount
close Cursor_DocCount
deallocate Cursor_DocCount
--Return all values from Temp Table 2

select * from #FinalDocList
order by Document_Code

drop table #DocCount
drop table #DocVersion
drop table #FinalDocList

END

GO

CREATE PROCEDURE spGetFormImageVersionInformationByDeveloperRole (@DeveloperRole varchar(1000),
																@ImageDatabase varchar(64)) AS
BEGIN
	declare @Query as varchar(2500)

	SELECT @Query = 'select distinct ii.Document_Code,ii2.ImageInfo_ID, ii2.Version	
	from	PropertyValuesForPage pvp, '
			+ @ImageDatabase + '.dbo.ImageInfo ii, 
			NavigationNode nn, '
			+ @ImageDatabase + '.dbo.ImageInfo ii2
	where pvp.Property_Name = ''Page.Background.ImageInfo_ID''
	and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
	and nn.Navigation_ID = 1
	and nn.DeveloperRole_ID in ' + @DeveloperRole + 
	' and isnull(nn.Page_ID,0) > 0
	and nn.Page_ID = pvp.Page_ID
	and ii.Document_Code = ii2.Document_Code
	order by ii.Document_Code asc'
	
	execute (@Query)
END
GO

CREATE PROCEDURE spUpdatePageFormImageVersions (	@imageinfo_id int, 
												@roleid varchar(1000),
												@documentCode varchar(10), 
												@version numeric(5,2),
												@imageDatabase varchar(64))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @Query as varchar(2500)
	
	Select @Query = 'Update pvp
	set pvp.Property_Value = '+  cast(@imageinfo_id as nvarchar(8)) + 
	'from	PropertyValuesForPage pvp,
			NavigationNode nn, '
			+ @ImageDatabase + '.dbo.ImageInfo ii
	where pvp.Property_Name = ''Page.Background.ImageInfo_ID''
	and nn.DeveloperRole_ID in ' + @roleid +
	'and nn.Navigation_ID = 1
	and isnull(nn.Page_ID,0) > 0
	and nn.Page_ID = pvp.Page_ID
	and ii.Document_Code = ''' + @documentCode +
	''' and pvp.Property_Value = ii.ImageInfo_ID
	and ii.Version <> ' + cast(@version as nvarchar(5))

	execute(@Query)
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetPageGraphicObjectInformation]	
	@IsPageSearch bit,
	@findItem as varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @QueryString as varchar(3000)
if (@IsPageSearch = 1)
	Begin						
		select @QueryString = 'select p.Page_ID, p.Page_Name, NULL as Comment
								from Page p
								where p.Page_Name like ''%' + @findItem + '%''
								and p.Page_ID not in (select pvp.Page_ID
													 from PropertyValuesForPage pvp
													where pvp.Property_Name = ''Page.Comment'')
								UNION
								select p.Page_ID, p.Page_Name, pvp.Property_Value as Comment
								from Page p, PropertyValuesForPage pvp
								where p.Page_Name like ''%' +  @findItem + '%''
								and p.Page_ID = pvp.Page_ID
								and pvp.Property_Name = ''Page.Comment'' 
								order by p.Page_Name'

		
	End
else
	Begin
		select @QueryString = 'select p.Page_ID, p.Page_Name, NULL as PageComment, g.GraphicObject_ID,g.GraphicObject_Name, 
		NULL as GraphicComment,g.graphicobject_id, g.positionX,g.positionY 
		from Page p, GraphicObject g
		where g.GraphicObject_Name like ''%' + @findItem + '%''
		and g.Page_ID = p.Page_ID
		and p.Page_ID not in (select pvp.Page_ID
								from PropertyValuesForPage pvp
								where pvp.Property_Name = ''Page.Comment'')
		and g.GraphicObject_ID not in (select pvg.GraphicObject_ID
										from PropertyValuesForGraphic pvg
										where pvg.Property_Name = ''Description.Comments''
										and pvg.Page_ID = g.Page_ID)
		UNION
		select p.Page_ID, p.Page_Name, pvp.Property_Value as PageComment, g.GraphicObject_ID,g.GraphicObject_Name, 
		NULL as GraphicComment,g.graphicobject_id, g.positionX,g.positionY 
		 from Page p, GraphicObject g, PropertyValuesForPage pvp
		where g.GraphicObject_Name like ''%' + @findItem + '%''
		and g.Page_ID = p.Page_ID
		and p.Page_ID = pvp.Page_ID
		and pvp.Property_Name = ''Page.Comment''
		and g.GraphicObject_ID not in (select pvg.GraphicObject_ID
										from PropertyValuesForGraphic pvg
										where pvg.Property_Name = ''Description.Comments''
										and pvg.Page_ID = g.Page_ID)
		UNION
		select p.Page_ID, p.Page_Name, NULL as PageComment, g.GraphicObject_ID,g.GraphicObject_Name, 
		pvg.Property_Value as GraphicComment,g.graphicobject_id, g.positionX,g.positionY 
		from Page p, GraphicObject g, PropertyValuesForGraphic pvg
		where g.GraphicObject_Name like ''%' + @findItem + '%''
		and g.Page_ID = p.Page_ID
		and p.Page_ID not in (select pvp.Page_ID
								from PropertyValuesForPage pvp
								where pvp.Property_Name = ''Page.Comment'')
		and g.GraphicObject_ID = pvg.GraphicObject_ID
		and pvg.Property_Name = ''Description.Comments''
		and pvg.Page_ID = g.Page_ID
		UNION
		select p.Page_ID, p.Page_Name, pvp.Property_Value as PageComment, g.GraphicObject_ID,g.GraphicObject_Name, 
		pvg.Property_Value as GraphicComment,g.graphicobject_id, g.positionX,g.positionY 
		from Page p, GraphicObject g, PropertyValuesForGraphic pvg, PropertyValuesForPage pvp
		where g.GraphicObject_Name like ''%' + @findItem + '%''
		and g.Page_ID = p.Page_ID
		and p.Page_ID = pvp.Page_ID
		and pvp.Property_Name = ''Page.Comment''
		and g.GraphicObject_ID = pvg.GraphicObject_ID
		and pvg.Property_Name = ''Description.Comments''
		and pvg.Page_ID = g.Page_ID
		order by p.Page_Name, g.GraphicObject_Name'
	End

exec (@QueryString)

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[spBuildPrintOrderByPage] (@MYPAGEID int)
	
AS
BEGIN
--Group = 3
--EntityGroup = 4
--PVGroup = 6
--Relational=8
--Logical = 22

declare @GRAPHICID int
declare @PAGEID int
declare @GRAPHICENUMTYPE tinyint
declare @YPOSITION smallint
declare @XPOSITION smallint
declare @PARENTGRAPHICID int
declare @PROCESSORDER numeric(9,4)
declare @PARENTEXISTS bit
declare @GROUPCOUNT smallint


create table #ProcessTable (Page_ID int,   ---this is the main table holding the processed objects
							GraphicObject_ID int,
							GraphicObjectType_EnumValue tinyint,
							PositionY smallint,
							PositionX smallint,
							Parent_GraphicObject_ID int,
							ProcessOrder numeric(9,4))

create table #PreProcessTable (Page_ID int,  --this is a temp table holding group objects
								GraphicObject_ID int,
								GraphicObjectType_EnumValue tinyint,
								PositionY smallint,
								PositionX smallint,
								Parent_GraphicObject_ID int,
								ProcessOrder numeric(9,4))

create table #PreProcessChildTable (Page_ID int,  --this is a temp table that holds group children
									GraphicObject_ID int,
									GraphicObjectType_EnumValue tinyint,
									PositionY smallint,
									PositionX smallint,
									Parent_GraphicObject_ID int,
									ProcessOrder numeric(9,4))

create table #MinProcOrderTable (Page_ID int,  --this temp table holds the min ProcessOrder for each group's children
									GraphicObject_ID int,
									ProcessOrder numeric(9,4))

select @PARENTEXISTS = 0

--Get all non-group objects without parents
	--add them to the temp ProcessTable
		--set ProcessOrder = (PositionY + (cast(PositionX as numeric(9,4)) / 10000))
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g
where g.Page_ID = @MYPAGEID
and g.GraphicObjectType_EnumValue not in (3,4,6,8,22)
and isnull(g.Parent_GraphicObject_ID,0) = 0



--Get groups that have no child groups and no parents
		--add to PreProcess temp table 1
insert into #PreProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g
where g.Page_ID = @MYPAGEID
and g.GraphicObjectType_EnumValue in (3,4,6,8,22)
and isnull(g.Parent_GraphicObject_ID,0) = 0
and not exists (select 1 from GraphicObject g1
				where g1.Page_ID = g.Page_ID
				and g1.GraphicObjectType_EnumValue in (3,4,6,8,22)
				and g1.Parent_GraphicObject_ID = g.GraphicObject_ID)

/**************  GROUPS WITH NO PARENTS AN NO CHILD GROUPS  *****************************/
--For groups that have no child group and no parent:
	--assign them the min Y, X position of their children  (change the ProcessOrder to [ProcessOrder - 0.0001])
insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
								Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, #PreProcessTable ppt
where g.Page_ID = ppt.Page_ID
and g.Parent_GraphicObject_ID = ppt.GraphicObject_ID
and g.GraphicObjectType_EnumValue not in (3,4,6,8,22)

--get the minimum process order for the children
insert into #MinProcOrderTable (Page_ID, GraphicObject_ID, ProcessOrder)
select ppct.Page_ID, ppct.Parent_GraphicObject_ID, min(ppct.ProcessOrder)
from #PreProcessChildTable ppct
group by ppct.Page_ID, ppct.Parent_GraphicObject_ID

--update the parent with the minimum process order of the children, less .0001
update ppt
set ppt.ProcessOrder = (mpt.ProcessOrder - 0.0001)
from #PreProcessTable ppt, #MinProcOrderTable mpt
where ppt.Page_ID = mpt.Page_ID
and ppt.GraphicObject_ID = mpt.GraphicObject_ID

--assign the children the min process order of their group
update pct  
set pct.ProcessOrder = mpt.ProcessOrder
from #PreProcessChildTable pct, #MinProcOrderTable mpt
where pct.Page_ID = mpt.Page_ID
and pct.Parent_GraphicObject_ID = mpt.GraphicObject_ID

truncate table #MinProcOrderTable
	--move them from the PreProcess temp table 1 to the ProcessTable

insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select ppt.Page_ID, ppt.GraphicObject_ID, ppt.GraphicObjectType_EnumValue, ppt.PositionY, ppt.PositionX, 
	ppt.Parent_GraphicObject_ID, ppt.ProcessOrder
from #PreProcessTable ppt

--add their children to the ProcessTable
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, pct.PositionY, pct.PositionX, 
	pct.Parent_GraphicObject_ID, pct.ProcessOrder
from #PreProcessChildTable pct

truncate table	#PreProcessTable

truncate table #PreProcessChildTable
 
/**************  GROUPS WITH PARENTS BUT WITHOUT CHILD GROUPS  *****************************/
--Get groups that have no child groups but do have parents.  These are the lowest level in their chain.
		--add to PreProcess temp table 1

insert into #PreProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g
where g.Page_ID = @MYPAGEID
and g.GraphicObjectType_EnumValue in (3,4,6,8,22)
and isnull(g.Parent_GraphicObject_ID,0) <> 0
and not exists (select 1 from GraphicObject g1
				where g1.Page_ID = g.Page_ID
				and g1.GraphicObjectType_EnumValue in (3,4,6,8,22)
				and g1.Parent_GraphicObject_ID = g.GraphicObject_ID)


select @GROUPCOUNT = 0
select @GROUPCOUNT = count(GraphicObject_ID)
from #PreProcessTable

if isnull(@GROUPCOUNT,0) > 0
begin
  select @PARENTEXISTS = 1
end 
		--Get the children and processing order
insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
								Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, #PreProcessTable ppt
where g.Page_ID = ppt.Page_ID
and g.Parent_GraphicObject_ID = ppt.GraphicObject_ID
and g.GraphicObjectType_EnumValue not in (3,4,6,8,22)

--get the minimum process order for the children
insert into #MinProcOrderTable (Page_ID, GraphicObject_ID, ProcessOrder)
select ppct.Page_ID, ppct.Parent_GraphicObject_ID, min(ppct.ProcessOrder)
from #PreProcessChildTable ppct
group by ppct.Page_ID, ppct.Parent_GraphicObject_ID

--update the parent with the minimum process order of the children, less .0001
update ppt
set ppt.ProcessOrder = (mpt.ProcessOrder - 0.0001)
from #PreProcessTable ppt, #MinProcOrderTable mpt
where ppt.Page_ID = mpt.Page_ID
and ppt.GraphicObject_ID = mpt.GraphicObject_ID

--assign the children the min process order of their group
update pct  
set pct.ProcessOrder = mpt.ProcessOrder
from #PreProcessChildTable pct, #MinProcOrderTable mpt
where pct.Page_ID = mpt.Page_ID
and pct.Parent_GraphicObject_ID = mpt.GraphicObject_ID

truncate table #MinProcOrderTable		

--Move the children to the ProcessTable
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, pct.PositionY, pct.PositionX, 
	pct.Parent_GraphicObject_ID, pct.ProcessOrder
from #PreProcessChildTable pct

truncate table #PreProcessChildTable

--while statement
While (@PARENTEXISTS <> 0)
begin
--Process those that have parent groups:

	--recurse up the chain until we've retrieved all groups
		--move the groups from PreProcessTable to Child Table
	insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select ppt.Page_ID, ppt.GraphicObject_ID, ppt.GraphicObjectType_EnumValue, ppt.PositionY, ppt.PositionX, 
	ppt.Parent_GraphicObject_ID, ppt.ProcessOrder
	from #PreProcessTable ppt 

	truncate table #PreProcessTable

	--populate the PreProcessTable with the parents of the children
	insert into #PreProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select distinct g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
	from GraphicObject g, #PreProcessChildTable pct
	where g.Page_ID = pct.Page_ID
	and g.GraphicObjectType_EnumValue in (3,4,6,8,22)
	and g.GraphicObject_ID = pct.Parent_GraphicObject_ID
	
	--populate the child table with additional children
	insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
	from GraphicObject g, #PreProcessTable ppt 
	where g.Page_ID = ppt.Page_ID
	and g.Parent_GraphicObject_ID = ppt.GraphicObject_ID
	and not exists (select 1 from #PreProcessChildTable pct
					where pct.GraphicObject_ID = g.GraphicObject_ID
					and pct.Page_ID = g.Page_ID)

	--assign them the min Y, X position of their children  (change the ProcessOrder to [ProcessOrder - 0.0001])
	--get the minimum process order for the children
	insert into #MinProcOrderTable (Page_ID, GraphicObject_ID, ProcessOrder)
	select ppct.Page_ID, ppct.Parent_GraphicObject_ID, min(ppct.ProcessOrder)
	from #PreProcessChildTable ppct
	group by ppct.Page_ID, ppct.Parent_GraphicObject_ID

	--update the parent with the minimum process order of the children, less .0001
	update ppt
	set ppt.ProcessOrder = (mpt.ProcessOrder - 0.0001)
	from #PreProcessTable ppt, #MinProcOrderTable mpt
	where ppt.Page_ID = mpt.Page_ID
	and ppt.GraphicObject_ID = mpt.GraphicObject_ID

	--assign the children (but not the groups) the min process order of their group
	update pct  
	set pct.ProcessOrder = mpt.ProcessOrder
	from #PreProcessChildTable pct, #MinProcOrderTable mpt
	where pct.Page_ID = mpt.Page_ID
	and pct.Parent_GraphicObject_ID = mpt.GraphicObject_ID
	and pct.GraphicObjectType_EnumValue not in (3,4,6,8,22)

	truncate table #MinProcOrderTable		

   --move them from the PreProcess temp table 1 to the PreProcess temp table 2
	--Move the children to the ProcessTable
	insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, pct.PositionY, pct.PositionX, 
	pct.Parent_GraphicObject_ID, pct.ProcessOrder
	from #PreProcessChildTable pct	

	truncate table #PreProcessChildTable
/* NOW RECURSE THROUGH THE CHAIN UNTIL YOU RUN OUT */
	select @GROUPCOUNT = 0
	select @GROUPCOUNT = count(Parent_GraphicObject_ID)
	from #PreProcessTable
	where isnull(Parent_GraphicObject_ID,0) <> 0

	if isnull(@GROUPCOUNT,0) = 0
	begin
		select @PARENTEXISTS = 0
	end 
--determine whether parent exists
end -- while

--Finally, insert the topmost group parents into the process table
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select ppt.Page_ID, ppt.GraphicObject_ID, ppt.GraphicObjectType_EnumValue, ppt.PositionY, ppt.PositionX, 
	ppt.Parent_GraphicObject_ID, ppt.ProcessOrder
	from #PreProcessTable ppt	

truncate table #PreProcessTable

--Order the whole enchilada by ProcessOrder, PositionY, PositionX

select p.Page_ID, p.Parent_Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, 
pct.PositionX, pct.PositionY, g.Height, g.Width, g.IsShortcut, 
pct.Parent_GraphicObject_ID, g.Linked_GraphicObject_ID,g.DataType_EnumValue
from #ProcessTable pct, Page p, GraphicObject g
where p.Page_ID = pct.Page_ID 
and pct.Page_ID = g.Page_ID
and pct.GraphicObject_ID = g.GraphicObject_ID
ORDER BY pct.ProcessOrder, pct.PositionY,pct.PositionX, g.Height DESC,
g.Width DESC, pct.GraphicObject_ID


drop table #ProcessTable

drop table #PreProcessTable

drop table #PreProcessChildTable

drop table #MinProcOrderTable

END

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBuildPrintOrderByNav] (@NAVIGATIONID int)
	
AS
BEGIN
--Group = 3
--EntityGroup = 4
--PVGroup = 6
--Relational=8
--Logical = 22

declare @GRAPHICID int
declare @PAGEID int
declare @GRAPHICENUMTYPE tinyint
declare @YPOSITION smallint
declare @XPOSITION smallint
declare @PARENTGRAPHICID int
declare @PROCESSORDER numeric(9,4)
declare @PARENTEXISTS bit
declare @GROUPCOUNT smallint

--select @NAVIGATIONID = 600001

create table #ProcessTable (Page_ID int,   ---this is the main table holding the processed objects
							GraphicObject_ID int,
							GraphicObjectType_EnumValue tinyint,
							PositionY smallint,
							PositionX smallint,
							Parent_GraphicObject_ID int,
							ProcessOrder numeric(9,4))

create table #PreProcessTable (Page_ID int,  --this is a temp table holding group objects
								GraphicObject_ID int,
								GraphicObjectType_EnumValue tinyint,
								PositionY smallint,
								PositionX smallint,
								Parent_GraphicObject_ID int,
								ProcessOrder numeric(9,4))

create table #PreProcessChildTable (Page_ID int,  --this is a temp table that holds group children
									GraphicObject_ID int,
									GraphicObjectType_EnumValue tinyint,
									PositionY smallint,
									PositionX smallint,
									Parent_GraphicObject_ID int,
									ProcessOrder numeric(9,4))

create table #MinProcOrderTable (Page_ID int,  --this temp table holds the min ProcessOrder for each group's children
									GraphicObject_ID int,
									ProcessOrder numeric(9,4))

select @PARENTEXISTS = 0

--Get all non-group objects without parents
	--add them to the temp ProcessTable
		--set ProcessOrder = (PositionY + (cast(PositionX as numeric(9,4)) / 10000))
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, NavigationNode nn
where nn.Navigation_ID = @NAVIGATIONID
and nn.Page_ID = g.Page_ID
and g.GraphicObjectType_EnumValue not in (3,4,6,8,22)
and isnull(g.Parent_GraphicObject_ID,0) = 0



--Get groups that have no child groups and no parents
		--add to PreProcess temp table 1
insert into #PreProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, NavigationNode nn
where nn.Navigation_ID = @NAVIGATIONID
and nn.Page_ID = g.Page_ID
and g.GraphicObjectType_EnumValue in (3,4,6,8,22)
and isnull(g.Parent_GraphicObject_ID,0) = 0
and not exists (select 1 from GraphicObject g1
				where g1.Page_ID = g.Page_ID
				and g1.GraphicObjectType_EnumValue in (3,4,6,8,22)
				and g1.Parent_GraphicObject_ID = g.GraphicObject_ID)

/**************  GROUPS WITH NO PARENTS AN NO CHILD GROUPS  *****************************/
--For groups that have no child group and no parent:
	--assign them the min Y, X position of their children  (change the ProcessOrder to [ProcessOrder - 0.0001])
insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
								Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, #PreProcessTable ppt
where g.Page_ID = ppt.Page_ID
and g.Parent_GraphicObject_ID = ppt.GraphicObject_ID
and g.GraphicObjectType_EnumValue not in (3,4,6,8,22)

--get the minimum process order for the children
insert into #MinProcOrderTable (Page_ID, GraphicObject_ID, ProcessOrder)
select ppct.Page_ID, ppct.Parent_GraphicObject_ID, min(ppct.ProcessOrder)
from #PreProcessChildTable ppct
group by ppct.Page_ID, ppct.Parent_GraphicObject_ID

--update the parent with the minimum process order of the children, less .0001
update ppt
set ppt.ProcessOrder = (mpt.ProcessOrder - 0.0001)
from #PreProcessTable ppt, #MinProcOrderTable mpt
where ppt.Page_ID = mpt.Page_ID
and ppt.GraphicObject_ID = mpt.GraphicObject_ID

--assign the children the min process order of their group
update pct  
set pct.ProcessOrder = mpt.ProcessOrder
from #PreProcessChildTable pct, #MinProcOrderTable mpt
where pct.Page_ID = mpt.Page_ID
and pct.Parent_GraphicObject_ID = mpt.GraphicObject_ID

truncate table #MinProcOrderTable
	--move them from the PreProcess temp table 1 to the ProcessTable

insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select ppt.Page_ID, ppt.GraphicObject_ID, ppt.GraphicObjectType_EnumValue, ppt.PositionY, ppt.PositionX, 
	ppt.Parent_GraphicObject_ID, ppt.ProcessOrder
from #PreProcessTable ppt

--add their children to the ProcessTable
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, pct.PositionY, pct.PositionX, 
	pct.Parent_GraphicObject_ID, pct.ProcessOrder
from #PreProcessChildTable pct

truncate table	#PreProcessTable

truncate table #PreProcessChildTable
 
/**************  GROUPS WITH PARENTS BUT WITHOUT CHILD GROUPS  *****************************/
--Get groups that have no child groups but do have parents.  These are the lowest level in their chain.
		--add to PreProcess temp table 1

insert into #PreProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, NavigationNode nn
where nn.Navigation_ID = @NAVIGATIONID
and nn.Page_ID = g.Page_ID
and g.GraphicObjectType_EnumValue in (3,4,6,8,22)
and isnull(g.Parent_GraphicObject_ID,0) <> 0
and not exists (select 1 from GraphicObject g1
				where g1.Page_ID = g.Page_ID
				and g1.GraphicObjectType_EnumValue in (3,4,6,8,22)
				and g1.Parent_GraphicObject_ID = g.GraphicObject_ID)


select @GROUPCOUNT = 0
select @GROUPCOUNT = count(GraphicObject_ID)
from #PreProcessTable

if isnull(@GROUPCOUNT,0) > 0
begin
  select @PARENTEXISTS = 1
end 
		--Get the children and processing order
insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
								Parent_GraphicObject_ID, ProcessOrder)
select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
from GraphicObject g, #PreProcessTable ppt
where g.Page_ID = ppt.Page_ID
and g.Parent_GraphicObject_ID = ppt.GraphicObject_ID
and g.GraphicObjectType_EnumValue not in (3,4,6,8,22)

--get the minimum process order for the children
insert into #MinProcOrderTable (Page_ID, GraphicObject_ID, ProcessOrder)
select ppct.Page_ID, ppct.Parent_GraphicObject_ID, min(ppct.ProcessOrder)
from #PreProcessChildTable ppct
group by ppct.Page_ID, ppct.Parent_GraphicObject_ID

--update the parent with the minimum process order of the children, less .0001
update ppt
set ppt.ProcessOrder = (mpt.ProcessOrder - 0.0001)
from #PreProcessTable ppt, #MinProcOrderTable mpt
where ppt.Page_ID = mpt.Page_ID
and ppt.GraphicObject_ID = mpt.GraphicObject_ID

--assign the children the min process order of their group
update pct  
set pct.ProcessOrder = mpt.ProcessOrder
from #PreProcessChildTable pct, #MinProcOrderTable mpt
where pct.Page_ID = mpt.Page_ID
and pct.Parent_GraphicObject_ID = mpt.GraphicObject_ID

truncate table #MinProcOrderTable		

--Move the children to the ProcessTable
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
select pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, pct.PositionY, pct.PositionX, 
	pct.Parent_GraphicObject_ID, pct.ProcessOrder
from #PreProcessChildTable pct

truncate table #PreProcessChildTable

--while statement
While (@PARENTEXISTS <> 0)
begin
--Process those that have parent groups:
	--recurse up the chain until we've retrieved all groups
		--move the groups from PreProcessTable to Child Table
	insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select ppt.Page_ID, ppt.GraphicObject_ID, ppt.GraphicObjectType_EnumValue, ppt.PositionY, ppt.PositionX, 
	ppt.Parent_GraphicObject_ID, ppt.ProcessOrder
	from #PreProcessTable ppt 

	truncate table #PreProcessTable

	--populate the PreProcessTable with the parents of the children
	insert into #PreProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select distinct g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
	from GraphicObject g, #PreProcessChildTable pct
	where g.Page_ID = pct.Page_ID
	and g.GraphicObjectType_EnumValue in (3,4,6,8,22)
	and g.GraphicObject_ID = pct.Parent_GraphicObject_ID
	

	--populate the child table with additional children
	insert into #PreProcessChildTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select g.Page_ID, g.GraphicObject_ID, g.GraphicObjectType_EnumValue, g.PositionY, g.PositionX, 
	g.Parent_GraphicObject_ID, (g.PositionY + (cast(g.PositionX as numeric(9,4)) / 10000))
	from GraphicObject g, #PreProcessTable ppt 
	where g.Page_ID = ppt.Page_ID
	and g.Parent_GraphicObject_ID = ppt.GraphicObject_ID
	and not exists (select 1 from #PreProcessChildTable pct
					where pct.GraphicObject_ID = g.GraphicObject_ID
					and pct.Page_ID = g.Page_ID)

	--assign them the min Y, X position of their children  (change the ProcessOrder to [ProcessOrder - 0.0001])
	--get the minimum process order for the children
	insert into #MinProcOrderTable (Page_ID, GraphicObject_ID, ProcessOrder)
	select ppct.Page_ID, ppct.Parent_GraphicObject_ID, min(ppct.ProcessOrder)
	from #PreProcessChildTable ppct
	group by ppct.Page_ID, ppct.Parent_GraphicObject_ID

	--update the parent with the minimum process order of the children, less .0001
	update ppt
	set ppt.ProcessOrder = (mpt.ProcessOrder - 0.0001)
	from #PreProcessTable ppt, #MinProcOrderTable mpt
	where ppt.Page_ID = mpt.Page_ID
	and ppt.GraphicObject_ID = mpt.GraphicObject_ID

	--assign the children (but not the groups) the min process order of their group
	update pct  
	set pct.ProcessOrder = mpt.ProcessOrder
	from #PreProcessChildTable pct, #MinProcOrderTable mpt
	where pct.Page_ID = mpt.Page_ID
	and pct.Parent_GraphicObject_ID = mpt.GraphicObject_ID
	and pct.GraphicObjectType_EnumValue not in (3,4,6,8,22)

	truncate table #MinProcOrderTable		

   --move them from the PreProcess temp table 1 to the PreProcess temp table 2
	--Move the children to the ProcessTable
	insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, pct.PositionY, pct.PositionX, 
	pct.Parent_GraphicObject_ID, pct.ProcessOrder
	from #PreProcessChildTable pct	

	truncate table #PreProcessChildTable
/* NOW RECURSE THROUGH THE CHAIN UNTIL YOU RUN OUT */
	select @GROUPCOUNT = 0
	select @GROUPCOUNT = count(Parent_GraphicObject_ID)
	from #PreProcessTable
	where isnull(Parent_GraphicObject_ID,0) <> 0

	if isnull(@GROUPCOUNT,0) = 0
	begin
		select @PARENTEXISTS = 0
	end 
--determine whether parent exists
end -- while

--Finally, insert the topmost group parents into the process table
insert into #ProcessTable (Page_ID, GraphicObject_ID, GraphicObjectType_EnumValue, PositionY, PositionX,
							Parent_GraphicObject_ID, ProcessOrder)
	select ppt.Page_ID, ppt.GraphicObject_ID, ppt.GraphicObjectType_EnumValue, ppt.PositionY, ppt.PositionX, 
	ppt.Parent_GraphicObject_ID, ppt.ProcessOrder
	from #PreProcessTable ppt	

truncate table #PreProcessTable

--Order the whole enchilada by ProcessOrder, PositionY, PositionX

/*
select '#ProcessTable'
select * from #ProcessTable
order by Page_ID, ProcessOrder, PositionY, PositionX
select '#PreProcessTable'
select * from #PreProcessTable
select '#PreProcessChildTable'
select * from #PreProcessChildTable
select '#MinProcOrderTable'
select * from #MinProcOrderTable
*/

select nn.Page_ID, p.Parent_Page_ID, pct.Page_ID, pct.GraphicObject_ID, pct.GraphicObjectType_EnumValue, 
pct.PositionX, pct.PositionY, g.Height, g.Width, g.IsShortcut, 
pct.Parent_GraphicObject_ID, g.Linked_GraphicObject_ID,g.DataType_EnumValue,nn.Navigation_Node_ID
from #ProcessTable pct, NavigationNode nn, Page p, GraphicObject g
where nn.Page_ID = pct.Page_ID 
and nn.Page_ID = p.Page_ID
and pct.Page_ID = g.Page_ID
and pct.GraphicObject_ID = g.GraphicObject_ID
and nn.Navigation_ID = @NAVIGATIONID 
AND (isnull(nn.Page_ID,0) <> 0)
ORDER BY nn.Parent_Node_ID, nn.DisplayOrder,nn.Navigation_Node_ID, 
pct.Page_ID, pct.ProcessOrder, pct.PositionY,pct.PositionX, g.Height DESC,
g.Width DESC, pct.GraphicObject_ID

drop table #ProcessTable

drop table #PreProcessTable

drop table #PreProcessChildTable

drop table #MinProcOrderTable

END

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spFullDisclosureFormStatus] (@NavigationID int,
												 @ImageDatabase varchar(64)) AS
BEGIN
declare @Query varchar(2500)
declare @NoHold tinyint


--create temp table to hold held nodes
create table #HeldNodes (Navigation_Node_ID int,
						 Parent_Node_ID int,
						 NodeType tinyint)

--create temp table to hold Document Code, Version, Jurisdiction, Image Name, Status
create table #FormStatus (Document_Code varchar(10),
							Version numeric(5,2),
							Jurisdiction varchar(255),
							Image_Name varchar(50),
							Status varchar(50))


-- Construct list of Held Images
select @NoHold = 1

if exists (select 1 from NavigationNode nn, PropertyValuesForNode pvn
			where nn.Navigation_ID = @NavigationID
			and nn.Navigation_Node_ID = pvn.Navigation_Node_ID
			and pvn.Property_Name = 'Behavior.EssentialDataTest'
			and pvn.Property_Value = 2)
begin
	select @NoHold = 0  
	insert into #HeldNodes (Navigation_Node_ID, Parent_Node_ID, NodeType)
	select nn.Navigation_Node_ID, nn.Parent_Node_ID, nn.NodeType_EnumValue
	from NavigationNode nn, PropertyValuesForNode pvn
	where nn.Navigation_ID = @NavigationID
	and nn.Navigation_Node_ID = pvn.Navigation_Node_ID
	and pvn.Property_Name = 'Behavior.EssentialDataTest'
	and pvn.Property_Value = 2 -- Hold Print
end
else 
begin
	select @NoHold = 1
end
--Iterate through the tree, finding the descendants of the held node
while @NoHold = 0
begin
	if exists (select 1 from NavigationNode nn, #HeldNodes hn
			where nn.Navigation_ID = @NavigationID
			and nn.Parent_Node_ID = hn.Navigation_Node_ID
			and nn.Navigation_Node_ID not in (select hn1.Navigation_Node_ID from #HeldNodes hn1))
	begin
		select @NoHold = 0  
		insert into #HeldNodes (Navigation_Node_ID, Parent_Node_ID, NodeType)
		select nn.Navigation_Node_ID, nn.Parent_Node_ID, nn.NodeType_EnumValue
		from NavigationNode nn, #HeldNodes hn
		where nn.Navigation_ID = @NavigationID
		and nn.Parent_Node_ID = hn.Navigation_Node_ID
		and nn.Navigation_Node_ID not in (select hn1.Navigation_Node_ID from #HeldNodes hn1)
	end
	else 
	begin
		select @NoHold = 1
	end

end

--Select Forms held out of the app
select @Query = 'insert into #FormStatus (Document_Code, Version, Jurisdiction, Image_Name, Status)
				select distinct ii.Document_Code, ii.Version, ii.Jurisdiction, ii.Image_Name, ''Held Out''
				from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn, #HeldNodes hn
				where nn.Navigation_Node_ID = hn.Navigation_Node_ID
				and hn.NodeType in (6,7,39)
				and nn.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and ii.Jurisdiction <> ''Custom'''

execute(@Query)

--Select Forms released as rolled-over versions of the prior year form
--****This defined as those forms without a history ************

select @Query = 'insert into #FormStatus (Document_Code, Version, Jurisdiction, Image_Name, Status)
				select distinct ii.Document_Code, ii.Version, ii.Jurisdiction, ii.Image_Name, ''Rolled-Over''
				from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn
				where nn.Navigation_ID = ' + cast(@NavigationID as varchar(10)) + 
				' and isnull(nn.Page_ID,0) > 0
				and nn.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and ii.Jurisdiction <> ''Custom''
				and ii.IsRolloverForm = 1
				and not exists (select 1 from #FormStatus fs
								where fs.Document_Code = ii.Document_Code
								and fs.Version = ii.Version)'


execute(@Query)



--Select Forms released as drafts

select @Query = 'insert into #FormStatus (Document_Code, Version, Jurisdiction, Image_Name, Status)
				select distinct ii.Document_Code, ii.Version, ii.Jurisdiction, ii.Image_Name, ''Draft''
				from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn
				where nn.Navigation_ID = ' + cast(@NavigationID as varchar(10)) + 
				' and isnull(nn.Page_ID,0) > 0
				and nn.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and ii.Jurisdiction <> ''Custom''
				and ii.IsDraftForm = 1
				and not exists (select 1 from #FormStatus fs
								where fs.Document_Code = ii.Document_Code
								and fs.Version = ii.Version)'



execute(@Query)



--Select Forms Pending Approval
--***Do not know if this is totally correct, but will look for Draft forms that have whole number version  ***
--The query that we got from the FormsCenter folks doesn't seem to distinguish Draft from Pending Approval

update #FormStatus
set Status = 'Approval Pending'
where Status = 'Draft'
and cast(Version as numeric(5,2)) >= 1.00


select @Query = 'select fs.Document_Code, fs.Version, ej.Enum_Description,ej.Enum_Value, fs.Image_Name,fs.Status
				 from #FormStatus fs, Enum_Jurisdiction ej, ' 
				+ @ImageDatabase + '.dbo.JurisdictionXref jx 
				 where fs.Jurisdiction = jx.ImageJurisExtended
				and jx.EnumJuris = ej.Enum_Description
				order by fs.Status, ej.Enum_Description, fs.Document_Code, fs.Version'


execute(@Query)

drop table #HeldNodes
drop table #FormStatus
END


GO 

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spFullDisclosureWatermarkStatus] (@NavigationID int,
												 @ImageDatabase varchar(64)) AS
BEGIN
declare @Query varchar(2500)


--Select Jurisdiction with Watermarked forms

select @Query = 'select distinct ii.Jurisdiction, ej.Enum_Value
				from PropertyValuesForPage pvp, NavigationNode nn, Enum_Jurisdiction ej, ' 
				+ @ImageDatabase + '.dbo.ImageWatermark iw, ' + @ImageDatabase + '.dbo.ImageInfo ii, '
				+ @ImageDatabase + '.dbo.JurisdictionXref jx 
				where nn.Navigation_ID = ' + cast(@NavigationID as varchar(10)) + 
				' and isnull(nn.Page_ID,0) > 0
				and nn.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and iw.WatermarkStatus in (1,2)
				and isnull(iw.WatermarkTemplate,''NA'') <> ''NA''
				and iw.ImageInfo_Id = ii.ImageInfo_ID
				and ii.Jurisdiction <> ''Custom''
				and ii.Jurisdiction = jx.ImageJurisExtended
				and jx.EnumJuris = ej.Enum_Description
				order by ii.Jurisdiction'



execute(@Query)



END

GO 
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spFullDisclosureFormStatusByAssignment] (@NavigationID int,
												 @ImageDatabase varchar(64),
												 @Developer_ID int) AS
BEGIN
declare @Query varchar(2500)
declare @NoHold tinyint


--create temp table to hold held nodes
create table #HeldNodes (Navigation_Node_ID int,
						 Parent_Node_ID int,
						 NodeType tinyint)

--create temp table to hold Document Code, Version, Jurisdiction, Image Name, Status
create table #FormStatus (Document_Code varchar(10),
							Version numeric(5,2),
							Jurisdiction varchar(50),
							Image_Name varchar(50),
							Status varchar(50),
							ImageInfo_ID int)


-- Construct list of Held Images
select @NoHold = 1

if exists (select 1 from NavigationNode nn, PropertyValuesForNode pvn
			where nn.Navigation_ID = @NavigationID
			and nn.Navigation_Node_ID = pvn.Navigation_Node_ID
			and pvn.Property_Name = 'Behavior.EssentialDataTest'
			and pvn.Property_Value = 2)
begin
	select @NoHold = 0  
	insert into #HeldNodes (Navigation_Node_ID, Parent_Node_ID, NodeType)
	select nn.Navigation_Node_ID, nn.Parent_Node_ID, nn.NodeType_EnumValue
	from NavigationNode nn, PropertyValuesForNode pvn
	where nn.Navigation_ID = @NavigationID
	and nn.Navigation_Node_ID = pvn.Navigation_Node_ID
	and pvn.Property_Name = 'Behavior.EssentialDataTest'
	and pvn.Property_Value = 2 -- Hold Print
end
else 
begin
	select @NoHold = 1
end
--Iterate through the tree, finding the descendants of the held node
while @NoHold = 0
begin
	if exists (select 1 from NavigationNode nn, #HeldNodes hn
			where nn.Navigation_ID = @NavigationID
			and nn.Parent_Node_ID = hn.Navigation_Node_ID
			and nn.Navigation_Node_ID not in (select hn1.Navigation_Node_ID from #HeldNodes hn1))
	begin
		select @NoHold = 0  
		insert into #HeldNodes (Navigation_Node_ID, Parent_Node_ID, NodeType)
		select nn.Navigation_Node_ID, nn.Parent_Node_ID, nn.NodeType_EnumValue
		from NavigationNode nn, #HeldNodes hn
		where nn.Navigation_ID = @NavigationID
		and nn.Parent_Node_ID = hn.Navigation_Node_ID
		and nn.Navigation_Node_ID not in (select hn1.Navigation_Node_ID from #HeldNodes hn1)
	end
	else 
	begin
		select @NoHold = 1
	end

end

--Select Forms held out of the app
select @Query = 'insert into #FormStatus (Document_Code, Version, Jurisdiction, Image_Name, Status, ImageInfo_ID)
				select distinct ii.Document_Code, ii.Version, ii.Jurisdiction, ii.Image_Name, ''Held Out'', ii.ImageInfo_ID
				from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn, #HeldNodes hn
				where nn.Navigation_Node_ID = hn.Navigation_Node_ID
				and hn.NodeType in (6,7,39)
				and nn.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and ii.Jurisdiction <> ''Custom'''

execute(@Query)


--Select Forms released as drafts

select @Query = 'insert into #FormStatus (Document_Code, Version, Jurisdiction, Image_Name, Status, ImageInfo_ID)
				select distinct ii.Document_Code, ii.Version, ii.Jurisdiction, ii.Image_Name, ''Draft'', ii.ImageInfo_ID
				from PropertyValuesForPage pvp, ' + @ImageDatabase + '.dbo.ImageInfo ii, NavigationNode nn
				where nn.Navigation_ID = ' + cast(@NavigationID as varchar(10)) + 
				' and isnull(nn.Page_ID,0) > 0
				and nn.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
				and ii.Jurisdiction <> ''Custom''
				and ii.IsDraftForm = 1
				and not exists (select 1 from #FormStatus fs
								where fs.Document_Code = ii.Document_Code
								and fs.Version = ii.Version)'



execute(@Query)



--Select Forms Pending Approval
--***Do not know if this is totally correct, but will look for Draft forms that have whole number version  ***
--The query that we got from the FormsCenter folks doesn't seem to distinguish Draft from Pending Approval

update #FormStatus
set Status = 'Approval Pending'
where Status = 'Draft'
and cast(Version as numeric(5,2)) >= 1.00





--Select Forms released as rolled-over versions of the prior year form
--****This info is currently unavailable from FormsCenter ************


select @Query = 'select distinct dr.DeveloperRoleName, fs.Status, ej.Enum_Description,ej.Enum_Value, fs.Document_Code, 
				 fs.Version, fs.Image_Name 
				 from #FormStatus fs, NavigationNode nn1, NavigationNode nn2, DeveloperRole dr, PropertyValuesForPage pvp, 
				 DeveloperRoleXref drx, Enum_Jurisdiction ej, ' 
				+ @ImageDatabase + '.dbo.JurisdictionXref jx 
				 where fs.Jurisdiction = jx.ImageJuris
				and jx.EnumJuris = ej.Enum_Description
				and nn1.Navigation_ID = 1
				and nn2.Navigation_ID = ' + cast(@NavigationID as varchar(10)) +
				'and isnull(nn1.Page_ID,0) > 0
				and nn1.Page_ID = pvp.Page_ID
				and pvp.Property_Name = ''Page.Background.ImageInfo_ID''
				and pvp.Property_Value = fs.ImageInfo_ID
				and nn1.Page_ID = nn2.Page_ID
				and nn1.DeveloperRole_ID = dr.DeveloperRole_ID
				and dr.DeveloperRole_ID = drx.DeveloperRole_ID
				and drx.Developer_ID = ' + cast(@Developer_ID as varchar(10)) +
				'order by dr.DeveloperRoleName, fs.Status,ej.Enum_Description, fs.Document_Code, fs.Version, fs.Image_Name'

execute(@Query)

drop table #HeldNodes
drop table #FormStatus
END

GO 

--TFS 73470
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

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO