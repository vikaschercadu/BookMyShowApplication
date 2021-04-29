CREATE TABLE [dbo].[movieTicket] (
    [id]             INT          NOT NULL,
    [userId]         INT          NOT NULL,
    [seatNumber]     VARCHAR (4)  NOT NULL,
    [showId]         INT          NOT NULL,
    [showDate]       DATE         NOT NULL,
    [screenId]       INT          NOT NULL,
    [status]         INT          NOT NULL,
    [TicketPrice]    FLOAT (53)   NOT NULL,
    [convenienceFee] FLOAT (53)   NOT NULL,
    [TotalAmount]    FLOAT (53)   NOT NULL,
    [createdOn]      DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [createdBy]      VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    [lastModifiedOn] DATETIME     DEFAULT (sysdatetime()) NOT NULL,
    [lastModifiedBy] VARCHAR (30) DEFAULT (user_name()) NOT NULL,
    CONSTRAINT [PK_movieTicket] PRIMARY KEY CLUSTERED ([id] ASC, [seatNumber] ASC),
    CONSTRAINT [CK_seat_status] CHECK ([status]=(2) OR [status]=(1) OR [status]=(0)),
    CONSTRAINT [FK_movieTicket_seat] FOREIGN KEY ([seatNumber], [screenId]) REFERENCES [dbo].[seat] ([number], [screenId]),
    CONSTRAINT [FK_movieTicket_show] FOREIGN KEY ([showId], [showDate]) REFERENCES [dbo].[show] ([id], [showDate]),
    CONSTRAINT [FK_movieTicket_user] FOREIGN KEY ([userId]) REFERENCES [dbo].[user] ([id])
);


GO

CREATE TRIGGER [dbo].[Trigger_movieTicket]
    ON [dbo].[movieTicket]
    FOR UPDATE
    AS
    BEGIN
        UPDATE [dbo].[movieTicket]
        SET lastModifiedOn = SYSDATETIME(), lastModifiedBy =USER
        FROM Inserted i
        WHERE movieTicket.id = i.id
    END