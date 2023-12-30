using Dapper;
using Npgsql;
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

        public Task<Account> GetAccountByPassword(string username, string password)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                var account = db.Query($@"select
                    username as {nameof(Account.Username)},
                    password as {nameof(Account.Password)},
                    refresh_token as {nameof(Account.Refresh_token)}
                    from accounts where username = @username
                    ", new { username = username }).FirstOrDefault();
                if(password == account.Password)
                {
                    return GetAccountByRefreshToken(account.Refresh_token);
                }
                return Task.FromResult(new Account());
            }
        }
        public void CreateAccount(Account account)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                db.Execute($@"insert into accounts 
                    (username, password, ballance, role, refresh_token) 
                    values
                    (@{nameof(Account.Username)},
                    @{nameof(Account.Password)},
                    @{nameof(Account.Ballance)},
                    @{nameof(Account.Role)},
                    @{nameof(Account.Refresh_token)})", account
                );
            }
        }
        public async Task<Account> GetAccountByRefreshToken(string token)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                Account account = db.Query($@"select
                    id as {nameof(Account.Id)},
                    username as {nameof(Account.Username)},
                    password as {nameof(Account.Password)},
                    ballance as {nameof(Account.Ballance)},
                    Role as {nameof(Account.Role)},
                    refresh_token as {nameof(Account.Refresh_token)}
                    from accounts where refresh_token = @token
                    ", new { token = token }).FirstOrDefault();
                return account;
            }
        }

        public Task<bool> CheckUser(string username)
        {
            using (var db = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSQL")))
            {
                return db.Query($@"select
                    username as {nameof(Account.Username)},
                    from accounts where refresh_token = @token
                    ", new { username = username }).FirstOrDefault();
            }
        }
    }
}
