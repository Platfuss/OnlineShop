CREATE PROCEDURE [dbo].[sp_OrderDetails_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [dbo].[OrderDetails]
	WHERE Id=@Id;
END
