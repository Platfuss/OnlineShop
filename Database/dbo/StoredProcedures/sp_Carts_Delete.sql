CREATE PROCEDURE [dbo].[sp_Carts_Delete]
	@CustomerId int,
	@ItemId int
AS
BEGIN
	DELETE
	FROM [dbo].[Carts]
	WHERE CustomerId = @CustomerId AND ItemId = @ItemId;
END
