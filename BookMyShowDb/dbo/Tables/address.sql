CREATE TABLE [dbo].[Address] (
    [Id]             INT          NOT NULL,
    [BuildingNumber] VARCHAR (20) NOT NULL,
    [StreetName]     VARCHAR (50) NOT NULL,
    [Landmark]       VARCHAR (50) NULL,
    [CityId]         INT          NOT NULL,
    [CreatedOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Address_City] FOREIGN KEY ([CityId]) REFERENCES [dbo].[City] ([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_Address]
    ON [dbo].[Address]
    AFTER UPDATE
    AS
    BEGIN
        UPDATE [dbo].[Address]
        SET LastModifiedOn = SYSDATETIME() , LastModifiedBy =USER 
        FROM Inserted i
        WHERE Address.Id = i.Id
    END