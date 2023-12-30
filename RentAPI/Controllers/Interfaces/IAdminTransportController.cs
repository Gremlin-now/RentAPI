using RentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface IAdminTransportController
    {
        public ActionResult GetAllTransport();
        public ActionResult GetTransport(int id);
        public ActionResult AddTransport(Transport transport);
        public ActionResult EditTransport(int id, Transport transport);
        public ActionResult DeleteTransport(int id);
    }
}
