CREATE TABLE [dbo].[QLWFHRequests](
	[RequestId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[RequestType] [int] NOT NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
	[Status] [int] NOT NULL,
	[NoOfDays] [int] NOT NULL,
	[Comments] [nvarchar](500) NULL,
	[RequestedDate] [date] NULL,
	[ApprovedDate] [date] NULL,
 CONSTRAINT [PK_QLWFHRequests] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[QLWFHRequests]  WITH CHECK ADD  CONSTRAINT [FK_QLWFHRequests_QLWFHStatus] FOREIGN KEY([Status])
REFERENCES [dbo].[QLWFHStatus] ([StatusId])
GO

ALTER TABLE [dbo].[QLWFHRequests] CHECK CONSTRAINT [FK_QLWFHRequests_QLWFHStatus]
GO


GO
ALTER TABLE [dbo].[QLWFHRequests]  WITH CHECK ADD  CONSTRAINT [FK_QLWFHRequests_QLRequestTypes] FOREIGN KEY([RequestType])
REFERENCES [dbo].[QLRequestTypes] ([RequestTypeId])
GO

ALTER TABLE [dbo].[QLWFHRequests] CHECK CONSTRAINT [FK_QLWFHRequests_QLRequestTypes]
GO


GO
ALTER TABLE [dbo].[QLWFHRequests]  WITH CHECK ADD  CONSTRAINT [FK_QLWFHRequests_QLEmployees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[QLEmployees] ([Id])
GO

ALTER TABLE [dbo].[QLWFHRequests] CHECK CONSTRAINT [FK_QLWFHRequests_QLEmployees]
GO

