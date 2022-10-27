CREATE TABLE [dbo].[Carts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [ItemId] INT NOT NULL, 
    [Amount] INT NOT NULL, 
    CONSTRAINT [FK_Carts_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]), 
    CONSTRAINT [FK_Carts_Items] FOREIGN KEY ([ItemId]) REFERENCES [Items]([Id]),
)
