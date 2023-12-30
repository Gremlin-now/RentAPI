using RentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface IAdminAccountController
    {
        public ActionResult GetAllAccounts();
        public ActionResult GetAccount(int id);
        public ActionResult AccountCreate(Account account);
        public ActionResult EditAccount(int id);
        public ActionResult DeleteAccount(int id);
    }
}
