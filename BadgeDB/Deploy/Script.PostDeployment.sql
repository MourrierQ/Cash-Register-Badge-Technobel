/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET identity_insert [Category] ON
INSERT INTO Category([Id],[CategoryName]) VALUES(1,'Boissons');
INSERT INTO Category([Id],[CategoryName]) VALUES(2,'Bieres');
INSERT INTO Category([Id],[CategoryName]) VALUES(3,'Vins');
INSERT INTO Category([Id],[CategoryName]) VALUES(4,'Bouffe');
SET identity_insert [Category] OFF
GO

INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Café', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Thé', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Coca Cola', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Fanta', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Sprite', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Looza', 1, 1.70);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Eau', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Ice Tea', 1, 1.60);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Redbull', 1, 3);

INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Carlsberg', 2,		2.00);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Jupiler', 2,		1.70);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Duvel', 2,			3.50);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Beer', 2,			3.50);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('BG Beer', 2,		2.30);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Leffe Brune', 2,	3.50);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Leffe Blonde', 2,	3.50);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Chimay Bleu', 2,	3.00);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Hoegarden', 2,		2.00);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Kriek', 2,			2.50);

INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Vin Bouteille',				3,	15.00);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Vin Spécial(bout.)',		3,	 45.00);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Vin 1/2 bouteille',			3,	11.50);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Verre de vin',				3,   3.00);

INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Chips',						4,   1.00);
INSERT INTO Product([ProductName],[CategoryID],[Price]) VALUES('Croque-Monsieur',			4,   1.50);