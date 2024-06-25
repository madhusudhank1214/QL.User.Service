CREATE PROCEDURE [dbo].[GetRequestType]
AS
BEGIN
	SELECT 
		 QLR.RequestTypeId AS Id
		,QLR.RequestTypeName AS Name
	FROM QLRequestTypes QLR
END