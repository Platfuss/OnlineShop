CREATE PROCEDURE [dbo].[sp_Address_Insert]
	@Id int = 0,
	@City NVARCHAR(50),
	@Street NVARCHAR(50),
	@PostalCode NCHAR(6)
AS
BEGIN
	INSERT INTO [dbo].[Address] (City, Street, PostalCode) VALUES (@City, @Street, @PostalCode);
END
