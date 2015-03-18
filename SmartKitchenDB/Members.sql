CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [firstname] NCHAR(80) NOT NULL, 
    [lastname] NCHAR(100) NOT NULL, 
    [dateOfBirth] INT NOT NULL, 
    [email] NCHAR(100) NOT NULL, 
    [pictureUrl] NCHAR(100) NULL, 
    [defaultColor] NCHAR(50) NULL, 
    [gameActivated] NCHAR(10) NULL, 
    [gameHealthLevel] INT NULL, 
    [gamePoints] INT NULL, 
    [password] NCHAR(100) NULL, 
    [idKitchen] INT NOT NULL, 
    CONSTRAINT [AK_Members_Email] UNIQUE ([email]), 
	CONSTRAINT [AK_Members_idKitchen] UNIQUE ([idKitchen]), 
    CONSTRAINT [FK_Members_ToKitchen] FOREIGN KEY ([idKitchen]) REFERENCES [Kitchen]([Id])
)
