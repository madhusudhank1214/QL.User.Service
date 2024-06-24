CREATE TABLE [dbo].[QLProjects] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [ProjectId]    VARCHAR (50) NOT NULL,
    [ProjectName]  VARCHAR (80) NULL,
    [CreatedDate]  DATETIME     NULL,
    [EndDate]      DATETIME     NULL,
    [AllottedDate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([ProjectId] ASC)
);

