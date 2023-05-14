using Microsoft.EntityFrameworkCore;
using Student_Portal.Models;

namespace Student_Portal.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> Enrollments { get; set; }
    }
}
