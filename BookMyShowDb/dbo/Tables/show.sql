CREATE TABLE [dbo].[Show] (
    [Id]             INT          NOT NULL,
    [ShowDate]       DATE         NOT NULL,
    [StartTime]      VARCHAR (8)  NOT NULL,
    [EndTime]        VARCHAR (8)  NULL,
    [ScreenId]       INT          NOT NULL,
    [MovieId]        INT          NOT NULL,
    [CreatedOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_Show] PRIMARY KEY CLUSTERED ([Id] ASC, [ShowDate] ASC),
    CONSTRAINT [FK_Show_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]),
    CONSTRAINT [FK_Show_Screen] FOREIGN KEY ([ScreenId]) REFERENCES [dbo].[Screen] ([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_Show]
    ON [dbo].[Show]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[Show]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE Show.Id = i.Id
    END