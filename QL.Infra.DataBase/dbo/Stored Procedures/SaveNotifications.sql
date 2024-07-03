CREATE PROCEDURE [dbo].[SaveNotifications]
@Title nvarchar(100),
@NotificationStatus int,
@CreatedDate Date,
@RequestId UNIQUEIDENTIFIER,
@Read bit
AS
BEGIN
Insert into QLNotifications (Title, NotificationStatusId, CreatedDate, RequestId, [Read])
values(@Title, @NotificationStatus, @CreatedDate, @RequestId,  @Read)
END

