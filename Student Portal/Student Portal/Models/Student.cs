using System;
using System.Collections.Generic;

namespace Student_Portal.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime Enrolled { get; set; }
        public ICollection<StudentCourse> Enrollemt { get; set; } = new HashSet<StudentCourse>();
    }
}
