CREATE PROCEDURE [dbo].[sp_Items_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Items]
	WHERE Id=@Id;
END
