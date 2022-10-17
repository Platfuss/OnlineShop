CREATE PROCEDURE [dbo].[sp_Items_GetOne]
	@Id int
AS
BEGIN
	SELECT Id, [Name], [Description], Price, Amount, Category, ImagePaths
	FROM [dbo].[Items]
	WHERE Id = @Id
END

