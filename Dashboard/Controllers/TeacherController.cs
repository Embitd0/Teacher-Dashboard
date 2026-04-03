using Microsoft.AspNetCore.Mvc;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _db;

        public TeacherController(AppDbContext db)
        {
            _db = db;
        }

        private bool IsLoggedIn() =>
            HttpContext.Session.GetString("LoggedInUser") != null;

        // GET /Teacher/Home
        public IActionResult Home()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");
            return View();
        }

        // GET /Teacher/StudentProgress
        public async Task<IActionResult> StudentProgress()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");

            var students = await _db.Students.ToListAsync();
            return View(students);
        }

        // GET /Teacher/ViewStudent/{lrn}
        // lrn is a string (VARCHAR in DB)
        public async Task<IActionResult> ViewStudent(string id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");

            var student = await _db.Students.FindAsync(id);
            if (student == null)
                return RedirectToAction("StudentProgress");

            return View(student);
        }
    }
}