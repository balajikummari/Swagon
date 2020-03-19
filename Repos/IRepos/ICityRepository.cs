using GeoCoordinatePortable;
using Swagon.DataBase.DataModel;
using System.Collections.Generic;

namespace Swagon.DataBase.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        /// <summary>
        /// Get the Fare per kilometer to caliculate the ride fire
        /// </summary>
        /// <returns>Fare per kilometer</returns>
        public int GetPerKMFare();

        /// <summary>
        /// Updates the Fare per kilometer
        /// </summary>
        /// <param name="charge">deciaml value for Fare per Kilometer</param>
        public void UpdatePerKmCharge(decimal charge);

        /// <summary>
        /// Get Distance Between two cities
        /// </summary>
        /// <param name="FromCityId">City ID of the Origin City</param>
        /// <param name="ToCityId">City ID of Destination City</param>
        /// <returns>Double value of Distance between two cities</returns>
        public double GetDistance(GeoCoordinate FromCityId, GeoCoordinate ToCityId);

        /// <summary>
        /// Get the list of codes of all servisable countries
        /// </summary>
        /// <returns> list of Country Codes</returns>
        public IEnumerable<string> GetCountryCodes();

        /// <summary>
        /// Get cities of a particular country 
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns>List of cities</returns>
        public IEnumerable<City> GetCitiesOfCountry(string countryCode);
    }
}
