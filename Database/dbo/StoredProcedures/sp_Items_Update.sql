CREATE PROCEDURE [dbo].[sp_Items_Update]
	@Id INT, 
    @Name NVARCHAR(50), 
    @Description NVARCHAR(2000), 
    @Price SMALLMONEY, 
    @Amount INT, 
    @Category NVARCHAR(100),
    @AddedToShop DATETIME2
AS
BEGIN
	DECLARE @TableHelper TABLE (Id INT, 
                                [Name] NVARCHAR(50), 
                                [Description] NVARCHAR(2000), 
                                Price SMALLMONEY, 
                                Amount INT, 
                                Category NVARCHAR(100),
                                AddedToShop DATETIME2);

	UPDATE [dbo].[Items]
	SET [Name] = @Name, [Description] = @Description, Price = @Price, Amount = @Amount, Category = @Category, AddedToShop = @AddedToShop
        OUTPUT INSERTED.Id, INSERTED.[Name], INSERTED.[Description], INSERTED.Price, INSERTED.Amount, INSERTED.Category, INSERTED.AddedToShop
        INTO @TableHelper
	WHERE Id = @Id;

    SELECT * FROM @TableHelper;
END
