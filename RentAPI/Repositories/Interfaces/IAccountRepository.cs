using RentAPI.Models;

namespace RentAPI.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> CheckAccount(string accountName);
        Task<bool> CheckRefreshTokenn(string token);
        Task<Account> GetAccountByRefreshToken(string token);
        Task CreateAccount(Account account);
    }
}
