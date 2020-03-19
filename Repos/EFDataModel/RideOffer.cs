namespace Swagon.DataBase.DataModel
{
    public partial class RideOffer : IEntity

    {
        public string Id { get; set; }
        public string OfferCreatorId { get; set; }
        public string FromCityId { get; set; }
        public string ToCityId { get; set; }
        public string JourneyDate { get; set; }
        public string CountryCode { get; set; }
        public long EntireJourneyFare { get; set; }
    }
}
