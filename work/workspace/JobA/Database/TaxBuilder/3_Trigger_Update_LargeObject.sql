/****** Object:  Trigger [dbo].[trigger_largeobject]    Script Date: 11/19/2012 13:37:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trigger_largeobject]
on [dbo].[LargeObject]
for UPDATE
as
	declare @largeObject_ID int
	declare @modtime datetime
	select @largeObject_ID = LargeObject_ID from inserted
	select @modtime = GETDATE()

	--
	-- Create archive
	--
	insert into LargeObjectArchive
	(
		ModTime, 
		UserId, 
		LargeObject_Id,
		LargeObject
	)
	select 
		@modtime, 
		system_user, 
		LargeObject_Id,
		LargeObject 
	from LargeObject 
	where LargeObject_ID = @largeObject_ID
	
	
	--
	-- Create log
	--
	insert into Log(
		ModTime, 
		UserId, 
		LogMessage)
	select 
		@modtime, 
		system_user, 
		'<xml><action>Update LargeObject</action><table>LargeObject</table><message>Updated LargeObject ID: '	+ cast(@largeObject_ID as varchar(64)) + '</message></xml>'
GO

