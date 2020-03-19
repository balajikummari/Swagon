using Microsoft.EntityFrameworkCore;
using Swagon.DataBase.DataModel;
using System;
using System.Linq;
using FluentValidation;

namespace Swagon.DataBase.Repositories
{
    public class EFUserRepository : EFRepository<User>, IUserReopository
    {
        public EFUserRepository(DbContext context) : base(context)
        {
        }


        public string GetUserId(string username, string password)
        {
            try
            {
                var validater = new UserValidations();
                validater.ValidateAndThrow(new User() { Username = username, Password = password }, ruleSet:RuleSets.User.crentials);
                return base.Context.Set<User>().Where(u => u.Username == username & u.Password == password).Select(u => u.Id).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
