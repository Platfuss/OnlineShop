CREATE TABLE [dbo].[OrderDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL, 
    [ItemId] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [FK_OrderDetails_Items] FOREIGN KEY ([ItemId]) REFERENCES [Items]([Id]), 
)
