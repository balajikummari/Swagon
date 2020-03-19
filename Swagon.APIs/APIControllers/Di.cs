using SimpleInjector;
using Swagon.APIs.APIControllers;
using Swagon.Services;

namespace Swagon.APIs.Controllers
{
    public static class DIContainer
    {
        public static void AddDevDeps(Container container)
        {
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            container.Register<ICityService, CityService>(Lifestyle.Transient);
            container.Register<IRideOfferService, RideOfferService>(Lifestyle.Transient);
            container.Register<IBookingService, BookingService>(Lifestyle.Transient);
            container.Register<AppSettings>(Lifestyle.Transient);
            ServiceDependencies.AddServiceDeps(container);
            Services.DataToDomain_ModelMappper.Init();
        }
    }
}
