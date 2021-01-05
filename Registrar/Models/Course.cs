using System.Collections.Generic;

namespace Registrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<CourseStudent>();
    }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public virtual ICollection<CourseStudent> Students { get; set; }
    // public int DepartmentId { get; set; }
    // public virtual Department Department { get; set; }
  }
}