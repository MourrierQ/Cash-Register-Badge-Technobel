CREATE TYPE [dbo].[OrderLinesParam] AS TABLE
(
	OrderID INT,
	ProductID INT,
	Price DECIMAL(5,2),
	Quantity INT
)
