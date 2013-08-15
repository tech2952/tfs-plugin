declare @LASTPAGE int
declare @LASTGRAPHIC int
declare @PAGENAME varchar(20)
declare @PAGEID int
declare @INNERX smallint
declare @INNERRIGHT smallint
declare @GAP tinyint
declare @NEWX smallint
declare @NEWWIDTH smallint
declare @GRAPHICID int

select @LASTPAGE = 700000
select @LASTGRAPHIC =  700000
select @GAP = 10

--Adjust position of Attachment Section Heading labels on 10pt landscape attachments
update g1
set g1.PositionX = 2474, g1.PositionY = 150
--select p1.Page_Name, p1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY
from GraphicObject g1, PropertyValuesForGraphic pvg1,  
PropertyValuesForGraphic pvg2,(select g.Page_ID, count(g.GraphicObject_ID) as ASHCount
								from GraphicObject g, PropertyValuesForGraphic pvg
								where g.Page_ID = pvg.Page_ID
								and g.Page_ID > @LASTPAGE
								and g.GraphicObject_ID = pvg.GraphicObject_ID
								and g.GraphicObject_ID > @LASTGRAPHIC
								and g.GraphicObjectType_EnumValue = 2
								and pvg.Property_Name = 'Appearance.SpecialText'
								and pvg.Property_Value = 7
								group by g.Page_ID
								having count(g.GraphicObject_ID) = 1) b
where g1.Page_ID = b.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g1.Page_ID = pvg2.Page_ID
and isnull(g1.Parent_GraphicObject_ID,0) = 0  --the ASH is not a child of a groupbox
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g1.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and pvg2.Property_Name = 'Appearance.FontIndex'
and pvg2.Property_Value in (1,7,11) -- Courier New 10 pt
and g1.Page_ID in (select p.Page_ID
					from PropertyValuesForPage p
					where p.Property_Name = 'Page.Orientation'
					and p.Property_Value = 1) -- Landscape




--Adjust position of Attachment Section Heading labels on 10pt portrait attachments
update g1
set g1.PositionX = 1760, g1.PositionY = 150
--select p1.Page_Name, p1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY
from GraphicObject g1, PropertyValuesForGraphic pvg1,  
PropertyValuesForGraphic pvg2,(select g.Page_ID, count(g.GraphicObject_ID) as ASHCount
								from GraphicObject g, PropertyValuesForGraphic pvg
								where g.Page_ID = pvg.Page_ID
								and g.Page_ID > @LASTPAGE
								and g.GraphicObject_ID = pvg.GraphicObject_ID
								and g.GraphicObject_ID > @LASTGRAPHIC
								and g.GraphicObjectType_EnumValue = 2
								and pvg.Property_Name = 'Appearance.SpecialText'
								and pvg.Property_Value = 7
								group by g.Page_ID
								having count(g.GraphicObject_ID) = 1) b
where g1.Page_ID = b.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g1.Page_ID = pvg2.Page_ID
and isnull(g1.Parent_GraphicObject_ID,0) = 0  --the ASH is not a child of a groupbox
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g1.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and pvg2.Property_Name = 'Appearance.FontIndex'
and pvg2.Property_Value in (1,7,11) -- Courier New 10 pt
and g1.Page_ID not in (select p.Page_ID
					from PropertyValuesForPage p
					where p.Property_Name = 'Page.Orientation'
					and p.Property_Value = 1) -- Landscape



--Adjust position of Attachment Section Heading labels on 12pt landscape attachments
update g1
set g1.PositionX = 2490, g1.PositionY = 150
--select p1.Page_Name, p1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY
from GraphicObject g1, PropertyValuesForGraphic pvg1,  
/*PropertyValuesForGraphic pvg2,*/(select g.Page_ID, count(g.GraphicObject_ID) as ASHCount
								from GraphicObject g, PropertyValuesForGraphic pvg
								where g.Page_ID = pvg.Page_ID
								and g.Page_ID > @LASTPAGE
								and g.GraphicObject_ID = pvg.GraphicObject_ID
								and g.GraphicObject_ID > @LASTGRAPHIC
								and g.GraphicObjectType_EnumValue = 2
								and pvg.Property_Name = 'Appearance.SpecialText'
								and pvg.Property_Value = 7
								group by g.Page_ID
								having count(g.GraphicObject_ID) = 1) b
where g1.Page_ID = b.Page_ID
and g1.Page_ID = pvg1.Page_ID
and isnull(g1.Parent_GraphicObject_ID,0) = 0  --the ASH is not a child of a groupbox
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g1.Page_ID
				and pvg2.GraphicObject_ID = g1.GraphicObject_ID
				and pvg2.Page_ID > @LASTPAGE
				and pvg2.GraphicObject_ID > @LASTGRAPHIC
				and pvg2.Property_Name = 'Appearance.FontIndex'
				and pvg2.Property_Value not in (0,5,6) ) -- Courier New 12 pt
and g1.Page_ID in (select p.Page_ID
					from PropertyValuesForPage p
					where p.Property_Name = 'Page.Orientation'
					and p.Property_Value = 1) -- Landscape


--Adjust position of Attachment Section Heading labels on 12pt portrait attachments
update g1
set g1.PositionX = 1770, g1.PositionY = 150
--select p1.Page_Name, p1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY
from GraphicObject g1, PropertyValuesForGraphic pvg1,  
/*PropertyValuesForGraphic pvg2,*/(select g.Page_ID, count(g.GraphicObject_ID) as ASHCount
								from GraphicObject g, PropertyValuesForGraphic pvg
								where g.Page_ID = pvg.Page_ID
								and g.Page_ID > @LASTPAGE
								and g.GraphicObject_ID = pvg.GraphicObject_ID
								and g.GraphicObject_ID > @LASTGRAPHIC
								and g.GraphicObjectType_EnumValue = 2
								and pvg.Property_Name = 'Appearance.SpecialText'
								and pvg.Property_Value = 7
								group by g.Page_ID
								having count(g.GraphicObject_ID) = 1) b
where g1.Page_ID = b.Page_ID
and g1.Page_ID = pvg1.Page_ID
and isnull(g1.Parent_GraphicObject_ID,0) = 0  --the ASH is not a child of a groupbox
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g1.Page_ID
				and pvg2.GraphicObject_ID = g1.GraphicObject_ID
				and pvg2.Page_ID > @LASTPAGE
				and pvg2.GraphicObject_ID > @LASTGRAPHIC
				and pvg2.Property_Name = 'Appearance.FontIndex'
				and pvg2.Property_Value not in (0,5,6) ) -- Courier New 12 pt
and g1.Page_ID not in (select p.Page_ID
					from PropertyValuesForPage p
					where p.Property_Name = 'Page.Orientation'
					and p.Property_Value = 1) -- Landscape

--This will shift the field position of specified pages in 990.  These pages are using 10pt font for the fields, 
--but the form is composed using a 12pt grid.  So, shift the textboxes to the nearest 12pt grid location.
create table #PAGES (PageNameSnip varchar(20))

insert into #PAGES (PageNameSnip)
values ('(20_7_9)')
insert into #PAGES (PageNameSnip)
values ('(20_6_16)')
insert into #PAGES (PageNameSnip)
values ('(20_6_32)')
insert into #PAGES (PageNameSnip)
values ('(20_49_9)')
insert into #PAGES (PageNameSnip)
values ('(20_57_9)')
insert into #PAGES (PageNameSnip)
values ('(25_6_9)')
insert into #PAGES (PageNameSnip)
values ('(25_14_9)')
insert into #PAGES (PageNameSnip)
values ('(31_632_9)')
insert into #PAGES (PageNameSnip)
values ('(31_1383_9)')
insert into #PAGES (PageNameSnip)
values ('(31_1758_9)')
insert into #PAGES (PageNameSnip)
values ('(31_1772_16)')
insert into #PAGES (PageNameSnip)
values ('(81_9_9)')
insert into #PAGES (PageNameSnip)
values ('(81_1668_9)')
insert into #PAGES (PageNameSnip)
values ('(81_1739_9)')
insert into #PAGES (PageNameSnip)
values ('(81_219_9)')
insert into #PAGES (PageNameSnip)
values ('(81_4223_24)')
insert into #PAGES (PageNameSnip)
values ('(81_4273_9)')
insert into #PAGES (PageNameSnip)
values ('(81_4404_9)')
insert into #PAGES (PageNameSnip)
values ('(81_5219_3)')
insert into #PAGES (PageNameSnip)
values ('(81_4970_9)')
insert into #PAGES (PageNameSnip)
values ('(100_212_9)')
insert into #PAGES (PageNameSnip)
values ('(81_5104_9)')
insert into #PAGES (PageNameSnip)
values ('(81_4437_9)')
insert into #PAGES (PageNameSnip)
values ('(31_1188_9)')
insert into #PAGES (PageNameSnip)
values ('(30_675_49)')
insert into #PAGES (PageNameSnip)
values ('(31_1222_41)')
insert into #PAGES (PageNameSnip)
values ('(31_1555_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1814_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1816_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1818_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1818_17)')
insert into #PAGES (PageNameSnip)
values ('(52_1616_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1690_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1771_9)')
insert into #PAGES (PageNameSnip)
values ('(52_1811_13)')
insert into #PAGES (PageNameSnip)
values ('(79_3417_88)')
insert into #PAGES (PageNameSnip)
values ('(80_7469_9)')
insert into #PAGES (PageNameSnip)
values ('(80_4945_9)')
insert into #PAGES (PageNameSnip)
values ('(80_7278_79)')
insert into #PAGES (PageNameSnip)
values ('(80_4849_79)')
insert into #PAGES (PageNameSnip)
values ('(11_1372_9)')
insert into #PAGES (PageNameSnip)
values ('(11_368_4)')
insert into #PAGES (PageNameSnip)
values ('(11_9_20)')
insert into #PAGES (PageNameSnip)
values ('(81_3866_25)')
insert into #PAGES (PageNameSnip)
values ('(81_3882_25)')
insert into #PAGES (PageNameSnip)
values ('(81_3886_25)')
insert into #PAGES (PageNameSnip)
values ('(81_4223_16)')
insert into #PAGES (PageNameSnip)
values ('(81_5502_16)')
insert into #PAGES (PageNameSnip)
values ('(81_5875_16)')
insert into #PAGES (PageNameSnip)
values ('(100_6_17)')
insert into #PAGES (PageNameSnip)
values ('(100_122_17)')
insert into #PAGES (PageNameSnip)
values ('(100_300_9)')
insert into #PAGES (PageNameSnip)
values ('(101_1577_16)')
insert into #PAGES (PageNameSnip)
values ('(109_2_17)')
insert into #PAGES (PageNameSnip)
values ('(111_19_16)')
insert into #PAGES (PageNameSnip)
values ('(115_114_16)')
insert into #PAGES (PageNameSnip)
values ('(116_64_9)')
insert into #PAGES (PageNameSnip)
values ('(131_719_3)')
insert into #PAGES (PageNameSnip)
values ('(201_2_4)')
insert into #PAGES (PageNameSnip)
values ('(201_2_20)')
insert into #PAGES (PageNameSnip)
values ('(211_70_9)')
insert into #PAGES (PageNameSnip)
values ('(222_2868_16)')
insert into #PAGES (PageNameSnip)
values ('(81_5630_16)')
insert into #PAGES (PageNameSnip)
values ('(11_1372_9)')
insert into #PAGES (PageNameSnip)
values ('(81_611_10)')
insert into #PAGES (PageNameSnip)
values ('(81_4709_3)')
insert into #PAGES (PageNameSnip)
values ('(81_4722_3)')
insert into #PAGES (PageNameSnip)
values ('(81_4797_16)')
insert into #PAGES (PageNameSnip)
values ('(81_4956_9)')
insert into #PAGES (PageNameSnip)
values ('(81_5875_32)')


--truncate table #PAGES
--select * from #PAGES


declare Cursor_UpdateFieldPosition insensitive scroll cursor for
    select PageNameSnip
    from #PAGES
    order by PageNameSnip

    open    Cursor_UpdateFieldPosition 

    fetch from Cursor_UpdateFieldPosition 
    into    @PAGENAME

    while (@@FETCH_STATUS <> -1)
    begin --Cursor_UpdateFieldPosition

	   select @PAGENAME = @PAGENAME + '%'

       select @PAGEID = Page_ID
	   from Page
	   where Page_Name like @PAGENAME
	   and Page_ID > @LASTPAGE

	  update g
	  set g.PositionX = (30*ROUND(g.PositionX/30,0))
	  from GraphicObject g
	  where g.Page_ID = @PAGEID
	  and g.GraphicObjectType_EnumValue = 1 --Textbox

	--Now, adjust the size of any affected groupboxes
	  if exists (select g1.GraphicObject_ID
					 from GraphicObject g1, GraphicObject g2
					where g1.GraphicObjectType_EnumValue = 3 --@GROUPBOXENUM
					and isnull(g1.Parent_GraphicObject_ID,0) = 0
					and g1.Page_ID = g2.Page_ID
					and g2.Parent_GraphicObject_ID = g1.GraphicObject_ID
					and g1.Page_ID = @PAGEID  --> 700000 --@LASTPAGE
					--and g1.GraphicObject_ID = @GRAPHICOBJECT_ID --> 700000 --@LASTGRAPHIC
					group by g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY, (g1.PositionX + g1.Width), (g1.PositionY + g1.Height)
					having (((g1.PositionX + g1.Width) < max(g2.PositionX + g2.Width)) OR ((g1.PositionY + g1.Height) < max(g2.PositionY + g2.Height))
						OR (g1.PositionX > min(g2.PositionX)) OR (g1.PositionY > min(g2.PositionY)))  )

		BEGIN  --modify the groupbox size

			declare Cursor_UpdateGroupBoxSize insensitive scroll cursor for
			select g1.GraphicObject_ID, min(g2.PositionX) as InnerX, max(g2.PositionX + g2.Width) as InnerRight
			from GraphicObject g1, GraphicObject g2
			where g1.GraphicObjectType_EnumValue = 3 --@GROUPBOXENUM
			  and isnull(g1.Parent_GraphicObject_ID,0) = 0
			  and g1.Page_ID = g2.Page_ID
			  and g2.Parent_GraphicObject_ID = g1.GraphicObject_ID
			  and g1.Page_ID = @PAGEID
			  and g1.GraphicObject_ID > 700000 --@LASTGRAPHIC
			  group by g1.GraphicObject_ID, g1.PositionX, g1.Width
			  having (((g1.PositionX + g1.Width) < max(g2.PositionX + g2.Width)) OR (g1.PositionX > min(g2.PositionX)))
			  order by g1.GraphicObject_ID

			open    Cursor_UpdateGroupBoxSize 

			fetch from Cursor_UpdateGroupBoxSize 
			into    @GRAPHICID, @INNERX, @INNERRIGHT

			while (@@FETCH_STATUS <> -1)
			begin --Cursor_UpdateGroupBoxSize

				select @NEWX = (@INNERX - @GAP)
				select @NEWWIDTH = (@INNERRIGHT + @GAP - @NEWX)

				update GraphicObject
				set PositionX = @NEWX, Width = @NEWWIDTH
				where Page_ID = @PAGEID
				and GraphicObject_ID = @GRAPHICID


			fetch from Cursor_UpdateGroupBoxSize 
			   into    @GRAPHICID, @INNERX, @INNERRIGHT
			end --Cursor_UpdateFieldPosition

			close Cursor_UpdateGroupBoxSize
			deallocate Cursor_UpdateGroupBoxSize


		end -- modifying the groupbox

       fetch from Cursor_UpdateFieldPosition 
	   into    @PAGENAME
    end --Cursor_UpdateFieldPosition

    close Cursor_UpdateFieldPosition
    deallocate Cursor_UpdateFieldPosition 


drop table #PAGES
