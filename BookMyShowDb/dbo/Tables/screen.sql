CREATE TABLE [dbo].[Screen] (
    [Id]               INT          NOT NULL,
    [Number]           INT          NOT NULL,
    [TotalNoOfSeats]   INT          NOT NULL,
    [ScreenResolution] VARCHAR (30) NOT NULL,
    [SoundSystem]      VARCHAR (30) NOT NULL,
    [TheatreId]        INT          NOT NULL,
    [CreatedOn]        DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]        VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn]   DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy]   VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_Screen] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Screen_Theatre] FOREIGN KEY ([TheatreId]) REFERENCES [dbo].[Theatre] ([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_Screen]
    ON [dbo].[Screen]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[Screen]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE Screen.Id = i.Id
    END