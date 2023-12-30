using RentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface IAdminRentController
    {
        public ActionResult GetRentByID(int id);
        public ActionResult GetUserHistory(int userId);
        public ActionResult GetTransportHistory(int transportId);
        public ActionResult CreateNewRent(Rent rent);
        public ActionResult StopRent(int id);
        public ActionResult EditRent(int id);
        public ActionResult DeleteRent(int id);
    }
}
