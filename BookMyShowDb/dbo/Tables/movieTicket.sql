CREATE TABLE [dbo].[MovieTicket] (
    [Id]             INT          NOT NULL,
    [UserId]         INT          NOT NULL,
    [SeatNumber]     VARCHAR (4)  NOT NULL,
    [ShowId]         INT          NOT NULL,
    [ShowDate]       DATE         NOT NULL,
    [ScreenId]       INT          NOT NULL,
    [Status]         INT          NOT NULL,
    [TicketPrice]    FLOAT (53)   NOT NULL,
    [ConvenienceFee] FLOAT (53)   NOT NULL,
    [TotalAmount]    FLOAT (53)   NOT NULL,
    [CreatedOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [CreatedBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [LastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [LastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_MovieTicket] PRIMARY KEY CLUSTERED ([Id] ASC, [SeatNumber] ASC),
    CONSTRAINT [CK_MovieTicket_Status] CHECK ([Status] IN (0,1,2)),
    CONSTRAINT [FK_MovieTicket_Seat] FOREIGN KEY ([SeatNumber], [ScreenId]) REFERENCES [dbo].[Seat] ([Number], [ScreenId]),
    CONSTRAINT [FK_MovieTicket_Show] FOREIGN KEY ([ShowId], [ShowDate]) REFERENCES [dbo].[Show] ([Id], [ShowDate]),
    CONSTRAINT [FK_MovieTicket_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);


GO

CREATE TRIGGER [dbo].[Trigger_MovieTicket]
    ON [dbo].[MovieTicket]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[MovieTicket]
        SET LastModifiedOn = SYSDATETIME(), LastModifiedBy =USER
        FROM Inserted i
        WHERE MovieTicket.Id = i.Id
    END