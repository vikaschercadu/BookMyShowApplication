CREATE TABLE [dbo].[City] (
    [Id]             INT          NOT NULL,
    [Name]           VARCHAR (45) NOT NULL,
    [State]          VARCHAR (45) NOT NULL,
    [Pincode]        VARCHAR (6)  NOT NULL,
    [CreatedOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_City]
    ON [dbo].[City]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[City]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE City.Id = i.Id
    END