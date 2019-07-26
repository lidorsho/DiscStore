CREATE TABLE [dbo].[ARTISTS_GENRES_LINKS] (
    [LinkID]  INT           NOT NULL,
    [GenreID]		INT NOT NULL,
    [ArtistID]	    INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([LinkID] ASC)
);
