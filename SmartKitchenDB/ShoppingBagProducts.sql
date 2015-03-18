CREATE TABLE [dbo].[ShoppingBagProducts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NCHAR(30) NOT NULL, 
    [quantity] NCHAR(30) NULL, 
    [category] NCHAR(30) NULL, 
    [shop] NCHAR(30) NULL, 
    [addedBy] INT NOT NULL, 
    [shoppingBagID] INT NOT NULL, 
    CONSTRAINT [FK_AddedBy_ToMembers] FOREIGN KEY ([addedBy]) REFERENCES [Members]([Id]), 
    CONSTRAINT [FK_ShoppingBagID_ToShoppingBags] FOREIGN KEY ([shoppingBagID]) REFERENCES [ShoppingBags]([Id])
)
