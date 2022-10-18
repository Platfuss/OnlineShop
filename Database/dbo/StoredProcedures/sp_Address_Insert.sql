CREATE PROCEDURE [dbo].[sp_Address_Insert]
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

	INSERT [dbo].[Address] 
		OUTPUT INSERTED.Id, INSERTED.City, INSERTED.Street, INSERTED.PostalCode
		INTO @TableHelper
	VALUES (@City, @Street, @PostalCode);

	SELECT * FROM @TableHelper;
END
