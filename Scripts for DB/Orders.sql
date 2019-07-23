CREATE TABLE [dbo].[Orders] (
    [OrderID]  INT           NOT NULL,
    [UserID]        INT      NOT NULL,
    [OrderDate]     DATETIME NOT NULL,
    [DiscID]	    INT    NOT NULL,
    [StoreID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
);
