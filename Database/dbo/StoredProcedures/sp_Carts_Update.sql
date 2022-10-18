CREATE PROCEDURE [dbo].[sp_Carts_Update]
	@Id INT,
    @CustomerId INT,
    @ItemId INT,
    @Amount INT
AS
BEGIN
	DECLARE @TableHelper TABLE (Id INT,
                                CustomerId INT,
                                ItemId INT,
                                Amount INT);

	UPDATE [dbo].[Carts]
    SET CustomerId = @CustomerId, ItemId = @ItemId, Amount = @Amount
        OUTPUT INSERTED.Id, INSERTED.CustomerId, INSERTED.ItemId, INSERTED.Amount
		INTO @TableHelper
    WHERE Id = @Id;

    SELECT * FROM @TableHelper;
END
