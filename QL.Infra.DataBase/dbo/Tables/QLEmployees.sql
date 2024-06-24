CREATE TABLE [dbo].[QLEmployees] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [EmpId]        NVARCHAR (10)  NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL,
    [RoleId]       INT            NOT NULL,
    [ProjectId]    INT            NOT NULL,
    [MobileNumber] INT            NULL,
    CONSTRAINT [PK_QLEmployees] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QLEmployees_QLProjects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[QLProjects] ([Id]),
    CONSTRAINT [FK_QLEmployees_QLRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[QLRoles] ([Id])
);

