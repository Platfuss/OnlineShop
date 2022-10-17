CREATE PROCEDURE [dbo].[sp_Customers_GetOne]
	@Id int
AS
BEGIN
	SELECT Id, [Name], Surname, Email, InvoiceAddressId, ShipmentAddressId
	FROM [dbo].[Customers]
	WHERE Id = @Id;
END

