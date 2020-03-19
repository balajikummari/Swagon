namespace Swagon.DataBase.DataModel
{
    public interface IEntity
    {
        public string Id { get; set; }
    }

    public partial class User : IEntity
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Cityofliving { get; set; }
        public string SecretInfo { get; set; }
    }
}
