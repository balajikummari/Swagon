using Swagon.DataBase.DataModel;

namespace Swagon.DataBase.Repositories
{
    public interface IUserReopository : IRepository<User>
    {
        /// <summary>
        /// Returns the user Id based on the right combination of  Username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>retuens userId if present</returns>
        public string GetUserId(string username, string password);
    }
}
