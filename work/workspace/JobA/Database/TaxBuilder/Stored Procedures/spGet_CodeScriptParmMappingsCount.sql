SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGet_CodeScriptParmMappingsCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGet_CodeScriptParmMappingsCount]
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

