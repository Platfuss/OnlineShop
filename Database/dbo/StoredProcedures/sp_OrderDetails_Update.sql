CREATE PROCEDURE [dbo].[sp_OrderDetails_Update]
	@Id INT, 
    @OrderId INT, 
    @ItemId INT, 
    @Amount INT
AS
BEGIN
	DECLARE @TableHelper TABLE (Id INT, 
                                OrderId INT, 
                                ItemId INT, 
                                Amount INT);

	UPDATE [dbo].[OrderDetails]
	SET OrderId = @OrderId, ItemId = @ItemId, Amount = @Amount
        OUTPUT INSERTED.Id, INSERTED.OrderId, INSERTED.ItemId, INSERTED.Amount
        INTO @TableHelper
	WHERE Id = @Id;

    SELECT * FROM @TableHelper;
END
