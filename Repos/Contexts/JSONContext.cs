using Newtonsoft.Json;
using Swagon.DataBase.DataModel;
using System.Collections.Generic;
using System.IO;

namespace Swagon.DataBase
{
    public class JSONContext<T> : IContext<T> where T : IEntity
    {
        private readonly EntityMapping<T> mapping;
        private List<T> Entites = new List<T>();
        public JSONContext()
        {
            mapping = new EntityMapping<T>();
            if (File.Exists(mapping.EntityMap[typeof(T)])) { LoadData(); }
            else { SaveChanges(); LoadData(); };
        }

        public void Add(T entity)
        {
            Entites.Add(entity);
        }

        public List<T> GetAll()
        {
            return Entites;
        }

        public void SaveChanges()
        {
            string updatedJSON = JsonConvert.SerializeObject(Entites);
            System.IO.File.WriteAllText(mapping.EntityMap[typeof(T)], updatedJSON);
        }

        internal void LoadData()
        {
            string json = System.IO.File.ReadAllText(mapping.EntityMap[typeof(T)]);
            Entites = JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
