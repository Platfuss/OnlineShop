CREATE PROCEDURE [dbo].[sp_Items_InCategory]
	@Category NCHAR(100)
AS
BEGIN
	SELECT Id, [Name], [Description], Price, Amount, Category, ImagePaths, AddedToShop
	FROM [dbo].[Items]
	WHERE Category = @Category
END

