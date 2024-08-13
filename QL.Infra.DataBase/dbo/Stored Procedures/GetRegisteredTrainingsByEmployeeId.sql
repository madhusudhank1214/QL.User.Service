CREATE PROCEDURE [dbo].[GetRegisteredTrainingsByEmployeeId]
	@EmployeeId NVARCHAR(10)  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
SELECT RT.[EmpId] EmployeeId  
      ,RT.[ManagerId]  
      ,RT.[TrainingScheduleId]  
      ,RT.[RegisteredDate]  
      ,RT.[UpdatedDate]  
      ,RT.[IsAttended]  
      ,RT.[Iscancelled]
	  ,TS.TOPIC
	  ,TS.FACILITATOR
	  ,TS.STARTDATE AS TRAININGSTARTDATE
	  ,TS.ENDDATE AS TRAININGENDDATE
   , E1.Name EmployeeName  
   , E1.managerid ManagerId  
   , E2.Name AS ManagerName  
  FROM [REGISTERTRAINING] RT  
  JOIN [TRAININGSCHEDULE] TS ON TS.TRAININGID = RT.TrainingScheduleId
  JOIN QLEmployees E1 ON RT.[EmpId] = E1.EmpId  
  JOIN QLEmployees E2 ON E1.managerid = E2.EmpId  
WHERE RT.[EmpId] =  @EmployeeId AND RT.[Iscancelled] = 0 AND TS.ENDDATE > GETDATE()
  
END
