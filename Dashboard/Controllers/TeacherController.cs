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
        public async Task<IActionResult> ViewStudent(string id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Index", "Login");

            var student = await _db.Students.FindAsync(id);
            if (student == null)
                return RedirectToAction("StudentProgress");

            var scores = await _db.PuzzleQuestScores
                .Where(s => s.Lrn == id)
                .OrderByDescending(s => s.DateCompleted)
                .ToListAsync();

            var badges = await _db.StudentBadges
                .Where(b => b.Lrn == id)
                .Include(b => b.Badge)
                .ToListAsync();

            ViewBag.Scores = scores;
            ViewBag.Badges = badges;
            return View(student);
        }
    }
}