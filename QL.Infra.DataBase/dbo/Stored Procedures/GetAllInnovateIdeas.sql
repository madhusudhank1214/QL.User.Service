USE [QL_WFH]
GO

/****** Object:  StoredProcedure [dbo].[GetAllInnovateIdeas]    Script Date: 06-08-2024 15:38:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Madhusudhan
-- Create date: 25-07-2024
-- Description:	Get All Innovative Ideas of respect Employee
-- =============================================
CREATE PROCEDURE  [dbo].[GetAllInnovateIdeas]
@EmployeeId NVARCHAR(10)= NULL
AS
BEGIN
SELECT ROW_NUMBER() OVER (  
  ORDER BY IT.Id
  ) AS Sl_no  
  ,IT.Title  
  ,IT.IdeaDescription as Idea_description  
  ,IT.Benefits  
  ,IT.Technology 
  ,E.EmpId AS EmpId  
  ,E.Name AS Resource_name  
FROM QLIdeaTracker IT WITH(NOLOCK) 
JOIN QLEmployees E WITH(NOLOCK) ON E.EmpId=IT.EmpId
WHERE 
  (@EmployeeId IS NULL OR (IT.EmpId = @EmployeeId))
END; 
GO


