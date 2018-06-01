CREATE PROCEDURE [dbo].[StP_GetTurnoverByDate]
	@begin DATETIME2,
	@end DATETIME2
AS
	SELECT SUM(Price * Quantity) FROM CustomersView
	WHERE OrderTime BETWEEN @begin AND @end
RETURN 0
