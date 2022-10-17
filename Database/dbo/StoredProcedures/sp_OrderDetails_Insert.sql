CREATE PROCEDURE [dbo].[sp_OrderDetails_Insert]
	@Id INT, 
    @OrderId INT, 
    @ItemId INT, 
    @Amount INT
AS
BEGIN
	INSERT INTO [dbo].[OrderDetails] (OrderId, ItemId, Amount)
        VALUES (@OrderId, @ItemId, @Amount);
END
