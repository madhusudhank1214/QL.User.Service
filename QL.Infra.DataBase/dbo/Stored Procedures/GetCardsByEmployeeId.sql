CREATE PROCEDURE [dbo].[GetCardsByEmployeeId]
	@EmployeeId NVARCHAR(10)
AS
BEGIN
	Declare @TotalRequestCount int, @ApprovedRequestCount int, @RejectedRequestsCount int, @CreatedRequestsCount int

SET @TotalRequestCount = (SELECT COUNT(QLW.RequestId) AS TotalRequestCount
FROM QLEmployees QLE
JOIN QLWFHRequests QLW ON QLW.EmployeeId = QLE.Id
WHERE QLE.EmpId = @EmployeeId)

SET @ApprovedRequestCount = (SELECT COUNT(QLW.RequestId)
FROM QLEmployees QLE
JOIN QLWFHRequests QLW ON QLW.EmployeeId = QLE.Id
JOIN QLWFHStatus QLWS ON QLWS.StatusId = QLW.STATUS
WHERE QLE.EmpId = @EmployeeId AND QLWS.Status='Approved')

SET @RejectedRequestsCount = (SELECT COUNT(QLW.RequestId)
FROM QLEmployees QLE
JOIN QLWFHRequests QLW ON QLW.EmployeeId = QLE.Id
JOIN QLWFHStatus QLWS ON QLWS.StatusId = QLW.STATUS
WHERE QLE.EmpId = @EmployeeId AND QLWS.Status='Rejected')

SET @CreatedRequestsCount = (SELECT COUNT(QLW.RequestId)
FROM QLEmployees QLE
JOIN QLWFHRequests QLW ON QLW.EmployeeId = QLE.Id
JOIN QLWFHStatus QLWS ON QLWS.StatusId = QLW.STATUS
WHERE QLE.EmpId = @EmployeeId AND QLWS.Status='Created')

SELECT Q.Id
		,Q.Icon
		,Q.Title
		,CASE
		 WHEN Q.Title='Total Requests' THEN @TotalRequestCount
		 WHEN Q.Title = 'Approved' THEN @ApprovedRequestCount
		 WHEN Q.Title = 'Rejected' THEN @RejectedRequestsCount
		 WHEN Q.Title = 'New Request' THEN @CreatedRequestsCount
		 END AS Number
		,Q.Color
		,Q.BackgroundColor
FROM QLCards Q
END