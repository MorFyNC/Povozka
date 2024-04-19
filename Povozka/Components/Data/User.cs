namespace Povozka.Components.Data
{
    public class User
    {
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid ID { get; set; }

        public User(string username, string login, string pass)
        {
            ID = Guid.NewGuid();
            Username = username;
            Login = login;
            Password = pass;
        }
    }
}
