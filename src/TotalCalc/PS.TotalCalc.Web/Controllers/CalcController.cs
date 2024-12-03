using Microsoft.AspNetCore.Mvc;

namespace PS.TotalCalc.Web.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
