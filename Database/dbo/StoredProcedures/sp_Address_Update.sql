CREATE PROCEDURE [dbo].[sp_Address_Update]
	@Id int = 0,
	@City NVARCHAR(50),
	@Street NVARCHAR(50),
	@PostalCode NCHAR(6)
AS
BEGIN
	UPDATE [dbo].[Address]
	SET City = @City, Street = @Street, PostalCode = @PostalCode
	WHERE Id = @Id;
END
