CREATE PROCEDURE [dbo].[GetStatus]
AS
BEGIN
	SELECT 
		 QLS.StatusId AS Id
		,QLS.Status AS Name
	FROM QLWFHStatus QLS
END
