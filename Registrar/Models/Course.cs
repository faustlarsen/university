using System.Collections.Generic;

namespace Registrar.Models
{
    public class Course
    {
        public Course()
        {
            this.Student = new HashSet<CourseStudent>();
        }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<CourseStudent> Students { get; set; }
    }
}