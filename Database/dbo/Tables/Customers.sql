CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [InvoiceAdressId] INT NOT NULL, 
    [ShipmentAdressId] INT NULL, 
    CONSTRAINT [FK_ClientsInvoice_Adress] FOREIGN KEY ([InvoiceAdressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_ClientsShipment_Adress] FOREIGN KEY ([ShipmentAdressId]) REFERENCES [Address]([Id])
)
