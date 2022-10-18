CREATE PROCEDURE [dbo].[sp_Items_Update]
	@Id INT, 
    @Name NVARCHAR(50), 
    @Description NVARCHAR(2000), 
    @Price SMALLMONEY, 
    @Amount INT, 
    @Category NCHAR(100), 
    @ImagePaths NCHAR(500) 
AS
BEGIN
	DECLARE @TableHelper TABLE (Id INT, 
                                [Name] NVARCHAR(50), 
                                [Description] NVARCHAR(2000), 
                                Price SMALLMONEY, 
                                Amount INT, 
                                Category NCHAR(100), 
                                ImagePaths NCHAR(500));

	UPDATE [dbo].[Items]
	SET [Name] = @Name, [Description] = @Description, Price = @Price, Amount = @Amount, Category = @Category, ImagePaths = @ImagePaths
        OUTPUT INSERTED.Id, INSERTED.[Name], INSERTED.[Description], INSERTED.Price, INSERTED.Amount, INSERTED.Category, INSERTED.ImagePaths
        INTO @TableHelper
	WHERE Id = @Id;

    SELECT * FROM @TableHelper;
END
