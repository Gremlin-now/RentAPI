using RentAPI.Models;
using RentAPI.Repositories.Interfaces;

namespace RentAPI.Repositories
{
    public class AccountRepository:IAccountRepository
    {

        public readonly IConfiguration _configuration;
        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<bool> CheckAccount(string accountName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckRefreshTokenn(string token)
        {
            throw new NotImplementedException();
        }

        public Task CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetAccountByRefreshToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
