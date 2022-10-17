CREATE PROCEDURE [dbo].[sp_Carts_Insert]
	@Id INT,
    @CustomerId INT,
    @ItemId INT,
    @Amount INT
AS
BEGIN
	INSERT INTO [dbo].[Carts] (CustomerId, ItemId, Amount)
        VALUES (@CustomerId, @ItemId, @Amount)
END
