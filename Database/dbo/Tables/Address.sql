﻿CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [City] NVARCHAR(50) NOT NULL, 
    [Street] NVARCHAR(50) NOT NULL, 
    [PostalCode] NCHAR(6) NOT NULL 
)
