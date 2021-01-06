using System.Collections.Generic;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<Course>();
    }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
  }
}