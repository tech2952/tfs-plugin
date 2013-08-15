/*  This script will execute most of the post-conversion scripts.  */
use [SomeDB]
Go


/* Global Variables  */
declare @LASTPAGE int --the ID of the last page in the database prior to conversion
declare @LASTGRAPHIC int --the ID of the last graphic object in the database prior to conversion
declare @LASTNAVNODE int  --the ID of the last navigation node in the database prior to conversion
declare @LASTCODESCRIPT int --the ID of the last code script in the database prior to conversion
declare @THISPRODUCT varchar(50) --the name of the product that you are converting
declare @NAVORDERPREFIX char(1) -- a preceding value to prepend to the New Nav Order value to separate the apps alphabetically

/* assign values to each of the global variables  */

select @LASTPAGE = 0
select @LASTGRAPHIC = 0
select @LASTNAVNODE = 0
select @LASTCODESCRIPT = 0
select @THISPRODUCT = 'F990'
select @NAVORDERPREFIX = 'v' /*  Use the following values:  1040 = c, 1041 = e,1065 = g,1120 = i,7060 = k,7090 = m, F990 = p, ISUT = r, 
								1041(tez) = t,F990(tez) = v */


/*Local Variables */
declare @PAGEID int
declare @GRAPHICID int
declare @PARENTOBJECT int
declare @NAVID as int
declare @PROCESSLEVEL tinyint
declare @POSITIONX smallint
declare @POSITIONY smallint
declare @GROUPRIGHT smallint
declare @GROUPBOTTOM smallint
declare @INNERX smallint
declare @INNERY smallint
declare @INNERRIGHT smallint
declare @INNERBOTTOM smallint
declare @GAP tinyint
declare @NEWX smallint
declare @NEWY smallint
declare @NEWWIDTH smallint
declare @NEWHEIGHT smallint
declare @GROUPBOXENUM tinyint
declare @NODENAME varchar(50)
declare @MYLEVEL tinyint
declare @MYNODE int
declare @DEVELOPERROLE int
declare @ROLECOUNT int
declare @FONTNAME varchar(100)
declare @FONTINDEX tinyint
declare @TB_SPACING smallint
declare @FADS_SPACING smallint
declare @FONT_INDEX tinyint
declare @PIXEL_PER_CHAR numeric(3,1)
declare @COMPUTED_SPACING numeric(5,1)
declare @ROUNDED_SPACING smallint
declare @MINX smallint
declare @MAXWIDTH smallint
declare @GROUPWIDTH smallint
declare @NEWSPACING smallint
declare @MINY smallint
declare @MAXHEIGHT smallint
declare @GROUPHEIGHT smallint
declare @MYGROUPFIELD int
declare @MYFORMIMAGE int
declare @PARENTNODE as int  
declare @COUNT as smallint 
declare @CHILDLEVEL as tinyint 
declare @DISPLAYORDER as nvarchar(50) 
declare @LABELID int  
declare @UNDERLINEID int 
declare @OLDWIDTH smallint 

select @NAVID = Navigation_ID
from Navigation
where Product_Name = @THISPRODUCT
and NavigationType_EnumValue = 1

--TFS 63465  Remove default properties.  Eventually, PEAT should take care of this.
select 'Starting script: Remove Default Properties' 
--eliminate default property values

create table #Props (Property_Type nvarchar(8), Property_Name nvarchar(50), Property_Value smallint)

insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Page', 'Appearance.FontIndex',0)
/*
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Page', 'Behavior.Relational',0)
*/
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Page', 'Page.Orientation',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Page', 'Page.PaperSize',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Page', 'Page.SuppressUpshift',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Appearance.FontIndex',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.AutoFit',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.IsEssential',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.PrintOnPage',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.SubStringBegin',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.SubStringLength',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.TextVertAlign',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.WordWrap',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Constraints.EssentialData',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.AllowSpaceForBlankMembers',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.RepetitionDirection',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.RepetitionsPerPageDown',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.RepetitionsPerPageRight',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.RequiredLinesRemaining',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.SpaceBetweenRepetitionDown',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.SpaceBetweenRepetitionRight',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Group.StartingRowNumber',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Label.Group.RepetitionOnThisPage',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Appearance.RequiredLinesRemaining',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Appearance.SpecialText',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Graphic', 'Behavior.PercentFormat',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Attachment.SubjectToCompress',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'AttachmentNode.PageHasContinuation',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Behavior.EssentialDataTest',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Behavior.PrintSet',0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'GroupLoop.NumberToProcess',-1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'GroupLoop.StartingRow',1)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Loop.AppendDescription',0)
--TFS 66360
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Attachment.RestartAttachmentNumber', 0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Behavior.AutoCompressChildren', 0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Behavior.Display', 0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Behavior.RestartPageNumber', 0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Function.SpecialUserFunction', 0)
insert into #Props (Property_Type, Property_Name, Property_Value)
values ( 'Node', 'Loop.LoopType', 0)





delete pvp
from PropertyValuesForPage pvp, #Props tp
where tp.Property_Type = 'Page'
and pvp.Property_Name = tp.Property_Name
and pvp.Property_Value = tp.Property_Value
and pvp.Page_ID > @LASTPAGE

delete pvn
from PropertyValuesForNode pvn, #Props tp
where tp.Property_Type = 'Node'
and pvn.Property_Name = tp.Property_Name
and pvn.Property_Value = tp.Property_Value
and pvn.Navigation_Node_ID > @LASTNAVNODE

delete pvg
from PropertyValuesForGraphic pvg, #Props tp
where tp.Property_Type = 'Graphic'
and pvg.Property_Name = tp.Property_Name
and pvg.Property_Value = tp.Property_Value
and pvg.GraphicObject_ID > @LASTGRAPHIC

drop table #Props

delete pvp
from PropertyValuesForPage pvp, Page p
where pvp.Property_Name = 'Behavior.Relational'
and pvp.Property_Value = 0
and pvp.Page_ID = p.Page_ID
and pvp.Page_ID > @LASTPAGE
and p.PageType_EnumValue in (0, 10) --Form, Report

delete pvp
from PropertyValuesForPage pvp, Page p
where pvp.Property_Name = 'Behavior.Relational'
and pvp.Property_Value = 1
and pvp.Page_ID = p.Page_ID
and pvp.Page_ID > @LASTPAGE
and p.PageType_EnumValue in (1, 9) --Attachment, Continuation


select 'Finished script: Remove Default Properties' 

--Script 1 :  Delete header nodes that are not parents of other nodes.  This will clean up the print tree a bit.
select 'Starting script: 02-DeleteHeaderNodesThatAreNotParents' 
 
create table #NODES (NavigationNodeID int)
create table #SHORTCUTS (NavigationNodeID int)

select @PROCESSLEVEL = max(Indent_Level)
from NavigationNode
where Navigation_ID = @NAVID
and NodeType_EnumValue = 5 --HeaderNode


--loop thru each indent level and delete all header nodes without children
while (@PROCESSLEVEL > 0)
  begin
  --populate temp nodes table
  insert into #NODES (NavigationNodeID)
  select nn1.Navigation_Node_ID
	from NavigationNode nn1 
	where nn1.NodeType_EnumValue = 5 --HeaderNode
	and nn1.Navigation_ID = @NAVID
    and nn1.Indent_Level = @PROCESSLEVEL
	and nn1.Navigation_Node_ID Not in (select isnull(nn2.Parent_Node_ID,0)
										from NavigationNode nn2
										where nn2.Navigation_ID = @NAVID)
   
  --must delete PropertyValuesForNode entries
    delete pvn
	from PropertyValuesForNode pvn, #NODES tn
	where pvn.Navigation_Node_ID = tn.NavigationNodeID

  --delete any FADSConstraintDependency entries
	delete fcd
	from FADSConstraintDependency fcd, CodeScriptAssignment csa, #NODES tn
	where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
	and csa.Dependent_Page_ID = 0
	and csa.Dependent_ID = tn.NavigationNodeID

  --delete any CodeScriptAssignment entries
	delete csa
	from CodeScriptAssignment csa, #NODES tn
	where csa.Dependent_Page_ID = 0
	and csa.Dependent_ID = tn.NavigationNodeID

  --then delete NavigationNode entries
	delete nn
	from NavigationNode nn, #NODES tn
	where nn.Navigation_Node_ID = tn.NavigationNodeID
    and nn.Navigation_ID = @NAVID
    and nn.NodeType_EnumValue = 5
	and nn.Indent_Level = @PROCESSLEVEL

--populate shortcuts table
	insert into #SHORTCUTS (NavigationNodeID)
	select nn.Navigation_Node_ID
	from NavigationNode nn, #NODES tn
	where nn.Navigation_ID = @NAVID
	and nn.ShortCut_Node_ID = tn.NavigationNodeID

  truncate table #NODES
  select @PROCESSLEVEL = (@PROCESSLEVEL - 1)
end --begin

drop table #NODES

--TFS 65491 --now, remove the shortcut nodes that were pointing at these deleted header nodes

 --must delete PropertyValuesForNode entries
    delete pvn
	from PropertyValuesForNode pvn, #SHORTCUTS ts
	where pvn.Navigation_Node_ID = ts.NavigationNodeID

  --delete any FADSConstraintDependency entries
	delete fcd
	from FADSConstraintDependency fcd, CodeScriptAssignment csa, #SHORTCUTS ts
	where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
	and csa.Dependent_Page_ID = 0
	and csa.Dependent_ID = ts.NavigationNodeID

  --delete any CodeScriptAssignment entries
	delete csa
	from CodeScriptAssignment csa, #SHORTCUTS ts
	where csa.Dependent_Page_ID = 0
	and csa.Dependent_ID = ts.NavigationNodeID

delete nn
from NavigationNode nn, #SHORTCUTS ts
where nn.Navigation_ID = @NAVID
and nn.Navigation_Node_ID = ts.NavigationNodeID

drop table #SHORTCUTS

select 'Finished script: 02-DeleteHeaderNodesThatAreNotParents' 

--Script 2 :  Update Code Scripts by replacing NONE with 0, and changing the parameter names to get rid of the word PARM
select 'Starting script: 03-UpdateCodeScriptSyntax' 
--Replace NONE references with zero so that code scripts will compile

update CodeScript
set Code_Syntax = replace(Code_Syntax, 'NONE', '0')
where Code_ID > @LASTCODESCRIPT


--Analysts do not like the word Parm in the parameter name.  So, first append 1 to the first parm of a specified datatype
update CodeScript
set Code_Syntax = replace(Code_Syntax, 'Parm ', 'Parm1 ')
where Code_ID > @LASTCODESCRIPT

update CodeScript
set Code_Syntax = replace(Code_Syntax, 'Parm.', 'Parm1.')
where Code_ID > @LASTCODESCRIPT

update CodeScript
set Code_Syntax = replace(Code_Syntax, 'Parm,', 'Parm1,')
where Code_ID > @LASTCODESCRIPT

update CodeScript
set Code_Syntax = replace(Code_Syntax, 'Parm)', 'Parm1)')
where Code_ID > @LASTCODESCRIPT

update CodeScriptParameters
set Parameter_Name = Parameter_Name + '1'
where Parameter_Name in ('BooleanParm','IntegerParm','StringParm','MoneyParm','RatioParm','DateParm')
and Code_ID > @LASTCODESCRIPT

--Then rid ourselves of the word Parm
update CodeScript
set Code_Syntax = replace(Code_Syntax, 'Parm', '')
where Code_ID > @LASTCODESCRIPT

update CodeScriptParameters
set Parameter_Name = replace(Parameter_Name, 'Parm', '')
where Code_ID > @LASTCODESCRIPT

select 'Finished script: 03-UpdateCodeScriptSyntax' 

--Script 3 :  Update code script names by removing illegal characters and appending the code ID
select 'Starting script: 04-UpdateCodeScriptNames' 
--Replace illegal characters in CodeScript name: ~`!@#$%^&*()-+=|\[]{};':,./ <>?"

update CodeScript
set Code_Name = REPLACE (Code_Name , '~' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '!' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '@' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '#' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '$' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '%' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '^' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '&' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '*' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '(' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , ')' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '-' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '+' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '=' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '|' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '\' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '[' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , ']' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '{' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '}' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , ';' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '''' , '' )

update CodeScript
set Code_Name = REPLACE (Code_Name , ':' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , ',' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '.' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '/' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '<' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '>' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '?' , 'x' )

update CodeScript
set Code_Name = REPLACE (Code_Name , '"' , '' )

update CodeScript
set Code_Name = REPLACE (Code_Name , ' ' , '_' )

--Now, append Code_ID to ensure uniqueness
update CodeScript
set Code_Name = left(Code_Name,42) + '_ID'+ convert(varchar(5), Code_ID)
where Code_ID > @LASTCODESCRIPT

select 'Finished script: 04-UpdateCodeScriptNames' 

--Script 4 : Update Graphic Object field datatypes to match the datatype of the assigned FADS field
select 'Starting script: 05a-UpdateFieldDatatype' 

update g
set  g.DataType_EnumValue = f.Field_Datatype
from GraphicObject g, FADSField f, PropertyValuesForGraphic p
where p.Property_Name = 'SourceField.FADSFieldID'
and p.Property_Value = f.FADS_Field_ID
and p.Page_ID = g.Page_ID
and p.Page_ID > @LASTPAGE
and p.GraphicObject_ID = g.GraphicObject_ID
and g.GraphicObject_ID > @LASTGRAPHIC


--TFS 69290
update csp
set csp.Parameter_Enum_DataType = ff.Field_Datatype
from CodeScriptParameters csp, FADSConstraintDependency fcd, FADSField ff
where csp.Parameter_ID = fcd.Parameter_ID
and fcd.FADS_Field_ID = ff.FADS_Field_ID
and csp.Parameter_Enum_DataType <> ff.Field_Datatype
and csp.Code_ID > @LASTCODESCRIPT


select 'Finished script: 05a-UpdateFieldDatatype' 

--Script 5 :  Assign the Left Align property to textboxes of type string and font
select 'Starting script: 05b-Set Text Alignment' 

insert into PropertyValuesForGraphic (GraphicObject_ID,Page_ID,Property_Name,Property_Value)
select g.GraphicObject_ID, g.Page_ID, 'Behavior.TextAlign',0 --Left Align
  from GraphicObject g
  where g.DataType_EnumValue in (2,4) /*(2,3,4) -- string, date, font */ -- Exclude dates per PCR 218208
  and g.GraphicObjectType_EnumValue = 1 -- Textbox
  and g.GraphicObject_ID > @LASTGRAPHIC
  and g.Page_ID > @LASTPAGE
  and not exists (select 1 from PropertyValuesForGraphic pvg
		  where g.GraphicObject_ID = pvg.GraphicObject_ID
		  and g.Page_ID = pvg.Page_ID
		  and pvg.Property_Name = 'Behavior.TextAlign')

select 'Finished script: 05b-Set Text Alignment' 

--Script 6 :  Set the node order for the design tree to match the order created (usually, by role)
select 'Starting script: 06-UpdateDesignNavOrder' 

declare @NAVNODE int
declare @ORDERCOUNT    smallint
declare @NEWORDER char(5)

select @ORDERCOUNT = 0
select @NEWORDER = 'aaaa'

declare Cursor_UpdateNavOrder insensitive scroll cursor for
    select Navigation_Node_ID
    from NavigationNode
    where Navigation_ID = 1
    and NodeType_EnumValue = 0 
	and Navigation_Node_ID > @LASTNAVNODE
    order by Node_Name

    open    Cursor_UpdateNavOrder 

    fetch from Cursor_UpdateNavOrder 
    into    @NAVNODE

    while (@@FETCH_STATUS <> -1)
    begin --Cursor_UpdateNavOrder
      	select @ORDERCOUNT = @ORDERCOUNT + 1
        if (@ORDERCOUNT < 10)
        begin
	   select @NEWORDER = '000' + convert(varchar(1), @ORDERCOUNT)
        end
        else
        begin -- first else
          if (@ORDERCOUNT < 100)
          begin
	    select @NEWORDER = '00' + convert(varchar(2), @ORDERCOUNT)
          end
          else 
	  begin -- 2nd else
	     if (@ORDERCOUNT < 1000)
             begin
	       select @NEWORDER = '0' + convert(varchar(3), @ORDERCOUNT)
	     end
             else
             begin -- 3rd else
		if (@ORDERCOUNT < 10000)
         	begin
	   	   select @NEWORDER = convert(varchar(4), @ORDERCOUNT)
         	end 
             end -- 3rd else
          end -- 2nd else
        end --first else
               
    select @NEWORDER = replace (@NEWORDER, '0','a')
	select @NEWORDER = replace (@NEWORDER, '1','c')
	select @NEWORDER = replace (@NEWORDER, '2','e')
	select @NEWORDER = replace (@NEWORDER, '3','g')
	select @NEWORDER = replace (@NEWORDER, '4','i')
	select @NEWORDER = replace (@NEWORDER, '5','k')
	select @NEWORDER = replace (@NEWORDER, '6','m')
	select @NEWORDER = replace (@NEWORDER, '7','o')
	select @NEWORDER = replace (@NEWORDER, '8','q')
	select @NEWORDER = replace (@NEWORDER, '9','r')
    
	select @NEWORDER = (@NAVORDERPREFIX + @NEWORDER)

	update NavigationNode
	set DisplayOrder = @NEWORDER
	where Navigation_ID = 1
	and NodeType_EnumValue = 0
	and Navigation_Node_ID = @NAVNODE

      fetch from Cursor_UpdateNavOrder 
	into    @NAVNODE
    end --Cursor_UpdateNavOrder
    close Cursor_UpdateNavOrder
    deallocate Cursor_UpdateNavOrder  

select 'Finished script: 06-UpdateDesignNavOrder' 


--Script 7 :  Find and shorten underline labels and abbreviated hyperlinks that spill over the border
select 'Starting script: 09-TooWideUnderlineLabels' 
--Too wide underline labels - Portrait
update g
set g.Width = (2520 - g.PositionX)
--select g.Page_ID, g.GraphicObject_ID, g.PositionX, g.Width, (2550 - g.PositionX)
from GraphicObject g, PropertyValuesForGraphic pg
where g.GraphicObjectType_EnumValue = 2
and g.GraphicObject_ID = pg.GraphicObject_ID
and g.Page_ID = pg.Page_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and pg.Property_Name = 'Appearance.Text'
and (cast(pg.Property_Value as varchar(500)) like '%---%'
or cast(pg.Property_Value as varchar(500)) like '%===%')
and g.Width > 1000
and (g.PositionX + g.Width) > 2520
and pg.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape

--Too wide underline labels - Landscape
update g
set g.Width = (3250 - g.PositionX)
--select g.Page_ID, g.GraphicObject_ID, g.PositionX, g.Width, (3300 - g.PositionX)
from GraphicObject g, PropertyValuesForPage p, PropertyValuesForGraphic pg
where g.GraphicObjectType_EnumValue = 2
and g.GraphicObject_ID = pg.GraphicObject_ID
and g.Page_ID = p.Page_ID
and g.Page_ID = pg.Page_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and pg.Property_Name = 'Appearance.Text'
and (cast(pg.Property_Value as varchar(500)) like '%---%'
or cast(pg.Property_Value as varchar(500)) like '%===%')
and g.Width > 1000
and (g.PositionX + g.Width) > 3250
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1

--Too-wide Hyperlinks (when using the short text)
update g
set g.Width = 120
from GraphicObject g, PropertyValuesForGraphic pg
where pg.Property_Name = 'Appearance.HyperText'
and pg.Property_Value = 1
and pg.Page_ID = g.Page_ID
and pg.GraphicObject_ID = g.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

select 'Finished script: 09-TooWideUnderlineLabels' 

--Script 8 :  Removes unused properties, removes default property values, adds the Group Overflow property for certain pages,
--  adjust the heights of underlined objects, sets property to print labels only when data exists on same row.
select 'Starting script: 12a-CorrectProperties' 

--Not seen in conversion of 1065.  Does it exist anywhere any longer?
delete p
from PropertyValuesForGraphic p, GraphicObject g
where p.Page_ID = g.Page_ID
and p.GraphicObject_ID = g.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 3
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and p.Property_Name in ('Group.ListName', 'GroupLoop.NumberToProcess')


--Remove unused properties for Continuation Pages
delete pvp
from Page p, PropertyValuesForPage pvp
where pvp.Page_ID = p.Page_ID
and p.PageType_EnumValue = 9
and p.Page_ID > @LASTPAGE
and pvp.Property_Name in ('Page.ImageCode', 'Page.Background.ImageInfo_ID')


--Remove Group.RequiredLinesRemaining from non-group objects
delete pg
from PropertyValuesForGraphic pg, GraphicObject g
where pg.Property_Name = 'Group.RequiredLinesRemaining'
and pg.GraphicObject_ID = g.GraphicObject_ID
and isnull(g.Parent_GraphicObject_ID,0) = 0
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

--Remove Group.RequiredLinesRemaining from labels inside groups
delete pg
from PropertyValuesForGraphic pg, GraphicObject g
where pg.Property_Name = 'Group.RequiredLinesRemaining'
and pg.GraphicObject_ID = g.GraphicObject_ID
and isnull(g.Parent_GraphicObject_ID,0) > 0
and g.GraphicObjectType_EnumValue = 2
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

--Remove IsEssential = TRUE (the default)
delete from PropertyValuesForGraphic
where Property_Name = 'Behavior.IsEssential'
and Property_Value = 1

--Add IsEssential = FALSE for Living Template textboxes in the header or footer region
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select p.Page_ID, g.GraphicObject_ID, 'Behavior.IsEssential', 0
from GraphicObject g, Page p
where p.PageType_EnumValue = 3 --LivingTemplate
and p.Page_ID = g.Page_ID
and g.GraphicObjectType_EnumValue = 1 --textbox
and (g.PositionY < 150 --header
	OR g.PositionY > 3149) --footer
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = p.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.IsEssential')

--Add IsEssential = FALSE for textboxes in the footer of non-template Portrait pages
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select p.Page_ID, g.GraphicObject_ID, 'Behavior.IsEssential', 0
from GraphicObject g, Page p
where p.PageType_EnumValue <> 3 --LivingTemplate
and p.Page_ID = g.Page_ID
and g.GraphicObjectType_EnumValue = 1 --textbox
and (g.PositionY < 150 --header
	OR g.PositionY > 3149) --footer
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = p.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.IsEssential')

--Add IsEssential = FALSE for textboxes in the footer of non-template Landscape pages
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select p.Page_ID, g.GraphicObject_ID, 'Behavior.IsEssential', 0
from GraphicObject g, Page p, PropertyValuesForPage pvp
where p.PageType_EnumValue <> 3 --LivingTemplate
and p.Page_ID = g.Page_ID
and p.Page_ID = pvp.Page_ID
and g.GraphicObjectType_EnumValue = 1 --textbox
and g.PositionY > 2399 --footer
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and pvp.Property_Name = 'Page.Orientation'
and pvp.Property_Value = 1
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = p.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.IsEssential')

--Remove LoopType = 0 (the default) from PropertyValuesForNode
delete from PropertyValuesForNode
where Property_Name = 'Loop.LoopType'
and Property_Value = 0

--Remove GroupLoop Number to Process = All (the default) from Node Properties 
delete from PropertyValuesForNode
where Property_Name = 'GroupLoop.NumberToProcess'
and Property_Value = -1

--Remove GroupLoop Starting Row = 1 (the default) from Node Properties 
delete from PropertyValuesForNode
where Property_Name = 'GroupLoop.StartingRow'
and Property_Value = 1


--insert Group Overflow property value for Group and Entity boxes on Attachments, Continuation, and Reports
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select p.Page_ID, g.GraphicObject_ID, 'Group.Overflow', 2
from Page p, GraphicObject g
where p.PageType_EnumValue in (1,9,10) --Attachment, Continuation, Report
and p.Page_ID = g.Page_ID
and g.GraphicObjectType_EnumValue in (3,4)
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Property_Name = 'Group.Overflow'
				and pvg.Page_ID = p.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID)


--adjust height of 12pt objects that have underlines
update g
set g.Height = 55
from PropertyValuesForGraphic pvg, Page p, GraphicObject g
where pvg.Property_Name = 'Appearance.UnderScore'
and pvg.Property_Value = 2 --double
and pvg.Page_ID = g.Page_ID
and pvg.GraphicObject_ID = g.GraphicObject_ID
and g.Page_ID = p.Page_ID
and g.Height = 50
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g.Page_ID
				and pvg2.GraphicObject_ID = g.GraphicObject_ID
				and pvg2.Page_ID > @LASTPAGE
				and pvg2.GraphicObject_ID > @LASTGRAPHIC
				and pvg2.Property_Name = 'Appearance.FontIndex'
				and pvg2.Property_Value not in (0,5,6) ) -- Courier New 12 pt

/* --remove this with changes made with TFS #21971 and others to handle PrintIfDataOnRow better 
--Finds labels on the same row as textboxes,and sets a property to only print the labels when 
--the textbox has data
insert into PropertyValuesForGraphic(Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select distinct g1.Page_ID, g1.GraphicObject_ID, 'Constraints.EssentialData', 1
from GraphicObject g1, GraphicObject g2, Page p
where g1.Page_ID = g2.Page_ID
and g1.Page_ID = p.Page_ID
and p.PageType_EnumValue > 0 --choose only Attachments, Continuation pages, and Reports
and g1.GraphicObjectType_EnumValue = 2 --Label
and g2.GraphicObjectType_EnumValue = 1 --Textbox
and g1.PositionY = g2.PositionY
and g1.PositionY < 3200
and (g1.PositionX + g1.Width) < g2.PositionX
--and g2.DataType_EnumValue in (1,7,8) -- integer, ratio, money
and isnull(g1.Parent_GraphicObject_ID,0) = 0
and isnull(g2.Parent_GraphicObject_ID,0) = 0
and g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = g1.Page_ID
				and pvg.GraphicObject_ID = g1.GraphicObject_ID
				and pvg.Property_Name = 'Constraints.EssentialData')

--Finds labels on the same row as textboxes,and sets the height = textbox height
update g1
set g1.Height = 55
from GraphicObject g1, GraphicObject g2, Page p
where g1.Page_ID = g2.Page_ID
and g1.Page_ID = p.Page_ID
and p.PageType_EnumValue > 0 --choose only Attachments, Continuation pages, and Reports
and g1.GraphicObjectType_EnumValue = 2 --Label
and g2.GraphicObjectType_EnumValue = 1 --Textbox
and g1.PositionY = g2.PositionY
and g1.PositionY < 3200
and (g1.PositionX + g1.Width) < g2.PositionX
and isnull(g1.Parent_GraphicObject_ID,0) = 0
and isnull(g2.Parent_GraphicObject_ID,0) = 0
and g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC
and g2.Height = 55
and g1.Height <> g2.Height
*/
--TFS 24077 shrink the width of labels that are overlapping textboxes on the same row
update g1
set g1.Width = (g2.PositionX - g1.PositionX)
from GraphicObject g1, GraphicObject g2, Page p
where g1.Page_ID = g2.Page_ID
and g1.Page_ID = p.Page_ID
and g1.GraphicObjectType_EnumValue = 2 --Label
and g2.GraphicObjectType_EnumValue = 1 --Textbox
and g1.PositionY = g2.PositionY
and g1.PositionY < 3200
and (g1.PositionX + g1.Width) >= g2.PositionX
and (g1.PositionX + g1.Width) < (g2.PositionX + g2.Width)
and g1.PositionX < g2.PositionX --label is to the left of the textbox
and isnull(g1.Parent_GraphicObject_ID,0) = 0
and isnull(g2.Parent_GraphicObject_ID,0) = 0
and g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC

--TFS 23339 set properties for ratio fields
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.IncludeCommasWhenOutputing', 1
from GraphicObject g
where g.GraphicObjectType_EnumValue = 1
and g.DataType_EnumValue = 7
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = g.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.IncludeCommasWhenOutputing')

/*  --added with 23339, removed with 24208
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.ZeroFormat', 1
from GraphicObject g
where g.GraphicObjectType_EnumValue = 1
and g.DataType_EnumValue = 7
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = g.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.ZeroFormat')
*/

--TFS 24071 set IncludeCommas = TRUE for string fields
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.IncludeCommasWhenOutputing', 0
from GraphicObject g
where g.GraphicObjectType_EnumValue in (1,7) --textbox, parsed-value field
and g.DataType_EnumValue = 2 --string
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where pvg.Page_ID = g.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.IncludeCommasWhenOutputing')

--TFS 26082 set RepeatForEachMember for labels that are part of a group
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select g.Page_ID, g.GraphicObject_ID, 'Label.Group.RepetitionOnThisPage', 1
from GraphicObject g, GraphicObject g2
where g.GraphicObjectType_EnumValue = 2 --label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID > @LASTPAGE
and g.Page_ID = g2.Page_ID
and isnull(g.Parent_GraphicObject_ID,0) > 0
and g.Parent_GraphicObject_ID = g2.GraphicObject_ID
and g2.GraphicObjectType_EnumValue in (3,4) --Group, EntityGroup
and not exists (select 1 from PropertyValuesForGraphic pvg
			where pvg.Property_Name = 'Label.Group.RepetitionOnThisPage'
			and pvg.GraphicObject_ID = g.GraphicObject_ID)
and not exists (select 1 from PropertyValuesForGraphic pvg2
			where pvg2.Property_Name = 'Appearance.SpecialText'
			and pvg2.Property_Value > 0  --do not want to affect ContinuedOnNextPage or AttachmentSectionHeadings
			and pvg2.GraphicObject_ID = g.GraphicObject_ID)

--TFS 68870 Set height to 50 for objects that are narrow
update GraphicObject
set Height = 50
where Height < 50
and Height > 10
and GraphicObject_ID > @LASTGRAPHIC
and Page_ID > @LASTPAGE

select 'Finished script: 12a-CorrectProperties' 

--Script 9 :  Remove constraints from Hyperlinks and Attachment Section Heading Labels
select 'Starting script: 12b-DeleteConstraintsOnHyperlinksAndASH' 

delete pvg
from CodeScriptAssignment csa, GraphicObject g, PropertyValuesForGraphic pvg
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_Page_ID = pvg.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and csa.Dependent_ID = pvg.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 5
and pvg.Property_Name = 'Constraint.AssignmentID'
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

delete pvg2
from CodeScriptAssignment csa, GraphicObject g, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_Page_ID = pvg1.Page_ID
and csa.Dependent_Page_ID = pvg2.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and csa.Dependent_ID = pvg1.GraphicObject_ID
and csa.Dependent_ID = pvg2.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and pvg2.Property_Name = 'Constraint.AssignmentID'
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC


delete fcd
from CodeScriptAssignment csa, GraphicObject g, FADSConstraintDependency fcd
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 5
and csa.CodeScriptAssignment_ID = fcd.CodeScriptAssignment_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

delete fcd
from CodeScriptAssignment csa, GraphicObject g, PropertyValuesForGraphic pvg1, FADSConstraintDependency fcd
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_Page_ID = pvg1.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and csa.Dependent_ID = pvg1.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and csa.CodeScriptAssignment_ID = fcd.CodeScriptAssignment_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

delete csa
from CodeScriptAssignment csa, GraphicObject g
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 5
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

delete csa
from CodeScriptAssignment csa, GraphicObject g, PropertyValuesForGraphic pvg1
where csa.Dependent_Page_ID = g.Page_ID
and csa.Dependent_Page_ID = pvg1.Page_ID
and csa.Dependent_ID = g.GraphicObject_ID
and csa.Dependent_ID = pvg1.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.SpecialText'
and pvg1.Property_Value = 7
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

select 'Finished script: 12b-DeleteConstraintsOnHyperlinksAndASH' 

--Script 10 :  Sets the converted Page's last approval date = to the Page's creation date
select 'Starting script: 13-SetApprovalDate' 

update Page
set DateLastApproved = DateLastSaved
where Page_ID > @LASTPAGE

select 'Finished script: 13-SetApprovalDate' 

--Script 11 :  Sets the code script parameter order
select 'Starting script: 14-PopulateParmPosition' 
declare @PARM_ID int
declare @CODE_ID int
declare @PARMORDER tinyint

select @PARMORDER = 0  --was 1, modified on 08/14/2007 per Ed Beck.

declare CURSOR_Code cursor for 
select distinct Code_ID
from CodeScriptParameters
where Code_ID > @LASTCODESCRIPT
order by Code_ID asc 

open CURSOR_Code
fetch next from CURSOR_Code into @CODE_ID

while @@FETCH_STATUS = 0
begin -- CURSOR_Code
   --initialize the parameter order
   	select @PARMORDER = 0  --was 1, modified on 08/14/2007 per Ed Beck.
   --loop thru the parameters for this code, and increment their order
	declare CURSOR_Parameter cursor for 
	select Parameter_ID
	from CodeScriptParameters
	where Code_ID = @CODE_ID
	order by Parameter_ID asc 

	open CURSOR_Parameter
	fetch next from CURSOR_Parameter into @PARM_ID

	while @@FETCH_STATUS = 0
	begin -- CURSOR_Parameter
   	--update the parm order
	   update CodeScriptParameters
	   set Parameter_Position = @PARMORDER
	   where Parameter_ID = @PARM_ID
	
	 --increment Parm Order for next parm
	   select @PARMORDER = @PARMORDER + 1

   	fetch next from CURSOR_Parameter into @PARM_ID
	end --CURSOR_Parameter
	close CURSOR_Parameter
	deallocate CURSOR_Parameter

   fetch next from CURSOR_Code into @CODE_ID
end --CURSOR_Code
close CURSOR_Code
deallocate CURSOR_Code

select 'Finished script: 14-PopulateParmPosition' 

--Script 12 :  Deletes the node Loop properties when no FADS field is assigned to the loop
select 'Starting script: 17-ClearNodeLoopProperties' 

--Group Loop Nodes without FADS fields
delete pn3
from PropertyValuesForNode pn3
where pn3.Property_Name like '%Loop%'
and pn3.Navigation_Node_ID in (
	select distinct pn1.Navigation_Node_ID
	from PropertyValuesForNode pn1, PropertyValuesForNode pn2
	where pn1.Property_Name = 'Loop.LoopType'
	and pn1.Property_Value = 2 --GroupLoop
	and pn1.Navigation_Node_ID > @LASTNAVNODE
	and not exists (select pn2.Navigation_Node_ID
			from PropertyValuesForNode pn2
			where pn1.Navigation_Node_ID = pn2.Navigation_Node_ID 
			and pn2.Property_Name = 'LoopName.FADSFieldID'))

--Entity Loop Nodes without FADS fields
delete pn3
from PropertyValuesForNode pn3
where pn3.Property_Name like '%Loop%'
and pn3.Navigation_Node_ID in (
	select distinct pn1.Navigation_Node_ID
	from PropertyValuesForNode pn1, PropertyValuesForNode pn2
	where pn1.Property_Name = 'Loop.LoopType'
	and pn1.Property_Value = 1 --EntityLoop
	and pn1.Navigation_Node_ID > @LASTNAVNODE
	and not exists (select pn2.Navigation_Node_ID
			from PropertyValuesForNode pn2
			where pn1.Navigation_Node_ID = pn2.Navigation_Node_ID 
			and pn2.Property_Name = 'LoopName.FADSFieldID'))

--Loop nodes with invalid FADS fields
delete pn2
from PropertyValuesForNode pn2
where pn2.Property_Name like '%Loop%'
and pn2.Navigation_Node_ID in ( 
	select distinct pn1.Navigation_Node_ID 
	from PropertyValuesForNode pn1
	where pn1.Property_Name = 'LoopName.FADSFieldID'
	and pn1.Navigation_Node_ID > @LASTNAVNODE
	and pn1.Property_Value not in (select FADS_Field_ID
				 	from FADSField))

select 'Finished script: 17-ClearNodeLoopProperties' 

--Script 13 :  Delete textboxes without valid FADS assignments
select 'Starting script: 18-DeleteTextboxesWithoutFADS' 

declare Cursor_MissingFADS insensitive scroll cursor for
   /* Find textboxes without any FADS entry */
   select g.Page_ID, g.GraphicObject_ID
   from GraphicObject g
   where g.GraphicObjectType_EnumValue = 1 --TextBox
   and g.Page_ID > @LASTPAGE
   and g.GraphicObject_ID > @LASTGRAPHIC
   and g.GraphicObject_ID not in (select pg.GraphicObject_ID
				from PropertyValuesForGraphic pg
				where pg.Property_Name = 'SourceField.FADSFieldID')
   UNION
   /*Find textboxes with an invalid FADS entry */
   select g.Page_ID, g.GraphicObject_ID
   from GraphicObject g, PropertyValuesForGraphic pg
   where g.GraphicObjectType_EnumValue = 1 --TextBox
   and g.GraphicObject_ID = pg.GraphicObject_ID
   and g.Page_ID = pg.Page_ID
   and g.Page_ID > @LASTPAGE
   and g.GraphicObject_ID > @LASTGRAPHIC
   and pg.Property_Name = 'SourceField.FADSFieldID'
   and pg.Property_Value not in (select FADS_Field_ID
				 from FADSField)
   open Cursor_MissingFADS
   fetch from Cursor_MissingFADS
   into  @PAGEID, @GRAPHICID

   while (@@FETCH_STATUS <> -1)
   begin
   
     	/*First, delete Properties */
	delete from PropertyValuesForGraphic
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error deleting Properties for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end
--TFS 65481

	--delete FADSContraintDependency entries 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @GRAPHICID
		and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID

		--delete CodeScriptAssignments entries
		delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @GRAPHICID


	/*Next, delete the object */
	delete from GraphicObject
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error deleting Object for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end

   fetch from Cursor_MissingFADS 
	into  @PAGEID, @GRAPHICID
   end --Cursor_MissingFADS
   close Cursor_MissingFADS
   deallocate Cursor_MissingFADS 

select 'Finished script: 18-DeleteTextboxesWithoutFADS' 

--Script 14 :  Delete groupboxes that have no child textboxes
select 'Starting script: 19a-DeleteGroupboxesWithoutTextboxes' 

declare Cursor_MissingChildren insensitive scroll cursor for
   select g1.Page_ID, g1.GraphicObject_ID
   from GraphicObject g1
   where g1.GraphicObjectType_EnumValue in (3,4) --GroupBox, EntityGroupBox
   and g1.Page_ID > @LASTPAGE
   and g1.GraphicObject_ID > @LASTGRAPHIC
   and g1.GraphicObject_ID not in (select distinct g2.Parent_GraphicObject_ID
									from GraphicObject g2
									where g2.Page_ID = g1.Page_ID
									and isnull(g2.Parent_GraphicObject_ID,0) > 0)
   open Cursor_MissingChildren
   fetch from Cursor_MissingChildren
   into  @PAGEID, @GRAPHICID

   while (@@FETCH_STATUS <> -1)
   begin
   
     	/*First, delete Properties */
	delete from PropertyValuesForGraphic
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error deleting Properties for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end
	--TFS 65481

	--delete FADSContraintDependency entries 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @GRAPHICID
		and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID

		--delete CodeScriptAssignments entries
		delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @GRAPHICID

	/*Next, delete the object */
	delete from GraphicObject
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error deleting Object for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end

   fetch from Cursor_MissingChildren 
	into  @PAGEID, @GRAPHICID
   end --Cursor_MissingChildren
   close Cursor_MissingChildren
   deallocate Cursor_MissingChildren 

select 'Finished script: 19a-DeleteGroupboxesWithoutTextboxes' 

--Script 15 :  Delete groupboxes that do not loop on valid FADS fields
select 'Starting script: 19b-DeleteGroupboxesWithoutFADS' 

declare Cursor_MissingFADS insensitive scroll cursor for
   /* Find textboxes without any FADS entry */
   select g.Page_ID, g.GraphicObject_ID
   from GraphicObject g
   where g.GraphicObjectType_EnumValue in (3,4) --GroupBox, EntityGroupBox
   and g.Page_ID > @LASTPAGE
   and g.GraphicObject_ID > @LASTGRAPHIC
   and g.GraphicObject_ID not in (select pg.GraphicObject_ID
				from PropertyValuesForGraphic pg
				where pg.Property_Name = 'SourceField.FADSFieldID')
   UNION
   /*Find textboxes with an invalid FADS entry */
   select g.Page_ID, g.GraphicObject_ID
   from GraphicObject g, PropertyValuesForGraphic pg
   where g.GraphicObjectType_EnumValue in (3,4) --GroupBox, EntityGroupBox
   and g.GraphicObject_ID = pg.GraphicObject_ID
   and g.Page_ID = pg.Page_ID
   and g.Page_ID > @LASTPAGE
   and g.GraphicObject_ID > @LASTGRAPHIC
   and pg.Property_Name = 'SourceField.FADSFieldID'
   and pg.Property_Value not in (select FADS_Field_ID
				 from FADSField)
   open Cursor_MissingFADS
   fetch from Cursor_MissingFADS
   into  @PAGEID, @GRAPHICID

   while (@@FETCH_STATUS <> -1)
   begin
   
     	/*First, delete Properties */
	delete from PropertyValuesForGraphic
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error deleting Properties for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end
	/*Next, delete the reference from any child textboxes */
	update GraphicObject
  	set Parent_GraphicObject_ID = NULL
	where Page_ID = @PAGEID
	and Parent_GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error removing Parent reference for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end

	--TFS 65481

	--delete FADSContraintDependency entries 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @GRAPHICID
		and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID

		--delete CodeScriptAssignments entries
		delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @GRAPHICID

	/*Next, delete the object */
	delete from GraphicObject
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	if @@ERROR <> 0 
	begin
	   select 'Error deleting Object for Page: ', @PAGEID, ', GraphicObject: ', @GRAPHICID
	   break
	end

   fetch from Cursor_MissingFADS 
	into  @PAGEID, @GRAPHICID
   end --Cursor_MissingFADS
   close Cursor_MissingFADS
   deallocate Cursor_MissingFADS 


select 'Finished script: 19b-DeleteGroupboxesWithoutFADS' 

--Script 16 :  Update @CONTTITLE labels that are children of groupboxes
select 'Starting script: 20-UpdateCONTTITLElabels' 

declare CONTTITLE cursor for
select pg.Page_ID, pg.GraphicObject_ID, isnull(g.Parent_GraphicObject_ID,0)
from PropertyValuesForGraphic pg, GraphicObject g
where pg.Property_Name = 'Appearance.Text'
and pg.Property_Value = '@CONTTITLE'
and pg.Page_ID = g.Page_ID
and pg.GraphicObject_ID = g.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

OPEN CONTTITLE

FETCH NEXT from CONTTITLE into @PAGEID, @GRAPHICID, @PARENTOBJECT

WHILE @@FETCH_STATUS = 0
BEGIN
	
	if (@PARENTOBJECT > 0)
	begin --CONTTITLE is part of a group
		-- change the width of the label to 720 pixels
		update GraphicObject
		set Width = 720
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID

		-- change the text of the label to Continued On Next Page
		update PropertyValuesForGraphic
		set Property_Value = 'Continued On Next Page'
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID
		and Property_Name =  'Appearance.Text'

	end --CONTTITLE is part of a group
	else
	begin --CONTTITLE is not part of a group
		--delete PropertyValueForGraphic entries
		delete from PropertyValuesForGraphic
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID

		--delete FADSContraintDependency entries 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @GRAPHICID
		and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID

		--delete CodeScriptAssignments entries
		delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @GRAPHICID

		--delete GraphicObject entries
		delete from GraphicObject
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID

	end --CONTTITLE is not part of a group

   FETCH NEXT from CONTTITLE into @PAGEID, @GRAPHICID, @PARENTOBJECT

END -- CURSOR CONTTITLE

close CONTTITLE
deallocate CONTTITLE

select 'Finished script: 20-UpdateCONTTITLElabels' 

--Script 17 :  remove invalid Parent_GraphicObject_ID assignments
select 'Starting script: 21-ClearInvalidParentGraphicObjectRefs' 

update g1
set Parent_GraphicObject_ID = NULL
from GraphicObject g1
where isnull(g1.Parent_GraphicObject_ID,0) > 0
and g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC
and g1.Parent_GraphicObject_ID not in (select distinct g2.GraphicObject_ID
										from GraphicObject g2)

select 'Finished script: 21-ClearInvalidParentGraphicObjectRefs' 

--Script 17a :  Update orientation of landscape pages and remove any templates from them

select 'Starting script: 22-EliminateTemplatesFromLandscape' 
/* -- Now, handled in PEAT via config settings
--update orientation for landscape pages that were not set as Landscape in FADS
update pvp2
set pvp2.Property_Value = 1
from Page p, PropertyValuesForPage pvp1, PropertyValuesForPage pvp2, TaxBuilder4Images.dbo.ImageInfo ii
where p.Page_ID = pvp1.Page_ID
and p.Page_ID = pvp2.Page_ID
and p.Page_ID > @LASTPAGE
and pvp1.Property_Name = 'Page.Background.ImageInfo_ID'
and cast(pvp1.Property_Value as int) = ii.ImageInfo_ID
and (ii.Document_Code like '%SPSLN'
	OR ii.Document_Code like '%X9027'
	OR ii.Document_Code like '%X9010')
and pvp2.Property_Name = 'Page.Orientation'
and pvp2.Property_Value = 0


--insert orientation for landscape pages that were not set as Landscape in FADS
insert into PropertyValuesForPage (Page_ID, Property_Name, Property_Value)
select p.Page_ID, 'Page.Orientation', 1
from Page p, PropertyValuesForPage pvp1, TaxBuilder4Images.dbo.ImageInfo ii
where p.Page_ID = pvp1.Page_ID
and p.Page_ID > @LASTPAGE
and pvp1.Property_Name = 'Page.Background.ImageInfo_ID'
and cast(pvp1.Property_Value as int) = ii.ImageInfo_ID
and (ii.Document_Code like '%SPSLN'
	OR ii.Document_Code like '%X9027'
	OR ii.Document_Code like '%X9010')
and not exists (select 1 from PropertyValuesForPage pvp2
				where p.Page_ID = pvp2.Page_ID
				and pvp2.Property_Name = 'Page.Orientation'
				)

*/
--Remove templates from landscape pages

update p
set p.Parent_Page_ID = null
from Page p, PropertyValuesForPage pg
where p.Page_ID = pg.Page_ID
and p.Page_ID > @LASTPAGE
and pg.Property_Name = 'Page.Orientation'
and pg.Property_Value = 1 
select 'Finished script: 22-EliminateTemplatesFromLandscape' 

--Script 18 :  Adjust Group Box sizes to enclose their children, plus a few extra pixels
select 'Starting script: 23-AdjustGroupBoxSize' 

select @GROUPBOXENUM = 3
select @GAP = 3

--Get all the groupboxes that are children of other groupboxes
declare Cursor_AdjustGroupSize insensitive scroll cursor for
  select g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY, (g1.PositionX + g1.Width) as GroupRightSide, (g1.PositionY + g1.Height) as GroupBottom,
  min(g2.PositionX) as InnerX, min(g2.PositionY) as InnerY, max(g2.PositionX + g2.Width) as InnerRight, max(g2.PositionY + g2.Height) as InnerBottom
  from GraphicObject g1, GraphicObject g2
  where g1.GraphicObjectType_EnumValue = @GROUPBOXENUM
  and isnull(g1.Parent_GraphicObject_ID,0) > 0
  and g1.Page_ID = g2.Page_ID
  and g2.Parent_GraphicObject_ID = g1.GraphicObject_ID
  and g1.Page_ID > @LASTPAGE
  and g1.GraphicObject_ID > @LASTGRAPHIC
  group by g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY, (g1.PositionX + g1.Width), (g1.PositionY + g1.Height)
  having (((g1.PositionX + g1.Width) < max(g2.PositionX + g2.Width)) OR ((g1.PositionY + g1.Height) < max(g2.PositionY + g2.Height))
		OR (g1.PositionX > min(g2.PositionX)) OR (g1.PositionY > min(g2.PositionY)))
  order by g1.Page_ID, g1.GraphicObject_ID

  open    Cursor_AdjustGroupSize 

  fetch from Cursor_AdjustGroupSize 
  into  @PAGEID, @GRAPHICID, @POSITIONX, @POSITIONY, @GROUPRIGHT, @GROUPBOTTOM, @INNERX, @INNERY, @INNERRIGHT, @INNERBOTTOM

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_IdentifyOverlays
	select @NEWX = (@INNERX - @GAP)
    select @NEWY = (@INNERY - @GAP)
	select @NEWWIDTH = (@INNERRIGHT + @GAP - @NEWX)
	select @NEWHEIGHT = (@INNERBOTTOM + @GAP - @NEWY)

	update GraphicObject
	set PositionX = @NEWX, PositionY = @NEWY, Width = @NEWWIDTH, Height = @NEWHEIGHT
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	fetch from Cursor_AdjustGroupSize 
	into  @PAGEID, @GRAPHICID, @POSITIONX, @POSITIONY, @GROUPRIGHT, @GROUPBOTTOM, @INNERX, @INNERY, @INNERRIGHT, @INNERBOTTOM
  end --Cursor_AdjustGroupSize
  close Cursor_AdjustGroupSize
  deallocate Cursor_AdjustGroupSize  

--Get all the groupboxes that aren't children.
declare Cursor_AdjustGroupSize insensitive scroll cursor for
  select g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY, (g1.PositionX + g1.Width) as GroupRightSide, (g1.PositionY + g1.Height) as GroupBottom,
  min(g2.PositionX) as InnerX, min(g2.PositionY) as InnerY, max(g2.PositionX + g2.Width) as InnerRight, max(g2.PositionY + g2.Height) as InnerBottom
  from GraphicObject g1, GraphicObject g2
  where g1.GraphicObjectType_EnumValue = @GROUPBOXENUM
  and isnull(g1.Parent_GraphicObject_ID,0) = 0
  and g1.Page_ID = g2.Page_ID
  and g2.Parent_GraphicObject_ID = g1.GraphicObject_ID
  and g1.Page_ID > @LASTPAGE
  and g1.GraphicObject_ID > @LASTGRAPHIC
  group by g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY, (g1.PositionX + g1.Width), (g1.PositionY + g1.Height)
  having (((g1.PositionX + g1.Width) < max(g2.PositionX + g2.Width)) OR ((g1.PositionY + g1.Height) < max(g2.PositionY + g2.Height))
		OR (g1.PositionX > min(g2.PositionX)) OR (g1.PositionY > min(g2.PositionY)))
  order by g1.Page_ID, g1.GraphicObject_ID

  open    Cursor_AdjustGroupSize 

  fetch from Cursor_AdjustGroupSize 
  into  @PAGEID, @GRAPHICID, @POSITIONX, @POSITIONY, @GROUPRIGHT, @GROUPBOTTOM, @INNERX, @INNERY, @INNERRIGHT, @INNERBOTTOM

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_IdentifyOverlays
	select @NEWX = (@INNERX - @GAP)
    select @NEWY = (@INNERY - @GAP)
	select @NEWWIDTH = (@INNERRIGHT + @GAP - @NEWX)
	select @NEWHEIGHT = (@INNERBOTTOM + @GAP - @NEWY)

	update GraphicObject
	set PositionX = @NEWX, PositionY = @NEWY, Width = @NEWWIDTH, Height = @NEWHEIGHT
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

	fetch from Cursor_AdjustGroupSize 
	into  @PAGEID, @GRAPHICID, @POSITIONX, @POSITIONY, @GROUPRIGHT, @GROUPBOTTOM, @INNERX, @INNERY, @INNERRIGHT, @INNERBOTTOM
  end --Cursor_AdjustGroupSize
  close Cursor_AdjustGroupSize
  deallocate Cursor_AdjustGroupSize  


select 'Finished script: 23-AdjustGroupBoxSize' 


--Script 19 :  Further increases the size of the group boxes to increase the gap a bit more.
select 'Starting script: 24-AdjustGroupBoxGapTo10' 

--Group box gap is currently 3 pixels around its children.  This increases the gap to 10 pixels.

update GraphicObject
set PositionX = (PositionX - 7), PositionY = (PositionY - 7), Width = (Width + 14), Height = (Height + 14)
where GraphicObjectType_EnumValue = 3
and Page_ID > @LASTPAGE
and GraphicObject_ID > @LASTGRAPHIC

-- Now, do it again for groupboxes that are parents of other group boxes, but increase the gap to 15 pixels
update g1
set g1.PositionX = (g1.PositionX - 12), g1.PositionY = (g1.PositionY - 12), g1.Width = (g1.Width + 24), g1.Height = (g1.Height + 24)
from GraphicObject g1, GraphicObject g2
where g1.Page_ID = g2.Page_ID
and g1.GraphicObjectType_EnumValue = 3
and g2.GraphicObjectType_EnumValue = 3
and isnull(g2.Parent_GraphicObject_ID,0) > 0
and g1.GraphicObject_ID = isnull(g2.Parent_GraphicObject_ID,0)
and g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC

select 'Finished script: 24-AdjustGroupBoxGapTo10' 


--Script 20 :  Set AutoFit to FALSE.
select 'Starting script: 25-Set Properties for Grid Print' 

--Set AutoFit to False
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.AutoFit', 0
from GraphicObject g
where g.GraphicObjectType_EnumValue in (1, 7)
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic p
				where p.Page_ID = g.Page_ID
				and p.GraphicObject_ID = g.GraphicObject_ID
				and p.Property_Name = 'Behavior.AutoFit')

select 'Finished script: 25-Set Properties for Grid Print' 

--Script 21 :  sets 'Behavior.PrintOnPage' property to FALSE for out of bounds objects, then moves 
-- them within the page border.

select 'Starting script: 26-SetBarcodeOnlyForOutOfBoundsObjects' 

insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
--Outside horizontal boundary: Portrait (550)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.Visible', 0
from GraphicObject g
where g.PositionX > 2500
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape
and not exists (select 1 from PropertyValuesForGraphic pvg1
				where pvg1.Page_ID = g.Page_ID
				and pvg1.GraphicObject_ID = g.GraphicObject_ID
				and pvg1.Property_Name = 'Behavior.Visible')
UNION
--Outside vertical boundary: Portrait (242)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.Visible', 0
from GraphicObject g
where g.PositionY > 3200
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape
and not exists (select 1 from PropertyValuesForGraphic pvg1
				where pvg1.Page_ID = g.Page_ID
				and pvg1.GraphicObject_ID = g.GraphicObject_ID
				and pvg1.Property_Name = 'Behavior.Visible')
UNION
--Outside horizontal boundary: Landscape (1373)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.Visible', 0
from GraphicObject g, PropertyValuesForPage p
where g.PositionX > 3200
and g.Page_ID = p.Page_ID
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1 -- Landscape
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg1
				where pvg1.Page_ID = g.Page_ID
				and pvg1.GraphicObject_ID = g.GraphicObject_ID
				and pvg1.Property_Name = 'Behavior.Visible')
UNION
--Outside vertical boundary: Landscape (1821)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.Visible', 0
from GraphicObject g, PropertyValuesForPage p
where g.PositionY > 2500
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and g.Page_ID = p.Page_ID
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1 -- Landscape
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg1
				where pvg1.Page_ID = g.Page_ID
				and pvg1.GraphicObject_ID = g.GraphicObject_ID
				and pvg1.Property_Name = 'Behavior.Visible')


--Update PrintOnPage property where it already exists
--Outside horizontal boundary: Portrait (550)
update pvg
set Property_Value = 0
from GraphicObject g, PropertyValuesForGraphic pvg
where g.PositionX > 2500
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Behavior.Visible'
and g.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape

--Outside vertical boundary: Portrait (242)
update pvg
set Property_Value = 0
from GraphicObject g, PropertyValuesForGraphic pvg
where g.PositionY > 3200
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Behavior.Visible'
and g.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape


--Outside horizontal boundary: Landscape (1373)
update pvg
set Property_Value = 0
from GraphicObject g, PropertyValuesForPage p, PropertyValuesForGraphic pvg
where g.PositionX > 3200
and g.Page_ID = p.Page_ID
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1 -- Landscape
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Behavior.Visible'


--Outside vertical boundary: Landscape (1821)
update pvg
set Property_Value = 0
from GraphicObject g, PropertyValuesForPage p, PropertyValuesForGraphic pvg
where g.PositionY > 2500
and g.GraphicObjectType_EnumValue in (1,2,7) --label, textbox, parsed-value field
and g.Page_ID = p.Page_ID
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1 -- Landscape
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Behavior.Visible'




--move out of bounds objects to viewable region

--Outside horizontal boundary: Portrait (550)
update g
set g.PositionX = (2520 - g.Width)
from GraphicObject g
where g.PositionX > 2500
--and g.GraphicObjectType_EnumValue <> 2 --label
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape

--Outside vertical boundary: Portrait (242)
update g
set g.PositionY = (3200 - g.Height)
from GraphicObject g
where g.PositionY > 3200
--and g.GraphicObjectType_EnumValue <> 2 --label
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID not in (select p.Page_ID
			from PropertyValuesForPage p
			where p.Property_Name = 'Page.Orientation'
			and p.Property_Value = 1) -- Landscape

--Outside horizontal boundary: Landscape (1373)
update g
set g.PositionX = (3210 - g.Width)
from GraphicObject g, PropertyValuesForPage p
where g.PositionX > 3200
--and g.GraphicObjectType_EnumValue <> 2 --label
and g.Page_ID = p.Page_ID
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1 -- Landscape
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

--Outside vertical boundary: Landscape (1821)
update g
set g.PositionY = (2500 - g.Height)
from GraphicObject g, PropertyValuesForPage p
where g.PositionY > 2500
--and g.GraphicObjectType_EnumValue <> 2 --label
and g.Page_ID = p.Page_ID
and p.Property_Name = 'Page.Orientation'
and p.Property_Value = 1 -- Landscape
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

select 'Finished script: 26-SetBarcodeOnlyForOutOfBoundsObjects' 

--Script 22 :  Updates the Developer Roles assigned to the print runtime nodes
select 'Starting script: 28-UpdateDeveloperRolesOnRuntimeNodes' 

update nn1
set nn1.DeveloperRole_ID = nn2.DeveloperRole_ID
from NavigationNode nn1, NavigationNode nn2
where nn1.Navigation_ID = @NAVID 
and nn2.Navigation_ID = 1
and nn1.Page_ID = nn2.Page_ID
and nn1.Navigation_Node_ID > @LASTNAVNODE

--update the shortcuts to match the roles of the original nodes
update nn1
set nn1.DeveloperRole_ID = nn2.DeveloperRole_ID
from NavigationNode nn1, NavigationNode nn2
where nn1.Navigation_ID = @NAVID
and nn1.Navigation_ID = nn2.Navigation_ID
and nn1.NodeType_EnumValue = 11
and nn1.ShortCut_Node_ID = nn2.Navigation_Node_ID
and nn1.Navigation_Node_ID > @LASTNAVNODE

--now, loop thru the header nodes and set them to match their children if all of the children are of the same role

--cursor through the list of header nodes, starting with the lowest levels
declare Cursor_HeaderNodes insensitive scroll cursor for
select nn.Navigation_Node_ID, nn.Node_Name, nn.Indent_Level, nn.DeveloperRole_ID 
from NavigationNode nn
where nn.Navigation_ID = @NAVID
and nn.NodeType_EnumValue = 5 --headernode
and nn.Navigation_Node_ID > @LASTNAVNODE
order by nn.Indent_Level desc, nn.Navigation_Node_ID

open    Cursor_HeaderNodes 

  fetch from Cursor_HeaderNodes 
  into  @MYNODE, @NODENAME, @MYLEVEL, @DEVELOPERROLE

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_HeaderNodes

   select @ROLECOUNT = 0

	select @ROLECOUNT = count(distinct DeveloperRole_ID)
	from NavigationNode
	where Parent_Node_ID = @MYNODE
  
    if @ROLECOUNT = 1
	begin 
	   select Top 1 @DEVELOPERROLE = DeveloperRole_ID
	   from NavigationNode
	   where Parent_Node_ID = @MYNODE 

	   update NavigationNode
	   set DeveloperRole_ID = @DEVELOPERROLE
	   where Navigation_Node_ID = @MYNODE 
		
	end

   fetch from Cursor_HeaderNodes 
	into  @MYNODE, @NODENAME, @MYLEVEL, @DEVELOPERROLE
 end --Cursor_HeaderNodes
 close Cursor_HeaderNodes
 deallocate Cursor_HeaderNodes 

select 'Finished script: 28-UpdateDeveloperRolesOnRuntimeNodes' 

--Script 23 :  Updates the obsolete Font properties to the new FontIndex property.
select 'Starting script: 29-UpdateToFontIndex' 
--go through each index 0 thru 15, find matching font entry, and change it to Font index for PVG and PVP tables

select @FONTINDEX = 0
--select @FONTNAME = '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
while (@FONTINDEX < 16)
begin
   select @FONTNAME = (case @FONTINDEX 
						when 0 then '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 1 then '[Font: Name=Courier New, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 2 then '[Font: Name=Courier New, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]' 
						when 3 then '[Font: Name=OCR A MT, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]' 
						when 4 then '[Font: Name=Courier New, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]' 
						when 5 then '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]' 
						when 6 then '[Font: Name=Courier New, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]' 
						when 7 then '[Font: Name=Courier New, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]'
						when 8 then '[Font: Name=Courier New, Size=11, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 9 then '[Font: Name=Courier New, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 10 then '[Font: Name=Courier New, Size=11, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]'
						when 11 then '[Font: Name=Courier New, Size=10, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]'
						when 12 then '[Font: Name=Courier New, Size=9, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Bold]'
						when 13 then '[Font: Name=Courier New, Size=8, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Underline]'
						when 14 then '[Font: Name=OCR A MT, Size=11, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
						when 15 then '[Font: Name=Times New Roman, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False, Style=Regular]'
					end )


insert into PropertyValuesForPage (Page_ID, Property_Name, Property_Value)
select pvp1.Page_ID,  'Appearance.FontIndex', @FONTINDEX
from PropertyValuesForPage pvp1
where pvp1.Property_Name = 'Appearance.Font'
and pvp1.Property_Value = @FONTNAME
and pvp1.Page_ID > @LASTPAGE
and not exists (select 1
				from PropertyValuesForPage pvp2
				where pvp2.Page_ID = pvp1.Page_ID
				and pvp2.Property_Name = 'Appearance.FontIndex')


insert into PropertyValuesForGraphic (GraphicObject_ID, Page_ID, Property_Name, Property_Value)
select pvg1.GraphicObject_ID, pvg1.Page_ID, 'Appearance.FontIndex', @FONTINDEX
from PropertyValuesForGraphic pvg1
where pvg1.Property_Name = 'Appearance.Font'
and pvg1.Property_Value = @FONTNAME
and pvg1.Page_ID > @LASTPAGE
and pvg1.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1
				from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = pvg1.Page_ID
				and pvg2.GraphicObject_ID = pvg1.GraphicObject_ID
				and pvg2.Property_Name = 'Appearance.FontIndex')

--At the end, delete the Appearance.Font records where an Appearance.FontIndex record exists
delete pvp1
from PropertyValuesForPage pvp1, PropertyValuesForPage pvp2
where pvp1.Page_ID = pvp2.Page_ID
and pvp1.Property_Name = 'Appearance.Font'
and pvp2.Property_Name = 'Appearance.FontIndex'

delete pvg1
from PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where pvg1.Page_ID = pvg2.Page_ID
and pvg1.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.Font'
and pvg2.Property_Name = 'Appearance.FontIndex'


select @FONTINDEX = (@FONTINDEX + 1)

end -- while

select 'Finished script: 29-UpdateToFontIndex' 
--Script 24 :  Reset the value of the rightward spacing for groupboxes
select 'Starting script: 30-ResetRightwardGroupSpacing' 

declare Cursor_RightwardGroups insensitive scroll cursor for
select g.GraphicObject_ID, g.Page_ID, cast(pvg.Property_Value as smallint)
from GraphicObject g, PropertyValuesForGraphic pvg
where g.GraphicObjectType_EnumValue = 3
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Group.SpaceBetweenRepetitionRight'
and cast(pvg.Property_Value as smallint) > 0
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

  open    Cursor_RightwardGroups 

  fetch from Cursor_RightwardGroups 
  into  @GRAPHICID, @PAGEID, @TB_SPACING

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_RightwardGroups

	select @FADS_SPACING = 0
	select @FADS_SPACING = (@TB_SPACING/30) + 1

	--select the textbox font index that is most popular in the groupbox
	select @FONT_INDEX = 0
	select @FONT_INDEX = cast(pvg.Property_Value as tinyint)
	from PropertyValuesForGraphic pvg, GraphicObject g
	where g.Page_ID = @PAGEID
	and g.Parent_GraphicObject_ID = @GRAPHICID
	and g.GraphicObjectType_EnumValue in (1,7)
	and pvg.Page_ID = g.Page_ID
	and pvg.GraphicObject_ID = g.GraphicObject_ID
	and pvg.Property_Name = 'Appearance.FontIndex'
	group by pvg.Property_Value
	order by count(pvg.Property_Name) asc

	select @PIXEL_PER_CHAR = 30
	select @PIXEL_PER_CHAR = (case @FONT_INDEX 
								when 1 then 25.5
								when 2 then 17 
								when 4 then 17
								when 7 then 25.5
								when 9 then 25.5
								when 11 then 25.5
								when 12 then 25.5
								when 13 then 17
								else 30
							  end )

	
	select @COMPUTED_SPACING = 0
	select @COMPUTED_SPACING = (@FADS_SPACING * @PIXEL_PER_CHAR)
	select @ROUNDED_SPACING = round(@COMPUTED_SPACING,0)

	--Get width of repeating data
	select @MINX = min(PositionX), @MAXWIDTH = max(PositionX + Width)
	from GraphicObject
	where Page_ID = @PAGEID
	and Parent_GraphicObject_ID = @GRAPHICID
	and GraphicObjectType_EnumValue in (1,7)

	--determine new spacing
	select @GROUPWIDTH = 0
	select @GROUPWIDTH = (@MAXWIDTH - @MINX)

	select @NEWSPACING = 0

	if (@GROUPWIDTH > @ROUNDED_SPACING)
	begin
	  select @NEWSPACING = 0
	end
	else
	begin
	  select @NEWSPACING = (@ROUNDED_SPACING - @GROUPWIDTH)
	end
	
	if isnull(@NEWSPACING,0) > 0  --TFS 79973
	begin 
		update PropertyValuesForGraphic
		set Property_Value = @NEWSPACING
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID
		and Property_Name = 'Group.SpaceBetweenRepetitionRight'
	end

fetch from Cursor_RightwardGroups 
	into  @GRAPHICID, @PAGEID, @TB_SPACING
  end --Cursor_RightwardGroups
  close Cursor_RightwardGroups
  deallocate Cursor_RightwardGroups  

select 'Finished script: 30-ResetRightwardGroupSpacing' 

--Script 25 :  Reset the downward spacing for groupboxes
select 'Starting script: 31-ResetDownwardGroupSpacing' 

declare Cursor_DownwardGroups insensitive scroll cursor for
select g.GraphicObject_ID, g.Page_ID, cast(pvg.Property_Value as smallint)
from GraphicObject g, PropertyValuesForGraphic pvg
where g.GraphicObjectType_EnumValue = 3
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Group.SpaceBetweenRepetitionDown'
and cast(pvg.Property_Value as smallint) > 0
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

  open    Cursor_DownwardGroups 

  fetch from Cursor_DownwardGroups 
  into  @GRAPHICID, @PAGEID, @TB_SPACING

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_DownwardGroups
	
	select @FADS_SPACING = 0
	select @FADS_SPACING = (@TB_SPACING + 50)
	
	--Get width of repeating data
	select @MINY = min(PositionY), @MAXHEIGHT = max(PositionY + Height)
	from GraphicObject
	where Page_ID = @PAGEID
	and Parent_GraphicObject_ID = @GRAPHICID
	and GraphicObjectType_EnumValue in (1,7)

	--determine new spacing
	select @GROUPHEIGHT = 0
	select @GROUPHEIGHT = (@MAXHEIGHT - @MINY)

	select @NEWSPACING = 0

	if (@GROUPHEIGHT > @FADS_SPACING)
	begin
	  select @NEWSPACING = 0
	end
	else
	begin
	  select @NEWSPACING = (@FADS_SPACING - @GROUPHEIGHT)
	end

	if isnull(@NEWSPACING,0) > 0   --TFS 79973
	begin
		update PropertyValuesForGraphic
		set Property_Value = @NEWSPACING
		where Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICID
		and Property_Name = 'Group.SpaceBetweenRepetitionDown'
	end

fetch from Cursor_DownwardGroups 
	into  @GRAPHICID, @PAGEID, @TB_SPACING
  end --Cursor_DownwardGroups
  close Cursor_DownwardGroups
  deallocate Cursor_DownwardGroups  

select 'Finished script: 31-ResetDownwardGroupSpacing' 


--Script 26 :  Sets the GroupOverflowOption based on whether there is the group flows to an attachment.
select 'Starting script: 32-SetGroupOverflowOptionOnForms' 

create table #AttachmentGroups ( Page_ID int,
								GraphicObject_ID int,
								FADSField int
								)

insert into #AttachmentGroups (Page_ID, GraphicObject_ID, FADSField)
select g1.Page_ID, g1.GraphicObject_ID, cast(pvg1.Property_Value as int)
from GraphicObject g1, Page p1, PropertyValuesForGraphic pvg1
where g1.GraphicObjectType_EnumValue = 3
and g1.Page_ID = p1.Page_ID
and p1.PageType_EnumValue = 1
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and pvg1.Property_Name = 'SourceField.FADSFieldID'
and g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC

declare Cursor_OverflowOption insensitive scroll cursor for
select g.GraphicObject_ID, g.Page_ID, isnull(cast(pvg.Property_Value as int),0), isnull(cast(pvp.Property_Value as int),0)
from GraphicObject g, Page p, PropertyValuesForGraphic pvg, PropertyValuesForPage pvp
where g.GraphicObjectType_EnumValue = 3
and g.Page_ID = p.Page_ID
and p.PageType_EnumValue = 0
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'SourceField.FADSFieldID'
and p.Page_ID = pvp.Page_ID
and pvp.Property_Name = 'Page.Background.ImageInfo_ID'
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

order by g.Page_ID, g.GraphicObject_ID

  open    Cursor_OverflowOption 

  fetch from Cursor_OverflowOption 
  into  @GRAPHICID, @PAGEID, @MYGROUPFIELD, @MYFORMIMAGE

  while (@@FETCH_STATUS <> -1)
  begin --Cursor_OverflowOption

	if exists (select 1 
				from #AttachmentGroups tag
				where tag.FADSField = @MYGROUPFIELD )
	begin  --group has attachment
		if exists (select 1 from PropertyValuesForGraphic
					where Page_ID = @PAGEID
					and GraphicObject_ID = @GRAPHICID
					and Property_Name = 'Group.Overflow')
		begin -- update existing record
			update PropertyValuesForGraphic
			set Property_Value = 1 --'OverflowDataOnAttachment'
			where Page_ID = @PAGEID
			and GraphicObject_ID = @GRAPHICID
			and Property_Name = 'Group.Overflow'
		end
		else
		begin --insert new record
			insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
			values (@PAGEID, @GRAPHICID, 'Group.Overflow', 1)
		end
	end
	else
	begin  --group is not on attachment.  
		if exists (select 1 from PropertyValuesForGraphic
					where Page_ID = @PAGEID
					and GraphicObject_ID = @GRAPHICID
					and Property_Name = 'Group.Overflow')
		begin -- update existing record
			update PropertyValuesForGraphic
			set Property_Value = 2 --'OverflowDataOnSamePage'
			where Page_ID = @PAGEID
			and GraphicObject_ID = @GRAPHICID
			and Property_Name = 'Group.Overflow'
		end
		else
		begin --insert new record
			insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
			values (@PAGEID, @GRAPHICID, 'Group.Overflow', 2)
		end
			
	end  --group is not on attachment. 

	fetch from Cursor_OverflowOption 
	into  @GRAPHICID, @PAGEID, @MYGROUPFIELD, @MYFORMIMAGE
  end --Cursor_OverflowOption
  close Cursor_OverflowOption
  deallocate Cursor_OverflowOption  


drop table #AttachmentGroups

select 'Finished script: 32-SetGroupOverflowOptionOnForms' 

--Script 27 :  Remove any labels hardcoded as "Statement"
select 'Starting script: Delete Statement Label' 

declare STATEMENTLABEL cursor for
select g.Page_ID, g.GraphicObject_ID
from GraphicObject g, PropertyValuesForGraphic pvg
where g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObjectType_EnumValue = 2
and pvg.Property_Name = 'Appearance.Text'
and cast(pvg.Property_Value as varchar(15)) like 'Statement%'
and PositionY in (0, 50, 100, 150, 200, 250, 2350, 2400, 2450, 2500, 3100)
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC

OPEN STATEMENTLABEL

FETCH NEXT from STATEMENTLABEL into @PAGEID, @GRAPHICID

WHILE @@FETCH_STATUS = 0
BEGIN
   --delete PropertyValueForGraphic entries
	delete from PropertyValuesForGraphic
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

   --delete FADSContraintDependency entries 
	delete fcd
	from FADSConstraintDependency fcd, CodeScriptAssignment csa
	where csa.Dependent_Page_ID = @PAGEID
	and csa.Dependent_ID = @GRAPHICID
	and fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID

   --delete CodeScriptAssignments entries
	delete from CodeScriptAssignment
	where Dependent_Page_ID = @PAGEID
	and Dependent_ID = @GRAPHICID

   --delete GraphicObject entries
	delete from GraphicObject
	where Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICID

   FETCH NEXT from STATEMENTLABEL into @PAGEID, @GRAPHICID

END -- CURSOR STATEMENTLABEL

close STATEMENTLABEL
deallocate STATEMENTLABEL

select 'Finished script: Delete Statement Label' 

select 'Starting script: Hide Commas for Integers' 
--Set Integer textboxes to not include commas on output (TFS #22126)
update pvg
set pvg.Property_Value = 1
from PropertyValuesForGraphic pvg, GraphicObject g
where g.GraphicObjectType_EnumValue in (1,7) -- textbox, parsed-value field
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.DataType_EnumValue = 1 --integer
and pvg.Property_Name = 'Behavior.IncludeCommasWhenOutputing'

--Set Integer textboxes to not include commas on output (TFS #22126) where no property value currently exists
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select g.Page_ID, g.GraphicObject_ID, 'Behavior.IncludeCommasWhenOutputing', 1
from GraphicObject g
where g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObjectType_EnumValue in (1,7) -- textbox, parsed-value field
and g.DataType_EnumValue = 1 --integer
and not exists (select 1 from PropertyValuesForGraphic pvg
				where g.Page_ID = pvg.Page_ID
				and g.GraphicObject_ID = pvg.GraphicObject_ID
				and pvg.Property_Name = 'Behavior.IncludeCommasWhenOutputing')

select 'Finished script: Hide Commas for Integers' 

select 'Starting script: Update Date Format for short fields'
--Update the Date Format to MM\DD when the field length is set to 5 characters  (TFS 22548)

insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value) 
select g.Page_ID, g.GraphicObject_ID, 'Behavior.DateFormat', 2
from GraphicObject g, PropertyValuesForGraphic pvg
where g.DataType_EnumValue = 3
and g.GraphicObjectType_EnumValue = 1
and g.Width = 150
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Appearance.FontIndex'
and pvg.Property_Value in (5,6) --12pt font, non-default
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g.Page_ID
				and pvg2.GraphicObject_ID = g.GraphicObject_ID
				and pvg2.Property_Name = 'Behavior.DateFormat')
UNION
select g.Page_ID, g.GraphicObject_ID, 'Behavior.DateFormat', 2
from GraphicObject g
where g.DataType_EnumValue = 3
and g.GraphicObjectType_EnumValue = 1
and g.Width = 150
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForGraphic pvg
				where g.Page_ID = pvg.Page_ID
				and g.GraphicObject_ID = pvg.GraphicObject_ID
				and pvg.Property_Name = 'Appearance.FontIndex')--default 12pt font
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g.Page_ID
				and pvg2.GraphicObject_ID = g.GraphicObject_ID
				and pvg2.Property_Name = 'Behavior.DateFormat')
UNION
select g.Page_ID, g.GraphicObject_ID, 'Behavior.DateFormat', 2
from GraphicObject g, PropertyValuesForGraphic pvg
where g.DataType_EnumValue = 3
and g.GraphicObjectType_EnumValue = 1
and g.Width = 128
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Appearance.FontIndex'
and pvg.Property_Value in (1,7,11) --10pt font
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g.Page_ID
				and pvg2.GraphicObject_ID = g.GraphicObject_ID
				and pvg2.Property_Name = 'Behavior.DateFormat')
UNION
select g.Page_ID, g.GraphicObject_ID, 'Behavior.DateFormat', 2
from GraphicObject g, PropertyValuesForGraphic pvg
where g.DataType_EnumValue = 3
and g.GraphicObjectType_EnumValue = 1
and g.Width = 88
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and g.Page_ID = pvg.Page_ID
and g.GraphicObject_ID = pvg.GraphicObject_ID
and pvg.Property_Name = 'Appearance.FontIndex'
and pvg.Property_Value in (2,4,13) --8pt font
and not exists (select 1 from PropertyValuesForGraphic pvg2
				where pvg2.Page_ID = g.Page_ID
				and pvg2.GraphicObject_ID = g.GraphicObject_ID
				and pvg2.Property_Name = 'Behavior.DateFormat')
select 'Finished script: Update Date Format for short fields'
select 'Started script: Clean up navigation tree'
/*
Delete Header Nodes that have:
1) Only one child node
2) Have no non-default Properties
3) Are not original nodes for shortcuts
*/
create table #NODES1 (NavigationNodeID int,
					 IndentLevel tinyint)

/*
select @NAVID = Navigation_ID
from Navigation
where Product_Name = @THISPRODUCT
and NavigationType_EnumValue = 1
*/
declare Cursor_HeaderNodes insensitive scroll cursor for
  select nn1.Navigation_Node_ID, nn1.Indent_Level--, count(nn3.Navigation_Node_ID)
	from NavigationNode nn1, NavigationNode nn3 
	where nn1.NodeType_EnumValue = 5 --HeaderNode
	and nn1.Navigation_ID = @NAVID
	and nn1.Indent_Level > 0
    and nn1.Navigation_Node_ID Not in (select distinct pvn.Navigation_Node_ID
										from PropertyValuesForNode pvn, NavigationNode nn2
										where nn2.Navigation_ID = @NAVID
										and nn2.NodeType_EnumValue = 5
										and nn2.Indent_Level > 0
										and pvn.Navigation_Node_ID = nn2.Navigation_Node_ID
										and pvn.Property_Name <> 'Page.FADSAML')
	and nn1.Navigation_Node_ID Not in (select distinct nn4.ShortCut_Node_ID
										from NavigationNode nn4
										where nn4.Navigation_ID = @NAVID
										and isnull(nn4.ShortCut_Node_ID,0) > 0)
	and nn1.Navigation_Node_ID = nn3.Parent_Node_ID
	group by nn1.Navigation_Node_ID, nn1.Indent_Level
	having count(nn3.Navigation_Node_ID) = 1
	order by nn1.Indent_Level desc, nn1.Navigation_Node_ID asc

   open Cursor_HeaderNodes
   fetch from Cursor_HeaderNodes
   into  @MYNODE, @PROCESSLEVEL

   while (@@FETCH_STATUS <> -1)
   begin

	--reassign this header's child to it's parent
	select @PARENTNODE = Parent_Node_ID, @DISPLAYORDER = DisplayOrder
	from NavigationNode
	where Navigation_ID = @NAVID
	and Navigation_Node_ID = @MYNODE

--locate all the descendant nodes of this nav node, and reset their Indent_Level
	insert into #NODES1 (NavigationNodeID, IndentLevel)
	select Navigation_Node_ID, Indent_Level
	from NavigationNode
	where Navigation_ID = @NAVID
	and Parent_Node_ID = @MYNODE

	select @CHILDLEVEL = (@PROCESSLEVEL + 1)
	select @COUNT = 1
	while (@COUNT > 0)
	   begin
		insert into #NODES1 (NavigationNodeID, IndentLevel)
		select nn.Navigation_Node_ID, nn.Indent_Level
		from NavigationNode nn, #NODES1 n1
		where nn.Navigation_ID = @NAVID
		and nn.Parent_Node_ID = n1.NavigationNodeID
		and n1.IndentLevel = @CHILDLEVEL

		select @CHILDLEVEL = (@CHILDLEVEL + 1)

		select @COUNT = count(nn.Navigation_Node_ID)
	    from NavigationNode nn, #NODES1 n1
		where nn.Navigation_ID = @NAVID
		and nn.Parent_Node_ID = n1.NavigationNodeID
		and n1.IndentLevel = @CHILDLEVEL

	   end --while

--Now reset the parent node
	update NavigationNode
	set Parent_Node_ID = @PARENTNODE, DisplayOrder = @DISPLAYORDER
	where Navigation_ID = @NAVID
	and Parent_Node_ID = @MYNODE
	
	--reset the descendants Indent_Level
	update nn
	set Indent_Level = (Indent_Level - 1)
	from NavigationNode nn, #NODES1 n1
	where nn.Navigation_ID = @NAVID
	and nn.Navigation_Node_ID = n1.NavigationNodeID

	--delete from PropertyValuesForNode
	delete from PropertyValuesForNode
	where Navigation_Node_ID = @MYNODE

	--delete this header node
	delete from NavigationNode
	where Navigation_ID = @NAVID
	and Navigation_Node_ID = @MYNODE

	truncate table #NODES1

	fetch from Cursor_HeaderNodes 
	into  @MYNODE, @PROCESSLEVEL
   end --Cursor_HeaderNodes
   close Cursor_HeaderNodes
   deallocate Cursor_HeaderNodes 


drop table #NODES1

select 'Finished script: Clean up navigation tree'


select 'Started script: move Attachment Section Heading labels out of groupboxes'
--TFS 21965
update g
set g.Parent_GraphicObject_ID = NULL
from Page p, GraphicObject g, PropertyValuesForGraphic pvg
where p.Page_ID = g.Page_ID
and p.Page_ID = pvg.Page_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObjectType_EnumValue = 2
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 7
and isnull(g.Parent_GraphicObject_ID,0) > 0

select 'Finished script: move Attachment Section Heading labels out of groupboxes'

select 'Starting script: Delete Underline Label'
--TFS Scenario 23681.
--This will look for underline labels converted from FADS.  This will then modify the label above the underline by setting
--the underscore property.  We will then delete the underline label.



declare Cursor_DoubleUnderline insensitive scroll cursor for

select p.Page_ID, g1.GraphicObject_ID, g2.GraphicObject_ID, g1.Width, g2.Width
from Page p, GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where p.Page_ID = g1.Page_ID
and p.Page_ID > @LASTPAGE
and g1.Page_ID = g2.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g2.Page_ID = pvg2.Page_ID
and g1.GraphicObject_ID > @LASTGRAPHIC
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g2.GraphicObject_ID = pvg2.GraphicObject_ID
and g1.GraphicObjectType_EnumValue = 2
and g2.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.Text'
and pvg2.Property_Name = 'Appearance.Text'
and cast(pvg2.Property_Value as varchar(50)) like '==%'
and g1.PositionX = g2.PositionX
and g1.PositionY = (g2.PositionY - 50)
order by p.Page_ID

open Cursor_DoubleUnderline
   fetch from Cursor_DoubleUnderline
   into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH

   while (@@FETCH_STATUS <> -1)
   begin
 --set the width of the label to match the width of the underline
     if (@OLDWIDTH < @NEWWIDTH)
     begin
	    update GraphicObject
	    set Width = @NEWWIDTH
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
     end
--set the height of the label to allow for the double underline
	 update GraphicObject
	    set Height = 55
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
 --set the underscore property to double
	  if not exists (select 1 from PropertyValuesForGraphic
					 where Page_ID = @PAGEID
					 and GraphicObject_ID = @LABELID
					 and Property_Name = 'Appearance.UnderScore')
      begin
		 insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
		 values(@PAGEID, @LABELID, 'Appearance.UnderScore', 2)
      end
      else
	  begin
		update PropertyValuesForGraphic
		set Property_Value = 2
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
		and Property_Name = 'Appearance.UnderScore'

      end
 --delete the underline label
	--delete any FADSConstraintDependency 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
		and csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @UNDERLINEID

	--delete any CodeScriptAssignment
	    delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @UNDERLINEID

	--delete any PropertyValuesForGraphic
	    delete from PropertyValuesForGraphic
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

	--delete the graphic object
	    delete from GraphicObject
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

fetch from Cursor_DoubleUnderline 
	into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH
   end --Cursor_DoubleUnderline
   close Cursor_DoubleUnderline
   deallocate Cursor_DoubleUnderline 



declare Cursor_SingleUnderline insensitive scroll cursor for

select p.Page_ID, g1.GraphicObject_ID, g2.GraphicObject_ID, g1.Width, g2.Width
from Page p, GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where p.Page_ID = g1.Page_ID
and p.Page_ID > @LASTPAGE
and g1.Page_ID = g2.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g2.Page_ID = pvg2.Page_ID
and g1.GraphicObject_ID > @LASTGRAPHIC
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g2.GraphicObject_ID = pvg2.GraphicObject_ID
and g1.GraphicObjectType_EnumValue = 2
and g2.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.Text'
and pvg2.Property_Name = 'Appearance.Text'
and cast(pvg2.Property_Value as varchar(50)) like '--%'
and g1.PositionX = g2.PositionX
and g1.PositionY = (g2.PositionY - 50)
order by p.Page_ID

open Cursor_SingleUnderline
   fetch from Cursor_SingleUnderline
   into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH

   while (@@FETCH_STATUS <> -1)
   begin
 --set the width of the label to match the width of the underline
     if (@OLDWIDTH < @NEWWIDTH)
     begin
	    update GraphicObject
	    set Width = @NEWWIDTH
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
     end
 --set the underscore property to single
	  if not exists (select 1 from PropertyValuesForGraphic
					 where Page_ID = @PAGEID
					 and GraphicObject_ID = @LABELID
					 and Property_Name = 'Appearance.UnderScore')
      begin
		 insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
		 values(@PAGEID, @LABELID, 'Appearance.UnderScore', 1)
      end
      else
	  begin
		update PropertyValuesForGraphic
		set Property_Value = 1
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
		and Property_Name = 'Appearance.UnderScore'

      end
 --delete the underline label
	--delete any FADSConstraintDependency 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
		and csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @UNDERLINEID

	--delete any CodeScriptAssignment
	    delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @UNDERLINEID

	--delete any PropertyValuesForGraphic
	    delete from PropertyValuesForGraphic
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

	--delete the graphic object
	    delete from GraphicObject
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

fetch from Cursor_SingleUnderline 
	into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH
   end --Cursor_SingleUnderline
   close Cursor_SingleUnderline
   deallocate Cursor_SingleUnderline 

--Now, try to find those labels and underlines that do not match precisely

declare Cursor_DoubleUnderline insensitive scroll cursor for

select p.Page_ID, g1.GraphicObject_ID, g2.GraphicObject_ID, g1.Width, g2.Width
from Page p, GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where p.Page_ID = g1.Page_ID
and p.Page_ID > @LASTPAGE
and g1.Page_ID = g2.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g2.Page_ID = pvg2.Page_ID
and g1.GraphicObject_ID > @LASTGRAPHIC
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g2.GraphicObject_ID = pvg2.GraphicObject_ID
and g1.GraphicObjectType_EnumValue = 2
and g2.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.Text'
and pvg2.Property_Name = 'Appearance.Text'
and cast(pvg2.Property_Value as varchar(50)) like '==%'
and g1.PositionX <> g2.PositionX
and g1.PositionY = (g2.PositionY - 50)
and (g1.PositionX + g1.Width) > g2.PositionX
and (g1.PositionX + g1.Width) <= (g2.PositionX + g2.Width)
and not exists (select 1 from PropertyValuesForGraphic pvg3
				where pvg3.Page_ID = g1.Page_ID
				and pvg3.GraphicObject_ID = g1.GraphicObject_ID
				and pvg3.Property_Name = 'Appearance.UnderScore')
order by p.Page_ID

open Cursor_DoubleUnderline
   fetch from Cursor_DoubleUnderline
   into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH

   while (@@FETCH_STATUS <> -1)
   begin
 --set the width of the label to match the width of the underline
     if (@OLDWIDTH < @NEWWIDTH)
     begin
	    update GraphicObject
	    set Width = @NEWWIDTH
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
     end
--set the height of the label to allow for the double underline
	 update GraphicObject
	    set Height = 55
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
 --set the underscore property to double
	  if not exists (select 1 from PropertyValuesForGraphic
					 where Page_ID = @PAGEID
					 and GraphicObject_ID = @LABELID
					 and Property_Name = 'Appearance.UnderScore')
      begin
		 insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
		 values(@PAGEID, @LABELID, 'Appearance.UnderScore', 2)
      end
      else
	  begin
		update PropertyValuesForGraphic
		set Property_Value = 2
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
		and Property_Name = 'Appearance.UnderScore'

      end
 --delete the underline label
	--delete any FADSConstraintDependency 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
		and csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @UNDERLINEID

	--delete any CodeScriptAssignment
	    delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @UNDERLINEID

	--delete any PropertyValuesForGraphic
	    delete from PropertyValuesForGraphic
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

	--delete the graphic object
	    delete from GraphicObject
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

fetch from Cursor_DoubleUnderline 
	into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH
   end --Cursor_DoubleUnderline
   close Cursor_DoubleUnderline
   deallocate Cursor_DoubleUnderline 



declare Cursor_SingleUnderline insensitive scroll cursor for

select p.Page_ID, g1.GraphicObject_ID, g2.GraphicObject_ID, g1.Width, g2.Width
from Page p, GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where p.Page_ID = g1.Page_ID
and p.Page_ID > @LASTPAGE
and g1.Page_ID = g2.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g2.Page_ID = pvg2.Page_ID
and g1.GraphicObject_ID > @LASTGRAPHIC
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g2.GraphicObject_ID = pvg2.GraphicObject_ID
and g1.GraphicObjectType_EnumValue = 2
and g2.GraphicObjectType_EnumValue = 2
and pvg1.Property_Name = 'Appearance.Text'
and pvg2.Property_Name = 'Appearance.Text'
and cast(pvg2.Property_Value as varchar(50)) like '--%'
and g1.PositionX <> g2.PositionX
and g1.PositionY = (g2.PositionY - 50)
and (g1.PositionX + g1.Width) > g2.PositionX
and (g1.PositionX + g1.Width) <= (g2.PositionX + g2.Width)
and not exists (select 1 from PropertyValuesForGraphic pvg3
				where pvg3.Page_ID = g1.Page_ID
				and pvg3.GraphicObject_ID = g1.GraphicObject_ID
				and pvg3.Property_Name = 'Appearance.UnderScore')
order by p.Page_ID

open Cursor_SingleUnderline
   fetch from Cursor_SingleUnderline
   into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH

   while (@@FETCH_STATUS <> -1)
   begin
 --set the width of the label to match the width of the underline
     if (@OLDWIDTH < @NEWWIDTH)
     begin
	    update GraphicObject
	    set Width = @NEWWIDTH
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
     end
 --set the underscore property to single
	  if not exists (select 1 from PropertyValuesForGraphic
					 where Page_ID = @PAGEID
					 and GraphicObject_ID = @LABELID
					 and Property_Name = 'Appearance.UnderScore')
      begin
		 insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
		 values(@PAGEID, @LABELID, 'Appearance.UnderScore', 1)
      end
      else
	  begin
		update PropertyValuesForGraphic
		set Property_Value = 1
		where Page_ID = @PAGEID
		and GraphicObject_ID = @LABELID
		and Property_Name = 'Appearance.UnderScore'

      end
 --delete the underline label
	--delete any FADSConstraintDependency 
		delete fcd
		from FADSConstraintDependency fcd, CodeScriptAssignment csa
		where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
		and csa.Dependent_Page_ID = @PAGEID
		and csa.Dependent_ID = @UNDERLINEID

	--delete any CodeScriptAssignment
	    delete from CodeScriptAssignment
		where Dependent_Page_ID = @PAGEID
		and Dependent_ID = @UNDERLINEID

	--delete any PropertyValuesForGraphic
	    delete from PropertyValuesForGraphic
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

	--delete the graphic object
	    delete from GraphicObject
		where Page_ID = @PAGEID
		and GraphicObject_ID = @UNDERLINEID

fetch from Cursor_SingleUnderline 
	into  @PAGEID, @LABELID, @UNDERLINEID, @OLDWIDTH, @NEWWIDTH
   end --Cursor_SingleUnderline
   close Cursor_SingleUnderline
   deallocate Cursor_SingleUnderline 

select 'Finished script: Delete Underline Label'

select 'Started script: Change contiguous hyphens to underline'

--TFS 68944  change contiguous hyphens to underline
update PropertyValuesForGraphic
set Property_Value = REPLACE(cast(Property_Value as nvarchar(50)), '-','_')
where Property_Name = 'Appearance.Text'
and cast(Property_Value as nvarchar(50)) like '---%'

select 'Finished script: Change contiguous hyphens to underline'

select 'Started script: Update STMT labels'
--TFS Task 25083 to replace @STMT labels with Attachment Page text
create table #SPECIALLABELS (Page_ID int,
							GraphicObject_ID int,
							NewX smallint,
							NewWidth smallint)

insert into #SPECIALLABELS (Page_ID, GraphicObject_ID, NewX, NewWidth)

--Populate temp table with 12pt font labels
select g.Page_ID, g.GraphicObject_ID, (g.PositionX - 429), (g.Width + 429)  
from GraphicObject g, PropertyValuesForGraphic pvg2
where g.Page_ID > @LASTPAGE
and g.Page_ID = pvg2.Page_ID
and g.GraphicObjectType_EnumValue = 2 --label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg2.Property_Name = 'Appearance.Text'
and pvg2.Property_Value = '@STMT'
and not exists (select 1
				from PropertyValuesForGraphic pvg1
				where pvg1.Page_ID = g.Page_ID
				and pvg1.GraphicObject_ID = g.GraphicObject_ID
				and pvg1.Property_Name = 'Appearance.FontIndex')
UNION
--Populate temp table with 10pt font labels
select g.Page_ID, g.GraphicObject_ID, (g.PositionX - 367), (g.Width + 367) 
from GraphicObject g, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where g.Page_ID > @LASTPAGE
and g.Page_ID = pvg1.Page_ID
and g.Page_ID = pvg2.Page_ID
and g.GraphicObjectType_EnumValue = 2 --label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg1.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.FontIndex'
and pvg1.Property_Value = 1
and pvg2.Property_Name = 'Appearance.Text'
and pvg2.Property_Value = '@STMT'
UNION
--Populate temp table with 8pt font labels
select g.Page_ID, g.GraphicObject_ID, (g.PositionX - 286), (g.Width + 286) 
from GraphicObject g, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2
where g.Page_ID > @LASTPAGE
and g.Page_ID = pvg1.Page_ID
and g.Page_ID = pvg2.Page_ID
and g.GraphicObjectType_EnumValue = 2 --label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg1.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and pvg1.Property_Name = 'Appearance.FontIndex'
and pvg1.Property_Value = 2
and pvg2.Property_Name = 'Appearance.Text'
and pvg2.Property_Value = '@STMT'


--move the label and adjust its width
update g1
set g1.PositionX = sl.NewX, g1.Width= sl.NewWidth
from GraphicObject g1, #SPECIALLABELS sl
where g1.Page_ID = sl.Page_ID
and g1.GraphicObject_ID = sl.GraphicObject_ID


--update the label text value
update pvg
set pvg.Property_Value = 'Attachment(s) x,y,z' 
from PropertyValuesForGraphic pvg, #SPECIALLABELS sl
where pvg.Page_ID = sl.Page_ID
and pvg.GraphicObject_ID = sl.GraphicObject_ID
and pvg.Property_Name = 'Appearance.Text'


drop table #SPECIALLABELS
select 'Finished script: Update STMT labels'

select 'Started script: Update footer labels'
--TFS Tasks 25314,25313 :  remove the "PrintIfDataOnRow" property value for "V" labels
delete pvg2
from GraphicObject g, PropertyValuesForGraphic pvg, PropertyValuesForGraphic pvg2
where g.GraphicObjectType_EnumValue = 2 -- label
and g.PositionY in (2450, 3200)  --footer region for landscape and portrait
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and g.Page_ID = pvg2.Page_ID
and pvg.Property_Name = 'Appearance.Text'
and pvg.Property_Value = 'V'
and pvg2.Property_Name = 'Constraints.EssentialData'
and pvg2.Property_Value = 1

--TFS Task 25315 : widen the @DATE and @TIME labels
--10pt font date (10 characters)
update g
set g.Width = 255
from GraphicObject g, PropertyValuesForGraphic pvg, PropertyValuesForGraphic pvg2
where g.GraphicObjectType_EnumValue = 2 -- label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and g.Page_ID = pvg2.Page_ID
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 2  --@DATE
and pvg2.Property_Name = 'Appearance.FontIndex'
and pvg2.Property_Value = 1--10pt

--10pt font time (12 characters)
update g
set g.Width = 306
from GraphicObject g, PropertyValuesForGraphic pvg, PropertyValuesForGraphic pvg2
where g.GraphicObjectType_EnumValue = 2 -- label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and g.Page_ID = pvg2.Page_ID
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 1  --@DATE
and pvg2.Property_Name = 'Appearance.FontIndex'
and pvg2.Property_Value = 1 --10pt

--8pt font date (10 characters)
update g
set g.Width = 170
from GraphicObject g, PropertyValuesForGraphic pvg, PropertyValuesForGraphic pvg2
where g.GraphicObjectType_EnumValue = 2 -- label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and g.Page_ID = pvg2.Page_ID
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 2  --@DATE
and pvg2.Property_Name = 'Appearance.FontIndex'
and pvg2.Property_Value = 2  --8pt

--8pt font time (12 characters)
update g
set g.Width = 204
from GraphicObject g, PropertyValuesForGraphic pvg, PropertyValuesForGraphic pvg2
where g.GraphicObjectType_EnumValue = 2 -- label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.GraphicObject_ID = pvg2.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and g.Page_ID = pvg2.Page_ID
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 1  --@DATE
and pvg2.Property_Name = 'Appearance.FontIndex'
and pvg2.Property_Value = 2 --8pt

--12pt font date (10 characters)
update g
set g.Width = 300
from GraphicObject g, PropertyValuesForGraphic pvg 
where g.GraphicObjectType_EnumValue = 2 -- label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 2  --@DATE
and not exists (select 1
				from PropertyValuesForGraphic pvg2
				where g.GraphicObject_ID = pvg2.GraphicObject_ID
				and g.Page_ID = pvg2.Page_ID
				and pvg2.Property_Name = 'Appearance.FontIndex'
				and Property_Value in (1,2))

--12pt font time (12 characters)
update g
set g.Width = 360
from GraphicObject g, PropertyValuesForGraphic pvg 
where g.GraphicObjectType_EnumValue = 2 -- label
and g.GraphicObject_ID > @LASTGRAPHIC
and g.GraphicObject_ID = pvg.GraphicObject_ID
and g.Page_ID > @LASTPAGE
and g.Page_ID = pvg.Page_ID
and pvg.Property_Name = 'Appearance.SpecialText'
and pvg.Property_Value = 1  --@TIME
and not exists (select 1
				from PropertyValuesForGraphic pvg2
				where g.GraphicObject_ID = pvg2.GraphicObject_ID
				and g.Page_ID = pvg2.Page_ID
				and pvg2.Property_Name = 'Appearance.FontIndex'
				and Property_Value in (1,2))

select 'Finished script: Update footer labels'

--TFS 26291
select 'Started script:  Remove PrintIfDataOnRow for labels without textboxes'
delete pvg
from GraphicObject g1, Page p, PropertyValuesForGraphic pvg
where g1.Page_ID > @LASTPAGE
and g1.GraphicObject_ID > @LASTGRAPHIC
and g1.Page_ID = p.Page_ID
and pvg.Page_ID = g1.Page_ID
and g1.GraphicObjectType_EnumValue = 2 --Label
and g1.PositionY < 3200
and isnull(g1.Parent_GraphicObject_ID,0) = 0
and pvg.GraphicObject_ID = g1.GraphicObject_ID 
and pvg.Property_Name = 'Constraints.EssentialData'  
and pvg.Property_Value = 1  --PrintIfDataOnRow
and not exists (select 1 from GraphicObject g2
				where g1.Page_ID = g2.Page_ID
				and g2.GraphicObjectType_EnumValue = 1 --Textbox
				and g1.PositionY = g2.PositionY
				and isnull(g2.Parent_GraphicObject_ID,0) = 0
			    and (g1.PositionX + g1.Width) <= g2.PositionX)
select 'Finished script:  Remove PrintIfDataOnRow for labels without textboxes'

--reset PrintOnPage value for RelationalPages
select 'Started script:  reset PrintOnPage value for RelationalPages'
delete pvg 
from PropertyValuesForPage pvp, PropertyValuesForGraphic pvg
where pvp.Property_Name = 'Behavior.Relational'
and pvp.Property_Value = 1
and pvp.Page_ID > @LASTPAGE
and pvp.Page_ID = pvg.Page_ID
and pvg.Property_Name = 'Behavior.PrintOnPage'
and pvg.Property_Value = 0
and pvg.GraphicObject_ID > @LASTGRAPHIC

delete pvg
from PropertyValuesForGraphic pvg, Page p
where p.PageType_EnumValue in (1,9) --Attachment, Continuation
and p.Page_ID > @LASTPAGE
and p.Page_ID = pvg.Page_ID
and pvg.Property_Name = 'Behavior.PrintOnPage'
and pvg.Property_Value = 0
and pvg.GraphicObject_ID > @LASTGRAPHIC
and not exists (select 1 from PropertyValuesForPage pvp
				where pvp.Page_ID = p.Page_ID
				and pvp.Property_Name = 'Behavior.Relational'
				and pvp.Property_Value = 1)

select 'Finished script:  reset PrintOnPage value for RelationalPages'

--reset children of page nodes to be siblings
select 'Started script:  reset children of page nodes to be siblings'

create table #SHIFTNODES (Navigation_Node_ID int, Parent_Node_ID int, DisplayOrder nvarchar(50), Indent_Level tinyint)


select @PROCESSLEVEL = max(nn1.Indent_Level)
from NavigationNode nn1, NavigationNode nn2
where nn1.Navigation_ID = @NAVID
and nn1.Navigation_ID = nn2.Navigation_ID
and nn2.Navigation_Node_ID = nn1.Parent_Node_ID
and nn2.NodeType_EnumValue in (6, 7, 39) --page, attachment, report

--TFS 65490 correct the levels of the nodes that shift
--loop thru each indent level and delete all header nodes without children

while (@PROCESSLEVEL > 0) --SHOULD BE ZERO
  begin
  --populate temp nodes table
 ---get all the pages that have children
 -----add these pages to a temp table.  

    insert into #SHIFTNODES (Navigation_Node_ID, Parent_Node_ID, DisplayOrder, Indent_Level)
	select nn1.Navigation_Node_ID, nn2.Parent_Node_ID, (nn2.DisplayOrder + nn1.DisplayOrder), nn2.Indent_Level
	from NavigationNode nn1, NavigationNode nn2
	where nn1.Navigation_ID = @NAVID
	and nn1.Navigation_ID = nn2.Navigation_ID
	and nn2.Navigation_Node_ID = nn1.Parent_Node_ID
	and nn2.NodeType_EnumValue in (6, 7, 39) --page, attachment, report
	and nn1.Indent_Level = @PROCESSLEVEL


 ----- add the children of the temp table nodes to the temp table
    select @COUNT = 0

	select @COUNT = count(nn1.Navigation_Node_ID)
	from NavigationNode nn1, #SHIFTNODES tn
	where nn1.Navigation_ID = @NAVID
	and nn1.Parent_Node_ID = tn.Navigation_Node_ID
	and nn1.Navigation_Node_ID not in (select tn2.Navigation_Node_ID
									   from #SHIFTNODES tn2)

	while @COUNT > 0
    begin
	 ----- continue adding children of the temp table nodes to the temp table until no more children exist
		insert into #SHIFTNODES (Navigation_Node_ID, Parent_Node_ID, DisplayOrder, Indent_Level)
		select nn1.Navigation_Node_ID, nn1.Parent_Node_ID, nn1.DisplayOrder, (tn.Indent_Level + 1)
		from NavigationNode nn1, #SHIFTNODES tn
		where nn1.Navigation_ID = @NAVID
		and nn1.Parent_Node_ID = tn.Navigation_Node_ID
		and nn1.Navigation_Node_ID not in (select tn2.Navigation_Node_ID
									   from #SHIFTNODES tn2)


		select @COUNT = 0
		select @COUNT = count(nn1.Navigation_Node_ID)
		from NavigationNode nn1, #SHIFTNODES tn
		where nn1.Navigation_ID = @NAVID
		and nn1.Parent_Node_ID = tn.Navigation_Node_ID
		and nn1.Navigation_Node_ID not in (select tn2.Navigation_Node_ID
										   from #SHIFTNODES tn2)
	end --while @COUNT > 0

 ----- update the nn table for the nodes in the temp table:  
 ------- change the parent, displayorder, indent level for children of pages
 ------- decrement the indent level for other nodes.

	update nn1
	set nn1.Parent_Node_ID = tn.Parent_Node_ID, nn1.DisplayOrder = tn.DisplayOrder, nn1.Indent_Level = tn.Indent_Level
	from NavigationNode nn1, #SHIFTNODES tn
	where nn1.Navigation_ID = @NAVID
	and nn1.Navigation_Node_ID = tn.Navigation_Node_ID


	truncate table #SHIFTNODES
---- increment the process level and repeat until we max out the process level.
  select @PROCESSLEVEL = (@PROCESSLEVEL - 1)
end --begin

drop table #SHIFTNODES


select 'Finished script:  reset children of page nodes to be siblings'


select 'Started script:  Change date format for short date fields'
--TFS 63460 change the date format for short date fields

--with font entry in Property table
create table #ShortDates (Page_ID int, 
						GraphicObject_ID int, 
						Width smallint, 
						Fontsize varchar(4))

insert into #ShortDates (Page_ID, GraphicObject_ID, Width, Fontsize)
select g.Page_ID, g.GraphicObject_ID, g.Width, '12pt'
from GraphicObject g, PropertyValuesForGraphic pvg
where g.GraphicObjectType_EnumValue = 1 ---textbox
and g.DataType_EnumValue = 3
and g.Width <= 255
and g.Width >= 225
and pvg.Page_ID = g.Page_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and pvg.GraphicObject_ID = g.GraphicObject_ID
and pvg.Property_Name = 'Appearance.FontIndex'
and pvg.Property_Value in (0, 5, 6)--12pt
UNION
select g.Page_ID, g.GraphicObject_ID, g.Width,  '10pt'
from GraphicObject g, PropertyValuesForGraphic pvg
where g.GraphicObjectType_EnumValue = 1 ---textbox
and g.DataType_EnumValue = 3
and g.Width <= 217
and g.Width >= 191
and pvg.Page_ID = g.Page_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and pvg.GraphicObject_ID = g.GraphicObject_ID
and pvg.Property_Name = 'Appearance.FontIndex'
and pvg.Property_Value in (1, 7, 11) --10pt
UNION
select g.Page_ID, g.GraphicObject_ID, g.Width,  '8pt'
from GraphicObject g, PropertyValuesForGraphic pvg
where g.GraphicObjectType_EnumValue = 1 ---textbox
and g.DataType_EnumValue = 3
and g.Width <= 144
and g.Width >= 127
and pvg.Page_ID = g.Page_ID
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and pvg.GraphicObject_ID = g.GraphicObject_ID
and pvg.Property_Name = 'Appearance.FontIndex'
and pvg.Property_Value in (2, 4, 13) --8pt
UNION --default
select g.Page_ID, g.GraphicObject_ID, g.Width, '12pt'
from GraphicObject g
where g.GraphicObjectType_EnumValue = 1 ---textbox
and g.DataType_EnumValue = 3
and g.Width <= 255
and g.Width >= 225
and g.Page_ID > @LASTPAGE
and g.GraphicObject_ID > @LASTGRAPHIC
and not exists (select pvg.GraphicObject_ID
				from PropertyValuesForGraphic pvg
				where pvg.Page_ID = g.Page_ID
				and pvg.GraphicObject_ID = g.GraphicObject_ID
				and pvg.Property_Name = 'Appearance.FontIndex')
order by g.Page_ID, g.GraphicObject_ID, g.Width


--update where the date format exists
update pvg
set pvg.Property_Value = 7
from PropertyValuesForGraphic pvg, #ShortDates sd
where pvg.Page_ID = sd.Page_ID
and pvg.GraphicObject_ID = sd.GraphicObject_ID
and pvg.Property_Name = 'Behavior.DateFormat'

--insert where not exists
insert into PropertyValuesForGraphic (Page_ID, GraphicObject_ID, Property_Name, Property_Value)
select sd.Page_ID, sd.GraphicObject_ID,'Behavior.DateFormat', 7
from #ShortDates sd
where not exists (select 1 from PropertyValuesForGraphic pvg
					where pvg.Page_ID = sd.Page_ID
					and pvg.GraphicObject_ID = sd.GraphicObject_ID
					and pvg.Property_Name = 'Behavior.DateFormat')

drop table #ShortDates

select 'Finished script:  Change date format for short date fields'

--TFS 65177 eliminate empty design folders
select 'Finished script:  Eliminate empty design folders'

delete
from NavigationNode
where Navigation_ID = 1
and NodeType_EnumValue = 0
and Navigation_Node_ID > @LASTNAVNODE
and Navigation_Node_ID not in (select distinct isnull(Parent_Node_ID,0)
									from NavigationNode
									where Navigation_ID = 1)

select 'Finished script:  Eliminate empty design folders'