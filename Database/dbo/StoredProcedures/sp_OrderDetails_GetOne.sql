CREATE PROCEDURE [dbo].[sp_OrderDetails_GetOne]
	@Id int
AS
BEGIN
	SELECT Id, OrderId, ItemId, Amount
	FROM [dbo].[OrderDetails]
	WHERE Id = @Id
END

