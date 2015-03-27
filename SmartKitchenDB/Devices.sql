CREATE TABLE [dbo].[Devices] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (MAX) NOT NULL,
    [idKitchen]  INT            NOT NULL,
    [Kitchen_Id] INT            NULL,
    CONSTRAINT [PK_dbo.Devices] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Devices_dbo.Kitchens_Kitchen_Id] FOREIGN KEY ([Kitchen_Id]) REFERENCES [dbo].[Kitchens] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Kitchen_Id]
    ON [dbo].[Devices]([Kitchen_Id] ASC);

