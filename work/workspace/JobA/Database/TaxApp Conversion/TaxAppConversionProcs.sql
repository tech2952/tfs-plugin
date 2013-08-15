if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[XFormDeveloper]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[XFormDeveloper]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[XFormNavigation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[XFormNavigation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[XFormProductValues]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[XFormProductValues]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[XformFields]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[XformFields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[XformScreen]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[XformScreen]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE XFormDeveloper  @Product varchar(100)
AS

truncate table XFormDeveloperRole

--DEVELOPER ROLE FOR PRODUCT
insert into xformdeveloperrole(Area,DeveloperRoleName,DeveloperRole_Description)
		values(NULL,@Product,'Role to determine who can check out/in product: ' + @Product )

--DEVELOPER ROLE FOR PROJECT(AREA)
insert into XFormDeveloperRole(Area, DeveloperRoleName, DeveloperRole_Description)
Select Distinct 
		Area 				= 	key_area, 
		DeveloperRoleName 		= 	@Product + '_Project_' + cast(key_area as varchar(200)), 	
		DeveloperRole_Description 	=    	'Role for ' + @Product + '_Project_' + cast(key_area as varchar(200)) 
from 
	FadsScreen 
where app= @Product
order by key_area asc






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE      PROCEDURE XFormNavigation @Product varchar (100)
AS

truncate table xformnavigationnode
insert into xformnavigationnode (Area, NodeType_EnumValue, Node_Name, Navigation_ID, Parent_Node_ID, DisplayOrder, Indent_Level, DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID, DateCreated, DateLastSaved)
Select distinct
	Area				= 	screen.key_area,
	NodeType_EnumValue 		= 	0, 
	Node_Name			= 	@Product + '_Project_' + cast(screen.key_area as varchar(100)),
	Navigation_ID			=	NULL,							--Navigation_Id for PrintDesignTree
	Parent_Node_ID			=	NULL,
	DisplayOrder			= 	'm',
	Indent_Level			=	0,
	DeveloperRole_ID		= 	developer.DeveloperRole_ID,		
	Page_ID				=	NULL,
	AlternateAction_Node_ID		=	NULL,
	ShortCut_Node_ID		= 	NULL,
	DateCreated			=	getdate(), 
	DateLastSaved			= 	getdate()
From 
	FadsScreen screen,
	XFormDeveloperRole developer
Where 
	screen.key_area = developer.area
ORDER BY 
	key_area


insert into xformnavigationnode (Area, NodeType_EnumValue, Node_Name, Navigation_ID, Parent_Node_ID, DisplayOrder, Indent_Level, DeveloperRole_ID, Page_ID, AlternateAction_Node_ID, ShortCut_Node_ID, DateCreated, DateLastSaved)
Select distinct
	Area				= 	Page.area,
	NodeType_EnumValue 		= 	22, 
	Page_Name			= 	Page.Page_Name,
	Navigation_ID			=	NULL,
	Parent_Node_ID			=	navnode.navigation_node_id,
	DisplayOrder			= 	'm',
	Indent_Level			=	1,
	DeveloperRole_ID		= 	developer.DeveloperRole_ID,		
	Page_ID				=	Page.Page_ID,
	AlternateAction_Node_ID		=	NULL,
	ShortCut_Node_ID		= 	NULL,
	DateCreated			=	getdate(), 
	DateLastSaved			= 	getdate()
From 	
	XFormDeveloperRole developer,
	XFormPage page,
	XFormNavigationNode navnode
Where 
	page.area 			= 	developer.area
And
	navnode.area 			=	page.area 
And
	navnode.nodetype_enumvalue 	= 	0
ORDER BY 
	Page.area









GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



Create       PROCEDURE XFormProductValues @Product varchar(255)
AS

--EDITED property values
truncate table XFormPropertyValuesForGraphicObjects
--INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, DataType_EnumValue, Property_Value)
INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, Property_Value)
Select 
	GraphicObject_ID 	= xgo.graphicobject_id,	
	Page_ID 	 	= xgo.page_id,
	Area			= ff.area, 
	Screen			= ff.screen,
	Field			= ff.field,  
	App			= ff.app,
	Prec			= ff.prec,  
	Property_Name 	  	= ffx.property,
--	DataType_EnumValue	= ffx.DataType_EnumValue,
	Property_Value		= 
			case                                                   
	       	            when ffx.DataType_EnumValue = 0 then cast ( ffx.property_value as bit(1) )		--boolean
                            when ffx.DataType_EnumValue = 1 then cast ( ffx.property_value as int )			--integer
                            when ffx.DataType_EnumValue = 2 then cast ( ffx.property_value as varchar(500))		--string     
                            when ffx.DataType_EnumValue = 3 then cast ( ffx.property_value as datetime)			--date
                            when ffx.DataType_EnumValue = 4 then cast ( ffx.property_value as nvarchar(500))
                            when ffx.DataType_EnumValue = 5 then cast ( ffx.property_value as bit)			--byte
                            when ffx.DataType_EnumValue = 7 then cast ( ffx.property_value as numeric(20,9))	--fraction
                            when ffx.DataType_EnumValue = 8 then cast ( ffx.property_value as numeric(22,2))	--numeric
			    else ffx.property_value
			end
from 
	fadsfield ff, fadsfieldxform ffx , xformgraphicobject xgo
where
	ff.app = @Product
and 
	ff.typedesc = 'EDITED'
and 
	ffx.Value = ff.typedesc
--and 
--	ffx.property != 'data.datatype'
and 
	xgo.area = ff.area
and 
	xgo.screen = ff.screen
and 
	xgo.field = ff.field
and 	
	ffx.condition = convert (int,(case when ff.prec = 0 then 0 else 1 end))
order by 
	ff.area asc,ff.screen asc, ff.field asc-- 


/* MINVal propertyvalues for graphic*/
--Case where string fields have non-zero minvalue = maxvalue
--If the source field has a length of one, then the constants in the minval field produce the list of values.
INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, Property_Value)
Select 
	GraphicObject_ID 	= xgo.graphicobject_id,	
	Page_ID 	 	= xgo.page_id,
	Area			= ff.area, 
	Screen			= ff.screen,
	Field			= ff.field,  
	App			= ff.app,
	Prec			= ff.prec,  
	Property_Name 	  	= ffx.property,
	Property_Value		= 
			case                                                   
	       	            when ffx.DataType_EnumValue = 0 then cast ( ffx.property_value as bit(1) )		--boolean
                            when ffx.DataType_EnumValue = 1 then cast ( ffx.property_value as int )			--integer
                            when ffx.DataType_EnumValue = 2 then cast ( ffx.property_value as varchar(500))		--string     
                            when ffx.DataType_EnumValue = 3 then cast ( ffx.property_value as datetime)			--date
                            when ffx.DataType_EnumValue = 4 then cast ( ffx.property_value as nvarchar(500))
                            when ffx.DataType_EnumValue = 5 then cast ( ffx.property_value as bit)			--byte
                            when ffx.DataType_EnumValue = 7 then cast ( ffx.property_value as numeric(20,9))	--fraction
                            when ffx.DataType_EnumValue = 8 then cast ( ffx.property_value as numeric(22,2))	--numeric
			    else ffx.property_value
			end
from 	fadsfield ff, fadsfieldxform ffx, xformgraphicobject xgo
where	ff.app = @Product
and 	xgo.area = ff.area
and 	xgo.screen = ff.screen
and 	xgo.field = ff.field
and 	ff.type in (17, 20) --string field
and     (ff.minval <> 0 OR ff.maxval <> 0)  
and     ff.minval = ff.maxval
and     ff.minval <> ff.field  --cannot be pointing at itself for min and max values 
and 	ffx.condition = 2
and not exists (select 1 from XFormPropertyValuesForGraphicObjects where GraphicObject_ID = xgo.graphicobject_id and
	Property_Name = ffx.property and Property_Name = ffx.property)
order by 
	ff.area asc, ff.screen asc, ff.field asc

/* MINVal propertyvalues for graphic*/
--Case where fields have non-zero minvalue != maxvalue
--The Data.MinValue property = constant value assigned to the minvalue field
--The maxval and minval fields cannot = formula field
INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, Property_Value)
Select 
	GraphicObject_ID 	= xgo.graphicobject_id,	
	Page_ID 	 	= xgo.page_id,
	Area			= ff.area, 
	Screen			= ff.screen,
	Field			= ff.field,  
	App			= ff.app,
	Prec			= ff.prec,  
	Property_Name 	  	= ffx.property,
	Property_Value		= fc.Data
			
from 	fadsfield ff, fadsfieldxform ffx, xformgraphicobject xgo, FADSCNST fc
where	ff.app = @Product
and 	xgo.area = ff.area
and 	xgo.screen = ff.screen
and 	xgo.field = ff.field
and     ff.minval <> 0
and     ff.minval <> ff.maxval
and     ff.minval <> ff.field  --cannot be pointing at itself for min and max values 
and 	ffx.condition = 3 --Data.MinValue
and 	ff.area = fc.Area
and 	ff.screen = fc.Screen
and	ff.minval = fc.Field
and not exists (select 1 from XFormPropertyValuesForGraphicObjects where GraphicObject_ID = xgo.graphicobject_id and
	Property_Name = ffx.property and Property_Name = ffx.property)
order by 
	ff.area asc, ff.screen asc, ff.field asc

--The Data.MaxValue property = constant value assigned to the maxvalue field
INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, Property_Value)
Select 
	GraphicObject_ID 	= xgo.graphicobject_id,	
	Page_ID 	 	= xgo.page_id,
	Area			= ff.area, 
	Screen			= ff.screen,
	Field			= ff.field,  
	App			= ff.app,
	Prec			= ff.prec,  
	Property_Name 	  	= ffx.property,
	Property_Value		= fc.Data
			
from 	fadsfield ff, fadsfieldxform ffx, xformgraphicobject xgo, FADSCNST fc
where	ff.app = @Product
and 	xgo.area = ff.area
and 	xgo.screen = ff.screen
and 	xgo.field = ff.field
and     ff.maxval <> 0
and     ff.minval <> ff.maxval
and     ff.maxval <> ff.field  --cannot be pointing at itself for min and max values 
and 	ffx.condition = 4 --Data.MaxValue
and 	ff.area = fc.Area
and 	ff.screen = fc.Screen
and	ff.maxval = fc.Field
and not exists (select 1 from XFormPropertyValuesForGraphicObjects where GraphicObject_ID = xgo.graphicobject_id and
	Property_Name = ffx.property and Property_Name = ffx.property)
order by 
	ff.area asc, ff.screen asc, ff.field asc


/* MINVal propertyvalues for graphic*/
--Case where numeric fields have non-zero minvalue = maxvalue
--This does not appear to be valid according to the FADS User Manual.  Need to look for cases.


--INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, DataType_EnumValue, Property_Value)
INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, Property_Value)
SELECT DISTINCT 
                      	XformGraphicObject.GraphicObject_ID 	AS GraphicObject_ID	, 
			XformGraphicObject.Page_ID 		AS Page_ID, 
			XformGraphicObject.Area 		AS Area, 
                      	XformGraphicObject.Screen 		AS Screen,
			Field					=  NULL,	 
			XformGraphicObject.App 			AS App,
			Prec					= 0, 
			FADSFieldXform.Property 		AS Property_Name, 
--                      	FADSFieldXform.DataType_EnumValue 	AS DataType_EnumValue, 
			Property_Value = 	 
				case 
					when FADSFieldXform.property = 'Appearance.Text' then XformGraphicObject.GraphicText
					else 
			                        case                                                   
				       	            when FADSFieldXform.DataType_EnumValue = 0 then cast ( FADSFieldXform.property_value as bit(1) )		--boolean
			                            when FADSFieldXform.DataType_EnumValue = 1 then cast ( FADSFieldXform.property_value as int )			--integer
			                            when FADSFieldXform.DataType_EnumValue = 2 then cast ( FADSFieldXform.property_value as varchar(500))		--string     
			                            when FADSFieldXform.DataType_EnumValue = 3 then cast ( FADSFieldXform.property_value as datetime)			--date
			                            when FADSFieldXform.DataType_EnumValue = 4 then cast ( FADSFieldXform.property_value as nvarchar(500))
			                            when FADSFieldXform.DataType_EnumValue = 5 then cast ( FADSFieldXform.property_value as bit)			--byte
			                            when FADSFieldXform.DataType_EnumValue = 7 then cast ( FADSFieldXform.property_value as numeric(20,9))	--fraction
			                            when FADSFieldXform.DataType_EnumValue = 8 then cast ( FADSFieldXform.property_value as numeric(22,2))	--numeric
						    else FADSFieldXform.property_value
						end
				end
FROM         XformGraphicObject INNER JOIN
                      FADSFieldXform ON XformGraphicObject.typedesc = FADSFieldXform.[Value]
Where (XformGraphicObject.typedesc = 'LABEL')
ORDER BY XformGraphicObject.Area asc, XformGraphicObject.Screen asc, Field asc



--the rest of the propertyvalues for graphic objects
--INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, DataType_EnumValue, Property_Value)
INSERT INTO XFormPropertyValuesForGraphicObjects (GraphicObject_ID, Page_ID, Area, Screen, Field, App, Prec, Property_Name, Property_Value)
Select 
	GraphicObject_ID 	= xgo.graphicobject_id,	
	Page_ID 	 	= xgo.page_id,
	Area			= ff.area, 
	Screen			= ff.screen,
	Field			= ff.field,  
	App			= ff.app,
	Prec			= ff.prec,  
	Property_Name 	  	= ffx.property,
--	DataType_EnumValue	= ffx.DataType_EnumValue,
	Property_Value		= 
			case                                                   
	       	            when ffx.DataType_EnumValue = 0 then cast ( ffx.property_value as bit(1) )		--boolean
                            when ffx.DataType_EnumValue = 1 then cast ( ffx.property_value as int )			--integer
                            when ffx.DataType_EnumValue = 2 then cast ( ffx.property_value as varchar(500))		--string     
                            when ffx.DataType_EnumValue = 3 then cast ( ffx.property_value as datetime)			--date
                            when ffx.DataType_EnumValue = 4 then cast ( ffx.property_value as nvarchar(500))
                            when ffx.DataType_EnumValue = 5 then cast ( ffx.property_value as bit)			--byte
                            when ffx.DataType_EnumValue = 7 then cast ( ffx.property_value as numeric(20,9))	--fraction
                            when ffx.DataType_EnumValue = 8 then cast ( ffx.property_value as numeric(22,2))	--numeric
			    else ffx.property_value
			end

from 
	fadsfield ff, xformgraphicobject xgo, fadsfieldxform ffx 
where
	ff.app    = @Product
and
	ff.area   = xgo.area
and
	ff.screen = xgo.screen
and 
	ff.field  = xgo.field 
and 
	ff.typedesc not in('Edited','coorfile','datafile','dosfile','revtab','select','tabfld','unknown')
and
	ff.typedesc = ffx.Value
--and 
--	ffx.property != 'data.datatype'
and not exists (select 1 from XFormPropertyValuesForGraphicObjects where GraphicObject_ID = xgo.graphicobject_id and
	Property_Name = ffx.property and Property_Name = ffx.property)
order by 
	 ff.area asc, ff.screen asc, ff.field asc

--Update to set the propertyvalue of the graphicobject

update xformgraphicobject
set xformgraphicobject.DataType_EnumValue = Convert(Varchar(50),xpvgo.Property_Value)
from xformpropertyvaluesforgraphicobjects xpvgo, xformgraphicobject xgo
where xpvgo.graphicobject_id = xgo.graphicObject_id 
and Graphicobjecttype_enumvalue = 1
and xpvgo.app = @Product
and xpvgo.property_name = 'Data.DataType'

Delete From xformpropertyvaluesforgraphicobjects where property_name = 'data.datatype'







GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE XformFields @Product varchar(255)
AS
/***********************************************************************************************************
	convert data from fadsfields to graphicobject
	Assuming 8.5 X 11 inch page (portrait)
************************************************************************************************************/
truncate table XformGraphicObject
Insert into XformGraphicObject (Area, Screen, Field, App, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width, DataType_EnumValue, IsShortcut, Parent_GraphicObject_ID, Linked_GraphicObject_ID, Linked_Page_ID,GraphicText,DateCreated, DateLastSaved,typedesc,GraphicObject_Name,WIP_Flag)
Select 	
	Area			= x.area ,
	Screen 			= x.screen,
	Field 			= ff.external_field,
	App 			= ff.app,
	GraphicObjectType_EnumValue = 
			case                                                   
	       	            when ((ff.minval > 0) AND (ff.maxval > 0) AND (minval = maxval) AND (ff.typedesc in ('alpha','alphanu'))) 
				OR (ff.typedesc = 'yesno') then 11
			    else 1
			end, 
	Page_ID 		= x.page_id ,
	PositionX 		= ff.col * 30,
	PositionY 		= ff.row * 50,
	Height 			= 50,
	Width 			= ff.[len] * 30,
	DataType_EnumValue	= null,--update of this field occurs at the end of xformpropertyvalueforgraphicobject stored procedure		
	IsShortcut 		= null,
	Parent_GraphicObject_ID = null,
	Linked_GraphicObject_ID = null,
	Linked_Page_ID 		= null,
	GraphicText		= null,
	DateCreated 		= getdate(),
	DateLastSaved 		= getdate(),
	typedesc 		= null,
	GraphicObject_Name	= null,
	WIP_Flag		= null 
from 
	fadsfield ff, xformpage x 
where 
	ff.Area = x.area 
and 
	ff.screen = x.screen 
and 
	ff.app = @Product
and 	
	ff.typedesc not in ('coorfile','datafile','dosfile','revtab','select','tabfld','unknown')--obsolete	
order by 
	Page_id asc, Area asc, screen asc, field asc


Insert into XformGraphicObject (Area, Screen, Field, App, GraphicObjectType_EnumValue, Page_ID, PositionX, PositionY, Height, Width, DataType_EnumValue, IsShortcut, Parent_GraphicObject_ID, Linked_GraphicObject_ID, Linked_Page_ID,GraphicText,DateCreated, DateLastSaved,typedesc,GraphicObject_Name,WIP_Flag)
Select  distinct	Area			= x.area ,
	Screen 			= x.screen,
	Field 			= null,
	App 			= fl.app,
	GraphicObjectType_EnumValue = 2, 
	Page_ID 		= x.page_id ,
	PositionX 		= fl.col * 30,
	PositionY 		= fl.row * 50,
	Height 			= 50,
	Width 			= fl.[len] * 30,
	DataType_EnumValue	= null,--update of this field occurs at the end of xformpropertyvalueforgraphicobject stored procedure		
	IsShortcut 		= null,
	Parent_GraphicObject_ID = null,
	Linked_GraphicObject_ID = null,
	Linked_Page_ID 		= null,
	GraphicText		= fl.[Text],
	DateCreated 		= getdate(),
	DateLastSaved 		= getdate(),
	typedesc 		= 'LABEL',
	GraphicObject_Name	= null,
	WIP_Flag		= null 
from 
	fadslabel fl, xformpage x 
where 
	fl.Area = x.area 
and 
	fl.screen = x.screen 
and 
	fl.app = @Product
order by 
	Page_id asc, Area asc, screen asc


--First set all names to the default value
update b
set GraphicObject_Name = 
'Area' + '['+ cast(a.Area as varchar(8)) + '].' + a.Name + '.Field[' + cast(b.Field as varchar(8)) + ']'
from FADSName a, XFormGraphicObject b
where a.App = b.App
and a.App = @Product
and a.Area = b.Area
and a.Screen = b.Screen
and a.Type = 83
and b.GraphicObjectType_EnumValue = 1

--Now, update those fields that have names.
update b
set GraphicObject_Name = 
'Area' + '['+ cast(a.Area as varchar(8)) + '].' + c.Name + '.' + a.Name
from FADSName a, XFormGraphicObject b, FADSName c
where a.App = b.App
and a.App = @Product
and a.Area = b.Area
and a.Screen = b.Screen
and a.Field = b.Field
and b.Area = c.Area
and b.Screen = c.Screen
and c.Type = 83
and b.App = c.App
and b.GraphicObjectType_EnumValue = 1



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO







CREATE PROCEDURE XformScreen @Product varchar(255)
AS 

truncate table xformpage
insert into  xformpage (Area,Screen, Product_Name,Page_Name, PageType_EnumValue, Parent_Page_ID, DateCreated, DateLastSaved, DateLastApproved)
select Key_Area, Key_Screen, app, cast(key_screen as varchar(255))  + ': ' + title as Page_Name, 
       PageType_EnumValue = 5  , 
        Parent_Page_ID= null, 
       getdate() as DateCreated, 
       getdate() as DateLastSaved, 
       getdate() as DateLastApproved  
from fadsscreen 
where app = @Product
order by key_area asc, key_screen asc


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

