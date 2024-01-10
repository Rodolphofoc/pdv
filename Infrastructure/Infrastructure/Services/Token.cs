using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Token
    {
        public bool Authenticated { get; set; }
        public string? Created { get; set; }
        public string? Expiration { get; set; }
        public string? AccessToken { get; set; }
        public string? Message { get; set; }
    }

    public class TokenConfigurations
    {
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public int Seconds { get; set; }
        public string? SecretJwtKey { get; set; }
    }

    public static class Roles
    {
        public const string? ROLE_ACESSO_APIS = "Acesso-APIs";
    }
}
