-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedurE1.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Madhusudhan
-- Create date: 06-08-2024
-- Description:	To Get Ideas Notifications based on EmployeeId
-- =============================================
CREATE PROCEDURE  [dbo].[GetIdeasNotificationsByEmployeeId] 
	-- Add the parameters for the stored procedure here
	@EmployeeId NVARCHAR(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT IT.[Id]
      ,[Title]
      ,[IdeaDescription]
      ,[IdeaType]
      ,[Benefits]
      ,[Technology]
      ,[EstimatedEffort]
      ,[ActualEffort]
      ,[AnnualSaving]
      ,[Status]
	  ,IT.EmpId EmployeeId
	  , E1.Name EmployeeName
	  , E1.managerid ManagerId
	  , E2.Name AS ManagerName
  FROM [dbo].[QLIdeaTracker] IT
  JOIN QLEmployees E1 ON IT.[EmpId] = E1.EmpId
  JOIN QLEmployees E2 ON E1.managerid = E2.EmpId
WHERE IT.EmpId = @EmployeeId

END
GO
