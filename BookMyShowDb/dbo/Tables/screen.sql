CREATE TABLE [dbo].[screen] (
    [id]               INT          NOT NULL,
    [number]           INT          NOT NULL,
    [totalNoOfSeats]   INT          NOT NULL,
    [screenResolution] VARCHAR (30) NOT NULL,
    [soundSystem]      VARCHAR (30) NOT NULL,
    [theatreId]        INT          NOT NULL,
    [createdOn]        DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]        VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn]   DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy]   VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_screen] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_screen_theatre] FOREIGN KEY ([theatreId]) REFERENCES [dbo].[theatre] ([id])
);


GO

CREATE TRIGGER [dbo].[Trigger_screen]
    ON [dbo].[screen]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[screen]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE screen.id = i.id
    END