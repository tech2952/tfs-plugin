use TaxBuilder2009
GO

--Upgrade the 2008 Production Database from version 3.03 to 3.03e

--*****  CREATE UNIQUE INSTANCES OF EACH SHARED CODE SCRIPT that uses constants *********

--Get the list of shared code scripts and their parameters

--For each shared code script, get the list of CodeScriptAssignments for this code script
--keep the first instance
--for every other instance,
	--add a copy to the CodeScript table
	--get the new Code_ID
	--update the CodeScriptAssignment table with the new CodeScript_ID
	--add a copy to the CodeScriptTestCase table with new CodeScript_ID
	--get the new TestCase_ID
	--for each original Parameter_ID that does not have a constant assigned,
		--add a copy to the CodeScriptParameters, using the new Code_ID
		--get the new parameter ID
		--update the FADSConstraintDependency table with the new Parameter_ID
		--add a copy to the CodeScriptTestCaseValues table with the new Parameter_ID and new TestCase_ID
    --for each original Parameter_ID that does have a constant assigned
		--get the original Parameter_Name and datatype
		--get the constant value assigned to the parameter (if it's a string then wrap it in quotes)
		--update the Code_Syntax by replacing the Parameter_Name with the constant value 

declare @ORIGINALCODESCRIPTID int
declare @NEWCODESCRIPTID int
declare @ORIGINALPARAMETERID int
declare @NEWPARAMETERID int
declare @ORIGINALTESTCASEID int
declare @NEWTESTCASEID int
declare @CODESCRIPTASSIGNMENTID int
declare @PARAMETERDATATYPE tinyint
declare @PARAMETERNAME varchar(100)
declare @SYNTAXUPDATE varchar(100)
declare @CONSTANTVALUE varchar(15)
declare @INSTANCE  smallint

DECLARE CodeScripts CURSOR FOR
select distinct csa.CodeScript_ID 
from FADSConstraintDependency fcd, CodeScriptAssignment csa
where fcd.Constant_Value is NOT NULL
and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
order by csa.CodeScript_ID

OPEN CodeScripts

FETCH NEXT FROM CodeScripts
INTO @ORIGINALCODESCRIPTID

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
	select @INSTANCE = 1
    select @INSTANCE = count(CodeScriptAssignment_ID)
	from CodeScriptAssignment
	where CodeScript_ID = @ORIGINALCODESCRIPTID

    if @INSTANCE = 1
    begin
	  select @CODESCRIPTASSIGNMENTID = CodeScriptAssignment_ID
	  from CodeScriptAssignment
	  where CodeScript_ID = @ORIGINALCODESCRIPTID
	  
	  DECLARE ScriptParameters2 CURSOR FOR
		select csp.Parameter_ID, csp.Parameter_Name, csp.Parameter_Enum_DataType, cast(fcd.Constant_Value as varchar(15))
		from CodeScriptParameters csp, FADSConstraintDependency fcd
		where csp.Code_ID = @ORIGINALCODESCRIPTID
		and fcd.CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID
		and csp.Parameter_ID = fcd.Parameter_ID
		and fcd.Constant_Value is NOT NULL
		order by csp.Parameter_ID

		OPEN ScriptParameters2

		FETCH NEXT FROM ScriptParameters2
		INTO @ORIGINALPARAMETERID, @PARAMETERNAME, @PARAMETERDATATYPE, @CONSTANTVALUE

			-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
		WHILE @@FETCH_STATUS = 0
		BEGIN --ScriptParameters2 Cursor
				
		--get the constant value assigned to the parameter (if it's a string then wrap it in quotes)
			if @PARAMETERDATATYPE = 2
			begin
				 select @SYNTAXUPDATE = '"' + @CONSTANTVALUE + '"'
			end
			else
			begin
				 select @SYNTAXUPDATE = @CONSTANTVALUE
			end

		--update the Code_Syntax by replacing the Parameter_Name with the constant value 
			update CodeScript
			set Code_Syntax = REPLACE(Code_Syntax, @PARAMETERNAME, @SYNTAXUPDATE)
			where Code_ID = @ORIGINALCODESCRIPTID

		--delete any TestCaseEntries for this parameter
			delete from CodeScriptTestCaseValues
			where Parameter_ID = @ORIGINALPARAMETERID
			
		--delete any FADSConstraintDependency for this parameter
			delete from FADSConstraintDependency
			where Parameter_ID = @ORIGINALPARAMETERID
			and CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID

		--delete the entry in the CodeScriptParameters table
			delete from CodeScriptParameters
			where Parameter_ID = @ORIGINALPARAMETERID

			FETCH NEXT FROM ScriptParameters2
			INTO @ORIGINALPARAMETERID, @PARAMETERNAME, @PARAMETERDATATYPE, @CONSTANTVALUE
		END --ScriptParameters2 Cursor

		CLOSE ScriptParameters2
		DEALLOCATE ScriptParameters2

    end --if @INSTANCE = 1
    else
    begin --if @INSTANCE > 1

	select @ORIGINALTESTCASEID = TestCase_ID
			from CodeScriptTestCase
			where Code_ID = @ORIGINALCODESCRIPTID

	DECLARE CodeScriptAssignments CURSOR FOR
	  select distinct csa.CodeScriptAssignment_ID 
	  from FADSConstraintDependency fcd, CodeScriptAssignment csa
	  where fcd.Constant_Value is NOT NULL
	  and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
	  and csa.CodeScript_ID = @ORIGINALCODESCRIPTID
	  order by csa.CodeScriptAssignment_ID
	  
	OPEN CodeScriptAssignments

	FETCH NEXT FROM CodeScriptAssignments
	INTO @CODESCRIPTASSIGNMENTID

	-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
	WHILE @@FETCH_STATUS = 0
	BEGIN --CodeScriptAssignment Cursor

			--add a copy to the CodeScript table
			insert into CodeScript(Code_Name, Code_Description, Return_Enum_DataType, Code_Syntax, DateCreated, DateLastSaved, IsSystemCode)
			select Code_Name, Code_Description, Return_Enum_DataType, Code_Syntax, DateCreated, DateLastSaved, IsSystemCode
			from CodeScript
			where Code_ID = @ORIGINALCODESCRIPTID
			--get the new Code_ID
			select @NEWCODESCRIPTID = @@IDENTITY
			--update the CodeScriptAssignment table with the new CodeScript_ID
			update CodeScriptAssignment
			set CodeScript_ID = @NEWCODESCRIPTID
			where CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID
			--add a copy to the CodeScriptTestCase table with new CodeScript_ID
			insert into CodeScriptTestCase (Code_ID, Test_Name, Test_Description, ExpectedResult_Value)
			select @NEWCODESCRIPTID, Test_Name, Test_Description, ExpectedResult_Value
			from CodeScriptTestCase
			where TestCase_ID = @ORIGINALTESTCASEID
			--get the new TestCase_ID
			select @NEWTESTCASEID = @@IDENTITY

			--deal with parameters that have no constant values
			DECLARE ScriptParameters CURSOR FOR
			  select csp.Parameter_ID
			  from CodeScriptParameters csp, FADSConstraintDependency fcd
			  where csp.Code_ID = @ORIGINALCODESCRIPTID
			  and fcd.CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID
			  and csp.Parameter_ID = fcd.Parameter_ID
			  and fcd.Constant_Value is NULL
			  order by csp.Parameter_ID

			OPEN ScriptParameters

			FETCH NEXT FROM ScriptParameters
			INTO @ORIGINALPARAMETERID

			-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
			WHILE @@FETCH_STATUS = 0
			BEGIN --ScriptParameters Cursor
				--add a copy to the CodeScriptParameters, using the new Code_ID
				insert into CodeScriptParameters(Code_ID, Parameter_Name, Parameter_Enum_DataType, Parameter_Position)
				select @NEWCODESCRIPTID, Parameter_Name, Parameter_Enum_DataType, Parameter_Position
				from CodeScriptParameters
				where Code_ID = @ORIGINALCODESCRIPTID
				and Parameter_ID = @ORIGINALPARAMETERID

				--get the new parameter ID
				select @NEWPARAMETERID = @@IDENTITY

				--update the FADSConstraintDependency table with the new Parameter_ID
				update FADSConstraintDependency
				set Parameter_ID = @NEWPARAMETERID
				where CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID
				and Parameter_ID = @ORIGINALPARAMETERID

				--add a copy to the CodeScriptTestCaseValues table with the new Parameter_ID and new TestCase_ID
				insert into CodeScriptTestCaseValues (TestCase_ID, Parameter_ID, ParameterInputValue)
				select @NEWTESTCASEID, @NEWPARAMETERID, ParameterInputValue
				from CodeScriptTestCaseValues
				where TestCase_ID = @ORIGINALTESTCASEID
				and Parameter_ID = @NEWPARAMETERID

				FETCH NEXT FROM ScriptParameters
				INTO @ORIGINALPARAMETERID
			END --ScriptParameters Cursor

			CLOSE ScriptParameters
			DEALLOCATE ScriptParameters


			DECLARE ScriptParameters2 CURSOR FOR
			  select csp.Parameter_ID, csp.Parameter_Name, csp.Parameter_Enum_DataType, cast(fcd.Constant_Value as varchar(15))
			  from CodeScriptParameters csp, FADSConstraintDependency fcd
			  where csp.Code_ID = @ORIGINALCODESCRIPTID
			  and fcd.CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID
			  and csp.Parameter_ID = fcd.Parameter_ID
			  and fcd.Constant_Value is NOT NULL
			  order by csp.Parameter_ID

			OPEN ScriptParameters2

			FETCH NEXT FROM ScriptParameters2
			INTO @ORIGINALPARAMETERID, @PARAMETERNAME, @PARAMETERDATATYPE, @CONSTANTVALUE

			-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
			WHILE @@FETCH_STATUS = 0
			BEGIN --ScriptParameters2 Cursor
				--get the original Parameter_Name and datatype
		--get the constant value assigned to the parameter (if it's a string then wrap it in quotes)
				if @PARAMETERDATATYPE = 2
				begin
				  select @SYNTAXUPDATE = '"' + @CONSTANTVALUE + '"'
				end
				else
				begin
				  select @SYNTAXUPDATE = @CONSTANTVALUE
				end

		--update the Code_Syntax by replacing the Parameter_Name with the constant value 
				update CodeScript
				set Code_Syntax = REPLACE(Code_Syntax, @PARAMETERNAME, @SYNTAXUPDATE)
				where Code_ID = @NEWCODESCRIPTID

		--delete any FADSConstraintDependency for this parameter
			delete from FADSConstraintDependency
			where Parameter_ID = @ORIGINALPARAMETERID
			and CodeScriptAssignment_ID = @CODESCRIPTASSIGNMENTID

				FETCH NEXT FROM ScriptParameters2
				INTO @ORIGINALPARAMETERID, @PARAMETERNAME, @PARAMETERDATATYPE, @CONSTANTVALUE
			END --ScriptParameters2 Cursor

			CLOSE ScriptParameters2
			DEALLOCATE ScriptParameters2

		
		FETCH NEXT FROM CodeScriptAssignments
		INTO @CODESCRIPTASSIGNMENTID
	END --CodeScriptAssignment Cursor

	CLOSE CodeScriptAssignments
	DEALLOCATE CodeScriptAssignments

   end -- if @INSTANCE > 1

   FETCH NEXT FROM CodeScripts
   INTO @ORIGINALCODESCRIPTID
END

CLOSE CodeScripts
DEALLOCATE CodeScripts


/***********  Upgrade to FontIndex    ****************/
declare @FONTNAME varchar(100)
declare @FONTINDEX tinyint

--go through each index 0 thru 15, find matching font entry, and change it to Font index for PVG and PVP tables

select @FONTINDEX = 0
--select @FONTNAME = '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
while (@FONTINDEX < 16)
begin
   select @FONTNAME = (case @FONTINDEX 
						when 0 then '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 1 then '[Font: Name=Courier New, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 2 then '[Font: Name=Courier New, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]' 
						when 3 then '[Font: Name=OCR A MT, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]' 
						when 4 then '[Font: Name=Courier New, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]' 
						when 5 then '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]' 
						when 6 then '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]' 
						when 7 then '[Font: Name=Courier New, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]'
						when 8 then '[Font: Name=Courier New, Size=11, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 9 then '[Font: Name=Courier New, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 10 then '[Font: Name=Courier New, Size=11, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]'
						when 11 then '[Font: Name=Courier New, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]'
						when 12 then '[Font: Name=Courier New, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]'
						when 13 then '[Font: Name=Courier New, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]'
						when 14 then '[Font: Name=OCR A MT, Size=11, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 15 then '[Font: Name=Times New Roman, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
					end )



insert into PropertyValuesForPage (Page_ID, Property_Name, Property_Value)
select pvp1.Page_ID,  'Appearance.FontIndex', @FONTINDEX
from PropertyValuesForPage pvp1
where pvp1.Property_Name = 'Appearance.Font'
and pvp1.Property_Value = @FONTNAME
and not exists (select 1
				from PropertyValuesForPage pvp2
				where pvp2.Page_ID = pvp1.Page_ID
				and pvp2.Property_Name = 'Appearance.FontIndex')


insert into PropertyValuesForGraphic (GraphicObject_ID, Page_ID, Property_Name, Property_Value)
select pvg1.GraphicObject_ID, pvg1.Page_ID, 'Appearance.FontIndex', @FONTINDEX
from PropertyValuesForGraphic pvg1
where pvg1.Property_Name = 'Appearance.Font'
and pvg1.Property_Value = @FONTNAME
and not exists (select 1
				from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = pvg1.Page_ID
				and pvg2.GraphicObject_ID = pvg1.GraphicObject_ID
				and pvg2.Property_Name = 'Appearance.FontIndex')

--At the end, delete the Appearance.Font records where an Appearance.FontIndex record exists
delete pvp1
from PropertyValuesForPage pvp1, PropertyValuesForPage pvp2
where pvp1.Page_ID = pvp2.Page_ID
and pvp1.Property_Name = 'Appearance.Font'
and pvp2.Property_Name = 'Appearance.FontIndex'

delete pvg1
from PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where pvg1.Page_ID = pvg2.Page_ID
and pvg1.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.Font'
and pvg2.Property_Name = 'Appearance.FontIndex'


select @FONTINDEX = (@FONTINDEX + 1)

end -- while


/***********  Update Enumerations    ****************/

insert into Enum_GraphicObjectType (Enum_Value, Enum_Description)
values (21, 'ShadowBox')
GO

insert into Enum_GraphicObjectType (Enum_Value, Enum_Description)
values (22, 'LogicalGroup')
GO

insert into Enum_GraphicObjectType (Enum_Value, Enum_Description)
values (23, 'RelationalUpperBoundary')
GO


insert into Enum_SpecialTextType (Enum_Value, Enum_Description)
values (15, 'SubsidiaryPartnershipName')
GO

update Enum_SpecialTextType
set Enum_Description = 'ClientCode'
where Enum_Value = 8

update Enum_SpecialTextType
set Enum_Description = 'Unused'
where Enum_Value = 9

update Enum_SpecialTextType
set Enum_Description = 'LocatorAccount'
where Enum_Value = 10

/***********  Update Properties    ****************/

--Barcode Only to PrintOnPage
insert into PropertyValuesForGraphic (GraphicObject_ID, Page_ID, Property_Name, Property_Value)
select pvg1.GraphicObject_ID, pvg1.Page_ID, 'Behavior.PrintOnPage', 0
from PropertyValuesForGraphic pvg1
where pvg1.Property_Name = 'Behavior.BarcodeOnly'
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg1.GraphicObject_ID = pvg2.GraphicObject_ID
				and pvg1.Page_ID = pvg2.Page_ID
				and pvg2.Property_Name = 'Behavior.PrintOnPage')



--Updated property names
--old property for group box = 'Group.CheckForEssentialData'
--old property for entity group = 'EntityGroup.DataExists'
--new property for both = 'Behavior.PrintIfNoEssentialData'
update PropertyValuesForGraphic
set Property_Name = 'Group.PrintIfNoEssentialData'
where Property_Name in ('Group.CheckForEssentialData', 'EntityGroup.DataExists')



--old property for entity group = 'EntityLoop.DataExists'
--new property for both = 'Loop.PrintIfNoEssentialData'
update PropertyValuesForNode
set Property_Name = 'Loop.PrintIfNoEssentialData'
where Property_Name = 'EntityLoop.DataExists'

/***********  New Stored Procedures    ****************/

--New proc drop commands
IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spAudit_NewerVersionsOfFormsExist' 
	   AND 	  type = 'P')
    DROP PROCEDURE spAudit_NewerVersionsOfFormsExist
GO


IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spAudit_CodeScriptTestCaseErrors' 
	   AND 	  type = 'P')
    DROP PROCEDURE spAudit_CodeScriptTestCaseErrors
GO

IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spAudit_CodeScriptCompilation' 
	   AND 	  type = 'P')
    DROP PROCEDURE spAudit_CodeScriptCompilation
GO


IF EXISTS (SELECT name 
	   FROM   sysobjects 
	   WHERE  name = N'spGet_PotentialHyperlinkTargets' 
	   AND 	  type = 'P')
    DROP PROCEDURE spGet_PotentialHyperlinkTargets
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

GRANT  EXECUTE  ON [dbo].[spAudit_CodeScriptTestCaseErrors]  TO [G-TTA-Taxbuilder]
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


GRANT  EXECUTE  ON [dbo].[spAudit_CodeScriptCompilation]  TO [G-TTA-Taxbuilder]
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
order by dr.DeveloperRoleName, nn.Node_Name


END
GO


GRANT  EXECUTE  ON [dbo].[spGet_PotentialHyperlinkTargets]  TO [G-TTA-Taxbuilder]
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

--Modify existing procs

ALTER PROCEDURE [dbo].[spGet_Graphic_ID_of_Graphics_Without_FADS_Field_Property]
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
	order by n.DeveloperRole_ID, p.Page_ID, g.GraphicObject_ID
	END
END



SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO


--Alter existing procedure
ALTER PROCEDURE [dbo].[spGet_Overlapping_Graphics]
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
	order by n.DeveloperRole_ID, g1.Page_ID, g1.GraphicObject_ID
END
ELSE
BEGIN
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
	order by n.DeveloperRole_ID, g1.Page_ID, g1.GraphicObject_ID
END

end


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spBuildMyTree] (	@DEVELOPERID int,
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

declare NavigationNode CURSOR FOR
select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
from NavigationNode nn, DeveloperRoleXref drx
where nn.Navigation_ID = @NAVIGATIONID
and nn.DeveloperRole_ID = drx.DeveloperRole_ID
and drx.Developer_ID = @DEVELOPERID
and nn.NodeType_EnumValue not in (4,5,11) --Root or Header node or shortcuts

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

select * from #TempNavTree
order by Indent_Level, DisplayOrder

drop table #TempNavTree

END


SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spBuildMyCodeScripts] (	@DEVELOPERID int,
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

   declare NavigationNode CURSOR FOR
   select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
	nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
	from NavigationNode nn, DeveloperRoleXref drx
	where nn.Navigation_ID = @NAVIGATIONID
	and nn.DeveloperRole_ID = drx.DeveloperRole_ID
	and drx.Developer_ID = @DEVELOPERID
	and nn.NodeType_EnumValue not in (4,5,11) --Root or Header node or shortcuts

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO


--Change the Primary Key on the CodeScriptBaseScriptXref table
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PK_CodeScriptBaseScriptXref]') and OBJECTPROPERTY(id, N'IsPrimaryKey') = 1)
ALTER TABLE [dbo].[CodeScriptBaseScriptXref] DROP CONSTRAINT [PK_CodeScriptBaseScriptXref]
GO


ALTER TABLE [dbo].[CodeScriptBaseScriptXref] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScriptBaseScriptXref] PRIMARY KEY  CLUSTERED 
	(
		[CodeScript_ID]
	)  ON [PRIMARY] 
GO

--Add a Stored Value column to the Value List Item table

ALTER TABLE [dbo].[ValueListItem] 
DROP COLUMN [ValueListItem_Description]

GO

ALTER TABLE [dbo].[ValueListItem] 
ADD [Stored_Value] [objectname] NULL

GO

update ValueListItem
set Stored_Value = ValueListItem_Name

GO

ALTER TABLE [dbo].[ValueListItem] 
ALTER COLUMN [Stored_Value] [objectname] NOT NULL

GO

-- Delete Constant_Value column from FADSConstraintDependency table

ALTER TABLE [dbo].[FADSConstraintDependency] 
DROP COLUMN [Constant_Value]

GO


-- Delete Constant_Value column from ComputedObjectDependency table

ALTER TABLE [dbo].[ComputedObjectDependency] 
DROP COLUMN [Constant_Value]

GO


-- Delete Code_Description column from CodeScript table

ALTER TABLE [dbo].[CodeScript] 
DROP COLUMN [Code_Description]

GO

-- Delete Test_Description column from CodeScriptTestCase table

ALTER TABLE [dbo].[CodeScriptTestCase] 
DROP COLUMN [Test_Description]

GO

--Delete the Enum_SpecialReturnType table
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ComputedObjectDependency_Enum_SpecialReturnType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ComputedObjectDependency] DROP CONSTRAINT FK_ComputedObjectDependency_Enum_SpecialReturnType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSConstraintDependency_Enum_SpecialReturnType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSConstraintDependency] DROP CONSTRAINT FK_FADSConstraintDependency_Enum_SpecialReturnType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_SpecialReturnType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_SpecialReturnType]
GO

ALTER TABLE [dbo].[FADSConstraintDependency] 
DROP COLUMN [SpecialReturnType_EnumValue]

GO

ALTER TABLE [dbo].[ComputedObjectDependency] 
DROP COLUMN [SpecialReturnType_EnumValue]

GO

--Delete the ImageInfo and ImageObject tables, as they are moving to a separate database
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ImageInfo_ImageObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ImageInfo] DROP CONSTRAINT FK_ImageInfo_ImageObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImageObject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImageObject]
GO


--Update Enterprise Info
update Enterprise_Information
set DB_Version = '4.00', Product_Year = 2009


--Add Proc
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetPageGraphicObjectInformation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetPageGraphicObjectInformation]
GO

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

GRANT  EXECUTE  ON [dbo].[spGetPageGraphicObjectInformation]  TO [G-TTA-Taxbuilder]
GO



--Update these procs to look for the TaxBuilder4Images database when using images
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spBuildMyFormImages]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spBuildMyFormImages]
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

GRANT  EXECUTE  ON [dbo].[spAudit_NewerVersionsOfFormsExist]  TO [G-TTA-Taxbuilder]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

--Update this proc for updated schema elements

ALTER PROCEDURE spGet_ComputeProcessingInfo (@CODETYPE tinyint,
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

--assign form images from common images database

delete pvp
from PropertyValuesForPage pvp, TaxBuilderImages.dbo.ImageInfo ii1
where pvp.Property_Name = 'Page.Background.ImageInfo_ID'
and pvp.Property_Value = ii1.ImageInfo_ID
and not exists (select 1 from TaxBuilderImages.dbo.ImageInfo ii2
				where ii1.Document_Code = ii2.Document_Code
				and ii1.Version = ii2.Version)

update pvp
set pvp.Property_Value = ii2.ImageInfo_ID
from PropertyValuesForPage pvp, TaxBuilderImages.dbo.ImageInfo ii1, TaxBuilderImages.dbo.ImageInfo ii2
where pvp.Property_Name = 'Page.Background.ImageInfo_ID'
and pvp.Property_Value = ii1.ImageInfo_ID
and ii1.Document_Code = ii2.Document_Code
and ii1.Version = ii2.Version


--- 4.00 to 4.01
CREATE PROCEDURE spGetFormImageInformationByDeveloperRole (	@DeveloperRole varchar(1000),
															@ImageDatabase varchar(64)) AS
BEGIN
	SET NOCOUNT ON;
	declare @Query varchar(2500)
	select @Query = 'select distinct ii.Document_Code, ii.Jurisdiction, ii.Image_Name
	from	PropertyValuesForPage pvp,'
			+ @ImageDatabase + '.dbo.ImageInfo ii, 
			NavigationNode nn
	where pvp.Property_Name = ''Page.Background.ImageInfo_ID''
	and cast(pvp.Property_Value as int) = ii.ImageInfo_ID
	and nn.Navigation_ID = 1
	and nn.DeveloperRole_ID in ' + @DeveloperRole +
	' and isnull(nn.Page_ID,0) > 0
	and nn.Page_ID = pvp.Page_ID
	order by ii.Document_Code asc'

	execute(@query)
END
GRANT  EXECUTE  ON [dbo].[spGetFormImageInformationByDeveloperRole]  TO [G-TTA-Taxbuilder]
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
GRANT  EXECUTE  ON [dbo].[spGetFormImageVersionInformationByDeveloperRole]  TO [G-TTA-Taxbuilder]
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
GRANT  EXECUTE  ON [dbo].[spUpdatePageFormImageVersions]  TO [G-TTA-Taxbuilder]

--spBuildMyTree
ALTER PROCEDURE [dbo].[spBuildMyTree] (	@DEVELOPERID int,
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

declare NavigationNode CURSOR FOR
select nn.Navigation_Node_ID, nn.NodeType_EnumValue, nn.Node_Name, nn.Parent_Node_ID, nn.DisplayOrder, 
nn.Indent_Level, nn.DeveloperRole_ID, nn.Page_ID, nn.AlternateAction_Node_ID, nn.ShortCut_Node_ID
from NavigationNode nn, DeveloperRoleXref drx
where nn.Navigation_ID = @NAVIGATIONID
and nn.DeveloperRole_ID = drx.DeveloperRole_ID
and drx.Developer_ID = @DEVELOPERID
and nn.NodeType_EnumValue not in (4,5) --,11) --Root or Header node  -- TFS 25860 to include shortcuts 

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

select * from #TempNavTree
order by Indent_Level, DisplayOrder

drop table #TempNavTree

END