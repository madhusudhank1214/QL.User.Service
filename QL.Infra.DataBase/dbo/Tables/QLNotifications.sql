CREATE TABLE [dbo].[QLNotifications](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[NotificationStatusId] [int] NOT NULL,
	[CreatedDate] [date] NULL,
	[Approveddate] [date] NULL,
	[RequestId] [uniqueidentifier] NOT NULL,
	[Read] [bit] NULL,
	[RejectedReason] [nvarchar](500) NULL,
 CONSTRAINT [PK_QLNotifications] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[QLNotifications]  WITH CHECK ADD  CONSTRAINT [FK_QLNotifications_QLWFHRequests] FOREIGN KEY([RequestId])
REFERENCES [dbo].[QLWFHRequests] ([RequestId])
GO

ALTER TABLE [dbo].[QLNotifications] CHECK CONSTRAINT [FK_QLNotifications_QLWFHRequests]
GO


GO
ALTER TABLE [dbo].[QLNotifications]  WITH CHECK ADD  CONSTRAINT [FK_QLNotifications_QLNotificationStatus] FOREIGN KEY([NotificationStatusId])
REFERENCES [dbo].[QLNotificationStatus] ([NotificationStatusId])
GO

ALTER TABLE [dbo].[QLNotifications] CHECK CONSTRAINT [FK_QLNotifications_QLNotificationStatus]
GO

