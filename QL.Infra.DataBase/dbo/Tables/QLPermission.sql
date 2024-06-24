CREATE TABLE [dbo].[QLPermission] (
    [PermissionId] INT           IDENTITY (1, 1) NOT NULL,
    [Permission]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_QLPermission] PRIMARY KEY CLUSTERED ([PermissionId] ASC)
);

