CREATE PROCEDURE [dbo].[GetAllRequestCountByEmployeeId] @EmployeeId NVARCHAR(10)
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

select @TotalRequestCount AS TotalRequestCount,@ApprovedRequestCount AS ApprovedRequestCount, 
@RejectedRequestsCount AS RejectedRequestsCount, @CreatedRequestsCount AS CreatedRequestsCount
END