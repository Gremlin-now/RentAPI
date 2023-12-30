using RentAPI.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Account")]
    public class AccountController : Controller, IAccountController
    {
        [HttpGet("Me")]
        public ActionResult GetMe()
        {

            return Ok();
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
        [HttpGet("Update")]
        public ActionResult Update(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
