CREATE TABLE [dbo].[Stores] (
    [ID]                 INT           NOT NULL,
    [Name]               NVARCHAR (50) NULL,
    [LocationLongitude ] FLOAT (53)    NOT NULL,
    [LocationLatitude ]  FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
