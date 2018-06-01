CREATE TABLE [dbo].[OrderLine]
(
	[ProductID] INT NOT NULL,
	[OrderID] INT NOT NULL,
	[Price] DECIMAL(5,2) NOT NULL,
	[Quantity] INT NOT NULL

	CONSTRAINT PK_OrderLine PRIMARY KEY([ProductID],[OrderID]), 
    CONSTRAINT [FK_OrderLine_ToProduct] FOREIGN KEY ([ProductID]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_OrderLine_ToOrder] FOREIGN KEY ([OrderID]) REFERENCES [Order]([Id])
)
