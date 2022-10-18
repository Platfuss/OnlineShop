CREATE PROCEDURE [dbo].[sp_Orders_Update]
	@Id INT,
	@CustomerId INT, 
    @InvoiceAddressId INT, 
    @ShipmentAddressId INT,
    @ShipmentType VARCHAR(50)
AS
BEGIN
	DECLARE @TableHelper TABLE (Id INT,
								CustomerId INT, 
								InvoiceAddressId INT, 
								ShipmentAddressId INT,
								ShipmentType VARCHAR(50));

	UPDATE [dbo].[Orders]
	SET CustomerId = @CustomerId, InvoiceAddressId = @InvoiceAddressId, ShipmentAddressId = @ShipmentAddressId, ShipmentType = @ShipmentType
		OUTPUT INSERTED.Id, INSERTED.CustomerId, INSERTED.InvoiceAddressId, INSERTED.ShipmentAddressId, INSERTED.ShipmentAddressId
		INTO @TableHelper
	WHERE Id = @Id;
	SELECT * FROM @TableHelper;
END
