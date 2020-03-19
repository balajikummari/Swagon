CREATE TABLE [dbo].[user]
(
	[Id] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [username] VARCHAR(MAX) NOT NULL, 
    [Password] VARCHAR(MAX) NOT NULL, 
    [firstname] VARCHAR(MAX) NULL, 
    [lastname] VARCHAR(MAX) NULL, 
    [phonenumber] VARCHAR(MAX) NULL, 
    [cityofliving] VARCHAR(MAX) NULL, 
    [secretInfo] VARCHAR(MAX) NULL
)
