CREATE TABLE [dbo].[movie] (
    [id]             INT           NOT NULL,
    [title]          VARCHAR (45)  NOT NULL,
    [language]       VARCHAR (45)  NOT NULL,
    [genre]          VARCHAR (45)  NOT NULL,
    [runningTime]    VARCHAR (8)   NOT NULL,
    [releaseDate]    DATE          NOT NULL,
    [imageUrl]       VARCHAR (100) NOT NULL,
    [createdOn]      DATETIME      DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30)  DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME      DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30)  DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_movie] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_movie]
    ON [dbo].[movie]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[movie]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE movie.id = i.id
    END