﻿CREATE PROCEDURE [dbo].[GetAppName]
AS
BEGIN
	SELECT 
		 QLA.Id AS Id
		,QLA.AppName AS Name
	FROM QLApps QLA
END