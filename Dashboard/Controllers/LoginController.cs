// Controllers/LoginController.cs
// Login checks Admin table first, then Teacher table.
// Admin → Admin dashboard | Teacher → Teacher dashboard

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _db;

        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LoggedInUser") != null)
            {
                var role = HttpContext.Session.GetString("UserRole");
                return role == "admin"
                    ? RedirectToAction("Index", "Admin")
                    : RedirectToAction("Home", "Teacher");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // ── Step 1: Check Admin table first ──────────────────────
            var admin = await _db.Admins
                .FirstOrDefaultAsync(a => a.Username == model.Username);

            if (admin != null && BCrypt.Net.BCrypt.Verify(model.Password, admin.Password))
            {
                HttpContext.Session.SetString("LoggedInUser", admin.Username);
                HttpContext.Session.SetString("UserRole", "admin");
                HttpContext.Session.SetString("DisplayName", admin.FullName);
                return RedirectToAction("Index", "Admin");
            }

            // ── Step 2: Check Teacher table ───────────────────────────
            var teacher = await _db.Teachers
                .FirstOrDefaultAsync(t => t.Username == model.Username);

            if (teacher != null && BCrypt.Net.BCrypt.Verify(model.Password, teacher.Password))
            {
                HttpContext.Session.SetString("LoggedInUser", teacher.Username);
                HttpContext.Session.SetString("UserRole", "teacher");
                HttpContext.Session.SetString("DisplayName", teacher.Name);
                return RedirectToAction("Home", "Teacher");
            }

            // ── Step 3: Neither matched ───────────────────────────────
            ModelState.AddModelError("", "INVALID USERNAME OR PASSWORD.");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}