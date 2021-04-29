CREATE TABLE [dbo].[seat] (
    [number]         VARCHAR (4)  NOT NULL,
    [screenId]       INT          NOT NULL,
    [createdOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_seat] PRIMARY KEY CLUSTERED ([number] ASC, [screenId] ASC),
    CONSTRAINT [FK_seat_screen] FOREIGN KEY ([screenId]) REFERENCES [dbo].[screen] ([id])
);


GO

CREATE TRIGGER [dbo].[Trigger_seat]
    ON [dbo].[seat]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[seat]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE seat.number = i.number
    END