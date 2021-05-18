CREATE TABLE [dbo].[Theatre] (
    [Id]                 INT          NOT NULL,
    [Name]               VARCHAR (45) NOT NULL,
    [NoOfScreens]        INT          NOT NULL,
    [IsParkingAvailable] BIT          NOT NULL,
    [AddressId]          INT          NOT NULL,
    [CreatedOn]          DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]          VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn]     DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy]     VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_Theatre] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Theatre_IsParkingAvailable] CHECK ([IsParkingAvailable]=(1) OR [IsParkingAvailable]=(0)),
    CONSTRAINT [FK_Theatre_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_Theatre]
    ON [dbo].[Theatre]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[Theatre]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE Theatre.Id = i.Id
    END