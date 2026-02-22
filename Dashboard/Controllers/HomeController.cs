// Controllers/LoginController.cs
// Nag-query sa MySQL Teacher table para i-verify ang credentials.
// Plain text password comparison muna — walang BCrypt needed.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class LoginController : Controller
    {
        // Ini-inject ng DI container ang AppDbContext —
        // tinukoy ito sa Program.cs
        private readonly AppDbContext _db;

        public LoginController(AppDbContext db)
        {
            _db = db;
        }

        // GET /Login — ipakita ang login form
        [HttpGet]
        public IActionResult Index()
        {
            // Kung naka-login na, i-redirect agad sa dashboard
            if (HttpContext.Session.GetString("LoggedInUser") != null)
                return RedirectToAction("Home", "Teacher");

            return View(new LoginViewModel());
        }

        // POST /Login — i-verify ang credentials laban sa DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            // Suriin ang Required validation bago mag-query sa DB
            if (!ModelState.IsValid)
                return View(model);

            // Hanapin ang teacher sa DB na may matching username
            var teacher = await _db.Teachers
                .FirstOrDefaultAsync(t => t.Username == model.Username);

            // I-compare ang password directly (plain text muna)
            // TODO: palitan ito ng BCrypt.Verify() kapag may hashing na
            bool isValid = teacher != null
            && BCrypt.Net.BCrypt.Verify(model.Password, teacher.Password);

            if (!isValid)
            {
                // Hindi sinasabi kung username o password ang mali —
                // para hindi malaman ng attacker kung may existing account
                ModelState.AddModelError("", "INVALID USERNAME OR PASSWORD.");
                return View(model);
            }

            // I-save ang username sa session
            HttpContext.Session.SetString("LoggedInUser", teacher.Username);

            return RedirectToAction("Home", "Teacher");
        }

        // GET /Login/Logout — burahin ang session at bumalik sa login
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}