using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
        this.Courses = new HashSet<CourseStudent>();
    }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        [DisplayName("DateOfEnrollment")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfEnrollement { get; set; }
        public ICollection<CourseStudent> Courses { get; }
  }
}