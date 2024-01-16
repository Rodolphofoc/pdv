using Domain;
using MediatR;

namespace Applications.Auth.Queries
{
    public class AuthQuery : IRequest<Response>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public AuthQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
