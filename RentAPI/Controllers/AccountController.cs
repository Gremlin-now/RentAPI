using RentAPI.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Repositories;
using RentAPI.Models;
using System.Security.Cryptography;
using System.Text;
using RentAPI.Services;
using System.Security.Claims;

namespace RentAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Account")]
    public class AccountController : Controller, IAccountController
    {
        JwtService _jwt;
        AccountRepository _accountRepository;
        [HttpGet("Me")]
        public ActionResult GetMe()
        {
            return Ok(_accountRepository.GetAccountByRefreshToken);
        }
        [HttpGet("SignIn")]
        public ActionResult SignIn(string username, string password)
        {
            throw new NotImplementedException();
        }
        [HttpGet("SignOut")]
        public ActionResult SignOut(string username, string password)
        {
            throw new NotImplementedException();
        }
        [AllowAnonymous]
        [HttpGet("SignUp")]
        public async Task<ActionResult> SignUp(string username, string password)
        {
            bool isUsernameAvailable = !await _accountRepository.CheckUser(username);
            if (!isUsernameAvailable)
            {
                return Ok("Имя пользователя уже занято");
            }
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            Account account = new Account();
            account.Username = username;
            account.Password = Convert.ToHexString(byteArray);
            account.Ballance = 0;
            account.Role = "user";
            account.Refresh_token = _jwt.CreateToken(new List<Claim>(), 72 * 60);
            return Ok(account);
        }

        [HttpGet("Update")]
        public ActionResult Update(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
