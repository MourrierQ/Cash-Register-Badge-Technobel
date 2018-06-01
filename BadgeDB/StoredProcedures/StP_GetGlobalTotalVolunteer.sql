CREATE PROCEDURE [dbo].[StP_GetGlobalTotalVolunteer]
AS
	SELECT SUM([Price] * [Quantity]) FROM VolunteerView
RETURN 0
