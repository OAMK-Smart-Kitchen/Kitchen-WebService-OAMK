CREATE TABLE [dbo].[MemberWeights] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [memberID]   INT            NOT NULL,
    [value]      NVARCHAR (MAX) NULL,
    [date]       INT            NOT NULL,
    [Members_Id] INT            NULL,
    CONSTRAINT [PK_dbo.MemberWeights] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.MemberWeights_dbo.Members_Members_Id] FOREIGN KEY ([Members_Id]) REFERENCES [dbo].[Members] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Members_Id]
    ON [dbo].[MemberWeights]([Members_Id] ASC);

