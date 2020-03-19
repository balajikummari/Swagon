using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Swagon.DataBase.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Swagon.DataBase.Repositories
{
    public class EFCityRepository : EFRepository<City>, ICityRepository
    {
        public EFCityRepository(DbContext context) : base(context)
        {

        }

        public int GetPerKMFare()
        {
            try
            {
                return 5;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdatePerKmCharge(decimal charge)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public double GetDistance(GeoCoordinate FromCityId, GeoCoordinate ToCityId)
        {
            try
            {
                return FromCityId.GetDistanceTo(ToCityId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<string> GetCountryCodes()
        {
            try
            {
                return base.Context.Set<City>().Select(c => c.CountryCode).Distinct();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<City> GetCitiesOfCountry(string countryCode) 
        {
            try
            {
                new BasicStringValidations().ValidateAndThrow(countryCode, ruleSet: RuleSets.String.EmptyString);
                return base.Context.Set<City>().Where(c => c.CountryCode == countryCode).Select(c => c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void LoadCityData()
        {
            try
            {
                string json = System.IO.File.ReadAllText(@"C:\Users\balaji.k\Desktop\Cityjson.json");
                List<City> cities = JsonConvert.DeserializeObject<List<City>>(json);
                Context.AddRange(cities);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
