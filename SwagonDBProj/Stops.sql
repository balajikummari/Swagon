CREATE TABLE [dbo].[Stops]
(
	[OfferID] VARCHAR(50) NOT NULL , 
    [CityIDofStop] VARCHAR(50) NOT NULL, 
    [Id] VARCHAR(50) NOT NULL, 
    [Sequence] INT NOT NULL, 
    CONSTRAINT [PK_Stops] PRIMARY KEY ([Id]), 

)
