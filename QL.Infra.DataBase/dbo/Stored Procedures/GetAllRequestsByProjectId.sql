﻿CREATE PROCEDURE [dbo].[GetAllRequestsByProjectId] @ProjectId NVARCHAR(10)
AS
BEGIN
	SELECT 
	ROW_NUMBER() OVER (
			ORDER BY QLW.RequestedDate
			) AS Sl_no
		,QLP.ProjectName AS Project
		,QLW.RequestedDate AS Requested_date
		,QLW.ApprovedDate
		,QLWS.STATUS
		,QLW.Comments
		,QLW.NoOfDays
		,(select E.Name from QLEmployees E where ProjectId=QLE.ProjectId and 
	RoleId=(Select Id from QLRoles where ProjectId=QLE.ProjectId and RoleName='ReportingManager')) AS Approver
	    ,QLE.EmpId AS Emp_id
		,QLW.RequestId AS Req_id
	FROM QLEmployees QLE
	JOIN QLProjects QLP ON QLP.Id = QLE.ProjectId
	JOIN QLWFHRequests QLW ON QLW.EmployeeId = QLE.Id
	JOIN QLWFHStatus QLWS ON QLWS.StatusId = QLW.STATUS
	WHERE QLP.projectId = @ProjectId
END