using Swagon.DataBase.DataModel;
using System.Collections.Generic;

namespace Swagon.DataBase.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        /// <summary>
        /// Updates the status of a booking
        /// </summary>
        /// <param name="bookingID">ID of the booking to be updated</param>
        /// <param name="Status">Sataus that has to be assigined to the booking</param>
        public void UpdateBookingStatus(string bookingID, int Status);

        /// <summary>
        /// Get All the bookings made by a user
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>List of Bookings</returns>
        public IEnumerable<Booking> GetBookingOfaUser(string userId);

        /// <summary>
        /// Gets all the Bookings made for a particular Offer
        /// </summary>
        /// <param name="OfferId">Id of ther Offer</param>
        /// <returns>List of Bookings</returns>
        public IEnumerable<Booking> GetBookingsOfOfferId(string OfferId);
    }
}
