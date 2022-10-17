CREATE PROCEDURE [dbo].[sp_OrderDetails_Update]
	@Id INT, 
    @OrderId INT, 
    @ItemId INT, 
    @Amount INT
AS
BEGIN
	UPDATE [dbo].[OrderDetails]
	SET OrderId = @OrderId, ItemId = @ItemId, Amount = @Amount
	WHERE Id = @Id;
END
