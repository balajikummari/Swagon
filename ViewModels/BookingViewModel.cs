namespace Swagon.ViewModels
{
    public class BookingViewModel : Entity
    {
        public string BookingCreatorId { get; set; }
        public string RideOfferId { get; set; }
        public string FromCityId { get; set; }
        public string ToCityId { get; set; }
        public string BookingFare { get; set; }

        public BookingStatus Status { get; set; }

    }

    public class BookingStatusViewModel : Entity
    {

        public BookingStatus Status { get; set; }
    }

    public enum BookingStatus
    {
        Requested,
        Booked,
        Rejected
    };
}
