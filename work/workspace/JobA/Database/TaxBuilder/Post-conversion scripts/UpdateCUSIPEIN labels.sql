--TFS 24424 move specific labels out of the group, remove their code scripts, and set the EveryPage property
declare @PAGEID int
declare @GRAPHICID int
declare @LASTPAGEID int
declare @LASTGRAPHICID int
declare @PROPTEXT varchar(6)

select @LASTPAGEID = 650000
select @LASTGRAPHICID = 650000

declare Cursor_UpdateLabels insensitive scroll cursor for
select p.Page_ID, g1.GraphicObject_ID, cast(pvg1.Property_Value as varchar(6))
from Page p, GraphicObject g1, PropertyValuesForGraphic pvg1
where g1.Page_ID > @LASTPAGEID  
and g1.Page_ID = p.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g1.GraphicObject_ID > @LASTGRAPHICID
and g1.GraphicObjectType_EnumValue = 2 --label
and isnull(g1.Parent_GraphicObject_ID,0) <> 0
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.Text'
and (pvg1.Property_Value = 'CUSIP/'
or pvg1.Property_Value = 'EIN#')

open    Cursor_UpdateLabels 

fetch from Cursor_UpdateLabels 
into    @PAGEID, @GRAPHICID, @PROPTEXT

while (@@FETCH_STATUS <> -1)
begin --Cursor_UpdateLabels
	--remove parent info
	update GraphicObject
	set Parent_GraphicObject_ID = null
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	--set Behavior.PrintOnPage = Everypage
	if exists (select 1
				from PropertyValuesForGraphic
				where Page_ID = @PAGEID
				and GraphicObject_ID = @GRAPHICID 
				and Property_Name = 'Behavior.PrintOnPage')
	begin --if property exists
		update PropertyValuesForGraphic
		set Property_Value = 2 --Everypage
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID 
		and Property_Name = 'Behavior.PrintOnPage'
	end--if property exists
	else 
	begin--if property does not exist
		insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
		values (@PAGEID, @GRAPHICID, 'Behavior.PrintOnPage', 2)

	end --if property does not exist


	--remove code script assignment
	--remove FADSConstraintDependency
	delete fcd
	from FADSConstraintDependency fcd, CodeScriptAssignment csa
	where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
	and csa.Dependent_Page_ID = @PAGEID
	and csa.Dependent_ID = @GRAPHICID

	--remove CodeScriptAssignment
	delete csa
	from CodeScriptAssignment csa
	where csa.Dependent_Page_ID = @PAGEID
	and csa.Dependent_ID = @GRAPHICID

	--remove Constraint.AssignmentID property
	delete pvg
	from PropertyValuesForGraphic pvg
	where pvg.Page_ID = @PAGEID
	and pvg.GraphicObject_ID = @GRAPHICID
	and pvg.Property_Name = 'Constraint.AssignmentID'

--adjust groupbox height
	if @PROPTEXT = 'EIN#'
	begin
	--increase Yposition and reduce height of groupboxes by 100 pixels
	  update GraphicObject
	  set PositionY = (PositionY + 100), Height = (Height - 100)
	  where Page_ID = @PAGEID
	  and GraphicObjectType_EnumValue = 3
	  and PositionY < 500

	end --@PROPTEXT = 'EIN#'
	

fetch from Cursor_UpdateLabels 
   into    @PAGEID, @GRAPHICID, @PROPTEXT
end --Cursor_UpdateLabels

close Cursor_UpdateLabels
deallocate Cursor_UpdateLabels 
