/****** Object:  Table [dbo].[FadsCHRG]    Script Date: 08/28/2007 15:17:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsCHRG](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsCHRGGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsCHRGGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsCKPT]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsCKPT](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsCKPTGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsCKPTGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsCNST]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsCNST](
	[Area] [smallint] NULL,
	[Screen] [int] NULL,
	[Field] [smallint] NULL,
	[ScrnType] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScrnGroup] [smallint] NULL,
	[Type] [smallint] NULL,
	[TypeDesc] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Length] [smallint] NULL,
	[Timestamp] [datetime] NULL,
	[Data] [varchar](80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsDFLT]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsDFLT](
	[Area] [smallint] NULL,
	[Screen] [int] NULL,
	[Field] [smallint] NULL,
	[ScrnType] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ScrnGroup] [smallint] NULL,
	[Type] [smallint] NULL,
	[TypeDesc] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Length] [smallint] NULL,
	[Timestamp] [datetime] NULL,
	[Data] [varchar](80) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsDvlpTran]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsDvlpTran](
	[key_type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[key_group] [tinyint] NULL,
	[timestamp] [datetime] NULL,
	[type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[path] [varchar](31) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[prefix] [varchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[carries] [tinyint] NULL,
	[description] [varchar](26) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsDvlpXref]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsDvlpXref](
	[key_type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[key_group] [tinyint] NULL,
	[timestamp] [datetime] NULL,
	[name] [varchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[description] [varchar](61) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[minor] [int] NULL,
	[xrefsize] [int] NULL,
	[altksize] [int] NULL,
	[altktype] [int] NULL,
	[altkdups] [int] NULL,
	[uninteresting] [int] NULL,
	[all_grps] [tinyint] NULL,
	[upshift] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[dups] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[unprotected] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[branch] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[length] [tinyint] NULL,
	[mask] [varchar](65) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsEORG]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsEORG](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsEORGGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsEORGGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsEquation]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsEquation](
	[Key_Area] [int] NULL,
	[Key_Screen] [int] NULL,
	[Key_Field] [int] NULL,
	[FldLevel_Area] [int] NULL,
	[FldLevel_Screen] [int] NULL,
	[FldLevel_Field] [int] NULL,
	[FldLevel_Level] [int] NULL,
	[Op] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[seq] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsField]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsField](
	[area] [tinyint] NULL,
	[screen] [int] NULL,
	[field] [tinyint] NULL,
	[type] [tinyint] NULL,
	[typedesc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[row] [tinyint] NULL,
	[col] [tinyint] NULL,
	[len] [tinyint] NULL,
	[prec] [tinyint] NULL,
	[display] [tinyint] NULL,
	[relgrp] [tinyint] NULL,
	[relfld] [tinyint] NULL,
	[dummy_data] [int] NULL,
	[position] [int] NULL,
	[minval] [tinyint] NULL,
	[maxval] [tinyint] NULL,
	[pgm] [int] NULL,
	[branch_area] [tinyint] NULL,
	[branch_screen] [int] NULL,
	[branch_valid] [tinyint] NULL,
	[help_area] [tinyint] NULL,
	[help_screen] [int] NULL,
	[carryfrom_area] [tinyint] NULL,
	[carryfrom_screen] [int] NULL,
	[carryfrom_field] [tinyint] NULL,
	[carryfrom_level] [tinyint] NULL,
	[external_field] [tinyint] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsFieldAttr]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsFieldAttr](
	[area] [tinyint] NULL,
	[screen] [int] NULL,
	[field] [tinyint] NULL,
	[attribute] [int] NULL,
	[attrdesc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsFieldTempAttr]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsFieldTempAttr](
	[area] [tinyint] NULL,
	[screen] [int] NULL,
	[field] [tinyint] NULL,
	[attribute] [int] NULL,
	[attrdesc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsFsrc]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsFsrc](
	[Key_Area] [int] NOT NULL,
	[Key_Screen] [int] NOT NULL,
	[Key_Field] [int] NOT NULL,
	[Type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[timestamp] [datetime] NULL,
	[HeadLoop] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Nops] [int] NULL,
	[src] [varchar](1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsFtrd]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsFtrd](
	[form_0] [smallint] NULL,
	[form_1] [smallint] NULL,
	[form_2] [smallint] NULL,
	[form_3] [smallint] NULL,
	[line_0] [smallint] NULL,
	[line_1] [smallint] NULL,
	[col_0] [smallint] NULL,
	[col_1] [smallint] NULL,
	[set_num] [smallint] NULL,
	[type] [smallint] NULL,
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[timestamp] [datetime] NULL,
	[info_0] [smallint] NULL,
	[info_1] [smallint] NULL,
	[info_2] [smallint] NULL,
	[info_3] [smallint] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsGSRD]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsGSRD](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsGSRDGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsGSRDGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsGSWT]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsGSWT](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsGSWTGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsGSWTGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsLog]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsLog](
	[MsgType] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[msg] [varchar](4096) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[timestamp] [datetime] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CtreeType] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsName]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsName](
	[Area] [tinyint] NULL,
	[Name] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [tinyint] NULL,
	[TypeDesc] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Screen] [int] NULL,
	[Field] [tinyint] NULL,
	[Level] [tinyint] NULL,
	[Timestamp] [datetime] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsOVRD]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsOVRD](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsOVRDGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsOVRDGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsScreen]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsScreen](
	[key_area] [tinyint] NULL,
	[key_screen] [int] NULL,
	[key_field] [tinyint] NULL,
	[key_group] [tinyint] NULL,
	[key_type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[timestamp] [datetime] NULL,
	[map_area] [tinyint] NULL,
	[map_screen] [int] NULL,
	[numflds] [tinyint] NULL,
	[fset] [tinyint] NULL,
	[modified] [tinyint] NULL,
	[dataloaded] [tinyint] NULL,
	[reformatted] [tinyint] NULL,
	[offset] [smallint] NULL,
	[cur] [smallint] NULL,
	[minimum_row] [tinyint] NULL,
	[minimum_col] [tinyint] NULL,
	[maximum_row] [tinyint] NULL,
	[maximum_col] [tinyint] NULL,
	[cmp_past] [smallint] NULL,
	[OnDisplay] [tinyint] NULL,
	[OnUpdate] [tinyint] NULL,
	[OnAccept] [tinyint] NULL,
	[grpbase] [tinyint] NULL,
	[grpflds] [tinyint] NULL,
	[NumGrps] [tinyint] NULL,
	[grplast] [tinyint] NULL,
	[level] [tinyint] NULL,
	[title] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsScrnBranch]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsScrnBranch](
	[key_area] [tinyint] NULL,
	[key_screen] [int] NULL,
	[area] [tinyint] NULL,
	[screen] [int] NULL,
	[valid] [tinyint] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsTran]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsTran](
	[key_numtran] [int] NULL,
	[key_tfld_area] [int] NULL,
	[key_tfld_screen] [int] NULL,
	[key_tfld_field] [int] NULL,
	[key_tfld_level] [int] NULL,
	[key_transtype] [int] NULL,
	[timestamp] [datetime] NULL,
	[sfld_area] [int] NULL,
	[sfld_field] [int] NULL,
	[sfld_screen] [int] NULL,
	[sfld_level] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsTREF]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsTREF](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[level] [smallint] NULL,
	[note] [smallint] NULL,
	[Xref] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsTREFGroup]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsTREFGroup](
	[area] [smallint] NULL,
	[screen] [int] NULL,
	[field] [smallint] NULL,
	[xref_group] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FadsXREF]    Script Date: 08/28/2007 15:17:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FadsXREF](
	[EntityRecIdx] [int] NULL,
	[Name] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Area] [smallint] NULL,
	[Screen] [int] NULL,
	[Field] [smallint] NULL,
	[Level] [smallint] NULL,
	[Note] [smallint] NULL,
	[FadsRecIdx] [int] NULL,
	[Offset] [int] NULL,
	[OffsetRecIdx] [int] NULL,
	[LoadType] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Length] [int] NULL,
	[App] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF