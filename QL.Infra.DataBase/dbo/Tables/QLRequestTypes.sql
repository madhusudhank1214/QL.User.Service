CREATE TABLE [dbo].[QLRequestTypes] (
    [RequestTypeId]   INT          IDENTITY (1, 1) NOT NULL,
    [RequestTypeName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_QLAppName] PRIMARY KEY CLUSTERED ([RequestTypeId] ASC)
);

