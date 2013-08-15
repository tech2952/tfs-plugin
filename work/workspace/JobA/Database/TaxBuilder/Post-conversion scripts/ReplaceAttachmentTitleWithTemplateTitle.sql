declare @LIVINGTEMPLATE int
declare @LIVINGOBJECTID int
declare @PAGEID int
declare @GRAPHICOBJECTID int
declare @NEWTEXT nvarchar(100)

select @LIVINGTEMPLATE = -1
select @LIVINGOBJECTID = -1



DECLARE Attachment_Cursor CURSOR FOR
select g.Page_ID, g.GraphicObject_ID, cast(pvg.Property_Value as nvarchar(100))
from GraphicObject g, PropertyValuesForGraphic pvg, Page p
where p.PageType_EnumValue in (1,9,10) --attachment, continuation, report
and p.Parent_Page_ID = @LIVINGTEMPLATE
and p.Page_ID = g.Page_ID
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 2
and pvg.Property_Name = 'Appearance.Text'
and cast(pvg.Property_Value as varchar(250)) like '%Supporting%'
and g.PositionY = 150
and g.PositionX = 60

OPEN Attachment_Cursor

FETCH NEXT FROM Attachment_Cursor
INTO @PAGEID, @GRAPHICOBJECTID, @NEWTEXT

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
	--Insert override value into PropertyValuesForGraphic table
	insert into PropertyValuesForGraphic(Page_ID, GraphicObject_ID, Property_Name, Property_Value)
	values (@PAGEID, @LIVINGOBJECTID, 'Appearance.Text', @NEWTEXT)

	--delete the existing label
	--delete PropertyValueForGraphic entries
	delete from PropertyValuesForGraphic
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICOBJECTID

   --delete FADSContraintDependency entries 
	delete fcd
	from FADSConstraintDependency fcd, CodeScriptAssignment csa
	where csa.Dependent_Page_ID = @PAGEID
	and csa.Dependent_ID = @GRAPHICOBJECTID
	and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID

   --delete CodeScriptAssignments entries
	delete from CodeScriptAssignment
	where Dependent_Page_ID = @PAGEID
	and Dependent_ID = @GRAPHICOBJECTID

   --delete GraphicObject entries
	delete from GraphicObject
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICOBJECTID


FETCH NEXT FROM Attachment_Cursor
   INTO @PAGEID, @GRAPHICOBJECTID, @NEWTEXT
END

CLOSE Attachment_Cursor
DEALLOCATE Attachment_Cursor