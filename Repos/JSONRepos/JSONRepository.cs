using Swagon.DataBase.DataModel;
using System;
using System.Collections.Generic;

namespace Swagon.DataBase.Repositories
{
    public class JSONRepository<T> : IRepository<T> where T : class, IEntity
    {

        public JSONContext<T> JSONContext;

        public JSONRepository()
        {
            JSONContext = new JSONContext<T>();
        }

        public void AddEntity(T entity)
        {
            JSONContext.Add(entity);
            JSONContext.SaveChanges();
        }

        public T GetEntityByID(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public void RemoveEntity(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(T entity)
        {
            throw new NotImplementedException();
        }

        string IRepository<T>.AddEntity(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
