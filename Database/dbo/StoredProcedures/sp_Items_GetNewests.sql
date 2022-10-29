CREATE PROCEDURE [dbo].[sp_Items_GetNewests]
AS
BEGIN
	SELECT TOP 4 
	*
	FROM [dbo].[Items]
	ORDER BY AddedToShop DESC;
END