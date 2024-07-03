CREATE PROCEDURE [dbo].[UpdateNotification]
@Title nvarchar(100),
@NotificationStatus int,
@ApprovedDate Date,
@RequestId UNIQUEIDENTIFIER,
@Read bit
AS
BEGIN

	Update QLNotifications SET Title=@Title, NotificationStatusId=@NotificationStatus, 
	Approveddate=@ApprovedDate where RequestId=@RequestId
	
END
