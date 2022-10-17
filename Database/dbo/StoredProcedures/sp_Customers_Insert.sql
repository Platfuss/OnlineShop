CREATE PROCEDURE [dbo].[sp_Customers_Insert]
	@Id INT,
    @Name NVARCHAR(20), 
    @Surname NVARCHAR(50),
    @Email NVARCHAR(100),
    @InvoiceAddressId INT, 
    @ShipmentAddressId INT
AS
BEGIN
	INSERT INTO [dbo].Customers ([Name], Surname, Email, InvoiceAddressId, ShipmentAddressId) 
		VALUES (@Name, @Surname, @Email, @InvoiceAddressId, @ShipmentAddressId)
END

