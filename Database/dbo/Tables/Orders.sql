CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CustomerId] INT NOT NULL, 
    [InvoiceAddressId] INT NOT NULL, 
    [ShipmentAddressId] INT NULL,
    [ShipmentType] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_Orders_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]), 
    CONSTRAINT [FK_OrdersInvoice_Address] FOREIGN KEY ([InvoiceAddressId]) REFERENCES [Address]([Id]), 
    CONSTRAINT [FK_OrdersShipment_Address] FOREIGN KEY ([ShipmentAddressId]) REFERENCES [Address]([Id]) 
)
