CREATE PROCEDURE [dbo].[sp_Customers_GetAll]
AS
BEGIN
	SELECT Id, [Name], Surname, Email, InvoiceAddressId, ShipmentAddressId
	FROM [dbo].[Customers]
END

