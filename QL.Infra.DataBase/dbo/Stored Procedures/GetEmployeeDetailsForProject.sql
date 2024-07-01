CREATE PROCEDURE [dbo].[GetEmployeeDetailsForProject]
	@Project NVARCHAR(10)
AS
BEGIN

SELECT ROW_NUMBER() OVER (
		ORDER BY QLP.ProjectName
		) AS Sl_no
	,QLE.EmpId AS Emp_id
	,QLE.Email AS Email
	,QLP.ProjectName AS Project
	,QLE.AllocationDate as Allocation_date
	,QLE.EndDate as End_date
FROM QLEmployees QLE
JOIN QLProjects QLP ON QLP.Id = QLE.ProjectId
WHERE QLP.ProjectName = @Project
	
END
