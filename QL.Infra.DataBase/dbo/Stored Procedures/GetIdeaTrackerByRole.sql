USE [QL_WFH]
GO

/****** Object:  StoredProcedure [dbo].[GetIdeaTrackerByRole]    Script Date: 06-08-2024 15:40:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Madhusudhan
-- Create date: 25-07-2024
-- Description:	Get All Innovative Ideas of respect Employee
-- =============================================
CREATE PROCEDURE  [dbo].[GetIdeaTrackerByRole] 
	@EmployeeId NVARCHAR(10),
	@RoleId int
AS
BEGIN
	SELECT ROW_NUMBER() OVER (  
  ORDER BY ID.IdeaType  
  ) AS Sl_no  
  ,IT.Title  
  ,IT.IdeaDescription as Idea_description  
  ,ID.IdeaType as Idea_type  
  ,IT.Benefits  
  ,IT.Technology  
  ,IT.EstimatedEffort as Estimated_effort  
  ,IT.ActualEffort as Actual_affort  
  ,IT.AnnualSaving AS Annual_saving  
  ,S.Status AS Status  
  ,E.Name AS Resource_name  
from QLIdeaTracker IT with(nolock) join  
QLIdeaDetails ID on ID.Id= IT.IdeaType  
JOIN QLEmployees E on E.EmpId=IT.EmpId  
JOIN QLWFHStatus S on S.StatusId=IT.Status  
WHERE 
  (@EmployeeId IS NULL OR (E.EmpId = @EmployeeId)) OR E.EmpId in
(select M.EmpId FROM QLEmployees M 
WHERE 
M.ManagerId IN(select e.EmpId EmployeeId FROM   QLEmployees e WHERE @EmployeeId IS NULL OR (E.EmpId = @EmployeeId)))
END;
GO


