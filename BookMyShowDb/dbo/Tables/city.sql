CREATE TABLE [dbo].[city] (
    [id]             INT          NOT NULL,
    [name]           VARCHAR (45) NOT NULL,
    [state]          VARCHAR (45) NOT NULL,
    [pincode]        VARCHAR (6)  NOT NULL,
    [createdOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_city] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

CREATE TRIGGER [dbo].[Trigger_city]
    ON [dbo].[city]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[city]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE city.id = i.id
    END