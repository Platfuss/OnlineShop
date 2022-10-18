CREATE PROCEDURE [dbo].[sp_Carts_Insert]
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

	INSERT INTO [dbo].[Carts] 
    	OUTPUT INSERTED.Id, INSERTED.CustomerId, INSERTED.ItemId, INSERTED.Amount
		INTO @TableHelper
    VALUES (@CustomerId, @ItemId, @Amount);

    SELECT * FROM @TableHelper;
END
