CREATE TABLE [dbo].[QLIdeaTracker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[IdeaDescription] [text] NOT NULL,
	[IdeaType] [int] NOT NULL,
	[Benefits] [nvarchar](200) NULL,
	[Technology] [nvarchar](200) NULL,
	[EstimatedEffort] [int] NULL,
	[ActualEffort] [int] NULL,
	[AnnualSaving] [int] NULL,
	[Status] [int] NOT NULL,
	[ResourceName] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[QLIdeaTracker]  WITH CHECK ADD FOREIGN KEY([Status])
REFERENCES [dbo].[QLWFHStatus] ([StatusId])