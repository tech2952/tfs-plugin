
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spConversionToolPagesAddedDeleted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spConversionToolPagesAddedDeleted]
GO

CREATE PROCEDURE [dbo].[spConversionToolPagesAddedDeleted] (@NewConversionDB varchar(64)) AS
BEGIN
declare @Query varchar(2500)


--create temp table to hold held nodes
create table #PagesOriginal (Page_ID int,
						 FADS_AML varchar(17),
						 Status varchar(8))

create table #PagesNew (Page_ID int,
						 FADS_AML varchar(17),
						 Status varchar(8))

create table #PagesAddDelete (FADS_AML varchar(17),
							  Status varchar(8))

insert into #PagesOriginal (Page_ID,FADS_AML,Status)
select p.Page_ID, cast(pvp.Property_Value as varchar(17)), 'Matched'
from Page p, PropertyValuesForPage pvp
where p.Page_ID = pvp.Page_ID
and pvp.Property_Name = 'Page.FADSAML'

select @Query = 'insert into #PagesNew (Page_ID,FADS_AML,Status)
select p.Page_ID, cast(pvp.Property_Value as varchar(17)), ''Matched''
from ' + @NewConversionDB +'.dbo.Page p, ' + @NewConversionDB + '.dbo.PropertyValuesForPage pvp
where p.Page_ID = pvp.Page_ID
and pvp.Property_Name = ''Page.FADSAML'''

execute (@Query)

update po
set Status = 'Deleted'
from #PagesOriginal po
where po.FADS_AML not in (select distinct pn.FADS_AML from #PagesNew pn)

update pn
set Status = 'Added'
from #PagesNew pn
where pn.FADS_AML not in (select distinct po.FADS_AML from #PagesOriginal po)

insert into #PagesAddDelete (FADS_AML, Status)
select po.FADS_AML, po.Status
from #PagesOriginal po
where po.Status = 'Deleted'

insert into #PagesAddDelete (FADS_AML, Status)
select pn.FADS_AML, pn.Status
from #PagesNew pn
where pn.Status = 'Added'

select FADS_AML, Status
from #PagesAddDelete

drop table #PagesOriginal
drop table #PagesNew
drop table #PagesAddDelete

END

GRANT EXECUTE ON [dbo].[spConversionToolPagesAddedDeleted] To [G-TTA-TaxBuilder]
GO