CREATE PROCEDURE [dbo].[SaveRequest]
@RequestId UNIQUEIDENTIFIER,
@EmployeeId nvarchar(50),
@Status int,
@Comments nvarchar(500),
@Fromdate date,
@ToDate date,
@RequestType int

AS
BEGIN

	Declare @NumberOfdays int, @EmpId int;
	SET @NumberOfdays = (SELECT DATEDIFF(d, @Fromdate, @ToDate) )
	SET @EmpId = (SELECT Id from QLEmployees where EmpId=@EmployeeId )

	INSERT INTO QLWFHRequests (RequestId, EmployeeId, RequestType, FromDate, ToDate, Status, NoOfDays, 
	Comments, RequestedDate) VALUES ( @RequestId, @EmpId, @RequestType, @Fromdate, @ToDate, @Status,@NumberOfdays, @Comments, getdate())

	SELECT ROW_NUMBER() OVER (
			ORDER BY QLW.RequestedDate
			) AS Sl_no
		,QLP.ProjectName AS Project
		,QLW.RequestedDate AS Requested_date
		,QLW.ApprovedDate
		,QLWS.STATUS
		,QLW.Comments
		,QLW.NoOfDays
		,QLW.EmployeeId AS Emp_id
		,QLW.RequestId AS Req_id
	FROM QLEmployees QLE
	JOIN QLWFHRequests QLW ON QLW.EmployeeId = QLE.Id
	JOIN QLProjects QLP ON QLP.Id = QLE.ProjectId
	JOIN QLWFHStatus QLWS ON QLWS.StatusId = QLW.STATUS
	WHERE QLE.EmpId = @EmployeeId
	
END