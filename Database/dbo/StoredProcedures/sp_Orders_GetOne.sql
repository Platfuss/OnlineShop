CREATE PROCEDURE [dbo].[sp_Orders_GetOne]
	@Id int
AS
BEGIN
	SELECT Id, CustomerId, InvoiceAddressId, ShipmentAddressId, ShipmentType
	FROM [dbo].[Orders]
	WHERE Id = @Id
END

