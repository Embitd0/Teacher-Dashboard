// Controllers/TeacherController.cs
// Dinagdagan lang ng IsLoggedIn() check sa bawat action
// para hindi ma-access ng hindi naka-login na user ang dashboard.

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class TeacherController : Controller
    {
        // Sinisigurado na may aktibong session bago ipakita ang kahit anong page.
        // Kapag nag-integrate ka na ng ASP.NET Core Identity,
        // pwede mo palitan ito ng [Authorize] attribute.
        private bool IsLoggedIn() =>
            HttpContext.Session.GetString("LoggedInUser") != null;

        public IActionResult Home()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");

            return View();
        }

        public IActionResult StudentProgress()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");

            return View();
        }

        public IActionResult ViewStudent()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");

            return View();
        }
    }
}