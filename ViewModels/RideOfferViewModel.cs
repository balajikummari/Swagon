using System.Collections.Generic;

namespace Swagon.ViewModels
{
    public class RideOfferViewModel : Entity
    {
        public string OfferCreatorId { get; set; }
        public string FromCityId { get; set; }
        public string ToCityId { get; set; }
        public string JourneyDate { get; set; }
        public double EntireJourneyFare { get; set; }
        public string CountryCode { get; set; }

        public List<string> CityIdsOfStops { get; set; }
    }
}
