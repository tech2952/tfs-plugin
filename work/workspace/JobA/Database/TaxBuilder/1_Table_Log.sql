
/****** Object:  Table [dbo].[Log]    Script Date: 11/19/2012 10:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Log](
	[ModTime] [datetime] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[LogMessage] [text] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

