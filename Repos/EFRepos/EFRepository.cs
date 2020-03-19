using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Swagon.DataBase.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Swagon.DataBase.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {

        public DbContext Context;

        public EFRepository(DbContext context)
        {
            Context = context;
        }

        public string AddEntity(T entity)
        {
            try
            {
                if (entity.Id == null || entity.Id.Length < 5 || entity.Id == "")
                {
                    entity.Id = Guid.NewGuid().ToString();
                }
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
                return entity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }


        public T GetEntityByID(string id)
        {
            new BasicStringValidations().ValidateAndThrow(id);
            try
            {
                return Context.Set<T>().FirstOrDefault(et => et.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public IEnumerable<T> GetAllEntities()
        {
            try
            {
                return Context.Set<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        public void RemoveEntity(T entity)
        {
            new BasicStringValidations().ValidateAndThrow(entity.Id);
            try
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdateEntity(T entity)
        {
            new BasicStringValidations().ValidateAndThrow(entity.Id);
            try
            {
                Context.Set<T>().Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }


}
