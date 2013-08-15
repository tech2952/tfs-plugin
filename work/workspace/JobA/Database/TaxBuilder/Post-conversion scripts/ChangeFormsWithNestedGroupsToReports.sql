--change forms to reports when they have nested groups

declare @PAGEID int
declare @MINY smallint
declare @NEWY smallint
declare @NEWGID int
declare @WIDTH smallint


SET NOCOUNT ON

DECLARE Form_Cursor CURSOR FOR
select p.Page_ID, min(g2.PositionY)
from GraphicObject g1, Page p, GraphicObject g2
where g1.GraphicObjectType_EnumValue = 3  --child GROUPBOX in g1
and g1.Page_ID = p.Page_ID
and p.PageType_EnumValue = 0
and p.Page_ID > 600000  --use this to filter the list of pages modified
and g1.Page_ID = g2.Page_ID
and g1.Parent_GraphicObject_ID = g2.GraphicObject_ID  --parent groupbox in g2
and g2.GraphicObjectType_EnumValue = 3
and p.PageType_EnumValue = 0
and exists (select 1 from GraphicObject g3  --exists another child of the parent
			where g3.Page_ID = g2.Page_ID
			and g3.Parent_GraphicObject_ID = g2.GraphicObject_ID
			and g3.GraphicObject_ID <> g1.GraphicObject_ID) 
group by p.Page_ID


OPEN Form_Cursor

FETCH NEXT FROM Form_Cursor
INTO @PAGEID, @MINY

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
--update Page table
 update Page
 set PageType_EnumValue = 10
 where Page_ID = @PAGEID

 --update Design Navigation
 update nn
 set nn.NodeType_EnumValue = 38
 from NavigationNode nn, Navigation n
 where nn.Page_ID = @PAGEID
 and nn.Navigation_ID = n.Navigation_ID
 and n.NavigationType_EnumValue = 0
 
 --update Runtime Navigation
 update nn
 set nn.NodeType_EnumValue = 39
 from NavigationNode nn, Navigation n
 where nn.Page_ID = @PAGEID
 and nn.Navigation_ID = n.Navigation_ID
 and n.NavigationType_EnumValue = 1


--modify Page Properties
insert into PropertyValuesForPage (Page_ID, Property_Name, Property_Value)
values (@PAGEID ,'Behavior.Relational',1)

--modify Node Properties
delete pvn
from PropertyValuesForNode pvn, NavigationNode nn
where pvn.Navigation_Node_ID = nn.Navigation_Node_ID
and pvn.Property_Name = 'Page.CompressForms'
and nn.NodeType_EnumValue = 39
and nn.Page_ID = @PAGEID

--insert RelationalUpperBoundary object on page
select @WIDTH = 2550

if exists (select 1 from PropertyValuesForPage
			where Page_ID = @PAGEID
			and Property_Name = 'Page.Orientation'
			and Property_Value = 1)
begin
  select @WIDTH = 3280
end

select @NEWY = (@MINY - 1)

select @NEWGID = NextGraphicObject_ID
from NextGraphicObject

insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height,
		Width, DateCreated, DateLastSaved)
values (@NEWGID, 23, @PAGEID, 0, @NEWY, 1, @WIDTH, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)


   FETCH NEXT FROM Form_Cursor
   INTO @PAGEID, @MINY
END

CLOSE Form_Cursor
DEALLOCATE Form_Cursor

SET NOCOUNT OFF

GO