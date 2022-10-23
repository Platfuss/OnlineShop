CREATE PROCEDURE [dbo].[sp_OrderDetails_Insert]
	@Id INT = 0, 
    @OrderId INT, 
    @ItemId INT, 
    @Amount INT
AS
BEGIN
	DECLARE @TableHelper TABLE (Id INT, 
                                OrderId INT, 
                                ItemId INT, 
                                Amount INT);

	INSERT [dbo].[OrderDetails]
        OUTPUT INSERTED.Id, INSERTED.OrderId, INSERTED.ItemId, INSERTED.Amount
        INTO @TableHelper
    VALUES (@OrderId, @ItemId, @Amount);

    SELECT * FROM @TableHelper;
END
