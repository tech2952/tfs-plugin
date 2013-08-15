USE [TaxBuilder2012]
Update [TaxBuilder2012].[dbo].[DeveloperRoleXref]
Set 
	[IsDisabled] = 1
Where 
	isnull(IsDisabled,0) = 0

Select *
from 
[TaxBuilder2012].[dbo].[DeveloperRoleXref]

--0 on
--1 off
