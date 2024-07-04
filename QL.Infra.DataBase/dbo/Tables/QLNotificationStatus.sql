CREATE TABLE [dbo].[QLNotificationStatus](
	[NotificationStatusId] [int] IDENTITY(1,1) NOT NULL,
	[NotificationStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_QLNotificationStatus] PRIMARY KEY CLUSTERED 
(
	[NotificationStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[QLNotificationStatus]  WITH CHECK ADD  CONSTRAINT [FK_QLNotificationStatus_QLNotificationStatus] FOREIGN KEY([NotificationStatusId])
REFERENCES [dbo].[QLNotificationStatus] ([NotificationStatusId])
GO

ALTER TABLE [dbo].[QLNotificationStatus] CHECK CONSTRAINT [FK_QLNotificationStatus_QLNotificationStatus]
GO

