using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Swagon.DataBase.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swagon.DataBase.Repositories
{
    public class BookingRepository : EFRepository<Booking>, IBookingRepository
    {

        public BookingRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Booking> GetBookingOfaUser(string userId)
        {
            new BasicStringValidations().ValidateAndThrow(userId);

            try
            {
                return base.Context.Set<Booking>().Where(b => b.BookingCreatorId == userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<Booking> GetBookingsOfOfferId(string OfferId)
        {
            new BasicStringValidations().ValidateAndThrow(OfferId);
            try
            {
                return base.Context.Set<Booking>().Where(b => b.RideOfferId == OfferId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdateBookingStatus(string bookingID, int Status)
        {
            new BasicStringValidations().ValidateAndThrow(bookingID);

            try
            {
                base.Context.Set<Booking>().FirstOrDefault(b => b.Id == bookingID).Status = Status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
