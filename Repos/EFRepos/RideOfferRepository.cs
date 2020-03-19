using Microsoft.EntityFrameworkCore;
using Swagon.DataBase.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
namespace Swagon.DataBase.Repositories
{
    public class RideOfferRepository : EFRepository<RideOffer>, IRideOfferRepository
    {

        public RideOfferRepository(DbContext context) : base(context)
        {

        }

        public void AddStopsForRideOffer(List<string> CityIdsOfStops, RideOffer rideOffer)
        {
            try
            {
                new RideOfferValidations().ValidateAndThrow(rideOffer,ruleSet : RuleSets.RideOffer.General);
                int counter = 0;
                foreach (string stop in CityIdsOfStops)
                {
                    counter += 1;
                    Context.Set<Stops>().Add(new Stops() { CityIdofStop = stop, OfferId = rideOffer.Id, Sequence = counter });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<RideOffer> GetRideOffersByUserID(string userId)
        {
            try
            {
                new BasicStringValidations().ValidateAndThrow(userId);
                return Context.Set<RideOffer>().Where(o => o.OfferCreatorId == userId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
