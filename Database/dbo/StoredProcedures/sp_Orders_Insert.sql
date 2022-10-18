CREATE PROCEDURE [dbo].[sp_Orders_Insert]
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

	INSERT INTO [dbo].[Orders]
		OUTPUT INSERTED.Id, INSERTED.CustomerId, INSERTED.InvoiceAddressId, INSERTED.ShipmentAddressId, INSERTED.ShipmentAddressId
		INTO @TableHelper
	VALUES (@CustomerId, @InvoiceAddressId, @ShipmentAddressId, @ShipmentType);

	SELECT * FROM @TableHelper;
END
