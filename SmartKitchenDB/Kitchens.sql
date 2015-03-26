CREATE TABLE [dbo].[Kitchens] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (MAX) NULL,
    [adminID]           INT            NOT NULL,
    [shoppingBagID]     INT            NULL,
    [temperatureFridge] NVARCHAR (MAX) NULL,
    [Members_Id]        INT            NULL,
    [ShoppingBags_Id]   INT            NULL,
    [Members_Id1]       INT            NULL,
    CONSTRAINT [PK_dbo.Kitchens] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Kitchens_dbo.Members_Members_Id] FOREIGN KEY ([Members_Id]) REFERENCES [dbo].[Members] ([Id]),
    CONSTRAINT [FK_dbo.Kitchens_dbo.ShoppingBags_ShoppingBags_Id] FOREIGN KEY ([ShoppingBags_Id]) REFERENCES [dbo].[ShoppingBags] ([Id]),
    CONSTRAINT [FK_dbo.Kitchens_dbo.Members_Members_Id1] FOREIGN KEY ([Members_Id1]) REFERENCES [dbo].[Members] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Members_Id]
    ON [dbo].[Kitchens]([Members_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ShoppingBags_Id]
    ON [dbo].[Kitchens]([ShoppingBags_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Members_Id1]
    ON [dbo].[Kitchens]([Members_Id1] ASC);

