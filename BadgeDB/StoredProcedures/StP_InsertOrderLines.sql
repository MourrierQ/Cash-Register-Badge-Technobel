CREATE PROCEDURE [dbo].[StP_InsertOrderLines]
	@NewOrderLines [OrderLinesParam] READONLY
AS
	INSERT INTO [OrderLine]([OrderID],[ProductID],[Price],[Quantity]) 
	SELECT OrderID, ProductID, Price, Quantity FROM @NewOrderLines
RETURN 0
