using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface IRentController
    {
        public ActionResult GetAvailableCar(double lat, double lon, double radius, string type);
        public ActionResult GetCarByID(int id);
        public ActionResult GetHistory();
        public ActionResult PostRentCar(int transportID);
        public ActionResult PostStopRentCar(int rentId);
    }
}
