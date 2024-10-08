﻿CREATE TABLE [dbo].[QLProjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [varchar](50) NOT NULL,
	[ProjectName] [varchar](80) NULL,
	[CreatedDate] [date] NULL,
	[EndDate] [date] NULL,
	[AllottedDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
/****** Object:  Index [UQ__QLProjec__761ABEF194B7639A]    Script Date: 02-07-2024 15:32:40 ******/
ALTER TABLE [dbo].[QLProjects] ADD UNIQUE NONCLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__QLProjec__761ABEF194B7639A]    Script Date: 04-07-2024 13:40:44 ******/
ALTER TABLE [dbo].[QLProjects] ADD UNIQUE NONCLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]