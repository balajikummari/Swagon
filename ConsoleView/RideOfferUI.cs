using Swagon.DomainModel;
using Swagon.Services;
using Swagon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swagon.ConsoleView
{
    public class RideOfferUI
    {
        private readonly IRideOfferService RideOfferservice;
        private readonly IBookingService bookingService = Program.container.GetInstance<BookingService>();
        private readonly ICityService cityService = Program.container.GetInstance<CityService>();
        private readonly CityUI CityUI = Program.container.GetInstance<CityUI>();
        private readonly BookingUI BookingUI = Program.container.GetInstance<BookingUI>();

        public RideOfferUI(IRideOfferService rideOfferService)
        {
            RideOfferservice = rideOfferService;
        }

        public void Post(string userId)
        {

            Console.Clear();
            Console.WriteLine($"ok {userId} you want to offer a ride ..");

            Console.WriteLine("Our Countries Of Operations : ");
            CityUI.DispalyCountyCodes();

            Console.Write("Enter a Country Code : ");
            string SelectedCountryCode = Console.ReadLine().ToUpper();
            Console.Clear();

            Console.WriteLine("Our Cities Of Operations : ");
            CityUI.DisplayCitiesOfCountry(SelectedCountryCode);

            Console.Write("Enter a Origin City Name  : ");
            string OriginCityName = Console.ReadLine();
            Console.Clear();

            City originCity = cityService.getCityByName(OriginCityName, SelectedCountryCode);

            Console.WriteLine("Our Cities Of Operations : ");
            CityUI.DisplayCitiesOfCountry(SelectedCountryCode);

            Console.Write("Enter a Destination City Name: ");
            CityUI.DisplayCitiesOfCountry(SelectedCountryCode);
            string DestinationCityName = Console.ReadLine();
            Console.Clear();

            City DestinationCity = cityService.getCityByName(DestinationCityName, SelectedCountryCode);

            Console.WriteLine("1.Direct Jounney      2.Add Stops in Bettween");
            int option = int.Parse(Console.ReadLine());
            List<string> stopNames = new List<string>();
            if (option == 2)
            {
                Console.WriteLine("Enter the Number of Stops you wish to make");
                int noOfStops = int.Parse(Console.ReadLine());
                for (int i = 1; i <= noOfStops; i++)
                {
                    Console.WriteLine("Our Cities Of Operations : ");
                    CityUI.DisplayCitiesOfCountry(SelectedCountryCode);

                    Console.Write($"Enter stop no {i}  City Name  : ");
                    string StopCityName = Console.ReadLine();

                    Console.Clear();
                    stopNames.Add(StopCityName);
                }
            }
            Console.Clear();
            Console.WriteLine("Enter a Date of journey ");
            string dateOfJourney = Console.ReadLine();

            RideOfferservice.AddRideOffer(new RideOfferViewModel()
            {
                CityIdsOfStops = cityService.StopNamesToIds(stopNames, SelectedCountryCode).ToList(),
                OfferCreatorId = userId,
                FromCityId = originCity.Id,
                ToCityId = DestinationCity.Id,
                EntireJourneyFare = cityService.GetFare(originCity, DestinationCity),
                CountryCode = SelectedCountryCode,
                JourneyDate = dateOfJourney
            }.MapV2D<RideOffer>()); ;
        }

        internal void MyPostings(string userId)
        {
            DisplayRideOffers(RideOfferservice.GetRideOffersByUserID(userId).MapV2D<IEnumerable<RideOfferViewModel>>());
            Console.Write("Enter a Offer ID to View Bookings or '0' to exit : ");
            string offerId = Console.ReadLine();
            if (offerId != "0")
            {
                BookingUI.PrintBookings(bookingService.GetBookingsOfaOfferId(offerId).MapV2D<IEnumerable<BookingViewModel>>());
            }
            Console.Write("Enter a Boooking ID to Update Booking Status or '0' to exit : : ");
            string bookingID = Console.ReadLine();
            if (bookingID != "0")
            {
                foreach (int i in Enum.GetValues(typeof(ViewModels.BookingStatus)))
                {
                    Console.Write($"{i}.{  Enum.GetName(typeof(ViewModels.BookingStatus), i)}");
                };
                int status = int.Parse(Console.ReadLine());
                BookingUI.UpdateBooking(bookingID, status);
            };
        }

        public void Search(string userID)
        {
            Console.Clear();
            Console.WriteLine($"ok {userID} you want to Book a ride ..");

            Console.WriteLine("Our Countries Of Operations : ");
            CityUI.DispalyCountyCodes();

            Console.Write("Enter a Country Code to Search Offer In that Country : ");
            string SelectedCountryCode = Console.ReadLine();
            Console.Clear();

            Console.Write("Offers In that Country : ");
            DisplayRideOffers(RideOfferservice.GetAllRideOffersOfaCountry(SelectedCountryCode).MapV2D<IEnumerable<RideOfferViewModel>>());

            Console.Write("Enter a RideOffer Id To Book or '0' To goBack : ");
            string selection = Console.ReadLine();
            if (selection == "0")
            {
                //goBack
            }
            else
            {
                BookingUI.InitiateBooking(userID, selection);
            }
        }

        public void DisplayaRideOffer(RideOfferViewModel offer)
        {
            Console.WriteLine($" OfferId          : {offer.Id} ");
            Console.WriteLine($" Posted By        : {offer.OfferCreatorId} ");
            Console.WriteLine($"");
            Console.WriteLine($" origin City  Id  : {offer.FromCityId} ");
            Console.WriteLine($" Destination  Id  : {offer.ToCityId} ");
            Console.WriteLine($"");
            Console.WriteLine($"origin City       : {cityService.GetCityById(offer.FromCityId).Name}");
            Console.WriteLine($"Destination City  : {cityService.GetCityById(offer.ToCityId).Name}");

            Console.WriteLine($" No of Stops      : {offer.CityIdsOfStops.Count} ");

            foreach (string city in offer.CityIdsOfStops)
            {
                Console.WriteLine($" Stop no {offer.CityIdsOfStops.IndexOf(city) + 1 } : {city} ");
            }
            Console.WriteLine($" Fare for Entire Journey : {offer.EntireJourneyFare}");
            Console.WriteLine($" No of Bookings : {bookingService.GetBookingsOfaOfferId(offer.Id).MapV2D<IEnumerable<BookingViewModel>>().Count()}");
            Console.WriteLine($"");
        }

        public void DisplayRideOffers(IEnumerable<RideOfferViewModel> offers)
        {
            foreach (RideOfferViewModel rideOffer in offers)
            {
                Console.WriteLine($"-----------------------------------------------------------------------------");
                DisplayaRideOffer(rideOffer);
                Console.WriteLine($"-----------------------------------------------------------------------------");
            }
        }
    }
}
