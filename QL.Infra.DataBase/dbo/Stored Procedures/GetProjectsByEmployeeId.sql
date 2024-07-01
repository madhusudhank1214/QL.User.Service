CREATE PROCEDURE [dbo].[GetProjectsByEmployeeId]
	@EmployeeId NVARCHAR(10)
AS
BEGIN
	SELECT ROW_NUMBER() OVER (
			ORDER BY QLP.ProjectId
			) AS Sl_no
		,QLP.ProjectName AS Project
		,QLP.ProjectId AS id
	FROM QLEmployees QLE
	JOIN QLProjects QLP ON QLP.Id = QLE.ProjectId
	WHERE QLE.EmpId = @EmployeeId
END
