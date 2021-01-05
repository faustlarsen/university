using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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