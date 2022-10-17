CREATE PROCEDURE [dbo].[sp_Carts_Update]
	@Id INT,
    @CustomerId INT,
    @ItemId INT,
    @Amount INT
AS
BEGIN
	UPDATE [dbo].[Carts]
    SET CustomerId = @CustomerId, ItemId = @ItemId, Amount = @Amount
    WHERE Id = @Id;
END
