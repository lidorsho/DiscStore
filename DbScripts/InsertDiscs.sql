USE [DiscStoreDB]
GO

INSERT INTO [dbo].[Discs] ([Name] ,[ArtistID], [GenreID], 
			   [Price],[IssueDate],[ImgPath])
     VALUES ( 'X',1, 2, 22,20/06/2014, 'Images\x.jpg');

INSERT INTO [dbo].[Discs] ([Name] ,[ArtistID], [GenreID], 
			   [Price],[IssueDate],[ImgPath])
     VALUES ( 'Divide',1, 2, 25,03/03/2017, 'Images\Divide_cover.jpg');

INSERT INTO [dbo].[Discs] ([Name] ,[ArtistID], [GenreID], 
			   [Price],[IssueDate],[ImgPath])
     VALUES ( 'Anti',3, 4, 35,28/01/2016, 'Images\Anti.jpg');

GO