CREATE TABLE [dbo].[Discs] (
    [DiscID]  INT           NOT NULL,
    [Name]		NCHAR (20) NULL,
    [ArtistID]	    INT    NOT NULL,
    [GenreID]  INT NOT NULL,
	[Price]	INT NOT NULL,
	[IssueDate] DATETIME NOT NULL,
	[ImgPath] NCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([DiscID] ASC)
);
