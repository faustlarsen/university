// using Microsoft.EntityFrameworkCore;
// using System;
using System.Collections.Generic;
// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Department
  {
    public Department()
    {
      //this.Students = new HashSet<Student>();
      this.Courses = new HashSet<Course>();
    }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    //public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
  }
}