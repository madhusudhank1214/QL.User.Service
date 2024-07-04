﻿CREATE PROCEDURE [dbo].[SaveIdeaTracker]
@Title nvarchar(200),
@IdeaDescription nvarchar(500),
@IdeaType int,
@Benefits nvarchar(200),
@Technology nvarchar(200),
@EstimatedEffort int,
@ActualEffort int,
@AnnualSaving int,
@Status int,
@ResourceName nvarchar(10)

AS
BEGIN

	Declare @EmployeeId int;
	SET @EmployeeId = (SELECT Id from QLEmployees where EmpId=@ResourceName )

	INSERT INTO QLIdeaTracker(Title, IdeaDescription, IdeaType, Benefits, Technology, EstimatedEffort, ActualEffort, 
	AnnualSaving, Status, ResourceName)
	values(@Title, @IdeaDescription, @IdeaType, @Benefits, @Technology, @EstimatedEffort, @ActualEffort,
	@AnnualSaving, @Status, @EmployeeId)
END