CREATE TABLE [dbo].[Booking]
(
	[Id] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [BookingCreatorId] VARCHAR(50) NOT NULL, 
    [RideOfferId] VARCHAR(50) NOT NULL, 
    [FromCityId] VARCHAR(50) NOT NULL, 
    [ToCityID] VARCHAR(50) NOT NULL, 
    [Status] INT NOT NULL, 
    [BookingFare] VARCHAR(MAX) NOT NULL, 
)
