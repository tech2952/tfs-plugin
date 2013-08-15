USE [1041OriginalConversion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spConversionToolGraphicsAddedDeletedByCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spConversionToolGraphicsAddedDeletedByCount]
GO


CREATE PROCEDURE [dbo].[spConversionToolGraphicsAddedDeletedByCount] (@NewConversionDB varchar(64)) AS
BEGIN
declare @Query varchar(2500)


--create temp table to hold held nodes
create table #PagesOriginal (FADS_AML varchar(17),
						 GraphicCount int)

create table #PagesNew (FADS_AML varchar(17),
						 GraphicCount int)

create table #PagesAddDelete (FADS_AML varchar(17),
							  NumberOfOriginalGraphics int,
							  NumberOfCurrentGraphics int,
							  Status varchar(8))

insert into #PagesOriginal (FADS_AML,GraphicCount)
select cast(pvp.Property_Value as varchar(17)), count(g.GraphicObject_ID)
from Page p, PropertyValuesForPage pvp, GraphicObject g
where p.Page_ID = pvp.Page_ID
and pvp.Property_Name = 'Page.FADSAML'
and p.Page_ID = g.Page_ID
group by cast(pvp.Property_Value as varchar(17))


select @Query = 'insert into #PagesNew (FADS_AML, GraphicCount)
select cast(pvp.Property_Value as varchar(17)), count(g.GraphicObject_ID)
from [' + @NewConversionDB +'].dbo.Page p, [' + @NewConversionDB + '].dbo.PropertyValuesForPage pvp, 
[' + @NewConversionDB + '].dbo.GraphicObject g
where p.Page_ID = pvp.Page_ID
and pvp.Property_Name = ''Page.FADSAML''
and p.Page_ID = g.Page_ID
group by cast(pvp.Property_Value as varchar(17))'


execute (@Query)


--Deleted pages where no pages exist in latest conversion
insert into #PagesAddDelete (FADS_AML, NumberOfOriginalGraphics, NumberOfCurrentGraphics, Status)
select po.FADS_AML, po.GraphicCount, 0, 'Deleted'
from #PagesOriginal po
where po.FADS_AML not in (select distinct pn.FADS_AML from #PagesNew pn)

--Deleted pages where pages exist in latest conversion
insert into #PagesAddDelete (FADS_AML, NumberOfOriginalGraphics, NumberOfCurrentGraphics, Status)
select po.FADS_AML, po.GraphicCount, pn.GraphicCount, 'Deleted'
from #PagesOriginal po, #PagesNew pn
where po.FADS_AML = pn.FADS_AML
and po.GraphicCount > pn.GraphicCount

--Added pages where no pages exist in original conversion
insert into #PagesAddDelete (FADS_AML, NumberOfOriginalGraphics, NumberOfCurrentGraphics, Status)
select pn.FADS_AML, 0, pn.GraphicCount, 'Added'
from #PagesNew pn
where  pn.FADS_AML not in (select distinct po.FADS_AML from #PagesOriginal po)


--Added pages where pages exist in original conversion
insert into #PagesAddDelete (FADS_AML, NumberOfOriginalGraphics, NumberOfCurrentGraphics, Status)
select pn.FADS_AML, po.GraphicCount, pn.GraphicCount, 'Added'
from #PagesNew pn, #PagesOriginal po
where pn.FADS_AML = po.FADS_AML
and pn.GraphicCount > po.GraphicCount

select FADS_AML, NumberOfOriginalGraphics, NumberOfCurrentGraphics, Status
from #PagesAddDelete
order by Status, FADS_AML

drop table #PagesOriginal
drop table #PagesNew
drop table #PagesAddDelete

END

GRANT EXECUTE ON [dbo].[spConversionToolGraphicsAddedDeletedByCount] To [G-TTA-TaxBuilder]
