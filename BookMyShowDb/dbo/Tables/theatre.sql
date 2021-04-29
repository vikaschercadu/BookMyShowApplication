CREATE TABLE [dbo].[theatre] (
    [id]                 INT          NOT NULL,
    [name]               VARCHAR (45) NOT NULL,
    [noOfScreens]        INT          NOT NULL,
    [isParkingAvailable] BIT          NOT NULL,
    [addressId]          INT          NOT NULL,
    [createdOn]          DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]          VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn]     DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy]     VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_theatre] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK_theatre_isParkingAvailable] CHECK ([isParkingAvailable]=(1) OR [isParkingAvailable]=(0)),
    CONSTRAINT [FK_theatre_address] FOREIGN KEY ([addressId]) REFERENCES [dbo].[address] ([id])
);


GO

CREATE TRIGGER [dbo].[Trigger_theatre]
    ON [dbo].[theatre]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[theatre]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE theatre.id = i.id
    END