--This script will remove the code script assignments on the print runtime nodes of a specified product
--This script will then assign the AlwaysPrint property to the page nodes in the print runtime tree
--This will allow for a product (currently, only 5500 needs it) to print blank pages with barcodes for forms approval

declare @NAVID int
declare @PRODUCT varchar(4)

select @PRODUCT = '5500'  --ENTER THE PRODUCT NAME HERE

--identify the Navigation ID for the runtime print tree
select @NAVID = Navigation_ID
from Navigation
where Product_Name = @PRODUCT
and NavigationType_EnumValue = 1 --Print Runtime Tree

--delete any FADSConstraintDependency entries for the code scripts assigned to the nodes

delete fcd
from CodeScriptAssignment csa, FADSConstraintDependency fcd, NavigationNode nn
where fcd.CodeScriptAssignment_ID = csa.CodeScriptAssignment_ID
and csa.Dependent_Page_ID = 0
and csa.Dependent_ID = nn.Navigation_Node_ID
and nn.Navigation_ID = @NAVID


--delete any CodeScriptAssignments for the nodes

delete csa
from CodeScriptAssignment csa, NavigationNode nn
where csa.Dependent_Page_ID = 0
and csa.Dependent_ID = nn.Navigation_Node_ID
and nn.Navigation_ID = @NAVID


--Update to the AlwaysPrint value if the property already exists
update pvn
set pvn.Property_Value = 1
from NavigationNode nn, PropertyValuesForNode pvn
where nn.Navigation_ID = @NAVID
and nn.NodeType_EnumValue = 6 --Page
and pvn.Navigation_Node_ID = nn.Navigation_Node_ID
and pvn.Property_Name = 'Behavior.EssentialDataTest'


--insert the AlwaysPrint value for the page node if no record already exists
insert into PropertyValuesForNode (Navigation_Node_ID, Property_Name, Property_Value)
select nn.Navigation_Node_ID, 'Behavior.EssentialDataTest', 1
from NavigationNode nn
where nn.Navigation_ID = @NAVID
and nn.NodeType_EnumValue = 6 --Page
and not exists (select 1 from PropertyValuesForNode pvn1
				where pvn1.Property_Name = 'Behavior.EssentialDataTest'
				and pvn1.Navigation_Node_ID = nn.Navigation_Node_ID)


--Remove the BlankField format options so that data doesn't print in blank fields
delete pvg
from PropertyValuesForGraphic pvg, NavigationNode nn
where pvg.Property_Name = 'Behavior.BlankFieldFormat'
and pvg.Page_ID = nn.Page_ID
and nn.Navigation_ID = @NAVID