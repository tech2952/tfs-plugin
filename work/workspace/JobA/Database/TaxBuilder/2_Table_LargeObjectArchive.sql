
/****** Object:  Table [dbo].[LargeObject]    Script Date: 11/19/2012 10:41:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LargeObjectArchive](
	ModTime datetime,
	UserId varchar(64),
	[LargeObject_ID] [int] NOT NULL,
	[LargeObject] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

