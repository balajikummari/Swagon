using Swagon.DataBase.DataModel;
using System;
using System.Collections.Generic;
using System.IO;


namespace Swagon.DataBase
{
    public class EntityMapping<T> where T : IEntity
    {
        public Dictionary<Type, string> EntityMap = new Dictionary<Type, string>();

        public EntityMapping()
        {
            EntityMap.Add(typeof(User), $"{Directory.GetCurrentDirectory() + "/Database/User.json"}");
            EntityMap.Add(typeof(City), $"{Directory.GetCurrentDirectory() + "/Database/OCityData.json"}");
            EntityMap.Add(typeof(RideOffer), $"{Directory.GetCurrentDirectory() + "/Database/RideOffer.json"}");
            EntityMap.Add(typeof(Booking), $"{Directory.GetCurrentDirectory() + "/Database/Booking.json"}");
        }

    }
}
