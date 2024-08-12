CREATE TABLE [dbo].[QLEmployees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[MobileNumber] [int] NULL,
	[AllocationDate] [date] NULL,
	[EndDate] [date] NULL,
	[ManagerId] [nvarchar](20) NULL,
 CONSTRAINT [PK_QLEmployees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[QLEmployees]  WITH CHECK ADD  CONSTRAINT [FK_QLEmployees_QLProjects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[QLProjects] ([Id])
GO

ALTER TABLE [dbo].[QLEmployees] CHECK CONSTRAINT [FK_QLEmployees_QLProjects]
GO

ALTER TABLE [dbo].[QLEmployees]  WITH CHECK ADD  CONSTRAINT [FK_QLEmployees_QLRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[QLRoles] ([Id])
GO

ALTER TABLE [dbo].[QLEmployees] CHECK CONSTRAINT [FK_QLEmployees_QLRoles]
GO
