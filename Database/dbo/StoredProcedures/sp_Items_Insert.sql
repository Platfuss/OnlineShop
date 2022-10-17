CREATE PROCEDURE [dbo].[sp_Items_Insert]
	@Id INT, 
    @Name NVARCHAR(50), 
    @Description NVARCHAR(2000), 
    @Price SMALLMONEY, 
    @Amount INT, 
    @Category NCHAR(100), 
    @ImagePaths NCHAR(500) 
AS
BEGIN
	INSERT INTO [dbo].[Items] ([Name], [Description], Price, Amount, Category, ImagePaths) 
        VALUES (@Name, @Description, @Price, @Amount, @Category, @ImagePaths)
END
