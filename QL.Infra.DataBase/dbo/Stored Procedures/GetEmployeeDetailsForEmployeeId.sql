CREATE PROCEDURE [dbo].[GetEmployeeDetailsForEmployeeId]
	 @EmployeeId NVARCHAR(10)
AS
BEGIN
	SELECT Q.EmpId AS EmployeeId
	 ,Q.Name
	 ,Q.Email
	 ,Q.RoleId
	 ,P.Id
	 ,Q.MobileNumber  
	 ,R.RoleName as RoleName
	 ,P.ProjectName as ProjectName
FROM QLEmployees Q join
QLRoles R on R.Id=Q.RoleId join
QLProjects P on P.Id = Q.ProjectId
where Q.EmpId=@EmployeeId
END
