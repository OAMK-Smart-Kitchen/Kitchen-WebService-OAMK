CREATE TABLE [dbo].[Devices]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NCHAR(50) NOT NULL, 
    [idKitchen] INT NOT NULL, 
    CONSTRAINT [FK_idKitchen_ToKitchen] FOREIGN KEY ([idKitchen]) REFERENCES [Kitchen]([Id]) 
)
