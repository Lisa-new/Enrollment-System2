using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Enrollment_System.Models
{
    public class StudentItem
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}
