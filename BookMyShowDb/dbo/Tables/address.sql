CREATE TABLE [dbo].[address] (
    [id]             INT          NOT NULL,
    [buildingNumber] VARCHAR (20) NOT NULL,
    [streetName]     VARCHAR (50) NOT NULL,
    [landmark]       VARCHAR (50) NULL,
    [cityId]         INT          NOT NULL,
    [createdOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_address_city] FOREIGN KEY ([cityId]) REFERENCES [dbo].[city] ([id])
);


GO

CREATE TRIGGER [dbo].[Trigger_address]
    ON [dbo].[address]
    AFTER UPDATE
    AS
    BEGIN
        UPDATE [dbo].[address]
        SET lastModifiedOn = SYSDATETIME() , lastModifiedBy =USER 
        FROM Inserted i
        WHERE address.id = i.id
    END