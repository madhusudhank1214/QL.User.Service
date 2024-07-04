CREATE PROCEDURE [dbo].[GetNotificationsByEmployeeId] 
	@EmployeeId NVARCHAR(10)
AS
BEGIN
	SELECT ROW_NUMBER() OVER (
		ORDER BY N.NotificationId
		) AS Sl_no
		,N.Title
		,NS.NotificationStatus as Notification_status
		,N.CreatedDate as Created_date
		,N.Approveddate as Approved_date
		,N.RequestId as Request_id
		,N.[Read]
		,N.RejectedReason as Rejected_reason
from QLNotifications N with(nolock)
join QLNotificationStatus NS on NS.NotificationStatusId= N.NotificationStatusId
join QLWFHRequests R on R.RequestId = N.RequestId
join QLEmployees E on E.Id = R.EmployeeId
where E.EmpId=@EmployeeId

END
