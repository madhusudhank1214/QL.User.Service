CREATE TABLE [dbo].[QLRoles] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]     NVARCHAR (50) NOT NULL,
    [ProjectId]    INT           NOT NULL,
    [PermissionId] INT           NULL,
    [AppId]        INT           NULL,
    CONSTRAINT [PK_QLRoles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_QLRoles_QLApps] FOREIGN KEY ([AppId]) REFERENCES [dbo].[QLApps] ([Id]),
    CONSTRAINT [FK_QLRoles_QLPermission] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[QLPermission] ([PermissionId]),
    CONSTRAINT [FK_QLRoles_QLProjects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[QLProjects] ([Id])
);

