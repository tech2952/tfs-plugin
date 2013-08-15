
--TFS 63589 Find labels that are "PrintIfDataOnRow" and have code scripts that match the related textbox
--MUST BE RUN AFTER THE BASE SCRIPTS HAVE BEEN BUILT.

create table #PrintIfData (Page_ID int,
							GraphicObject_ID int,
							PositionX smallint,
							PositionY smallint,
							CountObjects int)

create table #DeleteScripts (Page_ID int,
							 GraphicObject_ID int,
							 CSA_ID int)

insert into #PrintIfData (Page_ID, GraphicObject_ID, PositionX, PositionY, CountObjects)
select g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY, count(g2.GraphicObject_ID)
from GraphicObject g1, GraphicObject g2, PropertyValuesForGraphic pvg1
where g1.Page_ID = g2.Page_ID
and g1.Page_ID = pvg1.Page_ID
and g1.GraphicObject_ID <> g2.GraphicObject_ID
and g1.GraphicObject_ID = pvg1.GraphicObject_ID
and g1.GraphicObjectType_EnumValue = 2 --label
and g2.GraphicObjectType_EnumValue = 1 -- textbox
and g1.PositionY = g2.PositionY
and g1.PositionX < g2.PositionX
and pvg1.Property_Name = 'Constraints.EssentialData'
and pvg1.Property_Value = 1  --PrintIfDataOnRow 
group by g1.Page_ID, g1.GraphicObject_ID, g1.PositionX, g1.PositionY
having count(g2.GraphicObject_ID) = 1


insert into #DeleteScripts (Page_ID, GraphicObject_ID, CSA_ID)
select pid.Page_ID, pid.GraphicObject_ID, csa1.CodeScriptAssignment_ID 
from #PrintIfData pid, GraphicObject g2, PropertyValuesForGraphic pvg1, PropertyValuesForGraphic pvg2,
CodeScriptAssignment csa1, CodeScriptAssignment csa2, CodeScriptBaseScriptXref csbsx1, CodeScriptBaseScriptXref csbsx2
where pid.Page_ID = g2.Page_ID
and pid.Page_ID = pvg1.Page_ID
and g2.Page_ID = pvg2.Page_ID
and pid.GraphicObject_ID <> g2.GraphicObject_ID
and pid.GraphicObject_ID = pvg1.GraphicObject_ID
and g2.GraphicObject_ID = pvg2.GraphicObject_ID
and g2.GraphicObjectType_EnumValue = 1 -- textbox
and pid.PositionY = g2.PositionY
and pid.PositionX < g2.PositionX
and pvg1.Property_Name = 'Constraint.AssignmentID'
and pvg1.Property_Value = csa1.CodeScriptAssignment_ID
and pvg2.Property_Name = 'Constraint.AssignmentID'
and pvg2.Property_Value = csa2.CodeScriptAssignment_ID
and csbsx1.CodeScript_ID = csa1.CodeScript_ID
and csbsx2.CodeScript_ID = csa2.CodeScript_ID
and csbsx1.BaseCodeScript_ID = csbsx2.BaseCodeScript_ID


--now, delete the code script assignments from the labels
delete fcd
from FADSConstraintDependency fcd, #DeleteScripts ds
where fcd.CodeScriptAssignment_ID = ds.CSA_ID

delete csa
from CodeScriptAssignment csa, #DeleteScripts ds
where csa.CodeScriptAssignment_ID = ds.CSA_ID
and csa.CodeScriptAssignment_ID not in (select fcd.CodeScriptAssignment_ID from FADSConstraintDependency fcd)

delete pvg
from PropertyValuesForGraphic pvg, #DeleteScripts ds
where pvg.Page_ID = ds.Page_ID
and pvg.GraphicObject_ID = ds.GraphicObject_ID
and pvg.Property_Name = 'Constraint.AssignmentID'
and pvg.Property_Value not in (select CodeScriptAssignment_ID from CodeScriptAssignment)


drop table #PrintIfData
drop table #DeleteScripts