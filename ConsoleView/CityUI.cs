using Swagon.Services;
using Swagon.ViewModels;
using System;
using System.Collections.Generic;

namespace Swagon.ConsoleView
{
    internal class CityUI
    {
        private readonly ICityService cityService;
        public CityUI(ICityService _cityService)
        {
            cityService = _cityService;
        }


        public void DispalyCountyCodes()
        {
            foreach (var countryCode in cityService.GetCountryCodes())
            {
                Console.WriteLine(countryCode);
            }
        }

        public void DisplayCitiesOfCountry(string countryCode)
        {
            DisplayCities(cityService.GetCitiesOfaCountry(countryCode).MapV2D<IEnumerable<CityViewModel>>());
        }

        public void DisplayCity(CityViewModel City)
        {
            Console.WriteLine($"{City.Name},{City.State},{City.Country}");
        }

        public void DisplayCities(IEnumerable<CityViewModel> cities)
        {
            foreach (var city in cities)
            {
                DisplayCity(city);
            }
        }
    }
}
