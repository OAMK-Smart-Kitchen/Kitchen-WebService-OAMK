CREATE TABLE [dbo].[Kitchen]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NCHAR(50) NOT NULL, 
    [adminID] INT NOT NULL, 
    [shoppingBagID] INT NULL, 
    [temperatureFridge] NCHAR(20) NULL, 
    CONSTRAINT [FK_idAdmin_ToMembers] FOREIGN KEY ([adminID]) REFERENCES [Members]([Id]), 
    CONSTRAINT [FK_shoppingBagID_ShoppingBags] FOREIGN KEY (shoppingBagID) REFERENCES [ShoppingBags]([Id]), 
    CONSTRAINT [Admin] UNIQUE ([adminID]),
	CONSTRAINT [ShoppingBag] UNIQUE ([shoppingBagID])
)