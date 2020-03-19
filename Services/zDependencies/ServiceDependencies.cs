using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using Swagon.DataBase.DataModel;
using Swagon.DataBase.Repositories;



namespace Swagon.Services
{

    public static class ServiceDependencies
    {
        public static void AddServiceDeps(Container container)
        {
            container.Register<DbContext, SwagonContext>(Lifestyle.Singleton);
            container.Register<IBookingRepository, BookingRepository>(Lifestyle.Singleton);
            container.Register<ICityRepository, EFCityRepository>(Lifestyle.Transient);
            container.Register<IUserReopository, EFUserRepository>(Lifestyle.Transient);
            container.Register<IRideOfferRepository, RideOfferRepository>(Lifestyle.Transient);
        }
    }
}
