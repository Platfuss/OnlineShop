CREATE PROCEDURE [dbo].[sp_Address_Update]
	@Id int = 0,
	@City NVARCHAR(50),
	@Street NVARCHAR(50),
	@PostalCode NCHAR(6)
AS
BEGIN
	DECLARE @TableHelper TABLE (Id int,
								City NVARCHAR(50),
								Street NVARCHAR(50),
								PostalCode NCHAR(6));
	UPDATE [dbo].[Address]
	SET City = @City, Street = @Street, PostalCode = @PostalCode
		OUTPUT INSERTED.Id, INSERTED.City, INSERTED.Street, INSERTED.PostalCode
		INTO @TableHelper
	WHERE Id = @Id;

	SELECT * FROM @TableHelper;
END
