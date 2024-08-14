CREATE PROCEDURE [dbo].[GetIdeaTracker] @EmployeeId NVARCHAR(10)  
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
JOIN QLEmployees E on E.Id=IT.EmpId  
JOIN QLWFHStatus S on S.StatusId=IT.Status  
WHERE E.EmpId=@EmployeeId
END