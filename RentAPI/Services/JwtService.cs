using System.IdentityModel.Tokens.Jwt;
using RentAPI.Models;
using RentAPI.Repositories.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace RentAPI.Services
{
    public class JwtService
    {
        readonly IAccountRepository _accountRepository;
        public JwtService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public string CreateToken(ICollection<Claim> claims, int tokenExpiresAfterMinutes = 0) {
            var authSigningKey = AuthOptions.GetSymmetricSecurityKey();
            if (tokenExpiresAfterMinutes == 0)
            {
                tokenExpiresAfterMinutes = AuthOptions.TokenExpiresAfterMinutes;
            }
            var token = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                expires: DateTime.UtcNow.AddMinutes(tokenExpiresAfterMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<AuthTokenPair> ExpireToken(string token)
        {
            var account = await _accountRepository.GetAccountByRefreshToken(token);
            // вставить обработчики ошибок

            var claims = new List<Claim>() {
                new Claim("accountId", account.Id.ToString()),
                new Claim("username", account.Username),
                new Claim("role", account.Role),
            };

            string accessToken = CreateToken(new List<Claim>(), 72*60);
            string refreshToken = CreateToken(claims, 2);

            return new AuthTokenPair()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
