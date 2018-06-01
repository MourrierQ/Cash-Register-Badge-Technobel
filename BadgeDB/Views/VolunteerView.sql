CREATE VIEW [dbo].[VolunteerView]
	AS SELECT * FROM [OrderLine] ol JOIN [Order] o ON ol.OrderID = o.Id WHERE o.Volunteer = 1
	