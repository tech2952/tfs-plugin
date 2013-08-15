declare @LASTPAGE int
declare @LASTGRAPHIC int

select @LASTPAGE = 600000
select @LASTGRAPHIC =  600000

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