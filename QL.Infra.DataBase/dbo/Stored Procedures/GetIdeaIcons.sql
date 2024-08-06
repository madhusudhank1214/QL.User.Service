USE [QL_WFH]
GO

/****** Object:  StoredProcedure [dbo].[GetIdeaIcons]    Script Date: 06-08-2024 15:31:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Madhusudhan
-- Create date: 05-08-2024
-- Description:	gET Ideas 
-- =============================================
CREATE PROCEDURE  [dbo].[GetIdeaIcons]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id],[Icon],[Title],[Number],[Backgroundcolor] FROM [dbo].[QLIcons]
END
GO


