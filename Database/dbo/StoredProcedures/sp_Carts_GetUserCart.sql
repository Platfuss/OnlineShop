CREATE PROCEDURE [dbo].[sp_Carts_GetUserCart]
	@CustomerId int
AS
BEGIN
	SELECT Id, CustomerId, ItemId, Amount
	FROM [dbo].[Carts]
	WHERE CustomerId = @CustomerId
END
