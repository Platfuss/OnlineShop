CREATE PROCEDURE [dbo].[sp_Customers_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[Customers]
	WHERE Id = @Id;
END
