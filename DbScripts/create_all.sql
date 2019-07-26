CREATE TABLE [dbo].[Artists] (
    [ArtistID]  INT           NOT NULL,
    [Name]		NCHAR (20) NULL,
    [Age]	    INT    NOT NULL,
    [Location]  NCHAR (30)    NOT NULL,
	[Language]	NCHAR(20) NOT NULL,
	[ImgPath] NCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([ArtistID] ASC)
);

CREATE TABLE [dbo].[Users] (
    [UserID]   INT        NOT NULL,
    [UserName] NCHAR (10) NOT NULL,
    [Password]  NCHAR (10) NOT NULL,
    [isAdmin]  BIT        NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

CREATE TABLE [dbo].[Stores] (
    [ID]                 INT           NOT NULL,
    [Name]               NVARCHAR (50) NULL,
    [LocationLongitude ] FLOAT (53)    NOT NULL,
    [LocationLatitude ]  FLOAT (53)    NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Orders] (
    [OrderID]  INT           NOT NULL,
    [UserID]        INT      NOT NULL,
    [OrderDate]     DATETIME NOT NULL,
    [DiscID]	    INT    NOT NULL,
    [StoreID]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
);

CREATE TABLE [dbo].[Genres] (
    [GenreID]   INT        NOT NULL,
    [GenreName] NCHAR (10) NOT NULL,
    [Description]  NCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([GenreID] ASC)
);

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

CREATE TABLE [dbo].[ARTISTS_GENRES_LINKS] (
    [LinkID]  INT           NOT NULL,
    [GenreID]		INT NOT NULL,
    [ArtistID]	    INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([LinkID] ASC)
);
