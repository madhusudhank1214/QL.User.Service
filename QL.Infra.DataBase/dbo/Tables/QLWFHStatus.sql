CREATE TABLE [dbo].[QLWFHStatus] (
    [StatusId] INT           IDENTITY (1, 1) NOT NULL,
    [Status]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_QLWFHStatus] PRIMARY KEY CLUSTERED ([StatusId] ASC)
);

