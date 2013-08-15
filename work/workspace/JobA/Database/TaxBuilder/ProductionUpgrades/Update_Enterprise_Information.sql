USE [TaxBuilder2012]
--Run this to update the connection string for the Image database  
Update Enterprise_Information
Set Product_Year = 2012

Update Enterprise_Information
Set ImageDB_ConnectionString = 'data source=cr-tasql-a02r,1600;initial catalog=TaxBuilderImages;integrated security=SSPI;persist security info=False;packet size=4096'
