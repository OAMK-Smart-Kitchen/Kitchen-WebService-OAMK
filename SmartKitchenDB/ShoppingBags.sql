CREATE TABLE [dbo].[ShoppingBags] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [name]      NVARCHAR (MAX) NULL,
    [createdOn] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.ShoppingBags] PRIMARY KEY CLUSTERED ([Id] ASC)
);

