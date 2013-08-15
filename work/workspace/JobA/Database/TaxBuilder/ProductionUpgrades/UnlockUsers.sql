USE [TaxBuilder2012]
Update [TaxBuilder2012].[dbo].[DeveloperRoleXref]
Set 
	[IsDisabled] = 0
Where 
	isnull(IsDisabled,1) = 1

Select *
from 
[TaxBuilder2012].[dbo].[DeveloperRoleXref]

--0 on
--1 off
