CREATE PROCEDURE [dbo].[sp_Orders_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Orders]
	WHERE Id=@Id;
END
