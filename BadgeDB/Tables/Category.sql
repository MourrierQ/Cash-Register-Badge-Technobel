﻿CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CategoryName] NVARCHAR(20) NOT NULL,

	CONSTRAINT PK_Category PRIMARY KEY ([Id])
)
