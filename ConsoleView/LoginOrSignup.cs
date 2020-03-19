using Swagon.DomainModel;
using Swagon.Services;
using Swagon.ViewModels;
using System;


namespace Swagon.ConsoleView
{
    public class LoginOrSignup
    {
        private readonly IUserService userService = Program.container.GetInstance<UserService>();

        public void Signup()
        {
            Console.WriteLine("Signing Up !");

            Console.WriteLine("Enter UserName :");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Passsword :");
            string password = Console.ReadLine();

            userService.AddUser(new UserCredentials() { Username = userName, Password = password }.MapV2D<User>());
        }

        public void Login()
        {

            Console.WriteLine("Logging in !");
            Console.WriteLine("Enter UserName :");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Passsword :");
            string password = Console.ReadLine();

            string userId = userService.GetUserIdFromCredentials(new UserCredentials() { Username = userName, Password = password }.MapV2D<User>());

            if (userId == null)
            {
                Console.WriteLine("User Dose Not Exist");
                Console.WriteLine("");
            }
            else
            {
                UserDashBoard dashBoard = Program.container.GetInstance<UserDashBoard>();
                dashBoard.UserOptions(userId);
            }
        }


    }
}
