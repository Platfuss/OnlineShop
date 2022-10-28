CREATE PROCEDURE [dbo].[PopulateData]
AS
BEGIN
	EXEC sp_Address_Insert @City = "Wrocław", @Street = "Legnicka", @PostalCode = "50-123";
	EXEC sp_Address_Insert @City = "Wrocław", @Street = "Górnickiego", @PostalCode = "52-456"
	EXEC sp_Address_Insert @City = "Sokołów Młp.", @Street = "Rzeszowska", @PostalCode = "36-050";
	EXEC sp_Address_Insert @City = "Rzeszów", @Street = "Architektów", @PostalCode = "37-167";

	EXEC sp_Customers_Insert @Name = "Eleonora", @Surname = "Zadecka", @Email = "eleonora.zadecka@o2.pl", @InvoiceAddressId = 1, @ShipmentAddressId = 2;
	EXEC sp_Customers_Insert @Name = "Władysław", @Surname = "Włodecki", @Email = "w.w@onet.pl", @InvoiceAddressId = 3, @ShipmentAddressId = null;
	EXEC sp_Customers_Insert @Name = "Tomek", @Surname = "Polok", @Email = "pl.polok.tttt@gmail.com", @InvoiceAddressId = 3, @ShipmentAddressId = null;
	EXEC sp_Customers_Insert @Name = "Aleksandra", @Surname = "Schabowicka", @Email = "smiesznymail@interia.pl", @InvoiceAddressId = 4, @ShipmentAddressId = null;

	EXEC sp_Items_Insert @Name = "Cegłówka", @Description = "Narzędzie do budowania domów i innych budowli", @Price = 3.5, @Amount = 2000, @Category = "Budowlane", @AddedToShop = "2022-10-23 08:24:10";
	EXEC sp_Items_Insert @Name = "Ubranie", @Description = "Materiał do okrywania ciała", @Price = 200, @Amount = 20, @Category = "Moda", @AddedToShop = "2022-10-23 08:26:13";
	EXEC sp_Items_Insert @Name = "Piosenka", @Description = "Utwór muzyczny do miłego spędzania czasu", @Price = 50, @Amount = 100, @Category = "Rozrywka", @AddedToShop = "2022-10-22 08:27:10";
	EXEC sp_Items_Insert @Name = "Krzesło", @Description = "Urządzenie do siadania", @Price = 250, @Amount = 10, @Category = "Umeblowanie", @AddedToShop = "2022-10-21 08:28:30";

	EXEC sp_Orders_Insert @CustomerId = 1, @InvoiceAddressId = 1, @ShipmentAddressId = 2, @ShipmentType = "Kurier";
	EXEC sp_Orders_Insert @CustomerId = 2, @InvoiceAddressId = 1, @ShipmentAddressId = 1, @ShipmentType = "InPost";

	EXEC sp_OrderDetails_Insert @OrderId = 1, @ItemId = 1, @Amount = 10;
	EXEC sp_OrderDetails_Insert @OrderId = 1, @ItemId = 2, @Amount = 1;
	EXEC sp_OrderDetails_Insert @OrderId = 1, @ItemId = 3, @Amount = 3;
	EXEC sp_OrderDetails_Insert @OrderId = 1, @ItemId = 4, @Amount = 1;
	EXEC sp_OrderDetails_Insert @OrderId = 2, @ItemId = 1, @Amount = 40;
	EXEC sp_OrderDetails_Insert @OrderId = 2, @ItemId = 3, @Amount = 20;
	EXEC sp_OrderDetails_Insert @OrderId = 2, @ItemId = 4, @Amount = 1;

	EXEC sp_Carts_Insert @CustomerId = 3, @ItemId = 2, @Amount = 5;
	EXEC sp_Carts_Insert @CustomerId = 3, @ItemId = 3, @Amount = 20;

END
