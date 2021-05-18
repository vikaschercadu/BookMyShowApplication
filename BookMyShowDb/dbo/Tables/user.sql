CREATE TABLE [dbo].[User] (
    [Id]             INT          NOT NULL,
    [Name]           VARCHAR (50) NOT NULL,
    [EmailId]        VARCHAR (50) NOT NULL,
    [MobileNumber]   VARCHAR (10) NOT NULL,
    [CreatedOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

