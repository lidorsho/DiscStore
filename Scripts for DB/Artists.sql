CREATE TABLE [dbo].[Artists] (
    [ArtistID]  INT           NOT NULL,
    [Name]		NCHAR (20) NULL,
    [Age]	    INT    NOT NULL,
    [Location]  NCHAR (30)    NOT NULL,
	[Language]	NCHAR(20) NOT NULL,
	[ImgPath] NCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([ArtistID] ASC)
);
