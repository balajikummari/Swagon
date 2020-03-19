CREATE TABLE [dbo].[City]
(
	[Id] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(MAX) NOT NULL, 
    [State] VARCHAR(MAX) NULL, 
    [Latitute] FLOAT NOT NULL, 
    [Longitude] FLOAT NOT NULL, 
    [Country] VARCHAR(MAX) NULL, 
    [CountryCode] VARCHAR(MAX) NULL
)
