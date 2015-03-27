CREATE TABLE [dbo].[ProductsFridges] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [name]           NVARCHAR (MAX) NOT NULL,
    [idNFC]          NVARCHAR (MAX) NULL,
    [category]       NVARCHAR (MAX) NULL,
    [calories]       INT            NULL,
    [address]        NVARCHAR (MAX) NULL,
    [quantity]       NVARCHAR (MAX) NULL,
    [expirationDate] NVARCHAR (MAX) NULL,
    [available]      NVARCHAR (MAX) NULL,
    [kitchenID]      INT            NOT NULL,
    [addedBy]        INT            NOT NULL,
    [Members_Id]     INT            NULL,
    CONSTRAINT [PK_dbo.ProductsFridges] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ProductsFridges_dbo.Kitchens_kitchenID] FOREIGN KEY ([kitchenID]) REFERENCES [dbo].[Kitchens] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ProductsFridges_dbo.Members_Members_Id] FOREIGN KEY ([Members_Id]) REFERENCES [dbo].[Members] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_kitchenID]
    ON [dbo].[ProductsFridges]([kitchenID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Members_Id]
    ON [dbo].[ProductsFridges]([Members_Id] ASC);

