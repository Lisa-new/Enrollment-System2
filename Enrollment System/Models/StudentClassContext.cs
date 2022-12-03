using Microsoft.EntityFrameworkCore;

namespace Enrollment_System.Models
{
    public class StudentClassContext : DbContext
    {
        public StudentClassContext(DbContextOptions<StudentClassContext> options) : base(options)
        { }
        public DbSet<StudentClassItem> StudentClassItems { get; set; } = null!;

    }
}


