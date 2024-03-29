USE [Flight]
GO
/****** Object:  Table [dbo].[FlightSchedule]    Script Date: 30/05/2021 9:12:32 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlightSchedule](
	[FlightCode] [nchar](10) NOT NULL,
	[AirlineCode] [nchar](10) NULL,
	[AirlineName] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[FlightSchedule] ([FlightCode], [AirlineCode], [AirlineName]) VALUES (N'1233      ', N'2134      ', N'321234    ')
INSERT [dbo].[FlightSchedule] ([FlightCode], [AirlineCode], [AirlineName]) VALUES (N'WTF420    ', N'AK47      ', N'PIA       ')
INSERT [dbo].[FlightSchedule] ([FlightCode], [AirlineCode], [AirlineName]) VALUES (N'34        ', N'IDK90     ', N'kuchbhi   ')
INSERT [dbo].[FlightSchedule] ([FlightCode], [AirlineCode], [AirlineName]) VALUES (N'1234      ', N'OK        ', N'BYE       ')
INSERT [dbo].[FlightSchedule] ([FlightCode], [AirlineCode], [AirlineName]) VALUES (N'KHA123    ', N'BABA      ', N'MAMA      ')
GO
