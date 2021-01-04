using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
        public DateTime DateOfEnrollement { get; set; }
        public ICollection<CourseStudent> Courses { get; }

    }
}

// DateTime date1 = new DateTime(2008, 6, 1);
//   // Get date-only portion of date, without its time.
//   DateTime dateOnly = date1.Date;
//   // Display date using short date string.
//   Console.WriteLine(dateOnly.ToString("d"));