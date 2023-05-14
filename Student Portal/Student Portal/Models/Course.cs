using System.Collections.Generic;

namespace Student_Portal.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public ICollection<StudentCourse> Enrollemt { get; set; }
    }
}
