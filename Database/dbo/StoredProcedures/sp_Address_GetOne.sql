CREATE PROCEDURE [dbo].[sp_Address_GetOne]
	@Id int
AS
BEGIN
	SELECT Id, City, Street, PostalCode
	FROM [dbo].[Address]
	WHERE Id = @Id;
END
