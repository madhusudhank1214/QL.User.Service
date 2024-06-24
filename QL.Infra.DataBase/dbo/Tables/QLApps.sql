CREATE TABLE [dbo].[QLApps] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [AppName]     NVARCHAR (50)  NOT NULL,
    [DisplayName] NVARCHAR (50)  NOT NULL,
    [Uri]         NVARCHAR (250) NULL,
    CONSTRAINT [PK_QLApps] PRIMARY KEY CLUSTERED ([Id] ASC)
);

