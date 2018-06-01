CREATE PROCEDURE [dbo].[StP_ProductTotalByDate]
	@Id int,
	@begin DATETIME2,
	@end DATETIME2
AS
	SELECT SUM(ol.Price * ol.Quantity) 
	FROM OrderLine ol JOIN  [Order] as o ON ol.OrderID = o.Id 
	WHERE ol.ProductID = @Id AND o.OrderTime BETWEEN @begin AND @end AND o.Volunteer = 0
RETURN 0
