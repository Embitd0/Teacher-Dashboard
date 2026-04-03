using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<PuzzleQuestScore> PuzzleQuestScores { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<StudentBadge> StudentBadges { get; set; }
    }
}