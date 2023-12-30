using RentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface ITransportController
    {
        public ActionResult GetById(int id);
        public ActionResult AddCar(Transport transport);
        public ActionResult UpdateCarById(int id, Transport transport);
        public ActionResult DeleteCar(int id);
    }
}
