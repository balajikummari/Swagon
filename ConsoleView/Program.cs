using SimpleInjector;
using Swagon.Services;

namespace Swagon.ConsoleView
{
    internal static class Program
    {
        public static Container container = new Container();

        static Program()
        {
            ViewToDomain_ModelMapper.Init();
            DataToDomain_ModelMappper.Init();
            //container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            DIContainer.Init(container);
        }

        private static void Main(string[] args)
        {
            Startup startup = new Startup();
            startup.start();
        }
    }

}


//--- For Loading data from json to sql
/*
public static void LoadCity()
{


    SwagonContext swagonContext = new SwagonContext();
    string json = System.IO.File.ReadAllText(@"C:\Users\balaji.k\Desktop\CityDis.json");
    List<DomainModel.City> cities = JsonConvert.DeserializeObject<List<DomainModel.City>>(json);
    foreach (DomainModel.City city in cities)
    {

        string ucityID = Guid.NewGuid().ToString();

        swagonContext.Set<DataBase.DataModel.City>().Add(new DataBase.DataModel.City()
        {
            CityName = city.CityName,
            Id = ucityID,
            IsDestination = city.IsDestination
        });
        swagonContext.SaveChanges();
        foreach (int distance in city.DistanceTo)
        {
            _index = _index + 1;
            swagonContext.Set<DistanceTo>().Add(new DistanceTo()
            {
                Index = _index,
                CityId = ucityID,
                Distance = distance,
                Id = Guid.NewGuid().ToString()
            }
            );

        }
        swagonContext.SaveChanges();

    }
}
*/
