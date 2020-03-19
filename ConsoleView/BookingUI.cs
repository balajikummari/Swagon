using Swagon.Services;
using Swagon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swagon.ConsoleView
{
    public class BookingUI
    {
        private readonly IBookingService BookingService;
        private readonly ICityService cityService = Program.container.GetInstance<CityService>();
        private readonly IUserService userService = Program.container.GetInstance<UserService>();
        private readonly IRideOfferService rideOfferService = Program.container.GetInstance<RideOfferService>();

        public BookingUI(IBookingService service)
        {
            BookingService = service;
        }

        internal void InitiateBooking(string userID, string offerId)
        {
            RideOfferViewModel rideOffer = rideOfferService.GetRideOfferById(offerId).MapV2D<RideOfferViewModel>();
            if (rideOffer.CityIdsOfStops.Count == 0)
            {
                BookingService.CreateBooking(new DomainModel.Booking()
                {
                    BookingCreatorId = userID,
                    FromCityId = rideOffer.FromCityId,
                    ToCityId = rideOffer.ToCityId,
                    BookingFare = rideOffer.EntireJourneyFare,
                    RideOfferId = rideOffer.Id,
                    Status = DomainModel.BookingStatus.Requested
                });

            }
            else
            {
                Console.WriteLine("1. Direct Journey 2. Select between Stops");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        BookingService.CreateBooking(new DomainModel.Booking()
                        {
                            BookingCreatorId = userID,
                            FromCityId = rideOffer.FromCityId,
                            ToCityId = rideOffer.ToCityId,
                            BookingFare = rideOffer.EntireJourneyFare,
                            RideOfferId = rideOffer.Id,
                            Status = DomainModel.BookingStatus.Requested
                        });
                        break;

                    case 2:
                        IEnumerable<string> stops = GetStopSelection(offerId);
                        BookingService.CreateBooking(new DomainModel.Booking()
                        {
                            BookingCreatorId = userID,
                            FromCityId = stops.ElementAt(0),
                            ToCityId = stops.ElementAt(1),
                            BookingFare = rideOffer.EntireJourneyFare,
                            RideOfferId = rideOffer.Id,
                            Status = DomainModel.BookingStatus.Requested
                        });


                        break;
                }
            }
        }

        internal IEnumerable<string> GetStopSelection(string offerId)
        {
            RideOfferViewModel rideOffer = rideOfferService.GetRideOfferById(offerId).MapV2D<RideOfferViewModel>();

            foreach (string stop in cityService.StopIdsToNames(rideOffer.CityIdsOfStops, rideOffer.CountryCode))
            {
                Console.WriteLine($" { stop }   ");
            }
            Console.WriteLine("Enter a Origin Stop");
            string origin = Console.ReadLine();

            Console.WriteLine("Enter a Destination Stop");
            string Destination = Console.ReadLine();
            List<string> stops = new List<string>();
            stops.Add(origin);
            stops.Add(Destination);
            return cityService.StopIdsToNames(stops, rideOffer.CountryCode);
        }

        internal void ShowBookingsOfOffer(string offerId)
        {
            BookingService.GetBookingsOfaOfferId(offerId);
        }

        internal void ShowBookingsOfUser(string userId)
        {
            PrintBookings(BookingService.GetBookingsDoneByUserId(userId).MapV2D<IEnumerable<BookingViewModel>>());
        }

        internal void UpdateBooking(string BookingId, int bookingStatus)
        {
            BookingService.UpdateBookingStatus(BookingId, bookingStatus);
        }

        public void PrintBooking(BookingViewModel booking)
        {


            Console.WriteLine($"BookingID       : {booking.Id}");
            Console.WriteLine($"Booked by       : {userService.GetUserById(booking.BookingCreatorId).Username}");

            Console.WriteLine($"RideOfferId     : {booking.RideOfferId}");
            Console.WriteLine($"Posted by       : {userService.GetUserById(rideOfferService.GetRideOfferById(booking.RideOfferId).OfferCreatorId).Username}");

            Console.WriteLine($"FromCity        : {cityService.GetCityById(booking.FromCityId).Name}");
            Console.WriteLine($"ToCity          : {cityService.GetCityById(booking.ToCityId).Name}");

            Console.WriteLine($"BookingFare     : {booking.BookingFare}");
            Console.WriteLine($"Booking Status  : {booking.Status}");
        }

        public void PrintBookings(IEnumerable<BookingViewModel> bookings)
        {
            foreach (BookingViewModel booking in bookings)
            {
                Console.WriteLine($"-----------------------------------------------------------------------------");
                PrintBooking(booking);
                Console.WriteLine($"-----------------------------------------------------------------------------");
            }
        }
    }
}
