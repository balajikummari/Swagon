CREATE TABLE [dbo].[RideOffer]
(
	[Id] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [OfferCreatorID] VARCHAR(50) NOT NULL, 
    [FromCityID] VARCHAR(50) NOT NULL, 
    [ToCityID] VARCHAR(50) NOT NULL, 
    [JourneyDate] VARCHAR(MAX) NOT NULL, 
    [EntireJourneyFare] BIGINT NOT NULL, 
    [CountryCode] VARCHAR(MAX) NOT NULL, 
  
)
