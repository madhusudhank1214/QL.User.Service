﻿CREATE TABLE [dbo].[QLRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[PermissionId] [int] NULL,
	[AppId] [int] NULL,
 CONSTRAINT [PK_QLRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]


GO
ALTER TABLE [dbo].[QLRoles]  WITH CHECK ADD  CONSTRAINT [FK_QLRoles_QLProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[QLProjects] ([Id])
GO

ALTER TABLE [dbo].[QLRoles] CHECK CONSTRAINT [FK_QLRoles_QLProjects]
GO


GO
ALTER TABLE [dbo].[QLRoles]  WITH CHECK ADD  CONSTRAINT [FK_QLRoles_QLPermission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[QLPermission] ([PermissionId])
GO

ALTER TABLE [dbo].[QLRoles] CHECK CONSTRAINT [FK_QLRoles_QLPermission]
GO


GO
ALTER TABLE [dbo].[QLRoles]  WITH CHECK ADD  CONSTRAINT [FK_QLRoles_QLApps] FOREIGN KEY([AppId])
REFERENCES [dbo].[QLApps] ([Id])
GO

ALTER TABLE [dbo].[QLRoles] CHECK CONSTRAINT [FK_QLRoles_QLApps]
GO

