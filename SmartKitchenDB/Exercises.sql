CREATE TABLE [dbo].[Exercises] (
    [Id]     INT            IDENTITY (1, 1) NOT NULL,
    [name]   NVARCHAR (MAX) NULL,
    [cal]    NVARCHAR (MAX) NULL,
    [points] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Exercises] PRIMARY KEY CLUSTERED ([Id] ASC)
);

