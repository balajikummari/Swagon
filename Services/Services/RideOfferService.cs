using Swagon.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Swagon.DataBase;
using FluentValidation;
namespace Swagon.Services
{

    public class RideOfferService : IRideOfferService
    {
        private readonly IRideOfferRepository repository;
        public RideOfferService(IRideOfferRepository repository)
        {
            this.repository = repository;
        }

        public void AddRideOffer(DomainModel.RideOffer rideOffer)
        {
            try
            {
                new RideOfferValidations().ValidateAndThrow(rideOffer.Map<DataBase.DataModel.RideOffer>(), RuleSets.RideOffer.General);
                string Id = repository.AddEntity(rideOffer.Map<DataBase.DataModel.RideOffer>());
                repository.AddStopsForRideOffer(rideOffer.CityIdsOfStops, repository.GetEntityByID(Id));
                repository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<DomainModel.RideOffer> GetAllRideOffers()
        {
            try
            {
                return repository.GetAllEntities().Map<IEnumerable<DomainModel.RideOffer>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }


        public IEnumerable<DomainModel.RideOffer> GetAllRideOffersOfaCountry(string countryCode)
        {
            try
            {
                new BasicStringValidations().Validate(countryCode, RuleSets.String.EmptyString);
                return repository.GetAllEntities().Where(o => o.CountryCode == countryCode).Map<IEnumerable<DomainModel.RideOffer>>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }


        public IEnumerable<DomainModel.RideOffer> GetRideOffersByUserID(string userID)
        {
            try
            {
                new BasicStringValidations().Validate(userID, RuleSets.String.EmptyString);
                return repository.GetRideOffersByUserID(userID).Map<IEnumerable<DomainModel.RideOffer>>();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public DomainModel.RideOffer GetRideOfferById(string RideOfferID)
        {
            try
            {
                new BasicStringValidations().Validate(RideOfferID, RuleSets.String.EmptyString);
                return repository.GetEntityByID(RideOfferID).Map<DomainModel.RideOffer>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
