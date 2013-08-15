
-- creating the store procedure
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spGetCodeScriptParms' 
	   AND 	  type = 'P')
    DROP PROCEDURE spGetCodeScriptParms
GO

CREATE PROCEDURE spGetCodeScriptParms (@CODETYPE tinyint)
	
AS
BEGIN

declare @DETAILLINK tinyint

select @DETAILLINK = 1

select csa.Dependent_ID, csa.Dependent_Page_ID, csa.CodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, cod.Constant_Value, cod.SpecialReturnType_EnumValue, 
csp.Parameter_Enum_DataType, 1 as ParameterIsDetail, 1 as DependentIsDetail, csp.Parameter_Position
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp
where csa.CodeType_EnumValue = @CODETYPE
and csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and exists (select 1 from DataLink dl2
		where dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID
		and dl2.LinkType_EnumValue = @DETAILLINK)
UNION
select csa.Dependent_ID, csa.Dependent_Page_ID, csa.CodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, cod.Constant_Value, cod.SpecialReturnType_EnumValue, 
csp.Parameter_Enum_DataType, 0 as ParameterIsDetail, 1 as DependentIsDetail, csp.Parameter_Position
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp
where csa.CodeType_EnumValue = @CODETYPE
and csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and not exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and exists (select 1 from DataLink dl2
		where dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID
		and dl2.LinkType_EnumValue = @DETAILLINK)
UNION
select csa.Dependent_ID, csa.Dependent_Page_ID, csa.CodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, cod.Constant_Value, cod.SpecialReturnType_EnumValue, 
csp.Parameter_Enum_DataType, 1 as ParameterIsDetail, 0 as DependentIsDetail, csp.Parameter_Position
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp
where csa.CodeType_EnumValue = @CODETYPE
and csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and not exists (select 1 from DataLink dl2
		where dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID
		and dl2.LinkType_EnumValue = @DETAILLINK)
UNION
select csa.Dependent_ID, csa.Dependent_Page_ID, csa.CodeScript_ID, cs.Return_Enum_DataType, cod.ParameterSource_Page_ID, 
cod.ParameterSource_Object_ID, cod.Constant_Value, cod.SpecialReturnType_EnumValue, 
csp.Parameter_Enum_DataType, 0 as ParameterIsDetail, 0 as DependentIsDetail, csp.Parameter_Position
from CodeScriptAssignment csa, CodeScript cs, ComputedObjectDependency cod, CodeScriptParameters csp
where csa.CodeType_EnumValue = @CODETYPE
and csa.CodeScript_ID = cs.Code_ID
and csa.CodeScript_ID = csp.Code_ID
and csa.CodeScriptAssignment_ID = cod.CodeScriptAssignment_ID
and cod.Parameter_ID = csp.Parameter_ID
and not exists (select 1 from DataLink dl
		where dl.LinkTarget_Page_ID = cod.ParameterSource_Page_ID
		and dl.LinkType_EnumValue = @DETAILLINK)
and not exists (select 1 from DataLink dl2
		where dl2.LinkTarget_Page_ID = csa.Dependent_Page_ID
		and dl2.LinkType_EnumValue = @DETAILLINK)
order by csa.Dependent_ID, csa.Dependent_Page_ID, csa.CodeScript_ID, csp.Parameter_Position
 

END	
GO



