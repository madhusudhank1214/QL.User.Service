CREATE TABLE [dbo].[QLNotifications] (
    [NotificationId]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]                NVARCHAR (100) NOT NULL,
    [NotificationStatusId] INT            NOT NULL,
    [CreatedDate]          DATETIME       NOT NULL,
    [Approveddate]         DATETIME       NULL,
    [RequestId]            INT            NOT NULL,
    CONSTRAINT [PK_QLNotifications] PRIMARY KEY CLUSTERED ([NotificationId] ASC),
    CONSTRAINT [FK_QLNotifications_QLNotificationStatus] FOREIGN KEY ([NotificationStatusId]) REFERENCES [dbo].[QLNotificationStatus] ([NotificationStatusId]),
    CONSTRAINT [FK_QLNotifications_QLWFHRequests] FOREIGN KEY ([RequestId]) REFERENCES [dbo].[QLWFHRequests] ([RequestId])
);

