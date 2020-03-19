using Swagon.Services;
using Swagon.ViewModels;
using System;

namespace Swagon.ConsoleView
{
    public class UserDashBoard
    {
        private string userId;
        private readonly IUserService userService;

        public UserDashBoard(IUserService _userService)
        {
            userService = _userService;
        }


        public void UserOptions(string userId)
        {
            this.userId = userId;
            UserCredentials user = userService.GetUserById(userId).MapV2D<ViewModels.UserCredentials>();
            RideOfferUI rideOffer = Program.container.GetInstance<RideOfferUI>();
            BookingUI bookingUI = Program.container.GetInstance<BookingUI>();

            Console.Clear();
            Console.WriteLine($"Welcome MR.{user.Username} !!!");
            bool key = true;

            while (key)
            {

                Console.WriteLine("");
                Console.WriteLine("1. Edit Profile       2. Show Profile        0. log Out");
                Console.WriteLine("3. Search For a Ride  4. Post a Ride offer");
                Console.WriteLine("5. My Offer postings  6. My Bookings");

                switch (Console.ReadLine())
                {
                    case "1":
                        UpdateProfile(userId);
                        break;
                    case "2":
                        ShowProfile(userId);
                        break;
                    case "3":
                        rideOffer.Search(userId);
                        break;
                    case "4":
                        rideOffer.Post(userId);
                        break;
                    case "5":
                        rideOffer.MyPostings(userId);
                        break;
                    case "6":
                        bookingUI.ShowBookingsOfUser(userId);
                        break;
                    case "0":
                        key = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        public void UpdateProfile(string userId)
        {
            UserMetaData user = userService.GetUserById(userId).MapV2D<ViewModels.UserMetaData>();
            Console.WriteLine("");


            Console.WriteLine("");
            Console.WriteLine("FirstName :");
            user.Firstname = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("LastName :");
            user.Lastname = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("PhoneNumber :");
            user.Phonenumber = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("CityOfliving :");
            user.Cityofliving = Console.ReadLine();

            userService.UpdateUserProfile(user.MapV2D<DomainModel.User>());
            ShowProfile(userId);
        }

        public void ShowProfile(string userId)
        {
            UserMetaData user = userService.GetUserById(userId).MapV2D<ViewModels.UserMetaData>();
            Console.WriteLine("");
            Console.WriteLine($" ID         : {user.Id} \n FirstName \t {user.Firstname}");

            Console.WriteLine("");


            Console.WriteLine("");
            Console.WriteLine($"FirstName   :{user.Firstname}");

            Console.WriteLine("");
            Console.WriteLine($"LastName    :{user.Lastname}");

            Console.WriteLine("");
            Console.WriteLine($"PhoneNumber :{user.Phonenumber}");

            Console.WriteLine("");
            Console.WriteLine($"CityOfliving :{user.Cityofliving}");
            Console.ReadKey();

        }
    }
}
