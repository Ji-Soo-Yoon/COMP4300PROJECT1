using Microsoft.EntityFrameworkCore;
using CourseRegistrationSystem.Models;

namespace CourseRegistrationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}
