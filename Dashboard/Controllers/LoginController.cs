using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
