using System.Collections.Generic;

namespace Swagon.DomainModel
{
    public class RideOffer : IEntity
    {
        public string Id { get; set; }

        public string OfferCreatorId { get; set; }

        public string FromCityId { get; set; }
        public string ToCityId { get; set; }

        public string CountryCode { get; set; }

        public string JourneyDate { get; set; }
        public long EntireJourneyFare { get; set; }

        public List<string> CityIdsOfStops { get; set; }

    }
}
