USE [QL_WFH]
GO

/****** Object:  StoredProcedure [dbo].[UpdateIdeaIcons]    Script Date: 06-08-2024 15:32:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Madhusudhan
-- Create date: 05-08-2024
-- Description:	Update Ideas 
-- =============================================
CREATE PROCEDURE [dbo].[UpdateIdeaIcons]
@ID int,
@Icon NVARCHAR(50),
@Title NVARCHAR(50),
@Number int,
@Backgroundcolor NVARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update [dbo].[QLIcons] SET Icon = @Icon, Title=@Title, Number=@Number, 
	Backgroundcolor = @Backgroundcolor where Id= @ID
END
GO


