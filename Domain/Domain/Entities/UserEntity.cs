namespace Domain.Entities
{
    public class UserEntity : Entity
    {
        public UserEntity(string name, string login, string password)
        {
            Name = name;
            Login = login;
            Password = password;
        }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
