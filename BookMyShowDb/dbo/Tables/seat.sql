CREATE TABLE [dbo].[Seat] (
    [number]         VARCHAR (4)  NOT NULL,
    [ScreenId]       INT          NOT NULL,
    [CreatedOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED ([Number] ASC, [ScreenId] ASC),
    CONSTRAINT [FK_Seat_Screen] FOREIGN KEY ([ScreenId]) REFERENCES [dbo].[Screen] ([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_Seat]
    ON [dbo].[Seat]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[Seat]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE Seat.Number = i.Number
    END