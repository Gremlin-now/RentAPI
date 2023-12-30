using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RentAPI.Models
{
    public abstract class AuthOptions
    {
        public const string Issuer = "MyAuthServer";
        public const string Audience = "MyAuthClient";
        const string Key = "wtuNRpAZ3n7iWgWGKPeSEgQUTHGFOOEe-YS4PxHFnir7F881";
        public const int TokenExpiresAfterMinutes = 2;

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
    }
}
