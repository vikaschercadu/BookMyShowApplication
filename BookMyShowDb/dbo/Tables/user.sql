CREATE TABLE [dbo].[user] (
    [id]             INT          NOT NULL,
    [name]           VARCHAR (50) NOT NULL,
    [emailId]        VARCHAR (50) NOT NULL,
    [mobileNumber]   VARCHAR (10) NOT NULL,
    [createdOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([id] ASC)
);

