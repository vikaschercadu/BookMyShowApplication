CREATE TABLE [dbo].[Movie] (
    [Id]             INT           NOT NULL,
    [Title]          VARCHAR (45)  NOT NULL,
    [Language]       VARCHAR (45)  NOT NULL,
    [Genre]          VARCHAR (45)  NOT NULL,
    [RunningTime]    VARCHAR (8)   NOT NULL,
    [ReleaseDate]    DATE          NOT NULL,
    [ImageUrl]       VARCHAR (100) NOT NULL,
    [CreatedOn]      DATETIME      DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30)  DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME      DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30)  DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_Movie]
    ON [dbo].[Movie]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[Movie]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE Movie.Id = i.Id
    END