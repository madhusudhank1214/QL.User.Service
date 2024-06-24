CREATE TABLE [dbo].[QLWFHRequests] (
    [RequestId]   INT            IDENTITY (1, 1) NOT NULL,
    [EmployeeId]  INT            NOT NULL,
    [RequestType] INT            NOT NULL,
    [FromDate]    DATETIME       NOT NULL,
    [ToDate]      DATETIME       NOT NULL,
    [Status]      INT            NOT NULL,
    [NoOfDays]    INT            NOT NULL,
    [Comments]    NVARCHAR (500) NULL,
    [RequestedDate] DATETIME NOT NULL, 
    [ApprovedDate] DATETIME NOT NULL, 
    CONSTRAINT [PK_QLWFHRequests] PRIMARY KEY CLUSTERED ([RequestId] ASC),
    CONSTRAINT [FK_QLWFHRequests_QLEmployees] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[QLEmployees] ([Id]),
    CONSTRAINT [FK_QLWFHRequests_QLRequestTypes] FOREIGN KEY ([RequestType]) REFERENCES [dbo].[QLRequestTypes] ([RequestTypeId]),
    CONSTRAINT [FK_QLWFHRequests_QLWFHStatus] FOREIGN KEY ([Status]) REFERENCES [dbo].[QLWFHStatus] ([StatusId])
);

