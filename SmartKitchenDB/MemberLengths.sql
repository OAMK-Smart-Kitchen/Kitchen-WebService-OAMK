CREATE TABLE [dbo].[MemberLengths] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [memberID]   INT            NOT NULL,
    [value]      NVARCHAR (MAX) NULL,
    [date]       INT            NOT NULL,
    [Members_Id] INT            NULL,
    CONSTRAINT [PK_dbo.MemberLengths] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MemberLengths_dbo.Members_Members_Id] FOREIGN KEY ([Members_Id]) REFERENCES [dbo].[Members] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Members_Id]
    ON [dbo].[MemberLengths]([Members_Id] ASC);

