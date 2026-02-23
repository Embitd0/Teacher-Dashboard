// Data/AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        // Add Student, ArchivedTeacher, ArchivedStudent etc. later
    }
}