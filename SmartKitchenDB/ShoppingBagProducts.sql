CREATE TABLE [dbo].[ShoppingBagProducts] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (MAX) NULL,
    [quantity]        NVARCHAR (MAX) NULL,
    [category]        NVARCHAR (MAX) NULL,
    [shop]            NVARCHAR (MAX) NULL,
    [addedBy]         INT            NOT NULL,
    [shoppingBagID]   INT            NOT NULL,
    [Members_Id]      INT            NULL,
    [ShoppingBags_Id] INT            NULL,
    CONSTRAINT [PK_dbo.ShoppingBagProducts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ShoppingBagProducts_dbo.Members_Members_Id] FOREIGN KEY ([Members_Id]) REFERENCES [dbo].[Members] ([Id]),
    CONSTRAINT [FK_dbo.ShoppingBagProducts_dbo.ShoppingBags_ShoppingBags_Id] FOREIGN KEY ([ShoppingBags_Id]) REFERENCES [dbo].[ShoppingBags] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Members_Id]
    ON [dbo].[ShoppingBagProducts]([Members_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ShoppingBags_Id]
    ON [dbo].[ShoppingBagProducts]([ShoppingBags_Id] ASC);

