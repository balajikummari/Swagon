using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using Swagon.DataBase.DataModel;
using Swagon.DataBase.Repositories;
using Swagon.Services;

namespace Swagon.ConsoleView
{
    public static class DIContainer
    {
        public static void Init(Container container)
        {
            container.Register<DbContext, SwagonContext>(Lifestyle.Singleton);
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            container.Register<ICityService, CityService>(Lifestyle.Transient);
            container.Register<IRideOfferService, RideOfferService>(Lifestyle.Transient);
            container.Register<IBookingService, BookingService>(Lifestyle.Transient);


            container.Register<IBookingRepository, BookingRepository>(Lifestyle.Singleton);
            container.Register<ICityRepository, EFCityRepository>(Lifestyle.Transient);
            container.Register<IUserReopository, EFUserRepository>(Lifestyle.Transient);
            container.Register<IRideOfferRepository, RideOfferRepository>(Lifestyle.Transient);

            container.Register<EFCityRepository>(Lifestyle.Transient);
            container.Register<RideOfferUI>(Lifestyle.Transient);
            container.Register<UserDashBoard>(Lifestyle.Transient);
            container.Register<BookingUI>(Lifestyle.Transient);
            container.Register<CityUI>(Lifestyle.Transient);


            // container.Register<LoginOrSignup>(Lifestyle.Singleton);
            // container.Register<Startup>(Lifestyle.Singleton);
            container.Verify();
        }
    }
}
