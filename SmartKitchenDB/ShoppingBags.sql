CREATE TABLE [dbo].[ShoppingBags] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR (MAX) NOT NULL,
    [createdOn] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.ShoppingBags] PRIMARY KEY CLUSTERED ([Id] ASC)
);

