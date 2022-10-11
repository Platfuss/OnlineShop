CREATE PROCEDURE [dbo].[spTest_Insert]
	@TestValue nvarchar(50)
AS
BEGIN
	INSERT INTO dbo.Test (TestProperty) VALUES (@TestValue);
END
