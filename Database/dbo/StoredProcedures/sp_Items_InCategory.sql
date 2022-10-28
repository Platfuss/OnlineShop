CREATE PROCEDURE [dbo].[sp_Items_InCategory]
	@Category NVARCHAR(100)
AS
BEGIN
	SELECT Id, [Name], [Description], Price, Amount, Category, AddedToShop
	FROM [dbo].[Items]
	WHERE Category = @Category
END

