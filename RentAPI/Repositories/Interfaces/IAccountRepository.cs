using RentAPI.Models;

namespace RentAPI.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> CheckUser(string username);
        Task<Account> GetAccountByPassword(string username, string password);
        Task<Account> GetAccountByRefreshToken(string token);
        void CreateAccount(Account account);
    }
}
