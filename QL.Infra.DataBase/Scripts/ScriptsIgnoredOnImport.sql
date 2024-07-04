
USE [master]
GO

/****** Object:  Database [QL_WFH]    Script Date: 02-07-2024 15:32:40 ******/
CREATE DATABASE [QL_WFH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_WFH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QL_WFH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_WFH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QL_WFH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

ALTER DATABASE [QL_WFH] SET COMPATIBILITY_LEVEL = 150
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_WFH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [QL_WFH] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [QL_WFH] SET ANSI_NULLS OFF
GO

ALTER DATABASE [QL_WFH] SET ANSI_PADDING OFF
GO

ALTER DATABASE [QL_WFH] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [QL_WFH] SET ARITHABORT OFF
GO

ALTER DATABASE [QL_WFH] SET AUTO_CLOSE OFF
GO

ALTER DATABASE [QL_WFH] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [QL_WFH] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [QL_WFH] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [QL_WFH] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [QL_WFH] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [QL_WFH] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [QL_WFH] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [QL_WFH] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [QL_WFH] SET  DISABLE_BROKER
GO

ALTER DATABASE [QL_WFH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [QL_WFH] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [QL_WFH] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [QL_WFH] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [QL_WFH] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [QL_WFH] SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE [QL_WFH] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [QL_WFH] SET RECOVERY SIMPLE
GO

ALTER DATABASE [QL_WFH] SET  MULTI_USER
GO

ALTER DATABASE [QL_WFH] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [QL_WFH] SET DB_CHAINING OFF
GO

ALTER DATABASE [QL_WFH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [QL_WFH] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO

ALTER DATABASE [QL_WFH] SET DELAYED_DURABILITY = DISABLED
GO

ALTER DATABASE [QL_WFH] SET ACCELERATED_DATABASE_RECOVERY = OFF
GO

ALTER DATABASE [QL_WFH] SET QUERY_STORE = OFF
GO

USE [QL_WFH]
GO

/****** Object:  Table [dbo].[QLApps]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLEmployees]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLNotifications]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLNotificationStatus]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLPermission]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLProjects]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLRequestTypes]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLRoles]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLWFHRequests]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLWFHStatus]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[QLApps] ON
GO

INSERT [dbo].[QLApps] ([Id], [AppName], [DisplayName], [Uri]) VALUES (1, N'Hrone', N'HRone', N'https://hroneauthapi.hrone.cloud/api/saml2hrone/token?domainCode=qentelli')
GO

INSERT [dbo].[QLApps] ([Id], [AppName], [DisplayName], [Uri]) VALUES (2, N'WorkFromHome', N'QLWFH', NULL)
GO

SET IDENTITY_INSERT [dbo].[QLApps] OFF
GO

SET IDENTITY_INSERT [dbo].[QLEmployees] ON
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (1, N'QE1001', N'Rahul Solanki', N'rahul.solanki@qentelli.com', 6, 3, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (2, N'QE1002', N'Ruthvi Yerramsetti', N'ruthvi.yerramsetti@qentelli.com', 4, 3, NULL, CAST(N'2024-06-28' AS Date), CAST(N'2025-07-29' AS Date))
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (3, N'QE1003', N'SuprabhanuÂ  Badabagni', N'suprabhanu.badabagni@qentelli.com', 5, 3, NULL, CAST(N'2024-07-28' AS Date), NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (4, N'QE1004', N'Shalini Bunga', N'shalini.bunga@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (5, N'QE1005', N'Sushma Bodige', N'sushma.bodige@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (6, N'QE1005', N'Sushma Bodige', N'sushma.bodige@qentelli.com', 1, 2, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (7, N'QE1006', N'Madhusudhan Kasarapu', N'madhusudhan.kasarapu@qentelli.com', 2, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (31, N'QE1007', N'Prasad Kunda', N'prasadu.kunda@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (32, N'QE1008', N'Suman Deekonda', N'suman.deekonda@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (33, N'QE1009', N'Yedupati Venkata Prasad', N'prasad.yedupati@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (34, N'QE1010', N'Mazahar Shaik', N'mazahar.shaik@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (35, N'QE1011', N'Prasad Survarapu', N'prasad.suvarapu@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (36, N'QE1012', N'Samba Siva Rao Prudhvi', N'sambasivarao.prudhvi@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (37, N'QE1013', N'Rajesh Rapelly', N'rajesh.rapelly@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (38, N'QE1014', N'Kishore Kumar Merugu', N'kishore.merugu@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (39, N'QE1015', N'Sai Madhan Mohan Sakinala', N'madhanmohan.sakinala@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (40, N'QE1016', N'Karishma k', N'karishma.k@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (41, N'QE1017', N'JaideepÂ  shingari', N'jaideep.shingari@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (42, N'QE1018
', N'Bharath Dhonapati', N'bharath.dhonapati@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (43, N'QE1019', N'Sathish Mulugu', N'sathish.mulugu@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (44, N'QE1020', N'Md Mahfooz Alam', N'mdmahfooz.alam@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (45, N'QE1021', N'Shivananda Chary K', N'shivananda.chary@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (47, N'QE1022', N'Madhuri Kunja', N'madhuri.kunja@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (48, N'QE1023', N'Srija vuppala', N'srija.vuppala@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (49, N'QE1024', N'Tabassum', N'tabassum.husen@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (50, N'QE1025', N'Mohd Abdul Majeed', N'mohd.majeed@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (51, N'QE1026', N'Naga Manisha', N'manisha.chinimilli@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (53, N'QE1027', N'Jyothi Kondaveeti', N'jyothi.kondaveeti@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (54, N'QE1028', N'Surekha Goddeti', N'surekha.goddeti@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (55, N'QE1029', N'Annam Shalini Reddy', N'shalini.annam@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (56, N'QE1030', N'Gowri Shankar Bura', N'gowrishankar.bura@qentelli.com', 3, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (59, N'QE1030', N'Gowri Shankar Bura', N'gowrishankar.bura@qentelli.com', 3, 2, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (60, N'QE1030', N'Gowri Shankar Bura', N'gowrishankar.bura@qentelli.com', 3, 3, NULL, NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[QLEmployees] OFF
GO

SET IDENTITY_INSERT [dbo].[QLNotifications] ON
GO

INSERT [dbo].[QLNotifications] ([NotificationId], [Title], [NotificationStatusId], [CreatedDate], [Approveddate], [RequestId], [Read]) VALUES (1, N'WFH request has been raised', 1, CAST(N'2024-06-21' AS Date), NULL, N'93c57e03-bdab-4edc-8c3c-3058702a3fab', NULL)
GO

SET IDENTITY_INSERT [dbo].[QLNotifications] OFF
GO

SET IDENTITY_INSERT [dbo].[QLNotificationStatus] ON
GO

INSERT [dbo].[QLNotificationStatus] ([NotificationStatusId], [NotificationStatus]) VALUES (1, N'Ready')
GO

INSERT [dbo].[QLNotificationStatus] ([NotificationStatusId], [NotificationStatus]) VALUES (2, N'Sent')
GO

SET IDENTITY_INSERT [dbo].[QLNotificationStatus] OFF
GO

SET IDENTITY_INSERT [dbo].[QLPermission] ON
GO

INSERT [dbo].[QLPermission] ([PermissionId], [Permission]) VALUES (1, N'Level 1')
GO

INSERT [dbo].[QLPermission] ([PermissionId], [Permission]) VALUES (2, N'Level 2')
GO

SET IDENTITY_INSERT [dbo].[QLPermission] OFF
GO

SET IDENTITY_INSERT [dbo].[QLProjects] ON
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (1, N'P110', N'TAX', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (2, N'P111', N'IMMIGRATON', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (3, N'P112', N'TCB', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (4, N'P113', N'SWA', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (5, N'P114', N'AI INNOVATION', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (6, N'P115', N'TOSCA', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[QLProjects] OFF
GO

SET IDENTITY_INSERT [dbo].[QLRequestTypes] ON
GO

INSERT [dbo].[QLRequestTypes] ([RequestTypeId], [RequestTypeName]) VALUES (1, N'WFH')
GO

INSERT [dbo].[QLRequestTypes] ([RequestTypeId], [RequestTypeName]) VALUES (2, N'Leave')
GO

INSERT [dbo].[QLRequestTypes] ([RequestTypeId], [RequestTypeName]) VALUES (3, N'Facilities')
GO

SET IDENTITY_INSERT [dbo].[QLRequestTypes] OFF
GO

SET IDENTITY_INSERT [dbo].[QLRoles] ON
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (1, N'Team Member', 1, NULL, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (2, N'DeliveryManager', 1, 1, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (3, N'ReportingManager', 1, 2, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (4, N'Team Member', 3, NULL, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (5, N'DeliveryManager', 3, 1, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (6, N'ReportingManager', 3, 2, 2)
GO

SET IDENTITY_INSERT [dbo].[QLRoles] OFF
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', 3, 1, CAST(N'2024-06-28' AS Date), CAST(N'2024-06-30' AS Date), 3, 2, N'test health issues', CAST(N'2024-06-28' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'93c57e03-bdab-4edc-8c3c-3058702a3fab', 2, 1, CAST(N'2024-06-18' AS Date), CAST(N'2024-06-29' AS Date), 1, 1, N'Personal Reason', CAST(N'2024-06-21' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'ebf82a4f-5127-4643-b070-a6693e6f614b', 1, 1, CAST(N'2024-06-19' AS Date), CAST(N'2024-06-20' AS Date), 1, 1, N'Emergency', CAST(N'2024-06-21' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'ebf82a4f-5127-4643-b070-a6693e6f614e', 1, 1, CAST(N'2024-06-19' AS Date), CAST(N'2024-06-20' AS Date), 1, 1, N'Health issues', CAST(N'2024-06-21' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'ebf82a4f-5127-4643-b070-a6693f6f614e', 1, 1, CAST(N'2024-06-19' AS Date), CAST(N'2024-06-19' AS Date), 2, 1, N'test', CAST(N'2024-06-19' AS Date), NULL)
GO

SET IDENTITY_INSERT [dbo].[QLWFHStatus] ON
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (1, N'Approved')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (2, N'Rejected')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (3, N'Created')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (4, N'Hold')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (5, N'Read')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (6, N'UnRead')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (7, N'Completed')
GO

SET IDENTITY_INSERT [dbo].[QLWFHStatus] OFF
GO

SET ANSI_PADDING ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestCountByEmployeeId]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestsByEmployeeId]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestsByProjectId]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestsDetails]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAppName]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetEmployeeDetailsForProject]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetProjectsByEmployeeId]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetRequestType]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetStatus]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[SaveRequest]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[UpdateRequestStatus]    Script Date: 02-07-2024 15:32:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [master]
GO

ALTER DATABASE [QL_WFH] SET  READ_WRITE
GO

USE [master]
GO

/****** Object:  Database [QL_WFH]    Script Date: 04-07-2024 13:40:44 ******/
CREATE DATABASE [QL_WFH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_WFH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QL_WFH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_WFH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QL_WFH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

ALTER DATABASE [QL_WFH] SET COMPATIBILITY_LEVEL = 150
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_WFH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [QL_WFH] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [QL_WFH] SET ANSI_NULLS OFF
GO

ALTER DATABASE [QL_WFH] SET ANSI_PADDING OFF
GO

ALTER DATABASE [QL_WFH] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [QL_WFH] SET ARITHABORT OFF
GO

ALTER DATABASE [QL_WFH] SET AUTO_CLOSE OFF
GO

ALTER DATABASE [QL_WFH] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [QL_WFH] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [QL_WFH] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [QL_WFH] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [QL_WFH] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [QL_WFH] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [QL_WFH] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [QL_WFH] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [QL_WFH] SET  DISABLE_BROKER
GO

ALTER DATABASE [QL_WFH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [QL_WFH] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [QL_WFH] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [QL_WFH] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [QL_WFH] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [QL_WFH] SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE [QL_WFH] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [QL_WFH] SET RECOVERY SIMPLE
GO

ALTER DATABASE [QL_WFH] SET  MULTI_USER
GO

ALTER DATABASE [QL_WFH] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [QL_WFH] SET DB_CHAINING OFF
GO

ALTER DATABASE [QL_WFH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [QL_WFH] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO

ALTER DATABASE [QL_WFH] SET DELAYED_DURABILITY = DISABLED
GO

ALTER DATABASE [QL_WFH] SET ACCELERATED_DATABASE_RECOVERY = OFF
GO

ALTER DATABASE [QL_WFH] SET QUERY_STORE = OFF
GO

USE [QL_WFH]
GO

/****** Object:  Table [dbo].[QLApps]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLCards]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLEmployees]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLIdeaDetails]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLIdeaTracker]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLLogin]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLNotifications]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLNotificationStatus]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLPermission]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLProjects]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLRequestTypes]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLRoles]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLWFHRequests]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[QLWFHStatus]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[QLApps] ON
GO

INSERT [dbo].[QLApps] ([Id], [AppName], [DisplayName], [Uri]) VALUES (1, N'Hrone', N'HRone', N'https://hroneauthapi.hrone.cloud/api/saml2hrone/token?domainCode=qentelli')
GO

INSERT [dbo].[QLApps] ([Id], [AppName], [DisplayName], [Uri]) VALUES (2, N'WorkFromHome', N'QLWFH', NULL)
GO

SET IDENTITY_INSERT [dbo].[QLApps] OFF
GO

SET IDENTITY_INSERT [dbo].[QLCards] ON
GO

INSERT [dbo].[QLCards] ([Id], [Icon], [Title], [Color], [BackgroundColor]) VALUES (1, N'list_alt', N'Total Requests', N'#fff', N'#17a2b8')
GO

INSERT [dbo].[QLCards] ([Id], [Icon], [Title], [Color], [BackgroundColor]) VALUES (2, N'check_circle_outline', N'Approved', N'#fff', N'#28a745')
GO

INSERT [dbo].[QLCards] ([Id], [Icon], [Title], [Color], [BackgroundColor]) VALUES (3, N'highlight_off', N'Rejected', N'#fff', N'#dc3545')
GO

INSERT [dbo].[QLCards] ([Id], [Icon], [Title], [Color], [BackgroundColor]) VALUES (4, N'library_add', N'New Request', N'#fff', N'#17a2b8')
GO

SET IDENTITY_INSERT [dbo].[QLCards] OFF
GO

SET IDENTITY_INSERT [dbo].[QLEmployees] ON
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (1, N'QE1001', N'Rahul Solanki', N'rahul.solanki@qentelli.com', 6, 3, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (2, N'QE1002', N'Ruthvi Yerramsetti', N'ruthvi.yerramsetti@qentelli.com', 4, 3, NULL, CAST(N'2024-06-28' AS Date), CAST(N'2025-07-29' AS Date))
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (3, N'QE1003', N'SuprabhanuÂ  Badabagni', N'suprabhanu.badabagni@qentelli.com', 5, 3, NULL, CAST(N'2024-07-28' AS Date), NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (4, N'QE1004', N'Shalini Bunga', N'shalini.bunga@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (5, N'QE1005', N'Sushma Bodige', N'sushma.bodige@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (6, N'QE1005', N'Sushma Bodige', N'sushma.bodige@qentelli.com', 1, 2, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (7, N'QE1006', N'Madhusudhan Kasarapu', N'madhusudhan.kasarapu@qentelli.com', 2, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (31, N'QE1007', N'Prasad Kunda', N'prasadu.kunda@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (32, N'QE1008', N'Suman Deekonda', N'suman.deekonda@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (33, N'QE1009', N'Yedupati Venkata Prasad', N'prasad.yedupati@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (34, N'QE1010', N'Mazahar Shaik', N'mazahar.shaik@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (35, N'QE1011', N'Prasad Survarapu', N'prasad.suvarapu@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (36, N'QE1012', N'Samba Siva Rao Prudhvi', N'sambasivarao.prudhvi@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (37, N'QE1013', N'Rajesh Rapelly', N'rajesh.rapelly@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (38, N'QE1014', N'Kishore Kumar Merugu', N'kishore.merugu@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (39, N'QE1015', N'Sai Madhan Mohan Sakinala', N'madhanmohan.sakinala@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (40, N'QE1016', N'Karishma k', N'karishma.k@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (41, N'QE1017', N'JaideepÂ  shingari', N'jaideep.shingari@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (42, N'QE1018
', N'Bharath Dhonapati', N'bharath.dhonapati@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (43, N'QE1019', N'Sathish Mulugu', N'sathish.mulugu@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (44, N'QE1020', N'Md Mahfooz Alam', N'mdmahfooz.alam@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (45, N'QE1021', N'Shivananda Chary K', N'shivananda.chary@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (47, N'QE1022', N'Madhuri Kunja', N'madhuri.kunja@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (48, N'QE1023', N'Srija vuppala', N'srija.vuppala@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (49, N'QE1024', N'Tabassum', N'tabassum.husen@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (50, N'QE1025', N'Mohd Abdul Majeed', N'mohd.majeed@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (51, N'QE1026', N'Naga Manisha', N'manisha.chinimilli@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (53, N'QE1027', N'Jyothi Kondaveeti', N'jyothi.kondaveeti@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (54, N'QE1028', N'Surekha Goddeti', N'surekha.goddeti@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (55, N'QE1029', N'Annam Shalini Reddy', N'shalini.annam@qentelli.com', 1, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (56, N'QE1030', N'Gowri Shankar Bura', N'gowrishankar.bura@qentelli.com', 3, 1, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (59, N'QE1030', N'Gowri Shankar Bura', N'gowrishankar.bura@qentelli.com', 3, 2, NULL, NULL, NULL)
GO

INSERT [dbo].[QLEmployees] ([Id], [EmpId], [Name], [Email], [RoleId], [ProjectId], [MobileNumber], [AllocationDate], [EndDate]) VALUES (60, N'QE1030', N'Gowri Shankar Bura', N'gowrishankar.bura@qentelli.com', 3, 3, NULL, NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[QLEmployees] OFF
GO

SET IDENTITY_INSERT [dbo].[QLIdeaDetails] ON
GO

INSERT [dbo].[QLIdeaDetails] ([Id], [IdeaDescription], [IdeaType]) VALUES (1, N'Tax Descrption', N'Tax')
GO

INSERT [dbo].[QLIdeaDetails] ([Id], [IdeaDescription], [IdeaType]) VALUES (2, N'IMMIGRATON Descrption', N'IMMIGRATON')
GO

INSERT [dbo].[QLIdeaDetails] ([Id], [IdeaDescription], [IdeaType]) VALUES (3, N'TCB Desc', N'TCB')
GO

SET IDENTITY_INSERT [dbo].[QLIdeaDetails] OFF
GO

SET IDENTITY_INSERT [dbo].[QLIdeaTracker] ON
GO

INSERT [dbo].[QLIdeaTracker] ([Id], [Title], [IdeaDescription], [IdeaType], [Benefits], [Technology], [EstimatedEffort], [ActualEffort], [AnnualSaving], [Status], [ResourceName]) VALUES (1, N'test title', N'test desc', 1, N'test benefits', N'test tech', 3, 2, 1, 1, 1)
GO

SET IDENTITY_INSERT [dbo].[QLIdeaTracker] OFF
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'bharath.dhonapati@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'gowrishankar.bura@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'jaideep.shingari@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'jyothi.kondaveeti@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'karishma.k@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'kishore.merugu@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'madhanmohan.sakinala@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'madhuri.kunja@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'madhusudhan.kasarapu@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'manisha.chinimilli@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'mazahar.shaik@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'mdmahfooz.alam@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'mohd.majeed@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'prasad.suvarapu@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'prasad.yedupati@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'prasadu.kunda@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'rahul.solanki@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'rajesh.rapelly@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'ruthvi.yerramsetti@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'sambasivarao.prudhvi@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'sathish.mulugu@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'shalini.annam@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'shalini.bunga@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'shivananda.chary@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'srija.vuppala@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'suman.deekonda@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'suprabhanu.badabagni@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'surekha.goddeti@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'sushma.bodige@qentelli.com', N'123')
GO

INSERT [dbo].[QLLogin] ([UserName], [Password]) VALUES (N'tabassum.husen@qentelli.com', N'123')
GO

SET IDENTITY_INSERT [dbo].[QLNotifications] ON
GO

INSERT [dbo].[QLNotifications] ([NotificationId], [Title], [NotificationStatusId], [CreatedDate], [Approveddate], [RequestId], [Read], [RejectedReason]) VALUES (1, N'test notification', 2, CAST(N'2024-06-21' AS Date), CAST(N'2024-07-03' AS Date), N'93c57e03-bdab-4edc-8c3c-3058702a3fab', NULL, NULL)
GO

INSERT [dbo].[QLNotifications] ([NotificationId], [Title], [NotificationStatusId], [CreatedDate], [Approveddate], [RequestId], [Read], [RejectedReason]) VALUES (2, N'test notification1', 2, CAST(N'2024-07-03' AS Date), CAST(N'2024-07-03' AS Date), N'3fa85f64-5717-4562-b3fc-2c963f66afa6', 0, NULL)
GO

SET IDENTITY_INSERT [dbo].[QLNotifications] OFF
GO

SET IDENTITY_INSERT [dbo].[QLNotificationStatus] ON
GO

INSERT [dbo].[QLNotificationStatus] ([NotificationStatusId], [NotificationStatus]) VALUES (1, N'Ready')
GO

INSERT [dbo].[QLNotificationStatus] ([NotificationStatusId], [NotificationStatus]) VALUES (2, N'Sent')
GO

SET IDENTITY_INSERT [dbo].[QLNotificationStatus] OFF
GO

SET IDENTITY_INSERT [dbo].[QLPermission] ON
GO

INSERT [dbo].[QLPermission] ([PermissionId], [Permission]) VALUES (1, N'Level 1')
GO

INSERT [dbo].[QLPermission] ([PermissionId], [Permission]) VALUES (2, N'Level 2')
GO

SET IDENTITY_INSERT [dbo].[QLPermission] OFF
GO

SET IDENTITY_INSERT [dbo].[QLProjects] ON
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (1, N'P110', N'TAX', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (2, N'P111', N'IMMIGRATON', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (3, N'P112', N'TCB', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (4, N'P113', N'SWA', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (5, N'P114', N'AI INNOVATION', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

INSERT [dbo].[QLProjects] ([Id], [ProjectId], [ProjectName], [CreatedDate], [EndDate], [AllottedDate]) VALUES (6, N'P115', N'TOSCA', CAST(N'2024-06-20' AS Date), NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[QLProjects] OFF
GO

SET IDENTITY_INSERT [dbo].[QLRequestTypes] ON
GO

INSERT [dbo].[QLRequestTypes] ([RequestTypeId], [RequestTypeName]) VALUES (1, N'WFH')
GO

INSERT [dbo].[QLRequestTypes] ([RequestTypeId], [RequestTypeName]) VALUES (2, N'Leave')
GO

INSERT [dbo].[QLRequestTypes] ([RequestTypeId], [RequestTypeName]) VALUES (3, N'Facilities')
GO

SET IDENTITY_INSERT [dbo].[QLRequestTypes] OFF
GO

SET IDENTITY_INSERT [dbo].[QLRoles] ON
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (1, N'Team Member', 1, NULL, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (2, N'DeliveryManager', 1, 1, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (3, N'ReportingManager', 1, 2, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (4, N'Team Member', 3, NULL, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (5, N'DeliveryManager', 3, 1, 2)
GO

INSERT [dbo].[QLRoles] ([Id], [RoleName], [ProjectId], [PermissionId], [AppId]) VALUES (6, N'ReportingManager', 3, 2, 2)
GO

SET IDENTITY_INSERT [dbo].[QLRoles] OFF
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'3fa85f64-5717-4562-b3fc-2c963f66afa6', 3, 1, CAST(N'2024-06-28' AS Date), CAST(N'2024-06-30' AS Date), 3, 2, N'test health issues', CAST(N'2024-06-28' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'93c57e03-bdab-4edc-8c3c-3058702a3fab', 2, 1, CAST(N'2024-06-18' AS Date), CAST(N'2024-06-29' AS Date), 1, 1, N'Personal Reason', CAST(N'2024-06-21' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'ebf82a4f-5127-4643-b070-a6693e6f614b', 1, 1, CAST(N'2024-06-19' AS Date), CAST(N'2024-06-20' AS Date), 1, 1, N'Emergency', CAST(N'2024-06-21' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'ebf82a4f-5127-4643-b070-a6693e6f614e', 1, 1, CAST(N'2024-06-19' AS Date), CAST(N'2024-06-20' AS Date), 1, 1, N'Health issues', CAST(N'2024-06-21' AS Date), NULL)
GO

INSERT [dbo].[QLWFHRequests] ([RequestId], [EmployeeId], [RequestType], [FromDate], [ToDate], [Status], [NoOfDays], [Comments], [RequestedDate], [ApprovedDate]) VALUES (N'ebf82a4f-5127-4643-b070-a6693f6f614e', 1, 1, CAST(N'2024-06-19' AS Date), CAST(N'2024-06-19' AS Date), 2, 1, N'test', CAST(N'2024-06-19' AS Date), NULL)
GO

SET IDENTITY_INSERT [dbo].[QLWFHStatus] ON
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (1, N'Approved')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (2, N'Rejected')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (3, N'Created')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (4, N'Hold')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (5, N'Read')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (6, N'UnRead')
GO

INSERT [dbo].[QLWFHStatus] ([StatusId], [Status]) VALUES (7, N'Completed')
GO

SET IDENTITY_INSERT [dbo].[QLWFHStatus] OFF
GO

SET ANSI_PADDING ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestCountByEmployeeId]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestsByEmployeeId]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestsByProjectId]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAllRequestsDetails]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetAppName]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetCardsByEmployeeId]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetEmployeeDetailsForProject]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetIdeaTracker]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetNotificationsByEmployeeId]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetProjectsByEmployeeId]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetRequestType]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetStatus]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[SaveNotifications]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[SaveRequest]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[UpdateNotification]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[UpdateRequestStatus]    Script Date: 04-07-2024 13:40:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [master]
GO

ALTER DATABASE [QL_WFH] SET  READ_WRITE
GO
