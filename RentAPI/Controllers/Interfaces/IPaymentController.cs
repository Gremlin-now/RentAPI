using Microsoft.AspNetCore.Mvc;

namespace RentAPI.Controllers.Interfaces
{
    public interface IPaymentController
    {
        public ActionResult hesoyam(int accountId);
    }
}
