CREATE PROCEDURE [dbo].[sp_Items_GetAll]
AS
BEGIN
	SELECT Id, [Name], [Description], Price, Amount, Category, AddedToShop
	FROM [dbo].[Items]
END

