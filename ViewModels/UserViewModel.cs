namespace Swagon.ViewModels
{

    public class UserCredentials : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserMetaData : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string Cityofliving { get; set; }
    }
}
