CREATE TABLE [dbo].[Members] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [firstname]       NVARCHAR (MAX) NOT NULL,
    [lastname]        NVARCHAR (MAX) NOT NULL,
    [dateOfBirth]     INT            NOT NULL,
    [email]           NVARCHAR (MAX) NOT NULL,
    [pictureUrl]      NVARCHAR (MAX) NULL,
    [defaultColor]    NVARCHAR (MAX) NULL,
    [gameActivated]   NVARCHAR (MAX) NULL,
    [gameHealthLevel] INT            NULL,
    [gamePoints]      INT            NULL,
    [password]        NVARCHAR (MAX) NULL,
    [idKitchen]       INT            NOT NULL,
    [Kitchen1_Id]     INT            NULL,
    [Kitchen_Id]      INT            NULL,
    CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Members_dbo.Kitchens_Kitchen1_Id] FOREIGN KEY ([Kitchen1_Id]) REFERENCES [dbo].[Kitchens] ([Id]),
    CONSTRAINT [FK_dbo.Members_dbo.Kitchens_Kitchen_Id] FOREIGN KEY ([Kitchen_Id]) REFERENCES [dbo].[Kitchens] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Kitchen1_Id]
    ON [dbo].[Members]([Kitchen1_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Kitchen_Id]
    ON [dbo].[Members]([Kitchen_Id] ASC);

