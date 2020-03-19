using Swagon.DataBase.Repositories;
using Swagon.DataBase;
using FluentValidation;
using System;


namespace Swagon.Services
{

    public class UserService : IUserService
    {
        private readonly IUserReopository repository;

        public UserService(IUserReopository repository)
        {

            this.repository = repository;
        }

        public void AddUser(DomainModel.User user)
        {
            try
            {
                new UserValidations().ValidateAndThrow(user.Map<DataBase.DataModel.User>(),RuleSets.User.crentials);
                DataToDomain_ModelMappper.Init();
                repository.AddEntity(user.Map<DataBase.DataModel.User>());
                repository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public string GetUserIdFromCredentials(DomainModel.User user)
        {
            try
            {
                new UserValidations().ValidateAndThrow(user.Map<DataBase.DataModel.User>(), RuleSets.User.crentials);
                return repository.GetUserId(user.Username, user.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public DomainModel.User GetUserById(string Id)
        {
            try
            {
                new BasicStringValidations().Validate(Id, RuleSets.String.EmptyString);
                return repository.GetEntityByID(Id).Map<DomainModel.User>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void UpdateUserProfile(DomainModel.User UpdatedUserInfo)
        {
            try
            {
                new UserValidations().ValidateAndThrow(UpdatedUserInfo.Map<DataBase.DataModel.User>(), RuleSets.User.profile);
                DataBase.DataModel.User UserTObeUpdated = repository.GetEntityByID(UpdatedUserInfo.Id);
                UserTObeUpdated.Firstname = UpdatedUserInfo.Firstname;
                UserTObeUpdated.Lastname = UpdatedUserInfo.Lastname;
                UserTObeUpdated.Phonenumber = UpdatedUserInfo.Phonenumber;
                UserTObeUpdated.Cityofliving = UpdatedUserInfo.Cityofliving;
                repository.UpdateEntity(UserTObeUpdated);
                repository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void RemoveUser(DomainModel.User user)
        {
            try
            {
                new UserValidations().ValidateAndThrow(user.Map<DataBase.DataModel.User>(), RuleSets.User.crentials);
                repository.RemoveEntity(user.Map<DataBase.DataModel.User>());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
