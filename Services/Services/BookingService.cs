using Swagon.DataBase.Repositories;
using Swagon.DomainModel;
using System;
using System.Collections.Generic;


namespace Swagon.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository repository;
        public BookingService(IBookingRepository repository)
        {
            this.repository = repository;
        }

        public void CreateBooking(Booking Booking)
        {
            try
            {
                repository.AddEntity(Booking.Map<DataBase.DataModel.Booking>());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public Booking GetBookingByID(string BookingId)
        {
            try
            {
                return repository.GetEntityByID(BookingId).Map<Booking>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<Booking> GetBookingsDoneByUserId(string userId)
        {
            try
            {
                return repository.GetBookingOfaUser(userId).Map<IEnumerable<Booking>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<Booking> GetBookingsOfaOfferId(string OfferID)
        {
            try
            {
                return repository.GetBookingOfaUser(OfferID).Map<IEnumerable<Booking>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdateBookingStatus(string bookingId, int bookingStatus)
        {
            try
            {
                repository.UpdateBookingStatus(bookingId, bookingStatus);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }

}

