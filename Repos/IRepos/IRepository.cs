using Swagon.DataBase.DataModel;
using System.Collections.Generic;

namespace Swagon.DataBase.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Gets the entity of the respective ID
        /// </summary>
        /// <param name="id">Id of the entity being requested</param>
        /// <returns>entity of the respective Id or Null if something wrong happens</returns>
        T GetEntityByID(string id);

        /// <summary>
        /// Returns All the entities in database
        /// </summary>
        /// <returns>All the entities </returns>
        IEnumerable<T> GetAllEntities();

        /// <summary>
        /// Adds specified entity to the Database
        /// </summary>
        /// <param name="entity">entity to be added to the Database</param>
        /// <returns>Id of the entity that is added or Null if something wrong happens </returns>
        string AddEntity(T entity);

        /// <summary>
        /// Removes the Entity from the Database
        /// </summary>
        /// <param name="entity"></param>
        ///<returns> </returns>
        void RemoveEntity(T entity);
        /// <summary>
        /// Updates a Entity in the DataBase
        /// </summary>
        /// <param name="entity"></param>
        void UpdateEntity(T entity);
        /// <summary>
        /// save changes to the Databse
        /// </summary>
        void SaveChanges();
    }
}
