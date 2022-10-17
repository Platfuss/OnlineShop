CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [InvoiceAddressId] INT NOT NULL, 
    [ShipmentAddressId] INT NULL, 
    CONSTRAINT [FK_CustomersInvoice_Address] FOREIGN KEY ([InvoiceAddressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_CustomersShipment_Address] FOREIGN KEY ([ShipmentAddressId]) REFERENCES [Address]([Id])
)
