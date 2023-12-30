using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface IAccountController
    {
        public ActionResult GetMe();
        public ActionResult SignIn(string username, string password);
        public Task<ActionResult> SignUp(string username, string password);
        public ActionResult SignOut(string username, string password);
        public ActionResult Update(string username, string password);
    }
}
