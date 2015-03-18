CREATE TABLE [dbo].[ProductsFridge]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NCHAR(10) NOT NULL, 
    [idNFC] NCHAR(80) NULL, 
    [category] NCHAR(50) NULL, 
    [calories] INT NULL, 
    [address] NCHAR(80) NULL, 
    [quantity] NCHAR(30) NULL, 
    [expirationDate] NCHAR(20) NULL, 
    [available] NCHAR(10) NULL , 
    [kitchenID] INT NOT NULL, 
    CONSTRAINT [FK_ProductsFridge_ToKitchen] FOREIGN KEY ([kitchenID]) REFERENCES [Kitchen]([Id])
)
