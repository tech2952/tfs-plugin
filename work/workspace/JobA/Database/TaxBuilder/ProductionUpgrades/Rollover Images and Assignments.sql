--This process will rollover the year-specific form images from the old year to the new year.
-- The new year images will be assigned a version of 0.00
-- Pages assigned to the old year images will be assigned to the new image
USE [TaxBuilder2012]

declare @OLDYEAR char(1)
declare @NEWYEAR char(1)

select @OLDYEAR = '1' --2011
select @NEWYEAR = '2' --2012

declare @IMAGEINFO_ID int
declare @IMAGENAME varchar(50)
declare @IMAGE_ID int
declare @FILENAME varchar(50)
declare @JURISDICTION varchar(50)
declare @DOCUMENTCODE varchar(10)
declare @IMAGESIZE int
declare @DATECREATED datetime
declare @NEW_IMAGEINFO_ID int
declare @NEW_IMAGE_ID int
declare @NEW_FILENAME varchar(50)
declare @NEW_DOCUMENTCODE varchar(10)

--Copy the max version of the used year-specific forms to the next year.
declare AnnualImages CURSOR FOR
select ii.ImageInfo_ID, ii.Document_Code, ii.Image_Name, ii.FileName, ii.Jurisdiction, ii.ImageSize, ii.Image_ID, ii.DateCreated
from TaxBuilderImages.dbo.ImageInfo ii, TaxBuilderImages.dbo.ImageInfo i2
where substring(ii.Document_Code, 1,1) = @OLDYEAR
and ii.ImageInfo_ID = i2.ImageInfo_ID
and i2.Version = (select max(i3.Version) from TaxBuilderImages.dbo.ImageInfo i3
			where i3.Document_Code = i2.Document_Code)

Open AnnualImages

Fetch Next From AnnualImages into @IMAGEINFO_ID, @DOCUMENTCODE, @IMAGENAME, @FILENAME, @JURISDICTION, 
									@IMAGESIZE, @IMAGE_ID, @DATECREATED
While @@FETCH_STATUS = 0
BEGIN

----Loop thru them:
------ImageObject table
insert into TaxBuilderImages.dbo.ImageObject (ImageObject)
select io.ImageObject
from TaxBuilderImages.dbo.ImageObject io
where io.Image_ID = @IMAGE_ID

select @NEW_IMAGE_ID = @@IDENTITY

select @NEW_DOCUMENTCODE = STUFF(@DOCUMENTCODE,1,1,@NEWYEAR)
select @NEW_FILENAME = STUFF(@FILENAME,1,1,@NEWYEAR)

------ImageInfo table, resetting the new year forms to version '0.00'

insert into TaxBuilderImages.dbo.ImageInfo (Version, Image_Name, Image_ID, FileName, Jurisdiction, Document_Code, ImageSize, ImageType, 
						IsDraftForm, DateCreated, DateLastSaved)
values (0.00, @IMAGENAME, @NEW_IMAGE_ID, @NEW_FILENAME, @JURISDICTION, @NEW_DOCUMENTCODE, @IMAGESIZE, '.wmf',
						0,@DATECREATED, CURRENT_TIMESTAMP)

select @NEW_IMAGEINFO_ID = @@IDENTITY

--Reset the old-year page assignments, by Document_Code, to the new year forms.
update pp
set pp.Property_Value = @NEW_IMAGEINFO_ID
from TaxBuilder2010.dbo.PropertyValuesForPage pp, TaxBuilderImages.dbo.ImageInfo i4
where pp.Property_Name = 'Page.Background.ImageInfo_ID'
and pp.Property_Value = i4.ImageInfo_ID
and i4.Document_Code = @DOCUMENTCODE

	Fetch Next From AnnualImages into @IMAGEINFO_ID, @DOCUMENTCODE, @IMAGENAME, @FILENAME, @JURISDICTION, 
									@IMAGESIZE, @IMAGE_ID, @DATECREATED
END
close AnnualImages
deallocate AnnualImages
