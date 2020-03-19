using System.Collections.Generic;


namespace Swagon.Services
{
    public interface ICityService
    {
        public decimal GetPerKmFare();
        public void UpdatePerKmFare(int charge);
        public DomainModel.City GetCityById(string cityId);
        public IEnumerable<string> GetCountryCodes();
        public IEnumerable<DomainModel.City> GetCitiesOfaCountry(string CountryCode);
        public double GetFare(string FromCityId, string ToCityId);
        public IEnumerable<string> StopNamesToIds(List<string> stopNames, string CountryCode);
        public IEnumerable<string> StopIdsToNames(List<string> StopIds, string CountryCode);

        DomainModel.City getCityByName(string originCityName, string selectedCountryCode);
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
