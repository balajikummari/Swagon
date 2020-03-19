using AutoMapper;
using System.Collections.Generic;
using System;
namespace Swagon.Services
{
    public static class DataToDomain_ModelMappper
    {
        private static IMapper iMapper;
        public static void Init()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DomainModel.IEntity, DataBase.DataModel.IEntity>().ReverseMap();
                    cfg.CreateMap<DomainModel.User, DataBase.DataModel.User>().ReverseMap();
                    cfg.CreateMap<DomainModel.RideOffer, DataBase.DataModel.RideOffer>().ReverseMap();
                    cfg.CreateMap<DomainModel.City, DataBase.DataModel.City>().ReverseMap();
                    cfg.CreateMap<DomainModel.Booking, DataBase.DataModel.Booking>().ReverseMap();
                });
                 iMapper = config.CreateMapper();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        /// <summary>
        /// Maps Doamain Model to DataModel and Viceversa
        /// </summary>
        /// <typeparam name="Tout">output object</typeparam>
        /// <param name="obj"> </param>
        /// <returns></returns>
        public static Tout Map<Tout>(this object obj)
        {
            try
            {
                return iMapper.Map<Tout>(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public static IEnumerable<Tout> MapCOllection<Tin, Tout>(this IEnumerable<Tin> list) where Tin : DomainModel.IEntity, DataBase.DataModel.IEntity
        {
            try
            {
                return iMapper.Map<IEnumerable<Tin>, IEnumerable<Tout>>(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
