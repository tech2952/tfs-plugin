if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptBaseScriptXref_BaseCodeScript]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptBaseScriptXref] DROP CONSTRAINT FK_CodeScriptBaseScriptXref_BaseCodeScript
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptAssignment_CodeScript]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptAssignment] DROP CONSTRAINT FK_CodeScriptAssignment_CodeScript
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptBaseScriptXref_CodeScript]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptBaseScriptXref] DROP CONSTRAINT FK_CodeScriptBaseScriptXref_CodeScript
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptParameters_CodeScript]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptParameters] DROP CONSTRAINT FK_CodeScriptParameters_CodeScript
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptTestCase_CodeScript]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptTestCase] DROP CONSTRAINT FK_CodeScriptTestCase_CodeScript
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Diagnostic_CodeScript]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Diagnostic] DROP CONSTRAINT FK_Diagnostic_CodeScript
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ComputedObjectDependency_CodeScriptAssignment]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ComputedObjectDependency] DROP CONSTRAINT FK_ComputedObjectDependency_CodeScriptAssignment
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSConstraintDependency_CodeScriptAssignment]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSConstraintDependency] DROP CONSTRAINT FK_FADSConstraintDependency_CodeScriptAssignment
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScript_CodeScriptCategory]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScript] DROP CONSTRAINT FK_CodeScript_CodeScriptCategory
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptTestCaseValues_CodeScriptParameters]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptTestCaseValues] DROP CONSTRAINT FK_CodeScriptTestCaseValues_CodeScriptParameters
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ComputedObjectDependency_CodeScriptParameters]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ComputedObjectDependency] DROP CONSTRAINT FK_ComputedObjectDependency_CodeScriptParameters
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSConstraintDependency_CodeScriptParameters]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSConstraintDependency] DROP CONSTRAINT FK_FADSConstraintDependency_CodeScriptParameters
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptTestCaseValues_CodeScriptTestCase]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptTestCaseValues] DROP CONSTRAINT FK_CodeScriptTestCaseValues_CodeScriptTestCase
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicDXAssignment_DataExchangeElement]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicDXAssignment] DROP CONSTRAINT FK_GraphicDXAssignment_DataExchangeElement
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataExchangeElement_DataExchangeHistory]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataExchangeElement] DROP CONSTRAINT FK_DataExchangeElement_DataExchangeHistory
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataExchangeElement_DataExchangeType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataExchangeElement] DROP CONSTRAINT FK_DataExchangeElement_DataExchangeType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataExchangeHistory_DataExchangeType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataExchangeHistory] DROP CONSTRAINT FK_DataExchangeHistory_DataExchangeType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicDXAssignment_DataExchangeType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicDXAssignment] DROP CONSTRAINT FK_GraphicDXAssignment_DataExchangeType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataExchangeHistory_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataExchangeHistory] DROP CONSTRAINT FK_DataExchangeHistory_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeletedPage_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeletedPage] DROP CONSTRAINT FK_DeletedPage_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeveloperFADSXref_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeveloperFADSXref] DROP CONSTRAINT FK_DeveloperFADSXref_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeveloperRoleXref_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeveloperRoleXref] DROP CONSTRAINT FK_DeveloperRoleXref_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Navigation_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Navigation] DROP CONSTRAINT FK_Navigation_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_NavigationHistory_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NavigationHistory] DROP CONSTRAINT FK_NavigationHistory_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_NetworkLogin_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NetworkLogin] DROP CONSTRAINT FK_NetworkLogin_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Page_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Page] DROP CONSTRAINT FK_Page_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PageHistory_DeveloperName]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PageHistory] DROP CONSTRAINT FK_PageHistory_DeveloperName
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScript_DeveloperRole]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScript] DROP CONSTRAINT FK_CodeScript_DeveloperRole
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeletedPage_DeveloperRole]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeletedPage] DROP CONSTRAINT FK_DeletedPage_DeveloperRole
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeveloperRoleXref_DeveloperRole]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeveloperRoleXref] DROP CONSTRAINT FK_DeveloperRoleXref_DeveloperRole
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PrintNavigationNode_DeveloperRole]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NavigationNode] DROP CONSTRAINT FK_PrintNavigationNode_DeveloperRole
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_BuiltItem_Enum_BuiltItemType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[BuiltItem] DROP CONSTRAINT FK_BuiltItem_Enum_BuiltItemType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptAssignment_Enum_CodeType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptAssignment] DROP CONSTRAINT FK_CodeScriptAssignment_Enum_CodeType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataLink_Enum_DataLinkType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataLink] DROP CONSTRAINT FK_DataLink_Enum_DataLinkType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScript_Enum_DataType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScript] DROP CONSTRAINT FK_CodeScript_Enum_DataType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CodeScriptParameters_Enum_DataType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CodeScriptParameters] DROP CONSTRAINT FK_CodeScriptParameters_Enum_DataType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataExchangeElement_Enum_DataType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataExchangeElement] DROP CONSTRAINT FK_DataExchangeElement_Enum_DataType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSFields_Enum_DataType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSField] DROP CONSTRAINT FK_FADSFields_Enum_DataType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicObject_Enum_DataType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicObject] DROP CONSTRAINT FK_GraphicObject_Enum_DataType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Diagnostic_Enum_DiagnosticSeverity]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Diagnostic] DROP CONSTRAINT FK_Diagnostic_Enum_DiagnosticSeverity
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicObject_Enum_GraphicObjectType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicObject] DROP CONSTRAINT FK_GraphicObject_Enum_GraphicObjectType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Holiday_Enum_Jurisdiction]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Holiday] DROP CONSTRAINT FK_Holiday_Enum_Jurisdiction
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Navigation_Enum_NavigationType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Navigation] DROP CONSTRAINT FK_Navigation_Enum_NavigationType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PrintRuntimeNavigationNode_Enum_PrintNodeType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NavigationNode] DROP CONSTRAINT FK_PrintRuntimeNavigationNode_Enum_PrintNodeType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Page_Enum_PageType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Page] DROP CONSTRAINT FK_Page_Enum_PageType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeveloperFADSXref_FADSArea]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeveloperFADSXref] DROP CONSTRAINT FK_DeveloperFADSXref_FADSArea
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSFields_FADSArea]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSField] DROP CONSTRAINT FK_FADSFields_FADSArea
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSScreen_FADSArea]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSScreen] DROP CONSTRAINT FK_FADSScreen_FADSArea
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSFields_FADSScreen]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSField] DROP CONSTRAINT FK_FADSFields_FADSScreen
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ComputedObjectDependency_GraphicObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ComputedObjectDependency] DROP CONSTRAINT FK_ComputedObjectDependency_GraphicObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataLink_GraphicObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataLink] DROP CONSTRAINT FK_DataLink_GraphicObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataLink_GraphicObject1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataLink] DROP CONSTRAINT FK_DataLink_GraphicObject1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicDXAssignment_GraphicObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicDXAssignment] DROP CONSTRAINT FK_GraphicDXAssignment_GraphicObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PropertyValuesForGraphic_GraphicObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PropertyValuesForGraphic] DROP CONSTRAINT FK_PropertyValuesForGraphic_GraphicObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_BuiltItem_LargeObject]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[BuiltItem] DROP CONSTRAINT FK_BuiltItem_LargeObject
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_NavigationHistory_Navigation]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NavigationHistory] DROP CONSTRAINT FK_NavigationHistory_Navigation
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PrintRuntimeNavigationNode_Navigation]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NavigationNode] DROP CONSTRAINT FK_PrintRuntimeNavigationNode_Navigation
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PropertyValuesForNode_NavigationNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PropertyValuesForNode] DROP CONSTRAINT FK_PropertyValuesForNode_NavigationNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ComputedObjectDependency_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ComputedObjectDependency] DROP CONSTRAINT FK_ComputedObjectDependency_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataLink_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataLink] DROP CONSTRAINT FK_DataLink_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DataLink_Page1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DataLink] DROP CONSTRAINT FK_DataLink_Page1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DeletedPage_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DeletedPage] DROP CONSTRAINT FK_DeletedPage_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicDXAssignment_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicDXAssignment] DROP CONSTRAINT FK_GraphicDXAssignment_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicObject_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicObject] DROP CONSTRAINT FK_GraphicObject_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_GraphicObject_Page1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[GraphicObject] DROP CONSTRAINT FK_GraphicObject_Page1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_NavigationNode_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[NavigationNode] DROP CONSTRAINT FK_NavigationNode_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PageHistory_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PageHistory] DROP CONSTRAINT FK_PageHistory_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PropertyValuesForGraphic_Page1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PropertyValuesForGraphic] DROP CONSTRAINT FK_PropertyValuesForGraphic_Page1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PropertyValuesForPage_Page]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PropertyValuesForPage] DROP CONSTRAINT FK_PropertyValuesForPage_Page
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AssignmentGroupXref_AssignmentGroup]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AssignmentGroupXref] DROP CONSTRAINT FK_AssignmentGroupXref_AssignmentGroup
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_BuiltItem_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[BuiltItem] DROP CONSTRAINT FK_BuiltItem_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CurrencyRoundingCode_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CurrencyRoundingCode] DROP CONSTRAINT FK_CurrencyRoundingCode_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSArea_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSArea] DROP CONSTRAINT FK_FADSArea_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSFields_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSField] DROP CONSTRAINT FK_FADSFields_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FADSScreen_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FADSScreen] DROP CONSTRAINT FK_FADSScreen_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Navigation_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Navigation] DROP CONSTRAINT FK_Navigation_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ValueListItem_ValueList]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ValueListItem] DROP CONSTRAINT FK_ValueListItem_ValueList
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MarkNextGraphicID]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[MarkNextGraphicID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DataExchangeAssignment]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[DataExchangeAssignment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptParameterCount]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[CodeScriptParameterCount]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssignmentGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AssignmentGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AssignmentGroupXref]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AssignmentGroupXref]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BaseCodeScript]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BaseCodeScript]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BuiltItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BuiltItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScript]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScript]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptAssignment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScriptAssignment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptBaseScriptXref]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScriptBaseScriptXref]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScriptCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptParameters]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScriptParameters]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptTestCase]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScriptTestCase]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeScriptTestCaseValues]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CodeScriptTestCaseValues]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ComputedObjectDependency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ComputedObjectDependency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CurrencyRoundingCode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CurrencyRoundingCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DataExchangeElement]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DataExchangeElement]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DataExchangeHistory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DataExchangeHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DataExchangeType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DataExchangeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DataLink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DataLink]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeletedPage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DeletedPage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeveloperFADSXref]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DeveloperFADSXref]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeveloperName]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DeveloperName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeveloperRole]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DeveloperRole]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeveloperRoleXref]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DeveloperRoleXref]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Diagnostic]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Diagnostic]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enterprise_Information]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enterprise_Information]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_AnchorPosition]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_AnchorPosition]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_AttachmentLinkTextOption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_AttachmentLinkTextOption]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_BuiltItemType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_BuiltItemType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_CodeType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_CodeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_DataLinkType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_DataLinkType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_DataType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_DataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_DiagnosticSeverity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_DiagnosticSeverity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_EntityLoopEntity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_EntityLoopEntity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_FormatDateOption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_FormatDateOption]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_FormatNegativeOption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_FormatNegativeOption]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_FormatZeroOption]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_FormatZeroOption]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_GraphicObjectType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_GraphicObjectType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_GroupOverflow]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_GroupOverflow]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_GroupRepetitionDirection]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_GroupRepetitionDirection]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_Jurisdiction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_Jurisdiction]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_NavigationType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_NavigationType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_NodeType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_NodeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_OverscoreUnderscoreCharacter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_OverscoreUnderscoreCharacter]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_PageType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_PageType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_PaperOrientation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_PaperOrientation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_PaperSize]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_PaperSize]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_RegularExpression]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_RegularExpression]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_SpecialHeaderNodeFunction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_SpecialHeaderNodeFunction]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Enum_SpecialTextType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Enum_SpecialTextType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FADSArea]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FADSArea]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FADSConstraintDependency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FADSConstraintDependency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FADSField]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FADSField]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FADSScreen]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FADSScreen]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FontFamily]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FontFamily]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GraphicDXAssignment]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GraphicDXAssignment]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GraphicObject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GraphicObject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Holiday]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Holiday]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LargeObject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LargeObject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Navigation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Navigation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NavigationHistory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NavigationHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NavigationNode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NavigationNode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NetworkLogin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NetworkLogin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NextGraphicObject]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NextGraphicObject]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Page]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Page]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PageHistory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PageHistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Product]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PropertyValuesForGraphic]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PropertyValuesForGraphic]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PropertyValuesForNode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PropertyValuesForNode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PropertyValuesForPage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PropertyValuesForPage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ValueList]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ValueList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ValueListItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ValueListItem]
GO

CREATE TABLE [dbo].[AssignmentGroup] (
	[AssignmentGroup_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[AssignmentGroup_Name] [objectname] NOT NULL ,
	[AssignmentGroup_Description] [objectdescription] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AssignmentGroupXref] (
	[AssignmentGroup_ID] [objectid] NOT NULL ,
	[DeveloperRole_ID] [objectid] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BaseCodeScript] (
	[BaseCodeScript_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[OpCodeHash] [nvarchar] (16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CompiledScript] [nvarchar] (3999) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BuiltItem] (
	[Product_Name] [objectname] NOT NULL ,
	[ItemName_EnumValue] [tinyint] NOT NULL ,
	[LargeObject_ID] [objectid] NULL ,
	[DateLastSaved] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScript] (
	[Code_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Code_Name] [varchar] (115) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Return_Enum_DataType] [tinyint] NOT NULL ,
	[Code_Syntax] [nvarchar] (3930) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DateCreated] [datetime] NULL ,
	[DateLastSaved] [datetime] NULL ,
	[IsSystemCode] [booleanvalue] NULL ,
	[DeveloperRole_ID] [objectid] NULL ,
	[CodeScriptCategory_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScriptAssignment] (
	[CodeScriptAssignment_ID] [objectid] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Dependent_ID] [objectid] NOT NULL ,
	[Dependent_Page_ID] [objectid] NOT NULL ,
	[CodeScript_ID] [objectid] NOT NULL ,
	[CodeType_EnumValue] [tinyint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScriptBaseScriptXref] (
	[CodeScript_ID] [objectid] NOT NULL ,
	[BaseCodeScript_ID] [objectid] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScriptCategory] (
	[CodeScriptCategory_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Category_Name] [objectname] NULL ,
	[Category_Description] [objectdescription] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScriptParameters] (
	[Parameter_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Code_ID] [objectid] NOT NULL ,
	[Parameter_Name] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Parameter_Enum_DataType] [tinyint] NOT NULL ,
	[Parameter_Position] [tinyint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScriptTestCase] (
	[TestCase_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Code_ID] [objectid] NOT NULL ,
	[Test_Name] [objectname] NULL ,
	[ExpectedResult_Value] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CodeScriptTestCaseValues] (
	[TestCase_ID] [objectid] NOT NULL ,
	[Parameter_ID] [objectid] NOT NULL ,
	[ParameterInputValue] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ComputedObjectDependency] (
	[CodeScriptAssignment_ID] [objectid] NOT NULL ,
	[Parameter_ID] [objectid] NOT NULL ,
	[ParameterSource_Page_ID] [objectid] NULL ,
	[ParameterSource_Object_ID] [objectid] NULL ,
	[Processing_Scheme] [tinyint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CurrencyRoundingCode] (
	[Product_Name] [objectname] NOT NULL ,
	[Currency_Rounding_Code] [varchar] (7) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DataExchangeElement] (
	[DX_Element_ID] [objectid] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[DX_Type_ID] [objectid] NOT NULL ,
	[DX_Element_Name] [varchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataType_EnumValue] [tinyint] NOT NULL ,
	[Annotation] [varchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DX_History_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DataExchangeHistory] (
	[DX_History_ID] [objectid] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[DX_Type_ID] [objectid] NOT NULL ,
	[Import_Date] [smalldatetime] NOT NULL ,
	[DX_Type_Schema] [xmlstream] NOT NULL ,
	[DX_Type_Schema_Source] [varchar] (265) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Import_Success] [booleanvalue] NOT NULL ,
	[Import_Fail_Reason] [objectdescription] NULL ,
	[Developer_ID] [objectid] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[DataExchangeType] (
	[DX_Type_ID] [objectid] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[DX_Type_Name] [objectname] NOT NULL ,
	[DX_Type_Description] [objectdescription] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DataLink] (
	[LinkSource_ID] [objectid] NOT NULL ,
	[LinkSource_Page_ID] [objectid] NOT NULL ,
	[LinkTarget_ID] [objectid] NOT NULL ,
	[LinkTarget_Page_ID] [objectid] NOT NULL ,
	[LinkType_EnumValue] [tinyint] NULL ,
	[IsDefault] [booleanvalue] NULL ,
	[LoopingColumn_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DeletedPage] (
	[Page_ID] [objectid] NOT NULL ,
	[Date_Deleted] [smalldatetime] NOT NULL ,
	[DeveloperRole_ID] [objectid] NOT NULL ,
	[Developer_ID] [objectid] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DeveloperFADSXref] (
	[Developer_ID] [objectid] NOT NULL ,
	[Product_Name] [objectname] NOT NULL ,
	[FADS_Area] [tinyint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DeveloperName] (
	[Developer_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[FirstName] [objectname] NOT NULL ,
	[LastName] [objectname] NOT NULL ,
	[IsAdministrator] [booleanvalue] NOT NULL ,
	[IsFormsComposer] [booleanvalue] NOT NULL ,
	[IsDA] [booleanvalue] NULL ,
	[IsObsolete] [booleanvalue] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DeveloperRole] (
	[DeveloperRole_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[DeveloperRoleName] [objectname] NOT NULL ,
	[DeveloperRole_Description] [objectdescription] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DeveloperRoleXref] (
	[Developer_ID] [objectid] NOT NULL ,
	[DeveloperRole_ID] [objectid] NOT NULL,
	[IsDisabled] [booleanvalue] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Diagnostic] (
	[Diagnostic_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Diagnostic_Text] [varchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Diagnostic_Number] [varchar] (6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Severity] [tinyint] NOT NULL ,
	[IncludeAsTask] [booleanvalue] NOT NULL ,
	[CodeScript_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enterprise_Information] (
	[DB_Version] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Product_Year] [productyear] NULL ,
	[ImageDB_ConnectionString] [varchar] (300) NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_AnchorPosition] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_AttachmentLinkTextOption] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_BuiltItemType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_CodeType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_DataLinkType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_DataType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_DiagnosticSeverity] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_EntityLoopEntity] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_FormatDateOption] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_FormatNegativeOption] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_FormatZeroOption] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_GraphicObjectType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_GroupOverflow] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_GroupRepetitionDirection] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_Jurisdiction] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_NavigationType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_NodeType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_OverscoreUnderscoreCharacter] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_PageType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_PaperOrientation] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_PaperSize] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_RegularExpression] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_SpecialHeaderNodeFunction] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Enum_SpecialTextType] (
	[Enum_Value] [tinyint] NOT NULL ,
	[Enum_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FADSArea] (
	[Product_Name] [objectname] NOT NULL ,
	[FADS_Area] [tinyint] NOT NULL ,
	[FADS_Area_Name] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FADSConstraintDependency] (
	[CodeScriptAssignment_ID] [objectid] NOT NULL ,
	[Parameter_ID] [objectid] NOT NULL ,
	[FADS_Field_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FADSField] (
	[FADS_Field_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Field_Name] [objectname] NOT NULL ,
	[Product_Name] [objectname] NOT NULL ,
	[FADS_Area] [tinyint] NOT NULL ,
	[FADS_Screen] [int] NULL ,
	[FADS_Field] [tinyint] NOT NULL ,
	[FADS_Level] [tinyint] NOT NULL ,
	[Field_Datatype] [tinyint] NOT NULL ,
	[Field_Length] [smallint] NULL ,
	[Field_Precision] [tinyint] NULL,
	[ExpiryDate] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FADSScreen] (
	[Product_Name] [objectname] NOT NULL ,
	[FADS_Area] [tinyint] NOT NULL ,
	[FADS_Screen] [int] NOT NULL ,
	[FADS_Screen_Name] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FontFamily] (
	[FontFamilyName] [objectname] NOT NULL ,
	[AllowItalic] [booleanvalue] NULL ,
	[AllowBold] [booleanvalue] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GraphicDXAssignment] (
	[Page_ID] [objectid] NOT NULL ,
	[GraphicObject_ID] [objectid] NOT NULL ,
	[DX_Type_ID] [objectid] NOT NULL ,
	[DX_Element_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[GraphicObject] (
	[GraphicObject_ID] [objectid] NOT NULL ,
	[GraphicObjectType_EnumValue] [tinyint] NOT NULL ,
	[Page_ID] [objectid] NOT NULL ,
	[PositionX] [int] NOT NULL ,
	[PositionY] [int] NOT NULL ,
	[Height] [smallint] NOT NULL ,
	[Width] [smallint] NOT NULL ,
	[DataType_EnumValue] [tinyint] NULL ,
	[IsShortcut] [booleanvalue] NULL ,
	[Parent_GraphicObject_ID] [objectid] NULL ,
	[Linked_GraphicObject_ID] [objectid] NULL ,
	[Linked_Page_ID] [objectid] NULL ,
	[GraphicObject_Name] [objectname] NULL ,
	[DateCreated] [smalldatetime] NOT NULL ,
	[DateLastSaved] [smalldatetime] NOT NULL ,
	[WIP_Flag] [tinyint] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Holiday] (
	[Jurisdiction_EnumValue] [tinyint] NOT NULL ,
	[Holiday_Date] [smalldatetime] NOT NULL ,
	[Holiday_Description] [objectdescription] NULL 
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[LargeObject] (
	[LargeObject_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[LargeObject] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Navigation] (
	[Navigation_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[NavigationType_EnumValue] [tinyint] NOT NULL ,
	[Product_Name] [objectname] NULL ,
	[IsCheckedOut] [booleanvalue] NULL ,
	[Developer_ID] [objectid] NULL ,
	[DateCheckedOut] [datetime] NULL ,
	[DateLastSaved] [datetime] NULL ,
	[Current_Version] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NavigationHistory] (
	[Navigation_ID] [objectid] NOT NULL ,
	[Version] [int] NOT NULL ,
	[Checkin_Comment] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Developer_ID] [objectid] NOT NULL ,
	[Undo_Script] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Checkin_Time] [datetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[NavigationNode] (
	[Navigation_Node_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[NodeType_EnumValue] [tinyint] NULL ,
	[Node_Name] [objectname] NULL ,
	[Navigation_ID] [objectid] NULL ,
	[Parent_Node_ID] [objectid] NULL ,
	[DisplayOrder] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Indent_Level] [tinyint] NULL ,
	[DeveloperRole_ID] [objectid] NULL ,
	[Page_ID] [objectid] NULL ,
	[AlternateAction_Node_ID] [objectid] NULL ,
	[ShortCut_Node_ID] [objectid] NULL ,
	[DateCreated] [smalldatetime] NULL ,
	[DateLastSaved] [smalldatetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NetworkLogin] (
	[NetworkLogin_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[DomainLogin] [objectname] NOT NULL ,
	[Developer_ID] [objectid] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[NextGraphicObject] (
	[NextGraphicObject_ID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Page] (
	[Page_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[PageType_EnumValue] [tinyint] NOT NULL ,
	[Page_Name] [objectname] NOT NULL ,
	[Parent_Page_ID] [objectid] NULL ,
	[DateCreated] [smalldatetime] NULL ,
	[DateLastSaved] [smalldatetime] NULL ,
	[DateLastApproved] [smalldatetime] NULL ,
	[WIP_Developer_ID] [objectid] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PageHistory] (
	[PageHistory_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[Page_ID] [objectid] NOT NULL ,
	[Change_Date] [smalldatetime] NOT NULL ,
	[Developer_ID] [objectid] NOT NULL ,
	[PageHistory_XML] [xmlstream] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product] (
	[Product_Name] [objectname] NOT NULL ,
	[Version] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PropertyValuesForGraphic] (
	[GraphicObject_ID] [objectid] NOT NULL ,
	[Page_ID] [objectid] NOT NULL ,
	[Property_Name] [objectname] NOT NULL ,
	[Property_Value] [sql_variant] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PropertyValuesForNode] (
	[Navigation_Node_ID] [objectid] NOT NULL ,
	[Property_Name] [objectname] NOT NULL ,
	[Property_Value] [sql_variant] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PropertyValuesForPage] (
	[Page_ID] [objectid] NOT NULL ,
	[Property_Name] [objectname] NOT NULL ,
	[Property_Value] [sql_variant] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ValueList] (
	[ValueList_ID] [objectid] IDENTITY (1, 1) NOT NULL ,
	[ValueList_Name] [objectname] NOT NULL ,
	[ValueList_Description] [objectname] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ValueListItem] (
	[ValueListItem_Name] [objectname] NOT NULL ,
	[ValueList_ID] [objectid] NOT NULL ,
	[Stored_Value] [objectname] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AssignmentGroup] WITH NOCHECK ADD 
	CONSTRAINT [PK_AssignmentGroup] PRIMARY KEY  CLUSTERED 
	(
		[AssignmentGroup_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AssignmentGroupXref] WITH NOCHECK ADD 
	CONSTRAINT [PK_AssignmentGroupXref] PRIMARY KEY  CLUSTERED 
	(
		[AssignmentGroup_ID],
		[DeveloperRole_ID]
	)  ON [PRIMARY] 
GO



ALTER TABLE [dbo].[BaseCodeScript] WITH NOCHECK ADD 
	CONSTRAINT [PK_BaseCodeScript] PRIMARY KEY  CLUSTERED 
	(
		[BaseCodeScript_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[BuiltItem] WITH NOCHECK ADD 
	CONSTRAINT [PK_BuiltItem] PRIMARY KEY  CLUSTERED 
	(
		[Product_Name],
		[ItemName_EnumValue]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScript] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScript] PRIMARY KEY  CLUSTERED 
	(
		[Code_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptAssignment] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScriptAssignment] PRIMARY KEY  CLUSTERED 
	(
		[CodeScriptAssignment_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptBaseScriptXref] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScriptBaseScriptXref] PRIMARY KEY  CLUSTERED 
	(
		[CodeScript_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptCategory] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScriptCategory] PRIMARY KEY  CLUSTERED 
	(
		[CodeScriptCategory_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptParameters] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScriptParameters] PRIMARY KEY  CLUSTERED 
	(
		[Parameter_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptTestCase] WITH NOCHECK ADD 
	CONSTRAINT [PK_CodeScriptTestCase] PRIMARY KEY  CLUSTERED 
	(
		[TestCase_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptTestCaseValues] WITH NOCHECK ADD 
	CONSTRAINT [PK_CaseScriptTestCaseValues] PRIMARY KEY  CLUSTERED 
	(
		[TestCase_ID],
		[Parameter_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ComputedObjectDependency] WITH NOCHECK ADD 
	CONSTRAINT [PK_ComputedObjectDependency] PRIMARY KEY  CLUSTERED 
	(
		[CodeScriptAssignment_ID],
		[Parameter_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CurrencyRoundingCode] WITH NOCHECK ADD 
	CONSTRAINT [PK_CurrencyRoundingCode] PRIMARY KEY  CLUSTERED 
	(
		[Product_Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DataExchangeElement] WITH NOCHECK ADD 
	CONSTRAINT [PK_DXSchemaElement] PRIMARY KEY  CLUSTERED 
	(
		[DX_Element_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DataExchangeHistory] WITH NOCHECK ADD 
	CONSTRAINT [PK_DataExchangeHistory] PRIMARY KEY  CLUSTERED 
	(
		[DX_History_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DataExchangeType] WITH NOCHECK ADD 
	CONSTRAINT [PK_DataExchangeType] PRIMARY KEY  CLUSTERED 
	(
		[DX_Type_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DataLink] WITH NOCHECK ADD 
	CONSTRAINT [PK_DataLink] PRIMARY KEY  CLUSTERED 
	(
		[LinkSource_ID],
		[LinkSource_Page_ID],
		[LinkTarget_ID],
		[LinkTarget_Page_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DeletedPage] WITH NOCHECK ADD 
	CONSTRAINT [PK_DeletedPage] PRIMARY KEY  CLUSTERED 
	(
		[Page_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DeveloperFADSXref] WITH NOCHECK ADD 
	CONSTRAINT [PK_DeveloperFADSXref] PRIMARY KEY  CLUSTERED 
	(
		[Developer_ID],
		[Product_Name],
		[FADS_Area]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DeveloperName] WITH NOCHECK ADD 
	CONSTRAINT [PK_DeveloperName] PRIMARY KEY  CLUSTERED 
	(
		[Developer_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DeveloperRole] WITH NOCHECK ADD 
	CONSTRAINT [PK_DeveloperRole] PRIMARY KEY  CLUSTERED 
	(
		[DeveloperRole_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DeveloperRoleXref] WITH NOCHECK ADD 
	CONSTRAINT [PK_DeveloperRoleXref] PRIMARY KEY  CLUSTERED 
	(
		[DeveloperRole_ID],
		[Developer_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Diagnostic] WITH NOCHECK ADD 
	CONSTRAINT [PK_Diagnostic] PRIMARY KEY  CLUSTERED 
	(
		[Diagnostic_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_AnchorPosition] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_AnchorPosition] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_AttachmentLinkTextOption] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_AttachmentLinkOption] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_BuiltItemType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_BuiltItemType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_CodeType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_CodeType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_DataLinkType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_DataLinkType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_DataType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_DataType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_DiagnosticSeverity] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_DiagnosticSeverity] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_EntityLoopEntity] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_EntityLoopEntity] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_FormatDateOption] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_FormatDateOption] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_FormatNegativeOption] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_FormatNegativeOption] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_FormatZeroOption] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_FormatZeroOption] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_GraphicObjectType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_GraphicObjectType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_GroupOverflow] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_GroupOverflow] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_GroupRepetitionDirection] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_GroupRepetitionDirection] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_Jurisdiction] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_Jurisdiction] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_NavigationType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_NavigationType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_NodeType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_NodeType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_OverscoreUnderscoreCharacter] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_OverscoreUnderscoreCharacter] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_PageType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_PageType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_PaperOrientation] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_PaperOrientation] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_PaperSize] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_PaperSize] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_RegularExpression] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_RegularExpression] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_SpecialHeaderNodeFunction] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_SpecialHeaderNodeFunctions] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Enum_SpecialTextType] WITH NOCHECK ADD 
	CONSTRAINT [PK_Enum_SpecialTextType] PRIMARY KEY  CLUSTERED 
	(
		[Enum_Value]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FADSArea] WITH NOCHECK ADD 
	CONSTRAINT [PK_FADSArea] PRIMARY KEY  CLUSTERED 
	(
		[Product_Name],
		[FADS_Area]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FADSConstraintDependency] WITH NOCHECK ADD 
	CONSTRAINT [PK_FADSConstraintDependency] PRIMARY KEY  CLUSTERED 
	(
		[CodeScriptAssignment_ID],
		[Parameter_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FADSField] WITH NOCHECK ADD 
	CONSTRAINT [PK_FADSFields] PRIMARY KEY  CLUSTERED 
	(
		[FADS_Field_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FADSScreen] WITH NOCHECK ADD 
	CONSTRAINT [PK_FADSScreen] PRIMARY KEY  CLUSTERED 
	(
		[Product_Name],
		[FADS_Area],
		[FADS_Screen]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[FontFamily] WITH NOCHECK ADD 
	CONSTRAINT [PK_FontFamily] PRIMARY KEY  CLUSTERED 
	(
		[FontFamilyName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GraphicDXAssignment] WITH NOCHECK ADD 
	CONSTRAINT [PK_GraphicDXAssignment] PRIMARY KEY  CLUSTERED 
	(
		[Page_ID],
		[GraphicObject_ID],
		[DX_Type_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GraphicObject] WITH NOCHECK ADD 
	CONSTRAINT [PK_GraphicObject] PRIMARY KEY  CLUSTERED 
	(
		[GraphicObject_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Holiday] WITH NOCHECK ADD 
	CONSTRAINT [PK_Holiday] PRIMARY KEY  CLUSTERED 
	(
		[Jurisdiction_EnumValue],
		[Holiday_Date]
	)  ON [PRIMARY] 
GO


ALTER TABLE [dbo].[LargeObject] WITH NOCHECK ADD 
	CONSTRAINT [PK_LargeObject] PRIMARY KEY  CLUSTERED 
	(
		[LargeObject_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Navigation] WITH NOCHECK ADD 
	CONSTRAINT [PK_Navigation] PRIMARY KEY  CLUSTERED 
	(
		[Navigation_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[NavigationHistory] WITH NOCHECK ADD 
	CONSTRAINT [PK_NavigationHistory] PRIMARY KEY  CLUSTERED 
	(
		[Navigation_ID],
		[Version]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[NavigationNode] WITH NOCHECK ADD 
	CONSTRAINT [PK_NavigationNode] PRIMARY KEY  CLUSTERED 
	(
		[Navigation_Node_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[NetworkLogin] WITH NOCHECK ADD 
	CONSTRAINT [PK_NetworkLogin] PRIMARY KEY  CLUSTERED 
	(
		[NetworkLogin_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Page] WITH NOCHECK ADD 
	CONSTRAINT [PK_Page] PRIMARY KEY  CLUSTERED 
	(
		[Page_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PageHistory] WITH NOCHECK ADD 
	CONSTRAINT [PK_PageHistory] PRIMARY KEY  CLUSTERED 
	(
		[PageHistory_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Product] WITH NOCHECK ADD 
	CONSTRAINT [PK_Product] PRIMARY KEY  CLUSTERED 
	(
		[Product_Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PropertyValuesForGraphic] WITH NOCHECK ADD 
	CONSTRAINT [PK_PropertyValuesForGraphic] PRIMARY KEY  CLUSTERED 
	(
		[GraphicObject_ID],
		[Page_ID],
		[Property_Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PropertyValuesForNode] WITH NOCHECK ADD 
	CONSTRAINT [PK_PropertyValuesForNode] PRIMARY KEY  CLUSTERED 
	(
		[Navigation_Node_ID],
		[Property_Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PropertyValuesForPage] WITH NOCHECK ADD 
	CONSTRAINT [PK_PropertyValuesForPage] PRIMARY KEY  CLUSTERED 
	(
		[Page_ID],
		[Property_Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ValueList] WITH NOCHECK ADD 
	CONSTRAINT [PK_ValueList] PRIMARY KEY  CLUSTERED 
	(
		[ValueList_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ValueListItem] WITH NOCHECK ADD 
	CONSTRAINT [PK_ValueListItem] PRIMARY KEY  CLUSTERED 
	(
		[ValueListItem_Name],
		[ValueList_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[BaseCodeScript] ADD 
	CONSTRAINT [IX_BaseCodeScript] UNIQUE  NONCLUSTERED 
	(
		[OpCodeHash]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CodeScriptParameters] ADD 
	CONSTRAINT [DF_CodeScriptParameters_Parameter_Position] DEFAULT (1) FOR [Parameter_Position]
GO

 CREATE  INDEX [CodeScriptParameters2] ON [dbo].[CodeScriptParameters]([Code_ID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DataExchangeType] ADD 
	CONSTRAINT [IX_DataExchangeType] UNIQUE  NONCLUSTERED 
	(
		[DX_Type_Name]
	)  ON [PRIMARY] 
GO

 CREATE  INDEX [IX_GraphicDXAssignment] ON [dbo].[GraphicDXAssignment]([DX_Type_ID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[GraphicObject] ADD 
	CONSTRAINT [DF_GraphicObject_GraphicObject_ID] DEFAULT ([dbo].[DefaultGraphicObjectID]()) FOR [GraphicObject_ID]
GO

ALTER TABLE [dbo].[NextGraphicObject] ADD 
	CONSTRAINT [DF_NextGraphicObject_NextGraphicObject_ID] DEFAULT (1) FOR [NextGraphicObject_ID]
GO

 CREATE  INDEX [PropertyValuesForGraphic2] ON [dbo].[PropertyValuesForGraphic]([Page_ID]) ON [PRIMARY]
GO

 CREATE  INDEX [PropertyValuesForGraphic4] ON [dbo].[PropertyValuesForGraphic]([Property_Name]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BuiltItem] ADD 
	CONSTRAINT [FK_BuiltItem_Enum_BuiltItemType] FOREIGN KEY 
	(
		[ItemName_EnumValue]
	) REFERENCES [dbo].[Enum_BuiltItemType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_BuiltItem_LargeObject] FOREIGN KEY 
	(
		[LargeObject_ID]
	) REFERENCES [dbo].[LargeObject] (
		[LargeObject_ID]
	),
	CONSTRAINT [FK_BuiltItem_Product] FOREIGN KEY 
	(
		[Product_Name]
	) REFERENCES [dbo].[Product] (
		[Product_Name]
	)
GO

ALTER TABLE [dbo].[CodeScript] ADD 
	CONSTRAINT [FK_CodeScript_CodeScriptCategory] FOREIGN KEY 
	(
		[CodeScriptCategory_ID]
	) REFERENCES [dbo].[CodeScriptCategory] (
		[CodeScriptCategory_ID]
	),
	CONSTRAINT [FK_CodeScript_DeveloperRole] FOREIGN KEY 
	(
		[DeveloperRole_ID]
	) REFERENCES [dbo].[DeveloperRole] (
		[DeveloperRole_ID]
	),
	CONSTRAINT [FK_CodeScript_Enum_DataType] FOREIGN KEY 
	(
		[Return_Enum_DataType]
	) REFERENCES [dbo].[Enum_DataType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[CodeScriptAssignment] ADD 
	CONSTRAINT [FK_CodeScriptAssignment_CodeScript] FOREIGN KEY 
	(
		[CodeScript_ID]
	) REFERENCES [dbo].[CodeScript] (
		[Code_ID]
	),
	CONSTRAINT [FK_CodeScriptAssignment_Enum_CodeType] FOREIGN KEY 
	(
		[CodeType_EnumValue]
	) REFERENCES [dbo].[Enum_CodeType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[CodeScriptBaseScriptXref] ADD 
	CONSTRAINT [FK_CodeScriptBaseScriptXref_BaseCodeScript] FOREIGN KEY 
	(
		[BaseCodeScript_ID]
	) REFERENCES [dbo].[BaseCodeScript] (
		[BaseCodeScript_ID]
	),
	CONSTRAINT [FK_CodeScriptBaseScriptXref_CodeScript] FOREIGN KEY 
	(
		[CodeScript_ID]
	) REFERENCES [dbo].[CodeScript] (
		[Code_ID]
	)
GO

ALTER TABLE [dbo].[CodeScriptParameters] ADD 
	CONSTRAINT [FK_CodeScriptParameters_CodeScript] FOREIGN KEY 
	(
		[Code_ID]
	) REFERENCES [dbo].[CodeScript] (
		[Code_ID]
	),
	CONSTRAINT [FK_CodeScriptParameters_Enum_DataType] FOREIGN KEY 
	(
		[Parameter_Enum_DataType]
	) REFERENCES [dbo].[Enum_DataType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[CodeScriptTestCase] ADD 
	CONSTRAINT [FK_CodeScriptTestCase_CodeScript] FOREIGN KEY 
	(
		[Code_ID]
	) REFERENCES [dbo].[CodeScript] (
		[Code_ID]
	)
GO

ALTER TABLE [dbo].[CodeScriptTestCaseValues] ADD 
	CONSTRAINT [FK_CodeScriptTestCaseValues_CodeScriptParameters] FOREIGN KEY 
	(
		[Parameter_ID]
	) REFERENCES [dbo].[CodeScriptParameters] (
		[Parameter_ID]
	),
	CONSTRAINT [FK_CodeScriptTestCaseValues_CodeScriptTestCase] FOREIGN KEY 
	(
		[TestCase_ID]
	) REFERENCES [dbo].[CodeScriptTestCase] (
		[TestCase_ID]
	)
GO

ALTER TABLE [dbo].[ComputedObjectDependency] ADD 
	CONSTRAINT [FK_ComputedObjectDependency_CodeScriptAssignment] FOREIGN KEY 
	(
		[CodeScriptAssignment_ID]
	) REFERENCES [dbo].[CodeScriptAssignment] (
		[CodeScriptAssignment_ID]
	),
	CONSTRAINT [FK_ComputedObjectDependency_CodeScriptParameters] FOREIGN KEY 
	(
		[Parameter_ID]
	) REFERENCES [dbo].[CodeScriptParameters] (
		[Parameter_ID]
	),
	CONSTRAINT [FK_ComputedObjectDependency_GraphicObject] FOREIGN KEY 
	(
		[ParameterSource_Object_ID]
	) REFERENCES [dbo].[GraphicObject] (
		[GraphicObject_ID]
	),
	CONSTRAINT [FK_ComputedObjectDependency_Page] FOREIGN KEY 
	(
		[ParameterSource_Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[CurrencyRoundingCode] ADD 
	CONSTRAINT [FK_CurrencyRoundingCode_Product] FOREIGN KEY 
	(
		[Product_Name]
	) REFERENCES [dbo].[Product] (
		[Product_Name]
	)
GO

ALTER TABLE [dbo].[DataExchangeElement] ADD 
	CONSTRAINT [FK_DataExchangeElement_DataExchangeHistory] FOREIGN KEY 
	(
		[DX_History_ID]
	) REFERENCES [dbo].[DataExchangeHistory] (
		[DX_History_ID]
	),
	CONSTRAINT [FK_DataExchangeElement_DataExchangeType] FOREIGN KEY 
	(
		[DX_Type_ID]
	) REFERENCES [dbo].[DataExchangeType] (
		[DX_Type_ID]
	),
	CONSTRAINT [FK_DataExchangeElement_Enum_DataType] FOREIGN KEY 
	(
		[DataType_EnumValue]
	) REFERENCES [dbo].[Enum_DataType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[DataExchangeHistory] ADD 
	CONSTRAINT [FK_DataExchangeHistory_DataExchangeType] FOREIGN KEY 
	(
		[DX_Type_ID]
	) REFERENCES [dbo].[DataExchangeType] (
		[DX_Type_ID]
	),
	CONSTRAINT [FK_DataExchangeHistory_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	)
GO

ALTER TABLE [dbo].[DataLink] ADD 
	CONSTRAINT [FK_DataLink_Enum_DataLinkType] FOREIGN KEY 
	(
		[LinkType_EnumValue]
	) REFERENCES [dbo].[Enum_DataLinkType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_DataLink_GraphicObject] FOREIGN KEY 
	(
		[LinkSource_ID]
	) REFERENCES [dbo].[GraphicObject] (
		[GraphicObject_ID]
	),
	CONSTRAINT [FK_DataLink_GraphicObject1] FOREIGN KEY 
	(
		[LinkTarget_ID]
	) REFERENCES [dbo].[GraphicObject] (
		[GraphicObject_ID]
	),
	CONSTRAINT [FK_DataLink_Page] FOREIGN KEY 
	(
		[LinkTarget_Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	),
	CONSTRAINT [FK_DataLink_Page1] FOREIGN KEY 
	(
		[LinkSource_Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[DeletedPage] ADD 
	CONSTRAINT [FK_DeletedPage_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_DeletedPage_DeveloperRole] FOREIGN KEY 
	(
		[DeveloperRole_ID]
	) REFERENCES [dbo].[DeveloperRole] (
		[DeveloperRole_ID]
	),
	CONSTRAINT [FK_DeletedPage_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[DeveloperFADSXref] ADD 
	CONSTRAINT [FK_DeveloperFADSXref_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_DeveloperFADSXref_FADSArea] FOREIGN KEY 
	(
		[Product_Name],
		[FADS_Area]
	) REFERENCES [dbo].[FADSArea] (
		[Product_Name],
		[FADS_Area]
	)
GO

ALTER TABLE [dbo].[DeveloperRoleXref] ADD 
	CONSTRAINT [FK_DeveloperRoleXref_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_DeveloperRoleXref_DeveloperRole] FOREIGN KEY 
	(
		[DeveloperRole_ID]
	) REFERENCES [dbo].[DeveloperRole] (
		[DeveloperRole_ID]
	)
GO

ALTER TABLE [dbo].[Diagnostic] ADD 
	CONSTRAINT [FK_Diagnostic_CodeScript] FOREIGN KEY 
	(
		[CodeScript_ID]
	) REFERENCES [dbo].[CodeScript] (
		[Code_ID]
	),
	CONSTRAINT [FK_Diagnostic_Enum_DiagnosticSeverity] FOREIGN KEY 
	(
		[Severity]
	) REFERENCES [dbo].[Enum_DiagnosticSeverity] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[FADSArea] ADD 
	CONSTRAINT [FK_FADSArea_Product] FOREIGN KEY 
	(
		[Product_Name]
	) REFERENCES [dbo].[Product] (
		[Product_Name]
	)
GO

ALTER TABLE [dbo].[FADSConstraintDependency] ADD 
	CONSTRAINT [FK_FADSConstraintDependency_CodeScriptAssignment] FOREIGN KEY 
	(
		[CodeScriptAssignment_ID]
	) REFERENCES [dbo].[CodeScriptAssignment] (
		[CodeScriptAssignment_ID]
	),
	CONSTRAINT [FK_FADSConstraintDependency_CodeScriptParameters] FOREIGN KEY 
	(
		[Parameter_ID]
	) REFERENCES [dbo].[CodeScriptParameters] (
		[Parameter_ID]
	)
GO

ALTER TABLE [dbo].[FADSField] ADD 
	CONSTRAINT [FK_FADSFields_Enum_DataType] FOREIGN KEY 
	(
		[Field_Datatype]
	) REFERENCES [dbo].[Enum_DataType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_FADSFields_FADSArea] FOREIGN KEY 
	(
		[Product_Name],
		[FADS_Area]
	) REFERENCES [dbo].[FADSArea] (
		[Product_Name],
		[FADS_Area]
	),
	CONSTRAINT [FK_FADSFields_FADSScreen] FOREIGN KEY 
	(
		[Product_Name],
		[FADS_Area],
		[FADS_Screen]
	) REFERENCES [dbo].[FADSScreen] (
		[Product_Name],
		[FADS_Area],
		[FADS_Screen]
	),
	CONSTRAINT [FK_FADSFields_Product] FOREIGN KEY 
	(
		[Product_Name]
	) REFERENCES [dbo].[Product] (
		[Product_Name]
	)
GO

ALTER TABLE [dbo].[FADSScreen] ADD 
	CONSTRAINT [FK_FADSScreen_FADSArea] FOREIGN KEY 
	(
		[Product_Name],
		[FADS_Area]
	) REFERENCES [dbo].[FADSArea] (
		[Product_Name],
		[FADS_Area]
	),
	CONSTRAINT [FK_FADSScreen_Product] FOREIGN KEY 
	(
		[Product_Name]
	) REFERENCES [dbo].[Product] (
		[Product_Name]
	)
GO

ALTER TABLE [dbo].[GraphicDXAssignment] ADD 
	CONSTRAINT [FK_GraphicDXAssignment_DataExchangeElement] FOREIGN KEY 
	(
		[DX_Element_ID]
	) REFERENCES [dbo].[DataExchangeElement] (
		[DX_Element_ID]
	),
	CONSTRAINT [FK_GraphicDXAssignment_DataExchangeType] FOREIGN KEY 
	(
		[DX_Type_ID]
	) REFERENCES [dbo].[DataExchangeType] (
		[DX_Type_ID]
	),
	CONSTRAINT [FK_GraphicDXAssignment_GraphicObject] FOREIGN KEY 
	(
		[GraphicObject_ID]
	) REFERENCES [dbo].[GraphicObject] (
		[GraphicObject_ID]
	),
	CONSTRAINT [FK_GraphicDXAssignment_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[GraphicObject] ADD 
	CONSTRAINT [FK_GraphicObject_Enum_DataType] FOREIGN KEY 
	(
		[DataType_EnumValue]
	) REFERENCES [dbo].[Enum_DataType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_GraphicObject_Enum_GraphicObjectType] FOREIGN KEY 
	(
		[GraphicObjectType_EnumValue]
	) REFERENCES [dbo].[Enum_GraphicObjectType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_GraphicObject_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	),
	CONSTRAINT [FK_GraphicObject_Page1] FOREIGN KEY 
	(
		[Linked_Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[Holiday] ADD 
	CONSTRAINT [FK_Holiday_Enum_Jurisdiction] FOREIGN KEY 
	(
		[Jurisdiction_EnumValue]
	) REFERENCES [dbo].[Enum_Jurisdiction] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[Navigation] ADD 
	CONSTRAINT [FK_Navigation_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_Navigation_Enum_NavigationType] FOREIGN KEY 
	(
		[NavigationType_EnumValue]
	) REFERENCES [dbo].[Enum_NavigationType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_Navigation_Product] FOREIGN KEY 
	(
		[Product_Name]
	) REFERENCES [dbo].[Product] (
		[Product_Name]
	)
GO

ALTER TABLE [dbo].[NavigationHistory] ADD 
	CONSTRAINT [FK_NavigationHistory_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_NavigationHistory_Navigation] FOREIGN KEY 
	(
		[Navigation_ID]
	) REFERENCES [dbo].[Navigation] (
		[Navigation_ID]
	)
GO

ALTER TABLE [dbo].[NavigationNode] ADD 
	CONSTRAINT [FK_NavigationNode_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	),
	CONSTRAINT [FK_PrintNavigationNode_DeveloperRole] FOREIGN KEY 
	(
		[DeveloperRole_ID]
	) REFERENCES [dbo].[DeveloperRole] (
		[DeveloperRole_ID]
	),
	CONSTRAINT [FK_PrintRuntimeNavigationNode_Enum_PrintNodeType] FOREIGN KEY 
	(
		[NodeType_EnumValue]
	) REFERENCES [dbo].[Enum_NodeType] (
		[Enum_Value]
	),
	CONSTRAINT [FK_PrintRuntimeNavigationNode_Navigation] FOREIGN KEY 
	(
		[Navigation_ID]
	) REFERENCES [dbo].[Navigation] (
		[Navigation_ID]
	)
GO

ALTER TABLE [dbo].[NetworkLogin] ADD 
	CONSTRAINT [FK_NetworkLogin_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	)
GO

ALTER TABLE [dbo].[Page] ADD 
	CONSTRAINT [FK_Page_DeveloperName] FOREIGN KEY 
	(
		[WIP_Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_Page_Enum_PageType] FOREIGN KEY 
	(
		[PageType_EnumValue]
	) REFERENCES [dbo].[Enum_PageType] (
		[Enum_Value]
	)
GO

ALTER TABLE [dbo].[PageHistory] ADD 
	CONSTRAINT [FK_PageHistory_DeveloperName] FOREIGN KEY 
	(
		[Developer_ID]
	) REFERENCES [dbo].[DeveloperName] (
		[Developer_ID]
	),
	CONSTRAINT [FK_PageHistory_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[PropertyValuesForGraphic] ADD 
	CONSTRAINT [FK_PropertyValuesForGraphic_GraphicObject] FOREIGN KEY 
	(
		[GraphicObject_ID]
	) REFERENCES [dbo].[GraphicObject] (
		[GraphicObject_ID]
	),
	CONSTRAINT [FK_PropertyValuesForGraphic_Page1] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[PropertyValuesForNode] ADD 
	CONSTRAINT [FK_PropertyValuesForNode_NavigationNode] FOREIGN KEY 
	(
		[Navigation_Node_ID]
	) REFERENCES [dbo].[NavigationNode] (
		[Navigation_Node_ID]
	)
GO

ALTER TABLE [dbo].[PropertyValuesForPage] ADD 
	CONSTRAINT [FK_PropertyValuesForPage_Page] FOREIGN KEY 
	(
		[Page_ID]
	) REFERENCES [dbo].[Page] (
		[Page_ID]
	)
GO

ALTER TABLE [dbo].[ValueListItem] ADD 
	CONSTRAINT [FK_ValueListItem_ValueList] FOREIGN KEY 
	(
		[ValueList_ID]
	) REFERENCES [dbo].[ValueList] (
		[ValueList_ID]
	)
GO

ALTER TABLE [dbo].[AssignmentGroupXref] ADD 
	CONSTRAINT [FK_AssignmentGroupXref_AssignmentGroup] FOREIGN KEY 
	(
		[AssignmentGroup_ID]
	) REFERENCES [dbo].[AssignmentGroup] (
		[AssignmentGroup_ID]
	),
	CONSTRAINT [FK_AssignmentGroupXref_DeveloperRole] FOREIGN KEY 
	(
		[DeveloperRole_ID]
	) REFERENCES [dbo].[DeveloperRole] (
		[DeveloperRole_ID]
	)
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE VIEW dbo.CodeScriptParameterCount
AS
SELECT DISTINCT 
                      TOP 100 PERCENT Code_ID, SUM(BoolParm) AS BoolParm, SUM(IntParm) AS IntParm, SUM(StrParm) AS StrParm, SUM(DateParm) AS DateParm, 
                      SUM(RatioParm) AS RatioParm, SUM(MoneyParm) AS MoneyParm, SUM(ImageParm) AS ImageParm
FROM         (SELECT     Code_ID, COUNT(Parameter_ID) AS BoolParm, 0 AS IntParm, 0 AS StrParm, 0 AS DateParm, 0 AS RatioParm, 0 AS MoneyParm, 
                                              0 AS ImageParm
                       FROM          CodeScriptParameters
                       WHERE      Parameter_Enum_DataType = 0
                       GROUP BY Code_ID
                       UNION
                       SELECT     Code_ID, 0 AS BoolParm, COUNT(Parameter_ID) AS IntParm, 0 AS StrParm, 0 AS DateParm, 0 AS RatioParm, 0 AS MoneyParm, 
                                             0 AS ImageParm
                       FROM         CodeScriptParameters
                       WHERE     Parameter_Enum_DataType = 1
                       GROUP BY Code_ID
                       UNION
                       SELECT     Code_ID, 0 AS BoolParm, 0 AS IntParm, COUNT(Parameter_ID) AS StrParm, 0 AS DateParm, 0 AS RatioParm, 0 AS MoneyParm, 
                                             0 AS ImageParm
                       FROM         CodeScriptParameters
                       WHERE     Parameter_Enum_DataType = 2
                       GROUP BY Code_ID
                       UNION
                       SELECT     Code_ID, 0 AS BoolParm, 0 AS IntParm, 0 AS StrParm, COUNT(Parameter_ID) AS DateParm, 0 AS RatioParm, 0 AS MoneyParm, 
                                             0 AS ImageParm
                       FROM         CodeScriptParameters
                       WHERE     Parameter_Enum_DataType = 3
                       GROUP BY Code_ID
                       UNION
                       SELECT     Code_ID, 0 AS BoolParm, 0 AS IntParm, 0 AS StrParm, 0 AS DateParm, COUNT(Parameter_ID) AS RatioParm, 0 AS MoneyParm, 
                                             0 AS ImageParm
                       FROM         CodeScriptParameters
                       WHERE     Parameter_Enum_DataType = 7
                       GROUP BY Code_ID
                       UNION
                       SELECT     Code_ID, 0 AS BoolParm, 0 AS IntParm, 0 AS StrParm, 0 AS DateParm, 0 AS RatioParm, COUNT(Parameter_ID) AS MoneyParm, 
                                             0 AS ImageParm
                       FROM         CodeScriptParameters
                       WHERE     Parameter_Enum_DataType = 8
                       GROUP BY Code_ID
                       UNION
                       SELECT     Code_ID, 0 AS BoolParm, 0 AS IntParm, 0 AS StrParm, 0 AS DateParm, 0 AS RatioParm, 0 AS MoneyParm, COUNT(Parameter_ID) 
                                             AS ImageParm
                       FROM         CodeScriptParameters
                       WHERE     Parameter_Enum_DataType = 6
                       GROUP BY Code_ID) a
GROUP BY Code_ID
ORDER BY Code_ID





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE VIEW dbo.DataExchangeAssignment
AS
SELECT     g.Page_ID, g.GraphicObject_ID, g.DX_Type_ID, dt.DX_Type_Name, g.DX_Element_ID, de.DX_Element_Name, de.Annotation
FROM         dbo.GraphicDXAssignment g INNER JOIN
                      dbo.DataExchangeType dt ON g.DX_Type_ID = dt.DX_Type_ID INNER JOIN
                      dbo.DataExchangeElement de ON g.DX_Element_ID = de.DX_Element_ID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE TRIGGER MarkNextGraphicID ON [dbo].[GraphicObject] 
FOR INSERT
AS
update a
set a.NextGraphicObject_ID = b.GraphicObject_ID + 1
from NextGraphicObject a, inserted b




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

