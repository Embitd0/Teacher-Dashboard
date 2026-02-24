// Controllers/AdminController.cs
// FRONTEND STUB — routes to views, no DB yet.

using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class AdminController : Controller
    {
        private bool IsAdmin() =>
            HttpContext.Session.GetString("UserRole") == "admin";

        // GET /Admin — Main Menu (landing page after login)
        public IActionResult Index()
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("MainMenu");
        }

        // GET /Admin/ActiveAccounts — Students table (default)
        public IActionResult ActiveAccounts()
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("ActiveStudents");
        }

        // GET /Admin/ActiveTeachers — Teachers table
        public IActionResult ActiveTeachers()
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("ActiveTeachers");
        }

        // GET /Admin/Archive — Archive (Students default, Teachers toggle)
        public IActionResult Archive()
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("Archive");
        }

        // GET /Admin/EditTeacher/{id}
        public IActionResult EditTeacher(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("EditTeacher");
        }

        // GET /Admin/EditStudent/{id}
        public IActionResult EditStudent(int id)
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("EditStudent");
        }

        // GET /Admin/ConfirmDeactivate
        public IActionResult ConfirmDeactivate(string type, string id)
        {
            if (!IsAdmin()) return RedirectToAction("Index", "Login");
            return View("ConfirmDeactivate");
        }
    }
}