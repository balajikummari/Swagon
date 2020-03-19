using System.Collections.Generic;

namespace Swagon.Services
{
    public interface IRideOfferService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rideOffer"></param>
        public void AddRideOffer(DomainModel.RideOffer rideOffer);

        public IEnumerable<DomainModel.RideOffer> GetAllRideOffers();

        public DomainModel.RideOffer GetRideOfferById(string RideOfferID);

        public IEnumerable<DomainModel.RideOffer> GetRideOffersByUserID(string userID);

        public IEnumerable<DomainModel.RideOffer> GetAllRideOffersOfaCountry(string countryCode);

    }
}
