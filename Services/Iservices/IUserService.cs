namespace Swagon.Services
{
    public interface IUserService
    {
        
        public void AddUser(DomainModel.User user);
        public string GetUserIdFromCredentials(DomainModel.User user);
        public DomainModel.User GetUserById(string Id);
        public void UpdateUserProfile(DomainModel.User UpdatedUser);
        public void RemoveUser(DomainModel.User user);
    }
}
