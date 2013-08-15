
declare @BOOLEANVALUE bit
declare @BUILDINGCOUNT smallint
declare @BUILDINGNAME varchar(500)
declare @BUILDINGPARENTID int
declare @BULBAREACOUNT smallint
declare @BULBAREANAME varchar(500)
declare @PARTNERNAME varchar(500)
declare @BULBAREAPARENTID int
declare @PARTNERRATIO  numeric(6,5)
declare @CITYCOUNT smallint
declare @CITYNAME varchar(500)
declare @CITYPARENTID int
declare @COUNTRYCOUNT smallint
declare @COUNTRYNAME varchar(500)
declare @DATATYPE tinyint
declare @DATEVALUE  datetime
declare @GRAPHICOBJECTID int
declare @LOCATORID int
declare @LOCATORNAME varchar(500)
declare @MONEYVALUE numeric(22,2)
declare @NUMOFBULBAREAS smallint
declare @NUMOFBUILDINGS smallint
declare @NUMOFCITIES smallint 
declare @NUMOFCOUNTRIES smallint
declare @NUMOFPARTNERS smallint
declare @PAGEID int
declare @PRODUCTYEAR smallint
declare @RATIOVALUE numeric(20,9)
declare @RECORDID int
declare @RECORDLINEAGE int
declare @ROWDISPLAY int
declare @STRINGVALUE varchar(500)
declare @CLIENTID int
declare @POPULATEHALFTHEBUILDINGS char(1)
declare @PARTNERRESIDENCE bit
declare @PARTNERCOUNT smallint
declare @COUNTRYPARENTID int
declare @NUMERATOR numeric(6,5)



select @LOCATORNAME = 'LineageTest'
select @PRODUCTYEAR = 2007
select @NUMOFCOUNTRIES = 2
select @NUMOFCITIES = 2
select @NUMOFBUILDINGS = 2
select @NUMOFBULBAREAS = 2
select @NUMOFPARTNERS = 2
select @POPULATEHALFTHEBUILDINGS = 'N'
select @NUMERATOR = 1

/*********************  Populate Client data ***********/
insert into Client (Product_Year, Client_Name, Firm_Code, Account_Code, Product_License)
values (@PRODUCTYEAR, 'Multinational Conglomerate', 'SomeFirm', 'SomeAcct', 'SomeLicense')

select @CLIENTID = @@IDENTITY

/*********************  Populate Locator    ************/
insert into Locator (Product_Year, Locator_Name, TaxPeriod)
  values (@PRODUCTYEAR, @LOCATORNAME, 'MyTaxPeriod')

select @LOCATORID = @@IDENTITY

/*********************  Populate ClientLocator data ***********/
insert into ClientLocator (Product_Year, Client_ID, Locator_ID, IsTaxDefault)
values (@PRODUCTYEAR, @CLIENTID ,@LOCATORID,0)


/*********************  Populate LocatorObjectRecord and LocatorObjectValue    ************/
--Business Info
   select @PAGEID = 8
   select @GRAPHICOBJECTID = 64
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = 'ACME LIGHT BULBS'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 65
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = '123 Main Street'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 66
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = 'Anytown'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 67
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = 'TX'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 68
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = '123456789'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 69
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = '123456789'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 70
   select @DATATYPE = 2
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @STRINGVALUE = '1234567890'
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @STRINGVALUE, CURRENT_TIMESTAMP)

   select @GRAPHICOBJECTID = 75
   select @DATATYPE = 8
   select @ROWDISPLAY = 1
   select @RECORDLINEAGE = 0
   select @MONEYVALUE = 2
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @ROWDISPLAY, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
   values (@RECORDID, 0, @MONEYVALUE, CURRENT_TIMESTAMP)

--Country Names
select @COUNTRYCOUNT = 1
while (@COUNTRYCOUNT <= @NUMOFCOUNTRIES)
begin
   select @PAGEID = 3
   select @GRAPHICOBJECTID = 32
   select @DATATYPE = 2
   select @RECORDLINEAGE = 0
   select @COUNTRYNAME = ('COUNTRY ' + CAST(@COUNTRYCOUNT as varchar(10)))
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @COUNTRYCOUNT, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @COUNTRYNAME, CURRENT_TIMESTAMP)
   --insert default values for computed column
   select @CITYPARENTID = @RECORDID
   --select @GRAPHICOBJECTID = 35
   --select @DATATYPE = 1
   select @RECORDLINEAGE = 0
   /*
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @COUNTRYCOUNT, @RECORDLINEAGE, 1)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
   values (@RECORDID, 1, 0, CURRENT_TIMESTAMP)
*/
   --insert or update the LocatorGridRow table
   select @GRAPHICOBJECTID = 31

   if exists (select 1 from LocatorGridRow
		where Product_Year = @PRODUCTYEAR
		and Locator_ID = @LOCATORID
		and Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICOBJECTID
		and Record_Lineage = @RECORDLINEAGE)
   begin -- update the table
	update LocatorGridRow
	set Row_Count = @COUNTRYCOUNT
	where Product_Year = @PRODUCTYEAR
	and Locator_ID = @LOCATORID
	and Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICOBJECTID
	and Record_Lineage = @RECORDLINEAGE
   end
   else begin  --insert a new record
	insert into LocatorGridRow (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, Record_Lineage, Row_Count)
	values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @RECORDLINEAGE, @COUNTRYCOUNT)
   end
/*
   --insert default values for single textbox on City detail page
   select @PAGEID = 4 
   select @GRAPHICOBJECTID = 38
   select @DATATYPE = 2
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, 0, @CITYPARENTID, 1)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 1, '', CURRENT_TIMESTAMP)
*/
----For each Country, add City names
   
   select @CITYCOUNT = 1
   while (@CITYCOUNT <= @NUMOFCITIES)
   begin
     select @PAGEID = 4
     select @GRAPHICOBJECTID = 40
     select @DATATYPE = 2
     select @CITYNAME = ('CITY ' + CAST(@CITYCOUNT as varchar(10)) + ' of ' + @COUNTRYNAME)
     insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
     values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @CITYCOUNT, @CITYPARENTID, 0)
     select @RECORDID = @@IDENTITY
     insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
     values (@RECORDID, 0, @CITYNAME, CURRENT_TIMESTAMP)

     select @BUILDINGPARENTID = @RECORDID
/*
     --insert default values for computed column
     select @GRAPHICOBJECTID = 41
     select @DATATYPE = 1
        
     insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
     values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @CITYCOUNT, @CITYPARENTID, 1)
     select @RECORDID = @@IDENTITY
     insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
     values (@RECORDID, 1, 0, CURRENT_TIMESTAMP)
*/
     --insert or update the LocatorGridRow table
     select @GRAPHICOBJECTID = 39

     if exists (select 1 from LocatorGridRow
		where Product_Year = @PRODUCTYEAR
		and Locator_ID = @LOCATORID
		and Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICOBJECTID
		and Record_Lineage = @CITYPARENTID)
     begin -- update the table
	update LocatorGridRow
	set Row_Count = @CITYCOUNT
	where Product_Year = @PRODUCTYEAR
	and Locator_ID = @LOCATORID
	and Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICOBJECTID
	and Record_Lineage = @CITYPARENTID
     end
     else begin  --insert a new record
	insert into LocatorGridRow (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, Record_Lineage, Row_Count)
	values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @CITYPARENTID, @CITYCOUNT)
     end
/*
     --insert default for single computed textbox on building detail page
     select @PAGEID = 5
     select @GRAPHICOBJECTID = 42
     select @DATATYPE = 2

     insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
     values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, 0, @BUILDINGPARENTID, 1)
     select @RECORDID = @@IDENTITY
     insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
     values (@RECORDID, 1, '', CURRENT_TIMESTAMP)
*/
------For each City, add Building Names
     
     select @BUILDINGCOUNT = 1
     while (@BUILDINGCOUNT <= @NUMOFBUILDINGS)
     begin
        select @PAGEID = 5
        select @GRAPHICOBJECTID = 44
        select @DATATYPE = 2
        select @BUILDINGNAME = ('Bldg ' + CAST(@BUILDINGCOUNT as varchar(10)) + ' of ' + @CITYNAME)
        insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
        values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @BUILDINGCOUNT, @BUILDINGPARENTID, 0)
        select @RECORDID = @@IDENTITY
        insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
        values (@RECORDID, 0, @BUILDINGNAME, CURRENT_TIMESTAMP)

	--insert default values for computed single textbox
	select @BULBAREAPARENTID = @RECORDID
	
/*
        --insert default values for computed column
       
        select @GRAPHICOBJECTID = 45
        select @DATATYPE = 1
        
        insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
        values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @BUILDINGCOUNT, @BUILDINGPARENTID, 1)
        select @RECORDID = @@IDENTITY
        insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
        values (@RECORDID, 1, 0, CURRENT_TIMESTAMP)
*/
	--insert or update the LocatorGridRow table
     	select @GRAPHICOBJECTID = 43

     	if exists (select 1 from LocatorGridRow
		where Product_Year = @PRODUCTYEAR
		and Locator_ID = @LOCATORID
		and Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICOBJECTID
		and Record_Lineage = @BUILDINGPARENTID)
    	 begin -- update the table
		update LocatorGridRow
		set Row_Count = @BUILDINGCOUNT
		where Product_Year = @PRODUCTYEAR
		and Locator_ID = @LOCATORID
		and Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICOBJECTID
		and Record_Lineage = @BUILDINGPARENTID
     	end
     	else begin  --insert a new record
		insert into LocatorGridRow (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, Record_Lineage, Row_Count)
		values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @BUILDINGPARENTID, @BUILDINGCOUNT)
     	end
/*
        --insert default value for computed single field on detail page
	select @PAGEID = 7
	select @GRAPHICOBJECTID = 47
        select @DATATYPE = 2

	insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
        values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, 0, @BULBAREAPARENTID, 1)
        select @RECORDID = @@IDENTITY
        insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
        values (@RECORDID, 1, '', CURRENT_TIMESTAMP)
*/
--------For each Building, add Bulb Area Descriptions, # of Incandescents, and # of Fluorescents
        if (((@POPULATEHALFTHEBUILDINGS = 'Y') and ((@BUILDINGCOUNT % 2) = 1)) OR (@POPULATEHALFTHEBUILDINGS = 'N'))
	begin --Populate half or all
        
        select @BULBAREACOUNT = 1
        while (@BULBAREACOUNT <= @NUMOFBULBAREAS)
        begin
	  
           select @PAGEID = 7
           select @GRAPHICOBJECTID = 49
           select @DATATYPE = 2
           select @BULBAREANAME = ('Area ' + CAST(@BULBAREACOUNT as varchar(10)) + ' of ' + @BUILDINGNAME)
           insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
           values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @BULBAREACOUNT, @BULBAREAPARENTID, 0)
           select @RECORDID = @@IDENTITY
           insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
           values (@RECORDID, 0, @BULBAREANAME, CURRENT_TIMESTAMP)

	   select @DATATYPE = 1
           select @GRAPHICOBJECTID = 52
           select @MONEYVALUE = 1
           insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
           values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @BULBAREACOUNT, @BULBAREAPARENTID, 0)
           select @RECORDID = @@IDENTITY
           insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
           values (@RECORDID, 0, @MONEYVALUE, CURRENT_TIMESTAMP)

	   select @GRAPHICOBJECTID = 53
           select @MONEYVALUE = 1
           insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
           values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @BULBAREACOUNT, @BULBAREAPARENTID, 0)
           select @RECORDID = @@IDENTITY
           insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
           values (@RECORDID, 0, @MONEYVALUE, CURRENT_TIMESTAMP)

	  
/*
	   --insert default values for computed column
           select @GRAPHICOBJECTID = 50
           select @DATATYPE = 1
        
           insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
           values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @BULBAREACOUNT, @BULBAREAPARENTID, 1)
           select @RECORDID = @@IDENTITY
           insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, NumericValue, DateLastSaved)
           values (@RECORDID, 1, 0, CURRENT_TIMESTAMP)
*/
	   --insert or update the LocatorGridRow table
     	   select @GRAPHICOBJECTID = 48

     	   if exists (select 1 from LocatorGridRow
		where Product_Year = @PRODUCTYEAR
		and Locator_ID = @LOCATORID
		and Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICOBJECTID
		and Record_Lineage = @BULBAREAPARENTID)
    	   begin -- update the table
		update LocatorGridRow
		set Row_Count = @BULBAREACOUNT
		where Product_Year = @PRODUCTYEAR
		and Locator_ID = @LOCATORID
		and Page_ID = @PAGEID
		and GraphicObject_ID = @GRAPHICOBJECTID
		and Record_Lineage = @BULBAREAPARENTID
     	  end
     	  else begin  --insert a new record
		insert into LocatorGridRow (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, Record_Lineage, Row_Count)
		values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @BULBAREAPARENTID, @BULBAREACOUNT)
     	  end

           select @BULBAREACOUNT = @BULBAREACOUNT + 1
         end -- while bulbarea
	 end --Populate half or all
      select @BUILDINGCOUNT = @BUILDINGCOUNT + 1
      end -- while building

   select @CITYCOUNT = @CITYCOUNT + 1
   end -- while city
select @COUNTRYCOUNT = @COUNTRYCOUNT + 1
end --while country

/****POPULATE THE PARTNERS *****/
select @PARTNERRATIO = (@NUMERATOR / @NUMOFPARTNERS)
select @PARTNERCOUNT = 1
while (@PARTNERCOUNT <= @NUMOFPARTNERS)
begin
   select @PAGEID = 9
   select @GRAPHICOBJECTID = 80
   select @DATATYPE = 2
   select @RECORDLINEAGE = 0
   select @PARTNERNAME = ('PARTNER ' + CAST(@PARTNERCOUNT as varchar(10)))
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @PARTNERCOUNT, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, @PARTNERNAME, CURRENT_TIMESTAMP)
   
   select @COUNTRYPARENTID = @RECORDID
   --State Abbreviation
   select @GRAPHICOBJECTID = 82
   select @DATATYPE = 2
   select @RECORDLINEAGE = 0
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @PARTNERCOUNT, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 0, 'TX', CURRENT_TIMESTAMP)

--Residence Status
   if ((@PARTNERCOUNT%2) = 0)
   begin
     select @PARTNERRESIDENCE = 0
   end
   else begin
     select @PARTNERRESIDENCE = 1
   end
   select @GRAPHICOBJECTID = 84
   select @DATATYPE = 0
   select @RECORDLINEAGE = 0
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @PARTNERCOUNT, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, BooleanValue, DateLastSaved)
   values (@RECORDID, 0, @PARTNERRESIDENCE, CURRENT_TIMESTAMP)

--Allocation Ratio
   select @GRAPHICOBJECTID = 85
   select @DATATYPE = 7
   select @RECORDLINEAGE = 0
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, @PARTNERCOUNT, @RECORDLINEAGE, 0)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, FractionValue, DateLastSaved)
   values (@RECORDID, 0, @PARTNERRATIO, CURRENT_TIMESTAMP)

   --insert or update the LocatorGridRow table
   select @GRAPHICOBJECTID = 79

   if exists (select 1 from LocatorGridRow
	where Product_Year = @PRODUCTYEAR
	and Locator_ID = @LOCATORID
	and Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICOBJECTID
	and Record_Lineage = @RECORDLINEAGE)
    begin -- update the table
	update LocatorGridRow
	set Row_Count = @PARTNERCOUNT
	where Product_Year = @PRODUCTYEAR
	and Locator_ID = @LOCATORID
	and Page_ID = @PAGEID
	and GraphicObject_ID = @GRAPHICOBJECTID
	and Record_Lineage = @RECORDLINEAGE
     end
     else begin  --insert a new record
	insert into LocatorGridRow (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, Record_Lineage, Row_Count)
	values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @RECORDLINEAGE, @PARTNERCOUNT)
     end

   --insert default values for Partner Country detail page
   select @PAGEID = 10 
   select @GRAPHICOBJECTID = 88
   select @DATATYPE = 2
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, 0, @COUNTRYPARENTID, 1)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 1, '', CURRENT_TIMESTAMP)
/*
----CountryName (column)
   select @GRAPHICOBJECTID = 90
   select @DATATYPE = 2
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, 1, @COUNTRYPARENTID, 1)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, StringValue, DateLastSaved)
   values (@RECORDID, 1, '', CURRENT_TIMESTAMP)
----Total Bulbs (column)
   select @GRAPHICOBJECTID = 91
   select @DATATYPE = 7
   insert into LocatorObjectRecord (Product_Year, Locator_ID, Page_ID, GraphicObject_ID, DataType_EnumValue,
			Row_DisplayOrder, Record_Lineage, DataSourceUsed)
   values (@PRODUCTYEAR, @LOCATORID, @PAGEID, @GRAPHICOBJECTID, @DATATYPE, 1, @COUNTRYPARENTID, 1)
   select @RECORDID = @@IDENTITY
   insert into LocatorObjectValue (Record_ID, DataSource_EnumValue, FractionValue, DateLastSaved)
   values (@RECORDID, 1, 0, CURRENT_TIMESTAMP)

 */

select @PARTNERCOUNT = @PARTNERCOUNT + 1
end --while country