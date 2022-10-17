CREATE PROCEDURE [dbo].[sp_Customers_Update]
	@Id INT,
    @Name NVARCHAR(20), 
    @Surname NVARCHAR(50),
    @Email NVARCHAR(100),
    @InvoiceAddressId INT, 
    @ShipmentAddressId INT
AS
BEGIN
	UPDATE [dbo].[Customers]
	SET [Name] = @Name, Surname = @Surname, Email = @Email, InvoiceAddressId = @InvoiceAddressId, ShipmentAddressId = @ShipmentAddressId
	WHERE Id = @Id;
END
