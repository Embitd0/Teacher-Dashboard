using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult StudentProgress()
        {
            return View();
        }

        public IActionResult ViewStudent()
        {
            return View();
        }
    }
}
