CREATE PROCEDURE [dbo].[UpdateRequestStatus]
@RequestId UNIQUEIDENTIFIER,
@Status int
AS
BEGIN

	Update QLWFHRequests SET Status=@Status where RequestId= @RequestId

	Update QLNotifications SET NotificationStatusId=@Status where RequestId=@RequestId
	
END
