using Swagon.DomainModel;
using System.Collections.Generic;


namespace Swagon.Services
{
    public interface IBookingService
    {
        public void CreateBooking(Booking booking);
        public Booking GetBookingByID(string BookingId);
        public IEnumerable<Booking> GetBookingsDoneByUserId(string userId);
        public IEnumerable<Booking> GetBookingsOfaOfferId(string OfferID);
        public void UpdateBookingStatus(string bookingId, int bookingStatus);
    }

}

