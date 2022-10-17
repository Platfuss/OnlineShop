CREATE PROCEDURE [dbo].[sp_Orders_Update]
	@Id INT,
	@CustomerId INT, 
    @InvoiceAddressId INT, 
    @ShipmentAddressId INT,
    @ShipmentType VARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[Orders]
	SET CustomerId = @CustomerId, InvoiceAddressId = @InvoiceAddressId, ShipmentAddressId = @ShipmentAddressId, ShipmentType = @ShipmentType
	WHERE Id = @Id;
END
