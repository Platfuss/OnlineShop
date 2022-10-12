CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ClientId] INT NOT NULL, 
    [InvoiceAdressId] INT NOT NULL, 
    [ShipmentAdressId] INT NULL,
    [ShipmentType] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_OrdersInvoice_Adress] FOREIGN KEY ([InvoiceAdressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_OrdersShipment_Adress] FOREIGN KEY ([ShipmentAdressId]) REFERENCES [Address]([Id])
)
