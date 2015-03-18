CREATE TABLE [dbo].[MemberWeight]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [memberID] INT NOT NULL, 
    [value] NCHAR(20) NOT NULL, 
    [date] INT NOT NULL, 
    CONSTRAINT [FK_MemberWeight_ToMembers] FOREIGN KEY ([memberID]) REFERENCES [Members]([Id])
)
