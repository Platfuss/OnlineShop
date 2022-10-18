CREATE PROCEDURE [dbo].[sp_Customers_Update]
	@Id INT,
    @Name NVARCHAR(20), 
    @Surname NVARCHAR(50),
    @Email NVARCHAR(100),
    @InvoiceAddressId INT, 
    @ShipmentAddressId INT
AS
BEGIN
    DECLARE @TableHelper TABLE (Id INT,
                                [Name] NVARCHAR(20), 
                                Surname NVARCHAR(50),
                                Email NVARCHAR(100),
                                InvoiceAddressId INT, 
                                ShipmentAddressId INT);

	UPDATE [dbo].[Customers]
	SET [Name] = @Name, Surname = @Surname, Email = @Email, InvoiceAddressId = @InvoiceAddressId, ShipmentAddressId = @ShipmentAddressId
        OUTPUT INSERTED.Id, INSERTED.[Name], INSERTED.Surname, INSERTED.Email, INSERTED.InvoiceAddressId, INSERTED.ShipmentAddressId
        INTO @TableHelper
	WHERE Id = @Id;

    SELECT * FROM @TableHelper;
END
