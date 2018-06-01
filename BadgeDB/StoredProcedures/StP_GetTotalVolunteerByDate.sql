CREATE PROCEDURE [dbo].[StP_GetTotalVolunteerByDate]
	@begin DATETIME2,
	@end DATETIME2
AS
	SELECT SUM(Price * Quantity) FROM VolunteerView v JOIN [Order] o ON v.OrderID = o.Id AND o.OrderTime BETWEEN @begin and @end
RETURN 0
