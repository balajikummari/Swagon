using AutoMapper;
using Swagon.DomainModel;
using Swagon.ViewModels;
using System.Collections.Generic;



namespace Swagon.ConsoleView
{


    public static class ViewToDomain_ModelMapper
    {
        private static IMapper iMapper;
        public static void Init()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, IEntity>().ReverseMap();
                cfg.CreateMap<UserCredentials, User>().IncludeBase<Entity, IEntity>().ReverseMap();
                cfg.CreateMap<UserMetaData, User>().IncludeBase<Entity, IEntity>().ReverseMap();

                cfg.CreateMap<RideOfferViewModel, RideOffer>().IncludeBase<Entity, IEntity>().ReverseMap();
                cfg.CreateMap<BookingViewModel, Booking>().IncludeBase<Entity, IEntity>().ReverseMap();
                cfg.CreateMap<BookingStatusViewModel, Booking>().IncludeBase<Entity, IEntity>().ReverseMap();
                cfg.CreateMap<CityViewModel, City>().IncludeBase<Entity, IEntity>().ReverseMap();

            });
            iMapper = config.CreateMapper();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Tout MapV2D<Tout>(this object obj)
        {
            return iMapper.Map<Tout>(obj);
        }

        public static IEnumerable<Tout> MapCOllection<Tin, Tout>(this IEnumerable<Tin> list) where Tin : IEntity
        {
            return iMapper.Map<IEnumerable<Tin>, IEnumerable<Tout>>(list);
        }


    }
}