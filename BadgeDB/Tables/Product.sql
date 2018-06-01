CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[ProductName] NVARCHAR(30) NOT NULL,
	[Price] DECIMAL(5,2) NOT NULL,
	[CategoryID] INT NOT NULL,

	CONSTRAINT PK_Product PRIMARY KEY([Id]), 
    CONSTRAINT [FK_Product_ToCategory] FOREIGN KEY ([CategoryID]) REFERENCES [Category]([Id]),
)
