CREATE PROCEDURE [dbo].[StP_GetGlobalTurnover]
AS
	SELECT SUM(Price * Quantity) 
	FROM CustomersView
RETURN 0
