using Swagon.DataBase.Repositories;
using System;

namespace Swagon.ConsoleView
{
    public class Startup
    {
        private readonly LoginOrSignup userView = new LoginOrSignup();
        private readonly EFCityRepository EFCityRepository = Program.container.GetInstance<EFCityRepository>();
        public void start()
        {

            bool key = true;
            while (key)
            {
                Console.WriteLine("");
                Console.WriteLine("1. Signup  2.Login 3.Load Data   0. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        userView.Signup();
                        break;
                    case "2":
                        userView.Login();
                        break;
                    case "3":
                        EFCityRepository.LoadCityData();
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
    }
}
