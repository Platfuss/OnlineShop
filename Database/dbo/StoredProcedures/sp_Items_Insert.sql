CREATE PROCEDURE [dbo].[sp_Items_Insert]
	@Id INT = 0, 
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
	INSERT [dbo].[Items]
        OUTPUT INSERTED.Id, INSERTED.[Name], INSERTED.[Description], INSERTED.Price, INSERTED.Amount, INSERTED.Category, INSERTED.AddedToShop
        INTO @TableHelper
    VALUES (@Name, @Description, @Price, @Amount, @Category, @AddedToShop);

    SELECT * FROM @TableHelper;
END
