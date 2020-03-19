using Swagon.DataBase.DataModel;
using System.Collections.Generic;

namespace Swagon.DataBase.Repositories
{
    public interface IRideOfferRepository : IRepository<RideOffer>
    {
        /// <summary>
        /// Get All the Ride offers of a User by his Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>list of Ridea if sucessfull </returns>
        public IEnumerable<RideOffer> GetRideOffersByUserID(string userId);

        /// <summary>
        /// Add Stops to an Ride offer that is being created
        /// </summary>
        /// <param name="CityIdsOfStops">List of stop Ids</param>
        /// <param name="rideOffer"> Ride offer to which the stops are being added </param>
        public void AddStopsForRideOffer(List<string> CityIdsOfStops, RideOffer rideOffer);

    }
}
