--TFS 60608

--declare @LetterLongSide int
--declare @ShortSide int 
--declare @LegalLongSide int
declare @MyPageID int
declare @NewGraphicID int

--select @LetterLongSide = 3250
--select @ShortSide = 2520
--select @LegalLongSide = 4150

--Get pages, their sized, and their orientation.  Collect these into a temp file
create table #MyPages (Page_ID int,
					   PaperSize tinyint,  --0 = letter, 1 = legal
					   PageOrientation tinyint)  --0 = portrait, 1 = legal


insert into #MyPages (Page_ID, PaperSize, PageOrientation)
--Portrait, letter paper
select p.Page_ID, 0, 0
from Page p
where p.Page_ID not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and isnull(p.Parent_Page_ID,0) not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and p.Page_ID not in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)
UNION
--Landscape, letter paper
select p.Page_ID, 0, 1
from Page p
where (p.Page_ID in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1)
	OR isnull(p.Parent_Page_ID,0) in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1))
and p.Page_ID not in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)
UNION
--Portrait, legal paper
select  p.Page_ID, 1, 0
from Page p
where p.Page_ID not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and isnull(p.Parent_Page_ID,0) not in (select pg.Page_ID
					from PropertyValuesForPage pg
					where pg.Property_Name = 'Page.Orientation'
					and pg.Property_Value = 1)
and p.Page_ID in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)
UNION
--Landscape, legal paper
select p.Page_ID, 1, 1
from Page p
where (p.Page_ID in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1)
	OR isnull(p.Parent_Page_ID,0) in (select pg.Page_ID
			from PropertyValuesForPage pg
			where pg.Property_Name = 'Page.Orientation'
			and pg.Property_Value = 1))
and p.Page_ID in (select pg1.Page_ID
					from PropertyValuesForPage pg1
					where pg1.Property_Name = 'Page.PaperSize'
					and pg1.Property_Value = 1)

--cursor through the temp file by size and orientation


--Portrait, letter paper
declare Cursor_MyPages insensitive scroll cursor for
    select Page_ID
    from #MyPages
    where PaperSize = 0
    and PageOrientation = 0 

    open    Cursor_MyPages 

    fetch from Cursor_MyPages 
    into    @MyPageID

    while (@@FETCH_STATUS <> -1)
    begin --Cursor_MyPages
  -- add header and footer objects to each page
		--header
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,25,@MyPageID,0, 150, 1,2650, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
		--footer
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,26,@MyPageID,0, 3150, 1,2650, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)

	   fetch from Cursor_MyPages 
	   into    @MyPageID
    end --Cursor_MyPages
    close Cursor_MyPages
    deallocate Cursor_MyPages  

--Landscape, letter paper
declare Cursor_MyPages insensitive scroll cursor for
    select Page_ID
    from #MyPages
    where PaperSize = 0
    and PageOrientation = 1 

    open    Cursor_MyPages 

    fetch from Cursor_MyPages 
    into    @MyPageID

    while (@@FETCH_STATUS <> -1)
    begin --Cursor_MyPages
  -- add header and footer objects to each page
		--header
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,25,@MyPageID,0, 150, 1,3550, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
		--footer
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,26,@MyPageID,0, 2400, 1,3550, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)

	   fetch from Cursor_MyPages 
	   into    @MyPageID
    end --Cursor_MyPages
    close Cursor_MyPages
    deallocate Cursor_MyPages  

--Portrait, legal paper
declare Cursor_MyPages insensitive scroll cursor for
    select Page_ID
    from #MyPages
    where PaperSize = 1
    and PageOrientation = 0 

    open    Cursor_MyPages 

    fetch from Cursor_MyPages 
    into    @MyPageID

    while (@@FETCH_STATUS <> -1)
    begin --Cursor_MyPages
  -- add header and footer objects to each page
		--header
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,25,@MyPageID,0, 150, 1,2650, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
		--footer
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,26,@MyPageID,0, 4050, 1,2650, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)

	   fetch from Cursor_MyPages 
	   into    @MyPageID
    end --Cursor_MyPages
    close Cursor_MyPages
    deallocate Cursor_MyPages  

--Landscape, legal paper
declare Cursor_MyPages insensitive scroll cursor for
    select Page_ID
    from #MyPages
    where PaperSize = 1
    and PageOrientation = 1 

    open    Cursor_MyPages 

    fetch from Cursor_MyPages 
    into    @MyPageID

    while (@@FETCH_STATUS <> -1)
    begin --Cursor_MyPages
  -- add header and footer objects to each page
		--header
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,25,@MyPageID,0, 150, 1,4450, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)
		--footer
	  select @NewGraphicID = NextGraphicObject_ID
	  from NextGraphicObject

	  insert into GraphicObject (GraphicObject_ID, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width,
					DateCreated, DateLastSaved)
	  values (@NewGraphicID,26,@MyPageID,0, 2400, 1,4450, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP)

	   fetch from Cursor_MyPages 
	   into    @MyPageID
    end --Cursor_MyPages
    close Cursor_MyPages
    deallocate Cursor_MyPages  

drop table #MyPages