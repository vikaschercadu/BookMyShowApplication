CREATE TABLE [dbo].[show] (
    [id]             INT          NOT NULL,
    [showDate]       DATE         NOT NULL,
    [startTime]      VARCHAR (8)  NOT NULL,
    [endTime]        VARCHAR (8)  NULL,
    [screenId]       INT          NOT NULL,
    [movieId]        INT          NOT NULL,
    [createdOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_show] PRIMARY KEY CLUSTERED ([id] ASC, [showDate] ASC),
    CONSTRAINT [FK_show_movie] FOREIGN KEY ([movieId]) REFERENCES [dbo].[movie] ([id]),
    CONSTRAINT [FK_show_screen] FOREIGN KEY ([screenId]) REFERENCES [dbo].[screen] ([id])
);


GO

CREATE TRIGGER [dbo].[Trigger_show]
    ON [dbo].[show]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[show]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE show.id = i.id
    END