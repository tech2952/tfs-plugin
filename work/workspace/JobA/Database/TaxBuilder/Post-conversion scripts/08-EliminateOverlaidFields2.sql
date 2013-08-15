--DO NOT RUN THIS UNLESS SPECIFICALLY REQUESTED
--MOST LIKELY TO BE USED FOR 1120

--I HAVE REMARKED OUT THE DELETE STATEMENTS IN CASE SOMEONE ACCIDENTALLY RUNS THIS.
--SO, YOU CAN RUN THIS AS IS TO GENERATE A REPORT, OR RE-ENABLE THE 2 DELETE STATEMENTS TO DELETE THE OVERLAIN FIELDS

declare @PAGEID     	int
declare @POSITIONX  	smallint
declare @POSITIONY  	smallint
declare @PROPVALUE  	varchar(10)
declare @GRAPHICCOUNT 	smallint
declare @ENTITYGROUP_ENUM tinyint
declare @TEXTBOX_ENUM tinyint
declare @PARENT_ENUM	tinyint
declare @GRAPHIC_ID 	int
declare @PARENT_ID 	int
declare @ENTITYGROUP_FOUND	bit
declare @TOTALDELETIONS smallint
declare @DELETEME       bit

select @ENTITYGROUP_ENUM = 4
select @TEXTBOX_ENUM = 1

create table #DeletedFields ( Page_Name varchar(50),
				PositionX int,
				PositionY int
			   )

--First, Eliminate overlain fields that are part of entity groups
declare Cursor_IdentifyOverlays insensitive scroll cursor for
  select a.Page_ID, a.PositionX, a.PositionY, convert(varchar(10),b.Property_Value), count(a.GraphicObject_ID)
  from GraphicObject a, PropertyValuesForGraphic b
  where a.Page_ID = b.Page_ID
  --and a.Page_ID >= 1103  --******************  eliminate this line if processing all pages
  and a.GraphicObject_ID = b.GraphicObject_ID
  and a.GraphicObjectType_EnumValue = @TEXTBOX_ENUM
  and isnull(a.Parent_GraphicObject_ID,0) > 0 
  and b.Property_Name = 'SourceField.FADSFieldID'
  group by a.Page_ID, a.PositionX, a.PositionY, b.Property_Value
  having count(a.GraphicObject_ID) > 1
  order by a.Page_ID,a.PositionX, a.PositionY

  open    Cursor_IdentifyOverlays 

  fetch from Cursor_IdentifyOverlays 
  into  @PAGEID, @POSITIONX, @POSITIONY, @PROPVALUE, @GRAPHICCOUNT

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_IdentifyOverlays
    select @TOTALDELETIONS = @GRAPHICCOUNT - 1
    select @ENTITYGROUP_FOUND = 0

    declare Cursor_GetGraphics insensitive scroll cursor for
      	select a.GraphicObject_ID, isnull(a.Parent_GraphicObject_ID,0)
	from GraphicObject a, PropertyValuesForGraphic b
	where a.Page_ID = @PAGEID
	and a.Page_ID = b.Page_ID
	and a.GraphicObject_ID = b.GraphicObject_ID
	and a.GraphicObjectType_EnumValue = @TEXTBOX_ENUM
	and isnull(a.Parent_GraphicObject_ID,0) > 0
	and b.Property_Name = 'SourceField.FADSFieldID'
	and convert(varchar(10),b.Property_Value) = @PROPVALUE
	and a.PositionX = @POSITIONX
	and a.PositionY = @POSITIONY
	order by a.Parent_GraphicObject_ID, a.GraphicObject_ID

  	open    Cursor_GetGraphics 

  	fetch from Cursor_GetGraphics 
  	into  @GRAPHIC_ID, @PARENT_ID
	while (@@FETCH_STATUS <> -1)
  	begin --Cursor_GetGraphics
	   select @DELETEME = 1
	   
	   if (@TOTALDELETIONS > 0)
           begin
	     if (@ENTITYGROUP_FOUND = 0)
	     begin
		select @PARENT_ENUM = 0
	     	select @PARENT_ENUM = isnull(GraphicObjectType_EnumValue,0)
	     	from GraphicObject
	     	where Page_ID = @PAGEID
	     	and GraphicObject_ID = @PARENT_ID
	
	     	if @PARENT_ENUM = @ENTITYGROUP_ENUM 
	     	begin
		   select @DELETEME = 0
		   select @ENTITYGROUP_FOUND = 1
	     	end
	     end

	     if @DELETEME = 1
	     begin --if @DELETEME = 1
		    insert into #DeletedFields (Page_Name, PositionX, PositionY)
		    select p.Page_Name, g.PositionX, g.PositionY
		    from GraphicObject g, Page p
		    where g.GraphicObject_ID = @GRAPHIC_ID
		    and g.Page_ID = p.Page_ID
		    and g.Page_ID = @PAGEID
-- DELETE SECTION #1:  RE-ENABLE THESE DELETE STATEMENTS TO REMOVE THE OVERLAIN FIELDS
		/*
	       delete from PropertyValuesForGraphic
	       where Page_ID = @PAGEID
	       and GraphicObject_ID = @GRAPHIC_ID
	     
	       delete from GraphicObject
	       where Page_ID = @PAGEID
	       and GraphicObject_ID = @GRAPHIC_ID
		*/
	       select @TOTALDELETIONS = @TOTALDELETIONS - 1
 	     end --if @DELETEME = 1
           end --(@TOTALDELETIONS > 0)
	   fetch from Cursor_GetGraphics 
	   into  @GRAPHIC_ID, @PARENT_ID
  	end --Cursor_GetGraphics
  	close Cursor_GetGraphics
  	deallocate Cursor_GetGraphics 

    fetch from Cursor_IdentifyOverlays 
	into  @PAGEID, @POSITIONX, @POSITIONY, @PROPVALUE, @GRAPHICCOUNT
  end --Cursor_IdentifyOverlays
  close Cursor_IdentifyOverlays
  deallocate Cursor_IdentifyOverlays  

--Next, Eliminate overlain fields that are NOT part of entity groups
declare Cursor_IdentifyOverlays insensitive scroll cursor for
  select a.Page_ID, a.PositionX, a.PositionY, convert(varchar(10),b.Property_Value), count(a.GraphicObject_ID)
  from GraphicObject a, PropertyValuesForGraphic b
  where a.Page_ID = b.Page_ID
  --and a.Page_ID >= 1103  --******************  eliminate this line if processing all pages
  and a.GraphicObject_ID = b.GraphicObject_ID
  and a.GraphicObjectType_EnumValue = @TEXTBOX_ENUM
  and isnull(a.Parent_GraphicObject_ID,0) = 0 
  and b.Property_Name = 'SourceField.FADSFieldID'
  group by a.Page_ID, a.PositionX, a.PositionY, b.Property_Value
  having count(a.GraphicObject_ID) > 1
  order by a.Page_ID,a.PositionX, a.PositionY

  open    Cursor_IdentifyOverlays 

  fetch from Cursor_IdentifyOverlays 
  into  @PAGEID, @POSITIONX, @POSITIONY, @PROPVALUE, @GRAPHICCOUNT

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_IdentifyOverlays
    select @TOTALDELETIONS = @GRAPHICCOUNT - 1
--    select @ENTITYGROUP_FOUND = 0

--    select @PAGEID, @POSITIONX, @POSITIONY, @PROPVALUE, @GRAPHICCOUNT

    declare Cursor_GetGraphics insensitive scroll cursor for
      	select a.GraphicObject_ID, isnull(a.Parent_GraphicObject_ID,0)
	from GraphicObject a, PropertyValuesForGraphic b
	where a.Page_ID = @PAGEID
	and a.Page_ID = b.Page_ID
	and a.GraphicObject_ID = b.GraphicObject_ID
	and a.GraphicObjectType_EnumValue = @TEXTBOX_ENUM
	and isnull(a.Parent_GraphicObject_ID,0) = 0
	and b.Property_Name = 'SourceField.FADSFieldID'
	and convert(varchar(10),b.Property_Value) = @PROPVALUE
	and a.PositionX = @POSITIONX
	and a.PositionY = @POSITIONY
	order by a.Parent_GraphicObject_ID, a.GraphicObject_ID

  	open    Cursor_GetGraphics 

  	fetch from Cursor_GetGraphics 
  	into  @GRAPHIC_ID, @PARENT_ID
	while (@@FETCH_STATUS <> -1)
  	begin --Cursor_GetGraphics
	   select @DELETEME = 1
	   
	   if (@TOTALDELETIONS > 0)
           begin

	     if @DELETEME = 1
	     begin --if @DELETEME = 1
		    insert into #DeletedFields (Page_Name, PositionX, PositionY)
			select p.Page_Name, g.PositionX, g.PositionY
			from GraphicObject g, Page p
			where g.GraphicObject_ID = @GRAPHIC_ID
			and g.Page_ID = p.Page_ID
			and g.Page_ID = @PAGEID

-- DELETE SECTION #2:  RE-ENABLE THESE DELETE STATEMENTS TO REMOVE THE OVERLAIN FIELDS		
/*
	       delete from PropertyValuesForGraphic
	       where Page_ID = @PAGEID
	       and GraphicObject_ID = @GRAPHIC_ID
	     
	       delete from GraphicObject
	       where Page_ID = @PAGEID
	       and GraphicObject_ID = @GRAPHIC_ID
*/
	       select @TOTALDELETIONS = @TOTALDELETIONS - 1
 	     end --if @DELETEME = 1
           end --(@TOTALDELETIONS > 0)
	   fetch from Cursor_GetGraphics 
	   into  @GRAPHIC_ID, @PARENT_ID
  	end --Cursor_GetGraphics
  	close Cursor_GetGraphics
  	deallocate Cursor_GetGraphics 

    fetch from Cursor_IdentifyOverlays 
	into  @PAGEID, @POSITIONX, @POSITIONY, @PROPVALUE, @GRAPHICCOUNT
  end --Cursor_IdentifyOverlays
  close Cursor_IdentifyOverlays
  deallocate Cursor_IdentifyOverlays  

select *
from #DeletedFields

drop table #DeletedFields