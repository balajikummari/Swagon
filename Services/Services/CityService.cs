using FluentValidation;
using GeoCoordinatePortable;
using Swagon.DataBase;
using Swagon.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Swagon.Services
{

    public class CityService : ICityService
    {
        private readonly ICityRepository repository;
        public CityService(ICityRepository repository)
        {
            this.repository = repository;
        }

        public DomainModel.City GetCityById(string cityId)
        {
            try
            {
                new BasicStringValidations().Validate(cityId, RuleSets.String.EmptyString);
                return repository.GetEntityByID(cityId).Map<DomainModel.City>();
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
                return repository.GetCountryCodes();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public double GetFare(string FromCityID, string ToCityID)
        {
            try
            {
                new BasicStringValidations().ValidateAndThrow(FromCityID, ruleSet: RuleSets.String.EmptyString);
                new BasicStringValidations().ValidateAndThrow(ToCityID, ruleSet: RuleSets.String.EmptyString);
                var FromCity = repository.GetEntityByID(FromCityID);
                var ToCity = repository.GetEntityByID(ToCityID);

                GeoCoordinate geoCoordinateOrigin = new GeoCoordinate() { Latitude = FromCity.Latitute, Longitude = FromCity.Longitude };
                GeoCoordinate geoCoordinateDestinaton = new GeoCoordinate() { Latitude = ToCity.Latitute, Longitude = ToCity.Longitude };
                return repository.GetDistance(geoCoordinateOrigin, geoCoordinateDestinaton) * repository.GetPerKMFare();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public decimal GetPerKmFare()
        {
            try
            {
                return repository.GetPerKMFare();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdatePerKmFare(int charge)
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

        public IEnumerable<DomainModel.City> GetCitiesOfaCountry(string CountryCode)
        {
            try
            {
                return repository.GetCitiesOfCountry(CountryCode).Map<IEnumerable<DomainModel.City>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<string> StopNamesToIds(List<string> stopNames, string CountryCode)
        {
            try
            {
                 var x =repository.GetCitiesOfCountry(CountryCode).Where(c => stopNames.Contains(c.Name)).Select(c => c.Id);
                return x;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public DomainModel.City getCityByName(string originCityName, string selectedCountryCode)
        {
            try
            {
                return repository.GetCitiesOfCountry(selectedCountryCode).FirstOrDefault(c => c.Name == originCityName).Map<DomainModel.City>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<string> StopIdsToNames(List<string> StopIds, string CountryCode)
        {
            try
            {
                return repository.GetCitiesOfCountry(CountryCode).Where(c => StopIds.Contains(c.Id)).Select(c => c.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}




//Repository<City> Repository = new Repository<City>();

//public List<string> GetOriginCitiesNames()
//{
//    return (from city in Repository.List select city.CityName).ToList();
//}

//public List<string> GetDestinationCitiesNames()
//{
//    return (from  city in Repository.List where city.IsDestination == true select city.CityName).ToList();
//}

//public decimal GetDistance(string originCityName, string destinationCityName)
//{
//    var cityName = Repository.List.FirstOrDefault(l => l.CityName == originCityName)?.CityName;

//     return (from city in Repository.List where city.CityName == originCityName select city.DistanceTo).FirstOrDefault().ElementAtOrDefault(
//            (from city in Repository.List where city.CityName == destinationCityName select city.CityName).ToList().IndexOf(destinationCityName)); 
//}

//One time function to load city data into the database
/*
public void LoadCity()
{

        SwagonContext swagonContext = new SwagonContext();
        string json = System.IO.File.ReadAllText(@"C:\Users\balaji.k\Desktop\CityDis.json");
        List<DomainModel.City> cities = JsonConvert.DeserializeObject<List<DomainModel.City>>(json);
    foreach (DomainModel.City city in cities)
    {

        List<DistanceTo> distanceTo = new List<DistanceTo>();
        string ucityID =Guid.NewGuid().ToString() ;
        foreach( decimal distance in city.DistanceTo)
        {
            distanceTo.Add(new DistanceTo()
            {
                Id = Guid.NewGuid().ToString(),
                CityId = ucityID,
                Distance = distance.ToString()
            }
            );
        }

        eFRepository.Add(new DataBase.DataModel.City()
        {
            CityName = city.CityName,
            Id = ucityID,
            DistanceTo = distanceTo,
            IsDestination = 0


        });


    }

}*/
