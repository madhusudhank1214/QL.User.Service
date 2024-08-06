USE [QL_WFH]
GO

/****** Object:  StoredProcedure [dbo].[SaveIdeaIcons]    Script Date: 06-08-2024 15:32:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Madhusudhan
-- Create date: 05-08-2024
-- Description:	Save Ideas 
-- =============================================
CREATE PROCEDURE [dbo].[SaveIdeaIcons]
@Icon NVARCHAR(50),
@Title NVARCHAR(50),
@Number int,
@Backgroundcolor NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[QLIcons] (
[Icon],[Title],[Number],[Backgroundcolor])
VALUES(
@Icon, @Title, @Number, @Backgroundcolor)
END
GO


