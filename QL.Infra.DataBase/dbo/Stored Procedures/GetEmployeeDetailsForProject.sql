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
	,NULL as Allocation_date
	,NULL as End_date
	,NULL as Id
FROM QLEmployees QLE
JOIN QLProjects QLP ON QLP.Id = QLE.ProjectId
WHERE QLP.ProjectName = @Project
	
END
