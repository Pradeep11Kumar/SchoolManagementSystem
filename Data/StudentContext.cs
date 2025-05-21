using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class StudentContext :DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options) 
        {
        }

        public DbSet<GroupClass> GroupClasses { get; set; }
        public DbSet<Subject> subjects { get; set; }
    }
}
