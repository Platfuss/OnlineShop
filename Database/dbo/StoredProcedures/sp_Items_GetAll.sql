CREATE PROCEDURE [dbo].[sp_Items_GetAll]
AS
BEGIN
	SELECT Id, [Name], [Description], Price, Amount, Category, ImagePaths, AddedToShop
	FROM [dbo].[Items]
END

