// Controllers/AdminController.cs
// FRONTEND STUB — just routes to views for now.
// Backend DB wiring comes later.

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class AdminController : Controller
    {
        // Checks that the logged-in user is an admin
        private bool IsAdmin() =>
            HttpContext.Session.GetString("UserRole") == "admin";

        // GET /Admin — Active accounts list
        public IActionResult Index()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Login");

            return View("IndexTeachers");
        }

        // GET /Admin/Archive
        public IActionResult Archive()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Login");

            return View("ArchiveTeachers");
        }

        // GET /Admin/EditTeacher/{id}
        public IActionResult EditTeacher(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Login");

            return View("EditTeacher");
        }

        // GET /Admin/ConfirmDeactivate/{id}
        public IActionResult ConfirmDeactivate(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Login");

            return View("ConfirmDeactivate");
        }
    }
}