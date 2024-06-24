CREATE TABLE [dbo].[QLNotificationStatus] (
    [NotificationStatusId] INT           IDENTITY (1, 1) NOT NULL,
    [NotificationStatus]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_QLNotificationStatus] PRIMARY KEY CLUSTERED ([NotificationStatusId] ASC),
    CONSTRAINT [FK_QLNotificationStatus_QLNotificationStatus] FOREIGN KEY ([NotificationStatusId]) REFERENCES [dbo].[QLNotificationStatus] ([NotificationStatusId])
);

