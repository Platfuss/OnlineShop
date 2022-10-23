CREATE PROCEDURE [dbo].[sp_Customers_Insert]
	@Id INT = 0,
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
	INSERT [dbo].[Customers]
        OUTPUT INSERTED.Id, INSERTED.[Name], INSERTED.Surname, INSERTED.Email, INSERTED.InvoiceAddressId, INSERTED.ShipmentAddressId
        INTO @TableHelper
	VALUES (@Name, @Surname, @Email, @InvoiceAddressId, @ShipmentAddressId);

    SELECT * FROM @TableHelper;
END

