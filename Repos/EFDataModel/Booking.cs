namespace Swagon.DataBase.DataModel
{
    public partial class Booking : IEntity
    {
        public string Id { get; set; }
        public string BookingCreatorId { get; set; }
        public string RideOfferId { get; set; }
        public string FromCityId { get; set; }
        public string ToCityId { get; set; }
        public string BookingFare { get; set; }

        public int Status { get; set; }
    }
}
