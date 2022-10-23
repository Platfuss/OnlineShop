CREATE TABLE [dbo].[Items]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(2000) NULL, 
    [Price] SMALLMONEY NOT NULL, 
    [Amount] INT NOT NULL, 
    [Category] NCHAR(100) NOT NULL, 
    [ImagePaths] NCHAR(500) NULL, 
    [AddedToShop] DATETIME2 NOT NULL
)
