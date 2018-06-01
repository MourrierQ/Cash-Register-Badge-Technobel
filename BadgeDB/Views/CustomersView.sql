CREATE VIEW [dbo].[CustomersView]
	AS SELECT * FROM OrderLine ol JOIN [Order] o 
	ON ol.OrderID = o.Id
	WHERE o.Volunteer = 0