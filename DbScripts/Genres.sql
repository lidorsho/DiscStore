CREATE TABLE [dbo].[Genres] (
    [GenreID]   INT        NOT NULL,
    [GenreName] NCHAR (10) NOT NULL,
    [Description]  NCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([GenreID] ASC)
);
