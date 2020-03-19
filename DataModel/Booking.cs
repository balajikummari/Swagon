namespace Swagon.DomainModel
{
    public class Booking : IEntity
    {
        public string Id { get; set; }
        public string BookingCreatorId { get; set; }
        public string RideOfferId { get; set; }
        public string FromCityId { get; set; }
        public string ToCityId { get; set; }
        public double BookingFare { get; set; }

        public BookingStatus Status { get; set; }
    }

    public enum BookingStatus
    {
        Requested,
        Booked,
        Rejected
    };
}
